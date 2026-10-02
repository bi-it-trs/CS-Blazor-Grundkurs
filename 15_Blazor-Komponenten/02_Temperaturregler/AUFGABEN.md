# 02 – Temperaturregler: Ereignis über zwei Ebenen

## Start

Dieses Projekt ist unabhängig von Aufgabe 01. Starte es in diesem Verzeichnis:

```powershell
dotnet run --launch-profile http
```

Die Seite zeigt zunächst **20 °C**. Beide Knöpfe sind absichtlich noch ohne Funktion. Lies bei Bedarf [THEORIE_UND_ANLEITUNG.md](THEORIE_UND_ANLEITUNG.md); die Codebeispiele dort stammen aus einer anderen Anwendung.

## Ziel

„Kälter“ sendet pro Klick `-1`, „Wärmer“ sendet pro Klick `1`. Der Wert geht vom HTML-Button über `SchrittKnopf` und `TemperaturRegler` an `Home`. Nur `Home` speichert und ändert die Temperatur. `TemperaturAnzeige` erhält den aktuellen Wert bereits als Parameter.

## Arbeitsreihenfolge

1. **`Components/Uebung/SchrittKnopf.razor`:** Ergänze eine öffentliche `[Parameter]`-Property vom Typ `EventCallback<int>`. Verbinde den vorhandenen HTML-Button mit `@onclick`. Bei einem Klick soll die bereits vorhandene Property `Schritt` mit `InvokeAsync` gemeldet werden.
2. **`Components/Uebung/TemperaturRegler.razor`:** Ergänze eine öffentliche `[Parameter]`-Property vom Typ `EventCallback<int>` für die Meldung an `Home`. Verbinde *beide* `SchrittKnopf`-Tags mit derselben Methode des Reglers. Diese Methode nimmt `int schritt` entgegen und reicht ihn über den neuen Callback an `Home` weiter. Sie speichert keine Temperatur und braucht keine getrennte Plus- und Minusmethode.
3. **`Components/Pages/Home.razor`:** Verbinde den Callback des Reglers mit einer Methode, die `int schritt` entgegennimmt und ihn zu `temperatur` addiert. Übergib im Tag den **Methodennamen ohne Klammern**.

Die vorhandenen Attribute `Schritt="-1"` und `Schritt="1"` setzen die Parameter der beiden Knopf-Instanzen. Sie sind keine Variablen im Regler. `TemperaturAnzeige.razor` muss nicht geändert werden.

## Vorhersage und Selbsttest

Sage vor dem Start die erwarteten Werte für diese Folge voraus: „Kälter“, „Kälter“, „Wärmer“.

- Start: beide Anzeigen zeigen **20 °C**.
- „Wärmer“: beide zeigen **21 °C**.
- Danach „Kälter“: beide zeigen wieder **20 °C**.
- Die oben genannte Folge ab Start ergibt **19 °C**.
- Ein `Schritt` ist bei jedem Klick erneut `-1` oder `1`; die Summe wird in `temperatur` gespeichert.
- `dotnet build` endet ohne Fehler.

Wenn sich nichts ändert, prüfe jede Verbindung einzeln: HTML-`@onclick` → Callback des Knopfs → Methode im Regler → Callback an `Home` → Methode in `Home`. Ein unverbundener Callback bewirkt keinen sichtbaren Fehler, aber auch keine Zustandsänderung.

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "15_Blazor-Komponenten/02_Temperaturregler/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "15_Blazor-Komponenten/02_Temperaturregler/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "15_Blazor-Komponenten/02_Temperaturregler/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
