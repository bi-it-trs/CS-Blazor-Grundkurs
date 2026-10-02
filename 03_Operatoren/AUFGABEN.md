# Aufgaben – Operatoren

## Aufgabe: Lernfortschritt berechnen

Verwende folgende Ausgangswerte oder eigene vergleichbare Werte:

- geplante Aufgaben
- erledigte Aufgaben
- Minuten pro Aufgabe
- Wochenziel

Berechne und speichere:

1. offene Aufgaben
2. gesamte geplante Lernzeit in Minuten
3. gesamte geplante Lernzeit in Stunden
4. ob das Wochenziel erreicht wurde

Erhöhe danach die erledigten Aufgaben mit `+=` und berechne die davon abhängigen Werte erneut.

Anforderungen:

- Verwende mindestens `-`, `*`, `/` und `>=`.
- Speichere jedes Ergebnis in einer eigenen Variable.
- Der Vergleich wird in einer `bool`-Variable gespeichert.
- Gib ursprüngliche und aktualisierte Werte aus.

## Zusatzaufgabe

Verwende `%`, um zu prüfen, ob sich eine Anzahl Aufgaben gleichmäßig auf zwei Lerntage verteilen lässt.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "03_Operatoren/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "03_Operatoren/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "03_Operatoren/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
