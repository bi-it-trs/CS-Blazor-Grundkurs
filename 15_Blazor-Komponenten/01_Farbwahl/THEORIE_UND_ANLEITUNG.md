# Theorie und Anleitung – Daten zwischen Geschwistern

Die Beispiele hier verwenden eine **Notiz-App**, nicht die Farbwahl. Übertrage das Prinzip anschließend selbst auf die Aufgabe.

## Komponenten sind getrennte Klassen

Jede `.razor`-Datei wird zu einer eigenen Komponentenklasse. Ein privates Feld in `Home.razor` ist in einer anderen `.razor`-Datei nicht direkt sichtbar. Du erzeugst eine Razor-Komponente normalerweise nicht mit `new`, sondern setzt sie als Tag in das Markup. Blazor erstellt ihre Instanz.

```razor
<NotizEingabe />
<NotizAnzeige />
```

Diese beiden Komponenten sind Geschwister. Sie greifen nicht auf die privaten Felder der jeweils anderen zu. Ein gemeinsamer Elternteil kann ihre Daten und Ereignisse verbinden.

## Zwei Richtungen, zwei Arten von Parametern

**Daten nach unten:** Ein Kind deklariert eine öffentliche Property mit `[Parameter]`. Der Elternteil setzt sie im Komponenten-Tag.

```razor
<p>Gespeicherte Notiz: @Text</p>

@code {
    [Parameter]
    public string Text { get; set; } = string.Empty;
}
```

Im Eltern-Markup könnte stehen:

```razor
<NotizAnzeige Text="@gespeicherteNotiz" />
```

Links vom `=` steht **der Propertyname des Kindes** (`Text`). Rechts steht **das Feld des Elternteils** (`gespeicherteNotiz`). Die Namen müssen nicht identisch sein; der Typ muss passen. `public` allein reicht nicht: Ohne `[Parameter]` ist die Property kein von außen setzbarer Komponentenparameter.

**Aktionen nach oben:** Auch ein `EventCallback<string>` ist eine `[Parameter]`-Property. Sie erhält eine Methode des Elternteils. Das Kind löst diese Methode später mit einem Wert aus.

```razor
<input @bind="eingabe" aria-label="Notiz" />
<button type="button" @onclick="NotizMelden">Speichern</button>

@code {
    private string eingabe = string.Empty;

    [Parameter]
    public EventCallback<string> OnNotizGesendet { get; set; }

    private Task NotizMelden()
    {
        return OnNotizGesendet.InvokeAsync(eingabe);
    }
}
```

`InvokeAsync(eingabe)` sendet **den string**, keine Referenz auf die Kindkomponente. Die verbundene Elternmethode muss deshalb einen `string` annehmen:

```razor
<NotizEingabe OnNotizGesendet="NotizSpeichern" />
<NotizAnzeige Text="@gespeicherteNotiz" />

@code {
    private string gespeicherteNotiz = "Noch keine Notiz";

    private void NotizSpeichern(string text)
    {
        gespeicherteNotiz = text;
    }
}
```

`OnNotizGesendet="NotizSpeichern"` übergibt die **Methode** als Callback. Es ruft sie beim Rendern nicht auf. Erst `InvokeAsync` im Kind löst sie aus. Nach dem Ereignis rendert Blazor den betroffenen Komponentenbaum erneut; die Anzeige erhält den neuen Elternwert. Ein manuelles `StateHasChanged()` ist dafür nicht nötig.

## Werte in einer Schleife melden

Wenn eine Komponente mehrere Knöpfe aus einer Liste erzeugt, steht die aktuelle Schleifenvariable nur im Schleifenblock zur Verfügung:

```razor
@foreach (string kategorie in kategorien)
{
    <button type="button"
            @onclick="() => OnKategorieGewaehlt.InvokeAsync(kategorie)">
        @kategorie
    </button>
}
```

Der Lambda-Ausdruck `() => ...` wartet auf den Klick und verwendet dann den Wert des angeklickten Knopfs. `kategorie` ist nicht automatisch ein Zustand im Elternteil; erst der Callback sendet sie dorthin.

## Was gehört wem?

Die Eingabekomponente darf temporäre Eingaben besitzen. Der **dauerhaft gewählte** Wert gehört zum gemeinsamen Elternteil, wenn mehrere Kinder ihn brauchen. Das anzeigende Kind liest seinen Parameter und überschreibt ihn nicht selbst. Bei jedem Rendern könnte der Elternteil ohnehin seinen Wert erneut setzen.

Eine gleichnamige Property in zwei Kindkomponenten ist erlaubt: Es sind zwei verschiedene Klassen und Instanzen. Die Verbindung entsteht ausschließlich in den Komponenten-Tags des Elternteils.

## Fehlersuche

1. Existiert in der Kinddatei die `[Parameter]`-Property mit exakt dem Namen aus dem Tag?
2. Ist der Typ des Callback-Werts derselbe wie der Typ des Methodenparameters im Elternteil?
3. Ruft das Kind `InvokeAsync(wert)` tatsächlich beim Ereignis auf?
4. Übergibt der Elternteil die Methode **ohne** Klammern, zum Beispiel `OnNotizGesendet="NotizSpeichern"`?
5. Zeigt das zweite Kind den Parameter statt eines eigenen festen Feldes an?
6. Steht `@rendermode InteractiveServer` auf der Seite, damit Klicks verarbeitet werden?

Ein Modell oder eine neue Klasseninstanz ist für einen einzelnen `string` nicht nötig. Normale C#-Klassen sind sinnvoll, wenn mehrere zusammengehörende Daten ein Objekt bilden; Razor-Komponenten bleiben für die Oberfläche zuständig.
