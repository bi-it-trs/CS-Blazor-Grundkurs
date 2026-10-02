# C#-Übungen – Einstieg und Übersicht

Diese Übungen führen von den C#-Grundlagen über einen Lerntracker bis zu Blazor und dauerhafter Speicherung. Bearbeite sie in der angegebenen Reihenfolge. Kapitel 15 und 16 enthalten mehrere getrennte Projekte beziehungsweise Teile.

## So arbeitest du mit einer Übung

1. Öffne den Ordner der Übung und lies zuerst `AUFGABEN.md`. Dort stehen Ausgangslage, Arbeitsauftrag und Prüfpunkte. Bei 16.02 gibt es stattdessen eine Infrastruktur-Anleitung.
2. Sieh dir den vorhandenen Code an. Notiere für dich, welche Datei und welche Daten für den nächsten Schritt zuständig sind.
3. Versuche jeden Teil zunächst selbst. Nutze `THEORIE_UND_ANLEITUNG.md`, wenn dir ein Begriff, ein Syntaxmuster oder der Datenfluss fehlt. Die Beispiele dort verwenden nach Möglichkeit einen anderen Kontext als die Aufgabe.
4. Starte das jeweilige Projekt, prüfe auch Randfälle und beantworte die Kontrollfragen. Ändere jeweils nur so viel, dass du die Wirkung einer Änderung nachvollziehen kannst.
5. Halte deinen Stand mit Git fest, wenn du ihn später wiederfinden möchtest. Wenn du neu beginnen willst, stehen die Befehle zum Zurücksetzen im Aufgabenblatt und in der [Git-Anleitung](GIT_ANLEITUNG.md). Lies vor einem Rücksetzen den angegebenen Pfad: Der Befehl verwirft Änderungen in genau diesem Ordner.

Die **Aufgabe** beschreibt, was du umsetzen sollst. Bei **Theorie enthält** stehen nur die behandelten Themen, keine Lösungsschritte.

## Aufgaben 01–12: C# und Konsolenprogramme

### 01 – C#-Grundaufbau

- **Aufgaben:** [1. Persönliche Vorstellung](01_CSharp-Grundaufbau/AUFGABEN.md) mit mehreren Konsolenausgaben und einem Kommentar; 2. Ausgaben erweitern und verändern.
- **Theorie enthält:** Projektaufbau, `Program.cs`, Programmstart, Anweisungen, Konsolenausgabe, Groß- und Kleinschreibung, Kommentare, typische Fehler. [Theorie und Anleitung](01_CSharp-Grundaufbau/THEORIE_UND_ANLEITUNG.md)

### 02 – Variablen und Datentypen

- **Aufgaben:** [1. Lernprofil](02_Variablen-und-Datentypen/AUFGABEN.md) mit Werten verschiedener Typen ausgeben; 2. einen Wert neu zuweisen und die Änderung sichtbar machen.
- **Theorie enthält:** Variablen, `string`, `int`, `double`, `bool`, Benennung, String-Interpolation, Neuzuweisung, Gültigkeitsbereich. [Theorie und Anleitung](02_Variablen-und-Datentypen/THEORIE_UND_ANLEITUNG.md)

### 03 – Operatoren

- **Aufgaben:** [Lernfortschritt berechnen](03_Operatoren/AUFGABEN.md): offene Aufgaben, Lernzeit und Zielerreichung aus Werten ableiten; **Zusatz:** mit `%` eine Verteilung auf zwei Tage bestimmen.
- **Theorie enthält:** Rechenoperatoren, Vorrangregeln, ganzzahlige Division, Vergleiche, Kurzschreibweisen, Neuberechnung abhängiger Werte, Modulo. [Theorie und Anleitung](03_Operatoren/THEORIE_UND_ANLEITUNG.md)

### 04 – Bedingungen

- **Aufgabe:** [Aufgabenstatus bestimmen](04_Bedingungen/AUFGABEN.md): einen Zahlenwert per `switch` in einen Status übersetzen und mit Bedingungen eine passende Aktion ausgeben; mehrere Fälle testen.
- **Theorie enthält:** boolesche Bedingungen, `if`/`else if`/`else`, Vergleichsoperatoren, logische Operatoren, `switch`, Testfälle. [Theorie und Anleitung](04_Bedingungen/THEORIE_UND_ANLEITUNG.md)

