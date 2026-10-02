# Anleitung – MariaDB mit Docker Desktop und DBeaver

## Zweck dieser Anleitung

Diese Anleitung richtet nur die lokale Entwicklungsumgebung ein. Du programmierst hier noch keine Blazor-Funktion.

Am Ende laufen:

- ein MariaDB-Server in einem Docker-Container,
- ein dauerhaftes Docker-Volume für die Daten,
- eine Verbindung von DBeaver zum Server.

Die eigentliche Datenbank `lerntracker`, der eingeschränkte App-Benutzer und die Tabelle werden erst in Übung 04 erstellt.

## Begriffe

| Begriff | Bedeutung |
|---|---|
| Image | unveränderliche Vorlage für einen Container |
| Container | laufende Instanz eines Images |
| Volume | dauerhafter Speicher außerhalb des Containers |
| Port | Verbindung zwischen deinem Rechner und dem Container |
| DBeaver | grafische Oberfläche zum Verwalten der Datenbank |
| MariaDB | relationales Datenbanksystem |

Das Volume ist wichtig: Ein Container kann ersetzt werden, ohne dass die Datenbankdateien verloren gehen.

## Voraussetzungen prüfen

Docker Desktop muss gestartet sein. Prüfe im Terminal:

```powershell
docker --version
docker compose version
```

Beide Befehle müssen eine Versionsnummer ausgeben.

Installiere außerdem DBeaver Community, falls es noch nicht vorhanden ist.

## Arbeitsordner anlegen

Lege für die spätere To-do-App einen Infrastrukturordner an. Darin werden zwei lokale Dateien benötigt:

```text
infrastructure/
├── compose.yaml
└── .env
```

Die Datei `.env` enthält ein Passwort und darf später nicht in Git eingecheckt werden. Ergänze sie in der `.gitignore`.

## Inhalt von `.env`

Verwende für die lokale Entwicklung ein eigenes starkes Passwort:

```dotenv
MARIADB_ROOT_PASSWORD=hier-ein-lokales-passwort-einsetzen
MARIADB_HOST_PORT=3306
```

Übernimm das Beispielpasswort nicht wörtlich. `3306` ist nur ein Beispiel für den Host-Port. Prüfe, ob er auf deinem Rechner frei ist, und ändere `MARIADB_HOST_PORT` bei Bedarf. Notiere den gewählten Wert; du brauchst ihn später für DBeaver und die Blazor-Projekte.

## Inhalt von `compose.yaml`

```yaml
services:
  mariadb:
    image: mariadb:11.4
    container_name: lerntracker-mariadb
    restart: unless-stopped
    environment:
      MARIADB_ROOT_PASSWORD: ${MARIADB_ROOT_PASSWORD}
    ports:
      - "127.0.0.1:${MARIADB_HOST_PORT}:3306"
    volumes:
      - lerntracker_mariadb_data:/var/lib/mysql
    healthcheck:
      test:
        - CMD
        - healthcheck.sh
        - --connect
        - --innodb_initialized
      interval: 10s
      timeout: 5s
      retries: 10

volumes:
  lerntracker_mariadb_data:
```

Der explizite Tag `11.4` hält die Hauptversion reproduzierbar. Die Variablen `MARIADB_*` und `healthcheck.sh` gehören zum offiziellen MariaDB-Image.

Die Portfreigabe gilt nur auf deinem Rechner. Links steht der selbst gewählte Host-Port aus `.env`, rechts der interne MariaDB-Port `3306`. `docker compose ps` zeigt nach dem Start die tatsächliche Zuordnung.

## Konfiguration prüfen

Öffne ein Terminal im Infrastrukturordner:

```powershell
docker compose config
```

Dieser Befehl prüft die YAML-Struktur und setzt die Werte aus `.env` ein. Teile die Ausgabe nicht öffentlich, weil darin das aufgelöste Passwort erscheinen kann.

## Container starten

```powershell
docker compose up -d
```

Status prüfen:

```powershell
docker compose ps
```

Der Container wechselt nach der Initialisierung zu `healthy`. Beim ersten Start kann das etwas dauern.

Logs anzeigen:

```powershell
docker compose logs -f mariadb
```

Mit `Ctrl+C` beendest du nur die Loganzeige, nicht den Container.

## MariaDB im Container testen

```powershell
docker exec -it lerntracker-mariadb mariadb -u root -p
```

Gib das Root-Passwort aus `.env` ein. Das Passwort wird während der Eingabe nicht angezeigt.

Im MariaDB-Terminal:

```sql
SELECT VERSION();
SHOW DATABASES;
EXIT;
```

## DBeaver verbinden

1. Öffne DBeaver.
2. Wähle **Neue Datenbankverbindung**.
3. Wähle **MariaDB**.
4. Trage folgende Werte ein:

