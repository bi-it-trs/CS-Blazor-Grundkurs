public class TaskItem
{
    public string Titel { get; set; }
    public string Beschreibung { get; set; }
    public bool IstErledigt { get; set; }

    public TaskItem(string titel, string beschreibung)
    {
        Titel = titel;
        Beschreibung = beschreibung;
        IstErledigt = false;
    }
}
