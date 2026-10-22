

public class DroneControllerA
{
    public static void RunDrone(DroneModel drone)
    {
        if(drone.DelayMs < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(drone.DelayMs),
                $"Drone has an invalid delay");
        }
        
        if(drone.MaxCheckpoints < 1)
        {
            throw new InvalidOperationException(
                $"Drone Has invalid checkpoint count");
        }

        Console.WriteLine($"Drone: {drone.Name} has started its run.");
        for(int i = 0; i <= drone.MaxCheckpoints; i++)
        {
            Console.WriteLine($"Drone: {drone.Name} has reached checkpoint: {i} out of {drone.MaxCheckpoints}.");
            Thread.Sleep(drone.DelayMs);
        }
        Console.WriteLine($"Drone: {drone.Name} has finished its run.");
    }
}