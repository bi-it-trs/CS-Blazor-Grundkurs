TaskItem ersteAufgabe = new TaskItem(
    "Properties wiederholen",
    "Öffentliche Felder durch Properties ersetzen"
);

TaskItem zweiteAufgabe = new TaskItem(
    "Konstruktor verwenden",
    "Objekte direkt mit gültigen Werten erzeugen"
);

ZeigeAufgabe(ersteAufgabe);
ZeigeAufgabe(zweiteAufgabe);

zweiteAufgabe.IstErledigt = true;

Console.WriteLine("Nach der Änderung:");
ZeigeAufgabe(zweiteAufgabe);

void ZeigeAufgabe(TaskItem aufgabe)
{
    Console.WriteLine($"Titel: {aufgabe.Titel}");
    Console.WriteLine($"Beschreibung: {aufgabe.Beschreibung}");
    Console.WriteLine($"Erledigt: {aufgabe.IstErledigt}");
    Console.WriteLine();
}
