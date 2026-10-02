# 01 – C#-Grundaufbau

## Lernziel

Du kannst ein Konsolenprogramm starten, einfache Anweisungen lesen, Text im Terminal ausgeben und Kommentare schreiben.

## Das Projekt und `Program.cs`

In diesem Ordner liegt ein eigenständiges C#-Konsolenprojekt. Die Datei `Program.cs` enthält den Code, der beim Start ausgeführt wird.

Moderne C#-Konsolenprojekte erlauben Anweisungen direkt in der Datei:

```csharp
Console.WriteLine("Hallo!");
Console.WriteLine("Das ist die zweite Zeile.");
```

Die Anweisungen werden von oben nach unten ausgeführt. Jede `WriteLine`-Anweisung erzeugt eine neue Ausgabezeile.

## Das Programm ausführen

1. Speichere `Program.cs`.
2. Öffne ein Terminal in diesem Projektordner.
3. Führe den folgenden Befehl aus:

```powershell
dotnet run
```

Nach einer Änderung musst du die Datei erneut speichern und `dotnet run` erneut ausführen. Sonst siehst du möglicherweise noch die alte Ausgabe.

## Eine Anweisung zerlegen

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

## Mehrere Texte ausgeben

Jede Zeile ist eine eigene Anweisung:

```csharp
Console.WriteLine("Lieblingssprache: C#");
Console.WriteLine("Lernziel: eigene Programme schreiben");
Console.WriteLine("Lernzeit: drei Stunden");
```

Nur der Text innerhalb der Anführungszeichen erscheint im Terminal. Die Anführungszeichen selbst werden nicht ausgegeben.

`Console.Write` gibt ebenfalls Text aus, springt danach aber nicht in eine neue Zeile. Für die Aufgaben dieser Lektion verwendest du `Console.WriteLine`.

## Groß- und Kleinschreibung

C# unterscheidet Groß- und Kleinschreibung:

```csharp
Console.WriteLine("Richtig");
// console.WriteLine("Falsch");
```

`Console` und `console` gelten als zwei verschiedene Namen. Auch `WriteLine` muss genau so geschrieben werden.

## Kommentare

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

## Geführtes Beispiel

1. Öffne `Program.cs`.
2. Schreibe zuerst einen Kommentar, der den Zweck des Programms beschreibt.
3. Füge darunter drei `Console.WriteLine`-Anweisungen mit eigenen Texten ein.
4. Speichere die Datei.
5. Starte sie mit `dotnet run`.
6. Ändere einen Text, speichere erneut und starte das Programm noch einmal.

## Häufige Fehler

- Das Semikolon am Ende einer Anweisung fehlt.
- Ein Text besitzt nur ein öffnendes oder schließendes Anführungszeichen.
- `Console` oder `WriteLine` wurde mit falscher Groß- und Kleinschreibung geschrieben.
- Die Datei wurde vor `dotnet run` nicht gespeichert.
- Der Terminalbefehl wird außerhalb des Projektordners ausgeführt.

## Das brauchst du für die Aufgaben

Du kannst die Aufgaben vollständig lösen, wenn du:

- pro gewünschter Ausgabezeile eine eigene `Console.WriteLine`-Anweisung schreibst,
- Text in doppelte Anführungszeichen setzt,
- jede Anweisung mit `;` beendest,
- oberhalb des Codes einen Kommentar mit `//` einfügst,
- eigene Texte einsetzt, speicherst und das Ergebnis mit `dotnet run` prüfst.

