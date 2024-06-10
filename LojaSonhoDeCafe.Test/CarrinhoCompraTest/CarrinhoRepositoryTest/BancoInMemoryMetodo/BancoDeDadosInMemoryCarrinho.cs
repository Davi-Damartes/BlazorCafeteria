using FakeItEasy;
using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.BancoInMemoryMetodo
{
    public static class BancoDeDadosInMemoryCarrinho
    {

        public static async Task<BancoDeDado> GetBancoDeDadosCarrinho( )
        {
            var options = new DbContextOptionsBuilder<BancoDeDado>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new BancoDeDado(options);
            databaseContext.Database.EnsureCreated();

            var produto = A.Fake<Produto>();
            var carrinho = new Carrinho
            {
                Id = 1,
                UsuarioId = "1",
            }; 
            
            var carrinho2 = new Carrinho
            {
                Id = 2,
                UsuarioId = "2",
            };

            if (!await databaseContext.CarrinhoItens.AnyAsync())
            {
                await databaseContext.AddAsync(
                   new CarrinhoItem
                   {
                       Id = 1,
                       CarrinhoId = 1,
                       ProdutoId = produto.Id,
                       Quantidade = 15,
                       QuantidadeEmEstoque = 17,
                       Carrinho = carrinho,
                       Produto = produto
                   });

                await databaseContext.AddAsync(
                   new CarrinhoItem
                   {
                       Id = 2,
                       CarrinhoId = 1,
                       ProdutoId = produto.Id,
                       Quantidade = 14,
                       QuantidadeEmEstoque = 30,
                       Carrinho = carrinho,
                       Produto = produto
                   });

                await databaseContext.AddAsync(
                   new CarrinhoItem
                   {
                       Id = 3,
                       CarrinhoId = 2,
                       ProdutoId = produto.Id,
                       Quantidade = 23,
                       QuantidadeEmEstoque = 37,
                       Carrinho = carrinho2,
                       Produto = produto
                   });

                await databaseContext.AddAsync(
                   new CarrinhoItem
                   {
                       Id = 4,
                       CarrinhoId = 2,
                       ProdutoId = produto.Id,
                       Quantidade = 23,
                       QuantidadeEmEstoque = 37,
                       Carrinho = carrinho2,
                       Produto = produto
                   });
            
                    await databaseContext.SaveChangesAsync();
            }
           
            return databaseContext;
        }
    }

}
