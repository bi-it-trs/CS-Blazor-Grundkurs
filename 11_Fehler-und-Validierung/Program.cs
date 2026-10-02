List<TaskItem> aufgaben = new List<TaskItem>();

TaskItem ersteAufgabe = new TaskItem(
    "Enums wiederholen",
    "Feste Statuswerte verwenden"
);
ersteAufgabe.Status = AufgabenStatus.Offen;

TaskItem zweiteAufgabe = new TaskItem(
    "Nullable verstehen",
    null
);
zweiteAufgabe.Status = AufgabenStatus.InArbeit;

TaskItem dritteAufgabe = new TaskItem(
    "Ausgabe prüfen",
    "Fehlende Beschreibungen ersetzen"
);
dritteAufgabe.Status = AufgabenStatus.Erledigt;

aufgaben.Add(ersteAufgabe);
aufgaben.Add(zweiteAufgabe);
aufgaben.Add(dritteAufgabe);

foreach (TaskItem aufgabe in aufgaben)
{
    string beschreibung =
        aufgabe.Beschreibung ?? "Keine Beschreibung";

    Console.WriteLine($"Titel: {aufgabe.Titel}");
    Console.WriteLine($"Beschreibung: {beschreibung}");
    Console.WriteLine($"Status: {aufgabe.Status}");
    Console.WriteLine();
}
