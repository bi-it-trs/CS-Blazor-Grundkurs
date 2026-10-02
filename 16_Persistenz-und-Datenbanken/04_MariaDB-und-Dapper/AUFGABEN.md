# Aufgaben – MariaDB und Dapper

## Ausgangslage

Dieses Projekt enthält die Musterlösung der Async-Lerntracker-Übung. Die LocalStorage-Übung ist unabhängig und wurde absichtlich nicht übernommen.

Die Anwendung lädt und speichert bisher simuliert mit `Task.Delay`. Ladeanzeige, Speicherstatus, Doppelklickschutz, deaktivierte Bedienelemente und Fehlerbehandlung sind bereits vorhanden. Es gibt noch:

- keine Datenbank-ID,
- kein SQL-Schema,
- keine Dapper-Pakete,
- kein Repository,
- keinen Connection String.

## Ziel

Ersetze den In-Memory-Speicher durch MariaDB. Laden, Hinzufügen und Erledigen müssen einen App- und Browserneustart überleben.

## Voraussetzungen prüfen

1. Docker Desktop läuft.
2. Der MariaDB-Container aus Teil 02 ist `healthy`.
3. DBeaver kann sich verbinden.
4. Das Startprojekt baut:

```powershell
dotnet build
dotnet run
```

## Vereinbarte Struktur

Vorhanden:

- `Components/Pages/Home.razor`
- `Components/AufgabenFormular.razor`
- `Components/AufgabenKarte.razor`
- `Models/TaskItem.cs`
- `Models/AufgabenStatus.cs`

Von dir zu erstellen:

- `Database/01_schema.sql`
- `Data/TaskItemRepository.cs`

Benenne die vorhandenen Komponenten, Modelle und Properties nicht um.

## Aufgabe 1: Datenbankzugang einrichten

Erstelle mit DBeaver:

1. die Datenbank `lerntracker`,
2. den Benutzer `lernapp`,
3. eingeschränkte Rechte für SELECT, INSERT, UPDATE und DELETE,
4. die Tabelle `Aufgaben`.

Die Tabelle benötigt:

- automatisch erzeugte `Id`,
- erforderlichen Titel mit maximal 200 Zeichen,
- optionale Beschreibung,
- numerischen Status,
- Beschränkung auf die Statuswerte 0, 1 und 2.

Speichere das verwendete Schema ohne echtes Passwort in `Database/01_schema.sql`.

Erstelle danach eine eigene DBeaver-Verbindung als `lernapp` und prüfe den Zugriff.

## Aufgabe 2: Pakete installieren

```powershell
dotnet add package Dapper
dotnet add package MySqlConnector
```

Baue anschließend das Projekt.

## Aufgabe 3: Connection String als User Secret

Initialisiere User Secrets und speichere den Connection String unter:

```text
ConnectionStrings:MariaDb
```

Anforderungen:

- Host und Port passen zum Docker-Setup.
- Datenbank ist `lerntracker`.
- Benutzer ist `lernapp`.
- Das Passwort steht weder in C# noch in einer eingecheckten JSON-Datei.

## Aufgabe 4: Modell ergänzen

Ergänze `TaskItem` um:

- die Property `Id`,
- einen parameterlosen Konstruktor für Dapper.

Der vorhandene Konstruktor für das Formular bleibt erhalten.

## Aufgabe 5: Repository erstellen

Erstelle und implementiere:

```text
Data/TaskItemRepository.cs
```

Benötigte Methoden:

- `LadeAlleAsync()`
- `ErstellenAsync(TaskItem aufgabe)`
- `AlsErledigtMarkierenAsync(int id)`

Anforderungen:

- Jede Methode verwendet eine eigene `MySqlConnection`.
- Verbindungen werden mit `using` oder `await using` freigegeben.
- Alle Werte werden als SQL-Parameter übergeben.
- Nach dem INSERT wird die erzeugte ID in das Objekt geschrieben.
- Das UPDATE prüft, ob genau eine Zeile betroffen war.