### 05 – Schleifen

- **Aufgaben:** [1. Drei Schleifenarten](05_Schleifen/AUFGABEN.md): Aufgaben mit `foreach`, feste Durchläufe mit `for` und einen veränderlichen Ablauf mit `while` umsetzen; 2. eine Eingabe wiederholen, bis ein gültiger Titel vorliegt.
- **Theorie enthält:** Arrays, `foreach`, `for`, `while`, `do-while`, Konsoleneingabe, leere Eingaben, `break`, `continue`. [Theorie und Anleitung](05_Schleifen/THEORIE_UND_ANLEITUNG.md)

### 06 – Methoden

- **Aufgabe:** [Lernfortschritt in Methoden aufteilen](06_Methoden/AUFGABEN.md): eine Ausgabemethode, eine Berechnung mit `int`-Rückgabe und eine Prüfung mit `bool`-Rückgabe erstellen; **Zusatz:** einen vollständigen Text aus einer Methode zurückgeben.
- **Theorie enthält:** Methodendeklaration, Parameter und Argumente, `void`, Rückgabewerte, Ausgabe gegenüber Berechnung, Gültigkeitsbereich. [Theorie und Anleitung](06_Methoden/THEORIE_UND_ANLEITUNG.md)

### 07 – Klassen und Objekte

- **Aufgabe:** [Eigenen Datentyp `TaskItem` erstellen](07_Klassen-und-Objekte/AUFGABEN.md), zwei Objekte anlegen, Werte ändern und ein Objekt an eine Ausgabemethode übergeben.
- **Theorie enthält:** Klassen, Objekte, eigene Datei, `new`, Felder, Punktoperator, Objektzustand, Referenztypen, Übergabe an Methoden. [Theorie und Anleitung](07_Klassen-und-Objekte/THEORIE_UND_ANLEITUNG.md)

### 08 – Properties und Konstruktoren

- **Aufgabe:** [`TaskItem` verbessern](08_Properties-und-Konstruktoren/AUFGABEN.md): Felder durch Properties ersetzen, Pflichtangaben über einen Konstruktor setzen und den Status später ändern.
- **Theorie enthält:** Properties mit `get`/`set`, Konstruktoren, Parameter gegenüber Properties, Initialisierung, spätere Wertänderung. [Theorie und Anleitung](08_Properties-und-Konstruktoren/THEORIE_UND_ANLEITUNG.md)

### 09 – Collections

- **Aufgabe:** [Aufgabenliste verwalten](09_Collections/AUFGABEN.md): Objekte hinzufügen, zählen, durchlaufen, über einen Index ändern und entfernen; **Zusatz:** Entfernen über ein Objekt und weitere Listenfälle untersuchen.
- **Theorie enthält:** `List<T>`, `Add`, `Count`, Indexzugriff, `foreach`, `RemoveAt`, `Remove`, Indexgrenzen, Listen als Methodenargument. [Theorie und Anleitung](09_Collections/THEORIE_UND_ANLEITUNG.md)

### 10 – Enums und Null

- **Aufgabe:** [Status und optionale Beschreibung](10_Enums-und-Null/AUFGABEN.md): `AufgabenStatus` als Enum einführen, Aufgaben mit verschiedenen Status anlegen und fehlende Beschreibungen beim Anzeigen ersetzen.
- **Theorie enthält:** Enums, Enum-Properties und Vergleiche, nullable Referenztypen, `null`, optionale Konstruktorargumente, `??`. [Theorie und Anleitung](10_Enums-und-Null/THEORIE_UND_ANLEITUNG.md)

### 11 – Fehler und Validierung

- **Aufgabe:** [Neue Aufgabe über das Terminal erfassen](11_Fehler-und-Validierung/AUFGABEN.md): Pflichttitel, optionale Beschreibung und gültigen Status einlesen, Eingaben prüfen und das neue Objekt zur Liste hinzufügen.
- **Theorie enthält:** Eingabeprüfung, Pflicht- und optionale Felder, `Parse`/`TryParse`, Wertebereiche, Wiederholungsschleifen, Enum-Zuordnung, Fehlerfälle. [Theorie und Anleitung](11_Fehler-und-Validierung/THEORIE_UND_ANLEITUNG.md)

