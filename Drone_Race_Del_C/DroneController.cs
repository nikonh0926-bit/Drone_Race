

public class DroneController
{
    public static async Task RunDroneAsync(DroneModel drone)
    {
        if(drone.DelayMs < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(drone.DelayMs),
                $"Drone has an invalid delay");
        }

        // simulate a motor error
        bool motorFailure = Random.Shared.Next(2) == 0;

        int failureCheckpoint = motorFailure
            ? Random.Shared.Next(1, drone.MaxCheckpoints + 1)
            : -1;

        Console.WriteLine($"Drone: {drone.Name} has started its run.");
        for(int i = 0; i <= drone.MaxCheckpoints; i++)
        {
            

            Console.WriteLine($"Drone: {drone.Name} has reached checkpoint: {i} out of {drone.MaxCheckpoints}.");
            await Task.Delay(drone.DelayMs);

            if (i == failureCheckpoint)
            {
                throw new InvalidOperationException(
                    $"Drone suffered a motor failure at checkpoint {i}.");
            }
        }
        Console.WriteLine($"Drone: {drone.Name} has finished its run.");
    }
}

