TaskItem ersteAufgabe = new TaskItem();
ersteAufgabe.Titel = "Klassen wiederholen";
ersteAufgabe.Beschreibung = "Eigene Datentypen verstehen";
ersteAufgabe.IstErledigt = false;

TaskItem zweiteAufgabe = new TaskItem();
zweiteAufgabe.Titel = "Objekte erzeugen";
zweiteAufgabe.Beschreibung = "Zwei unabhängige Objekte anlegen";
zweiteAufgabe.IstErledigt = false;

ZeigeAufgabe(ersteAufgabe);
ZeigeAufgabe(zweiteAufgabe);

ersteAufgabe.IstErledigt = true;

Console.WriteLine("Nach der Änderung:");
ZeigeAufgabe(ersteAufgabe);

void ZeigeAufgabe(TaskItem aufgabe)
{
    Console.WriteLine($"Titel: {aufgabe.Titel}");
    Console.WriteLine($"Beschreibung: {aufgabe.Beschreibung}");
    Console.WriteLine($"Erledigt: {aufgabe.IstErledigt}");
    Console.WriteLine();
}
