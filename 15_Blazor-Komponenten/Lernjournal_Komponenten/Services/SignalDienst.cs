namespace BlazorDatenlabor.Services;

public class SignalDienst
{
    public event Func<string, Task>? SignalEmpfangen;

    public async Task SendenAsync()
    {
        // Nur dieses Lernbeispiel verlässt absichtlich den Blazor-Kontext.
        // Normale asynchrone Datenabfragen benötigen kein Task.Run.
        await Task.Run(async () =>
        {
            await Task.Delay(1500);
            var empfaenger = SignalEmpfangen;
            if (empfaenger is null)
            {
                return;
            }

            // Bei einem Multicast-Delegate käme nur der letzte Task zurück.
            // Deshalb jeden angemeldeten Empfänger einzeln abwarten.
            foreach (Func<string, Task> empfangen in empfaenger.GetInvocationList())
            {
                await empfangen("Signal aus dem Hintergrund");
            }
        });
    }
}
