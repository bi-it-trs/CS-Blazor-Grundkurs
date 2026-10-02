# Aufgaben – Enums und `null`

## Ausgangslage

Dieses Projekt enthält bereits den geprüften Mindest-Endstand aus Lektion 09:

- `TaskItem.cs` enthält Properties und einen Konstruktor.
- `Program.cs` erzeugt drei Aufgaben und speichert sie in einer `List<TaskItem>`.
- Die Liste wird gezählt, durchlaufen, verändert und mit `RemoveAt` verkleinert.

Der bisherige boolesche Status `IstErledigt` reicht nur für zwei Zustände. In dieser Lektion ersetzt du ihn durch den genaueren Enum-Status.

Prüfe vor der ersten Änderung:

```powershell
dotnet build
dotnet run
```

Vereinbarte Dateien:

- `Program.cs` und `TaskItem.cs` sind vorhanden.
- `AufgabenStatus.cs` erstellst du in dieser Lektion selbst.

Benenne diese Dateien sowie `TaskItem` und `AufgabenStatus` nicht um. Lektion 11 übernimmt genau diese Typen.

## Aufgabe: Status und optionale Beschreibung

1. Erstelle `AufgabenStatus.cs` mit `Offen`, `InArbeit` und `Erledigt`.
2. Verwende den Enum als Property in `TaskItem`.
3. Ändere Beschreibung und Konstruktorparameter zu `string?`.
4. Erzeuge mindestens drei Aufgaben.
5. Eine Aufgabe erhält `null` als Beschreibung.
6. Verwende alle drei Statuswerte.
7. Gib bei fehlender Beschreibung „Keine Beschreibung“ aus.
8. Gib alle Aufgaben mit `foreach` aus.

## Kontrollfragen

1. Warum ist ein Enum sicherer als ein freier Statustext?
2. Was liefert `nameof(AufgabenStatus.Offen)` und was ist der Unterschied zu `AufgabenStatus.Offen`?
3. Warum sollte der Anzeigetext nicht dauerhaft in der Beschreibung gespeichert werden?

