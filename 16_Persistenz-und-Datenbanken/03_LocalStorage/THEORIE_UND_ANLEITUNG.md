# 16.03 – Lerntracker mit LocalStorage speichern

## Lernziel

Du speicherst die Aufgabenliste als JSON im Browser und lädst sie nach einem Neuladen wieder ein.

Dabei lernst du:

- den Unterschied zwischen Arbeitsspeicher und Browser-Speicher,
- JSON-Serialisierung,
- JavaScript-Interop mit `IJSRuntime`,
- den Komponenten-Lebenszyklus `OnAfterRenderAsync`,
- die vorbereitete Async-Struktur mit einem echten Speicherzugriff zu verbinden.

## Ausgangslage

Das Projekt enthält bereits den erwarteten Endstand aus `01_Async-und-Await/02_Lerntracker-Async`:

- `Home` besitzt die Aufgabenliste.
- `AufgabenFormular` meldet neue Objekte.
- `AufgabenKarte` meldet den Erledigt-Klick.
- `OnInitializedAsync` lädt Startaufgaben mit einer simulierten Wartezeit.
- Hinzufügen und Erledigen sind bereits asynchron.
- Lade- und Speicherzustand, deaktivierte Buttons und Fehlerpfade sind vorhanden.
- Alle Daten liegen bisher nur im Arbeitsspeicher des Servers.

Bei einem Neustart oder einer neuen Blazor-Verbindung beginnt die Liste wieder mit den fest eingebauten Startwerten. In dieser Übung ersetzt du `Task.Delay` durch echten LocalStorage-Zugriff. Die Async-Struktur selbst bleibt bestehen.

## Was ist LocalStorage?

`localStorage` ist ein Schlüssel-Wert-Speicher des Browsers.

Eigenschaften:

- Daten bleiben nach einem Seitenneuladen erhalten.
- Daten bleiben nach dem Schließen und erneuten Öffnen des Browsers erhalten.
- Daten gehören zu einem bestimmten Browser und Ursprung.
- Andere Geräte oder Browser besitzen nicht automatisch dieselben Daten.
- Benutzer können die Daten in den Entwicklerwerkzeugen sehen und verändern.

LocalStorage ist für kleine, nicht sensible Übungsdaten geeignet. Passwörter, Zugangstoken oder vertrauliche Personendaten gehören nicht ungeschützt hinein.

## Schlüssel und Wert

LocalStorage speichert Text:

```text
Schlüssel: lerntracker.aufgaben
Wert:     [{"Titel":"...","Beschreibung":null,"Status":0}]
```

Eine `List<TaskItem>` ist kein Text. Sie muss deshalb vor dem Speichern serialisiert und nach dem Laden deserialisiert werden.

## JSON serialisieren

```csharp
using System.Text.Json;

string json = JsonSerializer.Serialize(aufgaben);
```

Serialisieren bedeutet: C#-Objekte werden in JSON-Text umgewandelt.

Deserialisieren:

```csharp
List<TaskItem>? geladeneAufgaben =
    JsonSerializer.Deserialize<List<TaskItem>>(json);
```

Das Ergebnis darf `null` sein, beispielsweise wenn der JSON-Inhalt nicht die erwartete Liste ergibt.

Der Enum wird mit den Standardeinstellungen als Zahl gespeichert:

- `Offen` → `0`
- `InArbeit` → `1`
- `Erledigt` → `2`

## JavaScript-Interop

LocalStorage ist eine Browser-API. Der C#-Code einer Interactive-Server-Komponente greift über JavaScript-Interop darauf zu.

Füge oben in `Home.razor` ein:

```razor
@using System.Text.Json
@inject IJSRuntime JS
```

Der benötigte Namespace für `IJSRuntime` ist im Projekt bereits über `_Imports.razor` verfügbar.

Ein konstanter Schlüssel verhindert Tippfehler:

```csharp
private const string StorageKey = "lerntracker.aufgaben";
```

## Speichern

```csharp
private async Task AufgabenSpeichernAsync()
{
    string json = JsonSerializer.Serialize(aufgaben);

    await JS.InvokeVoidAsync(
        "localStorage.setItem",
        StorageKey,
        json
    );
}
```

