List<TaskItem> aufgaben = new List<TaskItem>();

TaskItem ersteAufgabe = new TaskItem(
    "Listen anlegen",
    "Eine List<TaskItem> erstellen"
);

TaskItem zweiteAufgabe = new TaskItem(
    "Elemente verändern",
    "Über einen Index auf ein Objekt zugreifen"
);

TaskItem dritteAufgabe = new TaskItem(
    "Elemente entfernen",
    "RemoveAt verwenden"
);

aufgaben.Add(ersteAufgabe);
aufgaben.Add(zweiteAufgabe);
aufgaben.Add(dritteAufgabe);

Console.WriteLine($"Anzahl vor den Änderungen: {aufgaben.Count}");
GibAufgabenAus(aufgaben);

aufgaben[1].IstErledigt = true;
aufgaben.RemoveAt(0);

Console.WriteLine($"Anzahl nach den Änderungen: {aufgaben.Count}");
GibAufgabenAus(aufgaben);

void GibAufgabenAus(List<TaskItem> aufgabenListe)
{
    foreach (TaskItem aufgabe in aufgabenListe)
    {
        Console.WriteLine($"Titel: {aufgabe.Titel}");
        Console.WriteLine($"Beschreibung: {aufgabe.Beschreibung}");
        Console.WriteLine($"Erledigt: {aufgabe.IstErledigt}");
        Console.WriteLine();
    }
}
