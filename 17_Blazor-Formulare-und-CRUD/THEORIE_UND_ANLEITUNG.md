# Theorie und Anleitung – Blazor-Formulare und vollständiges CRUD

## Lernziel

Du vervollständigst die Datenbankfunktionen des Lerntrackers und baust aus dem manuellen HTML-Formular ein validiertes Blazor-Formular.

Nach der Lektion kann die Anwendung:

- Aufgaben erstellen,
- Aufgaben aus MariaDB lesen,
- Titel, Beschreibung und Status bearbeiten,
- Aufgaben löschen,
- nach Status filtern,
- nach ID oder Titel sortieren,
- offene und erledigte Aufgaben zählen,
- Lade-, Speicher-, Fehler- und Leerzustände darstellen.

## Ausgangslage

Das Startprojekt ist die Musterlösung von Lektion 16.04. Folgendes funktioniert bereits:

```text
Home
→ TaskItemRepository
→ Dapper
→ MySqlConnector
→ MariaDB
```

Das Repository besitzt:

- `LadeAlleAsync`,
- `ErstellenAsync`,
- `AlsErledigtMarkierenAsync`.

Es fehlen ein allgemeines UPDATE und DELETE. Das Formular arbeitet noch mit einzelnen Feldern und manueller `if`-Validierung.

## CRUD als vollständiger Datenlebenszyklus

CRUD beschreibt die vier grundlegenden Operationen einer Datenanwendung:

```text
Create  → INSERT
Read    → SELECT
Update  → UPDATE
Delete  → DELETE
```

Die App soll nach jeder erfolgreichen Operation denselben Zustand in der Benutzeroberfläche und in MariaDB zeigen.

Die Reihenfolge lautet grundsätzlich:

```text
Eingabe validieren
→ Datenbankoperation abwarten
→ sichtbaren Zustand aktualisieren
```

Schlägt die Datenbankoperation fehl, bleibt der bisherige sichtbare Zustand bestehen.

## Warum ein `EditForm`?

Das bisherige Formular besteht aus einem normalen HTML-`form` und einzelnen Feldern:

```razor
<form @onsubmit="Absenden"
      @onsubmit:preventDefault>
```

Das funktioniert für einfache Prüfungen. Mit wachsendem Formular entstehen aber viele manuelle `if`-Blöcke und Fehlermeldungsfelder.

Blazor stellt dafür `EditForm` bereit. Ein `EditForm`:

- arbeitet mit einem Formularmodell,
- verwaltet den Bearbeitungs- und Validierungszustand,
- unterstützt Blazor-Eingabekomponenten,
- kann nur bei gültigen Daten `OnValidSubmit` auslösen,
- verbindet DataAnnotations mit Fehlermeldungen.

## Entity und Formularmodell trennen

`TaskItem` repräsentiert den gespeicherten Datensatz. Für das Formular wird eine eigene Klasse verwendet:

```text
TaskItem
→ Datenbankobjekt und sichtbare Aufgabe

TaskItemFormularModell
→ vorübergehende Eingaben des Benutzers
```

Das verhindert einen wichtigen Fehler: Wenn du das vorhandene `TaskItem` direkt an Eingabefelder bindest, wird das Objekt in der sichtbaren Liste schon während des Tippens verändert. Ein Abbrechen könnte die alten Werte dann nicht einfach wiederherstellen.

Das Formularmodell ist eine Kopie. Erst nach gültigem Formular und erfolgreichem UPDATE ersetzt `Home` das sichtbare Objekt.

## Formularmodell mit DataAnnotations

Lege `Models/TaskItemFormularModell.cs` an:

```csharp
using System.ComponentModel.DataAnnotations;

namespace TodoCrudUebung.Models;

public class TaskItemFormularModell
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Der Titel ist erforderlich.")]
    [StringLength(
        200,
        ErrorMessage =
            "Der Titel darf höchstens 200 Zeichen lang sein."
    )]
    public string Titel { get; set; } = string.Empty;

    [StringLength(
        2000,
        ErrorMessage =
            "Die Beschreibung darf höchstens 2000 Zeichen lang sein."
    )]
    public string? Beschreibung { get; set; }

    public AufgabenStatus Status { get; set; } =
        AufgabenStatus.Offen;
}
```

