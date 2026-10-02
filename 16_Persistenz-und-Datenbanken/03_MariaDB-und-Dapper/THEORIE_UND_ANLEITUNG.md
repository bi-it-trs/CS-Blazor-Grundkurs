# 16.03 – MariaDB und Dapper mit Blazor verbinden

## Lernziel

Du ersetzt die Aufgabenliste im flüchtigen Arbeitsspeicher durch eine MariaDB-Datenbank.

Am Ende kann die Blazor-App:

- vorhandene Aufgaben aus MariaDB laden,
- neue Aufgaben in MariaDB anlegen,
- eine Aufgabe dauerhaft als erledigt markieren.

## Voraussetzungen

Arbeite zuerst die Anleitung in `01_MariaDB-Docker-und-DBeaver` durch.

Vor Beginn müssen gelten:

- Docker Desktop läuft.
- Der MariaDB-Container ist `healthy`.
- DBeaver kann sich als lokaler Administrator verbinden.
- Das Blazor-Startprojekt baut und läuft.

Die LocalStorage-Übung ist keine Voraussetzung. Dieses Projekt beginnt unabhängig davon mit dem komponentisierten In-Memory-Tracker.

## Architektur

```text
Razor-Komponenten
    ↓
TaskItemRepository
    ↓
Dapper
    ↓
MySqlConnector
    ↓
MariaDB im Docker-Container
```

Die Aufgaben der Schichten:

| Schicht | Verantwortung |
|---|---|
| Komponenten | Oberfläche und Benutzerereignisse |
| Repository | SQL-Anweisungen und Datenzugriff |
| Dapper | Parameter übergeben und Zeilen auf Objekte abbilden |
| MySqlConnector | technische Verbindung zu MariaDB |
| MariaDB | dauerhafte Speicherung |

Dapper ersetzt nicht den Datenbanktreiber. Deshalb werden Dapper und MySqlConnector benötigt.

## Datenbank, Benutzer und Tabelle erstellen

Öffne in DBeaver einen SQL-Editor mit der Root-Verbindung.

Verwende für das Übungspasswort einen eigenen lokalen Wert:

```sql
CREATE DATABASE IF NOT EXISTS lerntracker
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

CREATE USER IF NOT EXISTS 'lernapp'@'%'
    IDENTIFIED BY 'lokales-app-passwort';

ALTER USER 'lernapp'@'%'
    IDENTIFIED BY 'lokales-app-passwort';

GRANT SELECT, INSERT, UPDATE, DELETE
    ON lerntracker.*
    TO 'lernapp'@'%';

FLUSH PRIVILEGES;

USE lerntracker;

CREATE TABLE IF NOT EXISTS Aufgaben
(
    Id INT NOT NULL AUTO_INCREMENT,
    Titel VARCHAR(200) NOT NULL,
    Beschreibung TEXT NULL,
    Status TINYINT UNSIGNED NOT NULL DEFAULT 0,

    CONSTRAINT PK_Aufgaben PRIMARY KEY (Id),
    CONSTRAINT CK_Aufgaben_Status
        CHECK (Status IN (0, 1, 2))
);
```

Die Statuswerte entsprechen dem C#-Enum:

| Datenbank | C# |
|---:|---|
| `0` | `Offen` |
| `1` | `InArbeit` |
| `2` | `Erledigt` |

## Schema prüfen

```sql
USE lerntracker;

DESCRIBE Aufgaben;

SELECT
    Id,
    Titel,
    Beschreibung,
    Status
FROM Aufgaben;
```

Erstelle anschließend in DBeaver eine zweite Verbindung mit dem App-Benutzer:

| Feld | Wert |
|---|---|
| Host | `localhost` |
| Port | `3306` |
| Database | `lerntracker` |
| Benutzer | `lernapp` |
| Passwort | dein lokales App-Passwort |

Die Blazor-App verwendet später ausschließlich diesen Benutzer, nicht `root`.

## SQL-Datei im Projekt

Speichere das SQL-Schema zusätzlich als:

```text
Database/01_schema.sql
```

Dadurch kann eine andere Person die benötigte Datenbankstruktur nachvollziehen und erneut anlegen.

Speichere keine echten Passwörter in dieser Datei. Verwende dort einen deutlich erkennbaren Platzhalter oder dokumentiere die Benutzererstellung getrennt.

## Benötigte NuGet-Pakete

Im Projektordner:

```powershell
dotnet add package Dapper
dotnet add package MySqlConnector
```

Dapper erweitert Datenbankverbindungen unter anderem um:

- `QueryAsync<T>` für mehrere Ergebniszeilen,
- `ExecuteAsync` für INSERT und UPDATE,
- `ExecuteScalarAsync<T>` für einen einzelnen Rückgabewert.

MySqlConnector stellt `MySqlConnection` für MariaDB und MySQL bereit.

## Connection String sicher speichern

Ein Connection String enthält Server, Datenbank, Benutzer und Passwort.

