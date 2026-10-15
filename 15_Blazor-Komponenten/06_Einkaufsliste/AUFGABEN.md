# 06 – Einkaufsliste in Komponenten zerlegen

Starte das eigenständige Projekt im Ordner `06_Einkaufsliste` mit `dotnet run`. Zu Beginn kannst du Einträge hinzufügen und entfernen. Die gesamte Oberfläche und Logik steht in `Home.razor`.

## Deine Aufgabe

Lagere das Eingabefeld und den Hinzufügen-Button in `Components/Uebung/EintragFormular.razor` aus. Lagere die Liste samt Entfernen-Buttons in `Components/Uebung/EintragListe.razor` aus. Beide Dateien sind leer, damit du Parameter und Callbacks selbst entwirfst.

`Home` soll weiterhin die Sammlung `eintraege` besitzen und Einträge hinzufügen oder entfernen. Der noch nicht gespeicherte Eingabetext darf im Formular liegen. Das Formular meldet einen fertigen Text an `Home`. Die Listenkomponente bekommt die Einträge von `Home` und meldet zurück, welcher Eintrag entfernt werden soll. Die Anzahl bleibt zunächst in `Home`.

Übertrage zuerst nur das Formular und teste das Hinzufügen. Danach übertrage die Liste und teste das Entfernen. Du brauchst kein CSS, keine `div`-Elemente und keine weiteren Dateien.

## Selbsttest

- Ein leerer oder nur aus Leerzeichen bestehender Eintrag wird nicht hinzugefügt.
- Nach „Milch“ und „Brot“ steht die Anzahl auf `2` und beide Einträge sind sichtbar.
- „Milch“ entfernen: Anzahl `1`, nur „Brot“ bleibt.
- Nach dem Hinzufügen ist das Eingabefeld wieder leer.
- `dotnet build` läuft ohne Fehler.

Wenn du den Überblick verlierst, notiere für jede Variable ihren Besitzer. Das Formular besitzt nur den Entwurf, `Home` besitzt die gespeicherte Liste. Die Listenkomponente zeigt sie an und meldet Klicks zurück.

## Dieses Projekt zur?cksetzen

F?hre die Befehle im Repository-Ordner `cs_uebungen` aus. Dieser Befehl setzt nur dieses Projekt auf seinen eingecheckten Ausgangsstand zur?ck und verwirft seine ?nderungen:

```powershell
git restore --source=komponenten-ergaenzungen-start --staged --worktree -- "15_Blazor-Komponenten/06_Einkaufsliste/"
```

Der Tag `komponenten-ergaenzungen-start` enth?lt die neuen ?bungen 04?06. Der ?ltere Tag `uebungen-start` enth?lt diese Projekte noch nicht.

Neue, noch nicht versionierte Dateien bleiben stehen. Pr?fe sie zuerst:

```powershell
git clean -nd -- "15_Blazor-Komponenten/06_Einkaufsliste/"
```

Nur wenn die angezeigten Dateien ebenfalls weg sollen:

```powershell
git clean -fd -- "15_Blazor-Komponenten/06_Einkaufsliste/"
```

Das L?schen ist endg?ltig. Andere Projektordner bleiben unber?hrt.
