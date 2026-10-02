# 02 – Variablen und Datentypen

## Lernziel

Du kannst Texte, ganze Zahlen, Dezimalzahlen und Wahrheitswerte speichern, verändern und mit Beschriftung ausgeben.

## Was ist eine Variable?

Eine Variable ist ein benannter Speicherplatz. Eine vollständige Deklaration besteht aus Datentyp, Name, Zuweisungsoperator, Wert und Semikolon:

```csharp
string vorname = "Mira";
```

| Teil | Bedeutung |
|---|---|
| `string` | Datentyp der Variable |
| `vorname` | selbst gewählter Variablenname |
| `=` | weist der Variable einen Wert zu |
| `"Mira"` | gespeicherter Wert |
| `;` | beendet die Anweisung |

Das erstmalige Anlegen einer Variable heißt **Deklaration**. Wird dabei sofort ein Wert gespeichert, findet gleichzeitig eine **Zuweisung** statt.

## Vier wichtige Grundtypen

```csharp
string thema = "C#";
int anzahlLektionen = 5;
double lernstunden = 3.5;
bool machtSpass = true;
```

| Typ | Inhalt | Beispiele |
|---|---|---|
| `string` | Text | `"C#"`, `"Blazor"` |
| `int` | ganze Zahl | `4`, `-10`, `100` |
| `double` | Zahl mit Nachkommastellen | `2.5`, `19.99` |
| `bool` | Wahrheitswert | `true`, `false` |

Wichtige Schreibregeln:

- Ein `string` steht in doppelten Anführungszeichen.
- Ein `int` wird ohne Anführungszeichen und ohne Nachkommastellen geschrieben.
- Im C#-Code verwendet ein `double` einen Punkt als Dezimaltrennzeichen: `5.5`.
- Ein `bool` enthält nur `true` oder `false`, kleingeschrieben und ohne Anführungszeichen.
- `"Ja"` ist Text und deshalb ein `string`, kein `bool`.

## Variablen sinnvoll benennen

Variablennamen werden in C# üblicherweise in **camelCase** geschrieben. Das erste Wort beginnt klein, jedes weitere Wort groß:

```csharp
double lernstundenProWoche = 4.5;
bool moechteBlazorLernen = true;
```

Ein Name darf keine Leerzeichen enthalten und sollte beschreiben, welcher Wert gespeichert wird.

## Werte mit String-Interpolation ausgeben

Mit String-Interpolation verbindest du festen Text und Variablenwerte:

```csharp
string sprache = "C#";
int lektion = 2;

Console.WriteLine($"Sprache: {sprache}");
Console.WriteLine($"Aktuelle Lektion: {lektion}");
Console.WriteLine($"Ich lerne {sprache} in Lektion {lektion}.");
```

Das `$` vor dem Text aktiviert die Interpolation. Alles in `{ }` wird ausgewertet und durch den aktuellen Wert ersetzt. Ohne `$` würden die geschweiften Klammern als normaler Text behandelt.

Die Ausgabe eines `bool` erscheint standardmäßig als `True` oder `False`.

## Einen vorhandenen Wert verändern

Nach der ersten Deklaration wird nur noch ein neuer Wert zugewiesen. Der Datentyp wird nicht erneut geschrieben:

```csharp
double lernzeit = 2.5;              // Deklaration und erste Zuweisung
Console.WriteLine($"Vorher: {lernzeit}");

lernzeit = 4.0;                     // neue Zuweisung
Console.WriteLine($"Nachher: {lernzeit}");
```

Würdest du im selben Block erneut `double lernzeit = 4.0;` schreiben, versuchtest du eine zweite Variable mit demselben Namen anzulegen. Das führt zu einem Fehler.

Der neue Wert muss zum Datentyp passen:

```csharp
int tage = 3;
tage = 5;          // gültig
// tage = "fünf"; // ungültig: Text passt nicht in int
```

## Gültigkeitsbereich

Eine Variable kann erst nach ihrer Deklaration verwendet werden. Außerdem ist sie nur in dem Block verfügbar, in dem sie deklariert wurde. Blöcke werden meistens durch `{ }` begrenzt. Das wird bei Bedingungen, Schleifen und Methoden wichtig.

## Geführtes Beispiel

Erstelle ein kleines Profil für ein beliebiges Hobby:

1. Speichere die Bezeichnung als `string`.
2. Speichere die Anzahl Einheiten als `int`.
3. Speichere die Dauer pro Woche als `double`.
4. Speichere als `bool`, ob du es regelmäßig betreibst.
5. Gib alle Werte mit beschrifteten interpolierten Texten aus.
6. Ändere danach die Dauer durch eine neue Zuweisung und gib sie erneut aus.

## Häufige Fehler

- Das `$` vor einem interpolierten Text fehlt.
- In `{ }` steht ein Variablenname, der nicht existiert oder anders geschrieben wurde.
- Für eine Dezimalzahl wird im Code ein Komma statt eines Punkts verwendet.
- `true`, `false` oder Zahlen werden unnötig in Anführungszeichen gesetzt und dadurch zu Text.
- Bei einer neuen Zuweisung wird der Datentyp wiederholt.
- Einer Variable wird ein Wert eines unpassenden Typs zugewiesen.

## Das brauchst du für die Aufgaben

Für das Lernprofil legst du jede Information mit passendem Typ an, gibst sie über `$"... {variable} ..."` aus und weist der vorhandenen Lernstunden-Variable später ohne erneutes `double` einen neuen Wert zu.

