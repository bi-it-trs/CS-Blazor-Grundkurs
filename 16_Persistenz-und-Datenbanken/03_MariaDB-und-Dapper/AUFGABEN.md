# Aufgaben – MariaDB und Dapper

## Ausgangslage

Dieses Projekt enthält den fertigen komponentisierten Lerntracker aus Lektion 15.

Die Anwendung verwendet weiterhin eine private `List<TaskItem>` mit fest eingebauten Startdaten. Es gibt noch:

- keine Datenbank-ID,
- kein SQL-Schema,
- keine Dapper-Pakete,
- kein Repository,
- keinen Connection String.

Die LocalStorage-Übung ist unabhängig und wurde absichtlich nicht übernommen.

## Ziel

Ersetze den In-Memory-Speicher durch MariaDB. Laden, Hinzufügen und Erledigen müssen einen App- und Browserneustart überleben.

## Voraussetzungen prüfen

1. Docker Desktop läuft.
2. Der MariaDB-Container aus Teil 01 ist `healthy`.
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

Entferne die fest eingebauten Startaufgaben aus `Home`.

Lade die Liste in `OnInitializedAsync` über das Repository.

Eine leere Datenbank soll eine leere Aufgabenliste anzeigen und keinen Fehler erzeugen.

## Aufgabe 8: Neue Aufgaben speichern

Passe die Elternmethode für `OnAufgabeErstellt` an:

1. Repository asynchron aufrufen.
2. INSERT erfolgreich abschließen.
3. Danach das Objekt zur sichtbaren Liste hinzufügen.

## Aufgabe 9: Status speichern

Passe die Elternmethode für `OnErledigt` an:

1. Datensatz anhand der ID aktualisieren.
2. Danach den Status des sichtbaren Objekts ändern.

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
