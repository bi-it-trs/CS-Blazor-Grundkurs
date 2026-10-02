# Theorie und Anleitung – Async/Await ohne Blazor

## Lernziel

Du lernst zuerst die Sprachelemente `Task`, `Task<T>`, `async` und `await`, ohne dass Komponenten, HTML oder eine Datenbank davon ablenken.

Das vorhandene Konsolenprojekt enthält bereits ein vollständiges kleines Beispiel. Es verwendet `Task.Delay`, um einen langsamen Ein-/Ausgabevorgang zu simulieren. Später stehen an derselben Stelle LocalStorage- oder Datenbankaufrufe.

## Warum asynchroner Code nötig ist

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

## Das vorhandene Beispiel

Der Einstieg in `Program.cs` enthält:

```csharp
Console.WriteLine("Async-Beispiel startet.");

await BeispielAusfuehrenAsync();

Console.WriteLine("Async-Beispiel ist beendet.");
```

Die Zeile nach `await` wird erst ausgeführt, nachdem `BeispielAusfuehrenAsync` abgeschlossen ist.

Die aufgerufene Methode:

```csharp
static async Task BeispielAusfuehrenAsync()
{
    Console.WriteLine("Das Lernthema wird angefordert.");

    string thema = await LernthemaLadenAsync();

    Console.WriteLine($"Geladenes Thema: {thema}");
}
```

## `Task` bedeutet ein laufender oder zukünftiger Abschluss

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

## `Task<T>` liefert später einen Wert

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

Das kann absichtlich sinnvoll sein. Für die ersten Übungen wartest du aber direkt mit `await`.

## Was `async` und `await` jeweils machen

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

## `Task.Delay` gegenüber `Thread.Sleep`

In dieser Lektion simuliert `Task.Delay` einen langsamen externen Zugriff:

```csharp
await Task.Delay(800);
```

`Task.Delay` beschreibt asynchrones Warten. `Thread.Sleep(800)` blockiert dagegen den aktuellen Thread während der gesamten Zeit.

Für Blazor-Events und Serverzugriffe sollst du nicht mit `Thread.Sleep` warten.

Wichtig: `Task.Delay` speichert keine Daten. Es ist ausschließlich eine gut sichtbare Simulation, die in den Folgeübungen ersetzt wird.

## Asynchronität wandert zum Aufrufer

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

## Reihenfolge bleibt mit `await` lesbar

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

## Mehrere unabhängige Vorgänge

Zwei Tasks können zunächst gestartet und später gemeinsam abgewartet werden:

```csharp
Task<string> themaTask = LernthemaLadenAsync();
Task<int> punkteTask = PunktestandLadenAsync();

await Task.WhenAll(themaTask, punkteTask);

string thema = await themaTask;
int punkte = await punkteTask;
```

Das ist nur sinnvoll, wenn die Vorgänge voneinander unabhängig sind. Wenn der zweite Vorgang das Ergebnis des ersten benötigt, müssen sie nacheinander ausgeführt werden.

Für die Pflichtaufgaben genügt die sequentielle Variante. `Task.WhenAll` ist eine Zusatzaufgabe.

## Exceptions nach `await`

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

## Warum `async void` fast immer falsch ist

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

## Warum `.Result` und `.Wait()` vermieden werden

Diese Varianten blockieren synchron:

```csharp
string thema = LernthemaLadenAsync().Result;
LernthemaLadenAsync().Wait();
```

Sie können Anwendungen blockieren oder zu Deadlocks beitragen. Verwende in diesem Kurs stattdessen:

```csharp
string thema = await LernthemaLadenAsync();
```

## Benennung

Asynchrone Methoden enden üblicherweise auf `Async`:

- `LernthemaLadenAsync`
- `AufgabenSpeichernAsync`
- `LadeAlleAsync`

Der Name erinnert den Aufrufer daran, dass die Methode einen Task liefert und gewöhnlich mit `await` aufgerufen wird.

## Häufige Fehler

- `await` wird vergessen und es liegt nur ein `Task<T>` statt des Werts vor.
- Eine aufrufende Methode ist nicht selbst `async`.
- Eine eigene Methode wird als `async void` geschrieben.
- Nach dem Start eines Tasks wird zu früh auf Daten zugegriffen.
- `.Result` oder `.Wait()` blockiert den Ablauf.
- `Task.Delay` wird für echte Speicherung gehalten.
- Unabhängige und voneinander abhängige Schritte werden verwechselt.
- Eine Exception wird außerhalb des zugehörigen `await`-Aufrufs behandelt.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet. Voraussetzung ist, dass dieser Starterordner im Git-Tag `uebungen-start` enthalten ist.