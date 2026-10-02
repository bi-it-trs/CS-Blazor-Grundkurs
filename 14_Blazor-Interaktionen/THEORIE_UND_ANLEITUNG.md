# 14 – Blazor-Interaktionen

## Lernziel

Du kannst Eingabefelder an C#-Felder binden, ein Formular mit einer C#-Methode verarbeiten, Validierungsfehler anzeigen und über Buttons den Zustand der richtigen Aufgabe verändern.

## Warum ein interaktiver Rendermodus nötig ist

Statisches Razor erzeugt HTML, verarbeitet danach aber keine Blazor-Klicks oder Bindings. Ergänze in `Home.razor`:

```razor
@rendermode InteractiveServer
```

Bei `InteractiveServer`:

- läuft der C#-Komponentencode auf dem Server,
- hält Blazor eine Verbindung zum Browser,
- werden Browserereignisse an die Komponente übermittelt,
- sendet Blazor nur die nötigen Änderungen der Oberfläche zurück.

Der Browser muss dafür nicht selbst C# ausführen können.

Das Projekt ist bereits für den interaktiven Servermodus konfiguriert. Die Direktive aktiviert ihn für diese Seite und ihre untergeordneten Komponenten.

## Komponentenzustand

Felder im `@code`-Block speichern den aktuellen Zustand:

```razor
@code {
    private string neuerTitel = "";
    private string? neueBeschreibung;
    private AufgabenStatus neuerStatus = AufgabenStatus.Offen;
    private string? fehlermeldung;

    private List<TaskItem> aufgaben = new List<TaskItem>();
}
```

Diese Felder haben unterschiedliche Aufgaben:

- Die ersten drei speichern die momentanen Formulareingaben.
- `fehlermeldung` steuert, ob eine Meldung angezeigt wird.
- `aufgaben` enthält die dauerhaft erfassten Aufgaben dieser Komponente.

Die Daten liegen zunächst nur im Arbeitsspeicher. Ein Neustart der App löscht sie.

## Texteingaben mit `@bind`

```razor
<label for="titel">Titel</label>
<input id="titel" @bind="neuerTitel" />

<label for="beschreibung">Beschreibung</label>
<textarea id="beschreibung"
          @bind="neueBeschreibung"></textarea>
```

`@bind` verbindet zwei Richtungen:

1. Der aktuelle C#-Wert wird im Eingabefeld angezeigt.
2. Eine Änderung im Eingabefeld wird in das C#-Feld übernommen.

Bei normalen Texteingaben aktualisiert das standardmäßige Binding den Wert beim Änderungsereignis, typischerweise beim Verlassen des Feldes. Für diese Formularübung genügt das.

Soll der Wert bei jedem Tastendruck aktualisiert werden, kann später `@bind:event="oninput"` verwendet werden. Das ist für die Aufgabe nicht erforderlich.

## Einen Enum mit `select` binden

```razor
<label for="status">Status</label>
<select id="status" @bind="neuerStatus">
    <option value="@AufgabenStatus.Offen">Offen</option>
    <option value="@AufgabenStatus.InArbeit">In Arbeit</option>
    <option value="@AufgabenStatus.Erledigt">Erledigt</option>
</select>
```

Das gebundene C#-Feld besitzt den Typ `AufgabenStatus`. Blazor wandelt die gewählte Option in den passenden Enum-Wert um.

Alle Werte, die in den Optionen vorkommen, müssen gültige Werte desselben Enums sein.

## Das Formular absenden

```razor
<form @onsubmit="AufgabeHinzufuegen"
      @onsubmit:preventDefault>
    <!-- Eingabefelder -->

    <button type="submit">Aufgabe hinzufügen</button>
</form>
```

- `@onsubmit` verbindet das Absenden mit der C#-Methode `AufgabeHinzufuegen`.
- `@onsubmit:preventDefault` verhindert das normale HTML-Verhalten, bei dem die Seite neu geladen würde.
- `type="submit"` löst das Submit-Ereignis des Formulars aus.

