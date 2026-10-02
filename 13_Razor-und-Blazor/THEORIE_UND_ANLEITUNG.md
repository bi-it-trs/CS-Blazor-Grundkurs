# 13 – Razor und Blazor

## Lernziel

Du kannst C#-Modelle in einem Blazor-Projekt verwenden und ihre Daten mit Razor als HTML darstellen. Außerdem verstehst du, warum eine `.razor`-Datei sowohl Markup als auch private C#-Mitglieder enthalten kann.

## Vom Konsolenprojekt zur Blazor-Web-App

Ein Blazor-Projekt enthält mehr Dateien als ein Konsolenprojekt:

- `Program.cs` konfiguriert und startet die Webanwendung.
- `Components/App.razor` bildet die äußere App-Struktur.
- `Components/Routes.razor` findet Seiten anhand ihrer Route.
- `Components/Pages/Home.razor` ist die Startseite.
- `Components/_Imports.razor` stellt gemeinsame Namespaces für Razor-Dateien bereit.
- `wwwroot` enthält öffentlich ausgelieferte Dateien wie CSS.

Für diese Lektion arbeitest du hauptsächlich in `Components/Pages/Home.razor` und in einem neu angelegten Ordner `Models`.

## Projekt starten

Öffne ein Terminal im Projektordner:

```powershell
dotnet run
```

Das Terminal zeigt anschließend eine lokale Adresse, zum Beispiel `https://localhost:7000`. Öffne die tatsächlich angezeigte Adresse im Browser.

Solange die App läuft, bleibt das Terminal belegt. Mit `Ctrl+C` beendest du sie.

## Eine Razor-Komponente

```razor
@page "/"

<PageTitle>Lerntracker</PageTitle>

<h1>@ueberschrift</h1>

@code {
    private string ueberschrift = "Mein Lerntracker";
}
```

Die Datei verbindet zwei Bereiche:

- Oberhalb von `@code` steht hauptsächlich HTML mit Razor-Ausdrücken.
- Im `@code`-Block stehen C#-Felder, Properties und Methoden der Komponente.

`@page "/"` macht die Komponente unter der Route `/` erreichbar. `PageTitle` setzt den Titel des Browser-Tabs.

## Eine `.razor`-Datei ist eine Komponentenklasse

Beim Build übersetzt Razor eine Datei wie `Home.razor` in C#-Code. Vereinfacht entsteht eine partielle Klasse `Home`, die von Blazors `ComponentBase` erbt.

Markup und `@code` gehören dadurch zu derselben Komponentenklasse. Deshalb kann das Markup auf ein `private`-Feld aus dem `@code`-Block zugreifen. `private` bedeutet: Nur diese Komponentenklasse selbst darf darauf zugreifen.

Eine normale HTML-Datei besitzt dagegen keinen C#-`@code`-Block und wird nicht zu einer Blazor-Komponentenklasse.

## Das Zeichen `@`

Razor verwendet `@`, um im Markup zu C# zu wechseln.

Ein einfacher Wert:

```razor
<p>Anzahl: @anzahl</p>
```

Ein zusammengesetzter Ausdruck:

```razor
<p>@(beschreibung ?? "Keine Beschreibung")</p>
```

Ein C#-Block:

```razor
@if (anzahl > 0)
{
    <p>Es sind Einträge vorhanden.</p>
}
```

Bei einem längeren Ausdruck sorgen `@(...)` dafür, dass Razor Anfang und Ende des C#-Ausdrucks eindeutig erkennt.

## Modelle in einem eigenen Ordner

Lege im Projektordner einen Ordner `Models` an. Darin können der Enum und die Klasse aus den vorigen Lektionen liegen.

`Models/AufgabenStatus.cs`:

```csharp
namespace Uebung13RazorBlazor.Models;

public enum AufgabenStatus
{
    Offen,
    InArbeit,
    Erledigt
}
```

`Models/TaskItem.cs`:

```csharp
namespace Uebung13RazorBlazor.Models;

public class TaskItem
{
    public string Titel { get; set; }
    public string? Beschreibung { get; set; }
    public AufgabenStatus Status { get; set; }

    public TaskItem(
        string titel,
        string? beschreibung,
        AufgabenStatus status)
    {
        Titel = titel;
        Beschreibung = beschreibung;
        Status = status;
    }
}
```

Der Namespace beginnt hier mit dem Projektnamen und endet mit dem Ordnernamen. Beide Dateien verwenden denselben Namespace, sodass `TaskItem` den Enum direkt kennt.

## Den Modell-Namespace importieren

`Home.razor` muss wissen, wo `TaskItem` und `AufgabenStatus` liegen. Dafür gibt es zwei sinnvolle Möglichkeiten.

Nur in `Home.razor`:

```razor
@using Uebung13RazorBlazor.Models
```

Oder gemeinsam für die Komponenten in `Components/_Imports.razor`:

```razor
@using Uebung13RazorBlazor.Models
```

`_Imports.razor` wird auf Razor-Dateien in seinem Ordner und den darunterliegenden Ordnern angewendet. Ein Import dort erspart die Wiederholung in jeder einzelnen Komponente.