| Feld | Wert |
|---|---|
| Host | `localhost` |
| Port | gewählter Host-Port aus `.env` bzw. `docker compose ps` |
| Database | zunächst leer lassen |
| Benutzer | `root` |
| Passwort | Wert aus `.env` |

5. Klicke auf **Test Connection**.
6. Erlaube DBeaver bei Bedarf, den MariaDB-Treiber herunterzuladen.
7. Speichere die Verbindung.

Der Root-Zugang wird nur zum Einrichten verwendet. Die Blazor-App bekommt in Übung 04 einen eigenen eingeschränkten Benutzer.

## Test in DBeaver

Öffne einen SQL-Editor für die Verbindung:

```sql
SELECT VERSION();
SHOW DATABASES;
```

Wenn beide Anweisungen Ergebnisse liefern, ist die Infrastruktur bereit.

## Container später bedienen

Stoppen, Daten behalten:

```powershell
docker compose stop
```

Wieder starten:

```powershell
docker compose start
```

Container entfernen, Volume behalten:

```powershell
docker compose down
```

Container und Daten endgültig entfernen:

```powershell
docker compose down -v
```

Achtung: `down -v` löscht das Datenvolume. Die Datenbank kann danach nicht aus diesem Volume wiederhergestellt werden.

## Häufige Probleme

### Port 3306 ist bereits belegt

Möglicherweise läuft lokal bereits MySQL oder MariaDB. Prüfe Docker Desktop und installierte Windows-Dienste.

Wähle in `.env` einen freien Wert für `MARIADB_HOST_PORT` und starte mit `docker compose up -d` erneut. Übernimm genau diesen Host-Port in DBeaver und in den Connection String. Der interne Port `3306` bleibt unverändert.

### Container bleibt ungesund

Prüfe:

```powershell
docker compose logs mariadb
```

Häufige Ursachen sind ein fehlendes Root-Passwort oder ein altes Volume mit einer früheren Konfiguration.

### Geändertes Passwort funktioniert nicht

Initialisierungsvariablen wirken nur auf ein leeres Datenverzeichnis. Existiert das Volume bereits, bleibt das darin gespeicherte Passwort bestehen.

Wenn die Daten sicher gelöscht werden dürfen:

```powershell
docker compose down -v
docker compose up -d
```

### DBeaver erreicht den Server nicht

Prüfe nacheinander:

1. Docker Desktop läuft.
2. `docker compose ps` zeigt den Container.
3. Der Container ist `healthy`.
4. Host und Port stimmen.
5. Eine lokale Firewall blockiert den Port nicht.

## Sicherheitsregeln für die Übung

- Kein Passwort in C#-Quellcode schreiben.
- `.env` nicht in Git einchecken.
- Die App nicht mit dem Root-Benutzer verbinden.
- SQL-Eingaben später immer parametrisieren.
- Diese Konfiguration ist für lokale Entwicklung, nicht für einen öffentlichen Produktionsserver.

## Offizielle Nachschlagequellen

- [MariaDB Docker-Container](https://mariadb.com/docs/server/server-management/automated-mariadb-deployment-and-administration/docker-and-mariadb)
- [Umgebungsvariablen des offiziellen MariaDB-Images](https://mariadb.com/docs/server/server-management/automated-mariadb-deployment-and-administration/docker-and-mariadb/mariadb-server-docker-official-image-environment-variables)
- [MariaDB-Healthcheck](https://mariadb.com/docs/server/server-management/automated-mariadb-deployment-and-administration/docker-and-mariadb/using-healthcheck-sh)
- [Offizielle MariaDB-Image-Tags](https://hub.docker.com/_/mariadb/tags?name=11.4)
- [DBeaver-Verbindung zu MariaDB](https://dbeaver.com/docs/dbeaver/Database-driver-MariaDB/)

## Nur diese Übung zurücksetzen

Führe die Befehle im Terminal im Ordner `cs_uebungen` aus. Der folgende Befehl stellt nur die versionierten Dateien dieser Übung auf den Ausgangsstand zurück:

```powershell
git restore --source=uebungen-start --staged --worktree -- "16_Persistenz-und-Datenbanken/02_MariaDB-Docker-und-DBeaver/"
```

Falls du in diesem Übungsordner neue, noch nicht versionierte Dateien erstellt hast, zeige sie zuerst an:

```powershell
git clean -nd -- "16_Persistenz-und-Datenbanken/02_MariaDB-Docker-und-DBeaver/"
```

Nur wenn diese Dateien ebenfalls weg sollen, führe danach `git clean -fd -- "16_Persistenz-und-Datenbanken/02_MariaDB-Docker-und-DBeaver/"` aus. Das Löschen ist endgültig. Andere Übungsordner bleiben bei allen drei Befehlen unangetastet. Voraussetzung ist, dass dieser Starterordner im Git-Tag `uebungen-start` enthalten ist.