Ein zusätzlicher `@onclick` am Submit-Button ist nicht nötig. Sonst könnte dieselbe Aktion doppelt oder über zwei konkurrierende Wege ausgelöst werden.

## Eingaben in der Eventmethode validieren

```csharp
private void AufgabeHinzufuegen()
{
    if (string.IsNullOrWhiteSpace(neuerTitel))
    {
        fehlermeldung = "Der Titel darf nicht leer sein.";
        return;
    }

    // Erst nach dieser Prüfung ist der Titel gültig.
}
```

`return` beendet die Methode bei ungültiger Eingabe sofort. Dadurch wird kein Objekt angelegt und nichts zur Liste hinzugefügt.

Bei einer gültigen Eingabe sollte eine möglicherweise alte Fehlermeldung wieder entfernt werden:

```csharp
fehlermeldung = null;
```

## Fehlermeldung bedingt darstellen

```razor
@if (fehlermeldung is not null)
{
    <p class="fehler">@fehlermeldung</p>
}
```

Ist `fehlermeldung` gleich `null`, erzeugt Razor diesen Absatz nicht. Wird in der Eventmethode Text zugewiesen, rendert Blazor die Komponente erneut und der Absatz erscheint.

`is not null` ist hier eine Null-Prüfung. Alternativ wäre `fehlermeldung != null` möglich.

## Ein neues Objekt aus den Formularwerten erzeugen

Eine leere optionale Beschreibung kann vor dem Erzeugen in `null` umgewandelt werden:

```csharp
string? beschreibung = neueBeschreibung;

if (string.IsNullOrWhiteSpace(beschreibung))
{
    beschreibung = null;
}
```

Danach werden die gültigen Zustandswerte an den Konstruktor übergeben und das neue Objekt wird gespeichert:

```csharp
TaskItem neueAufgabe = new TaskItem(
    neuerTitel,
    beschreibung,
    neuerStatus
);

aufgaben.Add(neueAufgabe);
```

Falls dein eigener `TaskItem`-Konstruktor andere Parameter besitzt, erzeugst du das Objekt entsprechend diesem Konstruktor und weist den Status anschließend über die Property zu.

## Formular nach erfolgreichem Hinzufügen zurücksetzen

```csharp
neuerTitel = "";
neueBeschreibung = null;
neuerStatus = AufgabenStatus.Offen;
fehlermeldung = null;
```

Weil die Eingabefelder gebunden sind, erscheinen nach dem erneuten Rendern auch im Browser die zurückgesetzten Werte.

Setze die Felder nur nach erfolgreichem Hinzufügen zurück. Bei einem ungültigen Titel soll der Benutzer seine übrigen Eingaben nicht verlieren.

## Dynamische Liste darstellen

Die aus Lektion 13 bekannte Ausgabe verwendet weiterhin die aktuelle Liste:

```razor
<p>Gesamtzahl: @aufgaben.Count</p>

@foreach (TaskItem aufgabe in aufgaben)
{
    <section>
        <h2>@aufgabe.Titel</h2>
        <p>@(aufgabe.Beschreibung ?? "Keine Beschreibung")</p>
        <p>Status: @aufgabe.Status</p>
    </section>
}
```

Nach `aufgaben.Add(...)` rendert Blazor die Komponente erneut. Deshalb aktualisieren sich die Anzahl und die Liste ohne manuelles Neuladen.

## Button nur bei nicht erledigten Aufgaben anzeigen

```razor
@if (aufgabe.Status != AufgabenStatus.Erledigt)
{
    <button type="button"
            @onclick="() => AufgabeErledigen(aufgabe)">
        Erledigt
    </button>
}
```

Die `if`-Bedingung wird für jedes aktuelle Listenelement ausgewertet. Bei bereits erledigten Aufgaben wird der Button gar nicht erzeugt.

