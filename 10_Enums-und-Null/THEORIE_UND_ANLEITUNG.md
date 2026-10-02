# 10 – Enums und `null`

## Lernziel

Du kannst eine feste Menge erlaubter Statuswerte als Enum definieren und optionale Textwerte sicher behandeln.

## Warum ein Enum statt freiem Text?

Ein Status als `string` erlaubt beliebige Schreibweisen:

```csharp
string status1 = "In Arbeit";
string status2 = "in arbeit";
string status3 = "InArbiet";
```

Diese drei Texte sollen möglicherweise dasselbe bedeuten, sind für C# aber verschieden. Ein Enum beschränkt den Wert auf vorher festgelegte Möglichkeiten und verhindert Tippfehler bei der Zuweisung.

## Ein Enum definieren

Lege beispielsweise eine Datei `MedienStatus.cs` an:

```csharp
public enum MedienStatus
{
    Ungelesen,
    Begonnen,
    Beendet
}
```

- `enum` definiert einen eigenen Typ mit einer festen Wertemenge.
- `MedienStatus` ist der Name des neuen Typs.
- Die erlaubten Werte stehen durch Kommas getrennt im Block.
- Enum-Typen und ihre Werte werden üblicherweise in PascalCase geschrieben.

Wie bei Klassen werden `.cs`-Dateien im Projekt automatisch gemeinsam kompiliert.

## Eine Enum-Variable verwenden

```csharp
MedienStatus status = MedienStatus.Ungelesen;
status = MedienStatus.Begonnen;
```

Links steht der Enum-Typ. Rechts wird ein konkreter Wert über `EnumName.Wert` ausgewählt.

Ein Wert eines anderen Enums oder ein beliebiger Statustext kann nicht versehentlich zugewiesen werden. Das macht den Code sicherer.

## Enum als Property einer Klasse

```csharp
public class Buch
{
    public string Titel { get; set; }
    public MedienStatus Status { get; set; }

    public Buch(string titel)
    {
        Titel = titel;
        Status = MedienStatus.Ungelesen;
    }
}
```

Der Konstruktor setzt einen sinnvollen Anfangsstatus. Später kann die Property auf einen anderen erlaubten Wert gesetzt werden:

```csharp
Buch buch = new Buch("C# lernen");
buch.Status = MedienStatus.Begonnen;
```

## Enum vergleichen

```csharp
if (buch.Status == MedienStatus.Beendet)
{
    Console.WriteLine("Das Buch ist abgeschlossen.");
}
```

Beim Vergleich verwendest du ebenfalls den Enum-Typ und einen seiner Werte. Es werden keine frei geschriebenen Statustexte verglichen.

## Enum ausgeben

```csharp
Console.WriteLine(buch.Status);
Console.WriteLine($"{buch.Titel}: {buch.Status}");
```

Bei der Textausgabe verwendet C# den Namen des Enum-Wertes. `MedienStatus.Begonnen` erscheint deshalb als `Begonnen`.

Intern basieren Enum-Werte standardmäßig auf ganzen Zahlen ab `0`. Trotzdem ist ein Enum weder ein `string` noch einfach ein gewöhnlicher `int`: Es ist ein eigener Datentyp mit festgelegten Werten.

Die explizite Textumwandlung ist ebenfalls möglich:

```csharp
string statusText = buch.Status.ToString();
```

## `nameof` verstehen

`nameof` liefert den Namen eines Codeelements als `string`:

```csharp
string nameAlsText = nameof(MedienStatus.Ungelesen);
Console.WriteLine(nameAlsText); // Ungelesen
```

Der Unterschied:

- `MedienStatus.Ungelesen` ist ein Wert vom Typ `MedienStatus`.
- `nameof(MedienStatus.Ungelesen)` ist der Text `"Ungelesen"` vom Typ `string`.

Bei einer Ausgabe sehen beide ähnlich aus, besitzen aber unterschiedliche Typen und Zwecke. Mit dem Enum-Wert kannst du typsicher Status vergleichen und zuweisen. `nameof` benötigst du nur, wenn der Name ausdrücklich als Text gebraucht wird.

## Was bedeutet `null`?

`null` bedeutet, dass kein Wert vorhanden ist. Das ist etwas anderes als ein leerer Text:

| Wert | Bedeutung |
|---|---|
| `null` | kein Textwert vorhanden |
| `""` | ein vorhandener Text mit Länge null |
| `"   "` | ein vorhandener Text, der nur Leerzeichen enthält |

Ein erforderlicher Titel sollte als normaler `string` definiert werden. Eine optionale Beschreibung darf dagegen `null` sein.

## Nullable Referenztypen mit `?`