## Aufgabe 6: Dependency Injection

Registriere `TaskItemRepository` als Scoped Service in `Program.cs`.

Importiere den Data-Namespace für die Razor-Komponenten und injiziere das Repository in `Home.razor`.

## Aufgabe 7: Liste aus MariaDB laden

Ersetze in der bereits vorhandenen Methode `OnInitializedAsync` den Aufruf von `StartaufgabenLadenAsync` durch das Repository.

Behalte den vorhandenen Ladezustand sowie `try`, `catch` und `finally`. Entferne anschließend die simulierte Lademethode vollständig.

Eine leere Datenbank soll eine leere Aufgabenliste anzeigen und keinen Fehler erzeugen.

## Aufgabe 8: Neue Aufgaben speichern

Passe die Elternmethode für `OnAufgabeErstellt` an:

1. Im vorhandenen `try` den simulierten Speicheraufruf ersetzen.
2. Repository asynchron aufrufen.
3. INSERT erfolgreich abschließen.
4. Danach das Objekt zur sichtbaren Liste hinzufügen.
5. Doppelklickschutz, verständliche Exception und `finally` beibehalten.

## Aufgabe 9: Status speichern

Passe die Elternmethode für `OnErledigt` an:

1. Im vorhandenen `try` den simulierten Speicheraufruf ersetzen.
2. Datensatz anhand der ID aktualisieren.
3. Danach den Status des sichtbaren Objekts ändern.
4. Doppelklickschutz, verständliche Exception und `finally` beibehalten.

Entferne danach `AenderungSpeichernAsync`. Im fertigen Projekt darf keine `Task.Delay`-Simulation mehr für Laden oder Speichern übrig bleiben.

## Funktionstest

- App startet mit leerer Datenbank.
- Neue Aufgabe erscheint in der Oberfläche.
- Neue Zeile erscheint in DBeaver.
- Optionale Beschreibung kann `NULL` sein.
- Enum-Werte werden korrekt als 0, 1 oder 2 gespeichert.
- Nach Browser-Neuladen bleibt die Aufgabe bestehen.
- Nach App-Neustart bleibt die Aufgabe bestehen.
- Erledigt-Klick aktualisiert genau eine Zeile.
- Der erledigte Status bleibt nach einem Neustart bestehen.
- Die App verwendet nicht den Root-Benutzer.
- Im SQL werden keine Benutzereingaben verkettet.
- Lade- und Speicheranzeige funktionieren weiterhin.
- Buttons sind während eines Datenbankzugriffs deaktiviert.
- Die simulierten `Task.Delay`-Methoden wurden entfernt.

## Zusatzaufgaben

Diese Erweiterungen bereiten das spätere To-do-Projekt vor:

- Aufgabe über ihre ID löschen.
- Titel, Beschreibung und Status bearbeiten.
- Nach Status filtern.
- Nach Titel oder ID sortieren.
- Datenbankfehler benutzerfreundlich anzeigen.
- Repository mit einem Interface abstrahieren.

## Kontrollfragen

1. Warum werden Dapper und MySqlConnector benötigt?
2. Warum braucht ein Datenbankobjekt eine ID?
3. Warum liegt SQL im Repository und nicht in der Razor-Komponente?
4. Warum darf die App nicht mit dem Root-Benutzer arbeiten?
5. Warum wird zuerst die Datenbank und danach die sichtbare Liste geändert?
6. Wovor schützen SQL-Parameter?
7. Was übernimmt Dapper bewusst nicht?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/04_MariaDB-und-Dapper/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "16_Persistenz-und-Datenbanken/04_MariaDB-und-Dapper/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "16_Persistenz-und-Datenbanken/04_MariaDB-und-Dapper/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet. Voraussetzung ist, dass dieser Starterordner im Git-Tag `uebungen-start` enthalten ist.