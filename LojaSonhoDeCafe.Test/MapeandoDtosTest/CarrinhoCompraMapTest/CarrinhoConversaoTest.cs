using FluentAssertions;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Models.MapeandoDtos.CarrinhoCompraMapping;

namespace LojaSonhoDeCafe.Test.MapeandoDtosTest.CarrinhoCompraMapTest
{
    public class CarrinhoConversaoTest
    {
        [Fact]
        public void ConverterCarrinhoItem_Para_CarrinhoItemDto_DeveRetornar_Valido_CarrinhoItemDtoProdutoDto( )
        {
            // Assert
            var carrinhoItem = new CarrinhoItem
            {
                Id = 1,
                CarrinhoId = 1,
                Quantidade = 10,
                QuantidadeEmEstoque = 25,

            };

            var produto = new Produto
            {
                Nome = "Café Expresso",
                Descricao = "Café Expresso de melhor qualidade do Brasil.",
                FotoUrl = "https://example.com/cafe.jpg",
                Preco = 60.99M,
                QuantidadeEmEstoque = 50,
                IsFavorito = true,
                CategoriaId = 1,
                Categoria = new Categoria
                {
                    Id = 1,
                    Nome = "Bebidas"
                },
            };

            // Act 
            var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemProdParaCarrinhoItemDto(produto);


            // Assert

            Assert.NotNull(carrinhoItemDto);

            carrinhoItemDto.CarrinhoId.Should().Be(carrinhoItem.CarrinhoId);
            carrinhoItemDto.Quantidade.Should().Be(carrinhoItem.Quantidade);
            carrinhoItemDto.PrecoTotal.Should().Be(carrinhoItem.Quantidade * produto.Preco);
            carrinhoItemDto.ProdutoNome.Should().Be(produto.Nome);

        }

        [Fact]
        public void ConverteCarrinhoItem_Para_CarrinhoItemDto_DeveRetornar_Valido_CarrinhoItemDtoDto( )
        {
            // Assert
            var carrinhoItem = new CarrinhoItem
            {
                Id = 1,
                CarrinhoId = 1,
                Quantidade = 10,
                QuantidadeEmEstoque = 25,
            };

            var produto = new Produto
            {
                Nome = "Café Expresso",
                Descricao = "Café Expresso de melhor qualidade do Brasil.",
                FotoUrl = "https://example.com/cafe.jpg",
                Preco = 35.99M,
                QuantidadeEmEstoque = 50,
                IsFavorito = true,
                CategoriaId = 1,
                Categoria = new Categoria
                {
                    Id = 1,
                    Nome = "Bebidas"
                },
            };

            // Act 
            var carrinhosItemDto = carrinhoItem.ConverteCarrinhoItemParaCarrinhoDto(produto);


            // Assert

            Assert.NotNull(carrinhosItemDto);

            carrinhosItemDto.CarrinhoId.Should().Be(carrinhoItem.CarrinhoId);
            carrinhosItemDto.Quantidade.Should().Be(carrinhoItem.Quantidade);
            carrinhosItemDto.PrecoTotal.Should().Be(carrinhoItem.Quantidade * produto.Preco);
            carrinhosItemDto.ProdutoNome.Should().Be(produto.Nome);

        }

        [Fact]
        public void ConverteListaCarrinhoItens_Para_listaCarrinhoItensDto_DeveRetornar_Valido_ListaCarrinhoItemDtoDto( )
        {
            // Arrange
            var listaCarrinhoItens = new List<CarrinhoItem>
            {
                new CarrinhoItem
                {
                    Id = 1,
                    CarrinhoId = 1,
                    ProdutoId = Guid.NewGuid(),
                    Quantidade = 2,
                    QuantidadeEmEstoque = 10
                },
                new CarrinhoItem
                {
                    Id = 2,
                    CarrinhoId = 1,
                    ProdutoId = Guid.NewGuid(),
                    Quantidade = 3,
                    QuantidadeEmEstoque = 15
                }
            };

            var listaProdutos = new List<Produto>
            {
                new Produto
                {
                    Id = listaCarrinhoItens[0].ProdutoId,
                    Nome = "Produto 1",
                    Descricao = "Descrição do Produto 1",
                    FotoUrl = "https://example.com/produto1.jpg",
                    Preco = 20.0M,
                    QuantidadeEmEstoque = listaCarrinhoItens[0].QuantidadeEmEstoque
                },
                new Produto
                {
                    Id = listaCarrinhoItens[1].ProdutoId,
                    Nome = "Produto 2",
                    Descricao = "Descrição do Produto 2",
                    FotoUrl = "https://example.com/produto2.jpg",
                    Preco = 15.0M,
                    QuantidadeEmEstoque = listaCarrinhoItens[1].QuantidadeEmEstoque
                }
            };

            // Act
            var listaCarrinhoItensDto = listaCarrinhoItens.ConverterCarrinhoItensParaCarrinhoItensDto(listaProdutos);



            // Assert

            Assert.NotNull(listaCarrinhoItensDto);
            Assert.Equal(2, listaCarrinhoItensDto.Count());

            listaCarrinhoItensDto.First().Id.Should().Be(listaCarrinhoItens.First().Id);
            listaCarrinhoItensDto.First().CarrinhoId.Should().Be(listaCarrinhoItens.First().CarrinhoId);
            listaCarrinhoItensDto.First().Quantidade.Should().Be(listaCarrinhoItens.First().Quantidade);
            listaCarrinhoItensDto.First().ProdutoNome.Should().Be(listaProdutos.First().Nome);

            listaCarrinhoItensDto.First().PrecoTotal.Should().Be
                            (listaCarrinhoItens.First().Quantidade * listaProdutos.First().Preco);

        }
    }
}
