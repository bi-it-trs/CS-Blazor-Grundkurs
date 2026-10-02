# 04 – Bedingungen

## Lernziel

Du kannst abhängig von Werten unterschiedliche Codewege ausführen, feste Auswahlwerte mit `switch` übersetzen und mehrere Bedingungen logisch verbinden.

## Bedingungen ergeben `true` oder `false`

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

## `if`, `else if` und `else`

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

## Werte vergleichen

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

## Logische Operatoren

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

## Eine Zahl mit `switch` in Text übersetzen

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

## `switch` und `if` zusammen verwenden

Ein typischer Ablauf lautet:

1. Ausgangswerte anlegen, zum Beispiel Titel, Zahlenauswahl und Dringlichkeit.
2. Mit `switch` die Zahl in einen verständlichen Text übersetzen.
3. Aus dem Text oder der Zahl einen `bool` ableiten, zum Beispiel `bool istAbgeschlossen = bereich == "Projekt";`.
4. Mit `if`, `else if` und `else` über die weitere Meldung entscheiden.
5. Titel, übersetzten Text und Entscheidung ausgeben.

## Verschiedene Fälle testen

Ein Programm kann korrekt kompilieren und trotzdem einen Fall falsch behandeln. Ändere deshalb den Ausgangswert mehrmals und starte das Programm jeweils neu. Prüfe jeden gültigen Auswahlwert und außerdem einen Wert, der im `default`-Zweig landen soll.

## Häufige Fehler

- In `if ( )` steht kein Ausdruck, der `true` oder `false` ergibt.
- Bei einem Vergleich wird `=` statt `==` verwendet.
- Eine Seite von `&&` oder `||` ist keine vollständige Bedingung.
- Ein wichtiger Sonderfall steht nach einem allgemeineren Fall und wird deshalb nie erreicht.
- In einem `case` fehlt `break`.
- Die Ergebnisvariable wird nur in einigen `case`-Zweigen gesetzt; `default` verhindert diese Lücke.
- Eine Variable wird innerhalb eines Blocks deklariert und danach außerhalb verwendet.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "04_Bedingungen/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "04_Bedingungen/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "04_Bedingungen/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
