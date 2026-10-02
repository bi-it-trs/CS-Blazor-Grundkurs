# 16 – Persistenz und Datenbanken

## Ziel

Diese Lektion schließt die Lücke zwischen dem bisherigen Lerntracker im Arbeitsspeicher und einer späteren vollständigen To-do-App.

Die vier Teile sind bewusst getrennt:

1. `01_Async-und-Await`: asynchrone Grundlagen und Anwendung im Lerntracker.
2. `02_MariaDB-Docker-und-DBeaver`: reine Infrastruktur-Anleitung.
3. `03_LocalStorage`: Browser-Speicherung ohne Datenbank.
4. `04_MariaDB-und-Dapper`: relationale Datenbank und serverseitiger Datenzugriff.

## Empfohlene Reihenfolge

Arbeite zuerst beide Async-Projekte durch. Danach richtest du die Datenbank-Infrastruktur ein und löst LocalStorage und Dapper als zwei eigenständige Persistenzvarianten.

`04_MariaDB-und-Dapper` baut fachlich nicht auf der LocalStorage-Lösung auf. Beide Persistenzprojekte starten mit dem erwarteten Endstand aus `01_Async-und-Await/02_Lerntracker-Async`: asynchrones Laden und Speichern, Ladeanzeige, deaktivierte Bedienelemente und Fehlerbehandlung sind bereits vorbereitet.

## Was du danach unterscheiden kannst

| Speicherort | Überlebt Neuladen? | Mehrere Browser/Geräte? | Geeignet für |
|---|---:|---:|---|
| Arbeitsspeicher | Nein | Nein | erste Übungen |
| `localStorage` | Ja | Nein | kleine lokale Browserdaten |
| MariaDB | Ja | Ja | dauerhafte Anwendungsdaten |

## Bezug zum späteren To-do-Projekt

Die Dapper-Übung behandelt absichtlich nur:

- Aufgaben laden,
- Aufgaben anlegen,
- Aufgaben als erledigt markieren.

Im eigentlichen To-do-Projekt ergänzt du anschließend Bearbeiten, Löschen, Filtern, Sortieren, Fehlerbehandlung und eine saubere Projektstruktur.

## Einzelne Teilübung zurücksetzen

Führe im Terminal im Ordner `cs_uebungen` **nur die Zeile für den gewünschten Teil** aus:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/"
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/"
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/02_MariaDB-Docker-und-DBeaver/"
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/03_LocalStorage/"
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/04_MariaDB-und-Dapper/"
```

Die Befehle betreffen nur versionierte Dateien des angegebenen Teils. Neue, noch nicht versionierte Dateien kannst du mit `git clean -nd -- "GEWÄHLTER_PFAD/"` zuerst anzeigen und danach bei Bedarf mit `git clean -fd -- "GEWÄHLTER_PFAD/"` endgültig löschen. Die konkreten Befehle stehen in den jeweiligen Aufgabenblättern beziehungsweise in der Infrastruktur-Anleitung. Voraussetzung ist, dass der gewünschte Starterordner im Git-Tag `uebungen-start` enthalten ist.
