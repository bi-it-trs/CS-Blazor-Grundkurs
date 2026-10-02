# Aufgaben – Blazor-Formulare und vollständiges CRUD

> **Wichtig vor Übung 17:** Die User Secrets aus Übung 16.04 werden nicht automatisch übernommen. Dieses Projekt hat eine eigene `UserSecretsId`. Setze den Connection String im Ordner `17_Blazor-Formulare-und-CRUD` einmal erneut; `dotnet user-secrets init` ist hier nicht nötig. Der MariaDB-Container sowie Datenbank, Tabelle und Benutzer `lernapp` aus Übung 16 müssen weiterhin vorhanden sein.

```powershell
dotnet user-secrets set "ConnectionStrings:MariaDb" "Server=localhost;Port=DEIN_HOST_PORT;Database=lerntracker;User ID=lernapp;Password=DEIN_PASSWORT"
```

Ersetze `DEIN_HOST_PORT` durch den tatsächlich veröffentlichten Host-Port des Lerntracker-Containers (`docker compose ps` oder Docker Desktop). Ersetze `DEIN_PASSWORT` durch das Passwort von `lernapp`, nicht durch das Root-Passwort. Der Eintrag bleibt für dieses Projekt auf deinem Rechner gespeichert; bei jedem Start musst du ihn nicht neu setzen.

## Ausgangslage

Dieses Projekt enthält die Musterlösung aus Lektion 16.04.

Bereits vorhanden:

- MariaDB-Schema,
- Dapper und MySqlConnector,
- Repository und Dependency Injection,
- Aufgaben aus MariaDB laden,
- Aufgaben erstellen,
- Aufgaben als erledigt markieren,
- asynchrone Lade-, Speicher- und Fehlerzustände.

Noch nicht vorhanden:

- `EditForm` und DataAnnotations,
- allgemeines Bearbeiten,
- Löschen,
- Filter,
- Sortierung,
- differenzierte Leerzustände.

## Ziel

Vervollständige die Anwendung zu CRUD und verwende ein Formular sowohl für neue als auch für bestehende Aufgaben.

## Startcheck

Der MariaDB-Container aus Lektion 16 muss laufen. Die Datenbank und Tabelle müssen vorhanden sein. Der Connection String muss wie oben beschrieben für dieses Projekt gesetzt sein.

Danach:

```powershell
dotnet build
dotnet run
```

Prüfe den Ausgangsstand:

- Daten aus MariaDB erscheinen.
- Eine Aufgabe kann angelegt werden.
- Die erzeugte ID erscheint nach einem Neuladen weiterhin korrekt.
- Eine Aufgabe kann als erledigt markiert werden.

## Vereinbarte Struktur

Vorhanden:

- `Components/Pages/Home.razor`
- `Components/AufgabenFormular.razor`
- `Components/AufgabenKarte.razor`
- `Data/TaskItemRepository.cs`
- `Database/01_schema.sql`
- `Models/TaskItem.cs`
- `Models/AufgabenStatus.cs`

Von dir zu erstellen:

- `Models/TaskItemFormularModell.cs`
- `Models/AufgabenSortierung.cs`

Benenne die vorhandenen Modelle, Komponenten und Datenbankspalten nicht um.

## Etappe 1: Formularmodell mit Validierung

Erstelle `TaskItemFormularModell`.

Benötigte Properties:

- `Id`
- `Titel`
- `Beschreibung`
- `Status`

Validierungsregeln:

- Titel ist erforderlich.
- Titel besitzt höchstens 200 Zeichen.
- Beschreibung ist optional.
- Beschreibung besitzt höchstens 2000 Zeichen.
- Status beginnt mit `Offen`.

Verwende Attribute aus `System.ComponentModel.DataAnnotations` und formuliere verständliche deutsche Fehlermeldungen.

Baue danach das Projekt, bevor du das Formular veränderst.

## Etappe 2: Manuelles Formular durch `EditForm` ersetzen

Ersetze in `AufgabenFormular.razor` den normalen HTML-Formularblock.

Anforderungen:

- `EditForm` erhält ein `TaskItemFormularModell` über `Model`.
- Verwende `OnValidSubmit`.
- Füge `DataAnnotationsValidator` hinzu.
- Zeige eine `ValidationSummary`.
- Verwende `InputText` für den Titel.
- Verwende `InputTextArea` für die Beschreibung.
- Verwende `InputSelect` für den Status.
- Zeige mindestens für Titel und Beschreibung eine `ValidationMessage`.
- Alle Eingaben und Buttons beachten weiterhin `Deaktiviert`.
- Entferne die bisherige manuelle Leertextprüfung.
- Verwende keinen zusätzlichen äußeren `form`-Tag.

Teste:

- leerer Titel,
- Titel nur aus Leerzeichen,
- Titel länger als 200 Zeichen,
- gültiger Titel ohne Beschreibung,
- Beschreibung länger als 2000 Zeichen.

