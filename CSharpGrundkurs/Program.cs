List<TaskItem> aufgaben = new List<TaskItem>();

TaskItem aufgabe1 = new TaskItem("Listen lernen",
"Mehrere Aufgaben speichern",
AufgabenStatus.Offen);
TaskItem aufgabe2 = new TaskItem("Blazor vorbereiten",
null,
AufgabenStatus.Erledigt
);

aufgaben.Add(
   new TaskItem("verstehen wieso cw(aufgaben[1]) TaskItem ausgibt und nicht die aufgabe 2",
   "ah ich muss es mit ausgabe ausgeben lassen",
   AufgabenStatus.InArbeit
   ));

aufgaben.Add(aufgabe1);
aufgaben.Add(aufgabe2);
aufgaben.Add(
   new TaskItem(
      "Listen Filtern und Sortieren", 
      "Ich glaub ich habs gecheckt. nur Merken muss ich es mir. aber ich denke ich erkenne es nun im code", 
      AufgabenStatus.InArbeit
      ));
// void Ausgabe()

// {
//    foreach (TaskItem aufgabe in aufgaben)
//    {  string beschreibung =
//          string.IsNullOrWhiteSpace(aufgabe.Beschreibung) ? "Keine Beschreibung" : aufgabe.Beschreibung;
//       System.Console.WriteLine($"Aufgabe: {aufgabe.Titel}");
//       System.Console.WriteLine($"Beschreibung: {beschreibung}");
//       System.Console.WriteLine($"Status: {aufgabe.Status}");
//       System.Console.WriteLine("--------------------------");
//    }
// }

// aufgaben[1].Status = AufgabenStatus.Offen;
// aufgaben[2].Status = AufgabenStatus.Offen;

// Ausgabe();

// string Titel()
// {
//    while (true)
//    {
//       System.Console.WriteLine("Gib einen Titel ein");
//       string? titel = Console.ReadLine();

//       if (!string.IsNullOrWhiteSpace(titel))
//       {
//          return titel;
//       }
//       System.Console.WriteLine("Der Titel darf nicht leer sein");
//    }
// }

// string? Beschreibung()
// {
//    System.Console.WriteLine("Gib eine optionale Beschreibung ein");
//    string? beschreibung = System.Console.ReadLine();
//    // if (string.IsNullOrWhiteSpace(beschreibung))
//    // {
//    //    beschreibung = " Keine Beschreibung";
//    // }

//    return beschreibung;
// }

// AufgabenStatus Status()
// {
//    string? eingabe;
//    bool erfolgreich;
//    int auswahl;

//    do
//    {
//       System.Console.WriteLine("Wähle einen Status: 1: Offen | 2: InArbeit | 3: Erledigt");
//       eingabe = System.Console.ReadLine();
//       erfolgreich = int.TryParse(eingabe, out auswahl)
//       && auswahl >= 1
//       && auswahl <= 3;
      
//       if (!erfolgreich) // isnullorwhitespace unnötig oder?
//       {
//          System.Console.WriteLine("Bitte eine gültige Zahl eingeben!");
//       }
//    }
//    while (!erfolgreich);

//    return (AufgabenStatus)(auswahl - 1);
// }

// aufgaben.Add(new TaskItem(Titel(), Beschreibung(), Status()));

// Ausgabe();

List<TaskItem> offeneAufgaben = aufgaben
   .Where(aufgabe => aufgabe.Status == AufgabenStatus.Offen || aufgabe.Status == AufgabenStatus.InArbeit)
   .OrderBy(aufgabe => aufgabe.Titel)
   .ToList();

List<TaskItem> sortierteAufgaben = aufgaben.OrderBy(aufgabe => aufgabe.Titel).ToList();

void AusgabeOffen()
{
   System.Console.WriteLine("Offene Aufgaben");
   foreach(TaskItem aufgabe in offeneAufgaben)
   {
      System.Console.WriteLine($"Aufgabe: {aufgabe.Titel}");
      System.Console.WriteLine($"Beschreibung {aufgabe.Beschreibung}");
      System.Console.WriteLine($"Status: {aufgabe.Status}");
      System.Console.WriteLine("--------------------");
   }
}
// List<TaskItem> offeneAufgaben = aufgaben.OrderBy(aufgabe=> aufgabe.Titel).ToList;

void AusgabeSortiert()
{
   System.Console.WriteLine("Sortierte Aufgaben");
   foreach(TaskItem aufgabe in sortierteAufgaben)
   {
      System.Console.WriteLine($"Aufgabe: {aufgabe.Titel}");
      System.Console.WriteLine($"Beschreibung {aufgabe.Beschreibung}");
      System.Console.WriteLine($"Status: {aufgabe.Status}");
      System.Console.WriteLine("------------------");
   }
}
// System.Console.WriteLine($"Aufgaben: {aufgaben.Count}");
// System.Console.WriteLine($"Offene Aufgaben: {offeneAufgaben.Count}");
AusgabeOffen();
AusgabeSortiert();

int gesamt = aufgaben.Count;
int offen = aufgaben.Count(aufgabe => aufgabe.Status == AufgabenStatus.Offen);
int inArbeit = aufgaben.Count(aufgabe => aufgabe.Status == AufgabenStatus.InArbeit);
int erledigt = aufgaben.Count(aufgabe => aufgabe.Status == AufgabenStatus.Erledigt);


System.Console.WriteLine($"Gesamte Aufgaben: {gesamt}");
System.Console.WriteLine($"Offene Aufgaben: {offen}");
System.Console.WriteLine($"Aufgaben in Arbeit: {inArbeit}");
System.Console.WriteLine($"Erledigte Aufgaben: {erledigt}");

