using Blazored.LocalStorage;
using LojaSonhoDeCafe.Components;
using LojaSonhoDeCafe.Components.Account;
using LojaSonhoDeCafe.Data;
using LojaSonhoDeCafe.Repositories.Carrinho;
using LojaSonhoDeCafe.Repositories.Pagamento;
using LojaSonhoDeCafe.Repositories.Produtos;
using LojaSonhoDeCafe.Services.CarrinhoCompraServices;
using LojaSonhoDeCafe.Services.CarrinhoLocalStorage;
using LojaSonhoDeCafe.Services.PagamentoServices;
using LojaSonhoDeCafe.Services.Produto2Services;
using LojaSonhoDeCafe.Services.ProdutoServices;
using LojaSonhoDeCafe.Services.ProdutosLocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SonhoDeCafe.Server.Repositories.Produtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<BancoDeDados>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });



builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<ICarrinhoCompraRepository, CarrinhoCompraRepository>();

builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IProdutoHttpService, ProdutoHttpService>();



builder.Services.AddTransient<ICarrinhoCompraService, CarrinhoCompraService>();


builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPagamentoService, PagamentoService>();

builder.Services.AddTransient<CarrinhoCompraRepository>();
builder.Services.AddTransient<ProdutoRepository>();

builder.Services.AddBlazoredLocalStorage();


builder.Services.AddScoped<ILocalStorageProdutosService,
                           LocalStorageProdutosService>();

builder.Services.AddScoped<ILocalStorageCarrinhoItensService,
                           LocalStorageCarrinhoItensService>();


var baseUrl = "https://localhost:7135";
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(baseUrl)
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(LojaSonhoDeCafe.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
