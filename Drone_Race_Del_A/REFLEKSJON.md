

Del A.

Laget DroneModell med parametere: Name, MaxCheckpoints og DelayMs

Laget DroneController.cs med en enkel metode for og simulere et "run" for hver drone.

Join()
Det er interessant og se hva join() gjør for koden.
Når Join() fra begge threads er det, venter den med og si at alle droner er ferdige med sine "runs".
Men når de ikke er der så blir alle dronene logget som ferdig med en gang, før en drone har kommet til første sjekkpunkt.