`localStorage.setItem` erwartet Schlüssel und Textwert. `InvokeVoidAsync` wird verwendet, weil die JavaScript-Funktion keinen benötigten Rückgabewert liefert.

## Laden

```csharp
string? json = await JS.InvokeAsync<string?>(
    "localStorage.getItem",
    StorageKey
);
```

`getItem` liefert:

- den gespeicherten JSON-Text, oder
- `null`, wenn unter diesem Schlüssel noch nichts gespeichert wurde.

Danach:

```csharp
if (!string.IsNullOrWhiteSpace(json))
{
    List<TaskItem>? geladeneAufgaben =
        JsonSerializer.Deserialize<List<TaskItem>>(json);

    if (geladeneAufgaben is not null)
    {
        aufgaben = geladeneAufgaben;
    }
}
```

## Warum nicht in `OnInitializedAsync` laden?

Interactive Server rendert eine Seite zunächst möglicherweise auf dem Server vor. Während dieses Prerenderings existiert noch keine aktive Browser-Verbindung für JavaScript-Interop.

LocalStorage steht erst zur Verfügung, wenn die Komponente interaktiv im Browser gerendert wurde.

Für diese Übung wird deshalb verwendet:

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (!firstRender)
    {
        return;
    }

    // LocalStorage laden
}
```

`firstRender` verhindert, dass nach jedem erneuten Rendern wieder geladen und der aktuelle Zustand überschrieben wird.

## Simuliertes Laden ersetzen

Im Ausgangscode lädt `OnInitializedAsync` die simulierten Startaufgaben. Entferne diese Überschreibung. LocalStorage benötigt stattdessen `OnAfterRenderAsync`.

Die vorhandene Methode `StartaufgabenLadenAsync` simuliert ebenfalls Wartezeit. Ersetze sie durch eine synchrone Hilfsmethode ohne `Task.Delay`, die nur die Startliste erzeugt:

```csharp
private static List<TaskItem> StartaufgabenErstellen()
{
    return new List<TaskItem>
    {
        // die drei vorhandenen Startaufgaben
    };
}
```

Diese Startwerte werden nur verwendet, wenn der Browser noch keinen gespeicherten Wert besitzt.

## Vollständiger Ladeablauf mit vorhandenen Statusfeldern

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (!firstRender)
    {
        return;
    }

    try
    {
        string? json = await JS.InvokeAsync<string?>(
            "localStorage.getItem",
            StorageKey
        );

        if (!string.IsNullOrWhiteSpace(json))
        {
            List<TaskItem>? geladeneAufgaben =
                JsonSerializer.Deserialize<List<TaskItem>>(json);

            if (geladeneAufgaben is null)
            {
                throw new JsonException(
                    "Die gespeicherte Liste ist ungültig."
                );
            }

            aufgaben = geladeneAufgaben;
        }
        else
        {
            aufgaben = StartaufgabenErstellen();
            await AufgabenSpeichernAsync();
        }
    }
    catch (Exception)
    {
        ladefehler =
            "Die gespeicherten Aufgaben konnten nicht geladen werden.";
    }
    finally
    {
        ladevorgangLaeuft = false;
        StateHasChanged();
    }
}
```

Wenn noch keine gespeicherten Daten existieren, werden hier die vorhandenen Startaufgaben erzeugt und erstmals gespeichert.

`StateHasChanged()` ist an dieser Stelle nötig: `OnAfterRenderAsync` löst nach seinem asynchronen Abschluss nicht automatisch ein weiteres Rendering aus.

## Ladezustand anzeigen

Der Ausgangscode besitzt bereits `ladevorgangLaeuft` und `ladefehler`. Das Markup kann deshalb bestehen bleiben:

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
    <!-- Formular, Anzahl und Karten -->
}
```

Dadurch sieht der Benutzer kurz einen Ladehinweis. Erst danach erscheinen Formular und Liste.

## Nach jeder Änderung speichern

Nur beim Start zu laden reicht nicht. Jede dauerhafte Zustandsänderung muss anschließend gespeichert werden. Die Home-Methoden sind bereits asynchron und sperren die Oberfläche. Ersetze darin den Aufruf von `AenderungSpeichernAsync`.

Neue Aufgabe:

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    aufgaben.Add(neueAufgabe);

    try
    {
        await AufgabenSpeichernAsync();
    }
    catch
    {
        aufgaben.Remove(neueAufgabe);
        throw;
    }
}
```

