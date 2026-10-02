# Aufgaben – Properties und Konstruktoren

## Ausgangslage

Dieses Projekt enthält bereits den geprüften Mindest-Endstand aus Lektion 07:

- `TaskItem.cs` enthält `TaskItem` mit öffentlichen Feldern.
- `Program.cs` erzeugt zwei unabhängige Objekte.
- Eine Methode gibt ein übergebenes `TaskItem` aus.
- Ein Erledigt-Status wird nachträglich verändert.

Deine eigene Lösung aus Lektion 07 bleibt unverändert im vorherigen Projekt erhalten. Hier arbeitest du mit dem vorbereiteten Referenzstand weiter.

Prüfe vor der ersten Änderung:

```powershell
dotnet build
dotnet run
```

Arbeite in `Program.cs` und `TaskItem.cs`. Benenne beide Dateien und die Klasse `TaskItem` nicht um, weil die folgenden Lektionen darauf aufbauen.

## Aufgabe: `TaskItem` verbessern

1. Übernimm oder erstelle eine Klasse `TaskItem`.
2. Ersetze die öffentlichen Felder durch Properties mit `get` und `set`.
3. Erstelle einen Konstruktor mit Titel und Beschreibung.
4. Setze den Erledigt-Status im Konstruktor standardmäßig auf `false`.
5. Erzeuge zwei Aufgaben direkt über den Konstruktor.
6. Gib beide Aufgaben aus.
7. Setze eine Aufgabe nachträglich auf erledigt und gib sie erneut aus.

## Kontrollfragen

1. Warum besitzt ein Konstruktor keinen Rückgabetyp?
2. Was passiert, wenn ein erforderliches Konstruktorargument fehlt?
3. Welche Aufgabe haben `get` und `set`?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "08_Properties-und-Konstruktoren/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "08_Properties-und-Konstruktoren/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "08_Properties-und-Konstruktoren/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
