# Komponentenkommunikation · Übung 2

Deine fertige [Farb-Übung](UEBUNG1.md) liegt weiterhin unter `/farben`. Jetzt kommt **eine zusätzliche Ebene** zwischen Klick und zustandsbesitzender Komponente dazu.

## Start

Im Ordner `comp_comm`:

```powershell
dotnet run --launch-profile http
```

Öffne die angezeigte Adresse. Die Seite zeigt zunächst **20 °C**. Die Knöpfe sind absichtlich noch nicht verbunden.

## Vorhersage

Bevor du etwas änderst: Welche Zahl muss nach „Kälter“, „Kälter“, „Wärmer“ erscheinen? Sage außerdem den vollständigen Weg dieser Zahl vom Knopf bis zur Anzeige laut auf.

## Deine Aufgabe

Bearbeite diese drei Dateien in der angegebenen Reihenfolge:

1. `Components/Uebung/SchrittKnopf.razor`: Ergänze einen `EventCallback<int>`. Ein Klick soll den vorhandenen `Schritt` melden. Die Werte `-1` und `1` kommen bereits als Parameter vom Regler.
2. `Components/Uebung/TemperaturRegler.razor`: Ergänze ebenfalls einen `EventCallback<int>`. Verbinde beide `SchrittKnopf`-Komponenten mit **einer** Methode im Regler. Diese Methode nimmt den gemeldeten `int` entgegen und leitet ihn mit `InvokeAsync` an `Home` weiter. Der Regler speichert keine Temperatur.
3. `Components/Pages/Home.razor`: Verbinde den Callback des Reglers mit einer Methode. Diese Methode addiert den empfangenen Schritt zur vorhandenen Variablen `temperatur`.

`TemperaturAnzeige.razor` ist bereits fertig. Du musst dort nichts ändern.

## Selbstkontrolle

- Start: **20 °C** in `Home` und in der Anzeige.
- „Wärmer“: **21 °C** in beiden Anzeigen.
- Danach „Kälter“: wieder **20 °C**.
- Zweimal „Kälter“, einmal „Wärmer“ ab Start: **19 °C**.
- Du kannst erklären, warum `SchrittKnopf` keine Referenz auf `Home` und keine eigene Temperatur braucht.

Wenn du feststeckst, vergleiche den Weg `FarbAuswahl → Home` aus Übung 1. Hier geschieht derselbe Schritt zweimal hintereinander: `SchrittKnopf → TemperaturRegler → Home`.

**Schreib `p`, wenn es funktioniert.** Dann prüfe ich deinen Code und gestalte die nächste Übung passend dazu.
