# 15.03 – Lernaufgabentracker in Komponenten zerlegen

## Lernziel

Du zerlegst den funktionierenden Lernaufgabentracker aus Lektion 14 in drei Komponenten mit klaren Verantwortungen:

- `Home` besitzt die dauerhafte Aufgabenliste.
- `AufgabenFormular` verwaltet die vorübergehende Eingabe.
- `AufgabenKarte` zeigt eine Aufgabe und meldet eine Benutzeraktion.

Dabei verwendest du Parameter für Daten nach unten und `EventCallback<T>` für Ereignisse mit Daten nach oben.

## Ausgangspunkt

Zu Beginn befinden sich Formular, Validierung, Liste, Karten-Markup und Eventmethoden gemeinsam in `Home.razor`. Der Code funktioniert bereits.

Die Aufgabe ist deshalb keine neue Funktion. Du veränderst die Struktur, während das sichtbare Verhalten erhalten bleibt. Diese Art von Umbau nennt man Refactoring.

Teste die Anwendung vor dem Umbau. Danach kannst du nach jedem Teilschritt kontrollieren, ob noch alles funktioniert.

## Jede Razor-Datei ist eine eigene Komponentenklasse

Diese Dateien werden zu drei getrennten Klassen:

```text
Components/Pages/Home.razor
Components/AufgabenFormular.razor
Components/AufgabenKarte.razor
```

Private Felder gehören immer nur zu ihrer eigenen Komponente:

- `Home` kann nicht direkt auf ein privates Feld des Formulars zugreifen.
- Die Karte kann nicht direkt auf die private Liste von `Home` zugreifen.
- Das Formular kann nicht direkt die Methode der Karte aufrufen.

Benötigte Daten und Aktionen müssen deshalb ausdrücklich über die Komponentenschnittstellen verbunden werden.

## Eine einzige Quelle für dauerhafte Daten

Die Aufgabenliste bleibt in `Home`:

```csharp
private List<TaskItem> aufgaben = new List<TaskItem>
{
    // vorhandene Startaufgaben
};
```

`Home` ist damit der Zustandsbesitzer beziehungsweise die einzige Quelle der Wahrheit.

Würden `Home`, Formular und Karte jeweils eigene Aufgabenlisten führen, könnten diese Listen unterschiedliche Inhalte besitzen.

Die Grundregel lautet:

```text
Daten werden vom Besitzer nach unten gegeben.
Benutzeraktionen werden dem Besitzer nach oben gemeldet.
Nur der Besitzer verändert den dauerhaften Zustand.
```

## Daten nach unten: Komponentenparameter

Eine Kindkomponente erhält Daten über eine öffentliche Property mit `[Parameter]`:

```csharp
[Parameter]
public TaskItem Aufgabe { get; set; } = default!;
```

Die Elternkomponente setzt diesen Parameter im Komponenten-Tag:

```razor
<AufgabenKarte Aufgabe="@aufgabe" />
```

Der Parameter ist die Eingabe der Kindkomponente. Die Karte soll das Objekt anzeigen, aber den dauerhaften Status nicht eigenständig verändern.

## Was bedeutet `default!`?

Blazor erzeugt zuerst die Komponenteninstanz und setzt ihre Parameter anschließend. Der Compiler sieht bei der Objekterzeugung deshalb zunächst keinen Wert für die nicht nullable Property.

- `default` ist bei einem Klassentyp zunächst `null`.
- `!` unterdrückt hier die Nullable-Warnung.
- Dadurch wird kein `TaskItem` erzeugt.
- Der Elternteil muss `Aufgabe` tatsächlich übergeben.

Fehlt der Parameter im Komponenten-Tag, kann die Karte später auf `null` zugreifen. `default!` ist keine Laufzeitprüfung.

## Ereignis mit Daten nach oben

Die Karte muss beim Klick mitteilen, welche Aufgabe gemeint ist:

```csharp
[Parameter]
public EventCallback<TaskItem> OnErledigt { get; set; }
```

`TaskItem` ist der Typ des Werts, der nach oben gesendet wird.

```csharp
private async Task ErledigtMelden()
{
    await OnErledigt.InvokeAsync(Aufgabe);
}
```

Die Karte kennt nicht die konkrete Methode in `Home`. Sie kennt nur ihren Callback-Parameter. Der Elternteil verbindet diesen Parameter mit einer passenden Methode.

`InvokeAsync` liefert ein `Task`. Für diese Lektion genügt: `await` wartet, bis der verbundene Callback verarbeitet wurde. Die ausführlichen Async-Grundlagen folgen später.

## Schritt 1: Aufgabenkarte erstellen

`Components/AufgabenKarte.razor`:

