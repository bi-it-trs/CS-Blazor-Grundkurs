# Aufgaben – Klassen und Objekte

## Ausgangslage

Mit dieser Lektion beginnt die zusammenhängende Aufgaben-Tracker-Reihe. Es gibt deshalb noch keine übernommene Musterlösung. `Program.cs` enthält nur einen kurzen Starttext.

Prüfe zuerst das Projekt:

```powershell
dotnet build
dotnet run
```

Vereinbarte Dateinamen:

- `Program.cs` ist bereits vorhanden.
- `TaskItem.cs` erstellst du in dieser Lektion selbst.

Verwende für Klasse und Datei exakt den Namen `TaskItem`. Benenne `Program.cs` und `TaskItem.cs` während dieser Übungsreihe nicht um. Die folgenden Lektionen verwenden diese Namen als gemeinsamen Ausgangspunkt.

## Aufgabe: Eigener Datentyp `TaskItem`

1. Erstelle `TaskItem.cs`.
2. Definiere eine Klasse `TaskItem` mit öffentlichen Feldern für Titel, Beschreibung und Erledigt-Status.
3. Erzeuge in `Program.cs` zwei unterschiedliche Objekte.
4. Weise beiden Objekten eigene Werte zu.
5. Gib alle Werte aus.
6. Ändere den Status eines Objekts nachträglich.
7. Gib den neuen Status aus.

## Methode zur Ausgabe

Schreibe zusätzlich eine Methode, die ein `TaskItem` als Parameter erhält und alle Felder ausgibt.

Kontrolliere dabei:

- Der Parameter besitzt den Datentyp `TaskItem`.
- Beide Objekte können mit derselben Methode ausgegeben werden.
- Die Objekte behalten unterschiedliche Werte.