Die Regeln passen zu den Anwendungsanforderungen:

- Titel ist Pflicht,
- Datenbankspalte `Titel` erlaubt maximal 200 Zeichen,
- Beschreibung bleibt optional,
- Status besitzt immer einen Enum-Wert.

DataAnnotations ersetzen nicht alle Datenbankregeln. Die Datenbank behält weiterhin `NOT NULL`, maximale Spaltenlänge und Status-Check als letzte Schutzschicht.

## Aufbau eines `EditForm`

In `AufgabenFormular.razor` ersetzt du den normalen HTML-Formularblock:

```razor
<EditForm Model="@formularModell"
          OnValidSubmit="Speichern">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <label>
        Titel
        <InputText
            @bind-Value="formularModell.Titel"
            disabled="@Deaktiviert" />
    </label>
    <ValidationMessage
        For="@(() => formularModell.Titel)" />

    <label>
        Beschreibung
        <InputTextArea
            @bind-Value="formularModell.Beschreibung"
            disabled="@Deaktiviert" />
    </label>
    <ValidationMessage
        For="@(() => formularModell.Beschreibung)" />

    <label>
        Status
        <InputSelect
            @bind-Value="formularModell.Status"
            disabled="@Deaktiviert">
            <option value="@AufgabenStatus.Offen">Offen</option>
            <option value="@AufgabenStatus.InArbeit">In Arbeit</option>
            <option value="@AufgabenStatus.Erledigt">Erledigt</option>
        </InputSelect>
    </label>

    <button type="submit" disabled="@Deaktiviert">
        Speichern
    </button>
</EditForm>
```

Die wichtigsten Teile:

| Teil | Aufgabe |
|---|---|
| `Model` | Objekt, dessen Properties bearbeitet werden |
| `DataAnnotationsValidator` | aktiviert Validierungsattribute |
| `OnValidSubmit` | läuft nur bei gültigem Modell |
| `ValidationSummary` | zeigt alle Validierungsfehler |
| `ValidationMessage` | zeigt Fehler eines bestimmten Felds |
| `InputText` | bindet einen String im Formularkontext |
| `InputSelect` | bindet einen auswählbaren Wert |

Verwende nicht gleichzeitig einen äußeren HTML-`form`-Tag. Ein Formular darf nicht in einem weiteren Formular verschachtelt werden.

## Erstellen und Bearbeiten unterscheiden

Eine neue Aufgabe besitzt:

```text
Id == 0
```

Eine aus MariaDB geladene Aufgabe besitzt eine positive ID.

Das Formular erhält deshalb optional die zu bearbeitende Aufgabe:

```csharp
[Parameter]
public TaskItem? AufgabeZumBearbeiten { get; set; }

[Parameter]
public EventCallback<TaskItem> OnAufgabeGespeichert { get; set; }

[Parameter]
public EventCallback OnBearbeitungAbgebrochen { get; set; }
```

Der Modus ergibt sich aus dem Parameter:

```csharp
private bool IstBearbeitung =>
    AufgabeZumBearbeiten is not null;
```

Im Markup kannst du Titel und Buttontext unterscheiden:

```razor
<h2>@(IstBearbeitung ? "Aufgabe bearbeiten" : "Neue Aufgabe")</h2>
```

## Parameter in ein Formularmodell kopieren

Wenn `Home` eine Aufgabe auswählt, erhält die Formularkomponente einen neuen Parameterwert. `OnParametersSet` ist dafür der passende Lebenszyklus:

```csharp
private TaskItemFormularModell formularModell = new();
private int? geladeneId;

protected override void OnParametersSet()
{
    int? aktuelleId = AufgabeZumBearbeiten?.Id;

    if (aktuelleId == geladeneId)
    {
        return;
    }

    geladeneId = aktuelleId;

    if (AufgabeZumBearbeiten is null)
    {
        formularModell = new TaskItemFormularModell();
        return;
    }

    formularModell = new TaskItemFormularModell
    {
        Id = AufgabeZumBearbeiten.Id,
        Titel = AufgabeZumBearbeiten.Titel,
        Beschreibung = AufgabeZumBearbeiten.Beschreibung,
        Status = AufgabeZumBearbeiten.Status
    };
}
```