`type="button"` verhindert, dass der Button versehentlich ein umgebendes Formular absendet.

## Das aktuelle Listenelement an die Methode übergeben

```razor
@onclick="() => AufgabeErledigen(aufgabe)"
```

Der Lambda-Ausdruck bedeutet: „Wenn geklickt wird, rufe die Methode auf und übergib die aktuelle Aufgabe.“

Ohne Lambda würde ein Aufruf mit Argument nicht als auf den Klick wartende Aktion beschrieben. Der Lambda-Ausdruck hält für jede dargestellte Karte die jeweils passende Objektvariable fest.

Die zugehörige Methode verändert den Status dieses Objekts:

```csharp
private void AufgabeErledigen(TaskItem aufgabe)
{
    aufgabe.Status = AufgabenStatus.Erledigt;
}
```

`TaskItem` ist eine Klasse. Der Parameter verweist daher auf dasselbe Objekt, das in der Liste liegt. Die Änderung ist sofort über die Liste sichtbar.

## Automatisches erneutes Rendern

Nach einem von Blazor behandelten Ereignis läuft vereinfacht Folgendes ab:

```text
Browserereignis
    → C#-Eventmethode
    → Zustand wird verändert
    → Blazor rendert die Komponente erneut
    → Browser erhält die notwendigen Änderungen
```

Für normale synchrone `@onclick`- und `@onsubmit`-Methoden musst du `StateHasChanged()` nicht selbst aufrufen.

## Sinnvolle Reihenfolge beim Implementieren

1. Aktiviere `InteractiveServer`.
2. Übernimm Modelle und statische Listenausgabe aus Lektion 13.
3. Lege die vier Formularfelder im `@code`-Block an.
4. Baue das Formular mit `@bind` für Titel, Beschreibung und Status.
5. Verbinde das Formular über `@onsubmit` und `preventDefault`.
6. Prüfe zuerst nur die Validierung und Fehlermeldung.
7. Erzeuge danach das Objekt und füge es zur Liste hinzu.
8. Setze die Eingabefelder erst nach erfolgreichem Hinzufügen zurück.
9. Ergänze den bedingten Erledigt-Button in der Schleife.
10. Übergib die aktuelle Aufgabe per Lambda und ändere ihren Status.

## Testplan

- Leerer Titel und Titel nur aus Leerzeichen: Fehlermeldung, kein neues Objekt.
- Aufgabe ohne Beschreibung: wird hinzugefügt und zeigt den Ersatztext.
- Je eine Aufgabe mit allen drei Statuswerten.
- Mehrere Aufgaben direkt nacheinander.
- Erledigt-Button bei der ersten und bei einer späteren Aufgabe.
- Nach dem Klick wird genau die gewählte Aufgabe erledigt.
- Bei erledigten Aufgaben verschwindet der Button.
- Anzahl und Liste aktualisieren sich ohne Browser-Neuladen.

## Häufige Fehler

- `@rendermode InteractiveServer` fehlt und Klicks reagieren nicht.
- Ein Eingabefeld ist nicht an das zugehörige C#-Feld gebunden.
- Die Select-Optionen passen nicht zum Typ des gebundenen Enum-Feldes.
- `preventDefault` fehlt und der Browser lädt die Seite beim Absenden neu.
- Submit-Button und `@onsubmit` rufen dieselbe Methode zusätzlich über `@onclick` auf.
- Nach einer Fehlermeldung fehlt `return` und die ungültige Aufgabe wird trotzdem hinzugefügt.
- Die Eingaben werden auch bei fehlgeschlagener Validierung zurückgesetzt.
- Im `@onclick` wird die aktuelle Aufgabe nicht übergeben.
- Der Status einer neuen statt der angeklickten Aufgabe wird geändert.
- Es wird unnötig manuell `StateHasChanged()` aufgerufen.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "14_Blazor-Interaktionen/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "14_Blazor-Interaktionen/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "14_Blazor-Interaktionen/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
