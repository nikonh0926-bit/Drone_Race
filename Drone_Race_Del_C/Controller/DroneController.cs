

public class DroneController
{
    public static async Task RunDroneAsync(DroneModel drone)
    {
        Console.WriteLine($"Drone: {drone.Name} has started its run.");
        for(int i = 0; i < drone.MaxCheckpoints; i++)
        {
            Console.WriteLine($"Drone: {drone.Name} has reached checkpoint: {i} out of {drone.MaxCheckpoints}.");
            await Task.Delay(drone.DelayMs);
        }
        Console.WriteLine($"Drone: {drone.Name} has finished its run.");
    }
}