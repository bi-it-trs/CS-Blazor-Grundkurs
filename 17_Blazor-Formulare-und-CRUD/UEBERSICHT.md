# 17 – Blazor-Formulare und vollständiges CRUD

## Einordnung

Diese Lektion ist Punkt 6 der geplanten Erweiterung. Ein zusätzliches Abschlussprojekt aus Punkt 7 ist bewusst nicht enthalten.

Das Projekt beginnt mit der vollständigen Musterlösung aus Lektion 16.04:

- MariaDB und Dapper sind eingebunden.
- Aufgaben werden aus der Datenbank geladen.
- neue Aufgaben werden dauerhaft gespeichert,
- Aufgaben können dauerhaft als erledigt markiert werden,
- Lade-, Speicher- und Fehlerzustände sind vorbereitet.

## Ziel

Du entwickelst diesen Stand zu einer vollständigen CRUD-Anwendung weiter:

| Buchstabe | Bedeutung | Funktion in der App |
|---|---|---|
| C | Create | Aufgabe anlegen |
| R | Read | Aufgaben laden und anzeigen |
| U | Update | Titel, Beschreibung und Status bearbeiten |
| D | Delete | Aufgabe löschen |

Zusätzlich lernst du:

- `EditForm` und Blazor-Eingabekomponenten,
- DataAnnotations-Validierung,
- ein separates Formularmodell,
- Erstellen und Bearbeiten mit demselben Formular,
- Löschbestätigung,
- Statusfilter, Sortierung und Zähler,
- leere Ergebniszustände,
- konsistente UI- und Datenbankzustände.

## Dateien

- `THEORIE_UND_ANLEITUNG.md`: vollständige Erklärung und Referenz.
- `AUFGABEN.md`: Arbeitsauftrag in kontrollierbaren Etappen.
- `Database/01_schema.sql`: Schema aus Lektion 16.04.
- `Data/TaskItemRepository.cs`: funktionsfähiger Ausgangsstand für Create, Read und Erledigt-Update.

## Wichtiger Startpunkt

Der Connection String wird absichtlich nicht mitgeliefert. User Secrets gehören zu einem konkreten Projekt und müssen für dieses Projekt erneut gesetzt werden:

```powershell
dotnet user-secrets set "ConnectionStrings:MariaDb" "Server=localhost;Port=DEIN_HOST_PORT;Database=lerntracker;User ID=lernapp;Password=DEIN_PASSWORT"
```

Ersetze `DEIN_HOST_PORT` durch den tatsächlich veröffentlichten Host-Port des Datenbankcontainers und `DEIN_PASSWORT` durch das Passwort des App-Benutzers `lernapp`.

Verwende nicht den Root-Benutzer und speichere kein echtes Passwort im Projekt.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "17_Blazor-Formulare-und-CRUD/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "17_Blazor-Formulare-und-CRUD/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "17_Blazor-Formulare-und-CRUD/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet. Voraussetzung ist, dass dieser Starterordner im Git-Tag `uebungen-start` enthalten ist.
