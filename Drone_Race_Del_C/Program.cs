
var drone1 = new DroneModel("Bernt", 10, 400);
var drone2 = new DroneModel("Geir-Arne", 9, 800);

var runDrone1 = DroneController.RunDroneAsync(drone2);
var runDrone2 = DroneController.RunDroneAsync(drone1);

await Task.WhenAll(runDrone1, runDrone2);

Console.WriteLine("All drones have completed their runs.");