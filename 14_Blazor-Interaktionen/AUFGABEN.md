# Aufgaben – Blazor-Interaktionen

## Ausgangslage

Dieses Projekt enthält bereits den geprüften Mindest-Endstand aus Lektion 13:

- `Models/AufgabenStatus.cs` enthält die drei Statuswerte.
- `Models/TaskItem.cs` enthält Titel, optionale Beschreibung, Status und Konstruktor.
- `Components/_Imports.razor` importiert den Modell-Namespace.
- `Components/Pages/Home.razor` besitzt drei Aufgaben im `@code`-Block.
- Die Seite zeigt Anzahl, Titel, Ersatzbeschreibung und Status mit `@foreach` und sinnvollen HTML-Elementen.

Der übernommene Stand ist absichtlich noch statisch: Er enthält weder `@rendermode InteractiveServer` noch Formular, Binding oder Buttons. Genau diese Interaktivität ergänzt du in dieser Lektion.

Prüfe vor der ersten Änderung:

```powershell
dotnet build
dotnet run
```

Arbeite hauptsächlich in `Components/Pages/Home.razor`. Die Dateien `Models/TaskItem.cs`, `Models/AufgabenStatus.cs`, `Components/_Imports.razor` und `Home.razor` bilden die vereinbarte Struktur und sollen nicht umbenannt werden.

## Aufgabe: Interaktiver Lerntracker

Erweitere `Home.razor`:

1. Aktiviere `InteractiveServer`.
2. Erstelle ein Formular für Titel, optionale Beschreibung und Status.
3. Verbinde alle Eingaben mit `@bind`.
4. Verarbeite das Formular über `@onsubmit`.
5. Verhindere das normale Neuladen der Seite.
6. Lehne einen leeren Titel ab.
7. Zeige eine Fehlermeldung bedingt an.
8. Erzeuge bei gültigen Daten ein `TaskItem` und füge es zur Liste hinzu.
9. Setze die Eingabefelder danach zurück.
10. Zeige bei nicht erledigten Aufgaben einen Erledigt-Button.
11. Ändere beim Klick den Status der richtigen Aufgabe.
12. Prüfe, ob Anzahl und Oberfläche automatisch aktualisiert werden.

## Testfälle

- leerer Titel
- Aufgabe ohne Beschreibung
- alle drei Statuswerte
- mehrere Aufgaben nacheinander
- Erledigt-Button bei verschiedenen Aufgaben
- erledigte Aufgabe zeigt keinen Erledigt-Button mehr

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "14_Blazor-Interaktionen/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "14_Blazor-Interaktionen/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "14_Blazor-Interaktionen/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
