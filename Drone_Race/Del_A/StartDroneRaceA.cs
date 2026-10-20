
public class StartDroneRaceA
{
    public static void StartDroneRace()
    {
        var drone1 = new DroneModel("Bernt", 10, 400);
        var drone2 = new DroneModel("Geir-Arne", 9, 800);

        var runDrone1 = new Thread(() => DroneControllerA.RunDrone(drone1));
        runDrone1.Start();

        var runDrone2 = new Thread(() => DroneControllerA.RunDrone(drone2));
        runDrone2.Start();

        runDrone1.Join();
        runDrone2.Join();

        Console.WriteLine("All drones have completed their runs.");
    }
}