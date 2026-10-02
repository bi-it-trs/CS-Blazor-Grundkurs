# Aufgaben – Blazor-Komponenten

Bearbeite die drei eigenständigen Projekte der Reihe nach:

1. [Farbwahl: Kommunikation zwischen Geschwistern](01_Farbwahl/AUFGABEN.md)
2. [Temperaturregler: Callback über zwei Ebenen](02_Temperaturregler/AUFGABEN.md)
3. [LernaufgabenTracker: Formular und Karten auslagern](03_LernaufgabenTracker/AUFGABEN.md)

Jedes Aufgabenblatt nennt seine Starterdateien, Arbeitsschritte und Funktionstests. Beginne jeweils mit dem lauffähigen Starterprojekt; übertrage keine fertigen Komponenten aus den anderen Projekten.

## Einzelne Übung zurücksetzen

Führe im Terminal im Ordner `cs_uebungen` **nur die Zeile für das gewünschte Projekt** aus:

```powershell
git restore --source=uebungen-start --staged --worktree -- "15_Blazor-Komponenten/01_Farbwahl/"
git restore --source=uebungen-start --staged --worktree -- "15_Blazor-Komponenten/02_Temperaturregler/"
git restore --source=uebungen-start --staged --worktree -- "15_Blazor-Komponenten/03_LernaufgabenTracker/"
```

Diese Befehle betreffen nur versionierte Dateien des jeweils angegebenen Projekts. Neu angelegte, noch nicht versionierte Dateien kannst du mit `git clean -nd -- "GEWÄHLTER_PFAD/"` zuerst anzeigen und danach bei Bedarf mit `git clean -fd -- "GEWÄHLTER_PFAD/"` endgültig löschen. Die konkreten Befehle stehen auch in den Aufgabenblättern der drei Projekte.
