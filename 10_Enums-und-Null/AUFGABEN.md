# Aufgaben – Enums und `null`

## Ausgangslage

Dieses Projekt enthält bereits den geprüften Mindest-Endstand aus Lektion 09:

- `TaskItem.cs` enthält Properties und einen Konstruktor.
- `Program.cs` erzeugt drei Aufgaben und speichert sie in einer `List<TaskItem>`.
- Die Liste wird gezählt, durchlaufen, verändert und mit `RemoveAt` verkleinert.

Der bisherige boolesche Status `IstErledigt` reicht nur für zwei Zustände. In dieser Lektion ersetzt du ihn durch den genaueren Enum-Status.

Prüfe vor der ersten Änderung:

```powershell
dotnet build
dotnet run
```

Vereinbarte Dateien:

- `Program.cs` und `TaskItem.cs` sind vorhanden.
- `AufgabenStatus.cs` erstellst du in dieser Lektion selbst.

Benenne diese Dateien sowie `TaskItem` und `AufgabenStatus` nicht um. Lektion 11 übernimmt genau diese Typen.

## Aufgabe: Status und optionale Beschreibung

1. Erstelle `AufgabenStatus.cs` mit `Offen`, `InArbeit` und `Erledigt`.
2. Verwende den Enum als Property in `TaskItem`.
3. Ändere Beschreibung und Konstruktorparameter zu `string?`.
4. Erzeuge mindestens drei Aufgaben.
5. Eine Aufgabe erhält `null` als Beschreibung.
6. Verwende alle drei Statuswerte.
7. Gib bei fehlender Beschreibung „Keine Beschreibung“ aus.
8. Gib alle Aufgaben mit `foreach` aus.

## Kontrollfragen

1. Warum ist ein Enum sicherer als ein freier Statustext?
2. Was liefert `nameof(AufgabenStatus.Offen)` und was ist der Unterschied zu `AufgabenStatus.Offen`?
3. Warum sollte der Anzeigetext nicht dauerhaft in der Beschreibung gespeichert werden?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "10_Enums-und-Null/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "10_Enums-und-Null/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "10_Enums-und-Null/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
