# 09 – Collections mit `List<T>`

## Lernziel

Du kannst mehrere Objekte in einer veränderbaren Liste speichern, zählen, durchlaufen, über einen Index verändern und sicher entfernen.

## Warum eine `List<T>`?

Einzelne Variablen werden bei mehreren Aufgaben schnell unübersichtlich:

```csharp
TaskItem aufgabe1 = new TaskItem("C# lesen", "Kapitel wiederholen");
TaskItem aufgabe2 = new TaskItem("Code schreiben", "Übungen lösen");
```

Eine `List<T>` fasst beliebig viele Elemente desselben Typs in einer Sammlung zusammen. Anders als ein Array kann eine Liste nachträglich wachsen und schrumpfen.

## Liste anlegen

```csharp
List<TaskItem> aufgaben = new List<TaskItem>();
```

| Teil | Bedeutung |
|---|---|
| `List<TaskItem>` | Datentyp: eine Liste aus `TaskItem`-Objekten |
| `aufgaben` | Name der Listenvariable |
| `new List<TaskItem>()` | erzeugt eine neue, zunächst leere Liste |

Das `T` in `List<T>` ist ein Platzhalter für den Elementtyp. Bei `List<TaskItem>` wird dieser Platzhalter durch `TaskItem` ersetzt. Die Liste kann daher keine beliebigen anderen Typen aufnehmen.

In modernen Konsolenprojekten ist `List<T>` durch die standardmäßigen impliziten `using`-Anweisungen direkt verfügbar.

## Elemente mit `Add` hinzufügen

```csharp
TaskItem ersteAufgabe = new TaskItem("C# lesen", "Kapitel wiederholen");
TaskItem zweiteAufgabe = new TaskItem("Code schreiben", "Übungen lösen");

aufgaben.Add(ersteAufgabe);
aufgaben.Add(zweiteAufgabe);
aufgaben.Add(new TaskItem("Notizen ordnen", "Wichtige Regeln sammeln"));
```

`Add` hängt ein Element am Ende der Liste an. Die Listenreihenfolge hängt von der Reihenfolge der `Add`-Aufrufe ab, nicht davon, wann die Objektvariablen angelegt wurden.

## Anzahl mit `Count`

```csharp
int anzahl = aufgaben.Count;
Console.WriteLine($"Anzahl: {anzahl}");
```

`Count` ist die aktuelle Anzahl der Listenelemente. Nach `Add` wird sie größer, nach erfolgreichem Entfernen kleiner.

## Zugriff über den Index

Listenelemente besitzen fortlaufende Positionen, die bei `0` beginnen:

| Index | Bedeutung |
|---|---|
| `0` | erstes Element |
| `1` | zweites Element |
| `2` | drittes Element |

```csharp
TaskItem ersteAufgabe = aufgaben[0];
Console.WriteLine(aufgaben[1].Titel);
```

Bei drei Elementen sind nur die Indizes `0`, `1` und `2` gültig. `aufgaben[3]` würde einen Laufzeitfehler verursachen.

## Ein Objekt über seinen Index verändern

Da `TaskItem` eine Klasse ist, kannst du direkt auf eine Property des Listenelements zugreifen:

```csharp
aufgaben[1].IstErledigt = true;
```

`[1]` wählt das zweite Objekt aus. Der Punkt greift anschließend auf dessen Property zu. Das Objekt bleibt in der Liste; nur sein Status ändert sich.

## Liste mit `foreach` durchlaufen

```csharp
foreach (TaskItem aufgabe in aufgaben)
{
    Console.WriteLine($"Titel: {aufgabe.Titel}");
    Console.WriteLine($"Erledigt: {aufgabe.IstErledigt}");
}
```

`aufgaben` ist die vollständige Liste. `aufgabe` ist während jedes Durchlaufs jeweils ein einzelnes `TaskItem` daraus. Die Schleifenvariable wird im `foreach`-Kopf deklariert und existiert nur im Schleifenblock.

## Vor einem Indexzugriff prüfen

