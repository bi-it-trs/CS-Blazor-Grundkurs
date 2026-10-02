# Komponentenkommunikation · Übung 1

Diese abgeschlossene Übung ist jetzt unter `/farben` erreichbar. Die frühere Startseite heißt inzwischen `Components/Pages/Farben.razor`. Die folgenden Schritte dokumentieren die ursprüngliche Aufgabe.

Du hast im Lerntracker bereits eine Aufgabe per `[Parameter]` an eine Karte gegeben und einen Klick mit `EventCallback<TaskItem>` zurückgemeldet. Hier überträgst du dieses Prinzip auf **zwei Geschwisterkomponenten**.

## Start

Im Ordner `comp_comm`:

```powershell
dotnet run --launch-profile http
```

Öffne die angezeigte lokale Adresse im Browser. Das Projekt startet bereits. Die Farbknöpfe sind absichtlich noch ohne Funktion.

## Denkfrage vor dem Coden

`FarbAuswahl` und `FarbVorschau` kennen einander nicht. Zeichne oder sage den Weg einer angeklickten Farbe laut auf: Welche Komponente besitzt den Zustand? Über welche Verbindung geht die Farbe nach oben, über welche nach unten?

## Deine Aufgabe

Bearbeite nur diese drei Dateien:

1. `Components/Uebung/FarbAuswahl.razor`: Melde die angeklickte Farbe mit einem `EventCallback<string>` an die Elternkomponente. Die `foreach`-Variable `farbe` ist der Wert, den du senden sollst.
2. `Components/Pages/Farben.razor`: Verbinde dieses Ereignis mit einer Methode, die `ausgewaehlteFarbe` aktualisiert. Übergib den aktuellen Wert an die Vorschau.
3. `Components/Uebung/FarbVorschau.razor`: Mache `Farbe` zu einem `[Parameter]`, damit die Vorschau ihren Wert von `Home` erhält.

Die Vorschau soll ihre Farbe nicht selbst ändern. Der Zustand liegt in `Home`.

## Selbstkontrolle

- Nach dem Start zeigen Elternzustand und Vorschau **Blau**.
- Ein Klick auf **Grün** ändert beide Anzeigen und das Farbfeld auf Grün.
- Danach ändern Klicks auf **Orange** und **Blau** ebenfalls beide Anzeigen.
- Du kannst erklären, warum ein Klick in `FarbAuswahl` auch `FarbVorschau` verändert, obwohl die beiden keine direkte Verbindung haben.

Wenn du feststeckst, beginne mit der Frage: *Welche öffentliche Property braucht das Kind, um etwas nach oben zu melden?* Nutze deinen Code aus `LernaufgabenTracker/Components/AufgabenKarte.razor` als Muster. Für die Vorschau hilft dir derselbe `[Parameter]`-Mechanismus, nur mit `string` statt `TaskItem`.

**Wenn es funktioniert, schreib im Chat `p`.** Dann prüfen wir deinen Code und gehen gezielt zur nächsten Übung über.