```razor
<section class="aufgabenkarte">
    <h2>@Aufgabe.Titel</h2>
    <p>@(Aufgabe.Beschreibung ?? "Keine Beschreibung")</p>
    <p>Status: @Aufgabe.Status</p>

    @if (Aufgabe.Status != AufgabenStatus.Erledigt)
    {
        <button type="button" @onclick="ErledigtMelden">
            Erledigt
        </button>
    }
</section>

@code {
    [Parameter]
    public TaskItem Aufgabe { get; set; } = default!;

    [Parameter]
    public EventCallback<TaskItem> OnErledigt { get; set; }

    private async Task ErledigtMelden()
    {
        await OnErledigt.InvokeAsync(Aufgabe);
    }
}
```

Die Karte erfüllt genau drei Aufgaben:

1. Daten des übergebenen Objekts anzeigen.
2. Den Button abhängig vom Status darstellen.
3. Beim Klick das aktuelle Objekt nach oben melden.

Diese Zustandsänderung gehört bewusst nicht in die Karte:

```csharp
// Nicht in der Karte:
Aufgabe.Status = AufgabenStatus.Erledigt;
```

## Karte in Home verwenden

Das bisherige Karten-Markup in der Schleife wird durch den Komponenten-Tag ersetzt:

```razor
@foreach (TaskItem aufgabe in aufgaben)
{
    <AufgabenKarte
        Aufgabe="@aufgabe"
        OnErledigt="AufgabeErledigen" />
}
```

Die Elternmethode bleibt in `Home`:

```csharp
private void AufgabeErledigen(TaskItem aufgabe)
{
    aufgabe.Status = AufgabenStatus.Erledigt;
}
```

Der Ablauf:

```text
Home übergibt ein TaskItem an die Karte.
Die Karte zeigt dieses Objekt.
Die Karte meldet beim Klick dasselbe Objekt.
Home erhält es als Methodenparameter.
Home verändert dessen Status.
Blazor rendert die Karte mit dem neuen Status erneut.
```

## Drei ähnlich benannte Werte unterscheiden

| Name | Bedeutung | Gültigkeitsbereich |
|---|---|---|
| `aufgaben` | vollständige `List<TaskItem>` | privates Feld in `Home` |
| `aufgabe` | aktuelles Element der `foreach`-Schleife | nur im Schleifenblock |
| `Aufgabe` | Parameter-Property der Kartenkomponente | innerhalb der Karte |

Nur die Liste besitzt `Add`:

```csharp
aufgaben.Add(neueAufgabe);
```

Ein einzelnes `TaskItem` besitzt Properties wie `Titel` und `Status`, aber keine Listenmethode `Add`.

## Zwischenstand testen

Nach dem Auslagern der Karte sollte das Formular noch unverändert in `Home` funktionieren.

Prüfe:

- alle Startaufgaben erscheinen,
- der Ersatztext erscheint bei fehlender Beschreibung,
- der richtige Erledigt-Button verschwindet,
- Anzahl und Formular funktionieren weiterhin.

Erst danach lagerst du das Formular aus.

## Temporärer Zustand darf im Formular liegen

Die Formularfelder werden nur bis zum Absenden gebraucht:

- eingegebener Titel,
- eingegebene Beschreibung,
- ausgewählter Status,
- lokale Fehlermeldung.

Diese Werte dürfen von `Home` in `AufgabenFormular` verschoben werden. Die dauerhafte Aufgabenliste darf nicht mitwandern.

## Schritt 2: Aufgabenformular erstellen

`Components/AufgabenFormular.razor`:

```razor
<form @onsubmit="Absenden"
      @onsubmit:preventDefault>
    <label>
        Titel
        <input @bind="titel" />
    </label>

    <label>
        Beschreibung
        <textarea @bind="beschreibung"></textarea>
    </label>

    <label>
        Status
        <select @bind="status">
            <option value="@AufgabenStatus.Offen">Offen</option>
            <option value="@AufgabenStatus.InArbeit">In Arbeit</option>
            <option value="@AufgabenStatus.Erledigt">Erledigt</option>
        </select>
    </label>

    <button type="submit">Aufgabe hinzufügen</button>
</form>

@if (fehlermeldung is not null)
{
    <p role="alert">@fehlermeldung</p>
}

@code {
    private string titel = string.Empty;
    private string? beschreibung;
    private AufgabenStatus status = AufgabenStatus.Offen;
    private string? fehlermeldung;

    [Parameter]
    public EventCallback<TaskItem> OnAufgabeErstellt { get; set; }

    private async Task Absenden()
    {
        if (string.IsNullOrWhiteSpace(titel))
        {
            fehlermeldung = "Der Titel darf nicht leer sein.";
            return;
        }

        string? gespeicherteBeschreibung = beschreibung;

        if (string.IsNullOrWhiteSpace(gespeicherteBeschreibung))
        {
            gespeicherteBeschreibung = null;
        }

        TaskItem neueAufgabe = new TaskItem(
            titel,
            gespeicherteBeschreibung,
            status
        );

        await OnAufgabeErstellt.InvokeAsync(neueAufgabe);

        titel = string.Empty;
        beschreibung = null;
        status = AufgabenStatus.Offen;
        fehlermeldung = null;
    }
}
```

