using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SearchNarutoAPI;
using SearchNarutoAPI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri("https://dattebayo-api.onrender.com/"),
    Timeout = TimeSpan.FromSeconds(60)
});

builder.Services.AddScoped<NarutoApiService>();

await builder.Build().RunAsync();
