using LojaSonhoDeCafe.Client;
using LojaSonhoDeCafe.Client.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();


var baseUrl = "https://localhost:7135";
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(baseUrl)
});

builder.Services.AddScoped<IProduto2Service, Produto2Service>();

await builder.Build().RunAsync();