Er darf nicht direkt in C# und nicht mit echtem Passwort in eine eingecheckte `appsettings.json` geschrieben werden.

Aktiviere .NET User Secrets:

```powershell
dotnet user-secrets init
```

Setze anschließend den Connection String. Ersetze das Passwort:

```powershell
dotnet user-secrets set "ConnectionStrings:MariaDb" "Server=localhost;Port=3306;Database=lerntracker;User ID=lernapp;Password=DEIN_PASSWORT"
```

Prüfen, welche Schlüssel vorhanden sind:

```powershell
dotnet user-secrets list
```

User Secrets sind nur für lokale Entwicklung gedacht. Sie werden außerhalb des Projektordners im Benutzerprofil gespeichert.

## Modell für die Datenbank ergänzen

Die Datenbank identifiziert jede Zeile über `Id`. Ergänze in `TaskItem`:

```csharp
public int Id { get; set; }
```

Dapper muss geladene Zeilen in Objekte schreiben können. Ergänze deshalb zusätzlich einen parameterlosen Konstruktor:

```csharp
public TaskItem()
{
    Titel = string.Empty;
}
```

Der vorhandene Konstruktor für neue Formulareinträge bleibt bestehen:

```csharp
public TaskItem(
    string titel,
    string? beschreibung,
    AufgabenStatus status)
{
    Titel = titel;
    Beschreibung = beschreibung;
    Status = status;
}
```

Ein neues Objekt besitzt zunächst `Id == 0`. Nach dem INSERT erhält es die von MariaDB erzeugte ID.

## Repository statt SQL in der Komponente

Lege `Data/TaskItemRepository.cs` an.

Die Komponente soll nicht selbst Connection Strings lesen oder SQL enthalten. Das Repository bündelt den gesamten Datenzugriff.

Grundstruktur:

```csharp
using Dapper;
using LerntrackerDapperUebung.Models;
using MySqlConnector;

namespace LerntrackerDapperUebung.Data;

public class TaskItemRepository
{
    private readonly string connectionString;

    public TaskItemRepository(
        IConfiguration configuration)
    {
        connectionString =
            configuration.GetConnectionString("MariaDb")
            ?? throw new InvalidOperationException(
                "Connection String 'MariaDb' fehlt."
            );
    }

    private MySqlConnection ErstelleVerbindung()
    {
        return new MySqlConnection(connectionString);
    }
}
```

Das Repository speichert nicht eine dauerhaft geöffnete Verbindung. Jede Methode erzeugt ihre eigene Verbindung und gibt sie anschließend wieder frei. Connection Pooling übernimmt die effiziente Wiederverwendung im Hintergrund.

## Aufgaben laden

```csharp
public async Task<List<TaskItem>> LadeAlleAsync()
{
    const string sql = @"
        SELECT
            Id,
            Titel,
            Beschreibung,
            Status
        FROM Aufgaben
        ORDER BY Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    IEnumerable<TaskItem> ergebnis =
        await connection.QueryAsync<TaskItem>(sql);

    return ergebnis.ToList();
}
```

Dapper ordnet gleichnamige Spalten den Properties von `TaskItem` zu.

Die Abfrage verändert nichts. Sie liest alle Zeilen und sortiert sie nach der ID.

## Aufgabe anlegen

```csharp
public async Task ErstellenAsync(TaskItem aufgabe)
{
    const string insertSql = @"
        INSERT INTO Aufgaben
            (Titel, Beschreibung, Status)
        VALUES
            (@Titel, @Beschreibung, @Status);";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    await connection.OpenAsync();

    await connection.ExecuteAsync(
        insertSql,
        new
        {
            aufgabe.Titel,
            aufgabe.Beschreibung,
            Status = (int)aufgabe.Status
        }
    );

    long neueId =
        await connection.ExecuteScalarAsync<long>(
            "SELECT LAST_INSERT_ID();"
        );

    aufgabe.Id = checked((int)neueId);
}
```

Die Werte werden nicht in den SQL-Text hineinkopiert. `@Titel`, `@Beschreibung` und `@Status` sind Parameter.

Das schützt vor SQL-Injection und überlässt dem Treiber die korrekte Wertübertragung.

`LAST_INSERT_ID()` wird auf derselben geöffneten Verbindung ausgeführt. So erhält das Objekt die ID der gerade eingefügten Zeile.

## Aufgabe als erledigt markieren

```csharp
public async Task AlsErledigtMarkierenAsync(
    int id)
{
    const string sql = @"
        UPDATE Aufgaben
        SET Status = @Status
        WHERE Id = @Id;";

    await using MySqlConnection connection =
        ErstelleVerbindung();

    int betroffeneZeilen =
        await connection.ExecuteAsync(
            sql,
            new
            {
                Id = id,
                Status = (int)AufgabenStatus.Erledigt
            }
        );

    if (betroffeneZeilen != 1)
    {
        throw new InvalidOperationException(
            "Die Aufgabe wurde nicht gefunden."
        );
    }
}
```

