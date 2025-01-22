using Frontend.Components;
using API.Services;
using Frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja HttpClient i BooksService
builder.Services.AddHttpClient<IBooksService, BooksService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7299/");
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();