Vor dem Zugriff auf das zweite Element muss die Liste mindestens zwei Elemente enthalten:

```csharp
if (aufgaben.Count > 1)
{
    aufgaben[1].IstErledigt = true;
}
```

Warum `> 1`? Das zweite Element hat den Index `1`. Es existiert erst ab einer Anzahl von zwei Elementen.

Allgemein ist ein Index `index` gültig, wenn er mindestens `0` und kleiner als `Count` ist:

```csharp
if (index >= 0 && index < aufgaben.Count)
{
    Console.WriteLine(aufgaben[index].Titel);
}
```

## Mit `RemoveAt` über den Index entfernen

```csharp
aufgaben.RemoveAt(0);
```

Damit wird das erste Element entfernt. Alle folgenden Elemente rücken eine Position nach vorne. Die Liste besitzt danach keine leere Lücke.

Auch vor `RemoveAt(0)` sollte bei möglicherweise leeren Listen geprüft werden:

```csharp
if (aufgaben.Count > 0)
{
    aufgaben.RemoveAt(0);
}
```

## Mit `Remove` ein bestimmtes Objekt entfernen

```csharp
bool wurdeEntfernt = aufgaben.Remove(zweiteAufgabe);
```

`Remove` sucht nach dem angegebenen Objekt und entfernt das erste passende Element. Die Methode gibt `true` zurück, wenn etwas entfernt wurde, sonst `false`.

Bei Klassen ist es für diese Übung am zuverlässigsten, genau dieselbe Objektvariable zu übergeben, die zuvor mit `Add` eingefügt wurde.

## Eine komplette Liste an eine Methode übergeben

Der Parametertyp enthält ebenfalls den Elementtyp:

```csharp
void ZeigeAufgaben(List<TaskItem> aufgabenListe)
{
    foreach (TaskItem aufgabe in aufgabenListe)
    {
        Console.WriteLine($"{aufgabe.Titel}: {aufgabe.IstErledigt}");
    }
}

ZeigeAufgaben(aufgaben);
```

Die Methode erhält die Liste und kann alle enthaltenen Objekte mit `foreach` ausgeben. Der Parametername `aufgabenListe` ist frei wählbar und nur innerhalb der Methode gültig.

## Warum die direkte Objektausgabe wenig zeigt

```csharp
Console.WriteLine(aufgaben[0]);
```

Ohne eine eigene Textdarstellung erscheint dabei normalerweise nur der Klassenname. Greife auf die Properties zu oder rufe eine Ausgabemethode auf.

## Geführtes Vorgehen für die Aufgaben

1. Erzeuge zuerst mehrere unabhängige `TaskItem`-Objekte.
2. Lege eine leere `List<TaskItem>` an.
3. Füge die Objekte in der gewünschten Reihenfolge mit `Add` ein.
4. Gib `Count` aus.
5. Durchlaufe die Liste mit `foreach` und gib die Properties jedes Elements aus.
6. Prüfe bei Bedarf `Count` und ändere das zweite Objekt über Index `1`.
7. Prüfe, dass die Liste nicht leer ist, und entferne Index `0`.
8. Gib die neue Anzahl und die verbleibenden Elemente aus.

## Häufige Fehler

- Es wird `List<TaskItem>` geschrieben, aber ein Wert eines anderen Typs hinzugefügt.
- Das zweite Element wird fälschlich mit Index `2` statt `1` angesprochen.
- Ein Index wird verwendet, obwohl die Liste nicht genügend Elemente besitzt.
- Innerhalb von `foreach` wird die gesamte Liste statt des einzelnen Elements ausgegeben.
- `RemoveAt` erhält ein Objekt, obwohl die Methode einen Index erwartet.
- `Remove` erhält einen Index, obwohl die Methode ein Objekt erwartet.
- Nach `RemoveAt(0)` werden die alten Indexpositionen weiter angenommen.
- `Console.WriteLine(aufgabe)` wird verwendet und zeigt nur den Klassennamen.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "09_Collections/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "09_Collections/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "09_Collections/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