`@using` erzeugt keine Objekte. Es macht nur die Typnamen aus dem Namespace verfügbar.

## Eine Aufgabenliste als Komponentenzustand

Die Liste kann als privates Feld im `@code`-Block angelegt werden:

```razor
@code {
    private List<TaskItem> aufgaben = new List<TaskItem>
    {
        new TaskItem(
            "Razor lesen",
            "C# und HTML verbinden",
            AufgabenStatus.InArbeit
        ),
        new TaskItem(
            "Markup schreiben",
            null,
            AufgabenStatus.Offen
        )
    };
}
```

Die geschweiften Klammern hinter `new List<TaskItem>` sind ein **Collection-Initializer**. Jeder aufgeführte Wert wird beim Erzeugen zur Liste hinzugefügt. Das ist eine kürzere Schreibweise für mehrere `Add`-Aufrufe.

Das Feld ist `private`, weil es nur von `Home` verwendet wird.

## Anzahl im Markup ausgeben

```razor
<p>Gesamtzahl: @aufgaben.Count</p>
```

`@aufgaben.Count` wird beim Rendern ausgewertet. Im erzeugten HTML steht anschließend die konkrete Zahl.

## Liste mit `@foreach` darstellen

```razor
<ul>
    @foreach (TaskItem aufgabe in aufgaben)
    {
        <li>
            <section>
                <h2>@aufgabe.Titel</h2>
                <p>
                    @(aufgabe.Beschreibung ?? "Keine Beschreibung")
                </p>
                <p>Status: @aufgabe.Status</p>
            </section>
        </li>
    }
</ul>
```

Razor führt die Schleife serverseitig aus und erzeugt für jedes Objekt das Markup im Block.

`aufgabe` wird im Kopf der Schleife als lokale Variable deklariert:

- Im ersten Durchlauf verweist sie auf das erste Listenelement.
- Im zweiten Durchlauf verweist sie auf das zweite Listenelement.
- Sie existiert nur innerhalb der geschweiften Klammern der Schleife.

Du musst vorher keine Variable namens `aufgabe` anlegen.

## C#-Ausdruck und HTML-Struktur

Razor entscheidet anhand des Kontexts, was HTML und was C# ist:

```razor
@foreach (TaskItem aufgabe in aufgaben)
{
    <h2>@aufgabe.Titel</h2>
}
```

- `@foreach (...) { ... }` ist C#-Steuerung.
- `<h2>...</h2>` ist HTML.
- `@aufgabe.Titel` setzt einen C#-Wert in das HTML ein.

Verwende HTML-Elemente nach ihrer Bedeutung:

- `h1` für die Hauptüberschrift,
- `h2` für einzelne Aufgabentitel,
- `p` für Beschreibung und Status,
- `ul` für eine ungeordnete Liste,
- `li` für jedes Listenelement,
- `section` für einen zusammengehörenden Inhaltsbereich.

## Statisches und interaktives Rendern

In dieser Lektion zeigt die Seite vorhandene C#-Daten als HTML. Dafür sind noch keine Buttons, Formulare oder `@bind`-Anweisungen nötig.

Ohne einen interaktiven Rendermodus wird die Komponente serverseitig zu HTML gerendert. Für Klicks, Eingaben und dauerhaft verbundene Ereignisbehandlung benötigt die Komponente einen interaktiven Rendermodus. Das folgt in Lektion 14.

## Geführtes Vorgehen für die Aufgabe

1. Starte das unveränderte Projekt einmal und öffne die lokale Adresse.
2. Lege `Models/AufgabenStatus.cs` mit Namespace an.
3. Lege `Models/TaskItem.cs` mit demselben Namespace an.
4. Importiere den Modell-Namespace in `Home.razor` oder `Components/_Imports.razor`.
5. Ersetze den Beispielinhalt von `Home.razor`.
6. Lege im `@code`-Block eine Liste mit mindestens drei unterschiedlichen Objekten an.
7. Verwende bei mindestens einer Beschreibung `null`.
8. Gib `aufgaben.Count` im Markup aus.
9. Erzeuge mit `@foreach` für jedes Objekt ein `li` oder eine `section`.
10. Gib Titel, Ersatzbeschreibung und Status aus.
11. Baue und starte das Projekt erneut.

## Häufige Fehler

- Der Namespace in den Modelldateien stimmt nicht mit dem `@using` überein.
- Der Import wurde in einer normalen C#-Datei als `@using` geschrieben; das `@` gehört nur zu Razor.
- Die Liste wird im Markup verwendet, aber im `@code`-Block anders benannt.
- Bei einem zusammengesetzten Ausdruck wie `??` fehlen die runden Klammern von `@(...)`.
- `aufgabe` wird außerhalb der `foreach`-Schleife verwendet.
- Direkt in `ul` werden andere Elemente statt `li` eingesetzt.
- Es werden bereits Buttons eingebaut, obwohl die Seite noch keinen interaktiven Rendermodus besitzt.
- Nach einer Änderung läuft noch ein alter Build oder die Datei wurde nicht gespeichert.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "13_Razor-und-Blazor/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "13_Razor-und-Blazor/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "13_Razor-und-Blazor/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
