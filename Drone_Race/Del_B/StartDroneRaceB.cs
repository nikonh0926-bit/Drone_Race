
public class StartDroneRaceB
{
    
    public static async Task StartDroneRace()
    {
        var drone1 = new DroneModel("Bernt", 13, 400);
        var drone2 = new DroneModel("Geir-Arne", 9, 800);
        var drone3 = new DroneModel("Steinar", 10, 600);
        var drone4 = new DroneModel("Jonas", 6, 1200);
        var drone5 = new DroneModel("Dumbass", 5, -100);

        DroneModel[] drones = [ drone1, drone2, drone3, drone4, drone5 ];

        Task[] droneTasks = 
        [
            DroneControllerB.RunDroneAsync(drone1),
            DroneControllerB.RunDroneAsync(drone2),
            DroneControllerB.RunDroneAsync(drone3),
            DroneControllerB.RunDroneAsync(drone4),
            DroneControllerB.RunDroneAsync(drone5)
        ];

        string[] errors = new string[droneTasks.Length];

        try
        {
            await Task.WhenAll(droneTasks);

            Console.WriteLine("\n\nAll drones have completed their runs.");
        }
        catch
        {
            Console.WriteLine($"\n\nOne or more drones terminated with error");

            // collect exceptions
            for(int i = 0; i < droneTasks.Length; i++)
            {
                if (droneTasks[i].Exception is { } ex)
                {
                    errors[i] = ex.GetBaseException().Message;
                }        
            } 
        }   

        for (int i = 0; i < droneTasks.Length; i++)
        {
            if (droneTasks[i].IsCompletedSuccessfully)
            {
                Console.WriteLine($"Drone: {drones[i].Name} completed its run successfully.");
            }
            else
            {
                Console.WriteLine(
                    $"Drone: {drones[i].Name} failed its operation. " +
                    $"With error message {errors[i]}");
            }
        }             
    }
}
