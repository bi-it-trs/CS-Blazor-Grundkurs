# Aufgaben – Collections

## Ausgangslage

Dieses Projekt enthält bereits den geprüften Mindest-Endstand aus Lektion 08:

- `TaskItem.cs` verwendet Properties mit `get` und `set`.
- Der Konstruktor verlangt Titel und Beschreibung.
- Der anfängliche Erledigt-Status ist `false`.
- `Program.cs` erzeugt zwei Aufgaben über den Konstruktor und gibt sie aus.

Deine eigene Lösung aus Lektion 08 bleibt im vorherigen Projekt erhalten. Die vorhandenen Objekte bilden hier den Startpunkt für die Liste.

Prüfe vor der ersten Änderung:

```powershell
dotnet build
dotnet run
```

Arbeite in `Program.cs` und `TaskItem.cs`. Benenne diese Dateien, die Klasse oder ihre vorhandenen Properties nicht um.

## Aufgabe: Aufgabenliste verwalten

1. Erstelle eine `List<TaskItem>`.
2. Erzeuge mindestens drei eigene Aufgaben.
3. Füge alle Aufgaben mit `Add` zur Liste hinzu.
4. Gib die Anzahl mit `Count` aus.
5. Gib alle Aufgaben mit `foreach` aus.
6. Setze die zweite Aufgabe über den Index auf erledigt.
7. Entferne das erste Element mit `RemoveAt(0)`.
8. Gib die neue Anzahl und alle verbleibenden Aufgaben aus.

## Zusatzaufgaben

- Entferne ein bestimmtes Objekt mit `Remove`.
- Prüfe vor einem Indexzugriff, ob die Liste genügend Elemente besitzt.
- Schreibe eine Methode, die eine komplette `List<TaskItem>` als Parameter erhält und ausgibt.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "09_Collections/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "09_Collections/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "09_Collections/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
