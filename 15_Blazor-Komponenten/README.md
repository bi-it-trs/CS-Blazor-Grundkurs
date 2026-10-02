# 15 – Blazor-Komponenten

Drei **eigenständige** .NET-10-Blazor-Projekte, in Lernreihenfolge:

| Ordner | Thema | Ausgangslage |
|---|---|---|
| [01_Farbwahl](01_Farbwahl/AUFGABEN.md) | Elternzustand, Geschwister, `EventCallback<string>` | Seite und Kinder vorhanden; Knöpfe unverbunden |
| [02_Temperaturregler](02_Temperaturregler/AUFGABEN.md) | Ereignis über eine Zwischenkomponente, `EventCallback<int>` | Anzeige verbunden; Knöpfe unverbunden |
| [03_LernaufgabenTracker](03_LernaufgabenTracker/AUFGABEN.md) | Formular und Karten aus einer großen Seite auslagern | Funktionsfähiger Tracker in einer `Home.razor` |

In **jedem** Projekt liegen ein Aufgabenblatt und eine eigenständige [Theorie und Anleitung](THEORIE_UND_ANLEITUNG.md) mit Beispielen aus einer anderen Anwendung. Starte immer nur das Projekt, an dem du arbeitest: Terminal in dessen Ordner öffnen und `dotnet run --launch-profile http` ausführen. Die drei Projekte haben eigene Projektdateien, Startprofile und Ports.

Der bereits bearbeitete Tracker im Hauptordner `cs_uebungen/LernaufgabenTracker` bleibt als persönliches Arbeitsprojekt bestehen. Die drei Kapitelprojekte sind frische Übungsvorlagen.
