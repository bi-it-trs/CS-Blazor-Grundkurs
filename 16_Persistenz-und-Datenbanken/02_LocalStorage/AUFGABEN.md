# Aufgaben – LocalStorage

## Ausgangslage

Dieses Projekt enthält den fertigen komponentisierten Lerntracker aus Lektion 15.

Die Anwendung kann Aufgaben anlegen und erledigen. Die Liste liegt aber nur im Arbeitsspeicher und geht bei einem Neustart verloren.

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
3. einen konstanten Storage-Schlüssel,
4. ein boolesches Feld für den Ladezustand.

## Aufgabe 2: Liste speichern

Erstelle eine asynchrone Methode, die:

1. `aufgaben` mit `JsonSerializer.Serialize` in Text umwandelt,
2. den Text mit `localStorage.setItem` speichert,
3. immer denselben Storage-Schlüssel verwendet.

## Aufgabe 3: Liste einmalig laden

Überschreibe `OnAfterRenderAsync(bool firstRender)`.

Anforderungen:

- Nur beim ersten interaktiven Rendern laden.
- `localStorage.getItem` aufrufen.
- Vorhandenen JSON-Text deserialisieren.
- Die geladene Liste nur übernehmen, wenn sie nicht `null` ist.
- Wenn noch kein Wert existiert, die Startaufgaben erstmals speichern.
- Den Ladezustand abschließen.
- Danach einmal neu rendern.

## Aufgabe 4: Ladeanzeige

Zeige vor Abschluss des Ladens nur einen kurzen Ladehinweis.

Formular, Anzahl und Karten sollen erst erscheinen, wenn das Laden beendet ist.

## Aufgabe 5: Nach Änderungen speichern

Passe beide Elternmethoden an:

- Nach dem Hinzufügen einer Aufgabe speichern.
- Nach der Statusänderung speichern.

Beide Methoden müssen dafür asynchron werden und `Task` zurückgeben.

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
