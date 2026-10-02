# 07 – Klassen und Objekte

## Lernziel

Du kannst mit einer Klasse einen eigenen Datentyp definieren, mehrere unabhängige Objekte erzeugen und ein Objekt an eine Methode übergeben.

## Klasse und Objekt

Eine Klasse ist ein Bauplan. Sie beschreibt, welche Daten alle Objekte dieses Typs besitzen. Ein Objekt ist ein konkretes Exemplar dieses Bauplans.

Beispiel: Die Klasse `Buch` legt fest, dass jedes Buch einen Titel und eine Seitenzahl besitzt. Zwei daraus erzeugte Buchobjekte können unterschiedliche Titel und Seitenzahlen speichern.

## Eine Klasse in einer eigenen Datei anlegen

Erstelle beispielsweise eine Datei `Buch.cs`:

```csharp
public class Buch
{
    public string Titel = "";
    public int Seiten;
    public bool IstGelesen;
}
```

- `public class Buch` definiert einen neuen Datentyp namens `Buch`.
- Die geschweiften Klammern enthalten alle Mitglieder der Klasse.
- `Titel`, `Seiten` und `IstGelesen` sind hier öffentliche Felder.
- `public` erlaubt dem Code außerhalb der Klasse, auf diese Felder zuzugreifen.
- `Titel` erhält mit `""` einen leeren Anfangstext.

Öffentliche Felder werden in der nächsten Lektion durch Properties ersetzt. Für diese Lektion helfen sie, Klasse und Objekt ohne zusätzliche Konzepte zu verstehen.

Alle `.cs`-Dateien innerhalb desselben Projekts werden gemeinsam kompiliert. Du musst `Buch.cs` deshalb nicht manuell in `Program.cs` laden.

## Ein Objekt mit `new` erzeugen

```csharp
Buch erstesBuch = new Buch();
```

| Teil | Bedeutung |
|---|---|
| erstes `Buch` | Datentyp der Variable |
| `erstesBuch` | Name der Variable |
| `new Buch()` | erzeugt ein neues Objekt im Arbeitsspeicher |

Die Variable `erstesBuch` verweist anschließend auf dieses Objekt.

## Felder mit dem Punktoperator verwenden

Über die Objektvariable, einen Punkt und den Feldnamen greifst du auf die Daten zu:

```csharp
erstesBuch.Titel = "C# verstehen";
erstesBuch.Seiten = 180;
erstesBuch.IstGelesen = false;

Console.WriteLine($"Titel: {erstesBuch.Titel}");
Console.WriteLine($"Seiten: {erstesBuch.Seiten}");
Console.WriteLine($"Gelesen: {erstesBuch.IstGelesen}");
```

`Buch.Titel` wäre hier falsch: `Buch` ist der Datentyp, aber `erstesBuch` ist das konkrete Objekt mit den gespeicherten Werten.

## Mehrere unabhängige Objekte

Jeder Aufruf von `new` erzeugt ein neues Objekt:

```csharp
Buch erstesBuch = new Buch();
erstesBuch.Titel = "C# verstehen";

Buch zweitesBuch = new Buch();
zweitesBuch.Titel = "Blazor kennenlernen";
```

Eine Änderung an `erstesBuch.Titel` verändert `zweitesBuch.Titel` nicht. Beide Objekte besitzen ihre eigenen Felder.

## Ein Feld nachträglich verändern

Ein vorhandenes Feld kann erneut zugewiesen werden:

```csharp
erstesBuch.IstGelesen = false;
Console.WriteLine(erstesBuch.IstGelesen);

erstesBuch.IstGelesen = true;
Console.WriteLine(erstesBuch.IstGelesen);
```

Dabei wird kein neues Objekt erzeugt. Nur der Wert eines Feldes des bestehenden Objekts ändert sich.

## Ein Objekt an eine Methode übergeben

Eine eigene Klasse kann genau wie `string` oder `int` als Parametertyp verwendet werden:

```csharp
void ZeigeBuch(Buch buch)
{
    Console.WriteLine($"Titel: {buch.Titel}");
    Console.WriteLine($"Seiten: {buch.Seiten}");
    Console.WriteLine($"Gelesen: {buch.IstGelesen}");
}

ZeigeBuch(erstesBuch);
ZeigeBuch(zweitesBuch);
```

- `Buch` ist der Datentyp des Parameters.
- `buch` ist der lokale Parametername innerhalb der Methode.
- Beim ersten Aufruf verweist `buch` auf `erstesBuch`, beim zweiten auf `zweitesBuch`.
- Dieselbe Methode funktioniert deshalb für jedes Objekt vom Typ `Buch`.

## Warum `Console.WriteLine(objekt)` nicht alle Felder zeigt

```csharp
Console.WriteLine(erstesBuch);
```

Ohne weitere Anpassung zeigt C# dabei normalerweise nur den Klassennamen an. C# weiß nicht automatisch, welche Felder du wie darstellen möchtest. Gib die einzelnen Felder aus oder verwende eine eigene Ausgabemethode.

## Klassen sind Referenztypen

Bei einer Klasse enthält die Variable eine Referenz auf das Objekt. Übergibst du das Objekt an eine Methode, verweist der Parameter auf dasselbe Objekt:

```csharp
void MarkiereAlsGelesen(Buch buch)
{
    buch.IstGelesen = true;
}

MarkiereAlsGelesen(erstesBuch);
Console.WriteLine(erstesBuch.IstGelesen); // True
```

Die Änderung bleibt sichtbar, weil die Methode kein kopiertes Buch, sondern eine Referenz auf dasselbe Buchobjekt erhalten hat.

## Namenskonventionen

- Klassen: PascalCase, zum Beispiel `TaskItem`.
- Öffentliche Felder: in dieser Übung ebenfalls PascalCase, zum Beispiel `Titel`.
- Lokale Variablen und Parameter: camelCase, zum Beispiel `ersteAufgabe` und `aufgabe`.

## Geführtes Vorgehen für die Aufgaben

1. Lege die Klassendatei im Projektordner an.
2. Definiere darin die Klasse und ihre öffentlichen Felder.
3. Erzeuge in `Program.cs` das erste Objekt mit `new`.
4. Weise jedem Feld über den Punktoperator einen Wert zu.
5. Wiederhole das mit einem zweiten `new` für ein unabhängiges Objekt.
6. Gib die Felder beider Objekte aus.
7. Ändere ein Feld eines vorhandenen Objekts und gib es erneut aus.
8. Schreibe eine Methode mit der Klasse als Parametertyp und rufe sie für beide Objekte auf.

## Häufige Fehler

- Die Datei wurde außerhalb des Projektordners erstellt.
- Hinter `class` oder `new` steht ein anderer Klassenname.
- `new TaskItem()` fehlt und es existiert deshalb kein Objekt.
- Auf ein Feld wird über den Klassennamen statt über die Objektvariable zugegriffen.
- Für das zweite Objekt wird kein zweites `new` verwendet.
- Die Ausgabemethode erhält einen `string`, obwohl sie ein vollständiges Objekt benötigt.
- `Console.WriteLine(objekt)` wird verwendet und nur der Klassenname erscheint.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "07_Klassen-und-Objekte/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "07_Klassen-und-Objekte/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "07_Klassen-und-Objekte/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
