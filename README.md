

Drone Race

Et C#-prosjekt som demonstrerer parallell kjøring med tråder og asynkrone oppgaver. Prosjektet er delt inn i tre deler, som bruker ulike metoder for å simulere dronekappløp.


Del A – Threads

Demonstrerer bruk av Thread for å kjøre flere droner parallelt. Hver drone gjennomfører en serie sjekkpunkter med forsinkelser underveis.

Prosjektet viser hvordan Join() kan brukes til å vente på at trådene fullfører kjøringen.


Del B – Async/Await

Bruker async, await, Task og Task.WhenAll for å kjøre flere droner samtidig uten å blokkere tråden mens de venter.

Delen demonstrerer også feilhåndtering når én eller flere droner ikke fullfører kjøringen som forventet.


Del C – Weather API

Utvider dronesimuleringen ved å hente værdata fra Meteorologisk institutts Locationforecast API.

Vindstyrke og nedbør brukes til å beregne en multiplikator for hver drones forsinkelse. Dersom værdata ikke kan hentes eller behandles, brukes en standardverdi for å simulere ugunstige forhold.

Denne delen demonstrerer bruk av HttpClient, asynkrone HTTP-forespørsler, JSON-parsing og feilhåndtering.


Teknologier

C#

.NET

Spectre.Console

Threads og Tasks

Async/Await

HttpClient og JSON

Meteorologisk institutts Locationforecast API (Del C)



Kjøring

Start programmet og velg Del_A, Del_B eller del_C fra menyen for å kjøre den ønskede delen.

Del C krever internettilgang for å hente værdata.