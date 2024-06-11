using FakeItEasy;
using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoRepositorioTest.BancoInMemoryMetodo
{
    public static class BancoDeDadosInMemoryPag
    {

        public static async Task<BancoDeDado> GetBancoDeDadoPag()
        {
            var options = new DbContextOptionsBuilder<BancoDeDado>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new BancoDeDado(options);
            databaseContext.Database.EnsureCreated();


            var listaPagamentoDiario = A.Fake<List<PagamentoProduto>>();

            var pagamentoDiario = new PagamentoDiario
            {
                Usuario = "UsuarioTeste2",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = Enum.ETipoPagamento.paypal,
                HoraDoPagamento = DateTime.Now,
                PagamentoProdutos = listaPagamentoDiario
            };
            
            
            var pagamentoProduto = new PagamentoProduto
            {
                ProdutoId = Guid.NewGuid(),
                ProdutoNome = "Café",
                QuantidadeComprada = 5,
                PrecoTotal = 150.75m,
                PagamentoDiarioId = Guid.NewGuid(),
                PagamentoDiario = pagamentoDiario,

            };

            if (!await databaseContext.PagamentosDiarios.AnyAsync())
            {
                databaseContext.Add(pagamentoDiario);
                await databaseContext.SaveChangesAsync();
            }

             if (!await databaseContext.PagamentoProdutos.AnyAsync()) 
            {
                databaseContext.Add(pagamentoProduto);
                await databaseContext.SaveChangesAsync();
            }


            return databaseContext;
        }
    }

}
