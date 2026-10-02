# Aufgaben – Variablen und Datentypen

## Aufgabe 1: Lernprofil

Lege mindestens diese Variablen an:

- Name als `string`
- Alter als `int`
- Lernstunden pro Woche als `double`
- Interesse an Blazor als `bool`

Gib alle Werte mit String-Interpolation aus.

## Aufgabe 2: Wert verändern

1. Gib die ursprünglichen Lernstunden aus.
2. Weise der bestehenden Variable einen neuen Wert zu.
3. Gib den aktualisierten Wert aus.

Anforderungen:

- Jeder der vier Grundtypen wird verwendet.
- Bei der zweiten Zuweisung der Lernstunden wird `double` nicht erneut geschrieben.
- Das Programm läuft ohne Warnungen und Fehler.

## Kontrollfragen

1. Was ist der Unterschied zwischen Deklaration und Zuweisung?
2. Warum steht vor einem interpolierten Text ein `$`?
3. Kann ein `bool` den Wert `"Ja"` speichern?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "02_Variablen-und-Datentypen/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "02_Variablen-und-Datentypen/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "02_Variablen-und-Datentypen/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
