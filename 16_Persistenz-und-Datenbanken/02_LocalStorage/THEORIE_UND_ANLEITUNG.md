# 16.02 – Lerntracker mit LocalStorage speichern

## Lernziel

Du speicherst die Aufgabenliste als JSON im Browser und lädst sie nach einem Neuladen wieder ein.

Dabei lernst du:

- den Unterschied zwischen Arbeitsspeicher und Browser-Speicher,
- JSON-Serialisierung,
- JavaScript-Interop mit `IJSRuntime`,
- den Komponenten-Lebenszyklus `OnAfterRenderAsync`,
- asynchrone Eventmethoden.

## Ausgangslage

Das Projekt enthält bereits den komponentisierten Endstand aus Lektion 15:

- `Home` besitzt die Aufgabenliste.
- `AufgabenFormular` meldet neue Objekte.
- `AufgabenKarte` meldet den Erledigt-Klick.
- Alle Daten liegen bisher nur im Arbeitsspeicher des Servers.

Bei einem Neustart oder einer neuen Blazor-Verbindung beginnt die Liste wieder mit den fest eingebauten Startwerten.

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

## Vollständiger Ladeablauf

```csharp
private bool datenGeladen;

protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (!firstRender)
    {
        return;
    }

    string? json = await JS.InvokeAsync<string?>(
        "localStorage.getItem",
        StorageKey
    );

    if (!string.IsNullOrWhiteSpace(json))
    {
        List<TaskItem>? geladeneAufgaben =
            JsonSerializer.Deserialize<List<TaskItem>>(json);

        if (geladeneAufgaben is not null)
        {
            aufgaben = geladeneAufgaben;
        }
    }
    else
    {
        await AufgabenSpeichernAsync();
    }

    datenGeladen = true;
    StateHasChanged();
}
```

Wenn noch keine gespeicherten Daten existieren, werden hier die vorhandenen Startaufgaben gespeichert.

`StateHasChanged()` ist an dieser Stelle nötig: `OnAfterRenderAsync` löst nach seinem asynchronen Abschluss nicht automatisch ein weiteres Rendering aus.

## Ladezustand anzeigen

Bevor LocalStorage geladen wurde, sollte die Oberfläche keine voreiligen Änderungen erlauben:

```razor
@if (!datenGeladen)
{
    <p>Daten werden geladen ...</p>
}
else
{
    <AufgabenFormular
        OnAufgabeErstellt="AufgabeHinzufuegen" />

    <!-- Anzahl und Karten -->
}
```

Dadurch sieht der Benutzer kurz einen Ladehinweis. Erst danach erscheinen Formular und Liste.

## Nach jeder Änderung speichern

Nur beim Start zu laden reicht nicht. Jede dauerhafte Zustandsänderung muss anschließend gespeichert werden.

Neue Aufgabe:

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    aufgaben.Add(neueAufgabe);
    await AufgabenSpeichernAsync();
}
```

Status ändern:

```csharp
private async Task AufgabeErledigen(
    TaskItem aufgabe)
{
    aufgabe.Status = AufgabenStatus.Erledigt;
    await AufgabenSpeichernAsync();
}
```

Die Methoden geben nun `Task` statt `void` zurück. Die vorhandenen `EventCallback<TaskItem>`-Verbindungen können solche Methoden verwenden.

Wichtig ist die Reihenfolge:

```text
Zustand verändern
→ neuen Zustand serialisieren
→ JSON in LocalStorage speichern
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