```csharp
string titel = "C# lernen";
string? beschreibung = null;
```

Das Fragezeichen bei `string?` sagt ausdrücklich: Diese Variable darf entweder einen Text oder `null` enthalten.

Bei aktiviertem Nullable-System warnt der Compiler, wenn du einer normalen `string`-Variable möglicherweise `null` zuweist. Dadurch werden Fehler durch fehlende Werte früher sichtbar.

## Optionale Beschreibung in Property und Konstruktor

Ist eine Beschreibung optional, müssen sowohl die Property als auch der Konstruktorparameter `string?` verwenden:

```csharp
public class Buch
{
    public string Titel { get; set; }
    public string? Beschreibung { get; set; }
    public MedienStatus Status { get; set; }

    public Buch(string titel, string? beschreibung)
    {
        Titel = titel;
        Beschreibung = beschreibung;
        Status = MedienStatus.Ungelesen;
    }
}
```

Nun sind beide Aufrufe gültig:

```csharp
Buch mitBeschreibung = new Buch(
    "C# lernen",
    "Enums und null üben"
);

Buch ohneBeschreibung = new Buch(
    "Blazor vorbereiten",
    null
);
```

## Fehlenden Text mit `??` ersetzen

Der Null-Koaleszenzoperator `??` wählt einen Ersatzwert, falls links `null` steht:

```csharp
string beschreibungsText =
    buch.Beschreibung ?? "Keine Beschreibung";

Console.WriteLine(beschreibungsText);
```

Ablauf:

- Ist `buch.Beschreibung` ein Text, wird dieser verwendet.
- Ist sie `null`, wird `"Keine Beschreibung"` verwendet.
- Die ursprüngliche Property wird dabei nicht verändert.

Du kannst den Ausdruck auch direkt in einer interpolierten Ausgabe verwenden:

```csharp
Console.WriteLine(
    $"Beschreibung: {buch.Beschreibung ?? "Keine Beschreibung"}"
);
```

## Warum der Ersatztext nicht gespeichert werden sollte

`null` beschreibt den tatsächlichen Datenzustand: Es wurde keine Beschreibung angegeben. `"Keine Beschreibung"` ist nur eine benutzerfreundliche Darstellung dieses Zustands.

Würdest du den Anzeigetext dauerhaft als Beschreibung speichern, könnte der Code später nicht mehr unterscheiden, ob der Benutzer wirklich diesen Text eingegeben hat oder ob die Beschreibung fehlt.

## Mehrere Enum-Werte verwenden

Mehrere Objekte können verschiedene Werte desselben Enums besitzen:

```csharp
erstesBuch.Status = MedienStatus.Ungelesen;
zweitesBuch.Status = MedienStatus.Begonnen;
drittesBuch.Status = MedienStatus.Beendet;
```

Beim Durchlaufen einer Liste kannst du Titel, optionale Beschreibung und Status gemeinsam ausgeben:

```csharp
foreach (Buch einzelnesBuch in buecher)
{
    string text = einzelnesBuch.Beschreibung ?? "Keine Beschreibung";

    Console.WriteLine($"Titel: {einzelnesBuch.Titel}");
    Console.WriteLine($"Beschreibung: {text}");
    Console.WriteLine($"Status: {einzelnesBuch.Status}");
}
```

## Geführtes Vorgehen für die Aufgaben

1. Lege das Enum in einer eigenen Datei an.
2. Ersetze die bisherige Status-Property durch eine Property des Enum-Typs.
3. Ändere eine optionale Text-Property zu `string?`.
4. Ändere auch den dazugehörigen Konstruktorparameter zu `string?`.
5. Weise im Konstruktor einen sinnvollen Enum-Anfangswert zu.
6. Erzeuge mehrere Objekte; übergib bei einem davon `null`.
7. Weise den Objekten die verschiedenen Enum-Werte zu.
8. Durchlaufe die Liste mit `foreach`.
9. Erzeuge für die Ausgabe mit `??` einen Ersatztext, ohne die Property zu verändern.

## Häufige Fehler

- Der Status bleibt ein `string`, obwohl ein Enum angelegt wurde.
- Es wird nur der Wertname statt `EnumName.Wert` geschrieben.
- Property und Konstruktorparameter stimmen bei `string?` nicht überein.
- `"null"` wird in Anführungszeichen geschrieben; das wäre normaler Text statt des fehlenden Werts `null`.
- Der Anzeigetext wird dauerhaft in der Property gespeichert.
- Ein Enum-Wert wird mit einem `string` verglichen.
- `nameof(...)` wird für einen Enum-Wert gehalten, obwohl es einen `string` liefert.

