# Aufgaben – Den Lerntracker asynchron machen

## Ausgangslage

Das Projekt enthält den fertig komponentisierten Lerntracker aus Lektion 15. Es funktioniert vollständig im Arbeitsspeicher.

Die Elternmethoden in `Home.razor` sind noch synchron. Du baust nun die Async-Struktur, die in LocalStorage und Dapper weiterverwendet wird.

## Startcheck

```powershell
dotnet build
dotnet run
```

Teste vor der Änderung:

- Aufgaben werden sofort angezeigt.
- Eine Aufgabe kann hinzugefügt werden.
- Eine Aufgabe kann erledigt werden.
- Es gibt noch keine sichtbaren Lade- oder Speicherzeiten.

## Vereinbarte Dateien

Bearbeite:

- `Components/Pages/Home.razor`
- `Components/AufgabenFormular.razor`
- `Components/AufgabenKarte.razor`

Die Dateien in `Models` werden nicht verändert.

## Aufgabe 1: Startaufgaben asynchron laden

Verschiebe die Erzeugung der drei Startaufgaben aus dem Listenfeld in eine eigene Methode:

```text
StartaufgabenLadenAsync
```

Anforderungen:

- Rückgabetyp ist `Task<List<TaskItem>>`.
- Die Methode wartet ungefähr 800 Millisekunden mit `Task.Delay`.
- Danach gibt sie die drei bisherigen Startaufgaben als Liste zurück.
- Das Feld `aufgaben` startet als leere Liste.
- Überschreibe `OnInitializedAsync`.
- Weise darin das Ergebnis der Lademethode nach einem `await` dem Listenfeld zu.

## Aufgabe 2: Ladezustand anzeigen

Ergänze in `Home`:

- `ladevorgangLaeuft`, anfangs `true`,
- `ladefehler`, anfangs `null`.

Umschließe den Ladeaufruf mit `try`, `catch` und `finally`:

- `try` lädt und übernimmt die Liste.
- `catch` setzt eine verständliche Meldung.
- `finally` beendet den Ladezustand.

Passe das Markup an:

1. Während des Ladens erscheint nur `Aufgaben werden geladen ...`.
2. Bei einem Ladefehler erscheint die Fehlermeldung.
3. Nur bei erfolgreichem Laden erscheinen Formular, Anzahl und Karten.

## Aufgabe 3: Speichern simulieren

Erstelle eine Methode:

```text
AenderungSpeichernAsync
```

Anforderungen:

- Sie gibt `Task` zurück.
- Sie wartet ungefähr 600 Millisekunden.
- Sie verändert selbst keine Aufgabe und keine Liste.

Mache danach beide Home-Eventmethoden asynchron:

- `AufgabeHinzufuegen`
- `AufgabeErledigen`

Reihenfolge beim Hinzufügen:

1. simulierten Speichervorgang abwarten,
2. neue Aufgabe zur Liste hinzufügen.

Reihenfolge beim Erledigen:

1. simulierten Speichervorgang abwarten,
2. Status des richtigen Objekts ändern.

Beide Methoden geben `Task` statt `void` zurück.

## Aufgabe 4: Oberfläche während des Speicherns sperren

Ergänze in `Home` das Feld:

```text
speichervorgangLaeuft
```

Prüfe am Anfang jeder speichernden Eventmethode, ob das Feld bereits `true` ist. Wirf dann eine verständliche `InvalidOperationException`, damit die Kindkomponente den doppelten Aufruf als erwarteten Fehler behandeln kann. Setze das Feld anschließend auf `true` und in einem `finally`-Block zurück auf `false`.

Ergänze in beiden Kindkomponenten einen booleschen Parameter `Deaktiviert`.

Anforderungen für das Formular:

- Texteingabe ist deaktiviert.
- Textarea ist deaktiviert.
- Statusauswahl ist deaktiviert.
- Submit-Button ist deaktiviert.

