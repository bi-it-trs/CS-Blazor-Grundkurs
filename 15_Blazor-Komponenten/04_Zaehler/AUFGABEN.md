# 04 – Zähler auslagern

Dieses Projekt ist eigenständig. Starte es im Ordner `04_Zaehler` mit `dotnet run` und öffne die angezeigte Adresse. Am Anfang funktioniert alles bereits – aber alles steht in `Home.razor`.

## Deine Aufgabe

Lagere die Anzeige in die leere Datei `Components/Uebung/ZaehlerAnzeige.razor` aus. Lagere den Button in `Components/Uebung/ZaehlerKnopf.razor` aus und verwende diese Komponente in `Home.razor` **zweimal**: einmal für `-1`, einmal für `+1`.

Entscheide selbst, welche Parameter und Callbacks nötig sind. `Home` soll den Zählerstand weiterhin allein besitzen und verändern. Der Knopf meldet nur seinen Schritt nach oben; die Anzeige zeigt nur den übergebenen Stand.

Die beiden Komponenten-Dateien sind mit Absicht leer. Ändere nur sie und `Home.razor`. Kein CSS, keine zusätzlichen HTML-Container und keine weiteren Projekte nötig.

## Selbsttest

- Start: `0`.
- Zweimal `+1`, dann einmal `-1`: `1`.
- Beide Knöpfe funktionieren weiterhin nach mehreren Klicks.
- `dotnet build` läuft ohne Fehler.

Wenn du hängen bleibst, zeichne nur diese Pfeile auf: `Home → Anzeige` (Stand) und `Knopf → Home` (Schritt).

## Dieses Projekt zur?cksetzen

F?hre die Befehle im Repository-Ordner `cs_uebungen` aus. Dieser Befehl setzt nur dieses Projekt auf seinen eingecheckten Ausgangsstand zur?ck und verwirft seine ?nderungen:

```powershell
git restore --source=komponenten-ergaenzungen-start --staged --worktree -- "15_Blazor-Komponenten/04_Zaehler/"
```

Der Tag `komponenten-ergaenzungen-start` enth?lt die neuen ?bungen 04?06. Der ?ltere Tag `uebungen-start` enth?lt diese Projekte noch nicht.

Neue, noch nicht versionierte Dateien bleiben stehen. Pr?fe sie zuerst:

```powershell
git clean -nd -- "15_Blazor-Komponenten/04_Zaehler/"
```

Nur wenn die angezeigten Dateien ebenfalls weg sollen:

```powershell
git clean -fd -- "15_Blazor-Komponenten/04_Zaehler/"
```

Das L?schen ist endg?ltig. Andere Projektordner bleiben unber?hrt.
