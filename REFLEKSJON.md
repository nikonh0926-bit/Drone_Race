

Del A

Laget DroneModell med parametere: Name, MaxCheckpoints og DelayMs

Laget DroneController.cs med en enkel metode for og simulere et "run" for hver drone.

Join()
Det er interessant og se hva join() gjør for koden.
Når Join() fra begge threads er det, venter den med og si at alle droner er ferdige med sine "runs".
Men når de ikke er der så blir alle dronene logget som ferdig med en gang, før en drone har kommet til første sjekkpunkt.


Del B

Den største forskjellen mellom async/await operasjon er at den er implicit. Det gjør det mye lettere og sette opp forskjellige tasks.
Ulikt Thread hvor hver eneste Thread må bli satt opp eksplisitt.
Det gjør det mye lettere og separere Tasks fra annen operasjon som feilmeldinger. 

Det er også mye lettere og skalere async/await med bruk av lister og arrays.

Når jeg skrev om Del_A til og bruke async/await at Thread.Sleep() fortsatt var i metoden til dronene.
Det førte til at metoden ble blokkert. Metodene kjørte da sekvensiellt istedenfor samtidig

Del C

Jeg bestemte meg for og bruke api.met.no for og få ekte værdata fra Norske byer. Jeg syntes egentlig at det var like enkelt
og gjøre api-kall asynkront. Jeg håndterte feilkoder og timeouts med en try catch og jeg brukte HttpRequestException og TaskCanceledException.
Hvis det skjer en feil med værdata Må programmet anta verste scenario.