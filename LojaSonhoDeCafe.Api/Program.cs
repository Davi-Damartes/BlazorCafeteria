using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Api.Repositories;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BancoDeDado>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IProdutoRepository2, ProdutoRepository2>();
//builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();

//builder.Services.AddScoped<ICarrinhoCompraService, CarrinhoCompraService>();


//builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
//builder.Services.AddScoped<IPagamentoService, PagamentoService>();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
