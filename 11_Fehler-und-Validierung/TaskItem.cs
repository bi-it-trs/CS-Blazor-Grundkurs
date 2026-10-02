public class TaskItem
{
    public string Titel { get; set; }
    public string? Beschreibung { get; set; }
    public AufgabenStatus Status { get; set; }

    public TaskItem(string titel, string? beschreibung)
    {
        Titel = titel;
        Beschreibung = beschreibung;
        Status = AufgabenStatus.Offen;
    }
}
