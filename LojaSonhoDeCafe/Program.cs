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
using LojaSonhoDeCafe.Services.ProdutoServices;
using LojaSonhoDeCafe.Services.ProdutosLocalStorage;
using LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService;
using LojaSonhoDeCafe.ServicesHttp.PagamentoHttpService;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
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

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();

builder.Services.AddScoped<CarrinhoCompraRepository>();
builder.Services.AddScoped<ProdutoRepository>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();


builder.Services.AddScoped<IProdutoHttpService, ProdutoHttpService>();
builder.Services.AddScoped<ICarrinhoCompraHttpService, CarrinhoCompraHttpService>();

builder.Services.AddScoped<IPagamentoHttpService, PagamentoHttpService>();


builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();



builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddBlazoredLocalStorage();


builder.Services.AddTransient<ILocalStorageProdutosService,
                           LocalStorageProdutosService>();

builder.Services.AddTransient<ILocalStorageCarrinhoItensService,
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
