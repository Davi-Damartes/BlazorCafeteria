using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoRepositoriesTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.RepositoriesTest
{
    public class ProdutoRepositoryObterCategoriasTest
    {

        [Fact]
        public async Task ProdutoRepository_ObterCategorias_ReturnaIEnumerableCategoria()
        {
            //Arange

            var dbContext = await BancoDeDadosInMemory.GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = repository.ObterCategorias();

            //Assert         
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IEnumerable<Categoria>>>();
        }

    }
}