namespace LerntrackerDapperUebung.Models;

public class TaskItem
{
    public string Titel { get; set; }
    public string? Beschreibung { get; set; }
    public AufgabenStatus Status { get; set; }

    public TaskItem(
        string titel,
        string? beschreibung,
        AufgabenStatus status)
    {
        Titel = titel;
        Beschreibung = beschreibung;
        Status = status;
    }
}
