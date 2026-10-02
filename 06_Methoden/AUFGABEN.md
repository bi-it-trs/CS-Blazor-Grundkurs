# Aufgaben – Methoden

## Aufgabe: Lernfortschritt in Methoden aufteilen

Erstelle drei Methoden:

### `ZeigeAufgabe`

- erhält einen Titel als `string`
- gibt ihn aus
- besitzt keinen Rückgabewert

### `BerechneOffeneAufgaben`

- erhält Gesamtzahl und erledigte Anzahl
- gibt die offenen Aufgaben als `int` zurück
- gibt innerhalb der Methode nichts aus

### `IstZielErreicht`

- erhält erledigte Anzahl und Zielwert
- gibt `bool` zurück
- das Ziel ist erreicht, wenn die erledigte Anzahl mindestens dem Ziel entspricht

Speichere die Rückgabewerte im Hauptprogramm und gib sie dort aus.

Teste `IstZielErreicht` mit einem wahren und einem falschen Fall.

## Zusatzaufgabe

Schreibe eine Methode, die aus Titel und Status einen vollständigen Ausgabetext zurückgibt.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "06_Methoden/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "06_Methoden/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "06_Methoden/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
