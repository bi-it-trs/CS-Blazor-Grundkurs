# Aufgaben – LocalStorage

## Ausgangslage

Dieses Projekt enthält die Musterlösung der vorherigen Async-Lerntracker-Übung.

Die Anwendung lädt und speichert bisher nur simuliert mit `Task.Delay`. Ladeanzeige, Speicherstatus, deaktivierte Bedienelemente, `try`/`catch`/`finally` und asynchrone Eventmethoden sind bereits vorhanden. Die Liste liegt aber weiterhin nur im Arbeitsspeicher.

## Ziel

Speichere die vollständige `List<TaskItem>` als JSON in `localStorage`. Nach einem Neuladen müssen die zuletzt gespeicherten Aufgaben und Statuswerte wieder erscheinen.

## Startcheck

```powershell
dotnet build
dotnet run
```

Teste vor der Änderung:

- Aufgabe hinzufügen,
- Aufgabe erledigen,
- Browser neu laden.

Die Änderungen verschwinden momentan. Genau das wird in dieser Übung behoben.

## Vereinbarte Dateien

Arbeite hauptsächlich in:

- `Components/Pages/Home.razor`

Bereits vorhanden und nicht umzubenennen:

- `Components/AufgabenFormular.razor`
- `Components/AufgabenKarte.razor`
- `Models/TaskItem.cs`
- `Models/AufgabenStatus.cs`

Für diese Übung ist kein zusätzliches NuGet-Paket notwendig.

## Aufgabe 1: Voraussetzungen ergänzen

Ergänze in `Home.razor`:

1. den Namespace `System.Text.Json`,
2. die Injection von `IJSRuntime`,
3. einen konstanten Storage-Schlüssel.

Die Felder für Lade- und Speicherzustand sind bereits vorhanden.

## Aufgabe 2: Liste speichern

Ersetze die simulierte Methode `AenderungSpeichernAsync` durch eine asynchrone Methode `AufgabenSpeichernAsync`, die:

1. `aufgaben` mit `JsonSerializer.Serialize` in Text umwandelt,
2. den Text mit `localStorage.setItem` speichert,
3. immer denselben Storage-Schlüssel verwendet.

## Aufgabe 3: Liste einmalig laden

Entferne das simulierte `OnInitializedAsync` und überschreibe stattdessen `OnAfterRenderAsync(bool firstRender)`.

Anforderungen:

- Nur beim ersten interaktiven Rendern laden.
- `localStorage.getItem` aufrufen.
- Vorhandenen JSON-Text deserialisieren.
- Die geladene Liste nur übernehmen, wenn sie nicht `null` ist.
- Wenn noch kein Wert existiert, die Startaufgaben erstmals speichern.
- Vorhandene Felder `ladevorgangLaeuft` und `ladefehler` mit `try`, `catch` und `finally` verwenden.
- Danach einmal neu rendern.

Ersetze außerdem `StartaufgabenLadenAsync` durch eine synchrone Methode ohne `Task.Delay`, die nur die drei Startaufgaben erzeugt.

## Aufgabe 4: Ladeanzeige

Prüfe die bereits vorhandene Ladeanzeige und passe sie nur bei Bedarf an.

Formular, Anzahl und Karten sollen erst erscheinen, wenn das Laden beendet ist.

## Aufgabe 5: Nach Änderungen speichern

Passe die bereits asynchronen Elternmethoden an:

- Ersetze den simulierten Speicheraufruf durch `AufgabenSpeichernAsync`.
- Verändere die Liste beziehungsweise den Status so, dass der neue Zustand serialisiert wird.
- Nimm die Änderung in einem inneren `catch` zurück, falls LocalStorage fehlschlägt.
- Behalte Doppelklickschutz, verständliche Exception und `finally` aus der Async-Übung bei.

Entferne danach alle nicht mehr benötigten `Task.Delay`-Simulationen.

## Funktionstest

1. Füge mindestens zwei Aufgaben hinzu.
2. Verwende verschiedene Statuswerte.
3. Markiere eine Aufgabe als erledigt.
4. Lade die Browserseite neu.
5. Schließe den Browser und öffne die Seite erneut.
6. Prüfe, dass Aufgaben und Statuswerte erhalten bleiben.
7. Kontrolliere den JSON-Wert in den Entwicklerwerkzeugen.

## Zusatzaufgaben

- Ergänze einen Button, der nur den verwendeten Storage-Schlüssel löscht.
- Zeige eine verständliche Fehlermeldung bei ungültigem JSON.
- Speichere zusätzlich eine Versionsnummer, damit spätere Modelländerungen erkannt werden können.

## Kontrollfragen

1. Warum kann LocalStorage nicht sicher während des Prerenderings gelesen werden?
2. Warum wird `firstRender` geprüft?
3. Warum muss nach jeder Zustandsänderung erneut gespeichert werden?
4. Wem gehören die gespeicherten Daten?
5. Warum ist LocalStorage kein Ersatz für eine gemeinsame Datenbank?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/03_LocalStorage/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "16_Persistenz-und-Datenbanken/03_LocalStorage/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "16_Persistenz-und-Datenbanken/03_LocalStorage/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet. Voraussetzung ist, dass dieser Starterordner im Git-Tag `uebungen-start` enthalten ist.
