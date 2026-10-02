# Theorie und Anleitung – Async/Await im Lerntracker

## Lernziel

Du überträgst die Async-Grundlagen auf den komponentisierten Lerntracker aus Lektion 15.

Der Lerntracker verwendet noch keinen echten Speicher. Langsame Lese- und Schreibvorgänge werden mit `Task.Delay` simuliert. Dadurch kannst du den Ablauf sehen, bevor LocalStorage oder MariaDB dazukommen.

Nach der Übung kann die Oberfläche:

- beim Start asynchron Aufgaben laden,
- währenddessen eine Ladeanzeige zeigen,
- beim Speichern weitere Eingaben vorübergehend sperren,
- Zustände erst nach erfolgreichem Warten verändern,
- Fehler behandeln und Statusfelder mit `finally` zurücksetzen.

## Ausgangslage

Das Projekt entspricht dem abgeschlossenen Komponentenstand aus Lektion 15:

- `Home` besitzt die Aufgabenliste.
- `AufgabenFormular` meldet ein neues `TaskItem` nach oben.
- `AufgabenKarte` meldet den Erledigt-Klick nach oben.
- `Home` verändert die Liste und den Status.

Die Methoden in `Home` sind noch synchron:

```csharp
private void AufgabeHinzufuegen(TaskItem neueAufgabe)
{
    aufgaben.Add(neueAufgabe);
}
```

In den Kindkomponenten kommt Async bereits vor:

```csharp
await OnAufgabeErstellt.InvokeAsync(neueAufgabe);
```

Bis jetzt war das nur für den EventCallback nötig. Nun führt die Elternkomponente selbst langsame Arbeit aus.

## Der geplante Ablauf

Beim Start:

```text
Komponente beginnt Initialisierung
→ Ladezustand ist aktiv
→ Startaufgaben werden asynchron geladen
→ Liste wird übernommen
→ Ladezustand wird beendet
→ Liste wird dargestellt
```

Beim Hinzufügen:

```text
Formular meldet TaskItem
→ Home startet Speicherzustand
→ Home wartet auf Speichervorgang
→ Home fügt Objekt nur bei Erfolg zur Liste hinzu
→ Home beendet Speicherzustand
→ Callback ist abgeschlossen
→ Formular darf Eingaben zurücksetzen
```

## Asynchrone Lebenszyklusmethode

Blazor ruft `OnInitializedAsync` beim Initialisieren einer Komponente auf:

```csharp
protected override async Task OnInitializedAsync()
{
    aufgaben = await StartaufgabenLadenAsync();
}
```

Diese Lebenszyklusmethode ist für serverseitig erreichbare Daten geeignet, beispielsweise später für MariaDB.

LocalStorage ist eine Besonderheit: Es befindet sich im Browser und steht beim serverseitigen Prerendering noch nicht zur Verfügung. Deshalb verwendet die spätere LocalStorage-Übung stattdessen `OnAfterRenderAsync`.

## Laden zunächst simulieren

Eine Hilfsmethode simuliert einen langsamen Speicher:

```csharp
private static async Task<List<TaskItem>>
    StartaufgabenLadenAsync()
{
    await Task.Delay(800);

    return new List<TaskItem>
    {
        new TaskItem(
            "Async verstehen",
            "Erst simulieren wir langsame Speicherzugriffe",
            AufgabenStatus.InArbeit
        ),
        new TaskItem(
            "Persistenz vorbereiten",
            null,
            AufgabenStatus.Offen
        )
    };
}
```

Die Methode gibt `Task<List<TaskItem>>` zurück, weil die Liste erst nach dem asynchronen Vorgang verfügbar ist.

Die Liste in `Home` startet dafür leer:

```csharp
private List<TaskItem> aufgaben = new List<TaskItem>();
```

## Ladezustand abbilden

Ein boolesches Feld beschreibt den Zustand:

```csharp
private bool ladevorgangLaeuft = true;
```

Das Markup reagiert darauf:

```razor
@if (ladevorgangLaeuft)
{
    <p role="status">Aufgaben werden geladen ...</p>
}
else
{
    <!-- Formular, Anzahl und Karten -->
}
```

Das Feld ist nicht nur Dekoration. Solange die Daten noch nicht geladen sind, soll der Benutzer keine Änderungen an einer unvollständigen Liste auslösen.

## `try`, `catch` und `finally` beim Laden