### 12 – LINQ-Grundlagen

- **Aufgabe:** [Aufgaben auswerten](12_LINQ-Grundlagen/AUFGABEN.md): Aufgaben und Status zählen, nicht erledigte Aufgaben filtern und eine sortierte Ausgabe erstellen; **Zusatz:** die Reihenfolge von Filtern und Sortieren vergleichen.
- **Theorie enthält:** LINQ, `Count`, Lambda-Ausdrücke, `Where`, `OrderBy`, Methodenverkettung, `ToList`, unveränderte Ausgangsliste. [Theorie und Anleitung](12_LINQ-Grundlagen/THEORIE_UND_ANLEITUNG.md)

## Aufgaben 13–15: Blazor

### 13 – Razor und Blazor

- **Aufgabe:** [Statische Lerntracker-Seite](13_Razor-und-Blazor/AUFGABEN.md): Modelle in ein Blazor-Projekt übernehmen und eine feste Aufgabenliste mit Zähler und Status in Razor anzeigen.
- **Theorie enthält:** Blazor-Projektstart, Razor-Komponenten, Namespaces, `@code`, Werte in Markup, `@foreach`, HTML-Struktur, statisches gegenüber interaktivem Rendern. [Theorie und Anleitung](13_Razor-und-Blazor/THEORIE_UND_ANLEITUNG.md)

### 14 – Blazor-Interaktionen

- **Aufgabe:** [Interaktiver Lerntracker](14_Blazor-Interaktionen/AUFGABEN.md): Formularwerte binden, Eingaben prüfen, Aufgaben hinzufügen und einzelne Aufgaben per Schaltfläche erledigen.
- **Theorie enthält:** Interaktivitätsmodus, Komponentenzustand, `@bind`, Formulare, Ereignisse und Lambda-Ausdrücke, Validierung, bedingte Anzeige, erneutes Rendern. [Theorie und Anleitung](14_Blazor-Interaktionen/THEORIE_UND_ANLEITUNG.md)

### 15 – Blazor-Komponenten

Die drei Teile sind [eigenständige Blazor-Projekte](15_Blazor-Komponenten/README.md):

- **15.01 Farbwahl:** [Auswahl und Vorschau](15_Blazor-Komponenten/01_Farbwahl/AUFGABEN.md) als Geschwisterkomponenten verbinden: Die Auswahl meldet eine Farbe, `Home` speichert sie und die Vorschau zeigt sie. **Theorie enthält:** Elternzustand, `[Parameter]`, `EventCallback<string>`, Datenfluss zwischen Geschwistern, Werte aus `foreach`, Fehlersuche. [Theorie](15_Blazor-Komponenten/01_Farbwahl/THEORIE_UND_ANLEITUNG.md)
- **15.02 Temperaturregler:** [Schrittknopf, Regler und Home](15_Blazor-Komponenten/02_Temperaturregler/AUFGABEN.md) verbinden: Ein Knopf meldet einen Schritt an den Regler, dieser reicht ihn an `Home` weiter; die Anzeige erhält den neuen Wert. **Theorie enthält:** Komponentenparameter, `@onclick`, `EventCallback<int>`, Weitergabemethoden, Zustandsbesitz, Ereigniskette, `Task`. [Theorie](15_Blazor-Komponenten/02_Temperaturregler/THEORIE_UND_ANLEITUNG.md)
- **15.03 LernaufgabenTracker:** [Teil A: Aufgabenkarte](15_Blazor-Komponenten/03_LernaufgabenTracker/AUFGABEN.md) auslagern und Erledigen zurückmelden; **Teil B: Formular** auslagern, Eingaben prüfen und neue Aufgabe an `Home` melden. **Theorie enthält:** Razor-Komponenten, eine Zustandsquelle, Daten und Ereignisse zwischen Eltern und Kindern, `EventCallback<TaskItem>`, Formularzustand, Namespaces, Interaktivität. [Theorie](15_Blazor-Komponenten/03_LernaufgabenTracker/THEORIE_UND_ANLEITUNG.md)