Warum wird `geladeneId` geprüft? Die Elternkomponente kann auch aus anderen Gründen neu rendern, etwa wenn `Deaktiviert` geändert wird. Das Formular soll die Eingabe dann nicht ständig mit den alten Daten überschreiben.

## Ein gültiges Formular zurückmelden

Aus dem Formularmodell wird ein neues `TaskItem` erzeugt:

```csharp
private async Task Speichern()
{
    string? beschreibung = formularModell.Beschreibung;

    if (string.IsNullOrWhiteSpace(beschreibung))
    {
        beschreibung = null;
    }

    TaskItem aufgabe = new TaskItem(
        formularModell.Titel.Trim(),
        beschreibung,
        formularModell.Status
    )
    {
        Id = formularModell.Id
    };

    try
    {
        await OnAufgabeGespeichert.InvokeAsync(aufgabe);

        if (formularModell.Id == 0)
        {
            formularModell = new TaskItemFormularModell();
        }

        fehlermeldung = null;
    }
    catch (InvalidOperationException exception)
    {
        fehlermeldung = exception.Message;
    }
}
```

Bei einer neuen Aufgabe wird das Formular nach Erfolg geleert. Beim Bearbeiten setzt `Home` den Bearbeitungsparameter auf `null`; `OnParametersSet` stellt danach wieder ein leeres Modell her.

## Bearbeitung abbrechen

Im Bearbeitungsmodus erscheint ein zweiter Button:

```razor
@if (IstBearbeitung)
{
    <button type="button"
            disabled="@Deaktiviert"
            @onclick="BearbeitungAbbrechen">
        Abbrechen
    </button>
}
```

Die Methode meldet nur nach oben:

```csharp
private Task BearbeitungAbbrechen()
{
    return OnBearbeitungAbgebrochen.InvokeAsync();
}
```

`Home` besitzt die Auswahl und setzt sie zurück. Das Kind verändert nicht selbst die Aufgabenliste.

## Allgemeines UPDATE im Repository

Ergänze `TaskItemRepository`:

```csharp
public async Task AktualisierenAsync(TaskItem aufgabe)
{
    const string sql = @"
        UPDATE Aufgaben
        SET
            Titel = @Titel,
            Beschreibung = @Beschreibung,
            Status = @Status
        WHERE Id = @Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    int betroffeneZeilen =
        await connection.ExecuteAsync(
            sql,
            new
            {
                aufgabe.Id,
                aufgabe.Titel,
                aufgabe.Beschreibung,
                Status = (int)aufgabe.Status
            }
        );

    if (betroffeneZeilen != 1)
    {
        throw new InvalidOperationException(
            "Die Aufgabe wurde nicht gefunden."
        );
    }
}
```

Die ID steht ausschließlich in der WHERE-Bedingung. Ohne `WHERE Id = @Id` würden alle Aufgaben aktualisiert. Prüfe diese Zeile vor jedem UPDATE besonders sorgfältig.

## Eine gemeinsame Speichermethode in Home

`Home` entscheidet anhand der ID zwischen INSERT und UPDATE:

```csharp
private async Task AufgabeSpeichern(TaskItem aufgabe)
{
    PruefeObSpeichernMoeglichIst();
    speichervorgangLaeuft = true;

    try
    {
        if (aufgabe.Id == 0)
        {
            await Repository.ErstellenAsync(aufgabe);
            aufgaben.Add(aufgabe);
        }
        else
        {
            await Repository.AktualisierenAsync(aufgabe);

            int index = aufgaben.FindIndex(
                eintrag => eintrag.Id == aufgabe.Id
            );

            if (index < 0)
            {
                throw new InvalidOperationException(
                    "Die sichtbare Aufgabe wurde nicht gefunden."
                );
            }

            aufgaben[index] = aufgabe;
            aufgabeInBearbeitung = null;
        }
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
}
```

