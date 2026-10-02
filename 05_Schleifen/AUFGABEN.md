# Aufgaben – Schleifen

## Aufgabe 1: Drei Schleifenarten

Erstelle ein Array mit mindestens vier Lernaufgaben.

1. Gib alle Aufgaben mit `foreach` aus.
2. Gib mit `for` fünf nummerierte Lernrunden aus.
3. Simuliere mit `while`, wie Aufgaben nacheinander erledigt werden.

Anforderungen:

- Verwende `foreach`, `for` und `while`.
- Gib bei der `while`-Schleife jeden Zwischenstand aus.
- Die Schleife muss sicher enden.

## Aufgabe 2: Gültige Eingabe

Frage mit einer `do-while`- oder `while`-Schleife so lange nach einem nicht leeren Titel, bis eine gültige Eingabe erfolgt.

Teste:

- leere Eingabe
- nur Leerzeichen
- gültigen Titel

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "05_Schleifen/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "05_Schleifen/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "05_Schleifen/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
