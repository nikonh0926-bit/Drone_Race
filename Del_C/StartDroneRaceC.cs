using Spectre.Console;

public class StartDroneRaceC

{
    public static async Task StartDroneRace(HttpClient client)
    {
        try
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(
            "DroneSimulator/1.0 (Kontakt: nikonh0926@gmail.com)");

            client.Timeout = TimeSpan.FromSeconds(10);

            string[] endpoints =
            [
                // Tønsberg
                "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.2675&lon=10.4076",

                // Horten
                "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.4170&lon=10.4830",

                // Oslo
                "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.9139&lon=10.7522",

                // Bergen
                "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=60.3913&lon=5.3221",

                // Sandefjord
                "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=59.1312&lon=10.2166"
            ];

            Task<double> tønsberg = GetWeatherStatus.GetWeather(endpoints[0], client);
            Task<double> horten = GetWeatherStatus.GetWeather(endpoints[1], client);
            Task<double> oslo = GetWeatherStatus.GetWeather(endpoints[2], client);
            Task<double> bergen = GetWeatherStatus.GetWeather(endpoints[3], client);
            Task<double> sandefjord = GetWeatherStatus.GetWeather(endpoints[4], client);

            Task<double>[] weatherstatuses = 
            [
                tønsberg,
                horten,
                oslo,
                bergen,
                sandefjord
            ];

            double[] multipliers = await Task.WhenAll(weatherstatuses);

            var drone1 = new DroneModel("Bernt", 13, 400, 0);
            var drone2 = new DroneModel("Geir-Arne", 9, 800, 1);
            var drone3 = new DroneModel("Steinar", 10, 600, 2);
            var drone4 = new DroneModel("Jonas", 6, 1200, 3);
            var drone5 = new DroneModel("Eskil", 5, 1600, 4);

            DroneModel[] drones = [ drone1, drone2, drone3, drone4, drone5 ];

            foreach (DroneModel drone in drones)
                {
                    drone.DelayMs = (int)Math.Round(drone.DelayMs * multipliers[drone.Location]);
                    drone.multiplier = multipliers[drone.Location];
                }

            Task[] droneTasks = 
            [
                DroneControllerC.RunDroneAsync(drone1),
                DroneControllerC.RunDroneAsync(drone2),
                DroneControllerC.RunDroneAsync(drone3),
                DroneControllerC.RunDroneAsync(drone4),
                DroneControllerC.RunDroneAsync(drone5)
            ];

            string[] errors = new string[droneTasks.Length];

            try
            {
                await Task.WhenAll(droneTasks);

                AnsiConsole.WriteLine("\n\nAll drones have completed their runs.");
            }
            catch
            {
                AnsiConsole.WriteLine($"\n\nOne or more drones terminated with error");

                // collect exceptions
                for(int i = 0; i < droneTasks.Length; i++)
                {
                    if (droneTasks[i].Exception is { } ex)
                    {
                        errors[i] = ex.GetBaseException().Message;
                    }        
                }
            }

            // status reports
            for (int i = 0; i < droneTasks.Length; i++)
            {
                if (droneTasks[i].IsCompletedSuccessfully)
                {
                    AnsiConsole.WriteLine(
                        $"\nDrone: {drones[i].Name} completed its run successfully." + 
                        $"\nWeather multiplier{multipliers[drones[i].Location]}" +
                        $"\nDelay: {drones[i].DelayMs}\n"
                    );
                }
                else
                {
                    AnsiConsole.WriteLine(
                        $"\nDrone: {drones[i].Name} failed its operation. " +
                        $"\nWith error message {errors[i]}" + 
                        $"\nWeather multiplier{multipliers[drones[i].Location]}" +
                        $"\nDelay: {drones[i].DelayMs}\n"
                    );
                }
            }

        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            AnsiConsole.MarkupLine(
                "\n[yellow]Trykk en tast for å avslutte.[/]");
            Console.ReadKey(true);
        }
    } 
}
