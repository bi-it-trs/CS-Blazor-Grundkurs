# 05 – Zwei Geschwister ohne Vorlage verbinden

Starte das eigenständige Projekt im Ordner `05_Punktewahl` mit `dotnet run`. Anfangs funktioniert die Punktewahl vollständig in `Home.razor`.

## Deine Aufgabe

Lagere die fünf Knöpfe in die leere Datei `Components/Uebung/PunkteAuswahl.razor` aus. Lagere die beiden Absätze mit dem gewählten Wert und der Rückmeldung in `Components/Uebung/PunkteAnzeige.razor` aus.

`Home` besitzt weiterhin `punkte` und ändert den Wert. Die Auswahl meldet einen Klick an `Home`; die Anzeige erhält die Daten von `Home`. Die Liste `zahlen` darfst du zusammen mit den Knöpfen in die Auswahlkomponente verschieben. Überlege selbst, wo die berechnete `Rueckmeldung` sinnvoll bleibt und welche Werte die Anzeige als Parameter benötigt.

Die Komponenten-Dateien sind absichtlich leer: keine vorgegebenen Parameter, Methoden oder Tags. Verwende nur HTML und C#; füge kein CSS und keine unnötigen Container hinzu.

## Selbsttest

- Start: `3` und „Da ist noch Luft nach oben.“
- Klick auf `5`: `5` und „Das lief gut.“
- Klick auf `1`, danach `4`: Wert und Rückmeldung ändern sich jedes Mal passend.
- `dotnet build` läuft ohne Fehler.

Zeichne bei Bedarf: `Auswahl → Home → Anzeige`. Der Pfeil zurück von der Anzeige fehlt absichtlich.

## Dieses Projekt zur?cksetzen

F?hre die Befehle im Repository-Ordner `cs_uebungen` aus. Dieser Befehl setzt nur dieses Projekt auf seinen eingecheckten Ausgangsstand zur?ck und verwirft seine ?nderungen:

```powershell
git restore --source=komponenten-ergaenzungen-start --staged --worktree -- "15_Blazor-Komponenten/05_Punktewahl/"
```

Der Tag `komponenten-ergaenzungen-start` enth?lt die neuen ?bungen 04?06. Der ?ltere Tag `uebungen-start` enth?lt diese Projekte noch nicht.

Neue, noch nicht versionierte Dateien bleiben stehen. Pr?fe sie zuerst:

```powershell
git clean -nd -- "15_Blazor-Komponenten/05_Punktewahl/"
```

Nur wenn die angezeigten Dateien ebenfalls weg sollen:

```powershell
git clean -fd -- "15_Blazor-Komponenten/05_Punktewahl/"
```

Das L?schen ist endg?ltig. Andere Projektordner bleiben unber?hrt.
