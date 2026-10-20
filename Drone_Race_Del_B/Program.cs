
var drone1 = new DroneModel("Bernt", 13, 400);
var drone2 = new DroneModel("Geir-Arne", 9, 800);
var drone3 = new DroneModel("Idiot", 10, 600, true);
var drone4 = new DroneModel("Jonas", 6, 1200);
var drone5 = new DroneModel("Dumbass", 5, -100);

DroneModel[] drones = [ drone1, drone2, drone3, drone4, drone5 ];

Task[] droneTasks = 
[
    DroneController.RunDroneAsync(drone1),
    DroneController.RunDroneAsync(drone2),
    DroneController.RunDroneAsync(drone3),
    DroneController.RunDroneAsync(drone4),
    DroneController.RunDroneAsync(drone5)
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
    
    // report exceptions
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


