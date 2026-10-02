# Theorie und Anleitung – Ereignisse über mehrere Ebenen

Die Beispiele verwenden ein **Punktekonto**. Die Aufgabe selbst arbeitet mit einer anderen Anwendung.

## Was ein Komponenten-Tag setzt

Angenommen, eine Komponente besitzt diese Properties:

```csharp
[Parameter]
public int Punkte { get; set; }

[Parameter]
public EventCallback<int> OnPunkte { get; set; }
```

Dann setzt `<PunkteTaste Punkte="5" OnPunkte="Weiterreichen" />` zwei verschiedene Dinge:

- `Punkte="5"` gibt **dieser einen Komponenteninstanz** den Wert `5`.
- `OnPunkte="Weiterreichen"` verbindet ihren Callback mit einer Methode der direkt umgebenden Komponente.

Namen links vom `=` müssen exakt zu den `[Parameter]`-Properties der Kindkomponente passen. Es gibt keine automatische Übernahme in gleichnamige Properties des Elternteils.

## Der Klick entsteht am HTML-Button

In `PunkteTaste.razor` könnte stehen:

```razor
<button type="button" @onclick="() => OnPunkte.InvokeAsync(Punkte)">
    @Punkte Punkte geben
</button>

@code {
    [Parameter]
    public int Punkte { get; set; }

    [Parameter]
    public EventCallback<int> OnPunkte { get; set; }
}
```

`@onclick` gehört hierher, weil **hier der echte HTML-Button** steht. Der Lambda-Ausdruck wartet auf den Klick. `InvokeAsync(Punkte)` sendet den Wert der angeklickten Komponenteninstanz nach oben. Die Taste braucht dazu keine Referenz auf die Seite.

Wenn eine Taste `Punkte="5"` erhält, sendet sie bei jedem Klick wieder `5`. Die Property zählt Klicks nicht zusammen. Ein `int` ohne Zuweisung hätte zwar den Standardwert `0`, aber hier weist das Tag ausdrücklich `5` zu.

## Eine mittlere Komponente reicht weiter

Ein `PunktePanel.razor` kann zwei Tasten enthalten:

```razor
<PunkteTaste Punkte="5" OnPunkte="Weiterreichen" />
<PunkteTaste Punkte="-3" OnPunkte="Weiterreichen" />

@code {
    [Parameter]
    public EventCallback<int> OnAenderung { get; set; }

    private Task Weiterreichen(int delta)
    {
        return OnAenderung.InvokeAsync(delta);
    }
}
```

Beide Tasten rufen **dieselbe Methode** auf. Der Methodenparameter `delta` enthält jeweils den gesendeten Wert, also `5` oder `-3`. Er existiert nur während dieses Methodenaufrufs. Er muss nicht als zusätzliche `[Parameter]`-Property im Panel deklariert werden.

`Task` steht hier, weil `InvokeAsync` asynchron abgeschlossen wird. Mit `return OnAenderung.InvokeAsync(delta)` gibt die Methode diesen Task weiter. Gleichwertig wäre eine `async Task`-Methode mit `await`.

## Die Seite besitzt den dauerhaften Zustand

```razor
<PunktePanel OnAenderung="PunktestandAendern" />
<p>Punktestand: @punktestand</p>

@code {
    private int punktestand = 10;

    private void PunktestandAendern(int delta)
    {
        punktestand += delta;
    }
}
```

`OnAenderung="PunktestandAendern"` übergibt **die Methode**, nicht ihr Ergebnis. `PunktestandAendern(delta)` im Tag wäre ein sofortiger Methodenaufruf; außerdem gibt es dort noch keine lokale Variable `delta`. Blazor ruft die verbundene Methode später mit dem Wert aus `InvokeAsync` auf.

Nach zwei Klicks auf die `-3`-Taste ist `punktestand` zuerst `7`, dann `4`. Das gesendete `delta` ist bei beiden Klicks `-3`, nicht beim zweiten Klick `-6`.

## Derselbe Weg als Bild in Text

```text
HTML-Button in PunkteTaste
  → OnPunkte.InvokeAsync(Punkte)
  → Weiterreichen(int delta) in PunktePanel
  → OnAenderung.InvokeAsync(delta)
  → PunktestandAendern(int delta) auf der Seite
  → Zustand ändert sich
  → Blazor rendert die Anzeige neu
```

Der Callback ist selbst eine `[Parameter]`-Property, obwohl Ereignisse gedanklich **nach oben** gehen: Der Elternteil gibt dem Kind zunächst die passende Methode; später meldet das Kind den Wert zurück. Die mittlere Komponente kann einen Callback auch direkt an das tiefere Kind durchreichen. In dieser Übung soll sie ausdrücklich eine eigene Methode verwenden, damit du den Zwischenstopp beobachten kannst.

## Häufige Stolperstellen

- `OnPunkte="Weiterreichen"` verbindet eine Methode; `OnPunkte="Weiterreichen(delta)"` versucht sie am falschen Ort aufzurufen.
- `delta` ist nur **innerhalb** von `Weiterreichen(int delta)` sichtbar. Eine gleichnamige Property im Panel bekommt den Callback-Wert nicht automatisch.
- Der Wert bei `InvokeAsync(...)` und der Parameter der empfangenden Methode müssen zum Typ des `EventCallback<int>` passen.
- Eine Lambda-Funktion ohne `int`-Argument kann den gesendeten Wert nicht aus der Luft lesen.
- Nur die Seite verändert ihren dauerhaften Zustand. Das Panel vermittelt; die Taste meldet den Klick.
- Bei einem interaktiven Blazor-Ereignis rendert die Oberfläche normalerweise von selbst neu; ein zusätzliches `StateHasChanged()` ist hier nicht erforderlich.

Razor-Komponenten können neben Markup auch `@code` enthalten. Größere Logik kann in eine `.razor.cs`-Datei ausgelagert werden. Für Logik ohne eigene Oberfläche eignet sich eine normale C#-Klasse; die Komponenten selbst werden beim Verwenden als Tags von Blazor erzeugt.
