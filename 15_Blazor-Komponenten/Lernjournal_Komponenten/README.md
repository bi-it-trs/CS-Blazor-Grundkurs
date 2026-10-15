# Blazor Datenlabor

Eine kleine Blazor Web App für eigene Versuche und Screenshots im Lernjournal.
Jeder Themenordner enthält eine eigenständige Seite und ihre Kindkomponenten.
Die Oberfläche verwendet nur normales HTML, ohne CSS oder UI-Bibliotheken.

## Starten

Voraussetzung: .NET 10 SDK. Auf diesem Computer ist es bereits vorhanden.

- `Starten.cmd` doppelklicken. Das Fenster muss während der Nutzung offen bleiben.
- Falls sich kein Browser öffnet: <http://localhost:5104> aufrufen.
- Beenden: im laufenden Fenster Strg+C drücken.

Alternativ im Projektordner:

```powershell
dotnet run --launch-profile http
```

Mit automatischem Neuladen beim Bearbeiten in VS Code:

```powershell
dotnet watch --launch-profile http
```

Nur eine Instanz gleichzeitig starten, da beide Varianten denselben Port 5104 verwenden.

In Visual Studio die Datei `BlazorDatenlabor.csproj` öffnen und das Profil `http` starten.
Die App läuft lokal mit interaktivem Server-Rendering. Die Browser-Verbindung muss bestehen bleiben.
Beim ersten Start stellt .NET gegebenenfalls benötigte Frameworkdateien über NuGet wieder her.
Es gibt keine zusätzlichen Bibliotheken oder PackageReference-Einträge.

## Aufbau

`Components/Pages/Start.razor` ist die Übersicht. Die Navigation bleibt absichtlich einfach.
Jeder weitere Ordner unter `Components/Pages` enthält genau ein Thema.
Seiten besitzen eine `@page`-Direktive; reine Kindkomponenten besitzen keine Route.
Die Seitennummern bestimmen die empfohlene Reihenfolge.

`Models/Person.cs` enthält das Beispielobjekt.
`Services/LernZustand.cs` enthält den gemeinsamen Zustand.
`Services/SignalDienst.cs` simuliert ein externes Ereignis.
In `Program.cs` werden die beiden Dienste mit `AddScoped` registriert.
In `Components/App.razor` wird die App interaktiv geschaltet.

## Versuche und passende Code-Screenshots

| Nr. | Route | Dateien in Components/Pages | Versuch und erwartetes Ergebnis |
| --- | --- | --- | --- |
| 01 | `/parameter` | `Parameter/ParameterDemo.razor`, `TextAnzeige.razor` | Text ändern und Zahl erhöhen. Das erste Kind folgt den Eltern, das zweite zeigt feste bzw. Standardwerte. |
| 02 | `/callback` | `Callback/CallbackDemo.razor`, `TextSender.razor` | Nachricht senden und Ereignis ohne Daten auslösen. Die Eltern zeigen Nachricht bzw. Zähler. Im aufgeklappten Beispiel ist kein Handler zugewiesen. |
| 03 | `/lambda` | `Lambda/LambdaDemo.razor` | Methodenreferenz, feste Argumente, empfangenen Text plus Nummer und Schleifenbuttons vergleichen. Jede Nummer bleibt korrekt. Der letzte Button bekommt MouseEventArgs. |
| 04 | `/methoden` | `Methoden/MethodenDemo.razor`, `AnfrageBox.razor` | Einen string synchron und mit Task<string> laden. Danach dieselben Methoden vom Kind über Func abfragen. Die Ergebnisse erscheinen jeweils beim Aufrufer. |
| 05 | `/async` | `Async/AsyncDemo.razor`, `LadeKnopf.razor` | Laden starten: Während 1,5 Sekunden warten Kind und Eltern. Der Ablauf zeigt, dass die Zeile nach await erst anschließend erreicht wird. Danach Checkbox aktivieren und den abgefangenen Fehler ausprobieren. |
| 06 | `/binding` | `Binding/BindingDemo.razor`, `TextEingabe.razor` | In beide Felder schreiben. Beide Felder und die Elternanzeige zeigen denselben Wert. Ausgeschriebene Übergabe und @bind-Text vergleichen. |
| 07 | `/geschwister` | `Geschwister/GeschwisterDemo.razor`, `TextEditor.razor`, `TextVorschau.razor` | Entwurf ändern: Noch keine Übergabe. Erst Senden aktualisiert Eltern und zweites Kind. |
| 08 | `/referenz` | `Referenz/ReferenzDemo.razor`, `Zaehler.razor` | Im Kind erhöhen, bei den Eltern abfragen, dann das Kind zurücksetzen. Die Momentaufnahme bei den Eltern bleibt bis zur nächsten Abfrage erhalten. |
| 09 | `/kaskade` | `Kaskade/KaskadeDemo.razor`, `ZwischenEbene.razor`, `NameAnzeige.razor` | Namen ändern: Das Enkelkind folgt, obwohl die Zwischenebene keinen eigenen Parameter dafür besitzt. |
| 10 | `/zustand` | `Zustand/ZustandDemo.razor`, `NameEditor.razor`, `NameAnzeige.razor` | Namen speichern: Beide Anzeigen folgen. Zur Übersicht und zurück navigieren: Der Name bleibt. Vollständig neu laden: Wieder Sam. |
| 11 | `/objekte` | `Objekte/ObjektDemo.razor`, `PersonEditor.razor` | Name und Alter als Entwurf ändern und speichern: Neue Person plus Callback-Zähler. Anschließend direkt ändern und Elternanzeige neu rendern: gemeinsame Referenz ohne zusätzlichen Callback. |
| 12 | `/aktualisierung` | `Aktualisierung/AktualisierungDemo.razor` und `Services/SignalDienst.cs` | Signal starten: Nach 1,5 Sekunden erscheint die Nachricht aus dem Hintergrund. Während des Wartens lässt sich der Zwischenstand per normalem Klick ändern. |