Das Repository setzt beim INSERT die neue ID. Beim UPDATE wird das Objekt in der sichtbaren Liste erst nach erfolgreicher Datenbankänderung ersetzt.

## Bearbeitung in Home auswählen

```csharp
private TaskItem? aufgabeInBearbeitung;

private void AufgabeBearbeiten(TaskItem aufgabe)
{
    aufgabeInBearbeitung = aufgabe;
}

private void BearbeitungAbbrechen()
{
    aufgabeInBearbeitung = null;
}
```

Übergib die Auswahl an das Formular:

```razor
<AufgabenFormular
    AufgabeZumBearbeiten="@aufgabeInBearbeitung"
    Deaktiviert="@speichervorgangLaeuft"
    OnAufgabeGespeichert="AufgabeSpeichern"
    OnBearbeitungAbgebrochen="BearbeitungAbbrechen" />
```

## DELETE im Repository

```csharp
public async Task LoeschenAsync(int id)
{
    const string sql = @"
        DELETE FROM Aufgaben
        WHERE Id = @Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    int betroffeneZeilen =
        await connection.ExecuteAsync(
            sql,
            new { Id = id }
        );

    if (betroffeneZeilen != 1)
    {
        throw new InvalidOperationException(
            "Die Aufgabe wurde nicht gefunden."
        );
    }
}
```

Auch DELETE muss genau eine Zeile betreffen. Die ID stammt aus dem bereits geladenen Objekt und wird als SQL-Parameter übergeben.

## Löschen in Home

```csharp
private async Task AufgabeLoeschen(TaskItem aufgabe)
{
    PruefeObSpeichernMoeglichIst();
    speichervorgangLaeuft = true;

    try
    {
        await Repository.LoeschenAsync(aufgabe.Id);
        aufgaben.Remove(aufgabe);

        if (aufgabeInBearbeitung?.Id == aufgabe.Id)
        {
            aufgabeInBearbeitung = null;
        }
    }
    catch (Exception exception)
    {
        throw new InvalidOperationException(
            "Die Aufgabe konnte nicht gelöscht werden.",
            exception
        );
    }
    finally
    {
        speichervorgangLaeuft = false;
    }
}
```

Die sichtbare Liste wird erst nach erfolgreichem DELETE verändert. Wird gerade dieselbe Aufgabe bearbeitet, wird zusätzlich der Bearbeitungsmodus beendet.

## Neue Ereignisse der Aufgabenkarte

Die Karte meldet Bearbeiten und Löschen nach oben:

```csharp
[Parameter]
public EventCallback<TaskItem> OnBearbeiten { get; set; }

[Parameter]
public EventCallback<TaskItem> OnLoeschen { get; set; }
```

Die Buttons lösen nur Ereignisse aus. SQL und Listenänderungen bleiben in Repository beziehungsweise `Home`.

```razor
<button type="button"
        disabled="@Deaktiviert"
        @onclick="BearbeitenMelden">
    Bearbeiten
</button>

<button type="button"
        disabled="@Deaktiviert"
        @onclick="LoeschenVorbereiten">
    Löschen
</button>
```

## Löschbestätigung ohne JavaScript

Eine versehentliche Löschung ist schwer rückgängig zu machen. Die Karte kann eine zweistufige Bestätigung besitzen:

```csharp
private bool loeschenBestaetigen;
```

Beim ersten Klick wird nur dieses Feld gesetzt. Danach zeigt die Karte:

```razor
@if (loeschenBestaetigen)
{
    <p>Diese Aufgabe wirklich löschen?</p>

    <button type="button"
            disabled="@Deaktiviert"
            @onclick="LoeschenMelden">
        Ja, löschen
    </button>

    <button type="button"
            disabled="@Deaktiviert"
            @onclick="LoeschenAbbrechen">
        Abbrechen
    </button>
}
```

