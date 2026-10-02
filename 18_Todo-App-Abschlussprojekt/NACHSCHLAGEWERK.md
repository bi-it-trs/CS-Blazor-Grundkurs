# To-do-App – Nachschlagewerk

Die folgenden Theorieabschnitte und Beispiele stammen aus den Lektionen 01–17. Übungsaufträge, Testpläne und Rücksetzbefehle sind ausgelassen. Die Namen in den Codebeispielen stammen aus den jeweiligen Lektionen und sind als Beispiele zu lesen.

## Inhalt

- [01 · C#-Grundaufbau](#kapitel-01)
- [02 · Variablen und Datentypen](#kapitel-02)
- [03 · Operatoren](#kapitel-03)
- [04 · Bedingungen](#kapitel-04)
- [05 · Schleifen](#kapitel-05)
- [06 · Methoden](#kapitel-06)
- [07 · Klassen und Objekte](#kapitel-07)
- [08 · Properties und Konstruktoren](#kapitel-08)
- [09 · Collections](#kapitel-09)
- [10 · Enums und Null](#kapitel-10)
- [11 · Fehler und Validierung](#kapitel-11)
- [12 · LINQ](#kapitel-12)
- [13 · Razor und Blazor](#kapitel-13)
- [14 · Blazor-Interaktionen](#kapitel-14)
- [15 · Komponenten und Datenfluss](#kapitel-15)
- [15 · Komponenten zwischen Geschwistern](#kapitel-16)
- [16 · Async/Await-Grundlagen](#kapitel-17)
- [16 · Async/Await in Blazor](#kapitel-18)
- [16 · Docker, MariaDB und DBeaver](#kapitel-19)
- [16 · LocalStorage](#kapitel-20)
- [16 · Dapper und MariaDB](#kapitel-21)
- [17 · Formulare und vollständiges CRUD](#kapitel-22)

<a id="kapitel-01"></a>

## 01 · C#-Grundaufbau

Quelle: [Theorie der Lektion](../01_CSharp-Grundaufbau/THEORIE_UND_ANLEITUNG.md)

### Das Projekt und `Program.cs`

Die Datei `Program.cs` enthält den Code, der beim Start ausgeführt wird.

Moderne C#-Konsolenprojekte erlauben Anweisungen direkt in der Datei:

```csharp
Console.WriteLine("Hallo!");
Console.WriteLine("Das ist die zweite Zeile.");
```

Die Anweisungen werden von oben nach unten ausgeführt. Jede `WriteLine`-Anweisung erzeugt eine neue Ausgabezeile.

### Das Programm ausführen

1. Speichere `Program.cs`.
2. Öffne ein Terminal im Ordner des Konsolenprojekts.
3. Führe den folgenden Befehl aus:

```powershell
dotnet run
```

Nach einer Änderung musst du die Datei erneut speichern und `dotnet run` erneut ausführen. Sonst siehst du möglicherweise noch die alte Ausgabe.

### Eine Anweisung zerlegen

```csharp
Console.WriteLine("Willkommen im C#-Grundkurs!");
```

| Teil | Bedeutung |
|---|---|
| `Console` | vorhandene C#-Klasse für Ein- und Ausgaben im Terminal |
| `.` | greift auf ein Mitglied von `Console` zu |
| `WriteLine` | Methode, die einen Wert ausgibt und danach in die nächste Zeile springt |
| `( )` | enthält die Werte, die an die Methode übergeben werden |
| `"Willkommen ..."` | ein Textwert; Text steht in doppelten Anführungszeichen |
| `;` | beendet die Anweisung |

Das Semikolon trennt eine vollständige Anweisung von der nächsten. Fehlt es, meldet der Compiler meistens einen Syntaxfehler.

### Groß- und Kleinschreibung

C# unterscheidet Groß- und Kleinschreibung:

```csharp
Console.WriteLine("Richtig");
// console.WriteLine("Falsch");
```

`Console` und `console` gelten als zwei verschiedene Namen. Auch `WriteLine` muss genau so geschrieben werden.

### Kommentare

Ein einzeiliger Kommentar beginnt mit `//`:

```csharp
// Diese Ausgaben beschreiben mein aktuelles Lernziel.
Console.WriteLine("Ich lerne C#.");
```

Ein mehrzeiliger Kommentar steht zwischen `/*` und `*/`:

```csharp
/*
Dieser Kommentar geht
über mehrere Zeilen.
*/
```

Kommentare werden vom Programm nicht ausgeführt und erscheinen nicht in der Ausgabe. Sie sollen erklären, warum ein Codeabschnitt existiert oder was sein Zweck ist.

<a id="kapitel-02"></a>

## 02 · Variablen und Datentypen

Quelle: [Theorie der Lektion](../02_Variablen-und-Datentypen/THEORIE_UND_ANLEITUNG.md)

### Was ist eine Variable?

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

### Vier wichtige Grundtypen

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

### Variablen sinnvoll benennen

Variablennamen werden in C# üblicherweise in **camelCase** geschrieben. Das erste Wort beginnt klein, jedes weitere Wort groß:

```csharp
double lernstundenProWoche = 4.5;
bool moechteBlazorLernen = true;
```

Ein Name darf keine Leerzeichen enthalten und sollte beschreiben, welcher Wert gespeichert wird.

### Werte mit String-Interpolation ausgeben

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

### Einen vorhandenen Wert verändern

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

### Gültigkeitsbereich

Eine Variable kann erst nach ihrer Deklaration verwendet werden. Außerdem ist sie nur in dem Block verfügbar, in dem sie deklariert wurde. Blöcke werden meistens durch `{ }` begrenzt. Das wird bei Bedingungen, Schleifen und Methoden wichtig.

<a id="kapitel-03"></a>

## 03 · Operatoren

Quelle: [Theorie der Lektion](../03_Operatoren/THEORIE_UND_ANLEITUNG.md)

### Von Ausgangswerten zu Ergebnissen

Eine Berechnung besteht meistens aus drei Schritten:

1. Ausgangswerte in Variablen speichern.
2. Mit Operatoren ein Ergebnis berechnen und dieses in einer neuen Variable speichern.
3. Das Ergebnis ausgeben.

```csharp
int vorhandeneSeiten = 12;
int geleseneSeiten = 5;
int offeneSeiten = vorhandeneSeiten - geleseneSeiten;

Console.WriteLine($"Noch offen: {offeneSeiten}");
```

### Rechenoperatoren

| Operator | Bedeutung | Beispiel |
|---|---|---|
| `+` | Addition | `gesamt = alt + neu` |
| `-` | Subtraktion | `offen = gesamt - fertig` |
| `*` | Multiplikation | `minuten = anzahl * minutenProEinheit` |
| `/` | Division | `stunden = minuten / 60.0` |
| `%` | Rest einer Division | `rest = anzahl % 2` |

### Reihenfolge der Berechnung

Multiplikation und Division werden vor Addition und Subtraktion ausgeführt. Klammern machen eine andere Reihenfolge ausdrücklich sichtbar:

```csharp
int ohneKlammern = 2 + 3 * 4;    // 14
int mitKlammern = (2 + 3) * 4;   // 20
```

Wenn eine Rechnung schwer auf einen Blick zu lesen ist, helfen Klammern auch dann, wenn das Ergebnis ohne sie gleich wäre.

### Ganzzahlige und genaue Division

Sind beide Operanden `int`, führt C# eine Ganzzahldivision aus. Nachkommastellen gehen verloren:

```csharp
int ganzzahlig = 10 / 3;       // 3
double genau = 10.0 / 3;       // ungefähr 3.333
```

Für die Umrechnung von Minuten in Stunden sollte mindestens eine Zahl ein `double` sein:

```csharp
int gesamtMinuten = 95;
double gesamtStunden = gesamtMinuten / 60.0;
```

`60.0` sorgt dafür, dass die Nachkommastellen erhalten bleiben. Das Ergebnis kann deshalb in einer `double`-Variable gespeichert werden.

### Vergleiche liefern einen Wahrheitswert

Vergleiche ergeben immer `true` oder `false` und können deshalb in einer `bool`-Variable gespeichert werden:

| Operator | Bedeutung |
|---|---|
| `==` | gleich |
| `!=` | ungleich |
| `>` | größer |
| `<` | kleiner |
| `>=` | größer oder gleich |
| `<=` | kleiner oder gleich |

```csharp
int bearbeitet = 6;
int ziel = 5;
bool zielErreicht = bearbeitet >= ziel;

Console.WriteLine($"Ziel erreicht: {zielErreicht}");
```

`=` weist einen Wert zu. `==` vergleicht zwei Werte. Diese Zeichen haben unterschiedliche Aufgaben.

### Werte mit Kurzschreibweisen verändern

```csharp
int punkte = 10;
punkte += 5;  // dasselbe wie: punkte = punkte + 5;
punkte -= 2;  // dasselbe wie: punkte = punkte - 2;
```

Die Variable muss vor `+=` oder `-=` bereits existieren.

### Abhängige Ergebnisse neu berechnen

C# merkt sich in einer Ergebnisvariable nur das Ergebnis der damaligen Rechnung. Die Rechenformel bleibt nicht automatisch mit ihren Ausgangswerten verbunden:

```csharp
int gesamt = 8;
int fertig = 2;
int offen = gesamt - fertig;   // offen ist jetzt 6

fertig += 3;                   // fertig ist jetzt 5
// offen ist weiterhin 6

offen = gesamt - fertig;       // neu berechnet: offen ist jetzt 3
```

Nach einer Änderung musst du alle Ergebnisse, die davon abhängen, erneut zuweisen.

### Restwert mit `%`

Der Modulo-Operator `%` gibt den Rest einer Division zurück:

```csharp
int einheiten = 8;
int rest = einheiten % 2;          // 0
bool gleichmaessigTeilbar = rest == 0;
```

Ein Rest von `0` bedeutet, dass die Zahl ohne Rest teilbar ist. Bei `9 % 2` wäre der Rest `1`.

<a id="kapitel-04"></a>

## 04 · Bedingungen

Quelle: [Theorie der Lektion](../04_Bedingungen/THEORIE_UND_ANLEITUNG.md)

### Bedingungen ergeben `true` oder `false`

Der Ausdruck in den runden Klammern einer `if`-Anweisung muss einen `bool` ergeben:

```csharp
int fortschritt = 7;
bool zielErreicht = fortschritt >= 5;

if (zielErreicht)
{
    Console.WriteLine("Das Ziel wurde erreicht.");
}
```

Du kannst den Vergleich auch direkt in die Klammern schreiben: `if (fortschritt >= 5)`.

### `if`, `else if` und `else`

```csharp
int erledigt = 2;
int gesamt = 5;

if (erledigt >= gesamt)
{
    Console.WriteLine("Abgeschlossen");
}
else if (erledigt > 0)
{
    Console.WriteLine("In Arbeit");
}
else
{
    Console.WriteLine("Noch nicht begonnen");
}
```

Die Bedingungen werden von oben nach unten geprüft:

1. Trifft die `if`-Bedingung zu, wird ihr Block ausgeführt.
2. Andernfalls wird die nächste `else if`-Bedingung geprüft.
3. Trifft keine Bedingung zu, wird der `else`-Block ausgeführt.

In einer zusammenhängenden `if`-/`else if`-/`else`-Kette wird höchstens ein Block ausgeführt. Deshalb sollte der speziellste oder wichtigste Fall weit oben stehen.

Die geschweiften Klammern begrenzen den jeweiligen Codeblock. Variablen, die ausschließlich innerhalb eines Blocks deklariert werden, stehen außerhalb dieses Blocks nicht zur Verfügung.

### Werte vergleichen

Du kannst Zahlen, Texte und Wahrheitswerte vergleichen:

```csharp
int erledigt = 2;
int gesamt = 5;
string statusText = "Fertig";
bool istVollstaendig = erledigt == gesamt;
bool hatNochArbeit = erledigt != gesamt;
bool richtigerText = statusText == "Fertig";
```

Bei Texten müssen Schreibweise und Leerzeichen übereinstimmen. `"Fertig"` und `"fertig"` sind unterschiedliche Werte.

### Logische Operatoren

| Operator | Bedeutung |
|---|---|
| `&&` | beide Bedingungen müssen `true` sein |
| `||` | mindestens eine Bedingung muss `true` sein |
| `!` | kehrt einen Wahrheitswert um |

```csharp
bool istDringend = true;
bool istFertig = false;

if (istDringend && !istFertig)
{
    Console.WriteLine("Zuerst bearbeiten");
}
```

`!istFertig` bedeutet „ist nicht fertig“. Beide Seiten von `&&` und `||` müssen vollständige Bedingungen beziehungsweise `bool`-Werte sein:

```csharp
int punkte = 4;
bool bonus = true;

if (punkte >= 5 || bonus == true)
{
    Console.WriteLine("Bestanden");
}
```

`bonus == true` kann kürzer als `bonus` geschrieben werden. Entsprechend ist `bonus == false` dasselbe wie `!bonus`.

### Eine Zahl mit `switch` in Text übersetzen

`switch` eignet sich, wenn eine Variable mehrere feste Auswahlwerte haben kann. Soll das Ergebnis später noch gebraucht werden, deklarierst du die Ergebnisvariable vor dem `switch` und weist ihr in jedem Fall einen Wert zu:

```csharp
int auswahl = 2;
string bereich;

switch (auswahl)
{
    case 1:
        bereich = "Grundlagen";
        break;
    case 2:
        bereich = "Übungen";
        break;
    case 3:
        bereich = "Projekt";
        break;
    default:
        bereich = "Unbekannte Auswahl";
        break;
}

Console.WriteLine($"Bereich: {bereich}");
```

Wichtige Bestandteile:

- `switch (auswahl)` prüft den Wert von `auswahl`.
- `case 1:` behandelt einen bestimmten Wert.
- `break` beendet diesen Fall, damit nicht in den nächsten Fall weitergelaufen wird.
- `default` behandelt alle Werte, für die es keinen passenden `case` gibt.
- Weil jeder mögliche Weg einen Text zuweist, kann `bereich` danach sicher verwendet werden.

<a id="kapitel-05"></a>

## 05 · Schleifen

Quelle: [Theorie der Lektion](../05_Schleifen/THEORIE_UND_ANLEITUNG.md)

### Welche Schleife passt wann?

| Schleife | Geeignet, wenn ... |
|---|---|
| `foreach` | jedes Element einer Sammlung einmal verarbeitet werden soll |
| `for` | die Anzahl der Wiederholungen bekannt ist oder ein Zähler benötigt wird |
| `while` | vorher nicht bekannt ist, wie oft wiederholt werden muss |
| `do-while` | der Block mindestens einmal ausgeführt werden muss |

### Mehrere Werte in einem Array speichern

Ein Array speichert mehrere Werte desselben Typs. Ein `string[]` ist ein Array aus Texten:

```csharp
string[] lernThemen =
{
    "Variablen",
    "Operatoren",
    "Bedingungen",
    "Schleifen"
};
```

Die Werte werden durch Kommas getrennt. `lernThemen.Length` enthält die Anzahl der Elemente, hier also `4`.

Array-Positionen beginnen bei `0`:

```csharp
Console.WriteLine(lernThemen[0]); // Variablen
Console.WriteLine(lernThemen[1]); // Operatoren
```

### `foreach`: jedes Element verarbeiten

```csharp
foreach (string thema in lernThemen)
{
    Console.WriteLine($"Thema: {thema}");
}
```

Bei jedem Durchlauf erhält `thema` den nächsten Wert aus `lernThemen`. Die Variable `thema` wird im Kopf der Schleife deklariert und existiert nur innerhalb des Schleifenblocks. Du musst sie vorher nicht anlegen.

Der Name ist frei wählbar. Ein Einzahlname für das einzelne Element und ein Mehrzahlname für die Sammlung machen den Code leichter lesbar.

### `for`: mit einem Zähler wiederholen

```csharp
for (int runde = 1; runde <= 5; runde++)
{
    Console.WriteLine($"Lernrunde {runde}");
}
```

Der Kopf besteht aus drei Teilen:

1. `int runde = 1` legt den Startwert einmalig fest.
2. `runde <= 5` wird vor jedem Durchlauf geprüft.
3. `runde++` erhöht den Wert nach jedem Durchlauf um eins.

`runde++` ist eine Kurzform für `runde = runde + 1`. Die Schleife läuft hier für die Werte `1`, `2`, `3`, `4` und `5`.

### `while`: wiederholen, solange etwas zutrifft

Die Bedingung einer `while`-Schleife wird vor jedem Durchlauf geprüft:

```csharp
int erledigt = 0;
int ziel = 4;

while (erledigt < ziel)
{
    erledigt++;
    Console.WriteLine($"Erledigt: {erledigt} von {ziel}");
}
```

Für eine sicher endende `while`-Schleife brauchst du:

1. einen sinnvollen Startwert vor der Schleife,
2. eine Bedingung, die anfangs zutrifft,
3. eine Veränderung im Schleifenblock, durch die die Bedingung irgendwann `false` wird.

Ohne `erledigt++` bliebe `erledigt < ziel` immer wahr und die Schleife würde endlos laufen.

### `do-while`: mindestens einmal fragen

Die Variable wird vor der Schleife deklariert, damit sie sowohl im Block als auch in der Bedingung verfügbar ist:

```csharp
string? eingabe;

do
{
    Console.Write("Gib einen Begriff ein: ");
    eingabe = Console.ReadLine();
}
while (string.IsNullOrWhiteSpace(eingabe));

Console.WriteLine($"Gültige Eingabe: {eingabe}");
```

Ablauf:

1. Der `do`-Block läuft ohne vorherige Prüfung mindestens einmal.
2. Danach prüft `while`, ob die Eingabe ungültig ist.
3. Bei `true` beginnt ein neuer Durchlauf.
4. Bei `false` endet die Schleife.

Beachte das Semikolon nach der `while`-Bedingung einer `do-while`-Schleife.

Würde `eingabe` erst innerhalb der geschweiften Klammern mit `string? eingabe = ...` deklariert, wäre sie in der anschließenden `while`-Bedingung nicht mehr sichtbar.

### Alternative mit `while`

Mit einer normalen `while`-Schleife brauchst du bereits vor der ersten Prüfung einen Anfangswert:

```csharp
Console.Write("Gib einen Begriff ein: ");
string? eingabe = Console.ReadLine();

while (string.IsNullOrWhiteSpace(eingabe))
{
    Console.Write("Eingabe war leer. Erneut: ");
    eingabe = Console.ReadLine();
}
```

Beide Varianten sind korrekt. Für eine Eingabe, die auf jeden Fall mindestens einmal erfolgen muss, ist `do-while` oft übersichtlicher.

### `continue` und `break`

- `continue` überspringt den Rest des aktuellen Durchlaufs und beginnt den nächsten.
- `break` beendet die Schleife vollständig.

<a id="kapitel-06"></a>

## 06 · Methoden

Quelle: [Theorie der Lektion](../06_Methoden/THEORIE_UND_ANLEITUNG.md)

### Warum Methoden?

Eine Methode fasst einen klaren Arbeitsschritt zusammen. Dadurch musst du denselben Code nicht mehrfach schreiben:

```csharp
ZeigeThema("Methoden");
ZeigeThema("Klassen");

void ZeigeThema(string thema)
{
    Console.WriteLine($"Thema: {thema}");
}
```

Der Methodenaufruf führt den Code im Methodenblock aus. Danach läuft das Programm hinter dem Aufruf weiter.

In einem Konsolenprojekt mit Anweisungen auf oberster Ebene können solche Methoden unterhalb der Hauptanweisungen in `Program.cs` stehen.

### Aufbau einer Methode

```csharp
int Addiere(int ersteZahl, int zweiteZahl)
{
    int summe = ersteZahl + zweiteZahl;
    return summe;
}
```

| Teil | Bedeutung |
|---|---|
| `int` vor dem Namen | Rückgabetyp |
| `Addiere` | Methodenname |
| `int ersteZahl` | erster Parameter mit Datentyp |
| `int zweiteZahl` | zweiter Parameter mit Datentyp |
| `{ ... }` | Methodenblock |
| `return summe;` | gibt das Ergebnis an den Aufrufer zurück |

Methodennamen werden üblicherweise in **PascalCase** geschrieben, beispielsweise `ZeigeThema`, `BerechneRest` oder `IstBestanden`.

### Parameter und Argumente

Ein **Parameter** ist die Variable in der Methodendefinition. Ein **Argument** ist der konkrete Wert beim Aufruf:

```csharp
void Begruesse(string name) // name ist der Parameter
{
    Console.WriteLine($"Hallo {name}");
}

Begruesse("Sam");           // "Sam" ist das Argument
```

Anzahl, Reihenfolge und Datentypen der Argumente müssen zu den Parametern passen:

```csharp
int Addiere(int a, int b)
{
    return a + b;
}

int ergebnis = Addiere(4, 7);
```

Im Aufruf erhält `a` den Wert `4` und `b` den Wert `7`.

### Methode ohne Rückgabewert: `void`

`void` bedeutet, dass die Methode keinen Wert zurückgibt:

```csharp
void ZeigeMeldung(string meldung)
{
    Console.WriteLine(meldung);
}

ZeigeMeldung("Die Übung beginnt.");
```

Eine `void`-Methode kann etwas ausführen oder ausgeben. Ihr Aufruf kann aber nicht in einer Ergebnisvariable gespeichert werden.

### Methode mit Rückgabewert

Eine Berechnung sollte ihr Ergebnis zurückgeben, damit der aufrufende Code entscheidet, was damit passiert:

```csharp
int BerechneRest(int gesamt, int verbraucht)
{
    int rest = gesamt - verbraucht;
    return rest;
}

int verbleibend = BerechneRest(12, 5);
Console.WriteLine($"Verbleibend: {verbleibend}");
```

Der Rückgabetyp und der Wert hinter `return` müssen zusammenpassen. Eine Methode mit Rückgabetyp `int` muss eine ganze Zahl zurückgeben, eine Methode mit `bool` einen Wahrheitswert und eine Methode mit `string` einen Text.

`return` beendet die Methode sofort. Bei einer Methode mit Rückgabewert muss jeder mögliche Programmweg einen passenden Wert zurückgeben.

### Eine Methode mit `bool` als Ergebnis

Ein Vergleich liefert bereits einen Wahrheitswert und kann direkt zurückgegeben werden:

```csharp
bool IstBestanden(int punkte, int mindestPunkte)
{
    return punkte >= mindestPunkte;
}

bool ersterTest = IstBestanden(8, 5);  // True
bool zweiterTest = IstBestanden(3, 5); // False
```

Zum Prüfen einer solchen Methode solltest du mindestens einen Fall testen, der `true` ergibt, und einen, der `false` ergibt.

### Eine Methode mit `string` als Ergebnis

Auch ein zusammengesetzter Text kann zurückgegeben werden:

```csharp
string ErstelleBuchText(string titel, string autor)
{
    return $"{titel} von {autor}";
}

string ausgabetext = ErstelleBuchText("Beispielbuch", "M. Muster");
Console.WriteLine(ausgabetext);
```

Diese Methode erzeugt nur den Text. Die Ausgabe erfolgt bewusst außerhalb der Methode.

### Ausgabe und Berechnung trennen

Eine Berechnungsmethode wird flexibler, wenn sie nicht selbst ausgibt:

```csharp
int Verdopple(int zahl)
{
    return zahl * 2;
}

int wert = Verdopple(6);
Console.WriteLine(wert);
```

So kann der Rückgabewert später ausgegeben, gespeichert, verglichen oder weiterberechnet werden.

### Gültigkeitsbereich

Parameter und innerhalb einer Methode deklarierte Variablen existieren nur in dieser Methode:

```csharp
int BerechneQuadrat(int zahl)
{
    int quadrat = zahl * zahl;
    return quadrat;
}

// zahl und quadrat sind hier nicht verfügbar.
```

Eine außerhalb angelegte Variable kann denselben Namen wie ein Parameter haben. Es sind trotzdem unterschiedliche Variablen in unterschiedlichen Gültigkeitsbereichen.

<a id="kapitel-07"></a>

## 07 · Klassen und Objekte

Quelle: [Theorie der Lektion](../07_Klassen-und-Objekte/THEORIE_UND_ANLEITUNG.md)

### Klasse und Objekt

Eine Klasse ist ein Bauplan. Sie beschreibt, welche Daten alle Objekte dieses Typs besitzen. Ein Objekt ist ein konkretes Exemplar dieses Bauplans.

Beispiel: Die Klasse `Buch` legt fest, dass jedes Buch einen Titel und eine Seitenzahl besitzt. Zwei daraus erzeugte Buchobjekte können unterschiedliche Titel und Seitenzahlen speichern.

### Eine Klasse in einer eigenen Datei anlegen

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


Alle `.cs`-Dateien innerhalb desselben Projekts werden gemeinsam kompiliert. Du musst `Buch.cs` deshalb nicht manuell in `Program.cs` laden.

### Ein Objekt mit `new` erzeugen

```csharp
Buch erstesBuch = new Buch();
```

| Teil | Bedeutung |
|---|---|
| erstes `Buch` | Datentyp der Variable |
| `erstesBuch` | Name der Variable |
| `new Buch()` | erzeugt ein neues Objekt im Arbeitsspeicher |

Die Variable `erstesBuch` verweist anschließend auf dieses Objekt.

### Felder mit dem Punktoperator verwenden

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

### Mehrere unabhängige Objekte

Jeder Aufruf von `new` erzeugt ein neues Objekt:

```csharp
Buch erstesBuch = new Buch();
erstesBuch.Titel = "C# verstehen";

Buch zweitesBuch = new Buch();
zweitesBuch.Titel = "Blazor kennenlernen";
```

Eine Änderung an `erstesBuch.Titel` verändert `zweitesBuch.Titel` nicht. Beide Objekte besitzen ihre eigenen Felder.

### Ein Feld nachträglich verändern

Ein vorhandenes Feld kann erneut zugewiesen werden:

```csharp
erstesBuch.IstGelesen = false;
Console.WriteLine(erstesBuch.IstGelesen);

erstesBuch.IstGelesen = true;
Console.WriteLine(erstesBuch.IstGelesen);
```

Dabei wird kein neues Objekt erzeugt. Nur der Wert eines Feldes des bestehenden Objekts ändert sich.

### Ein Objekt an eine Methode übergeben

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

### Klassen sind Referenztypen

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

### Namenskonventionen

- Klassen: PascalCase, zum Beispiel `TaskItem`.
- Lokale Variablen und Parameter: camelCase, zum Beispiel `ersteAufgabe` und `aufgabe`.

<a id="kapitel-08"></a>

## 08 · Properties und Konstruktoren

Quelle: [Theorie der Lektion](../08_Properties-und-Konstruktoren/THEORIE_UND_ANLEITUNG.md)

### Von Feldern zu Properties

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

### Eine Klasse mit Properties

```csharp
public class Buch
{
    public string Titel { get; set; }
    public string Beschreibung { get; set; }
    public bool IstGelesen { get; set; }
}
```

Ohne Konstruktor müsste der aufrufende Code die Werte nach `new Buch()` einzeln setzen. Dabei könnte ein notwendiger Wert vergessen werden.

### Was ist ein Konstruktor?

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

### Properties und Parameter unterscheiden

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

### Ein Objekt über den Konstruktor erzeugen

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

### Pflichtwerte durch Konstruktorparameter

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

### Property nachträglich verändern

Besitzt eine Property ein öffentliches `set`, kann sie nach der Objekterzeugung verändert werden:

```csharp
Console.WriteLine(erstesBuch.IstGelesen); // False
erstesBuch.IstGelesen = true;
Console.WriteLine(erstesBuch.IstGelesen); // True
```

Der Konstruktor legt also den Anfangszustand fest. Das `set` erlaubt spätere Zustandsänderungen.

<a id="kapitel-09"></a>

## 09 · Collections

Quelle: [Theorie der Lektion](../09_Collections/THEORIE_UND_ANLEITUNG.md)

### Warum eine `List<T>`?

Einzelne Variablen werden bei mehreren Aufgaben schnell unübersichtlich:

```csharp
TaskItem aufgabe1 = new TaskItem("C# lesen", "Kapitel wiederholen");
TaskItem aufgabe2 = new TaskItem("Code schreiben", "Übungen lösen");
```

Eine `List<T>` fasst beliebig viele Elemente desselben Typs in einer Sammlung zusammen. Anders als ein Array kann eine Liste nachträglich wachsen und schrumpfen.

### Liste anlegen

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

### Elemente mit `Add` hinzufügen

```csharp
TaskItem ersteAufgabe = new TaskItem("C# lesen", "Kapitel wiederholen");
TaskItem zweiteAufgabe = new TaskItem("Code schreiben", "Übungen lösen");

aufgaben.Add(ersteAufgabe);
aufgaben.Add(zweiteAufgabe);
aufgaben.Add(new TaskItem("Notizen ordnen", "Wichtige Regeln sammeln"));
```

`Add` hängt ein Element am Ende der Liste an. Die Listenreihenfolge hängt von der Reihenfolge der `Add`-Aufrufe ab, nicht davon, wann die Objektvariablen angelegt wurden.

### Anzahl mit `Count`

```csharp
int anzahl = aufgaben.Count;
Console.WriteLine($"Anzahl: {anzahl}");
```

`Count` ist die aktuelle Anzahl der Listenelemente. Nach `Add` wird sie größer, nach erfolgreichem Entfernen kleiner.

### Zugriff über den Index

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

### Ein Objekt über seinen Index verändern

Da `TaskItem` eine Klasse ist, kannst du direkt auf eine Property des Listenelements zugreifen:

```csharp
aufgaben[1].IstErledigt = true;
```

`[1]` wählt das zweite Objekt aus. Der Punkt greift anschließend auf dessen Property zu. Das Objekt bleibt in der Liste; nur sein Status ändert sich.

### Liste mit `foreach` durchlaufen

```csharp
foreach (TaskItem aufgabe in aufgaben)
{
    Console.WriteLine($"Titel: {aufgabe.Titel}");
    Console.WriteLine($"Erledigt: {aufgabe.IstErledigt}");
}
```

`aufgaben` ist die vollständige Liste. `aufgabe` ist während jedes Durchlaufs jeweils ein einzelnes `TaskItem` daraus. Die Schleifenvariable wird im `foreach`-Kopf deklariert und existiert nur im Schleifenblock.

### Vor einem Indexzugriff prüfen

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

### Mit `RemoveAt` über den Index entfernen

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

### Mit `Remove` ein bestimmtes Objekt entfernen

```csharp
bool wurdeEntfernt = aufgaben.Remove(zweiteAufgabe);
```

`Remove` sucht nach dem angegebenen Objekt und entfernt das erste passende Element. Die Methode gibt `true` zurück, wenn etwas entfernt wurde, sonst `false`.


### Eine komplette Liste an eine Methode übergeben

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

<a id="kapitel-10"></a>

## 10 · Enums und Null

Quelle: [Theorie der Lektion](../10_Enums-und-Null/THEORIE_UND_ANLEITUNG.md)

### Warum ein Enum statt freiem Text?

Ein Status als `string` erlaubt beliebige Schreibweisen:

```csharp
string status1 = "In Arbeit";
string status2 = "in arbeit";
string status3 = "InArbiet";
```

Diese drei Texte sollen möglicherweise dasselbe bedeuten, sind für C# aber verschieden. Ein Enum beschränkt den Wert auf vorher festgelegte Möglichkeiten und verhindert Tippfehler bei der Zuweisung.

### Ein Enum definieren

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

### Eine Enum-Variable verwenden

```csharp
MedienStatus status = MedienStatus.Ungelesen;
status = MedienStatus.Begonnen;
```

Links steht der Enum-Typ. Rechts wird ein konkreter Wert über `EnumName.Wert` ausgewählt.

Ein Wert eines anderen Enums oder ein beliebiger Statustext kann nicht versehentlich zugewiesen werden. Das macht den Code sicherer.

### Enum als Property einer Klasse

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

### Enum vergleichen

```csharp
if (buch.Status == MedienStatus.Beendet)
{
    Console.WriteLine("Das Buch ist abgeschlossen.");
}
```

Beim Vergleich verwendest du ebenfalls den Enum-Typ und einen seiner Werte. Es werden keine frei geschriebenen Statustexte verglichen.

### Enum ausgeben

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

### `nameof` verstehen

`nameof` liefert den Namen eines Codeelements als `string`:

```csharp
string nameAlsText = nameof(MedienStatus.Ungelesen);
Console.WriteLine(nameAlsText); // Ungelesen
```

Der Unterschied:

- `MedienStatus.Ungelesen` ist ein Wert vom Typ `MedienStatus`.
- `nameof(MedienStatus.Ungelesen)` ist der Text `"Ungelesen"` vom Typ `string`.

Bei einer Ausgabe sehen beide ähnlich aus, besitzen aber unterschiedliche Typen und Zwecke. Mit dem Enum-Wert kannst du typsicher Status vergleichen und zuweisen. `nameof` benötigst du nur, wenn der Name ausdrücklich als Text gebraucht wird.

### Was bedeutet `null`?

`null` bedeutet, dass kein Wert vorhanden ist. Das ist etwas anderes als ein leerer Text:

| Wert | Bedeutung |
|---|---|
| `null` | kein Textwert vorhanden |
| `""` | ein vorhandener Text mit Länge null |
| `"   "` | ein vorhandener Text, der nur Leerzeichen enthält |

Ein erforderlicher Titel sollte als normaler `string` definiert werden. Eine optionale Beschreibung darf dagegen `null` sein.

### Nullable Referenztypen mit `?`

```csharp
string titel = "C# lernen";
string? beschreibung = null;
```

Das Fragezeichen bei `string?` sagt ausdrücklich: Diese Variable darf entweder einen Text oder `null` enthalten.

Bei aktiviertem Nullable-System warnt der Compiler, wenn du einer normalen `string`-Variable möglicherweise `null` zuweist. Dadurch werden Fehler durch fehlende Werte früher sichtbar.

### Optionale Beschreibung in Property und Konstruktor

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

### Fehlenden Text mit `??` ersetzen

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

### Warum der Ersatztext nicht gespeichert werden sollte

`null` beschreibt den tatsächlichen Datenzustand: Es wurde keine Beschreibung angegeben. `"Keine Beschreibung"` ist nur eine benutzerfreundliche Darstellung dieses Zustands.

Würdest du den Anzeigetext dauerhaft als Beschreibung speichern, könnte der Code später nicht mehr unterscheiden, ob der Benutzer wirklich diesen Text eingegeben hat oder ob die Beschreibung fehlt.

<a id="kapitel-11"></a>

## 11 · Fehler und Validierung

Quelle: [Theorie der Lektion](../11_Fehler-und-Validierung/THEORIE_UND_ANLEITUNG.md)

### Was ist Validierung?

Validierung bedeutet, einen eingegebenen Wert vor der weiteren Verarbeitung zu prüfen:

- Ist ein Pflichttext vorhanden?
- Lässt sich eine Eingabe in eine Zahl umwandeln?
- Liegt die Zahl im erlaubten Bereich?
- Darf ein Wert fehlen?

Ungültige Benutzereingaben gehören zum normalen Programmablauf. Das Programm soll deshalb eine verständliche Meldung zeigen und erneut fragen, statt abzustürzen.

### Pflichttext prüfen

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

### Optionale Eingabe genau einmal lesen

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

### Warum `int.Parse` für Benutzereingaben riskant ist

```csharp
int zahl = int.Parse(eingabe);
```

`int.Parse` erwartet gültigen Zahlentext. Bei `""`, `"abc"` oder anderen ungültigen Eingaben wirft die Methode eine Exception. Das Programm würde ohne zusätzliche Behandlung abbrechen.

Für erwartbare Eingaben ist `int.TryParse` besser geeignet.

### Zahlen mit `TryParse` sicher einlesen

```csharp
bool konnteUmwandeln = int.TryParse(eingabe, out int zahl);
```

`TryParse` liefert zwei Informationen:

- Der Rückgabewert ist `true`, wenn die Umwandlung funktioniert hat.
- Die `out`-Variable `zahl` enthält danach das Zahlenergebnis.

Bei ungültigem Text liefert die Methode `false`, statt das Programm abstürzen zu lassen.

### Umwandlung und erlaubten Bereich gemeinsam prüfen

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

### Validierung und Exceptions

Falsche Benutzereingaben sind erwartbar und werden mit Prüfungen wie `IsNullOrWhiteSpace`, `TryParse` und Bereichsvergleichen behandelt.

Exceptions sind für Fehler gedacht, die nicht zum normalen Eingabeablauf gehören. Verwende sie nicht als Ersatz für einfache Validierung.

<a id="kapitel-12"></a>

## 12 · LINQ

Quelle: [Theorie der Lektion](../12_LINQ-Grundlagen/THEORIE_UND_ANLEITUNG.md)

### Was ist LINQ?

LINQ steht für **Language Integrated Query**. Es stellt Methoden bereit, mit denen Sammlungen beschrieben und ausgewertet werden können:

- `Count(...)` zählt passende Elemente.
- `Where(...)` filtert Elemente.
- `OrderBy(...)` sortiert aufsteigend.
- `ToList()` erzeugt aus dem Ergebnis eine neue Liste.

In modernen Konsolenprojekten ist der benötigte Namespace `System.Linq` normalerweise über implizite `using`-Anweisungen verfügbar.

Für die Beispiele wird eine vorhandene `List<TaskItem> aufgaben` verwendet.

### Alle Elemente mit `Count` zählen

`Count` ohne runde Klammern ist eine Property der Liste:

```csharp
int gesamt = aufgaben.Count;
```

Sie liefert die Anzahl aller Listenelemente.

### Passende Elemente mit `Count(...)` zählen

Die LINQ-Methode `Count(...)` kann eine Bedingung erhalten:

```csharp
int erledigt = aufgaben.Count(
    aufgabe => aufgabe.Status == AufgabenStatus.Erledigt
);
```

Das bedeutet: Zähle jedes Element, dessen Status `Erledigt` ist.

Der Unterschied:

| Schreibweise | Ergebnis |
|---|---|
| `aufgaben.Count` | Anzahl aller Elemente |
| `aufgaben.Count(bedingung)` | Anzahl der Elemente, die die Bedingung erfüllen |

Für verschiedene Statuswerte verwendest du dieselbe Struktur mit einer jeweils passenden Vergleichsbedingung.

### Lambda-Ausdrücke lesen

```csharp
aufgabe => aufgabe.Status == AufgabenStatus.Offen
```

Ein Lambda-Ausdruck ist hier eine kurze Prüffunktion:

- Das erste `aufgabe` ist ein frei gewählter Name für jeweils ein Listenelement.
- `=>` kann als „wird geprüft mit“ gelesen werden.
- Rechts steht eine Bedingung, die `true` oder `false` ergibt.

In Worten: „Nimm eine Aufgabe und prüfe, ob ihr Status offen ist.“

Die Lambda-Variable existiert nur innerhalb dieses Ausdrucks. Sie muss vorher nicht deklariert werden.

### Mit `Where` filtern

`Where` behält nur Elemente, für die die Bedingung `true` liefert:

```csharp
List<TaskItem> offeneAufgaben = aufgaben
    .Where(aufgabe => aufgabe.Status == AufgabenStatus.Offen)
    .ToList();
```

`Where` verändert `aufgaben` nicht. Es liefert eine gefilterte Folge. `ToList()` macht daraus eine neue `List<TaskItem>`, die in der Variable gespeichert wird.

### Mehrere Statuswerte filtern

Beide Seiten von `||` müssen vollständige Bedingungen sein:

```csharp
List<TaskItem> aktiveAufgaben = aufgaben
    .Where(aufgabe =>
        aufgabe.Status == AufgabenStatus.Offen
        || aufgabe.Status == AufgabenStatus.InArbeit)
    .ToList();
```

Diese verkürzte Schreibweise ist ungültig:

```csharp
// Falsch:
// aufgabe.Status == AufgabenStatus.Offen
// || AufgabenStatus.InArbeit
```

`AufgabenStatus.InArbeit` ist ein Enum-Wert und für sich allein keine Bedingung. Links und rechts von `||` muss jeweils ein Ausdruck stehen, der `bool` ergibt.

Wenn „nicht erledigt“ genau die beiden gewünschten Statuswerte umfasst, ist diese Bedingung kürzer:

```csharp
List<TaskItem> nichtErledigteAufgaben = aufgaben
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .ToList();
```

Der Variablenname sollte den tatsächlichen Inhalt beschreiben. Eine Liste mit offenen **und** in Arbeit befindlichen Aufgaben sollte nicht nur `offeneAufgaben` heißen.

### Mit `OrderBy` sortieren

```csharp
List<TaskItem> alphabetisch = aufgaben
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();
```

Der Lambda-Ausdruck hinter `OrderBy` wählt den Sortierschlüssel. Hier wird nach der Property `Titel` aufsteigend sortiert.

`OrderBy` sortiert nicht die ursprüngliche Liste um. Durch `ToList()` entsteht eine neue Liste in sortierter Reihenfolge.

### Filtern und Sortieren verketten

LINQ-Methoden können hintereinander ausgeführt werden:

```csharp
List<TaskItem> aktiveAufgabenAlphabetisch = aufgaben
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();
```

Der Datenfluss lautet:

```text
ursprüngliche Liste
    → Where behält passende Elemente
    → OrderBy ordnet diese Elemente
    → ToList erzeugt eine neue Liste
```

Jede Methode arbeitet auf dem Ergebnis der vorherigen Methode.

### `Where().OrderBy()` gegenüber `OrderBy().Where()`

Beide Varianten können denselben sichtbaren Inhalt liefern:

```csharp
List<TaskItem> varianteA = aufgaben
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();

List<TaskItem> varianteB = aufgaben
    .OrderBy(aufgabe => aufgabe.Titel)
    .Where(aufgabe => aufgabe.Status != AufgabenStatus.Erledigt)
    .ToList();
```

Warum ist das Ergebnis hier gleich?

- Variante A entfernt zuerst erledigte Aufgaben und sortiert die verbleibenden Titel.
- Variante B sortiert zuerst alle Aufgaben und entfernt anschließend die erledigten.
- Das Filtern verändert die Reihenfolge der übrig gebliebenen Elemente nicht.

Variante A ist meist sinnvoller, weil `OrderBy` nur die bereits verkleinerte Menge sortieren muss. Allgemein darf die Reihenfolge verketteter Methoden aber nicht beliebig vertauscht werden; andere Methodenfolgen können unterschiedliche Ergebnisse liefern.

### Eine separat sortierte Gesamtliste

Wenn sowohl eine gefilterte als auch eine vollständig sortierte Liste benötigt wird, startest du beide Abfragen wieder bei der ursprünglichen Liste:

```csharp
List<TaskItem> gefiltertUndSortiert = aufgaben
    .Where(/* Bedingung */)
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();

List<TaskItem> alleSortiert = aufgaben
    .OrderBy(aufgabe => aufgabe.Titel)
    .ToList();
```

Die zweite Abfrage darf nicht versehentlich bei `gefiltertUndSortiert` beginnen, wenn wirklich alle Aufgaben enthalten sein sollen.

### Prüfen, dass das Original unverändert bleibt

`Where` und `OrderBy` erzeugen Abfrageergebnisse. Sie entfernen keine Objekte aus `aufgaben` und ordnen diese Liste nicht um.

Die Ergebnislisten enthalten allerdings weiterhin Referenzen auf dieselben `TaskItem`-Objekte. Würdest du eine Property eines enthaltenen Objekts verändern, wäre diese Änderung auch über die ursprüngliche Liste sichtbar.

<a id="kapitel-13"></a>

## 13 · Razor und Blazor

Quelle: [Theorie der Lektion](../13_Razor-und-Blazor/THEORIE_UND_ANLEITUNG.md)

### Vom Konsolenprojekt zur Blazor-Web-App

Ein Blazor-Projekt enthält mehr Dateien als ein Konsolenprojekt:

- `Program.cs` konfiguriert und startet die Webanwendung.
- `Components/App.razor` bildet die äußere App-Struktur.
- `Components/Routes.razor` findet Seiten anhand ihrer Route.
- `Components/Pages/Home.razor` ist die Startseite.
- `Components/_Imports.razor` stellt gemeinsame Namespaces für Razor-Dateien bereit.
- `wwwroot` enthält öffentlich ausgelieferte Dateien wie CSS.

### Projekt starten

Öffne ein Terminal im Projektordner:

```powershell
dotnet run
```

Das Terminal zeigt anschließend eine lokale Adresse, zum Beispiel `https://localhost:7000`. Öffne die tatsächlich angezeigte Adresse im Browser.

Solange die App läuft, bleibt das Terminal belegt. Mit `Ctrl+C` beendest du sie.

### Eine Razor-Komponente

```razor
@page "/"

<PageTitle>Lerntracker</PageTitle>

<h1>@ueberschrift</h1>

@code {
    private string ueberschrift = "Mein Lerntracker";
}
```

Die Datei verbindet zwei Bereiche:

- Oberhalb von `@code` steht hauptsächlich HTML mit Razor-Ausdrücken.
- Im `@code`-Block stehen C#-Felder, Properties und Methoden der Komponente.

`@page "/"` macht die Komponente unter der Route `/` erreichbar. `PageTitle` setzt den Titel des Browser-Tabs.

### Eine `.razor`-Datei ist eine Komponentenklasse

Beim Build übersetzt Razor eine Datei wie `Home.razor` in C#-Code. Vereinfacht entsteht eine partielle Klasse `Home`, die von Blazors `ComponentBase` erbt.

Markup und `@code` gehören dadurch zu derselben Komponentenklasse. Deshalb kann das Markup auf ein `private`-Feld aus dem `@code`-Block zugreifen. `private` bedeutet: Nur diese Komponentenklasse selbst darf darauf zugreifen.

Eine normale HTML-Datei besitzt dagegen keinen C#-`@code`-Block und wird nicht zu einer Blazor-Komponentenklasse.

### Das Zeichen `@`

Razor verwendet `@`, um im Markup zu C# zu wechseln.

Ein einfacher Wert:

```razor
<p>Anzahl: @anzahl</p>
```

Ein zusammengesetzter Ausdruck:

```razor
<p>@(beschreibung ?? "Keine Beschreibung")</p>
```

Ein C#-Block:

```razor
@if (anzahl > 0)
{
    <p>Es sind Einträge vorhanden.</p>
}
```

Bei einem längeren Ausdruck sorgen `@(...)` dafür, dass Razor Anfang und Ende des C#-Ausdrucks eindeutig erkennt.

### Modelle in einem eigenen Ordner

`Models/AufgabenStatus.cs`:

```csharp
namespace Uebung13RazorBlazor.Models;

public enum AufgabenStatus
{
    Offen,
    InArbeit,
    Erledigt
}
```

`Models/TaskItem.cs`:

```csharp
namespace Uebung13RazorBlazor.Models;

public class TaskItem
{
    public string Titel { get; set; }
    public string? Beschreibung { get; set; }
    public AufgabenStatus Status { get; set; }

    public TaskItem(
        string titel,
        string? beschreibung,
        AufgabenStatus status)
    {
        Titel = titel;
        Beschreibung = beschreibung;
        Status = status;
    }
}
```

Der Namespace beginnt hier mit dem Projektnamen und endet mit dem Ordnernamen. Beide Dateien verwenden denselben Namespace, sodass `TaskItem` den Enum direkt kennt.

### Den Modell-Namespace importieren

`Home.razor` muss wissen, wo `TaskItem` und `AufgabenStatus` liegen. Dafür gibt es zwei sinnvolle Möglichkeiten.

Nur in `Home.razor`:

```razor
@using Uebung13RazorBlazor.Models
```

Oder gemeinsam für die Komponenten in `Components/_Imports.razor`:

```razor
@using Uebung13RazorBlazor.Models
```

`_Imports.razor` wird auf Razor-Dateien in seinem Ordner und den darunterliegenden Ordnern angewendet. Ein Import dort erspart die Wiederholung in jeder einzelnen Komponente.

`@using` erzeugt keine Objekte. Es macht nur die Typnamen aus dem Namespace verfügbar.

### Eine Aufgabenliste als Komponentenzustand

Die Liste kann als privates Feld im `@code`-Block angelegt werden:

```razor
@code {
    private List<TaskItem> aufgaben = new List<TaskItem>
    {
        new TaskItem(
            "Razor lesen",
            "C# und HTML verbinden",
            AufgabenStatus.InArbeit
        ),
        new TaskItem(
            "Markup schreiben",
            null,
            AufgabenStatus.Offen
        )
    };
}
```

Die geschweiften Klammern hinter `new List<TaskItem>` sind ein **Collection-Initializer**. Jeder aufgeführte Wert wird beim Erzeugen zur Liste hinzugefügt. Das ist eine kürzere Schreibweise für mehrere `Add`-Aufrufe.

Das Feld ist `private`, weil es nur von `Home` verwendet wird.

### Anzahl im Markup ausgeben

```razor
<p>Gesamtzahl: @aufgaben.Count</p>
```

`@aufgaben.Count` wird beim Rendern ausgewertet. Im erzeugten HTML steht anschließend die konkrete Zahl.

### Liste mit `@foreach` darstellen

```razor
<ul>
    @foreach (TaskItem aufgabe in aufgaben)
    {
        <li>
            <section>
                <h2>@aufgabe.Titel</h2>
                <p>
                    @(aufgabe.Beschreibung ?? "Keine Beschreibung")
                </p>
                <p>Status: @aufgabe.Status</p>
            </section>
        </li>
    }
</ul>
```

Razor führt die Schleife serverseitig aus und erzeugt für jedes Objekt das Markup im Block.

`aufgabe` wird im Kopf der Schleife als lokale Variable deklariert:

- Im ersten Durchlauf verweist sie auf das erste Listenelement.
- Im zweiten Durchlauf verweist sie auf das zweite Listenelement.
- Sie existiert nur innerhalb der geschweiften Klammern der Schleife.

Du musst vorher keine Variable namens `aufgabe` anlegen.

### C#-Ausdruck und HTML-Struktur

Razor entscheidet anhand des Kontexts, was HTML und was C# ist:

```razor
@foreach (TaskItem aufgabe in aufgaben)
{
    <h2>@aufgabe.Titel</h2>
}
```

- `@foreach (...) { ... }` ist C#-Steuerung.
- `<h2>...</h2>` ist HTML.
- `@aufgabe.Titel` setzt einen C#-Wert in das HTML ein.

Verwende HTML-Elemente nach ihrer Bedeutung:

- `h1` für die Hauptüberschrift,
- `h2` für einzelne Aufgabentitel,
- `p` für Beschreibung und Status,
- `ul` für eine ungeordnete Liste,
- `li` für jedes Listenelement,
- `section` für einen zusammengehörenden Inhaltsbereich.

### Statisches und interaktives Rendern

Ohne einen interaktiven Rendermodus wird die Komponente serverseitig zu HTML gerendert. Für Klicks, Eingaben und dauerhaft verbundene Ereignisbehandlung benötigt die Komponente einen interaktiven Rendermodus.

<a id="kapitel-14"></a>

## 14 · Blazor-Interaktionen

Quelle: [Theorie der Lektion](../14_Blazor-Interaktionen/THEORIE_UND_ANLEITUNG.md)

### Warum ein interaktiver Rendermodus nötig ist

Statisches Razor erzeugt HTML, verarbeitet danach aber keine Blazor-Klicks oder Bindings. Ergänze in `Home.razor`:

```razor
@rendermode InteractiveServer
```

Bei `InteractiveServer`:

- läuft der C#-Komponentencode auf dem Server,
- hält Blazor eine Verbindung zum Browser,
- werden Browserereignisse an die Komponente übermittelt,
- sendet Blazor nur die nötigen Änderungen der Oberfläche zurück.

Der Browser muss dafür nicht selbst C# ausführen können.

Die Direktive aktiviert den interaktiven Servermodus für diese Seite und ihre untergeordneten Komponenten.

### Komponentenzustand

Felder im `@code`-Block speichern den aktuellen Zustand:

```razor
@code {
    private string neuerTitel = "";
    private string? neueBeschreibung;
    private AufgabenStatus neuerStatus = AufgabenStatus.Offen;
    private string? fehlermeldung;

    private List<TaskItem> aufgaben = new List<TaskItem>();
}
```

Diese Felder haben unterschiedliche Aufgaben:

- Die ersten drei speichern die momentanen Formulareingaben.
- `fehlermeldung` steuert, ob eine Meldung angezeigt wird.
- `aufgaben` enthält die dauerhaft erfassten Aufgaben dieser Komponente.

Die Daten liegen zunächst nur im Arbeitsspeicher. Ein Neustart der App löscht sie.

### Texteingaben mit `@bind`

```razor
<label for="titel">Titel</label>
<input id="titel" @bind="neuerTitel" />

<label for="beschreibung">Beschreibung</label>
<textarea id="beschreibung"
          @bind="neueBeschreibung"></textarea>
```

`@bind` verbindet zwei Richtungen:

1. Der aktuelle C#-Wert wird im Eingabefeld angezeigt.
2. Eine Änderung im Eingabefeld wird in das C#-Feld übernommen.


Soll der Wert bei jedem Tastendruck aktualisiert werden, kann `@bind:event="oninput"` verwendet werden.

### Einen Enum mit `select` binden

```razor
<label for="status">Status</label>
<select id="status" @bind="neuerStatus">
    <option value="@AufgabenStatus.Offen">Offen</option>
    <option value="@AufgabenStatus.InArbeit">In Arbeit</option>
    <option value="@AufgabenStatus.Erledigt">Erledigt</option>
</select>
```

Das gebundene C#-Feld besitzt den Typ `AufgabenStatus`. Blazor wandelt die gewählte Option in den passenden Enum-Wert um.

Alle Werte, die in den Optionen vorkommen, müssen gültige Werte desselben Enums sein.

### Das Formular absenden

```razor
<form @onsubmit="AufgabeHinzufuegen"
      @onsubmit:preventDefault>
    <!-- Eingabefelder -->

    <button type="submit">Aufgabe hinzufügen</button>
</form>
```

- `@onsubmit` verbindet das Absenden mit der C#-Methode `AufgabeHinzufuegen`.
- `@onsubmit:preventDefault` verhindert das normale HTML-Verhalten, bei dem die Seite neu geladen würde.
- `type="submit"` löst das Submit-Ereignis des Formulars aus.

Ein zusätzlicher `@onclick` am Submit-Button ist nicht nötig. Sonst könnte dieselbe Aktion doppelt oder über zwei konkurrierende Wege ausgelöst werden.

### Eingaben in der Eventmethode validieren

```csharp
private void AufgabeHinzufuegen()
{
    if (string.IsNullOrWhiteSpace(neuerTitel))
    {
        fehlermeldung = "Der Titel darf nicht leer sein.";
        return;
    }

    // Erst nach dieser Prüfung ist der Titel gültig.
}
```

`return` beendet die Methode bei ungültiger Eingabe sofort. Dadurch wird kein Objekt angelegt und nichts zur Liste hinzugefügt.

Bei einer gültigen Eingabe sollte eine möglicherweise alte Fehlermeldung wieder entfernt werden:

```csharp
fehlermeldung = null;
```

### Fehlermeldung bedingt darstellen

```razor
@if (fehlermeldung is not null)
{
    <p class="fehler">@fehlermeldung</p>
}
```

Ist `fehlermeldung` gleich `null`, erzeugt Razor diesen Absatz nicht. Wird in der Eventmethode Text zugewiesen, rendert Blazor die Komponente erneut und der Absatz erscheint.

`is not null` ist hier eine Null-Prüfung. Alternativ wäre `fehlermeldung != null` möglich.

### Ein neues Objekt aus den Formularwerten erzeugen

Eine leere optionale Beschreibung kann vor dem Erzeugen in `null` umgewandelt werden:

```csharp
string? beschreibung = neueBeschreibung;

if (string.IsNullOrWhiteSpace(beschreibung))
{
    beschreibung = null;
}
```

Danach werden die gültigen Zustandswerte an den Konstruktor übergeben und das neue Objekt wird gespeichert:

```csharp
TaskItem neueAufgabe = new TaskItem(
    neuerTitel,
    beschreibung,
    neuerStatus
);

aufgaben.Add(neueAufgabe);
```

Falls dein eigener `TaskItem`-Konstruktor andere Parameter besitzt, erzeugst du das Objekt entsprechend diesem Konstruktor und weist den Status anschließend über die Property zu.

### Formular nach erfolgreichem Hinzufügen zurücksetzen

```csharp
neuerTitel = "";
neueBeschreibung = null;
neuerStatus = AufgabenStatus.Offen;
fehlermeldung = null;
```

Weil die Eingabefelder gebunden sind, erscheinen nach dem erneuten Rendern auch im Browser die zurückgesetzten Werte.

Setze die Felder nur nach erfolgreichem Hinzufügen zurück. Bei einem ungültigen Titel soll der Benutzer seine übrigen Eingaben nicht verlieren.

### Dynamische Liste darstellen

```razor
<p>Gesamtzahl: @aufgaben.Count</p>

@foreach (TaskItem aufgabe in aufgaben)
{
    <section>
        <h2>@aufgabe.Titel</h2>
        <p>@(aufgabe.Beschreibung ?? "Keine Beschreibung")</p>
        <p>Status: @aufgabe.Status</p>
    </section>
}
```

Nach `aufgaben.Add(...)` rendert Blazor die Komponente erneut. Deshalb aktualisieren sich die Anzahl und die Liste ohne manuelles Neuladen.

### Button nur bei nicht erledigten Aufgaben anzeigen

```razor
@if (aufgabe.Status != AufgabenStatus.Erledigt)
{
    <button type="button"
            @onclick="() => AufgabeErledigen(aufgabe)">
        Erledigt
    </button>
}
```

Die `if`-Bedingung wird für jedes aktuelle Listenelement ausgewertet. Bei bereits erledigten Aufgaben wird der Button gar nicht erzeugt.

`type="button"` verhindert, dass der Button versehentlich ein umgebendes Formular absendet.

### Das aktuelle Listenelement an die Methode übergeben

```razor
@onclick="() => AufgabeErledigen(aufgabe)"
```

Der Lambda-Ausdruck bedeutet: „Wenn geklickt wird, rufe die Methode auf und übergib die aktuelle Aufgabe.“

Ohne Lambda würde ein Aufruf mit Argument nicht als auf den Klick wartende Aktion beschrieben. Der Lambda-Ausdruck hält für jede dargestellte Karte die jeweils passende Objektvariable fest.

Die zugehörige Methode verändert den Status dieses Objekts:

```csharp
private void AufgabeErledigen(TaskItem aufgabe)
{
    aufgabe.Status = AufgabenStatus.Erledigt;
}
```

`TaskItem` ist eine Klasse. Der Parameter verweist daher auf dasselbe Objekt, das in der Liste liegt. Die Änderung ist sofort über die Liste sichtbar.

### Automatisches erneutes Rendern

Nach einem von Blazor behandelten Ereignis läuft vereinfacht Folgendes ab:

```text
Browserereignis
    → C#-Eventmethode
    → Zustand wird verändert
    → Blazor rendert die Komponente erneut
    → Browser erhält die notwendigen Änderungen
```

Für normale synchrone `@onclick`- und `@onsubmit`-Methoden musst du `StateHasChanged()` nicht selbst aufrufen.

<a id="kapitel-15"></a>

## 15 · Komponenten und Datenfluss

Quelle: [Theorie der Lektion](../15_Blazor-Komponenten/03_LernaufgabenTracker/THEORIE_UND_ANLEITUNG.md)

### Jede Razor-Datei ist eine eigene Komponentenklasse

Diese Dateien werden zu drei getrennten Klassen:

```text
Components/Pages/Home.razor
Components/AufgabenFormular.razor
Components/AufgabenKarte.razor
```

Private Felder gehören immer nur zu ihrer eigenen Komponente:

- `Home` kann nicht direkt auf ein privates Feld des Formulars zugreifen.
- Die Karte kann nicht direkt auf die private Liste von `Home` zugreifen.
- Das Formular kann nicht direkt die Methode der Karte aufrufen.

Benötigte Daten und Aktionen müssen deshalb ausdrücklich über die Komponentenschnittstellen verbunden werden.

### Eine einzige Quelle für dauerhafte Daten

Die Aufgabenliste bleibt in `Home`:

```csharp
private List<TaskItem> aufgaben = new List<TaskItem>
{
    // vorhandene Startaufgaben
};
```

`Home` ist damit der Zustandsbesitzer beziehungsweise die einzige Quelle der Wahrheit.

Würden `Home`, Formular und Karte jeweils eigene Aufgabenlisten führen, könnten diese Listen unterschiedliche Inhalte besitzen.

Die Grundregel lautet:

```text
Daten werden vom Besitzer nach unten gegeben.
Benutzeraktionen werden dem Besitzer nach oben gemeldet.
Nur der Besitzer verändert den dauerhaften Zustand.
```

### Daten nach unten: Komponentenparameter

Eine Kindkomponente erhält Daten über eine öffentliche Property mit `[Parameter]`:

```csharp
[Parameter]
public TaskItem Aufgabe { get; set; } = default!;
```

Die Elternkomponente setzt diesen Parameter im Komponenten-Tag:

```razor
<AufgabenKarte Aufgabe="@aufgabe" />
```

Der Parameter ist die Eingabe der Kindkomponente. Die Karte soll das Objekt anzeigen, aber den dauerhaften Status nicht eigenständig verändern.

### Was bedeutet `default!`?

Blazor erzeugt zuerst die Komponenteninstanz und setzt ihre Parameter anschließend. Der Compiler sieht bei der Objekterzeugung deshalb zunächst keinen Wert für die nicht nullable Property.

- `default` ist bei einem Klassentyp zunächst `null`.
- `!` unterdrückt hier die Nullable-Warnung.
- Dadurch wird kein `TaskItem` erzeugt.
- Der Elternteil muss `Aufgabe` tatsächlich übergeben.

Fehlt der Parameter im Komponenten-Tag, kann die Karte später auf `null` zugreifen. `default!` ist keine Laufzeitprüfung.

### Ereignis mit Daten nach oben

Die Karte muss beim Klick mitteilen, welche Aufgabe gemeint ist:

```csharp
[Parameter]
public EventCallback<TaskItem> OnErledigt { get; set; }
```

`TaskItem` ist der Typ des Werts, der nach oben gesendet wird.

```csharp
private async Task ErledigtMelden()
{
    await OnErledigt.InvokeAsync(Aufgabe);
}
```

Die Karte kennt nicht die konkrete Methode in `Home`. Sie kennt nur ihren Callback-Parameter. Der Elternteil verbindet diesen Parameter mit einer passenden Methode.

### Karte in Home verwenden

Das bisherige Karten-Markup in der Schleife wird durch den Komponenten-Tag ersetzt:

```razor
@foreach (TaskItem aufgabe in aufgaben)
{
    <AufgabenKarte
        Aufgabe="@aufgabe"
        OnErledigt="AufgabeErledigen" />
}
```

Die Elternmethode bleibt in `Home`:

```csharp
private void AufgabeErledigen(TaskItem aufgabe)
{
    aufgabe.Status = AufgabenStatus.Erledigt;
}
```

Der Ablauf:

```text
Home übergibt ein TaskItem an die Karte.
Die Karte zeigt dieses Objekt.
Die Karte meldet beim Klick dasselbe Objekt.
Home erhält es als Methodenparameter.
Home verändert dessen Status.
Blazor rendert die Karte mit dem neuen Status erneut.
```

### Drei ähnlich benannte Werte unterscheiden

| Name | Bedeutung | Gültigkeitsbereich |
|---|---|---|
| `aufgaben` | vollständige `List<TaskItem>` | privates Feld in `Home` |
| `aufgabe` | aktuelles Element der `foreach`-Schleife | nur im Schleifenblock |
| `Aufgabe` | Parameter-Property der Kartenkomponente | innerhalb der Karte |

Nur die Liste besitzt `Add`:

```csharp
aufgaben.Add(neueAufgabe);
```

Ein einzelnes `TaskItem` besitzt Properties wie `Titel` und `Status`, aber keine Listenmethode `Add`.

### Temporärer Zustand darf im Formular liegen

Die Formularfelder werden nur bis zum Absenden gebraucht:

- eingegebener Titel,
- eingegebene Beschreibung,
- ausgewählter Status,
- lokale Fehlermeldung.

Diese Werte dürfen von `Home` in `AufgabenFormular` verschoben werden. Die dauerhafte Aufgabenliste darf nicht mitwandern.

### Warum validiert das Formular selbst?

Das Formular besitzt die Eingabefelder und erzeugt das neue Objekt. Deshalb ist lokale Eingabevalidierung dort eine klare Verantwortung.

`Home` muss nicht wissen, wie der Titel eingegeben oder welche Fehlermeldung dargestellt wurde. `Home` erhält nur ein bereits gültiges `TaskItem`.

### Vollständiger Datenfluss

Beim Hinzufügen:

```text
Benutzer füllt AufgabenFormular aus
    → Formular validiert
    → Formular erzeugt TaskItem
    → OnAufgabeErstellt sendet TaskItem
    → Home empfängt TaskItem
    → Home fügt es zu aufgaben hinzu
    → Home rendert eine weitere AufgabenKarte
```

Beim Erledigen:

```text
Benutzer klickt in AufgabenKarte
    → Karte sendet ihr TaskItem über OnErledigt
    → Home empfängt das vorhandene Objekt
    → Home setzt Status auf Erledigt
    → Karte wird ohne Erledigt-Button neu gerendert
```

Formular und Karte sind Geschwisterkomponenten. Sie kommunizieren nicht direkt miteinander, sondern über `Home`.

### Interaktivität wird vererbt

`Home.razor` besitzt bereits:

```razor
@rendermode InteractiveServer
```

Die darin gerenderten Kindkomponenten gehören zum selben interaktiven Komponentenbaum. Die Direktive muss nicht in den Kindkomponenten wiederholt werden.

Nach einem Blazor-Ereignis wird automatisch erneut gerendert. Für diese normalen Callbacks ist kein manueller Aufruf von `StateHasChanged()` nötig.

<a id="kapitel-16"></a>

## 15 · Komponenten zwischen Geschwistern

Quelle: [Theorie der Lektion](../15_Blazor-Komponenten/01_Farbwahl/THEORIE_UND_ANLEITUNG.md)

### Komponenten sind getrennte Klassen

Jede `.razor`-Datei wird zu einer eigenen Komponentenklasse. Ein privates Feld in `Home.razor` ist in einer anderen `.razor`-Datei nicht direkt sichtbar. Du erzeugst eine Razor-Komponente normalerweise nicht mit `new`, sondern setzt sie als Tag in das Markup. Blazor erstellt ihre Instanz.

```razor
<NotizEingabe />
<NotizAnzeige />
```

Diese beiden Komponenten sind Geschwister. Sie greifen nicht auf die privaten Felder der jeweils anderen zu. Ein gemeinsamer Elternteil kann ihre Daten und Ereignisse verbinden.

### Zwei Richtungen, zwei Arten von Parametern

**Daten nach unten:** Ein Kind deklariert eine öffentliche Property mit `[Parameter]`. Der Elternteil setzt sie im Komponenten-Tag.

```razor
<p>Gespeicherte Notiz: @Text</p>

@code {
    [Parameter]
    public string Text { get; set; } = string.Empty;
}
```

Im Eltern-Markup könnte stehen:

```razor
<NotizAnzeige Text="@gespeicherteNotiz" />
```

Links vom `=` steht **der Propertyname des Kindes** (`Text`). Rechts steht **das Feld des Elternteils** (`gespeicherteNotiz`). Die Namen müssen nicht identisch sein; der Typ muss passen. `public` allein reicht nicht: Ohne `[Parameter]` ist die Property kein von außen setzbarer Komponentenparameter.

**Aktionen nach oben:** Auch ein `EventCallback<string>` ist eine `[Parameter]`-Property. Sie erhält eine Methode des Elternteils. Das Kind löst diese Methode später mit einem Wert aus.

```razor
<input @bind="eingabe" aria-label="Notiz" />
<button type="button" @onclick="NotizMelden">Speichern</button>

@code {
    private string eingabe = string.Empty;

    [Parameter]
    public EventCallback<string> OnNotizGesendet { get; set; }

    private Task NotizMelden()
    {
        return OnNotizGesendet.InvokeAsync(eingabe);
    }
}
```

`InvokeAsync(eingabe)` sendet **den string**, keine Referenz auf die Kindkomponente. Die verbundene Elternmethode muss deshalb einen `string` annehmen:

```razor
<NotizEingabe OnNotizGesendet="NotizSpeichern" />
<NotizAnzeige Text="@gespeicherteNotiz" />

@code {
    private string gespeicherteNotiz = "Noch keine Notiz";

    private void NotizSpeichern(string text)
    {
        gespeicherteNotiz = text;
    }
}
```

`OnNotizGesendet="NotizSpeichern"` übergibt die **Methode** als Callback. Es ruft sie beim Rendern nicht auf. Erst `InvokeAsync` im Kind löst sie aus. Nach dem Ereignis rendert Blazor den betroffenen Komponentenbaum erneut; die Anzeige erhält den neuen Elternwert. Ein manuelles `StateHasChanged()` ist dafür nicht nötig.

### Was gehört wem?

Die Eingabekomponente darf temporäre Eingaben besitzen. Der **dauerhaft gewählte** Wert gehört zum gemeinsamen Elternteil, wenn mehrere Kinder ihn brauchen. Das anzeigende Kind liest seinen Parameter und überschreibt ihn nicht selbst. Bei jedem Rendern könnte der Elternteil ohnehin seinen Wert erneut setzen.

Eine gleichnamige Property in zwei Kindkomponenten ist erlaubt: Es sind zwei verschiedene Klassen und Instanzen. Die Verbindung entsteht ausschließlich in den Komponenten-Tags des Elternteils.

<a id="kapitel-17"></a>

## 16 · Async/Await-Grundlagen

Quelle: [Theorie der Lektion](../16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/THEORIE_UND_ANLEITUNG.md)

### Warum asynchroner Code nötig ist

Manche Arbeit benötigt messbar Zeit:

- eine Datei lesen,
- einen Webserver anfragen,
- Daten aus einer Datenbank laden,
- Daten in LocalStorage schreiben,
- auf eine Netzwerkantwort warten.

Während dieser Wartezeit muss der ausführende Thread nicht aktiv rechnen. Asynchroner Code kann die Kontrolle vorübergehend zurückgeben, damit die Anwendung auf andere Arbeit reagieren kann.

Das bedeutet nicht automatisch:

- dass ein neuer Thread gestartet wird,
- dass alles gleichzeitig läuft,
- dass die Methode schneller fertig wird.

`async` verbessert vor allem den Umgang mit Wartezeit. Eine Datenbankabfrage braucht dadurch nicht weniger Zeit, aber die Anwendung muss währenddessen nicht unnötig blockieren.

### `Task` bedeutet ein laufender oder zukünftiger Abschluss

Eine normale `void`-Methode besitzt keinen Rückgabewert:

```csharp
static void NachrichtAusgeben()
{
    Console.WriteLine("Fertig");
}
```

Eine asynchrone Methode ohne fachlichen Rückgabewert gibt normalerweise `Task` zurück:

```csharp
static async Task FortschrittSpeichernAsync()
{
    await Task.Delay(500);
}
```

Der `Task` erlaubt dem Aufrufer zu beobachten:

- ob der Vorgang noch läuft,
- ob er erfolgreich beendet wurde,
- ob dabei eine Exception entstand.

### `Task<T>` liefert später einen Wert

Soll die Methode nach dem Warten einen Wert liefern, verwendet sie `Task<T>`:

```csharp
static async Task<int> PunktestandLadenAsync()
{
    await Task.Delay(500);
    return 12;
}
```

Der Aufrufer verwendet `await` und erhält danach direkt den inneren Wert:

```csharp
int punktestand = await PunktestandLadenAsync();
```

Ohne `await` wäre der Typ nicht `int`, sondern `Task<int>`:

```csharp
Task<int> vorgang = PunktestandLadenAsync();
```

Das kann absichtlich sinnvoll sein.

### Was `async` und `await` jeweils machen

`async` steht in der Methodendeklaration:

```csharp
static async Task MeineMethodeAsync()
```

Damit darf die Methode `await` verwenden und der Compiler baut den notwendigen Fortsetzungsablauf.

`await` steht vor einem Task:

```csharp
await Task.Delay(500);
```

Vereinfacht läuft Folgendes ab:

1. Die Methode startet normal.
2. Sie erreicht einen noch nicht abgeschlossenen Task.
3. Sie gibt die Kontrolle an ihren Aufrufer zurück.
4. Der wartende Vorgang wird später abgeschlossen.
5. Die Methode läuft hinter `await` weiter.
6. Ihr eigener Task wird schließlich abgeschlossen.

Du musst diesen Ablauf nicht manuell verwalten. Genau dafür existieren `async` und `await`.

### `Task.Delay` gegenüber `Thread.Sleep`


```csharp
await Task.Delay(800);
```

`Task.Delay` beschreibt asynchrones Warten. `Thread.Sleep(800)` blockiert dagegen den aktuellen Thread während der gesamten Zeit.

Für Blazor-Events und Serverzugriffe sollst du nicht mit `Thread.Sleep` warten.

Wichtig: `Task.Delay` speichert keine Daten. Es ist ausschließlich eine gut sichtbare Simulation, die in den Folgeübungen ersetzt wird.

### Asynchronität wandert zum Aufrufer

Wenn Methode A auf Methode B wartet, muss auch Methode A asynchron sein:

```csharp
static async Task MethodeAAsync()
{
    await MethodeBAsync();
}

static async Task MethodeBAsync()
{
    await Task.Delay(500);
}
```

Ruft eine weitere Methode `MethodeAAsync` auf und möchte deren Abschluss abwarten, wird auch diese Methode asynchron. Dieses Weiterreichen wird manchmal als „async all the way“ bezeichnet.

In einem Programm endet die Kette beispielsweise hier:

```csharp
await MethodeAAsync();
```

Top-Level-Code in `Program.cs` darf direkt `await` verwenden.

### Reihenfolge bleibt mit `await` lesbar

```csharp
string thema = await LernthemaLadenAsync();
await FortschrittSpeichernAsync(thema);
Console.WriteLine("Alles abgeschlossen.");
```

Die drei Schritte laufen nacheinander:

1. Thema laden.
2. Fortschritt speichern.
3. Abschluss ausgeben.

`async` bedeutet also nicht, dass diese Schritte automatisch parallel laufen.

### Mehrere unabhängige Vorgänge

Zwei Tasks können zunächst gestartet und später gemeinsam abgewartet werden:

```csharp
Task<string> themaTask = LernthemaLadenAsync();
Task<int> punkteTask = PunktestandLadenAsync();

await Task.WhenAll(themaTask, punkteTask);

string thema = await themaTask;
int punkte = await punkteTask;
```

Das ist nur sinnvoll, wenn die Vorgänge voneinander unabhängig sind. Wenn der zweite Vorgang das Ergebnis des ersten benötigt, müssen sie nacheinander ausgeführt werden.

### Exceptions nach `await`

Eine Exception aus einer asynchronen Methode erscheint beim `await`-Aufruf:

```csharp
try
{
    await PruefungAusfuehrenAsync();
    Console.WriteLine("Prüfung erfolgreich.");
}
catch (InvalidOperationException exception)
{
    Console.WriteLine($"Fehler: {exception.Message}");
}
finally
{
    Console.WriteLine("Prüfung beendet.");
}
```

Die Rollen sind dieselben wie bei synchronem Code:

- `try`: Vorgang versuchen,
- `catch`: erwartbaren Fehler behandeln,
- `finally`: immer aufräumen oder einen Status zurücksetzen.

`finally` ist in Blazor besonders nützlich, um einen Lade- oder Speicherzustand garantiert zu beenden.

### Warum `async void` fast immer falsch ist

Eine eigene asynchrone Methode soll normalerweise `Task` zurückgeben:

```csharp
static async Task SpeichernAsync()
```

Nicht:

```csharp
static async void SpeichernAsync()
```

Bei `async void` kann der Aufrufer nicht:

- mit `await` auf den Abschluss warten,
- erkennen, wann die Methode fertig ist,
- Exceptions über den zurückgegebenen Task behandeln.

Bestimmte klassische .NET-Eventhandler benötigen `async void`. Blazor-Eventmethoden dürfen und sollen dagegen `Task` zurückgeben.

### Warum `.Result` und `.Wait()` vermieden werden

Diese Varianten blockieren synchron:

```csharp
string thema = LernthemaLadenAsync().Result;
LernthemaLadenAsync().Wait();
```

Sie können Anwendungen blockieren oder zu Deadlocks beitragen. Verwende in diesem Kurs stattdessen:

```csharp
string thema = await LernthemaLadenAsync();
```

### Benennung

Asynchrone Methoden enden üblicherweise auf `Async`:

- `LernthemaLadenAsync`
- `AufgabenSpeichernAsync`
- `LadeAlleAsync`

Der Name erinnert den Aufrufer daran, dass die Methode einen Task liefert und gewöhnlich mit `await` aufgerufen wird.

<a id="kapitel-18"></a>

## 16 · Async/Await in Blazor

Quelle: [Theorie der Lektion](../16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/THEORIE_UND_ANLEITUNG.md)

### Asynchrone Lebenszyklusmethode

Blazor ruft `OnInitializedAsync` beim Initialisieren einer Komponente auf:

```csharp
protected override async Task OnInitializedAsync()
{
    aufgaben = await StartaufgabenLadenAsync();
}
```

Diese Lebenszyklusmethode ist für serverseitig erreichbare Daten geeignet, beispielsweise später für MariaDB.

LocalStorage ist eine Besonderheit: Es befindet sich im Browser und steht beim serverseitigen Prerendering noch nicht zur Verfügung. Deshalb verwendet die spätere LocalStorage-Übung stattdessen `OnAfterRenderAsync`.

### Ladezustand abbilden

Ein boolesches Feld beschreibt den Zustand:

```csharp
private bool ladevorgangLaeuft = true;
```

Das Markup reagiert darauf:

```razor
@if (ladevorgangLaeuft)
{
    <p role="status">Aufgaben werden geladen ...</p>
}
else
{
    <!-- Formular, Anzahl und Karten -->
}
```

Das Feld ist nicht nur Dekoration. Solange die Daten noch nicht geladen sind, soll der Benutzer keine Änderungen an einer unvollständigen Liste auslösen.

### `try`, `catch` und `finally` beim Laden

```csharp
private string? ladefehler;

protected override async Task OnInitializedAsync()
{
    try
    {
        aufgaben = await StartaufgabenLadenAsync();
    }
    catch (Exception)
    {
        ladefehler = "Die Aufgaben konnten nicht geladen werden.";
    }
    finally
    {
        ladevorgangLaeuft = false;
    }
}
```

Warum `finally`?

- Bei Erfolg muss die Ladeanzeige verschwinden.
- Bei Fehler muss die Ladeanzeige ebenfalls verschwinden.
- Ohne `finally` könnte ein vergessener Zweig die Oberfläche dauerhaft im Ladezustand lassen.

Die technische Exception wird hier nicht direkt an Benutzer ausgegeben. Interne Informationen, Servernamen oder SQL-Texte gehören nicht in eine öffentliche Fehlermeldung.

### Ladefehler anzeigen

Nach dem Ladezustand wird unterschieden:

```razor
@if (ladevorgangLaeuft)
{
    <p role="status">Aufgaben werden geladen ...</p>
}
else if (ladefehler is not null)
{
    <p role="alert">@ladefehler</p>
}
else
{
    <!-- normale Oberfläche -->
}
```

Bei einem Ladefehler wird nicht so getan, als wäre eine leere Aufgabenliste erfolgreich geladen worden.

### Zustandsänderung erst nach erfolgreichem Await

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    await AenderungSpeichernAsync();
    aufgaben.Add(neueAufgabe);
}
```

Die Reihenfolge ist wichtig:

```text
erst speichern
→ danach sichtbaren Zustand verändern
```

Wenn du das Objekt zuerst zur Liste hinzufügst und der echte Speicher später fehlschlägt, zeigt die Oberfläche einen Zustand, der nie dauerhaft gespeichert wurde.

Dasselbe gilt für den Status:

```csharp
private async Task AufgabeErledigen(TaskItem aufgabe)
{
    await AenderungSpeichernAsync();
    aufgabe.Status = AufgabenStatus.Erledigt;
}
```

### Speicherzustand gegen Doppelklicks

```csharp
private bool speichervorgangLaeuft;
```

Prüfe am Anfang jeder speichernden Methode zusätzlich, ob bereits ein Vorgang läuft:

```csharp
if (speichervorgangLaeuft)
{
    throw new InvalidOperationException(
        "Eine Änderung wird bereits gespeichert."
    );
}
```

Das ist der Schutz in der Logik. Die Exception wird wie die anderen erwarteten Speicherfehler in der auslösenden Kindkomponente angezeigt. Die deaktivierten Buttons sind zusätzlich sichtbares Feedback für den Benutzer.

Die Elternmethode setzt ihn mit `try` und `finally`:

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    speichervorgangLaeuft = true;

    try
    {
        await AenderungSpeichernAsync();
        aufgaben.Add(neueAufgabe);
    }
    finally
    {
        speichervorgangLaeuft = false;
    }
}
```

Ohne Sperre kann ein schneller Doppelklick denselben Vorgang mehrfach starten.

### Zustand an Kindkomponenten weitergeben

Das Formular benötigt einen Parameter:

```csharp
[Parameter]
public bool Deaktiviert { get; set; }
```

Verwende ihn an den Eingaben und am Button:

```razor
<input @bind="titel" disabled="@Deaktiviert" />
<textarea @bind="beschreibung"
          disabled="@Deaktiviert"></textarea>
<select @bind="status" disabled="@Deaktiviert">
    ...
</select>
<button type="submit" disabled="@Deaktiviert">
    Aufgabe hinzufügen
</button>
```

Auch die Karte bekommt denselben Parameter und deaktiviert ihren Erledigt-Button.

`Home` reicht das Feld nach unten:

```razor
<AufgabenFormular
    Deaktiviert="@speichervorgangLaeuft"
    OnAufgabeErstellt="AufgabeHinzufuegen" />
```

```razor
<AufgabenKarte
    Aufgabe="@aufgabe"
    Deaktiviert="@speichervorgangLaeuft"
    OnErledigt="AufgabeErledigen" />
```

### Warum Home-Eventmethoden `Task` zurückgeben

Der Callback wartet auf die verbundene Elternmethode. Deshalb darf diese Methode `Task` zurückgeben:

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
```

Der Ablauf bleibt verbunden:

```text
AufgabenFormular.Absenden
→ await EventCallback.InvokeAsync
→ Home.AufgabeHinzufuegen
→ await Speichervorgang
→ Home-Methode endet
→ InvokeAsync endet
→ Formular setzt Eingaben zurück
```

Das Formular setzt seine Eingaben deshalb erst hinter dem `await` zurück. Es wartet tatsächlich auf die Elternkomponente.

### Fehler über den Callback melden

Eine echte Speicheroperation kann scheitern. `Home` kennt die technische Operation und übersetzt sie in eine verständliche Exception:

```csharp
try
{
    await AenderungSpeichernAsync();
    aufgaben.Add(neueAufgabe);
}
catch (Exception exception)
{
    throw new InvalidOperationException(
        "Die Aufgabe konnte nicht gespeichert werden.",
        exception
    );
}
finally
{
    speichervorgangLaeuft = false;
}
```

Das Formular behandelt diese erwartete Anwendungsfehlermeldung:

```csharp
try
{
    await OnAufgabeErstellt.InvokeAsync(neueAufgabe);

    titel = string.Empty;
    beschreibung = null;
    status = AufgabenStatus.Offen;
    fehlermeldung = null;
}
catch (InvalidOperationException exception)
{
    fehlermeldung = exception.Message;
}
```

Die Eingaben werden nur im erfolgreichen `try`-Zweig geleert. Bei einem Fehler kann der Benutzer sie erneut absenden.

Die Karte verwendet denselben Grundgedanken für den Erledigt-Klick und besitzt dafür eine eigene lokale Fehlermeldung.

### Muss `StateHasChanged` aufgerufen werden?

Bei einem normalen Blazor-Eventcallback rendert Blazor vor und nach dem asynchronen Eventablauf passend neu. Ein manueller Aufruf ist dafür nicht nötig.

Wird innerhalb von `OnAfterRenderAsync` geladen, ist ein manueller Aufruf nötig, weil Blazor nach dem asynchronen Abschluss dieser speziellen Lebenszyklusmethode nicht automatisch erneut rendert.

<a id="kapitel-19"></a>

## 16 · Docker, MariaDB und DBeaver

Quelle: [Theorie der Lektion](../16_Persistenz-und-Datenbanken/02_MariaDB-Docker-und-DBeaver/ANLEITUNG.md)

### Begriffe

| Begriff | Bedeutung |
|---|---|
| Image | unveränderliche Vorlage für einen Container |
| Container | laufende Instanz eines Images |
| Volume | dauerhafter Speicher außerhalb des Containers |
| Port | Verbindung zwischen deinem Rechner und dem Container |
| DBeaver | grafische Oberfläche zum Verwalten der Datenbank |
| MariaDB | relationales Datenbanksystem |

Das Volume ist wichtig: Ein Container kann ersetzt werden, ohne dass die Datenbankdateien verloren gehen.

### Voraussetzungen prüfen

Docker Desktop muss gestartet sein. Prüfe im Terminal:

```powershell
docker --version
docker compose version
```

Beide Befehle müssen eine Versionsnummer ausgeben.

Installiere außerdem DBeaver Community, falls es noch nicht vorhanden ist.

### Inhalt von `.env`

Verwende für die lokale Entwicklung ein eigenes starkes Passwort:

```dotenv
MARIADB_ROOT_PASSWORD=hier-ein-lokales-passwort-einsetzen
MARIADB_HOST_PORT=3306
```

Übernimm das Beispielpasswort nicht wörtlich. `3306` ist nur ein Beispiel für den Host-Port. Prüfe, ob er auf deinem Rechner frei ist, und ändere `MARIADB_HOST_PORT` bei Bedarf. Notiere den gewählten Wert; du brauchst ihn später für DBeaver und die Blazor-Projekte.

### Inhalt von `compose.yaml`

```yaml
services:
  mariadb:
    image: mariadb:11.4
    container_name: lerntracker-mariadb
    restart: unless-stopped
    environment:
      MARIADB_ROOT_PASSWORD: ${MARIADB_ROOT_PASSWORD}
    ports:
      - "127.0.0.1:${MARIADB_HOST_PORT}:3306"
    volumes:
      - lerntracker_mariadb_data:/var/lib/mysql
    healthcheck:
      test:
        - CMD
        - healthcheck.sh
        - --connect
        - --innodb_initialized
      interval: 10s
      timeout: 5s
      retries: 10

volumes:
  lerntracker_mariadb_data:
```

Der explizite Tag `11.4` hält die Hauptversion reproduzierbar. Die Variablen `MARIADB_*` und `healthcheck.sh` gehören zum offiziellen MariaDB-Image.

Die Portfreigabe gilt nur auf deinem Rechner. Links steht der selbst gewählte Host-Port aus `.env`, rechts der interne MariaDB-Port `3306`. `docker compose ps` zeigt nach dem Start die tatsächliche Zuordnung.

### Konfiguration prüfen

Öffne ein Terminal im Infrastrukturordner:

```powershell
docker compose config
```

Dieser Befehl prüft die YAML-Struktur und setzt die Werte aus `.env` ein. Teile die Ausgabe nicht öffentlich, weil darin das aufgelöste Passwort erscheinen kann.

### Container starten

```powershell
docker compose up -d
```

Status prüfen:

```powershell
docker compose ps
```

Der Container wechselt nach der Initialisierung zu `healthy`. Beim ersten Start kann das etwas dauern.

Logs anzeigen:

```powershell
docker compose logs -f mariadb
```

Mit `Ctrl+C` beendest du nur die Loganzeige, nicht den Container.

### MariaDB im Container testen

```powershell
docker exec -it lerntracker-mariadb mariadb -u root -p
```

Gib das Root-Passwort aus `.env` ein. Das Passwort wird während der Eingabe nicht angezeigt.

Im MariaDB-Terminal:

```sql
SELECT VERSION();
SHOW DATABASES;
EXIT;
```

### DBeaver verbinden

1. Öffne DBeaver.
2. Wähle **Neue Datenbankverbindung**.
3. Wähle **MariaDB**.
4. Trage folgende Werte ein:

| Feld | Wert |
|---|---|
| Host | `localhost` |
| Port | gewählter Host-Port aus `.env` bzw. `docker compose ps` |
| Database | zunächst leer lassen |
| Benutzer | `root` |
| Passwort | Wert aus `.env` |

5. Klicke auf **Test Connection**.
6. Erlaube DBeaver bei Bedarf, den MariaDB-Treiber herunterzuladen.
7. Speichere die Verbindung.

Der Root-Zugang wird nur zum Einrichten verwendet. Die Blazor-App bekommt in Übung 04 einen eigenen eingeschränkten Benutzer.

### Container später bedienen

Stoppen, Daten behalten:

```powershell
docker compose stop
```

Wieder starten:

```powershell
docker compose start
```

Container entfernen, Volume behalten:

```powershell
docker compose down
```

Container und Daten endgültig entfernen:

```powershell
docker compose down -v
```

Achtung: `down -v` löscht das Datenvolume. Die Datenbank kann danach nicht aus diesem Volume wiederhergestellt werden.

### Häufige Probleme

#### Port 3306 ist bereits belegt

Möglicherweise läuft lokal bereits MySQL oder MariaDB. Prüfe Docker Desktop und installierte Windows-Dienste.

Wähle in `.env` einen freien Wert für `MARIADB_HOST_PORT` und starte mit `docker compose up -d` erneut. Übernimm genau diesen Host-Port in DBeaver und in den Connection String. Der interne Port `3306` bleibt unverändert.

#### Container bleibt ungesund

Prüfe:

```powershell
docker compose logs mariadb
```

Häufige Ursachen sind ein fehlendes Root-Passwort oder ein altes Volume mit einer früheren Konfiguration.

#### Geändertes Passwort funktioniert nicht

Initialisierungsvariablen wirken nur auf ein leeres Datenverzeichnis. Existiert das Volume bereits, bleibt das darin gespeicherte Passwort bestehen.

Wenn die Daten sicher gelöscht werden dürfen:

```powershell
docker compose down -v
docker compose up -d
```

#### DBeaver erreicht den Server nicht

Prüfe nacheinander:

1. Docker Desktop läuft.
2. `docker compose ps` zeigt den Container.
3. Der Container ist `healthy`.
4. Host und Port stimmen.
5. Eine lokale Firewall blockiert den Port nicht.

### Sicherheitsregeln für lokale Entwicklung

- Kein Passwort in C#-Quellcode schreiben.
- `.env` nicht in Git einchecken.
- Die App nicht mit dem Root-Benutzer verbinden.
- SQL-Eingaben später immer parametrisieren.
- Diese Konfiguration ist für lokale Entwicklung, nicht für einen öffentlichen Produktionsserver.

<a id="kapitel-20"></a>

## 16 · LocalStorage

Quelle: [Theorie der Lektion](../16_Persistenz-und-Datenbanken/03_LocalStorage/THEORIE_UND_ANLEITUNG.md)

### Was ist LocalStorage?

`localStorage` ist ein Schlüssel-Wert-Speicher des Browsers.

Eigenschaften:

- Daten bleiben nach einem Seitenneuladen erhalten.
- Daten bleiben nach dem Schließen und erneuten Öffnen des Browsers erhalten.
- Daten gehören zu einem bestimmten Browser und Ursprung.
- Andere Geräte oder Browser besitzen nicht automatisch dieselben Daten.
- Benutzer können die Daten in den Entwicklerwerkzeugen sehen und verändern.

LocalStorage ist für kleine, nicht sensible Übungsdaten geeignet. Passwörter, Zugangstoken oder vertrauliche Personendaten gehören nicht ungeschützt hinein.

### Schlüssel und Wert

LocalStorage speichert Text:

```text
Schlüssel: lerntracker.aufgaben
Wert:     [{"Titel":"...","Beschreibung":null,"Status":0}]
```

Eine `List<TaskItem>` ist kein Text. Sie muss deshalb vor dem Speichern serialisiert und nach dem Laden deserialisiert werden.

### JSON serialisieren

```csharp
using System.Text.Json;

string json = JsonSerializer.Serialize(aufgaben);
```

Serialisieren bedeutet: C#-Objekte werden in JSON-Text umgewandelt.

Deserialisieren:

```csharp
List<TaskItem>? geladeneAufgaben =
    JsonSerializer.Deserialize<List<TaskItem>>(json);
```

Das Ergebnis darf `null` sein, beispielsweise wenn der JSON-Inhalt nicht die erwartete Liste ergibt.

Der Enum wird mit den Standardeinstellungen als Zahl gespeichert:

- `Offen` → `0`
- `InArbeit` → `1`
- `Erledigt` → `2`

### JavaScript-Interop

LocalStorage ist eine Browser-API. Der C#-Code einer Interactive-Server-Komponente greift über JavaScript-Interop darauf zu.

Füge oben in `Home.razor` ein:

```razor
@using System.Text.Json
@inject IJSRuntime JS
```

Der benötigte Namespace für `IJSRuntime` ist im Projekt bereits über `_Imports.razor` verfügbar.

Ein konstanter Schlüssel verhindert Tippfehler:

```csharp
private const string StorageKey = "lerntracker.aufgaben";
```

### Speichern

```csharp
private async Task AufgabenSpeichernAsync()
{
    string json = JsonSerializer.Serialize(aufgaben);

    await JS.InvokeVoidAsync(
        "localStorage.setItem",
        StorageKey,
        json
    );
}
```

`localStorage.setItem` erwartet Schlüssel und Textwert. `InvokeVoidAsync` wird verwendet, weil die JavaScript-Funktion keinen benötigten Rückgabewert liefert.

### Laden

```csharp
string? json = await JS.InvokeAsync<string?>(
    "localStorage.getItem",
    StorageKey
);
```

`getItem` liefert:

- den gespeicherten JSON-Text, oder
- `null`, wenn unter diesem Schlüssel noch nichts gespeichert wurde.

Danach:

```csharp
if (!string.IsNullOrWhiteSpace(json))
{
    List<TaskItem>? geladeneAufgaben =
        JsonSerializer.Deserialize<List<TaskItem>>(json);

    if (geladeneAufgaben is not null)
    {
        aufgaben = geladeneAufgaben;
    }
}
```

### Warum nicht in `OnInitializedAsync` laden?

Interactive Server rendert eine Seite zunächst möglicherweise auf dem Server vor. Während dieses Prerenderings existiert noch keine aktive Browser-Verbindung für JavaScript-Interop.

LocalStorage steht erst zur Verfügung, wenn die Komponente interaktiv im Browser gerendert wurde.


```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (!firstRender)
    {
        return;
    }

    // LocalStorage laden
}
```

`firstRender` verhindert, dass nach jedem erneuten Rendern wieder geladen und der aktuelle Zustand überschrieben wird.

### Vollständiger Ladeablauf mit vorhandenen Statusfeldern

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (!firstRender)
    {
        return;
    }

    try
    {
        string? json = await JS.InvokeAsync<string?>(
            "localStorage.getItem",
            StorageKey
        );

        if (!string.IsNullOrWhiteSpace(json))
        {
            List<TaskItem>? geladeneAufgaben =
                JsonSerializer.Deserialize<List<TaskItem>>(json);

            if (geladeneAufgaben is null)
            {
                throw new JsonException(
                    "Die gespeicherte Liste ist ungültig."
                );
            }

            aufgaben = geladeneAufgaben;
        }
        else
        {
            aufgaben = StartaufgabenErstellen();
            await AufgabenSpeichernAsync();
        }
    }
    catch (Exception)
    {
        ladefehler =
            "Die gespeicherten Aufgaben konnten nicht geladen werden.";
    }
    finally
    {
        ladevorgangLaeuft = false;
        StateHasChanged();
    }
}
```

Wenn noch keine gespeicherten Daten existieren, werden hier die vorhandenen Startaufgaben erzeugt und erstmals gespeichert.

`StateHasChanged()` ist an dieser Stelle nötig: `OnAfterRenderAsync` löst nach seinem asynchronen Abschluss nicht automatisch ein weiteres Rendering aus.

### Ladezustand anzeigen


```razor
@if (ladevorgangLaeuft)
{
    <p role="status">Aufgaben werden geladen ...</p>
}
else if (ladefehler is not null)
{
    <p role="alert">@ladefehler</p>
}
else
{
    <!-- Formular, Anzahl und Karten -->
}
```

Dadurch sieht der Benutzer kurz einen Ladehinweis. Erst danach erscheinen Formular und Liste.

### Nach jeder Änderung speichern

Nur beim Start zu laden reicht nicht. Jede dauerhafte Zustandsänderung muss anschließend gespeichert werden. Die Home-Methoden sind bereits asynchron und sperren die Oberfläche. Ersetze darin den Aufruf von `AenderungSpeichernAsync`.

Neue Aufgabe:

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    aufgaben.Add(neueAufgabe);

    try
    {
        await AufgabenSpeichernAsync();
    }
    catch
    {
        aufgaben.Remove(neueAufgabe);
        throw;
    }
}
```

Das vorübergehende Hinzufügen ist nötig, weil `AufgabenSpeichernAsync` die aktuelle Liste serialisiert. Scheitert LocalStorage, wird die Änderung sofort zurückgenommen. Der bereits vorhandene äußere `catch`-Block übersetzt den Fehler anschließend in die verständliche Meldung für das Formular.

Status ändern:

```csharp
private async Task AufgabeErledigen(
    TaskItem aufgabe)
{
    AufgabenStatus vorherigerStatus = aufgabe.Status;
    aufgabe.Status = AufgabenStatus.Erledigt;

    try
    {
        await AufgabenSpeichernAsync();
    }
    catch
    {
        aufgabe.Status = vorherigerStatus;
        throw;
    }
}
```


Wichtig ist die Reihenfolge:

```text
Zustand verändern
→ neuen Zustand serialisieren
→ JSON in LocalStorage speichern
→ bei einem Fehler die Änderung zurücknehmen
```

### Daten löschen

Optional kannst du einen Reset-Button ergänzen:

```csharp
private async Task SpeicherLeeren()
{
    await JS.InvokeVoidAsync(
        "localStorage.removeItem",
        StorageKey
    );

    aufgaben.Clear();
}
```

Entscheide bewusst, ob danach eine leere Liste oder wieder Startdaten erscheinen sollen.

### Grenzen von LocalStorage

- Die Daten gelten nur für diesen Browser und diese Adresse.
- Browserdaten können gelöscht werden.
- Mehrere Benutzerkonten werden nicht automatisch getrennt.
- Änderungen in mehreren Tabs können sich überschreiben.
- Die Daten sind sichtbar und manipulierbar.
- Bei Interactive Server wird der JSON-Text über die Verbindung zwischen Browser und Server übertragen.

Für eine echte gemeinsame To-do-Anwendung ist eine serverseitige Datenbank geeigneter.

<a id="kapitel-21"></a>

## 16 · Dapper und MariaDB

Quelle: [Theorie der Lektion](../16_Persistenz-und-Datenbanken/04_MariaDB-und-Dapper/THEORIE_UND_ANLEITUNG.md)

### Architektur

```text
Razor-Komponenten
    ↓
TaskItemRepository
    ↓
Dapper
    ↓
MySqlConnector
    ↓
MariaDB im Docker-Container
```

Die Aufgaben der Schichten:

| Schicht | Verantwortung |
|---|---|
| Komponenten | Oberfläche und Benutzerereignisse |
| Repository | SQL-Anweisungen und Datenzugriff |
| Dapper | Parameter übergeben und Zeilen auf Objekte abbilden |
| MySqlConnector | technische Verbindung zu MariaDB |
| MariaDB | dauerhafte Speicherung |

Dapper ersetzt nicht den Datenbanktreiber. Deshalb werden Dapper und MySqlConnector benötigt.

### Datenbank, Benutzer und Tabelle erstellen

```sql
CREATE DATABASE IF NOT EXISTS lerntracker
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

CREATE USER IF NOT EXISTS 'lernapp'@'%'
    IDENTIFIED BY 'lokales-app-passwort';

ALTER USER 'lernapp'@'%'
    IDENTIFIED BY 'lokales-app-passwort';

GRANT SELECT, INSERT, UPDATE, DELETE
    ON lerntracker.*
    TO 'lernapp'@'%';

FLUSH PRIVILEGES;

USE lerntracker;

CREATE TABLE IF NOT EXISTS Aufgaben
(
    Id INT NOT NULL AUTO_INCREMENT,
    Titel VARCHAR(200) NOT NULL,
    Beschreibung TEXT NULL,
    Status TINYINT UNSIGNED NOT NULL DEFAULT 0,

    CONSTRAINT PK_Aufgaben PRIMARY KEY (Id),
    CONSTRAINT CK_Aufgaben_Status
        CHECK (Status IN (0, 1, 2))
);
```

Die Statuswerte entsprechen dem C#-Enum:

| Datenbank | C# |
|---:|---|
| `0` | `Offen` |
| `1` | `InArbeit` |
| `2` | `Erledigt` |

### Schema prüfen

```sql
USE lerntracker;

DESCRIBE Aufgaben;

SELECT
    Id,
    Titel,
    Beschreibung,
    Status
FROM Aufgaben;
```

Erstelle anschließend in DBeaver eine zweite Verbindung mit dem App-Benutzer:

| Feld | Wert |
|---|---|
| Host | `localhost` |
| Port | gewählter Host-Port aus `docker compose ps` |
| Database | `lerntracker` |
| Benutzer | `lernapp` |
| Passwort | dein lokales App-Passwort |

Die Blazor-App verwendet später ausschließlich diesen Benutzer, nicht `root`.

### Benötigte NuGet-Pakete

Im Projektordner:

```powershell
dotnet add package Dapper
dotnet add package MySqlConnector
```

Dapper erweitert Datenbankverbindungen unter anderem um:

- `QueryAsync<T>` für mehrere Ergebniszeilen,
- `ExecuteAsync` für INSERT und UPDATE,
- `ExecuteScalarAsync<T>` für einen einzelnen Rückgabewert.

MySqlConnector stellt `MySqlConnection` für MariaDB und MySQL bereit.

### Connection String sicher speichern

Ein Connection String enthält Server, Datenbank, Benutzer und Passwort.

Er darf nicht direkt in C# und nicht mit echtem Passwort in eine eingecheckte `appsettings.json` geschrieben werden.

Aktiviere .NET User Secrets:

```powershell
dotnet user-secrets init
```

Setze anschließend den Connection String. Ersetze das Passwort:

```powershell
dotnet user-secrets set "ConnectionStrings:MariaDb" "Server=localhost;Port=DEIN_HOST_PORT;Database=lerntracker;User ID=lernapp;Password=DEIN_PASSWORT"
```

Ersetze `DEIN_HOST_PORT` durch den auf deinem Rechner veröffentlichten Port aus `docker compose ps` und `DEIN_PASSWORT` durch das Passwort von `lernapp`.

Prüfen, welche Schlüssel vorhanden sind:

```powershell
dotnet user-secrets list
```

User Secrets sind nur für lokale Entwicklung gedacht. Sie werden außerhalb des Projektordners im Benutzerprofil gespeichert.

### Modell für die Datenbank ergänzen

Die Datenbank identifiziert jede Zeile über `Id`. Ergänze in `TaskItem`:

```csharp
public int Id { get; set; }
```

Dapper muss geladene Zeilen in Objekte schreiben können. Ergänze deshalb zusätzlich einen parameterlosen Konstruktor:

```csharp
public TaskItem()
{
    Titel = string.Empty;
}
```

Der vorhandene Konstruktor für neue Formulareinträge bleibt bestehen:

```csharp
public TaskItem(
    string titel,
    string? beschreibung,
    AufgabenStatus status)
{
    Titel = titel;
    Beschreibung = beschreibung;
    Status = status;
}
```

Ein neues Objekt besitzt zunächst `Id == 0`. Nach dem INSERT erhält es die von MariaDB erzeugte ID.

### Repository statt SQL in der Komponente


Die Komponente soll nicht selbst Connection Strings lesen oder SQL enthalten. Das Repository bündelt den gesamten Datenzugriff.

Grundstruktur:

```csharp
using Dapper;
using LerntrackerDapperUebung.Models;
using MySqlConnector;

namespace LerntrackerDapperUebung.Data;

public class TaskItemRepository
{
    private readonly string connectionString;

    public TaskItemRepository(
        IConfiguration configuration)
    {
        connectionString =
            configuration.GetConnectionString("MariaDb")
            ?? throw new InvalidOperationException(
                "Connection String 'MariaDb' fehlt."
            );
    }

    private MySqlConnection ErstelleVerbindung()
    {
        return new MySqlConnection(connectionString);
    }
}
```

Das Repository speichert nicht eine dauerhaft geöffnete Verbindung. Jede Methode erzeugt ihre eigene Verbindung und gibt sie anschließend wieder frei. Connection Pooling übernimmt die effiziente Wiederverwendung im Hintergrund.

### Aufgaben laden

```csharp
public async Task<List<TaskItem>> LadeAlleAsync()
{
    const string sql = @"
        SELECT
            Id,
            Titel,
            Beschreibung,
            Status
        FROM Aufgaben
        ORDER BY Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    IEnumerable<TaskItem> ergebnis =
        await connection.QueryAsync<TaskItem>(sql);

    return ergebnis.ToList();
}
```

Dapper ordnet gleichnamige Spalten den Properties von `TaskItem` zu.

Die Abfrage verändert nichts. Sie liest alle Zeilen und sortiert sie nach der ID.

### Aufgabe anlegen

```csharp
public async Task ErstellenAsync(TaskItem aufgabe)
{
    const string insertSql = @"
        INSERT INTO Aufgaben
            (Titel, Beschreibung, Status)
        VALUES
            (@Titel, @Beschreibung, @Status);";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    await connection.OpenAsync();

    await connection.ExecuteAsync(
        insertSql,
        new
        {
            aufgabe.Titel,
            aufgabe.Beschreibung,
            Status = (int)aufgabe.Status
        }
    );

    long neueId =
        await connection.ExecuteScalarAsync<long>(
            "SELECT LAST_INSERT_ID();"
        );

    aufgabe.Id = checked((int)neueId);
}
```

Die Werte werden nicht in den SQL-Text hineinkopiert. `@Titel`, `@Beschreibung` und `@Status` sind Parameter.

Das schützt vor SQL-Injection und überlässt dem Treiber die korrekte Wertübertragung.

`LAST_INSERT_ID()` wird auf derselben geöffneten Verbindung ausgeführt. So erhält das Objekt die ID der gerade eingefügten Zeile.

### Aufgabe als erledigt markieren

```csharp
public async Task AlsErledigtMarkierenAsync(
    int id)
{
    const string sql = @"
        UPDATE Aufgaben
        SET Status = @Status
        WHERE Id = @Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    int betroffeneZeilen =
        await connection.ExecuteAsync(
            sql,
            new
            {
                Id = id,
                Status = (int)AufgabenStatus.Erledigt
            }
        );

    if (betroffeneZeilen != 1)
    {
        throw new InvalidOperationException(
            "Die Aufgabe wurde nicht gefunden."
        );
    }
}
```

Die ID entscheidet, welche Datenbankzeile geändert wird. Titel sind dafür ungeeignet, weil mehrere Aufgaben denselben Titel besitzen können.

### Repository registrieren

Ergänze in `Program.cs` den Namespace:

```csharp
using LerntrackerDapperUebung.Data;
```

Registriere das Repository vor `builder.Build()`:

```csharp
builder.Services.AddScoped<TaskItemRepository>();
```

`Scoped` passt bei Interactive Server zum Verbindungskontext des Benutzers. Das Repository selbst hält trotzdem keine offene Datenbankverbindung.

### Repository in Home verwenden

Oben in `Home.razor`:

```razor
@inject TaskItemRepository Repository
```

Dafür muss der Data-Namespace verfügbar sein, entweder direkt:

```razor
@using LerntrackerDapperUebung.Data
```

oder gemeinsam in `Components/_Imports.razor`.


```csharp
private List<TaskItem> aufgaben =
    new List<TaskItem>();
```


```csharp
protected override async Task OnInitializedAsync()
{
    try
    {
        aufgaben = await Repository.LadeAlleAsync();
    }
    catch (Exception)
    {
        ladefehler =
            "Die Aufgaben konnten nicht geladen werden.";
    }
    finally
    {
        ladevorgangLaeuft = false;
    }
}
```

Die Datenbank liegt auf dem Server. Anders als LocalStorage benötigt dieser Zugriff keine Browser-JavaScript-Verbindung und kann während der Komponenteninitialisierung stattfinden.

### Neue Aufgabe dauerhaft speichern


```csharp
await Repository.ErstellenAsync(neueAufgabe);
aufgaben.Add(neueAufgabe);
```

Zuerst wird gespeichert. Nur bei erfolgreichem INSERT wird das Objekt zur sichtbaren Liste hinzugefügt.

Doppelklickschutz, verständliche `InvalidOperationException` und das Zurücksetzen von `speichervorgangLaeuft` in `finally` bleiben unverändert.

### Status dauerhaft ändern


```csharp
await Repository.AlsErledigtMarkierenAsync(
    aufgabe.Id
);

aufgabe.Status = AufgabenStatus.Erledigt;
```

Auch hier wird zuerst die Datenbank aktualisiert. Scheitert das UPDATE, zeigt die Oberfläche nicht fälschlich einen Zustand, der nie gespeichert wurde.

### Was Dapper nicht übernimmt

Dapper:

- erstellt die Datenbank nicht automatisch,
- erstellt keine Tabellenmigrationen,
- verfolgt keine Objektänderungen,
- generiert kein UPDATE aus einer Propertyänderung,
- hält keine Objekte automatisch mit der Datenbank synchron.

Du schreibst SQL bewusst selbst und rufst für jede gewünschte Änderung eine Repository-Methode auf.

### Dapper und Sicherheit

Immer Parameter verwenden:

```csharp
// Richtig
"WHERE Id = @Id", new { Id = id }
```

Keine Eingaben durch String-Verkettung in SQL einsetzen:

```csharp
// Falsch
"WHERE Titel = '" + titel + "'"
```

SQL-Parameter schützen Werte. Namen von Tabellen oder Spalten können nicht auf dieselbe Weise als Parameter übergeben werden und sollten nicht aus Benutzereingaben stammen.

<a id="kapitel-22"></a>

## 17 · Formulare und vollständiges CRUD

Quelle: [Theorie der Lektion](../17_Blazor-Formulare-und-CRUD/THEORIE_UND_ANLEITUNG.md)

### CRUD als vollständiger Datenlebenszyklus

CRUD beschreibt die vier grundlegenden Operationen einer Datenanwendung:

```text
Create  → INSERT
Read    → SELECT
Update  → UPDATE
Delete  → DELETE
```

Die App soll nach jeder erfolgreichen Operation denselben Zustand in der Benutzeroberfläche und in MariaDB zeigen.

Die Reihenfolge lautet grundsätzlich:

```text
Eingabe validieren
→ Datenbankoperation abwarten
→ sichtbaren Zustand aktualisieren
```

Schlägt die Datenbankoperation fehl, bleibt der bisherige sichtbare Zustand bestehen.

### Warum ein `EditForm`?

Das bisherige Formular besteht aus einem normalen HTML-`form` und einzelnen Feldern:

```razor
<form @onsubmit="Absenden"
      @onsubmit:preventDefault>
```

Das funktioniert für einfache Prüfungen. Mit wachsendem Formular entstehen aber viele manuelle `if`-Blöcke und Fehlermeldungsfelder.

Blazor stellt dafür `EditForm` bereit. Ein `EditForm`:

- arbeitet mit einem Formularmodell,
- verwaltet den Bearbeitungs- und Validierungszustand,
- unterstützt Blazor-Eingabekomponenten,
- kann nur bei gültigen Daten `OnValidSubmit` auslösen,
- verbindet DataAnnotations mit Fehlermeldungen.

### Entity und Formularmodell trennen

`TaskItem` repräsentiert den gespeicherten Datensatz. Für das Formular wird eine eigene Klasse verwendet:

```text
TaskItem
→ Datenbankobjekt und sichtbare Aufgabe

TaskItemFormularModell
→ vorübergehende Eingaben des Benutzers
```

Das verhindert einen wichtigen Fehler: Wenn du das vorhandene `TaskItem` direkt an Eingabefelder bindest, wird das Objekt in der sichtbaren Liste schon während des Tippens verändert. Ein Abbrechen könnte die alten Werte dann nicht einfach wiederherstellen.

Das Formularmodell ist eine Kopie. Erst nach gültigem Formular und erfolgreichem UPDATE ersetzt `Home` das sichtbare Objekt.

### Formularmodell mit DataAnnotations


```csharp
using System.ComponentModel.DataAnnotations;

namespace TodoCrudUebung.Models;

public class TaskItemFormularModell
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Der Titel ist erforderlich.")]
    [StringLength(
        200,
        ErrorMessage =
            "Der Titel darf höchstens 200 Zeichen lang sein."
    )]
    public string Titel { get; set; } = string.Empty;

    [StringLength(
        2000,
        ErrorMessage =
            "Die Beschreibung darf höchstens 2000 Zeichen lang sein."
    )]
    public string? Beschreibung { get; set; }

    public AufgabenStatus Status { get; set; } =
        AufgabenStatus.Offen;
}
```

Die Regeln passen zu den Anwendungsanforderungen:

- Titel ist Pflicht,
- Datenbankspalte `Titel` erlaubt maximal 200 Zeichen,
- Beschreibung bleibt optional,
- Status besitzt immer einen Enum-Wert.

DataAnnotations ersetzen nicht alle Datenbankregeln. Die Datenbank behält weiterhin `NOT NULL`, maximale Spaltenlänge und Status-Check als letzte Schutzschicht.

### Aufbau eines `EditForm`


```razor
<EditForm Model="@formularModell"
          OnValidSubmit="Speichern">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <label>
        Titel
        <InputText
            @bind-Value="formularModell.Titel"
            disabled="@Deaktiviert" />
    </label>
    <ValidationMessage
        For="@(() => formularModell.Titel)" />

    <label>
        Beschreibung
        <InputTextArea
            @bind-Value="formularModell.Beschreibung"
            disabled="@Deaktiviert" />
    </label>
    <ValidationMessage
        For="@(() => formularModell.Beschreibung)" />

    <label>
        Status
        <InputSelect
            @bind-Value="formularModell.Status"
            disabled="@Deaktiviert">
            <option value="@AufgabenStatus.Offen">Offen</option>
            <option value="@AufgabenStatus.InArbeit">In Arbeit</option>
            <option value="@AufgabenStatus.Erledigt">Erledigt</option>
        </InputSelect>
    </label>

    <button type="submit" disabled="@Deaktiviert">
        Speichern
    </button>
</EditForm>
```

Die wichtigsten Teile:

| Teil | Aufgabe |
|---|---|
| `Model` | Objekt, dessen Properties bearbeitet werden |
| `DataAnnotationsValidator` | aktiviert Validierungsattribute |
| `OnValidSubmit` | läuft nur bei gültigem Modell |
| `ValidationSummary` | zeigt alle Validierungsfehler |
| `ValidationMessage` | zeigt Fehler eines bestimmten Felds |
| `InputText` | bindet einen String im Formularkontext |
| `InputSelect` | bindet einen auswählbaren Wert |

Verwende nicht gleichzeitig einen äußeren HTML-`form`-Tag. Ein Formular darf nicht in einem weiteren Formular verschachtelt werden.

### Erstellen und Bearbeiten unterscheiden

Eine neue Aufgabe besitzt:

```text
Id == 0
```

Eine aus MariaDB geladene Aufgabe besitzt eine positive ID.

Das Formular erhält deshalb optional die zu bearbeitende Aufgabe:

```csharp
[Parameter]
public TaskItem? AufgabeZumBearbeiten { get; set; }

[Parameter]
public EventCallback<TaskItem> OnAufgabeGespeichert { get; set; }

[Parameter]
public EventCallback OnBearbeitungAbgebrochen { get; set; }
```

Der Modus ergibt sich aus dem Parameter:

```csharp
private bool IstBearbeitung =>
    AufgabeZumBearbeiten is not null;
```

Im Markup kannst du Titel und Buttontext unterscheiden:

```razor
<h2>@(IstBearbeitung ? "Aufgabe bearbeiten" : "Neue Aufgabe")</h2>
```

### Parameter in ein Formularmodell kopieren

Wenn `Home` eine Aufgabe auswählt, erhält die Formularkomponente einen neuen Parameterwert. `OnParametersSet` ist dafür der passende Lebenszyklus:

```csharp
private TaskItemFormularModell formularModell = new();
private int? geladeneId;

protected override void OnParametersSet()
{
    int? aktuelleId = AufgabeZumBearbeiten?.Id;

    if (aktuelleId == geladeneId)
    {
        return;
    }

    geladeneId = aktuelleId;

    if (AufgabeZumBearbeiten is null)
    {
        formularModell = new TaskItemFormularModell();
        return;
    }

    formularModell = new TaskItemFormularModell
    {
        Id = AufgabeZumBearbeiten.Id,
        Titel = AufgabeZumBearbeiten.Titel,
        Beschreibung = AufgabeZumBearbeiten.Beschreibung,
        Status = AufgabeZumBearbeiten.Status
    };
}
```

Warum wird `geladeneId` geprüft? Die Elternkomponente kann auch aus anderen Gründen neu rendern, etwa wenn `Deaktiviert` geändert wird. Das Formular soll die Eingabe dann nicht ständig mit den alten Daten überschreiben.

### Ein gültiges Formular zurückmelden

Aus dem Formularmodell wird ein neues `TaskItem` erzeugt:

```csharp
private async Task Speichern()
{
    string? beschreibung = formularModell.Beschreibung;

    if (string.IsNullOrWhiteSpace(beschreibung))
    {
        beschreibung = null;
    }

    TaskItem aufgabe = new TaskItem(
        formularModell.Titel.Trim(),
        beschreibung,
        formularModell.Status
    )
    {
        Id = formularModell.Id
    };

    try
    {
        await OnAufgabeGespeichert.InvokeAsync(aufgabe);

        if (formularModell.Id == 0)
        {
            formularModell = new TaskItemFormularModell();
        }

        fehlermeldung = null;
    }
    catch (InvalidOperationException exception)
    {
        fehlermeldung = exception.Message;
    }
}
```

Bei einer neuen Aufgabe wird das Formular nach Erfolg geleert. Beim Bearbeiten setzt `Home` den Bearbeitungsparameter auf `null`; `OnParametersSet` stellt danach wieder ein leeres Modell her.

### Bearbeitung abbrechen

Im Bearbeitungsmodus erscheint ein zweiter Button:

```razor
@if (IstBearbeitung)
{
    <button type="button"
            disabled="@Deaktiviert"
            @onclick="BearbeitungAbbrechen">
        Abbrechen
    </button>
}
```

Die Methode meldet nur nach oben:

```csharp
private Task BearbeitungAbbrechen()
{
    return OnBearbeitungAbgebrochen.InvokeAsync();
}
```

`Home` besitzt die Auswahl und setzt sie zurück. Das Kind verändert nicht selbst die Aufgabenliste.

### Allgemeines UPDATE im Repository


```csharp
public async Task AktualisierenAsync(TaskItem aufgabe)
{
    const string sql = @"
        UPDATE Aufgaben
        SET
            Titel = @Titel,
            Beschreibung = @Beschreibung,
            Status = @Status
        WHERE Id = @Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    int betroffeneZeilen =
        await connection.ExecuteAsync(
            sql,
            new
            {
                aufgabe.Id,
                aufgabe.Titel,
                aufgabe.Beschreibung,
                Status = (int)aufgabe.Status
            }
        );

    if (betroffeneZeilen != 1)
    {
        throw new InvalidOperationException(
            "Die Aufgabe wurde nicht gefunden."
        );
    }
}
```

Die ID steht ausschließlich in der WHERE-Bedingung. Ohne `WHERE Id = @Id` würden alle Aufgaben aktualisiert. Prüfe diese Zeile vor jedem UPDATE besonders sorgfältig.

### Eine gemeinsame Speichermethode in Home

`Home` entscheidet anhand der ID zwischen INSERT und UPDATE:

```csharp
private async Task AufgabeSpeichern(TaskItem aufgabe)
{
    PruefeObSpeichernMoeglichIst();
    speichervorgangLaeuft = true;

    try
    {
        if (aufgabe.Id == 0)
        {
            await Repository.ErstellenAsync(aufgabe);
            aufgaben.Add(aufgabe);
        }
        else
        {
            await Repository.AktualisierenAsync(aufgabe);

            int index = aufgaben.FindIndex(
                eintrag => eintrag.Id == aufgabe.Id
            );

            if (index < 0)
            {
                throw new InvalidOperationException(
                    "Die sichtbare Aufgabe wurde nicht gefunden."
                );
            }

            aufgaben[index] = aufgabe;
            aufgabeInBearbeitung = null;
        }
    }
    catch (Exception exception)
    {
        throw new InvalidOperationException(
            "Die Aufgabe konnte nicht gespeichert werden.",
            exception
        );
    }
    finally
    {
        speichervorgangLaeuft = false;
    }
}
```

Das Repository setzt beim INSERT die neue ID. Beim UPDATE wird das Objekt in der sichtbaren Liste erst nach erfolgreicher Datenbankänderung ersetzt.

### Bearbeitung in Home auswählen

```csharp
private TaskItem? aufgabeInBearbeitung;

private void AufgabeBearbeiten(TaskItem aufgabe)
{
    aufgabeInBearbeitung = aufgabe;
}

private void BearbeitungAbbrechen()
{
    aufgabeInBearbeitung = null;
}
```

Übergib die Auswahl an das Formular:

```razor
<AufgabenFormular
    AufgabeZumBearbeiten="@aufgabeInBearbeitung"
    Deaktiviert="@speichervorgangLaeuft"
    OnAufgabeGespeichert="AufgabeSpeichern"
    OnBearbeitungAbgebrochen="BearbeitungAbbrechen" />
```

### DELETE im Repository

```csharp
public async Task LoeschenAsync(int id)
{
    const string sql = @"
        DELETE FROM Aufgaben
        WHERE Id = @Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    int betroffeneZeilen =
        await connection.ExecuteAsync(
            sql,
            new { Id = id }
        );

    if (betroffeneZeilen != 1)
    {
        throw new InvalidOperationException(
            "Die Aufgabe wurde nicht gefunden."
        );
    }
}
```

Auch DELETE muss genau eine Zeile betreffen. Die ID stammt aus dem bereits geladenen Objekt und wird als SQL-Parameter übergeben.

### Löschen in Home

```csharp
private async Task AufgabeLoeschen(TaskItem aufgabe)
{
    PruefeObSpeichernMoeglichIst();
    speichervorgangLaeuft = true;

    try
    {
        await Repository.LoeschenAsync(aufgabe.Id);
        aufgaben.Remove(aufgabe);

        if (aufgabeInBearbeitung?.Id == aufgabe.Id)
        {
            aufgabeInBearbeitung = null;
        }
    }
    catch (Exception exception)
    {
        throw new InvalidOperationException(
            "Die Aufgabe konnte nicht gelöscht werden.",
            exception
        );
    }
    finally
    {
        speichervorgangLaeuft = false;
    }
}
```

Die sichtbare Liste wird erst nach erfolgreichem DELETE verändert. Wird gerade dieselbe Aufgabe bearbeitet, wird zusätzlich der Bearbeitungsmodus beendet.

### Neue Ereignisse der Aufgabenkarte

Die Karte meldet Bearbeiten und Löschen nach oben:

```csharp
[Parameter]
public EventCallback<TaskItem> OnBearbeiten { get; set; }

[Parameter]
public EventCallback<TaskItem> OnLoeschen { get; set; }
```

Die Buttons lösen nur Ereignisse aus. SQL und Listenänderungen bleiben in Repository beziehungsweise `Home`.

```razor
<button type="button"
        disabled="@Deaktiviert"
        @onclick="BearbeitenMelden">
    Bearbeiten
</button>

<button type="button"
        disabled="@Deaktiviert"
        @onclick="LoeschenVorbereiten">
    Löschen
</button>
```

### Löschbestätigung ohne JavaScript

Eine versehentliche Löschung ist schwer rückgängig zu machen. Die Karte kann eine zweistufige Bestätigung besitzen:

```csharp
private bool loeschenBestaetigen;
```

Beim ersten Klick wird nur dieses Feld gesetzt. Danach zeigt die Karte:

```razor
@if (loeschenBestaetigen)
{
    <p>Diese Aufgabe wirklich löschen?</p>

    <button type="button"
            disabled="@Deaktiviert"
            @onclick="LoeschenMelden">
        Ja, löschen
    </button>

    <button type="button"
            disabled="@Deaktiviert"
            @onclick="LoeschenAbbrechen">
        Abbrechen
    </button>
}
```

`LoeschenMelden` wartet auf `OnLoeschen.InvokeAsync(Aufgabe)`. Bei Erfolg wird die Karte aus der Elternliste entfernt. Bei einem Fehler bleibt sie sichtbar und zeigt wie beim Erledigt-Button eine lokale Fehlermeldung.

### `@key` bei veränderlichen Listen

Eine Aufgabenkarte besitzt nun lokalen Zustand, beispielsweise `loeschenBestaetigen`. Beim Sortieren oder Entfernen soll Blazor den Zustand eindeutig dem richtigen Datensatz zuordnen.

Verwende deshalb:

```razor
@foreach (TaskItem aufgabe in SichtbareAufgaben)
{
    <AufgabenKarte
        @key="aufgabe.Id"
        Aufgabe="@aufgabe"
        ... />
}
```

Die Datenbank-ID ist stabil und eindeutig. Der Schleifenindex wäre kein geeigneter Schlüssel, weil er sich beim Sortieren oder Löschen verändert.

### Filtern ist keine Listenänderung

Die ursprüngliche Liste bleibt vollständig. Ein Filter bestimmt nur, welche Elemente gerade dargestellt werden:

```csharp
private AufgabenStatus? statusFilter;
```

`null` bedeutet „Alle“.

Im Markup:

```razor
<label>
    Status filtern
    <select @bind="statusFilter">
        <option value="">Alle</option>
        <option value="@AufgabenStatus.Offen">Offen</option>
        <option value="@AufgabenStatus.InArbeit">In Arbeit</option>
        <option value="@AufgabenStatus.Erledigt">Erledigt</option>
    </select>
</label>
```

### Sortierung als eigener Enum


```csharp
namespace TodoCrudUebung.Models;

public enum AufgabenSortierung
{
    NeuesteZuerst,
    AeltesteZuerst,
    TitelAufsteigend
}
```

Im Markup:

```razor
<label>
    Sortierung
    <select @bind="sortierung">
        <option value="@AufgabenSortierung.NeuesteZuerst">
            Neueste zuerst
        </option>
        <option value="@AufgabenSortierung.AeltesteZuerst">
            Älteste zuerst
        </option>
        <option value="@AufgabenSortierung.TitelAufsteigend">
            Titel A–Z
        </option>
    </select>
</label>
```

Eine höhere ID steht in dieser einfachen App für eine später erstellte Aufgabe. Für eine echte Zeitangabe würdest du später eine eigene `ErstelltAm`-Spalte verwenden.

### Sichtbare Aufgaben berechnen

```csharp
private AufgabenSortierung sortierung =
    AufgabenSortierung.NeuesteZuerst;

private IEnumerable<TaskItem> SichtbareAufgaben
{
    get
    {
        IEnumerable<TaskItem> ergebnis = aufgaben;

        if (statusFilter.HasValue)
        {
            ergebnis = ergebnis.Where(
                aufgabe =>
                    aufgabe.Status == statusFilter.Value
            );
        }

        return sortierung switch
        {
            AufgabenSortierung.AeltesteZuerst =>
                ergebnis.OrderBy(aufgabe => aufgabe.Id),

            AufgabenSortierung.TitelAufsteigend =>
                ergebnis.OrderBy(aufgabe => aufgabe.Titel),

            _ => ergebnis.OrderByDescending(
                aufgabe => aufgabe.Id
            )
        };
    }
}
```

Die Property erzeugt keine zweite dauerhafte Aufgabenliste. Sie liefert bei jedem Rendern eine gefilterte und sortierte Sicht auf `aufgaben`.

Für eine kleine Lern-App ist Filtern im Arbeitsspeicher sinnvoll. Bei sehr vielen Datensätzen würden Filter, Sortierung und Seiteneinteilung bereits in der SQL-Abfrage stattfinden.

### Zähler

Die vollständige Liste ist die Grundlage für die Zähler:

```csharp
private int AnzahlOffen => aufgaben.Count(
    aufgabe => aufgabe.Status != AufgabenStatus.Erledigt
);

private int AnzahlErledigt => aufgaben.Count(
    aufgabe => aufgabe.Status == AufgabenStatus.Erledigt
);
```

Im Markup:

```razor
<p>
    Gesamt: @aufgaben.Count ·
    Offen: @AnzahlOffen ·
    Erledigt: @AnzahlErledigt
</p>
```

Hier bedeutet „Offen“ alle noch nicht erledigten Aufgaben, also sowohl `Offen` als auch `InArbeit`.

### Leere Zustände unterscheiden

Zwei Situationen sehen ähnlich aus, bedeuten aber etwas anderes:

```text
aufgaben.Count == 0
→ Datenbank enthält keine Aufgaben

!SichtbareAufgaben.Any()
→ Aufgaben existieren, aber keine passt zum Filter
```

Zeige passende Meldungen:

```razor
@if (aufgaben.Count == 0)
{
    <p>Noch keine Aufgaben vorhanden.</p>
}
else if (!SichtbareAufgaben.Any())
{
    <p>Keine Aufgabe passt zum gewählten Filter.</p>
}
else
{
    <!-- Karten -->
}
```

### Die Karte aus Home verbinden

Beispiel mit drei Ereignissen:

```razor
<AufgabenKarte
    @key="aufgabe.Id"
    Aufgabe="@aufgabe"
    Deaktiviert="@speichervorgangLaeuft"
    OnErledigt="AufgabeErledigen"
    OnBearbeiten="AufgabeBearbeiten"
    OnLoeschen="AufgabeLoeschen" />
```

Der Datenfluss:

```text
Home gibt TaskItem nach unten
→ Karte zeigt es an
→ Benutzer klickt
→ Karte meldet TaskItem nach oben
→ Home ruft Repository auf
→ Home ändert Liste erst nach Erfolg
```

### Validierung und Datenbanksicherheit sind verschiedene Ebenen

DataAnnotations verbessern die Benutzerführung. SQL-Parameter schützen die Datenbankabfrage. Beide lösen unterschiedliche Probleme:

| Schutz | Aufgabe |
|---|---|
| DataAnnotations | ungültige Formulareingaben früh erkennen |
| SQL-Parameter | Werte sicher an SQL übertragen |
| Datenbank-Constraints | gültige Daten auch außerhalb der UI erzwingen |
| eingeschränkter Benutzer | erlaubte Datenbankaktionen begrenzen |

Ein gültiges `EditForm` erlaubt deshalb keine String-Verkettung in SQL. Repository-Abfragen bleiben immer parametrisiert.
