# Aufgaben – Razor und Blazor

## Ausgangslage

Mit dieser Lektion beginnt die zusammenhängende Blazor-Reihe. Sie übernimmt deshalb keinen fertigen Lerntracker aus den Konsolenprojekten. Das Blazor-Grundprojekt und eine einfache `Home.razor` sind bereits vorhanden.

Prüfe zuerst den unveränderten Startstand:

```powershell
dotnet build
dotnet run
```

Öffne anschließend die im Terminal angezeigte lokale Adresse. Beende die laufende App bei Bedarf mit `Ctrl+C`.

Vereinbarte Dateien:

- `Components/Pages/Home.razor` ist die Startseite.
- `Models/TaskItem.cs` erstellst du in dieser Lektion.
- `Models/AufgabenStatus.cs` erstellst du in dieser Lektion.
- `Components/_Imports.razor` kann den gemeinsamen Modell-Namespace importieren.

Verwende exakt die Namen `TaskItem`, `AufgabenStatus` und `Home.razor`. Benenne diese Dateien und Typen während der Blazor-Übungsreihe nicht um. Lektion 14 übernimmt sie als festen Ausgangspunkt.

## Aufgabe: Statische Lerntracker-Seite

1. Starte das Blazor-Projekt.
2. Erstelle im Ordner `Models` die Klasse `TaskItem` und den Enum `AufgabenStatus`.
3. Verwende einen passenden Namespace.
4. Importiere die Modelle in `Home.razor`.
5. Lege im `@code`-Block mindestens drei Aufgaben an.
6. Gib die Gesamtzahl aus.
7. Zeige alle Aufgaben mit `@foreach` an.
8. Zeige Titel, Beschreibung und Status.
9. Verwende bei fehlender Beschreibung einen Ersatztext.
10. Nutze sinnvolle HTML-Elemente wie `section`, `h2`, `p`, `ul` und `li`.

Noch keine Buttons oder Eingabefelder verwenden. Diese Übung konzentriert sich auf die Darstellung von C#-Daten als HTML.

## Kontrollfragen

1. Zu was wird eine `.razor`-Datei beim Build?
2. Woher kommt die lokale Variable einer Razor-`foreach`-Schleife?
3. Warum kann das Markup auf private Felder im `@code`-Block zugreifen?

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "13_Razor-und-Blazor/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "13_Razor-und-Blazor/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "13_Razor-und-Blazor/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet.
