# Aufgaben – LINQ-Grundlagen

## Ausgangslage

Dieses Projekt enthält bereits den geprüften Mindest-Endstand aus Lektion 11:

- `TaskItem.cs` und `AufgabenStatus.cs` sind vollständig vorhanden.
- `Program.cs` fragt Titel, optionale Beschreibung und Status über drei Methoden ab.
- Ungültige Eingaben werden wiederholt abgefragt.
- Das erzeugte Objekt wird zu einer `List<TaskItem>` hinzugefügt und ausgegeben.

Prüfe den übernommenen Stand zuerst mit mehreren gültigen und ungültigen Eingaben:

```powershell
dotnet build
dotnet run
```

Für reproduzierbare LINQ-Ergebnisse benötigst du in dieser Lektion mindestens sechs Aufgaben mit festgelegten Statuswerten. Du kannst die vorhandene Eingabeaufgabe durch weitere feste Testobjekte ergänzen oder den Eingabeabschnitt in diesem Projekt durch feste Testdaten ersetzen. Die vollständige Eingabelösung bleibt in Lektion 11 erhalten.

Arbeite in `Program.cs`, `TaskItem.cs` und `AufgabenStatus.cs`. Benenne diese Dateien, Typen oder verwendeten Properties nicht um.

## Aufgabe: Aufgaben auswerten

Erstelle eine Liste mit mindestens sechs Aufgaben und unterschiedlichen Statuswerten.

1. Zähle alle Aufgaben.
2. Zähle offene Aufgaben.
3. Zähle Aufgaben in Arbeit.
4. Zähle erledigte Aufgaben.
5. Erzeuge mit `Where` eine Liste aller nicht erledigten Aufgaben.
6. Sortiere die gefilterte Liste alphabetisch nach Titel.
7. Erzeuge zusätzlich eine separat sortierte Liste aller Aufgaben.
8. Gib beide Listen aus.

Anforderungen:

- Verwende `Count`, `Where`, `OrderBy` und `ToList`.
- Verändere die ursprüngliche Liste nicht.
- Benenne gefilterte Listen nach ihrem tatsächlichen Inhalt.

## Zusatzaufgabe

Vergleiche die Ergebnisse von `Where(...).OrderBy(...)` und `OrderBy(...).Where(...)`. Erkläre, warum beide hier denselben sichtbaren Inhalt liefern können.

