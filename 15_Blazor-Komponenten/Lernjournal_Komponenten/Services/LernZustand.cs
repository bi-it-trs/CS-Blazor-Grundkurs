namespace BlazorDatenlabor.Services;

public class LernZustand
{
    public string Name { get; private set; } = "Sam";

    public event Action? Geaendert;

    public void NameSetzen(string name)
    {
        Name = name;
        Geaendert?.Invoke();
    }
}
