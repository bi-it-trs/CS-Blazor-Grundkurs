# Git für die Übungen

Alle Übungsordner gehören zu **einem** Repository im Ordner `cs_uebungen`. Die Datei `.gitignore` schließt Build-Ausgaben, Editor-Dateien und lokale Zugangsdaten aus.

## Einen Übungsordner auf den ursprünglichen Stand setzen

Öffne ein Terminal im Ordner `cs_uebungen`. Beispiel für die Farbwahl:

```powershell
git status --short -- "15_Blazor-Komponenten/01_Farbwahl/"
git restore --source=uebungen-start --staged --worktree -- "15_Blazor-Komponenten/01_Farbwahl/"
```

Das stellt **versionierte** Dateien in genau diesem Ordner auf den Tag `uebungen-start` zurück. Änderungen in anderen Ordnern bleiben unberührt. Der Tag bezeichnet den Ausgangsstand aller Übungen.

Neu angelegte, bisher **nicht versionierte** Dateien bleiben nach `git restore` stehen. Zeige sie zuerst an:

```powershell
git clean -nd -- "15_Blazor-Komponenten/01_Farbwahl/"
```

Nur wenn die angezeigten Dateien wirklich weg sollen, lösche sie mit:

```powershell
git clean -fd -- "15_Blazor-Komponenten/01_Farbwahl/"
```

`git clean -fd` löscht diese nicht versionierten Dateien endgültig. Der Pfad am Ende begrenzt auch diesen Befehl auf **einen** Übungsordner. Ersetze ihn für andere Übungen, zum Beispiel durch `15_Blazor-Komponenten/02_Temperaturregler/`.

## Eine eigene Zwischenversion speichern

```powershell
git add -- "15_Blazor-Komponenten/01_Farbwahl/"
git commit -m "Farbwahl: Zwischenstand"
```

Ein Commit darf Änderungen aus nur einem Ordner enthalten. Zum Wiederherstellen aus einem bestimmten Commit kannst du statt `uebungen-start` dessen Commit-ID bei `--source=` einsetzen. `git log --oneline` zeigt die IDs.

## Auf GitHub hochladen

Die lokale GitHub-CLI muss angemeldet sein:

```powershell
gh auth login -h github.com
gh auth status
```

Wenn die Anmeldung funktioniert und noch kein gleichnamiges Remote-Repository existiert, kannst du aus dem Ordner `cs_uebungen` ein **öffentliches** Repository erstellen und den lokalen Stand samt Start-Tag hochladen:

```powershell
gh repo create cs_uebungen --public --source=. --remote=origin --push
git push origin uebungen-start
```

Prüfe vor dem Push mit `git status` und `git ls-files`, welche Dateien versioniert sind. Lokale Passwörter gehören nicht in Git; verwende für Datenbank-Zugangsdaten zum Beispiel .NET User Secrets oder eine ignorierte `.env`-Datei.
