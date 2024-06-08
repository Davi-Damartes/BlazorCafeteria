using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoRepositoriesTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.RepositoriesTest
{
    public class ProdutoRepositoryObterTodosProdutosTest
    {

        [Fact]
        public async Task ProdutoRepository_ObterTodosOsProdutos_ReturnaIEnumerableProduto()
        {
            //Arange
            var dbContext = await BancoDeDadosInMemory.GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = await repository.ObterTodosOsProdutos();
            var teste = result.Count();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Produto>>();
            result.Should().HaveCountGreaterThan(0);
            Assert.Equal(3, teste);
        }

    }
}