`LoeschenMelden` wartet auf `OnLoeschen.InvokeAsync(Aufgabe)`. Bei Erfolg wird die Karte aus der Elternliste entfernt. Bei einem Fehler bleibt sie sichtbar und zeigt wie beim Erledigt-Button eine lokale Fehlermeldung.

## `@key` bei veränderlichen Listen

Eine Aufgabenkarte besitzt nun lokalen Zustand, beispielsweise `loeschenBestaetigen`. Beim Sortieren oder Entfernen soll Blazor den Zustand eindeutig dem richtigen Datensatz zuordnen.

Verwende deshalb:

```razor
@foreach (TaskItem aufgabe in SichtbareAufgaben)
{
    <AufgabenKarte
        @key="aufgabe.Id"
        Aufgabe="@aufgabe"
        ... />
}
```

Die Datenbank-ID ist stabil und eindeutig. Der Schleifenindex wäre kein geeigneter Schlüssel, weil er sich beim Sortieren oder Löschen verändert.

## Filtern ist keine Listenänderung

Die ursprüngliche Liste bleibt vollständig. Ein Filter bestimmt nur, welche Elemente gerade dargestellt werden:

```csharp
private AufgabenStatus? statusFilter;
```

`null` bedeutet „Alle“.

Im Markup:

```razor
<label>
    Status filtern
    <select @bind="statusFilter">
        <option value="">Alle</option>
        <option value="@AufgabenStatus.Offen">Offen</option>
        <option value="@AufgabenStatus.InArbeit">In Arbeit</option>
        <option value="@AufgabenStatus.Erledigt">Erledigt</option>
    </select>
</label>
```

## Sortierung als eigener Enum

Lege `Models/AufgabenSortierung.cs` an:

```csharp
namespace TodoCrudUebung.Models;

public enum AufgabenSortierung
{
    NeuesteZuerst,
    AeltesteZuerst,
    TitelAufsteigend
}
```

Im Markup:

```razor
<label>
    Sortierung
    <select @bind="sortierung">
        <option value="@AufgabenSortierung.NeuesteZuerst">
            Neueste zuerst
        </option>
        <option value="@AufgabenSortierung.AeltesteZuerst">
            Älteste zuerst
        </option>
        <option value="@AufgabenSortierung.TitelAufsteigend">
            Titel A–Z
        </option>
    </select>
</label>
```

Eine höhere ID steht in dieser einfachen App für eine später erstellte Aufgabe. Für eine echte Zeitangabe würdest du später eine eigene `ErstelltAm`-Spalte verwenden.

## Sichtbare Aufgaben berechnen

```csharp
private AufgabenSortierung sortierung =
    AufgabenSortierung.NeuesteZuerst;

private IEnumerable<TaskItem> SichtbareAufgaben
{
    get
    {
        IEnumerable<TaskItem> ergebnis = aufgaben;

        if (statusFilter.HasValue)
        {
            ergebnis = ergebnis.Where(
                aufgabe =>
                    aufgabe.Status == statusFilter.Value
            );
        }

        return sortierung switch
        {
            AufgabenSortierung.AeltesteZuerst =>
                ergebnis.OrderBy(aufgabe => aufgabe.Id),

            AufgabenSortierung.TitelAufsteigend =>
                ergebnis.OrderBy(aufgabe => aufgabe.Titel),

            _ => ergebnis.OrderByDescending(
                aufgabe => aufgabe.Id
            )
        };
    }
}
```

Die Property erzeugt keine zweite dauerhafte Aufgabenliste. Sie liefert bei jedem Rendern eine gefilterte und sortierte Sicht auf `aufgaben`.

Für eine kleine Lern-App ist Filtern im Arbeitsspeicher sinnvoll. Bei sehr vielen Datensätzen würden Filter, Sortierung und Seiteneinteilung bereits in der SQL-Abfrage stattfinden.

## Zähler

Die vollständige Liste ist die Grundlage für die Zähler:

```csharp
private int AnzahlOffen => aufgaben.Count(
    aufgabe => aufgabe.Status != AufgabenStatus.Erledigt
);

private int AnzahlErledigt => aufgaben.Count(
    aufgabe => aufgabe.Status == AufgabenStatus.Erledigt
);
```

