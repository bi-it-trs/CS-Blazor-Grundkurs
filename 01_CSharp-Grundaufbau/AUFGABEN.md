# Aufgaben – C#-Grundaufbau

## Aufgabe 1: Persönliche Vorstellung

Schreibe ein Programm, das vier Zeilen ausgibt:

- Name
- Ausbildung oder Beruf
- aktuelles Lernthema
- nächstes Lernziel

Anforderungen:

- Verwende viermal `Console.WriteLine`.
- Schreibe oberhalb des Codes einen sinnvollen Kommentar.
- Verwende eigene Angaben.
- Das Programm muss mit `dotnet run` fehlerfrei laufen.

## Aufgabe 2: Ausgabe verändern

Ergänze eine fünfte Zeile mit deiner geplanten Lernzeit für diese Woche. Ändere danach mindestens zwei Texte und prüfe, ob die neue Ausgabe erscheint.

## Kontrollfragen

1. Wozu dient das Semikolon?
2. Warum funktioniert `console.WriteLine` nicht?
3. Welche Teile eines Kommentars werden ausgeführt?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "01_CSharp-Grundaufbau/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "01_CSharp-Grundaufbau/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "01_CSharp-Grundaufbau/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
