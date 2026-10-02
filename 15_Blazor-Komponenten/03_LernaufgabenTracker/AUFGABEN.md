# 03 – LernaufgabenTracker: Formular und Karte auslagern

## Start

Dieses Projekt ist eigenständig. Starte es in diesem Verzeichnis mit:

```powershell
dotnet run --launch-profile http
```

Die Ausgangslage ist **bereits funktionsfähig**: `Home.razor` enthält Formular, Validierung, Aufgabenliste, einzelne Karten und Erledigt-Button. Drei Aufgaben sind vorgegeben. Neue Aufgaben lassen sich hinzufügen und erledigen. Lies bei Bedarf [THEORIE_UND_ANLEITUNG.md](THEORIE_UND_ANLEITUNG.md); deren Beispiele verwenden eine Gästeliste.

## Ziel

Teile die große `Home.razor` in klar verantwortliche Komponenten auf, ohne das Verhalten zu verändern:

- `Home` besitzt dauerhaft die `List<TaskItem>` und verändert sie.
- `AufgabenKarte` zeigt genau ein `TaskItem` und meldet den Erledigt-Klick.
- `AufgabenFormular` besitzt seine vorübergehenden Eingaben, validiert sie, erzeugt ein gültiges `TaskItem` und meldet es an `Home`.

Die Modelle `Models/TaskItem.cs` und `Models/AufgabenStatus.cs` sind schon vorhanden. Du musst sie für diese Übung nicht neu schreiben.

## Teil A – Eine Aufgabenkarte

1. Erstelle `Components/AufgabenKarte.razor`.
2. Übernimm aus der `foreach`-Schleife in `Home` die Darstellung von Titel, Beschreibung, Status und Erledigt-Button.
3. Die Karte erhält die aktuelle Aufgabe als `[Parameter]` vom Typ `TaskItem`.
4. Ihr Erledigt-Button meldet genau dieses Objekt über `EventCallback<TaskItem>` an `Home`.
5. Die Methode, die den Status verändert, bleibt in `Home`. Ersetze den bisherigen Schleifeninhalt durch den Komponenten-Tag und verbinde Parameter und Callback.
6. Prüfe Teil A im Browser, bevor du Teil B beginnst.

## Teil B – Das Formular

1. Erstelle `Components/AufgabenFormular.razor`.
2. Verschiebe Formular, Eingabefelder, lokale Fehlermeldung und Validierung aus `Home` in diese Komponente.
3. Das Formular erzeugt bei gültigem Titel ein neues `TaskItem` und meldet es über `EventCallback<TaskItem>` an `Home`.
4. `Home` fügt das empfangene Objekt zu seiner Liste hinzu. Im Formular entsteht **keine zweite Aufgabenliste**.
5. Setze Eingaben und Fehlermeldung nur nach einem erfolgreichen Hinzufügen zurück.
6. Ersetze das bisherige Formular-Markup in `Home` durch den Komponenten-Tag und verbinde seinen Callback.

## Prüffragen

Beantworte vor dem Umbau: Welcher Zustand ist nur während der Eingabe nötig? Wer besitzt die dauerhafte Liste? Welcher konkrete Wert wird beim Anlegen gemeldet? Welcher konkrete Wert wird beim Erledigt-Klick gemeldet? Warum muss keine Kindkomponente `Home` als Objekt kennen?

## Funktionstest

- Die drei Startaufgaben erscheinen und die Anzahl stimmt.
- Eine neue Aufgabe ohne Beschreibung lässt sich anlegen.
- Ein leerer Titel und ein Titel nur aus Leerzeichen werden abgelehnt; die Liste bleibt unverändert.
- Nach gültiger Eingabe werden die Formularfelder zurückgesetzt.
- Eine offene Aufgabe wird durch ihren eigenen Button erledigt; eine andere bleibt unverändert.
- Bei erledigten Aufgaben verschwindet der Erledigt-Button.
- Formular und Karten funktionieren weiterhin nach mehreren Aktionen hintereinander.
- `dotnet build` endet ohne Fehler und Warnungen.

Arbeite in kleinen Schritten und baue nach Teil A sowie nach Teil B. Wenn ein Komponenten-Tag nicht erkannt wird, prüfe Dateiname und Namespace-Import in `Components/_Imports.razor`.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "15_Blazor-Komponenten/03_LernaufgabenTracker/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "15_Blazor-Komponenten/03_LernaufgabenTracker/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "15_Blazor-Komponenten/03_LernaufgabenTracker/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
