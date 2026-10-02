List<TaskItem> aufgaben = new List<TaskItem>();

string titel = TitelEinlesen();
string? beschreibung = BeschreibungEinlesen();
AufgabenStatus status = StatusEinlesen();

TaskItem neueAufgabe = new TaskItem(titel, beschreibung);
neueAufgabe.Status = status;

aufgaben.Add(neueAufgabe);

Console.WriteLine();
Console.WriteLine("Gespeicherte Aufgaben:");

foreach (TaskItem aufgabe in aufgaben)
{
    Console.WriteLine($"Titel: {aufgabe.Titel}");
    Console.WriteLine(
        $"Beschreibung: {aufgabe.Beschreibung ?? "Keine Beschreibung"}"
    );
    Console.WriteLine($"Status: {aufgabe.Status}");
    Console.WriteLine();
}

string TitelEinlesen()
{
    string? eingabe;

    do
    {
        Console.Write("Titel: ");
        eingabe = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(eingabe))
        {
            Console.WriteLine("Der Titel darf nicht leer sein.");
        }
    }
    while (string.IsNullOrWhiteSpace(eingabe));

    return eingabe;
}

string? BeschreibungEinlesen()
{
    Console.Write("Beschreibung (optional): ");
    string? eingabe = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(eingabe))
    {
        return null;
    }

    return eingabe;
}

AufgabenStatus StatusEinlesen()
{
    int auswahl;
    bool gueltig;

    do
    {
        Console.WriteLine("Status auswählen:");
        Console.WriteLine("1 - Offen");
        Console.WriteLine("2 - In Arbeit");
        Console.WriteLine("3 - Erledigt");
        Console.Write("Auswahl: ");

        string? eingabe = Console.ReadLine();

        gueltig =
            int.TryParse(eingabe, out auswahl)
            && auswahl >= 1
            && auswahl <= 3;

        if (!gueltig)
        {
            Console.WriteLine(
                "Bitte eine Zahl von 1 bis 3 eingeben."
            );
        }
    }
    while (!gueltig);

    switch (auswahl)
    {
        case 1:
            return AufgabenStatus.Offen;
        case 2:
            return AufgabenStatus.InArbeit;
        default:
            return AufgabenStatus.Erledigt;
    }
}