Anforderungen für die Karte:

- Erledigt-Button ist deaktiviert.

`Home` übergibt seinen Speicherzustand an beide Komponenten.

Teste einen schnellen Doppelklick. Eine Aufgabe darf nicht zweimal entstehen.

## Aufgabe 5: Fehler verständlich weitergeben

Erweitere beide speichernden Home-Methoden um einen `catch`-Block.

Bei einem technischen Fehler:

- Liste beziehungsweise Status bleiben unverändert.
- Wirf eine neue `InvalidOperationException` mit einer verständlichen Meldung.
- Übergib die ursprüngliche Exception als innere Exception.
- Der `finally`-Block gibt die Oberfläche trotzdem wieder frei.

Verwende unterschiedliche Meldungen:

- Aufgabe konnte nicht gespeichert werden.
- Status konnte nicht gespeichert werden.

## Aufgabe 6: Fehler in den Kindkomponenten behandeln

### AufgabenFormular

Umschließe den vorhandenen `InvokeAsync`-Aufruf mit `try` und `catch`.

- Setze die Eingabefelder nur nach einem erfolgreichen Callback zurück.
- Fange `InvalidOperationException`.
- Zeige ihre verständliche Nachricht mit der bereits vorhandenen `fehlermeldung`.
- Bei einem Fehler bleiben die Eingaben erhalten.

### AufgabenKarte

Ergänze eine lokale nullable Fehlermeldung.

- Fange beim Erledigt-Callback eine `InvalidOperationException`.
- Zeige die Meldung innerhalb der Karte mit `role="alert"`.
- Lösche eine alte Meldung nach einem erfolgreichen Versuch.

## Aufgabe 7: Fehlerfall bewusst testen

Setze vorübergehend an den Anfang von `AenderungSpeichernAsync`:

```csharp
throw new InvalidOperationException(
    "Simulierter Speicherfehler"
);
```

Prüfe Hinzufügen und Erledigen.

Danach muss gelten:

- Keine nicht gespeicherte Änderung erscheint in der Liste.
- Eine verständliche Meldung erscheint.
- Formulareingaben bleiben bei fehlgeschlagenem Hinzufügen erhalten.
- Die Bedienelemente sind nach dem Fehler wieder aktiv.
- Die Anwendung läuft weiter.

Entferne die Test-Exception anschließend wieder.

## Funktionstest

- Beim Start ist die Ladeanzeige ungefähr 800 Millisekunden sichtbar.
- Danach erscheinen genau drei Startaufgaben.
- Hinzufügen dauert sichtbar ungefähr 600 Millisekunden.
- Währenddessen sind Eingaben und Buttons deaktiviert.
- Die Aufgabe erscheint erst nach dem simulierten Speichern.
- Erledigen verändert den Status erst nach dem simulierten Speichern.
- Ein Doppelklick erzeugt keine doppelte Änderung.
- Fehler werden verständlich angezeigt.
- Statusfelder werden durch `finally` zurückgesetzt.
- Es gibt keine eigene `async void`-Methode.
- Das Projekt baut ohne Fehler und Warnungen.

## Kontrollfragen

1. Warum startet `aufgaben` nun als leere Liste?
2. Warum gibt die Lademethode `Task<List<TaskItem>>` zurück?
3. Warum wird die Liste erst hinter `await` verändert?
4. Warum gehört das Zurücksetzen des Speicherzustands in `finally`?
5. Warum wartet das Formular auf `OnAufgabeErstellt.InvokeAsync`?
6. Was würde passieren, wenn das Formular seine Felder schon vor dem `await` leert?
7. Welche zwei simulierten Methoden werden in den nächsten Übungen durch echten Speicher ersetzt?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "16_Persistenz-und-Datenbanken/01_Async-und-Await/02_Lerntracker-Async/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet. Voraussetzung ist, dass dieser Starterordner im Git-Tag `uebungen-start` enthalten ist.