Im Markup:

```razor
<p>
    Gesamt: @aufgaben.Count ·
    Offen: @AnzahlOffen ·
    Erledigt: @AnzahlErledigt
</p>
```

Hier bedeutet „Offen“ alle noch nicht erledigten Aufgaben, also sowohl `Offen` als auch `InArbeit`.

## Leere Zustände unterscheiden

Zwei Situationen sehen ähnlich aus, bedeuten aber etwas anderes:

```text
aufgaben.Count == 0
→ Datenbank enthält keine Aufgaben

!SichtbareAufgaben.Any()
→ Aufgaben existieren, aber keine passt zum Filter
```

Zeige passende Meldungen:

```razor
@if (aufgaben.Count == 0)
{
    <p>Noch keine Aufgaben vorhanden.</p>
}
else if (!SichtbareAufgaben.Any())
{
    <p>Keine Aufgabe passt zum gewählten Filter.</p>
}
else
{
    <!-- Karten -->
}
```

## Die Karte aus Home verbinden

Nach der Erweiterung erhält jede Karte drei Ereignisse:

```razor
<AufgabenKarte
    @key="aufgabe.Id"
    Aufgabe="@aufgabe"
    Deaktiviert="@speichervorgangLaeuft"
    OnErledigt="AufgabeErledigen"
    OnBearbeiten="AufgabeBearbeiten"
    OnLoeschen="AufgabeLoeschen" />
```

Der Datenfluss bleibt derselbe wie in Lektion 15:

```text
Home gibt TaskItem nach unten
→ Karte zeigt es an
→ Benutzer klickt
→ Karte meldet TaskItem nach oben
→ Home ruft Repository auf
→ Home ändert Liste erst nach Erfolg
```

## Validierung und Datenbanksicherheit sind verschiedene Ebenen

DataAnnotations verbessern die Benutzerführung. SQL-Parameter schützen die Datenbankabfrage. Beide lösen unterschiedliche Probleme:

| Schutz | Aufgabe |
|---|---|
| DataAnnotations | ungültige Formulareingaben früh erkennen |
| SQL-Parameter | Werte sicher an SQL übertragen |
| Datenbank-Constraints | gültige Daten auch außerhalb der UI erzwingen |
| eingeschränkter Benutzer | erlaubte Datenbankaktionen begrenzen |

Ein gültiges `EditForm` erlaubt deshalb keine String-Verkettung in SQL. Repository-Abfragen bleiben immer parametrisiert.

## Häufige Fehler

- Ein `EditForm` wird in einen weiteren `form`-Tag gesetzt.
- `DataAnnotationsValidator` fehlt und Attribute werden nicht ausgewertet.
- `OnSubmit` wird verwendet, obwohl nur gültige Daten gespeichert werden sollen.
- Das Datenbankobjekt wird direkt an das Bearbeitungsformular gebunden.
- UPDATE besitzt keine `WHERE`-Bedingung.
- DELETE verwendet Titel statt eindeutiger ID.
- Die sichtbare Liste wird vor der erfolgreichen Datenbankoperation verändert.
- Nach UPDATE wird das alte Listenobjekt nicht ersetzt.
- Beim Löschen der gerade bearbeiteten Aufgabe bleibt das Formular im Bearbeitungsmodus.
- Beim Filtern wird die ursprüngliche Liste überschrieben.
- Für `@key` wird der veränderliche Schleifenindex verwendet.
- Während eines Datenbankzugriffs bleiben weitere Buttons aktiv.
- Technische Datenbankmeldungen werden direkt an Benutzer ausgegeben.

## Offizielle Nachschlagequellen

- [Blazor-Formulare](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/?view=aspnetcore-10.0)
- [Blazor-Formularvalidierung](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-10.0)
- [Blazor-Eingabekomponenten](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/input-components?view=aspnetcore-10.0)
- [EventCallback und Eventbehandlung](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-10.0)
- [Dapper](https://github.com/DapperLib/Dapper)
- [MySqlConnector](https://mysqlconnector.net/)

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