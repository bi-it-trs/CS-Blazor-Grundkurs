# 16 – Persistenz und Datenbanken

## Ziel

Diese Lektion schließt die Lücke zwischen dem bisherigen Lerntracker im Arbeitsspeicher und einer späteren vollständigen To-do-App.

Die drei Teile sind bewusst getrennt:

1. `01_MariaDB-Docker-und-DBeaver`: reine Infrastruktur-Anleitung.
2. `02_LocalStorage`: Browser-Speicherung ohne Datenbank.
3. `03_MariaDB-und-Dapper`: relationale Datenbank und serverseitiger Datenzugriff.

## Empfohlene Reihenfolge

Arbeite zuerst die Infrastruktur-Anleitung durch. Löse danach LocalStorage und Dapper als zwei eigenständige Varianten.

`03_MariaDB-und-Dapper` baut fachlich nicht auf der LocalStorage-Lösung auf. Beide Blazor-Projekte starten mit dem fertigen komponentisierten Lerntracker aus Lektion 15.

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
