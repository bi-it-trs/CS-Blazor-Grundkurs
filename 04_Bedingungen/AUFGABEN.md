# Aufgaben – Bedingungen

## Aufgabe: Aufgabenstatus bestimmen

Lege folgende Informationen an:

- Aufgabentitel
- Statusauswahl als Zahl
- Dringlichkeit als `bool`
- Statustext als `string`

Übersetze die Statusauswahl mit `switch`:

- `1` → Offen
- `2` → In Arbeit
- `3` → Erledigt
- andere Zahl → Unbekannt

Verwende danach `if`, `else if` und `else`:

- Erledigt: Abschlussmeldung
- dringend und nicht erledigt: Prioritätsmeldung
- sonst: normale Bearbeitung

Anforderungen:

- Teste alle drei gültigen Werte und mindestens einen ungültigen Wert.
- Verwende mindestens einmal `&&` oder `!`.
- Gib Titel, Status und Entscheidung aus.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "04_Bedingungen/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "04_Bedingungen/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "04_Bedingungen/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
