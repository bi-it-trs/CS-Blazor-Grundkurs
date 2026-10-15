using BlazorDatenlabor.Components;
using BlazorDatenlabor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Pro Browser-Verbindung erhalten die Komponenten denselben Zustand.
builder.Services.AddScoped<LernZustand>();
builder.Services.AddScoped<SignalDienst>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
