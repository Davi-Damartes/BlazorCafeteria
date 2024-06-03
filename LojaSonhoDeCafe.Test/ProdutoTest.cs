using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using SonhoDeCafe.Server.MapeandoDto;

namespace LojaSonhoDeCafe.Test
{
    public class ProdutoTest
    {
        [Fact]
        public void ProdutoDto_CriandoProdutoDto_ProdutoNaoPodeSerNull()
        {
            //Arrange
            var produtoDto = new ProdutoDto
            {
                Id = Guid.NewGuid(),
                Nome = "Café Especial",
                Descricao = "Um blend exclusivo de grãos de café arábica.",
                FotoUrl = "http://example.com/cafe-especial.jpg",
                Preco = 25.99m,
                QuantidadeEmEstoque = 100,
                IsFavorito = true,
                CategoriaId = 1,
                CategoriaNome = null,
            };

            //Assert
            produtoDto.CategoriaNome.Should().NotBeEquivalentTo(null);

        }
        
        [Fact]
        public void ProdutoDto_IdNaoPodeSerEmpty()
        {
            // Arrange
            var produtoDto = new ProdutoDto
            {
                Id = Guid.Empty,
                Nome = "Café Especial",
                Descricao = "Um blend exclusivo de grãos de café arábica.",
                FotoUrl = "http://example.com/cafe-especial.jpg",
                Preco = 25.99m,
                QuantidadeEmEstoque = 100,
                IsFavorito = true,
                CategoriaId = 1,
                CategoriaNome = "Lanches",
            };

            // Act - Não há necessidade de uma ação explícita neste teste

            // Assert
            produtoDto.Id.Should().Be(Guid.Empty);
        }
    }
}
