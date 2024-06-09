using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoRepositoriesTest.BancoInMemoryMetodo;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Test.RepositoriesTest
{
    public class ProdutoRepositoryAddProdutoTest
    {

        [Fact]
        public async Task ProdutoRepository_AdicionarNovoProduto_ReturnoNaoPodeSerNull( )
        {
            //Arange
            var produto = A.Fake<Produto>();

            var dbContext = await BancoDeDadosInMemory.GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var QntAntes = dbContext.Produtos.Count();
            Assert.Equal(3, QntAntes);
            var result = repository.AdicionarNovoProduto(produto);

            var QntDepois = await dbContext.Produtos.CountAsync();

            //Assert
            Assert.Equal(4, QntDepois);
            result.Should().NotBeNull();
            result.Id.Should().NotBe(null);
        }
    }
}