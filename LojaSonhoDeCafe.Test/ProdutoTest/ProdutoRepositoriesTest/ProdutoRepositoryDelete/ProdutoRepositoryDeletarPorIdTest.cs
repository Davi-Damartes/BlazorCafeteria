using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoTest.ProdutoRepositoriesTest.BancoInMemoryMetodo;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoRepositoriesTest.ProdutoRepositoryDelete
{
    public class ProdutoRepositoryDeletarPorIdTest
    {

        [Fact]
        public async Task ProdutoRepository_ExcluirProduto_ReturnNaoNull()
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


            var dbContext = await BancoDeDadosInMemory.GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            await repository.AdicionarNovoProduto(produto);
            var qntAntesExclusao = dbContext.Produtos.Count();
            Assert.Equal(4, qntAntesExclusao);
            //Act
            var result = repository.ExcluirProduto(produto.Id);
            var qntDepoisExclusao = await dbContext.Produtos.CountAsync();

            //Assert
            result.Should().NotBeNull();
            Assert.Equal(3, qntDepoisExclusao);

        }
    }
}