# 16.01 – Async und Await

## Warum dieses Thema hier steht

Die folgenden Persistenzübungen rufen Browser- und Datenbankfunktionen auf. Solche Ein-/Ausgabevorgänge benötigen Zeit und werden in .NET normalerweise asynchron ausgeführt.

Darum kommt diese Lektion vor LocalStorage und Dapper. Du sollst dort nicht gleichzeitig rätseln müssen, was SQL macht und warum eine Methode plötzlich `Task`, `async` und `await` verwendet.

## Reihenfolge

1. `01_Einfache-Uebung`: Async ohne Blazor verstehen.
2. `02_Lerntracker-Async`: dasselbe Prinzip in Komponenten und Events anwenden.

Beide Projekte sind eigenständig und werden in ihrem jeweiligen Ordner gestartet.

## Übergang zu den nächsten Teilen

Der Lerntracker aus Projekt 02 simuliert zunächst langsame Lese- und Schreibvorgänge mit `Task.Delay`.

Die Folgeübungen beginnen mit dem erwarteten Endstand dieser Übung:

- In `03_LocalStorage` ersetzt du die Simulation durch Browser-Speicher.
- In `04_MariaDB-und-Dapper` ersetzt du die Simulation durch Datenbankzugriffe.

Dadurch bleibt der Ablauf gleich:

```text
Vorgang starten
→ await Speicherzugriff
→ Zustand nur bei Erfolg verändern
→ Oberfläche wieder freigeben
```

## Lernziel

Nach beiden Übungen kannst du:

- `Task` und `Task<T>` unterscheiden,
- eine asynchrone Methode schreiben und aufrufen,
- erklären, an welcher Stelle der Aufrufer weiterarbeitet,
- Fehler um einen `await`-Aufruf behandeln,
- Lade- und Speicherzustände in Blazor darstellen,
- doppelte Eingaben während eines laufenden Vorgangs verhindern,
- `async void`, `.Wait()` und `.Result` vermeiden.

## Einzelne Teilübung zurücksetzen

Führe im Terminal im Ordner `cs_uebungen` **nur die Zeile für das gewünschte Projekt** aus:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/"
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/"
```

Die Befehle betreffen nur versionierte Dateien des angegebenen Projekts. Neue, noch nicht versionierte Dateien kannst du mit `git clean -nd -- "GEWÄHLTER_PFAD/"` zuerst anzeigen und danach bei Bedarf mit `git clean -fd -- "GEWÄHLTER_PFAD/"` endgültig löschen. Die konkreten Befehle stehen in den beiden Aufgabenblättern. Voraussetzung ist, dass der gewünschte Starterordner im Git-Tag `uebungen-start` enthalten ist.