Die ID entscheidet, welche Datenbankzeile geändert wird. Titel sind dafür ungeeignet, weil mehrere Aufgaben denselben Titel besitzen können.

## Repository registrieren

Ergänze in `Program.cs` den Namespace:

```csharp
using LerntrackerDapperUebung.Data;
```

Registriere das Repository vor `builder.Build()`:

```csharp
builder.Services.AddScoped<TaskItemRepository>();
```

`Scoped` passt bei Interactive Server zum Verbindungskontext des Benutzers. Das Repository selbst hält trotzdem keine offene Datenbankverbindung.

## Repository in Home verwenden

Oben in `Home.razor`:

```razor
@inject TaskItemRepository Repository
```

Dafür muss der Data-Namespace verfügbar sein, entweder direkt:

```razor
@using LerntrackerDapperUebung.Data
```

oder gemeinsam in `Components/_Imports.razor`.

Die Liste startet nun leer:

```csharp
private List<TaskItem> aufgaben =
    new List<TaskItem>();
```

Beim Initialisieren laden:

```csharp
protected override async Task OnInitializedAsync()
{
    aufgaben = await Repository.LadeAlleAsync();
}
```

Die Datenbank liegt auf dem Server. Anders als LocalStorage benötigt dieser Zugriff keine Browser-JavaScript-Verbindung und kann während der Komponenteninitialisierung stattfinden.

## Neue Aufgabe dauerhaft speichern

```csharp
private async Task AufgabeHinzufuegen(
    TaskItem neueAufgabe)
{
    await Repository.ErstellenAsync(neueAufgabe);
    aufgaben.Add(neueAufgabe);
}
```

Zuerst wird gespeichert. Nur bei erfolgreichem INSERT wird das Objekt zur sichtbaren Liste hinzugefügt.

## Status dauerhaft ändern

```csharp
private async Task AufgabeErledigen(
    TaskItem aufgabe)
{
    await Repository.AlsErledigtMarkierenAsync(
        aufgabe.Id
    );

    aufgabe.Status = AufgabenStatus.Erledigt;
}
```

Auch hier wird zuerst die Datenbank aktualisiert. Scheitert das UPDATE, zeigt die Oberfläche nicht fälschlich einen Zustand, der nie gespeichert wurde.

## Was Dapper nicht übernimmt

Dapper:

- erstellt die Datenbank nicht automatisch,
- erstellt keine Tabellenmigrationen,
- verfolgt keine Objektänderungen,
- generiert kein UPDATE aus einer Propertyänderung,
- hält keine Objekte automatisch mit der Datenbank synchron.

Du schreibst SQL bewusst selbst und rufst für jede gewünschte Änderung eine Repository-Methode auf.

## Dapper und Sicherheit

Immer Parameter verwenden:

```csharp
// Richtig
"WHERE Id = @Id", new { Id = id }
```

Keine Eingaben durch String-Verkettung in SQL einsetzen:

```csharp
// Falsch
"WHERE Titel = '" + titel + "'"
```

SQL-Parameter schützen Werte. Namen von Tabellen oder Spalten können nicht auf dieselbe Weise als Parameter übergeben werden und sollten nicht aus Benutzereingaben stammen.

## Funktionstest

1. App starten.
2. Aufgabe anlegen.
3. Zeile in DBeaver kontrollieren.
4. Browser neu laden.
5. App stoppen und neu starten.
6. Aufgabe muss weiterhin vorhanden sein.
7. Aufgabe erledigen.
8. Status in DBeaver prüfen.
9. Erneut neu laden.
10. Status muss erhalten bleiben.

## Häufige Fehler

- Der Container läuft nicht.
- Host-Port im Connection String stimmt nicht mit Compose überein.
- Die App verwendet versehentlich `root`.
- Der Connection String heißt anders als `MariaDb`.
- User Secrets wurden in einem anderen Projektordner gesetzt.
- Dapper oder MySqlConnector wurde nicht installiert.
- Das Repository wurde nicht im Dependency-Injection-Container registriert.
- `TaskItem.Id` fehlt.
- Der parameterlose Konstruktor fehlt und Dapper kann das Objekt nicht erzeugen.
- SQL-Spalten und Propertynamen passen nicht zusammen.
- Die UI wird geändert, ohne das Repository aufzurufen.
- INSERT und `LAST_INSERT_ID()` laufen auf unterschiedlichen Verbindungen.
- SQL wird durch String-Verkettung zusammengesetzt.

## Offizielle Nachschlagequellen

- [Dapper-Projekt und Grundlagen](https://github.com/DapperLib/Dapper)
- [MySqlConnector](https://mysqlconnector.net/)
- [Connection-String-Optionen](https://mysqlconnector.net/connection-options/)
- [MySqlConnector mit ASP.NET Core](https://mysqlconnector.net/tutorials/net-core-mvc/)
- [Blazor Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-10.0)
