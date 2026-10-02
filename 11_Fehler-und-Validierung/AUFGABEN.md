# Aufgaben – Fehler und Validierung

## Ausgangslage

Dieses Projekt enthält bereits den geprüften Mindest-Endstand aus Lektion 10:

- `AufgabenStatus.cs` enthält `Offen`, `InArbeit` und `Erledigt`.
- `TaskItem.cs` verwendet den Enum als Status-Property.
- Die Beschreibung und der Konstruktorparameter sind `string?`.
- `Program.cs` enthält drei Aufgaben, verwendet alle Statuswerte und zeigt bei `null` einen Ersatztext.

Die vorhandene Liste ist dein Ausgangspunkt. In dieser Lektion ergänzt du die sichere Erfassung einer weiteren Aufgabe über das Terminal.

Prüfe vor der ersten Änderung:

```powershell
dotnet build
dotnet run
```

Arbeite in `Program.cs`, `TaskItem.cs` und `AufgabenStatus.cs`. Benenne diese Dateien, Typen oder vorhandenen Properties nicht um.

## Aufgabe: Neue Aufgabe über das Terminal erfassen

Schreibe drei Eingabemethoden:

### Titel

- fragt so lange, bis ein nicht leerer Titel eingegeben wurde
- gibt `string` zurück

### Beschreibung

- fragt genau einmal
- darf leer bleiben
- gibt `string?` zurück

### Status

- zeigt die Auswahl 1 bis 3
- lehnt leere Eingabe und Text ab
- lehnt Zahlen außerhalb von 1 bis 3 ab
- fragt bis zu einer gültigen Auswahl erneut
- gibt `AufgabenStatus` zurück

Erzeuge aus den drei Rückgabewerten ein `TaskItem`, füge es zu einer Liste hinzu und gib die Liste aus.

## Testfälle

- leerer Titel
- Titel nur aus Leerzeichen
- gültiger Titel
- leerer Status
- Status `abc`
- Status `0` und `5`
- gültige Statuswerte 1, 2 und 3

Das Programm darf bei keiner Fehleingabe abstürzen.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "11_Fehler-und-Validierung/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "11_Fehler-und-Validierung/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "11_Fehler-und-Validierung/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
