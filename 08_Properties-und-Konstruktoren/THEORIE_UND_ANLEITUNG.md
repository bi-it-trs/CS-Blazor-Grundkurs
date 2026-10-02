# 08 – Properties und Konstruktoren

## Lernziel

Du kannst öffentliche Felder durch Properties ersetzen und Objekte über einen Konstruktor mit gültigen Anfangswerten erzeugen.

## Von Feldern zu Properties

In der vorigen Lektion wurden öffentliche Felder verwendet:

```csharp
public string Titel = "";
```

In C# werden von außen zugängliche Daten normalerweise als Properties geschrieben:

```csharp
public string Titel { get; set; }
```

Diese kurze Form heißt automatisch implementierte Property.

- `get` erlaubt, den Wert zu lesen.
- `set` erlaubt, dem Wert etwas Neues zuzuweisen.
- `string` ist der Datentyp.
- `Titel` ist der Name der Property.

Die Verwendung sieht von außen ähnlich wie bei einem Feld aus:

```csharp
Console.WriteLine(aufgabe.Titel); // get liest den Wert
aufgabe.Titel = "Neuer Titel";   // set schreibt einen Wert
```

Properties können später um Validierung oder eingeschränkten Schreibzugriff erweitert werden, ohne dass der aufrufende Code vollständig umgebaut werden muss.

## Eine Klasse mit Properties

```csharp
public class Buch
{
    public string Titel { get; set; }
    public string Beschreibung { get; set; }
    public bool IstGelesen { get; set; }
}
```

Ohne Konstruktor müsste der aufrufende Code die Werte nach `new Buch()` einzeln setzen. Dabei könnte ein notwendiger Wert vergessen werden.

## Was ist ein Konstruktor?

Ein Konstruktor wird automatisch ausgeführt, wenn mit `new` ein Objekt erzeugt wird:

```csharp
public class Buch
{
    public string Titel { get; set; }
    public string Beschreibung { get; set; }
    public bool IstGelesen { get; set; }

    public Buch(string titel, string beschreibung)
    {
        Titel = titel;
        Beschreibung = beschreibung;
        IstGelesen = false;
    }
}
```

Ein Konstruktor:

- heißt genau wie die Klasse,
- besitzt keinen Rückgabetyp, auch nicht `void`,
- kann Parameter entgegennehmen,
- weist den Properties Anfangswerte zu,
- wird bei jedem `new Buch(...)` automatisch ausgeführt.

Er erzeugt nicht selbst das Objekt und gibt es nicht mit `return` zurück. Der Ausdruck `new Buch(...)` erzeugt das Objekt und ruft dabei den passenden Konstruktor auf.

## Properties und Parameter unterscheiden

Im Konstruktor stehen links die Properties des Objekts und rechts die übergebenen Parameter:

```csharp
Titel = titel;
Beschreibung = beschreibung;
```

- `Titel` mit großem Anfangsbuchstaben ist die Property.
- `titel` mit kleinem Anfangsbuchstaben ist der Konstruktorparameter.

Durch die unterschiedliche Groß- und Kleinschreibung kann C# beide Namen auseinanderhalten.

Wenn Parameter und Property denselben Namen hätten, könnte man mit `this` ausdrücklich auf die Property des aktuellen Objekts verweisen:

```csharp
public Buch(string Titel)
{
    this.Titel = Titel;
}
```

Für den Einstieg ist die Variante mit `Titel` und `titel` meist besser lesbar.

## Ein Objekt über den Konstruktor erzeugen

```csharp
Buch erstesBuch = new Buch(
    "C# verstehen",
    "Properties und Konstruktoren üben"
);
```

Die Argumente werden entsprechend ihrer Reihenfolge zugeordnet:

1. `"C# verstehen"` wird zum Parameter `titel`.
2. `"Properties und Konstruktoren üben"` wird zum Parameter `beschreibung`.
3. Der Konstruktor setzt `IstGelesen` selbst auf `false`.

Für ein zweites unabhängiges Objekt wird der Konstruktor erneut aufgerufen:

```csharp
Buch zweitesBuch = new Buch(
    "Blazor kennenlernen",
    "Eine erste Oberfläche planen"
);
```

## Pflichtwerte durch Konstruktorparameter

Wenn die Klasse nur einen Konstruktor mit zwei Parametern besitzt, müssen beide Argumente angegeben werden:

```csharp
Buch buch = new Buch("Titel", "Beschreibung");
```

Diese Aufrufe wären dann ungültig:

```csharp
// Buch buch = new Buch();
// Buch buch = new Buch("Nur ein Argument");
```

Der Compiler sucht einen Konstruktor, dessen Parameter zu Anzahl, Reihenfolge und Datentypen der Argumente passen. Findet er keinen, entsteht ein Compilerfehler.

## Property nachträglich verändern

Besitzt eine Property ein öffentliches `set`, kann sie nach der Objekterzeugung verändert werden:

```csharp
Console.WriteLine(erstesBuch.IstGelesen); // False
erstesBuch.IstGelesen = true;
Console.WriteLine(erstesBuch.IstGelesen); // True
```

Der Konstruktor legt also den Anfangszustand fest. Das `set` erlaubt spätere Zustandsänderungen.

## Vollständige Ausgabe

Eine aus der vorherigen Lektion bekannte Ausgabemethode funktioniert auch mit Properties:

```csharp
void ZeigeBuch(Buch buch)
{
    Console.WriteLine($"Titel: {buch.Titel}");
    Console.WriteLine($"Beschreibung: {buch.Beschreibung}");
    Console.WriteLine($"Gelesen: {buch.IstGelesen}");
}
```

`get` sorgt dafür, dass die Methode die Propertywerte lesen kann.

## Geführtes Vorgehen für die Aufgaben

1. Ersetze jedes öffentliche Feld durch eine Property mit `get; set;`.
2. Füge innerhalb der Klasse einen Konstruktor hinzu.
3. Gib ihm Parameter für alle Werte, die beim Erzeugen zwingend vorhanden sein sollen.
4. Weise im Konstruktor jedem Parameter die passende Property zu.
5. Setze den anfänglichen Wahrheitswert im Konstruktor ausdrücklich auf `false`.
6. Passe die `new`-Aufrufe an und übergib die benötigten Argumente.
7. Ändere eine boolesche Property später über ihr `set`.
8. Gib beide Objekte und den veränderten Zustand aus.

## Häufige Fehler

- Der Konstruktor besitzt versehentlich einen Rückgabetyp wie `void`.
- Der Konstruktorname stimmt nicht exakt mit dem Klassennamen überein.
- Property und Parameter werden in der Zuweisung vertauscht.
- Bei `new` fehlen Argumente oder sie stehen in der falschen Reihenfolge.
- Eine Property wurde ohne `set` geschrieben, soll aber später verändert werden.
- Der alte parameterlose Aufruf `new TaskItem()` wird nach Einführung des Konstruktors weiterverwendet.
- Der Anfangsstatus wird außerhalb des Konstruktors gesetzt und bei einem anderen Objekt vergessen.