Für einen Screenshot den gewünschten Beispielordner im Editor öffnen und die zugehörige Seite im Browser anzeigen.
Eltern und Kinder sind durch HTML-fieldsets mit Beschriftung erkennbar.
Kompliziertere Sonderfälle sind auf späteren Seiten oder in aufklappbaren Abschnitten untergebracht.
Ein Seitenwechsel über die Übersicht setzt lokalen Zustand zurück. Vollständiges Neuladen setzt auch die scoped Dienste zurück.

## Warum passt eine Methode nicht zum Callback?

Eingabeparameter und Rückgabewert sind verschiedene Dinge.
`EventCallback<string>` gibt einen string an den Handler weiter.
Das generische Argument string bezeichnet nicht dessen Rückgabewert.

```csharp
void TextEmpfangen(string text)       // passend: string als Eingabe
Task TextEmpfangenAsync(string text)  // passend: string als Eingabe, asynchroner Abschluss
string TextErstellen()                // Abfrage: liefert einen string zurück
Task<string> TextLadenAsync()         // Abfrage: liefert nach await einen string zurück
```

Die Zeilen oben sind eine Übersicht der Signaturen, kein vollständiger Codeblock zum Kompilieren.

Blazor verwendet für Ereignisse gewöhnlich Handler mit void oder Task als Rückgabetyp,
je nach Ereignis ohne Parameter oder mit einem passenden Eingabeparameter.
Eine synchrone string-Methode lässt sich nicht direkt als solche Methodenreferenz zuweisen.
Ein Handler kann sie aber aufrufen und den Rückgabewert speichern:

```csharp
private void TextSetzen()
{
    ergebnis = TextErstellen();
}
```

Auch die Eingabetypen müssen passen: Ein Handler, der int erwartet, passt nicht zu einem
EventCallback<string>. Eine Lambda kann Werte ergänzen oder ausdrücklich umwandeln.
Sie macht aber aus einem beliebigen Rückgabewert nicht automatisch einen Callback-Rückkanal.

Zwei Sonderfälle stehen auf Seite 04:

- `() => TextErstellen()` kann als Action kompiliert werden. Der zurückgegebene string wird verworfen.
- Task<string> erbt von Task. Eine entsprechende Methode kann als Task-Handler zuweisbar sein;
  Blazor wartet dann auf den Abschluss, übernimmt aber den string nicht als Anzeigewert.

Wenn das Kind gezielt einen Wert von den Eltern abfragen soll, zeigen `Func<string>` und
`Func<Task<string>>` einen ausdrücklichen Rückgabekanal. Anders als EventCallback bringen
diese Delegates keine automatische Ereignisbenachrichtigung für das Rendern der Eltern mit.
Für normale Änderungsmeldungen bleiben EventCallbacks die passende Wahl.

Nicht kompilierbare Zuweisungen stehen in Razor-Kommentaren (`@* ... *@`).
Die übrige App bleibt dadurch ausführbar. Zum Untersuchen eines Compilerfehlers
nur ein Gegenbeispiel aktivieren und anschließend wieder auskommentieren.

