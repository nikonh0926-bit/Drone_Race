using Spectre.Console;

var client = new HttpClient();

List<string> selections = 
[
"Del_A",
"Del_B",
"Del_C",
];

var runCommand = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
    .Title("run program >")
    .AddChoices(selections));

switch (runCommand)
{
    case "Del_A":
        StartDroneRaceA.StartDroneRace();
        break;
    case "Del_B":
        await StartDroneRaceB.StartDroneRace();
        break;
    case "Del_C":
        await StartDroneRaceC.StartDroneRace(client);
        break;
}