```csharp
private string? ladefehler;

protected override async Task OnInitializedAsync()
{
    try
    {
        aufgaben = await StartaufgabenLadenAsync();
    }
    catch (Exception)
    {
        ladefehler = "Die Aufgaben konnten nicht geladen werden.";
    }
    finally
    {
        ladevorgangLaeuft = false;
    }
}
```

Warum `finally`?

- Bei Erfolg muss die Ladeanzeige verschwinden.
- Bei Fehler muss die Ladeanzeige ebenfalls verschwinden.
- Ohne `finally` könnte ein vergessener Zweig die Oberfläche dauerhaft im Ladezustand lassen.

Die technische Exception wird hier nicht direkt an Benutzer ausgegeben. Interne Informationen, Servernamen oder SQL-Texte gehören nicht in eine öffentliche Fehlermeldung.

## Ladefehler anzeigen

Nach dem Ladezustand wird unterschieden:

```razor
@if (ladevorgangLaeuft)
{
    <p role="status">Aufgaben werden geladen ...</p>
}
else if (ladefehler is not null)
{
    <p role="alert">@ladefehler</p>
}
else
{
    <!-- normale Oberfläche -->
}
```

Bei einem Ladefehler wird nicht so getan, als wäre eine leere Aufgabenliste erfolgreich geladen worden.

## Speichern simulieren

Für Hinzufügen und Erledigen genügt zunächst eine gemeinsame Simulation:

```csharp
private static async Task AenderungSpeichernAsync()
{
    await Task.Delay(600);
}
```

In den nächsten Übungen wird nur der Inhalt dieser Speicherlogik durch LocalStorage beziehungsweise Repository-Aufrufe ersetzt.

## Zustandsänderung erst nach erfolgreichem Await

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    await AenderungSpeichernAsync();
    aufgaben.Add(neueAufgabe);
}
```

Die Reihenfolge ist wichtig:

```text
erst speichern
→ danach sichtbaren Zustand verändern
```

Wenn du das Objekt zuerst zur Liste hinzufügst und der echte Speicher später fehlschlägt, zeigt die Oberfläche einen Zustand, der nie dauerhaft gespeichert wurde.

Dasselbe gilt für den Status:

```csharp
private async Task AufgabeErledigen(TaskItem aufgabe)
{
    await AenderungSpeichernAsync();
    aufgabe.Status = AufgabenStatus.Erledigt;
}
```

## Speicherzustand gegen Doppelklicks

```csharp
private bool speichervorgangLaeuft;
```

Prüfe am Anfang jeder speichernden Methode zusätzlich, ob bereits ein Vorgang läuft:

```csharp
if (speichervorgangLaeuft)
{
    throw new InvalidOperationException(
        "Eine Änderung wird bereits gespeichert."
    );
}
```

Das ist der Schutz in der Logik. Die Exception wird wie die anderen erwarteten Speicherfehler in der auslösenden Kindkomponente angezeigt. Die deaktivierten Buttons sind zusätzlich sichtbares Feedback für den Benutzer.

Die Elternmethode setzt ihn mit `try` und `finally`:

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    speichervorgangLaeuft = true;

    try
    {
        await AenderungSpeichernAsync();
        aufgaben.Add(neueAufgabe);
    }
    finally
    {
        speichervorgangLaeuft = false;
    }
}
```

Ohne Sperre kann ein schneller Doppelklick denselben Vorgang mehrfach starten.

## Zustand an Kindkomponenten weitergeben

Das Formular benötigt einen Parameter:

```csharp
[Parameter]
public bool Deaktiviert { get; set; }
```

Verwende ihn an den Eingaben und am Button:

```razor
<input @bind="titel" disabled="@Deaktiviert" />
<textarea @bind="beschreibung"
          disabled="@Deaktiviert"></textarea>
<select @bind="status" disabled="@Deaktiviert">
    ...
</select>
<button type="submit" disabled="@Deaktiviert">
    Aufgabe hinzufügen
</button>
```

Auch die Karte bekommt denselben Parameter und deaktiviert ihren Erledigt-Button.

`Home` reicht das Feld nach unten:

```razor
<AufgabenFormular
    Deaktiviert="@speichervorgangLaeuft"
    OnAufgabeErstellt="AufgabeHinzufuegen" />
```