## Etappe 3: Formular auf Erstellen und Bearbeiten vorbereiten

Ergänze in `AufgabenFormular`:

- optionalen Parameter `AufgabeZumBearbeiten`,
- Callback `OnAufgabeGespeichert`,
- Callback `OnBearbeitungAbgebrochen`,
- berechnete Property `IstBearbeitung`,
- Feld `geladeneId`.

Ersetze den bisherigen Callback `OnAufgabeErstellt` durch `OnAufgabeGespeichert`.

Überschreibe `OnParametersSet`:

- Bei neuer positiver ID werden die Werte in ein neues Formularmodell kopiert.
- Bei `null` wird ein leeres Formularmodell verwendet.
- Derselbe Parameter darf laufende Eingaben nicht bei jedem Rendern erneut überschreiben.
- Binde niemals das empfangene `TaskItem` direkt an die Eingabefelder.

Passe Überschrift und Buttontext an:

```text
Erstellen:  Neue Aufgabe / Hinzufügen
Bearbeiten: Aufgabe bearbeiten / Änderungen speichern
```

Zeige den Abbrechen-Button nur im Bearbeitungsmodus.

## Etappe 4: Gültige Formulardaten melden

Erstelle in der Submit-Methode ein neues `TaskItem` aus dem Formularmodell.

Anforderungen:

- Titel wird mit `Trim()` bereinigt.
- Leere oder nur aus Leerzeichen bestehende Beschreibung wird `null`.
- ID wird übernommen.
- Status wird übernommen.
- `OnAufgabeGespeichert` wird asynchron abgewartet.
- Ein neues Formular wird nur nach erfolgreichem Erstellen geleert.
- Eine `InvalidOperationException` wird als verständliche Fehlermeldung angezeigt.
- Bei einem Fehler bleiben die Eingaben erhalten.

Der Abbrechen-Button ruft nur `OnBearbeitungAbgebrochen` auf. Die Auswahl gehört weiterhin `Home`.

## Etappe 5: Allgemeines UPDATE implementieren

Ergänze in `TaskItemRepository`:

```text
AktualisierenAsync(TaskItem aufgabe)
```

Die SQL-Anweisung aktualisiert:

- Titel,
- Beschreibung,
- Status.

Anforderungen:

- Auswahl der Zeile ausschließlich über `WHERE Id = @Id`.
- Alle Werte als Parameter übergeben.
- Enum als Zahl speichern.
- Verbindung mit `await using` freigeben.
- Prüfen, dass genau eine Zeile betroffen wurde.
- Bei null oder mehreren betroffenen Zeilen eine Exception auslösen.

Kontrolliere deine UPDATE-Anweisung besonders vor dem Ausführen. Eine fehlende WHERE-Bedingung würde alle Zeilen verändern.

## Etappe 6: Erstellen und Bearbeiten in Home verbinden

Ergänze in `Home`:

- nullable Feld `aufgabeInBearbeitung`,
- Methode zum Auswählen einer Aufgabe,
- Methode zum Abbrechen der Bearbeitung.

Ersetze `AufgabeHinzufuegen` durch eine gemeinsame asynchrone Methode `AufgabeSpeichern`.

Wenn `Id == 0`:

1. `Repository.ErstellenAsync` aufrufen.
2. Erfolgreich gespeichertes Objekt zur Liste hinzufügen.

Wenn `Id > 0`:

1. `Repository.AktualisierenAsync` aufrufen.
2. Objekt mit derselben ID in der sichtbaren Liste finden.
3. Dieses Listenobjekt durch das neue Objekt ersetzen.
4. Bearbeitungsmodus beenden.

Behalte bei:

- Doppelklickschutz,
- `speichervorgangLaeuft`,
- verständliche Exception,
- Zurücksetzen in `finally`,
- sichtbare Liste erst nach erfolgreicher Datenbankoperation verändern.

Verbinde die neuen Parameter und Callbacks mit `AufgabenFormular`.

## Etappe 7: Bearbeiten-Button in der Karte

Ergänze `AufgabenKarte` um:

```text
OnBearbeiten
```

Der Bearbeiten-Button:

- ist ein Button vom Typ `button`,
- beachtet `Deaktiviert`,
- meldet genau die Aufgabe dieser Karte,
- verändert selbst keine Property.

Verbinde den Callback in `Home` mit der Auswahlmethode.

Funktionstest:

1. Aufgabe zum Bearbeiten auswählen.
2. Formular zeigt eine Kopie der vorhandenen Werte.
3. Titel, Beschreibung und Status ändern.
4. Speichern.
5. Karte zeigt neue Werte.
6. DBeaver zeigt dieselben Werte.
7. Browser neu laden.
8. Änderungen bleiben erhalten.
9. Bearbeitung starten, Werte ändern und abbrechen.
10. Die ursprüngliche Aufgabe bleibt unverändert.

## Etappe 8: DELETE im Repository

Ergänze:

```text
LoeschenAsync(int id)
```

Anforderungen:

