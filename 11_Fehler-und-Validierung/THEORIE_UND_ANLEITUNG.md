# 11 – Fehler und Validierung

## Lernziel

Du kannst erwartbare Fehleingaben erkennen, verständlich melden und erneut abfragen. Jede Eingabemethode liefert erst dann einen passenden Wert zurück, wenn ihre eigenen Regeln erfüllt sind.

## Was ist Validierung?

Validierung bedeutet, einen eingegebenen Wert vor der weiteren Verarbeitung zu prüfen:

- Ist ein Pflichttext vorhanden?
- Lässt sich eine Eingabe in eine Zahl umwandeln?
- Liegt die Zahl im erlaubten Bereich?
- Darf ein Wert fehlen?

Ungültige Benutzereingaben gehören zum normalen Programmablauf. Das Programm soll deshalb eine verständliche Meldung zeigen und erneut fragen, statt abzustürzen.

## Eingaben sind zunächst Text

```csharp
Console.Write("Eingabe: ");
string? eingabe = Console.ReadLine();
```

`Console.ReadLine()` liefert `string?`. Auch wenn der Benutzer eine Zahl tippt, erhält das Programm zunächst Text. Dieser Text muss anschließend geprüft und gegebenenfalls umgewandelt werden.

## Pflichttext prüfen

`string.IsNullOrWhiteSpace` erkennt alle für einen Pflichttitel ungültigen Fälle:

```csharp
bool istUngueltig = string.IsNullOrWhiteSpace(eingabe);
```

Das Ergebnis ist `true`, wenn die Eingabe:

- `null` ist,
- leer ist, oder
- ausschließlich aus Leerzeichen oder ähnlichen Leerraumzeichen besteht.

Eine vollständige Eingabemethode für einen beliebigen Pflichttext kann so aufgebaut sein:

```csharp
string LiesPflichtText()
{
    string? eingabe;

    do
    {
        Console.Write("Pflichttext: ");
        eingabe = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(eingabe))
        {
            Console.WriteLine("Die Eingabe darf nicht leer sein.");
        }
    }
    while (string.IsNullOrWhiteSpace(eingabe));

    return eingabe;
}
```

Nach der Schleife weiß der Compiler durch die Prüfung, dass ein verwendbarer Text vorhanden ist. Die Methode gibt ihn als `string` zurück.

## Optionale Eingabe genau einmal lesen

Eine optionale Beschreibung muss nicht wiederholt abgefragt werden. Leerer Text kann dabei in `null` umgewandelt werden:

```csharp
string? LiesOptionalenText()
{
    Console.Write("Optionaler Text: ");
    string? eingabe = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(eingabe))
    {
        return null;
    }

    return eingabe;
}
```

Damit bedeutet `null` im späteren Objekt eindeutig: Es wurde kein Inhalt angegeben. Diese Methode fragt genau einmal und besitzt deshalb keine Schleife.

## Warum `int.Parse` für Benutzereingaben riskant ist

```csharp
int zahl = int.Parse(eingabe);
```

`int.Parse` erwartet gültigen Zahlentext. Bei `""`, `"abc"` oder anderen ungültigen Eingaben wirft die Methode eine Exception. Das Programm würde ohne zusätzliche Behandlung abbrechen.

Für erwartbare Eingaben ist `int.TryParse` besser geeignet.

## Zahlen mit `TryParse` sicher einlesen

```csharp
bool konnteUmwandeln = int.TryParse(eingabe, out int zahl);
```

`TryParse` liefert zwei Informationen:

- Der Rückgabewert ist `true`, wenn die Umwandlung funktioniert hat.
- Die `out`-Variable `zahl` enthält danach das Zahlenergebnis.

Bei ungültigem Text liefert die Methode `false`, statt das Programm abstürzen zu lassen.

## Umwandlung und erlaubten Bereich gemeinsam prüfen

Eine gültige ganze Zahl kann trotzdem außerhalb des erlaubten Bereichs liegen:

```csharp
bool gueltig =
    int.TryParse(eingabe, out auswahl)
    && auswahl >= 1
    && auswahl <= 3;
```

Die Eingabe ist nur gültig, wenn alle drei Bedingungen stimmen:

1. Sie lässt sich in eine ganze Zahl umwandeln.
2. Die Zahl ist mindestens `1`.
3. Die Zahl ist höchstens `3`.

Das `&&` wertet von links nach rechts aus. Wenn `TryParse` bereits `false` liefert, müssen die weiteren Bedingungen nicht mehr über den Erfolg entscheiden.

## Wiederholen, bis eine gültige Zahl vorliegt

Variablen, die nach der Schleife oder in ihrer Bedingung benötigt werden, werden vor dem `do`-Block deklariert:

