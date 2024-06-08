using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoRepositoriesTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.RepositoriesTest
{
    public class ProdutoRepositoryAttProdQntTest
    {

        [Fact]
        public async Task ProdutoRepository_AdicionarProdutoAoEstoque_ReturnoNaoPodeSerNull( )
        {
            //Arange
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Calça Jeans",
                Descricao = "Uma calça jeans clássica",
                FotoUrl = "http://example.com/calca-jeans.jpg",
                Preco = 59.99m,
                QuantidadeEmEstoque = 0,
                IsFavorito = true,
                CategoriaId = 1
            };

            int quantidade = 10;

            var dbContext = await BancoDeDadosInMemory.GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            await repository.AdicionarNovoProduto(produto);
            var qntAntes = dbContext.Produtos.Where(p => p.Id == produto.Id).Select(p => p.QuantidadeEmEstoque).FirstOrDefault();
            Assert.Equal(0, qntAntes);


            var result = repository.AdicionarEstoqueAoProduto(produto.Id, quantidade);
            var qntDepois = dbContext.Produtos.Where(p => p.Id == produto.Id).Select(p => p.QuantidadeEmEstoque).FirstOrDefault();

            // Assert
            result.Should().NotBeNull();
            Assert.Equal(10, qntDepois);
        }

    }
}