- parametrisierte DELETE-Anweisung,
- WHERE-Bedingung mit ID,
- Verbindung korrekt freigeben,
- genau eine betroffene Zeile erwarten,
- fehlende Aufgabe als Fehler behandeln.

## Etappe 9: Sicheres Löschen in Karte und Home

Ergänze `AufgabenKarte` um:

- Callback `OnLoeschen`,
- lokalen booleschen Bestätigungszustand,
- ersten Löschen-Button,
- Bestätigen-Button,
- Abbrechen-Button,
- lokale Fehlermeldung bei fehlgeschlagenem Löschen.

Der erste Klick darf noch nichts aus der Datenbank löschen.

Ergänze in `Home` die asynchrone Löschmethode:

1. Doppelklickschutz prüfen.
2. Speicherzustand aktivieren.
3. Repository aufrufen.
4. Objekt erst nach erfolgreichem DELETE aus der Liste entfernen.
5. Bearbeitungsmodus beenden, falls genau diese Aufgabe bearbeitet wurde.
6. Fehler verständlich weitergeben.
7. Speicherzustand in `finally` zurücksetzen.

Verwende bei jeder Kartenkomponente:

```razor
@key="aufgabe.Id"
```

Teste Löschen sowohl normal als auch während die Aufgabe im Formular ausgewählt ist.

## Etappe 10: Filter ergänzen

Ergänze in `Home`:

```text
AufgabenStatus? statusFilter
```

Erstelle eine Auswahl mit:

- Alle,
- Offen,
- In Arbeit,
- Erledigt.

`null` steht für Alle.

Die ursprüngliche Liste darf durch das Filtern nicht überschrieben oder verändert werden.

## Etappe 11: Sortierung ergänzen

Erstelle `Models/AufgabenSortierung.cs` mit:

- `NeuesteZuerst`,
- `AeltesteZuerst`,
- `TitelAufsteigend`.

Ergänze eine Sortierungsauswahl in `Home`.

Berechne `SichtbareAufgaben`:

1. mit der vollständigen Liste beginnen,
2. optional mit `Where` nach Status filtern,
3. anschließend passend sortieren,
4. das Ergebnis zurückgeben.

Verwende `SichtbareAufgaben` in der `foreach`-Schleife.

## Etappe 12: Zähler und Leerzustände

Zeige unabhängig vom Filter:

- Gesamtzahl,
- Anzahl noch nicht erledigter Aufgaben,
- Anzahl erledigter Aufgaben.

Unterscheide:

- Datenbank enthält keine Aufgaben.
- Aufgaben existieren, aber keine passt zum Filter.

Formuliere für beide Situationen eine passende Meldung.

## Gesamttest CRUD

### Create

- gültige Aufgabe anlegen,
- erzeugte Datenbank-ID prüfen,
- ungültige Eingabe wird nicht gespeichert,
- Formular wird nur bei Erfolg geleert.

### Read

- App neu starten,
- alle Daten werden aus MariaDB geladen,
- Ladeanzeige verschwindet,
- Ladefehler wird verständlich angezeigt.

### Update

- Titel bearbeiten,
- Beschreibung hinzufügen und entfernen,
- Status ändern,
- Abbrechen verändert nichts,
- Änderungen überleben einen Neustart.

### Delete

- Löschen zunächst abbrechen,
- danach bestätigen,
- genau eine Datenbankzeile verschwindet,
- gelöschte Aufgabe bleibt nach Neustart verschwunden.

### Filter und Sortierung

- jeder Statusfilter zeigt nur passende Aufgaben,
- Alle zeigt wieder die vollständige Liste,
- jede Sortierung liefert die erwartete Reihenfolge,
- Filter und Sortierung funktionieren gemeinsam,
- Zähler bleiben unabhängig vom Filter korrekt.

### Stabilität

- Buttons sind während des Speicherns deaktiviert,
- kein Doppelklick erzeugt doppelte Operationen,
- Datenbankfehler verändern die sichtbare Liste nicht,
- SQL enthält keine verketteten Benutzereingaben,
- die Anwendung arbeitet nicht mit dem Root-Benutzer,
- `dotnet build` endet ohne Codefehler.

## Kontrollfragen

1. Warum wird ein separates Formularmodell verwendet?
2. Was unterscheidet `OnValidSubmit` von einem normalen Submit-Ereignis?
3. Warum darf UPDATE nicht ohne WHERE-Bedingung ausgeführt werden?
4. Warum wird das sichtbare Objekt erst nach erfolgreichem UPDATE ersetzt?
5. Warum benötigt jede Aufgabe eine eindeutige ID?
6. Warum soll DELETE genau eine betroffene Zeile melden?
7. Warum wird `@key` mit der ID gesetzt?
8. Warum darf Filtern die ursprüngliche Liste nicht überschreiben?
9. Welche Verantwortung haben Komponente, Repository und Datenbank jeweils?
10. Welche vier Operationen bilden CRUD?

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