Das Formular:

1. verwaltet seine Eingaben,
2. validiert den Titel,
3. erzeugt ein gültiges Objekt,
4. meldet das Objekt,
5. setzt seine Eingaben zurück.

Es speichert das Objekt nicht dauerhaft.

## Formular in Home verwenden

Im Markup von `Home` ersetzt der Komponenten-Tag das bisherige Formular:

```razor
<AufgabenFormular
    OnAufgabeErstellt="AufgabeHinzufuegen" />
```

Die Elternmethode erhält das neue Objekt:

```csharp
private void AufgabeHinzufuegen(TaskItem neueAufgabe)
{
    aufgaben.Add(neueAufgabe);
}
```

Callback-Typ und Methodenparameter müssen zusammenpassen:

```text
EventCallback<TaskItem>
        ↓
InvokeAsync(neueAufgabe)
        ↓
AufgabeHinzufuegen(TaskItem neueAufgabe)
```

## Warum validiert das Formular selbst?

Das Formular besitzt die Eingabefelder und erzeugt das neue Objekt. Deshalb ist lokale Eingabevalidierung dort eine klare Verantwortung.

`Home` muss nicht wissen, wie der Titel eingegeben oder welche Fehlermeldung dargestellt wurde. `Home` erhält nur ein bereits gültiges `TaskItem`.

## Vollständiger Datenfluss

Beim Hinzufügen:

```text
Benutzer füllt AufgabenFormular aus
    → Formular validiert
    → Formular erzeugt TaskItem
    → OnAufgabeErstellt sendet TaskItem
    → Home empfängt TaskItem
    → Home fügt es zu aufgaben hinzu
    → Home rendert eine weitere AufgabenKarte
```

Beim Erledigen:

```text
Benutzer klickt in AufgabenKarte
    → Karte sendet ihr TaskItem über OnErledigt
    → Home empfängt das vorhandene Objekt
    → Home setzt Status auf Erledigt
    → Karte wird ohne Erledigt-Button neu gerendert
```

Formular und Karte sind Geschwisterkomponenten. Sie kommunizieren nicht direkt miteinander, sondern über `Home`.

## Interaktivität wird vererbt

`Home.razor` besitzt bereits:

```razor
@rendermode InteractiveServer
```

Die darin gerenderten Kindkomponenten gehören zum selben interaktiven Komponentenbaum. Die Direktive muss nicht in den Kindkomponenten wiederholt werden.

Nach einem Blazor-Ereignis wird automatisch erneut gerendert. Für diese normalen Callbacks ist kein manueller Aufruf von `StateHasChanged()` nötig.

## Wenn Blazor eine Komponente nicht erkennt

Prüfe:

1. Die Datei liegt unter `Components`.
2. Dateiname und Tag stimmen überein:
   - `AufgabenKarte.razor` und `<AufgabenKarte />`
   - `AufgabenFormular.razor` und `<AufgabenFormular />`
3. Die Datei wurde gespeichert.
4. Der Namespace ist über `Components/_Imports.razor` erreichbar.
5. Das Projekt wurde neu gebaut.

Die vorhandene `_Imports.razor` importiert bereits die Komponenten- und Modell-Namespaces.

## Sicheres Vorgehen

1. Ausgangsanwendung vollständig testen.
2. Nur `AufgabenKarte` erstellen.
3. Karten-Markup in `Home` ersetzen.
4. Bauen und Kartenfunktion testen.
5. Erst danach `AufgabenFormular` erstellen.
6. Formular-Markup und lokale Felder verschieben.
7. Callback mit der Elternmethode verbinden.
8. Erneut bauen und vollständig testen.
9. Zum Schluss ungenutzte Felder und Methoden aus `Home` entfernen.

## Häufige Fehler

- Ein Parameter ist `private` statt `public`.
- Im Eltern-Tag fehlt ein erforderlicher Parameter.
- `Aufgabe` und `aufgabe` werden verwechselt.
- Die Karte verändert den Status selbst.
- `OnErledigt.InvokeAsync(Aufgabe)` übergibt kein Objekt.
- Die Elternmethode besitzt keinen passenden `TaskItem`-Parameter.
- Das Formular besitzt versehentlich eine zweite Aufgabenliste.
- Das Formular erzeugt ein Objekt, ruft den Callback aber nicht auf.
- `Home` greift weiterhin auf ausgelagerte private Formularfelder zu.
- Formularcode bleibt doppelt in `Home` und im Kind vorhanden.
- `@rendermode InteractiveServer` wird aus `Home` entfernt.
- Beide Komponenten werden gleichzeitig ausgelagert und Fehler lassen sich schwer eingrenzen.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "15_Blazor-Komponenten/03_LernaufgabenTracker/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "15_Blazor-Komponenten/03_LernaufgabenTracker/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "15_Blazor-Komponenten/03_LernaufgabenTracker/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
