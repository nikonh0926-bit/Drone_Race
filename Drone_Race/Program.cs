using Spectre.Console;

var client = new HttpClient();

List<string> selections = 
[
"Del_A",
"Del_B",
"del_C",
];

var runCommand = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
    .Title("run program >")
    .AddChoices(selections));
Task task;

switch (runCommand)
{
    case "Del_A":
        StartDroneRaceA.StartDroneRace();
        break;
    case "Del_B":
        task = StartDroneRaceB.StartDroneRace();
        await Task.WhenAny(task);
        break;
    case "Del_C":
        task = StartDroneRaceC.StartDroneRace(client);
        await Task.WhenAny(task);
        break;
}