Das vorübergehende Hinzufügen ist nötig, weil `AufgabenSpeichernAsync` die aktuelle Liste serialisiert. Scheitert LocalStorage, wird die Änderung sofort zurückgenommen. Der bereits vorhandene äußere `catch`-Block übersetzt den Fehler anschließend in die verständliche Meldung für das Formular.

Status ändern:

```csharp
private async Task AufgabeErledigen(
    TaskItem aufgabe)
{
    AufgabenStatus vorherigerStatus = aufgabe.Status;
    aufgabe.Status = AufgabenStatus.Erledigt;

    try
    {
        await AufgabenSpeichernAsync();
    }
    catch
    {
        aufgabe.Status = vorherigerStatus;
        throw;
    }
}
```

Die gezeigten Blöcke kommen jeweils in den vorhandenen äußeren `try`-Block. `speichervorgangLaeuft`, die Prüfung gegen Doppelklicks, die verständliche Exception und `finally` bleiben erhalten.

Wichtig ist die Reihenfolge:

```text
Zustand verändern
→ neuen Zustand serialisieren
→ JSON in LocalStorage speichern
→ bei einem Fehler die Änderung zurücknehmen
```

## Daten löschen

Optional kannst du einen Reset-Button ergänzen:

```csharp
private async Task SpeicherLeeren()
{
    await JS.InvokeVoidAsync(
        "localStorage.removeItem",
        StorageKey
    );

    aufgaben.Clear();
}
```

Entscheide bewusst, ob danach eine leere Liste oder wieder Startdaten erscheinen sollen.

## Daten im Browser kontrollieren

In Chromium-basierten Browsern:

1. Entwicklerwerkzeuge öffnen.
2. Register **Application** wählen.
3. **Local Storage** öffnen.
4. Die lokale Adresse auswählen.
5. Nach `lerntracker.aufgaben` suchen.

Dort siehst du den gespeicherten JSON-Text.

## Grenzen von LocalStorage

- Die Daten gelten nur für diesen Browser und diese Adresse.
- Browserdaten können gelöscht werden.
- Mehrere Benutzerkonten werden nicht automatisch getrennt.
- Änderungen in mehreren Tabs können sich überschreiben.
- Die Daten sind sichtbar und manipulierbar.
- Bei Interactive Server wird der JSON-Text über die Verbindung zwischen Browser und Server übertragen.

Für eine echte gemeinsame To-do-Anwendung ist eine serverseitige Datenbank geeigneter.

## Fehlerbehandlung als Zusatz

Manipulierter oder veralteter JSON-Text kann eine `JsonException` auslösen. Später kannst du den Ladevorgang mit `try` und `catch` absichern und bei beschädigten Daten eine verständliche Meldung anzeigen.

Für den ersten Durchlauf teste zunächst nur JSON, das die Anwendung selbst geschrieben hat.

## Häufige Fehler

- Laden wird in `OnInitializedAsync` versucht und JS-Interop ist noch nicht verfügbar.
- `firstRender` wird nicht geprüft und alte Daten überschreiben neue Änderungen.
- Die Liste wird verändert, aber danach nicht gespeichert.
- Hinzufügen speichert, Statusänderung aber nicht.
- Beim Laden und Speichern werden unterschiedliche Schlüssel verwendet.
- JSON wird gespeichert, aber nie deserialisiert.
- Nach dem Laden fehlt `StateHasChanged()`.
- Sensible Informationen werden ungeschützt im Browser gespeichert.

## Offizielle Nachschlagequellen

- [Blazor-Zustand und Browser-Speicher](https://learn.microsoft.com/en-us/aspnet/core/blazor/state-management/protected-browser-storage?view=aspnetcore-10.0)
- [JavaScript aus .NET aufrufen](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet?view=aspnetcore-10.0)
- [Lebenszyklus von Razor-Komponenten](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-10.0)

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/03_LocalStorage/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "16_Persistenz-und-Datenbanken/03_LocalStorage/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "16_Persistenz-und-Datenbanken/03_LocalStorage/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet. Voraussetzung ist, dass dieser Starterordner im Git-Tag `uebungen-start` enthalten ist.