```razor
<AufgabenKarte
    Aufgabe="@aufgabe"
    Deaktiviert="@speichervorgangLaeuft"
    OnErledigt="AufgabeErledigen" />
```

## Warum Home-Eventmethoden `Task` zurückgeben

Der Callback wartet auf die verbundene Elternmethode. Deshalb darf diese Methode `Task` zurückgeben:

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
```

Der Ablauf bleibt verbunden:

```text
AufgabenFormular.Absenden
→ await EventCallback.InvokeAsync
→ Home.AufgabeHinzufuegen
→ await Speichervorgang
→ Home-Methode endet
→ InvokeAsync endet
→ Formular setzt Eingaben zurück
```

Das Formular setzt seine Eingaben deshalb erst hinter dem `await` zurück. Es wartet tatsächlich auf die Elternkomponente.

## Fehler über den Callback melden

Eine echte Speicheroperation kann scheitern. `Home` kennt die technische Operation und übersetzt sie in eine verständliche Exception:

```csharp
try
{
    await AenderungSpeichernAsync();
    aufgaben.Add(neueAufgabe);
}
catch (Exception exception)
{
    throw new InvalidOperationException(
        "Die Aufgabe konnte nicht gespeichert werden.",
        exception
    );
}
finally
{
    speichervorgangLaeuft = false;
}
```

Das Formular behandelt diese erwartete Anwendungsfehlermeldung:

```csharp
try
{
    await OnAufgabeErstellt.InvokeAsync(neueAufgabe);

    titel = string.Empty;
    beschreibung = null;
    status = AufgabenStatus.Offen;
    fehlermeldung = null;
}
catch (InvalidOperationException exception)
{
    fehlermeldung = exception.Message;
}
```

Die Eingaben werden nur im erfolgreichen `try`-Zweig geleert. Bei einem Fehler kann der Benutzer sie erneut absenden.

Die Karte verwendet denselben Grundgedanken für den Erledigt-Klick und besitzt dafür eine eigene lokale Fehlermeldung.

## Fehlerfall sichtbar testen

Während der Übung kannst du am Anfang der simulierten Speichermethode vorübergehend werfen:

```csharp
throw new InvalidOperationException(
    "Simulierter Speicherfehler"
);
```

Prüfe:

- Die App bleibt bedienbar.
- Eine verständliche Meldung erscheint.
- Die neue Aufgabe wurde nicht hinzugefügt.
- Der Status wurde nicht verändert.
- Die Buttons werden nach dem Fehler wieder freigegeben.

Entferne die Test-Exception danach wieder. Die fertige Simulation soll erfolgreich durchlaufen.

## Muss `StateHasChanged` aufgerufen werden?

Bei einem normalen Blazor-Eventcallback rendert Blazor vor und nach dem asynchronen Eventablauf passend neu. Für die Felder dieser Übung ist kein manueller Aufruf nötig.

In der späteren LocalStorage-Übung wird innerhalb von `OnAfterRenderAsync` geladen. Dort ist ein manueller Aufruf nötig, weil Blazor nach dem asynchronen Abschluss dieser speziellen Lebenszyklusmethode nicht automatisch erneut rendert.

## Was in der nächsten Lektion ersetzt wird

Der fertige Async-Lerntracker besitzt danach zwei simulierte Stellen:

```text
StartaufgabenLadenAsync
AenderungSpeichernAsync
```

Alles drum herum bleibt nützlich:

- `Task`-Rückgabewerte,
- `await`,
- Lade- und Speicherzustände,
- `try`, `catch`, `finally`,
- deaktivierte Bedienelemente,
- Zustandsänderungen erst nach Erfolg.

LocalStorage und Dapper ersetzen nicht die Async-Grundidee. Sie liefern nur die echten Operationen, auf die gewartet wird.

## Häufige Fehler

- `OnInitialized` statt `OnInitializedAsync` wird verwendet.
- Die Liste wird vor dem `await` verändert.
- Eine Eventmethode wird als `async void` geschrieben.
- Das Formular leert sich vor dem abgeschlossenen Callback.
- Der Speicherzustand wird nur bei Erfolg zurückgesetzt.
- Buttons bleiben während des Speicherns anklickbar.
- Ein Ladefehler wird als erfolgreiche leere Liste dargestellt.
- Eine technische Exception wird ungefiltert in der Oberfläche ausgegeben.
- `Task.Delay` wird versehentlich als dauerhafte Speicherung betrachtet.

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