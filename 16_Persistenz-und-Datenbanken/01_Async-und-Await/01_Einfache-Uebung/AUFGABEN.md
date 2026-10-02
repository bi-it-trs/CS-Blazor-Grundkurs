# Aufgaben – Async-Grundlagen in der Konsole

## Ausgangslage

`Program.cs` enthält ein vollständiges Beispiel. Es lädt nach einer simulierten Wartezeit den Text `Blazor-Komponenten`.

Starte zunächst unverändert:

```powershell
dotnet run
```

## Aufgabe 1: Ablauf vorhersagen

Schreibe vor dem Start für dich auf, in welcher Reihenfolge diese Meldungen erscheinen:

- `Async-Beispiel startet.`
- `Das Lernthema wird angefordert.`
- `Laden läuft ...`
- `Geladenes Thema: Blazor-Komponenten`
- `Async-Beispiel ist beendet.`

Starte das Projekt und vergleiche die tatsächliche Reihenfolge mit deiner Vorhersage.

Beantworte anschließend:

1. Welche Codezeile sorgt dafür, dass die letzte Meldung nicht zu früh erscheint?
2. Welchen Typ gibt `LernthemaLadenAsync` zurück?
3. Warum kann die Variable `thema` trotzdem als `string` deklariert werden?

## Aufgabe 2: Methode ohne Rückgabewert

Erstelle eine Methode:

```text
FortschrittSpeichernAsync
```

Anforderungen:

- Sie erhält das geladene Thema als `string`-Parameter.
- Sie gibt `Task` zurück.
- Sie simuliert mit `Task.Delay` eine Wartezeit von ungefähr einer halben Sekunde.
- Sie gibt danach aus, für welches Thema der Fortschritt gespeichert wurde.
- Rufe sie in `BeispielAusfuehrenAsync` nach dem Laden des Themas mit `await` auf.
- Die Abschlussmeldung des Hauptprogramms darf erst danach erscheinen.

## Aufgabe 3: Methode mit Rückgabewert

Erstelle eine Methode:

```text
PunktestandLadenAsync
```

Anforderungen:

- Sie benötigt keinen Parameter.
- Sie gibt später einen `int` zurück und verwendet deshalb `Task<int>`.
- Sie wartet zunächst mit `Task.Delay`.
- Sie gibt danach beispielsweise `12` zurück.
- Rufe sie mit `await` auf.
- Gib den erhaltenen Punktestand aus.

Kontrolliere bewusst den Unterschied:

```text
Task       → später nur abgeschlossen
Task<int>  → später abgeschlossen und liefert int
```

## Aufgabe 4: Fehler nach einem Await behandeln

Erstelle eine Methode:

```text
PruefungAusfuehrenAsync
```

Sie soll:

1. einen booleschen Parameter `fehlerAusloesen` erhalten,
2. kurz asynchron warten,
3. bei `true` eine `InvalidOperationException` mit verständlicher Nachricht werfen,
4. bei `false` normal enden.

Rufe die Methode innerhalb von `try`, `catch` und `finally` auf.

Teste beide Varianten:

```csharp
await PruefungAusfuehrenAsync(false);
await PruefungAusfuehrenAsync(true);
```

Anforderungen:

- Bei Erfolg erscheint eine Erfolgsmeldung.
- Bei Fehler erscheint die Exception-Nachricht.
- Die Meldung aus `finally` erscheint in beiden Fällen.
- Das Programm darf nicht unkontrolliert abbrechen.

## Aufgabe 5: Reihenfolge erklären

Ordne deine Aufrufe so an:

1. Lernthema laden.
2. Punktestand laden.
3. Fortschritt speichern.
4. Prüfung ausführen.
5. Abschlussmeldung ausgeben.

Erkläre für jede Stelle, warum dort `await` benötigt wird.

## Zusatzaufgabe: Zwei unabhängige Vorgänge

Starte das Laden von Thema und Punktestand zunächst ohne direktes `await`. Warte anschließend mit `Task.WhenAll` auf beide Tasks und lies danach beide Ergebnisse aus.

Vergleiche die Laufzeit gedanklich mit der sequentiellen Variante. Verwende `Task.WhenAll` nur für diese beiden unabhängigen Lesevorgänge. Der Speichervorgang benötigt das geladene Thema und bleibt deshalb danach.

## Funktionstest

- Das Projekt baut ohne Fehler.
- Alle Meldungen erscheinen in nachvollziehbarer Reihenfolge.
- Methoden ohne Ergebnis verwenden `Task`.
- Methoden mit Ergebnis verwenden `Task<T>`.
- Jeder benötigte Task wird mit `await` abgewartet.
- Es existiert keine eigene `async void`-Methode.
- `.Result`, `.Wait()` und `Thread.Sleep` werden nicht verwendet.
- Der Fehlerfall wird kontrolliert behandelt.

## Kontrollfragen

1. Macht `async` eine Methode automatisch parallel?
2. Was erhält man beim `await` eines `Task<int>`?
3. Warum ist `Task.Delay` besser geeignet als `Thread.Sleep`?
4. Wo wird eine Exception aus einer asynchronen Methode sichtbar?
5. Warum ist `finally` für UI-Statusfelder nützlich?

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