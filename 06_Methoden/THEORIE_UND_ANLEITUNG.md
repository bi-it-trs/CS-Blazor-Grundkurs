# 06 – Methoden

## Lernziel

Du kannst wiederverwendbaren Code in benannte Methoden aufteilen, Werte als Argumente übergeben und berechnete Ergebnisse zurückgeben.

## Warum Methoden?

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

## Aufbau einer Methode

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

## Parameter und Argumente

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

## Methode ohne Rückgabewert: `void`

`void` bedeutet, dass die Methode keinen Wert zurückgibt:

```csharp
void ZeigeMeldung(string meldung)
{
    Console.WriteLine(meldung);
}

ZeigeMeldung("Die Übung beginnt.");
```

Eine `void`-Methode kann etwas ausführen oder ausgeben. Ihr Aufruf kann aber nicht in einer Ergebnisvariable gespeichert werden.

## Methode mit Rückgabewert

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

## Eine Methode mit `bool` als Ergebnis

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

## Eine Methode mit `string` als Ergebnis

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

## Ausgabe und Berechnung trennen

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

## Gültigkeitsbereich

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

## Geführtes Vorgehen für die Aufgaben

1. Entscheide für jede Methode, ob sie nur etwas tun oder einen Wert liefern soll.
2. Verwende `void`, wenn kein Rückgabewert benötigt wird.
3. Verwende den passenden Rückgabetyp, wenn ein Ergebnis benötigt wird.
4. Schreibe für jeden benötigten Eingangswert einen Parameter mit Datentyp.
5. Rufe die Methode mit Argumenten in derselben Reihenfolge auf.
6. Speichere Rückgabewerte in Variablen des passenden Typs.
7. Gib die gespeicherten Ergebnisse im Hauptprogramm aus.

## Häufige Fehler

- Eine Methode mit Rückgabetyp enthält kein `return`.
- Der Wert hinter `return` passt nicht zum Rückgabetyp.
- Das Ergebnis einer `void`-Methode soll in einer Variable gespeichert werden.
- Beim Aufruf fehlen Argumente oder ihre Reihenfolge ist vertauscht.
- Eine Berechnungsmethode gibt nur etwas aus, obwohl ihr Ergebnis später gebraucht wird.
- Ein Parameter oder eine lokale Variable wird außerhalb der Methode verwendet.
- Beim Aufruf wird die Methodendefinition mit Datentypen wiederholt; Datentypen stehen nur in der Definition.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "06_Methoden/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "06_Methoden/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "06_Methoden/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
