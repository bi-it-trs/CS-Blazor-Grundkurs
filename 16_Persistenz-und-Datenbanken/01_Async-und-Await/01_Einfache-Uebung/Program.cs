Console.WriteLine("Async-Beispiel startet.");

await BeispielAusfuehrenAsync();

Console.WriteLine("Async-Beispiel ist beendet.");

static async Task BeispielAusfuehrenAsync()
{
    Console.WriteLine("Das Lernthema wird angefordert.");

    string thema = await LernthemaLadenAsync();

    Console.WriteLine($"Geladenes Thema: {thema}");
}

static async Task<string> LernthemaLadenAsync()
{
    Console.WriteLine("Laden läuft ...");

    await Task.Delay(800);

    return "Blazor-Komponenten";
}