## Aufgabe 16 – Persistenz und Datenbanken

Die [Kapitelübersicht](16_Persistenz-und-Datenbanken/UEBERSICHT.md) gibt die Reihenfolge vor. Die beiden Speicherwege in 16.03 und 16.04 sind eigenständige Varianten.

### 16.01 – Async und Await

- **16.01.01 Async-Grundlagen in der Konsole:** [Aufgaben 1–5](16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/AUFGABEN.md): Ausgabeablauf vorhersagen; eine Methode mit `Task` erstellen; einen Wert mit `Task<int>` laden; Fehler nach `await` behandeln; Reihenfolge erklären. **Zusatz:** unabhängige Vorgänge zusammen ausführen. **Theorie enthält:** `Task`, `Task<T>`, `async`/`await`, `Task.Delay`, Aufrufkette, `Task.WhenAll`, Exceptions, `async void`, blockierendes Warten. [Theorie](16_Persistenz-und-Datenbanken/01_Async-und-Await/01_Einfache-Uebung/THEORIE_UND_ANLEITUNG.md)
- **16.01.02 Lerntracker asynchron machen:** [Aufgaben 1–7](16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/AUFGABEN.md): Startaufgaben asynchron laden; Ladezustand anzeigen; Speichern simulieren; Oberfläche beim Speichern sperren; Fehler weitergeben; Fehler im Formular und in der Karte behandeln; Fehlerfall testen. **Theorie enthält:** `OnInitializedAsync`, Lade- und Speicherzustand, `try`/`catch`/`finally`, asynchrone Eventmethoden, Fehler über Callbacks, Aktualisierung der Oberfläche. [Theorie](16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/THEORIE_UND_ANLEITUNG.md)

### 16.02 – MariaDB mit Docker und DBeaver vorbereiten

- **Anleitung:** [Docker und DBeaver einrichten](16_Persistenz-und-Datenbanken/02_MariaDB-Docker-und-DBeaver/ANLEITUNG.md), MariaDB-Container mit dauerhaftem Volume starten und die Verbindung prüfen. **Anleitung enthält:** Grundbegriffe, Voraussetzungen, `.env`, `compose.yaml`, Containerbefehle, Verbindungstest, häufige Probleme.

### 16.03 – LocalStorage

- **Aufgaben 1–5:** [Browser-Speicherung ergänzen](16_Persistenz-und-Datenbanken/03_LocalStorage/AUFGABEN.md): Schlüssel und JS-Zugriff vorbereiten; Aufgaben als JSON speichern; beim Start laden; Ladezustand anzeigen; Änderungen mit Fehlerbehandlung speichern. **Zusatz:** gespeicherte Daten löschen, Fehlerfälle und Datenversionen untersuchen. **Theorie enthält:** `localStorage`, Schlüssel/Werte, JSON, JS-Interop, `OnAfterRenderAsync`, Prerendering, Ladezustand, Speichern nach Änderungen, Browser-Werkzeuge, Grenzen. [Theorie](16_Persistenz-und-Datenbanken/03_LocalStorage/THEORIE_UND_ANLEITUNG.md)

### 16.04 – MariaDB und Dapper

- **Aufgaben 1–9:** [Datenbank-Speicherung ergänzen](16_Persistenz-und-Datenbanken/04_MariaDB-und-Dapper/AUFGABEN.md): Datenbank, Benutzer und Tabelle anlegen; Pakete installieren; Verbindungsdaten hinterlegen; Modell anpassen; Repository für Laden, Anlegen und Erledigen schreiben; Dependency Injection einrichten; Laden und beide Schreibvorgänge mit der Oberfläche verbinden. **Zusatz:** weitere Datenbankfunktionen und Fehlerfälle. **Theorie enthält:** SQL-Schema, Dapper, MySqlConnector, User Secrets, IDs, Repository, SQL-Abfragen und Parameter, Dependency Injection, asynchrone Datenzugriffe, Tests. [Theorie](16_Persistenz-und-Datenbanken/04_MariaDB-und-Dapper/THEORIE_UND_ANLEITUNG.md)
