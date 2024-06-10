using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoTest.ProdutoRepositoriesTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoRepositoriesTest.ProdutoRepositoryGet
{
    public class ProdutoRepositoryObterTodosProdutosTest
    {

        [Fact]
        public async Task ProdutoRepository_ObterTodosOsProdutos_ReturnaIEnumerableProduto()
        {
            //Arange
            var dbContext = await BancoDeDadosInMemory.GetBancoDeDado();

            var produtoRepository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = await produtoRepository.ObterTodosOsProdutos();
            var teste = result.Count();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Produto>>();
            result.Should().HaveCountGreaterThan(0);
            Assert.Equal(3, teste);
        }

    }
}