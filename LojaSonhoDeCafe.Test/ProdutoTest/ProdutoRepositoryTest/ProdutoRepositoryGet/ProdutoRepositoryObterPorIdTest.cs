using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoTest.ProdutoRepositoriesTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoRepositoriesTest.ProdutoRepositoryGet
{
    public class ProdutoRepositoryObterPorIdTest
    {

        [Fact]
        public async Task ProdutoRepository_ObterProdutoPorId_ReturnarUmProduto()
        {
            //Arange
            var produtoId = Guid.NewGuid();

            var dbContext = await BancoDeDadosInMemory.GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = repository.ObterProdutoPorId(produtoId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Produto>>();

        }
    }
}