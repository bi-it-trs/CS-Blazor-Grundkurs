using Dapper;
using MySqlConnector;
using TodoCrudUebung.Models;

namespace TodoCrudUebung.Data;

public class TaskItemRepository
{
    private readonly string connectionString;

    public TaskItemRepository(IConfiguration configuration)
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

    public async Task AlsErledigtMarkierenAsync(int id)
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
}