## Methodenreferenz, Aufruf und Lambda

```razor
<button @onclick="TextSetzen">Methodenreferenz</button>
<button @onclick='() => TextMitNummer("Hallo", 7)'>Lambda</button>
```

`TextSetzen` übergibt die Methode. `TextSetzen()` würde sie sofort aufrufen.
Die Lambda ist selbst eine Funktion und führt ihren Inhalt erst beim Klick aus.
Auf Seite 03 ergänzt eine weitere Lambda einen empfangenen string um eine feste Nummer.
In der for-Schleife bekommt jede Lambda eine eigene lokale Variable.
Ein aufklappbares Zusatzbeispiel auf Seite 03 zeigt außerdem eine asynchrone Lambda,
die den empfangenen Text nach einer kurzen Wartezeit übernimmt.

## Task, await und die beiden InvokeAsync-Methoden

| Ausdruck | Aufgabe |
| --- | --- |
| `await LadenAsync()` | Auf eine asynchrone Operation warten. |
| `string text = await TextLadenAsync()` | Auf eine Operation warten und ihren Rückgabewert übernehmen. |
| `await TextGesendet.InvokeAsync(text)` | EventCallback auslösen und auf den Handler warten. |
| `await InvokeAsync(aktion)` | Aktion über die Komponente im Blazor-Ausführungskontext ausführen. |
| `StateHasChanged()` | Rendern anfordern; wechselt keinen Ausführungskontext. |

`async` startet nicht automatisch einen neuen Thread. Task.Delay simuliert hier eine Wartezeit,
ohne den Thread zu blockieren. Normale Blazor-Ereignishandler benötigen in diesen Beispielen
keinen zusätzlichen StateHasChanged-Aufruf. Der absichtlich fehlschlagende Eltern-Handler
fordert vor dem Werfen der Exception ausdrücklich ein Rendern an: Bei einem fehlerhaften
Task entfällt das automatische Rendern am erfolgreichen Abschluss. Auch für das externe
Signal wird die Aktualisierung ausdrücklich im Blazor-Kontext angefordert.

Task.Run wird ausschließlich im SignalDienst verwendet, um den externen Aufruf zu demonstrieren.
Es ist kein notwendiger Bestandteil normaler asynchroner Datenabfragen.
Bei mehreren asynchronen Ereignisabonnenten wartet der Dienst jeden Task einzeln ab.
Komponenten melden sich in Dispose vom Dienst ab.

## Weitere bewusste Grenzen

- Der Zustandsdienst aus Beispiel 10 wird nur von Blazor-Ereignissen aus geändert.
  Für Änderungen von außerhalb des Blazor-Kontexts gilt Beispiel 12.
- Objekte werden nicht automatisch auf Änderungen überwacht. Eine gemeinsam referenzierte
  Person kann bereits verändert sein, obwohl eine andere Anzeige noch den alten Stand zeigt.
- OnParametersSet befüllt den Objektentwurf nur, wenn eine neue Person übergeben wird.
  So überschreibt ein gewöhnliches Rendern der Eltern keine ungespeicherte Eingabe.
- @ref ist nach dem Rendern verfügbar, nicht bereits in OnInitialized.
- Es gibt keine Persistenz, Validierungsbibliothek, Authentifizierung oder Datenbank.
  Das Projekt konzentriert sich auf Datenwege zwischen Komponenten.

## Kompilierung

```powershell
dotnet build
```

## Dokumentation zum Nachschlagen

- [Komponenten und Parameter](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-10.0)
- [Ereignisbehandlung und EventCallback](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/event-handling?view=aspnetcore-10.0)
- [Binding](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/data-binding?view=aspnetcore-10.0)
- [Synchronisierungskontext und InvokeAsync](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/synchronization-context?view=aspnetcore-10.0)

## Eingecheckten Beispielstand wiederherstellen

Im Repository-Ordner `cs_uebungen` ausf?hren. Der Befehl verwirft ?nderungen nur im Lernjournal:

```powershell
git restore --source=komponenten-ergaenzungen-start --staged --worktree -- "15_Blazor-Komponenten/Lernjournal_Komponenten/"
```

Der ?ltere Tag `uebungen-start` enth?lt dieses Projekt noch nicht. Neue, nicht versionierte Dateien bleiben stehen. Mit `git clean -nd -- "15_Blazor-Komponenten/Lernjournal_Komponenten/"` zuerst pr?fen und nur bei Bedarf mit `git clean -fd -- "15_Blazor-Komponenten/Lernjournal_Komponenten/"` endg?ltig l?schen.