```csharp
int auswahl;
bool gueltig;

do
{
    Console.Write("Auswahl von 1 bis 3: ");
    string? eingabe = Console.ReadLine();

    gueltig =
        int.TryParse(eingabe, out auswahl)
        && auswahl >= 1
        && auswahl <= 3;

    if (!gueltig)
    {
        Console.WriteLine("Bitte eine Zahl von 1 bis 3 eingeben.");
    }
}
while (!gueltig);

Console.WriteLine($"Gültige Auswahl: {auswahl}");
```

`!gueltig` bedeutet „nicht gültig“. Die Schleife läuft also weiter, solange die Prüfung fehlschlägt.

`eingabe` wird nur innerhalb des Blocks gebraucht und darf dort deklariert werden. `auswahl` und `gueltig` werden außerhalb beziehungsweise in der Schleifenbedingung benötigt und stehen deshalb vor dem Block.

## Eine gültige Zahl in einen Enum-Wert übersetzen

Eine Menüzahl ist nicht automatisch ein Enum-Wert. Nach erfolgreicher Prüfung kannst du sie mit einem `switch` zuordnen:

```csharp
AufgabenStatus status;

switch (auswahl)
{
    case 1:
        status = AufgabenStatus.Offen;
        break;
    case 2:
        status = AufgabenStatus.InArbeit;
        break;
    default:
        status = AufgabenStatus.Erledigt;
        break;
}
```

Der `default`-Zweig steht hier für `3`, weil vorher bereits sichergestellt wurde, dass nur `1`, `2` oder `3` möglich sind.

Verlasse dich nicht blind auf die internen Enum-Zahlen. Die Menüwerte `1` bis `3` werden hier ausdrücklich den gewünschten Enum-Werten zugeordnet.

## Eine Eingabemethode mit Enum-Rückgabewert

Der Ablauf einer solchen Methode besteht aus zwei Teilen:

1. So lange lesen und prüfen, bis eine gültige Menüzahl vorliegt.
2. Die Zahl in einen Enum-Wert übersetzen und diesen zurückgeben.

Der Methodenkopf legt fest, was am Ende geliefert wird:

```csharp
AufgabenStatus LiesStatus()
{
    // Eingabe wiederholen und Zahl validieren
    // Zahl mit switch zuordnen
    // passenden AufgabenStatus zurückgeben
}
```

Innerhalb einer Methode mit Rückgabetyp `AufgabenStatus` muss `return` einen Wert dieses Enum-Typs liefern, keinen `string` und keine Menüzahl.

## Die Rückgabewerte weiterverwenden

Rufe jede Eingabemethode auf und speichere ihr Ergebnis im passenden Typ:

```csharp
string titel = LiesPflichtText();
string? beschreibung = LiesOptionalenText();
AufgabenStatus status = LiesStatus();
```

Diese Variablen können anschließend an den Konstruktor eines Objekts übergeben werden. Falls der Konstruktor den Status nicht als Parameter besitzt, erzeugst du zuerst das Objekt und weist danach seine Status-Property zu.

Das fertige Objekt wird mit `Add` zu einer `List<TaskItem>` hinzugefügt und anschließend wie in Lektion 9 mit `foreach` ausgegeben.

## Validierung und Exceptions

Falsche Benutzereingaben sind erwartbar und werden mit Prüfungen wie `IsNullOrWhiteSpace`, `TryParse` und Bereichsvergleichen behandelt.

Exceptions sind für Fehler gedacht, die nicht zum normalen Eingabeablauf gehören. Verwende sie nicht als Ersatz für einfache Validierung.

## Systematisch testen

Teste nicht nur den erfolgreichen Weg:

- Drücke beim Pflichttext direkt Enter.
- Gib nur Leerzeichen ein.
- Gib anschließend gültigen Text ein.
- Drücke bei der Zahlenauswahl Enter.
- Gib Buchstaben ein.
- Gib Zahlen unter und über dem erlaubten Bereich ein.
- Prüfe jeden gültigen Menüwert.

Nach jeder ungültigen Eingabe muss dieselbe Methode erneut fragen. Erst ein gültiger Wert darf zurückgegeben werden.

## Häufige Fehler

- Für eine erwartbare Zahleneingabe wird `int.Parse` statt `TryParse` verwendet.
- Es wird nur geprüft, ob die Umwandlung klappt, aber nicht der erlaubte Zahlenbereich.
- `gueltig` oder `auswahl` wird innerhalb des `do`-Blocks deklariert und ist in der Bedingung nicht sichtbar.
- In der Schleife wird die Eingabe nicht erneut gelesen.
- Die Schleifenbedingung ist umgedreht und wiederholt bei gültiger statt bei ungültiger Eingabe.
- Eine leere optionale Beschreibung wird unnötig erneut abgefragt.
- Die Menüzahl wird ohne klare Zuordnung als Enum behandelt.
- Eine Methode verspricht `AufgabenStatus`, gibt aber eine Zahl oder einen Text zurück.

