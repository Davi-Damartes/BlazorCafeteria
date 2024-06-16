using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Models.MapeandoDtos.ProdutosMapping;
using System.Collections.ObjectModel;


namespace LojaSonhoDeCafe.Test.MapeandoDtosTest.ProdutoMapTest
{
    public class ProdutoConversaoTest
    {

        [Fact]
        public void ConverterProduto_Para_ProdutoDto_DeveRetornar_Valido_ProdutoDto()
        {
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

            var produtoDto = produto.ConverterProdutoParaDto();
          
            Assert.NotNull(produtoDto);

            produtoDto.Id.Should().Be(produto.Id);
            produtoDto.Nome.Should().Be(produto.Nome);
            produtoDto.Descricao.Should().Be(produto.Descricao);
            produtoDto.FotoUrl.Should().Be(produto.FotoUrl);
            produtoDto.Preco.Should().Be(produto.Preco);
            produtoDto.QuantidadeEmEstoque.Should().Be(produto.QuantidadeEmEstoque);
            produtoDto.IsFavorito.Should().Be(produto.IsFavorito);
            produtoDto.CategoriaId.Should().Be(produto.CategoriaId);
            produtoDto.CategoriaNome.Should().Be(produto.Categoria.Nome);

        } 

        [Fact]
        public void ConverterProdutoDto_Para_Produto_DeveRetornar_Valido_Produto()
        {
            var produtoDto = new ProdutoDto
            {
                Id = Guid.NewGuid(),
                Nome = "Café Expresso",
                Descricao = "Café Expresso de melhor qualidade do Brasil.",
                FotoUrl = "https://example.com/cafe.jpg",
                Preco = 30.99M,
                QuantidadeEmEstoque = 50,
                IsFavorito = true,
                CategoriaId = 1, 
                CategoriaNome =  "Bebidas"
            };

            var produto = produtoDto.ConverterProdutoDtoParaProduto();
          
            Assert.NotNull(produtoDto);

            produto.Id.Should().Be(produtoDto.Id);
            produto.Nome.Should().Be(produtoDto.Nome);
            produto.Descricao.Should().Be(produtoDto.Descricao);
            produto.FotoUrl.Should().Be(produtoDto.FotoUrl);
            produto.Preco.Should().Be(produtoDto.Preco);
            produto.QuantidadeEmEstoque.Should().Be(produtoDto.QuantidadeEmEstoque);
            produto.IsFavorito.Should().Be(produtoDto.IsFavorito);
            produto.CategoriaId.Should().Be(produtoDto.CategoriaId);

        }

        [Fact]
        public void ConverterProdutos_Para_ProdutosDto_DeveRetornar_Valido_ListaDeProdutos( )
        {
            // Arrange
            var listaProdutos = new List<Produto> {
                new Produto
                {
                    Nome = "Café Expresso",
                    Descricao = "Café Expresso de melhor qualidade do Brasil.",
                    FotoUrl = "https://example.com/cafe.jpg",
                    Preco = 10.99M,
                    QuantidadeEmEstoque = 50,
                    IsFavorito = true,
                    CategoriaId = 1,
                    Categoria = new Categoria
                    {
                        Id = 1,
                        Nome = "Bebidas"
                    },
                },  
                
                new Produto
                {
                    Nome = "Chá Expresso",
                    Descricao = "Chá de melhor qualidade do Brasil.",
                    FotoUrl = "https://example.com/cafe.jpg",
                    Preco = 5.99M,
                    QuantidadeEmEstoque = 50,
                    IsFavorito = true,
                    CategoriaId = 2,
                    Categoria = new Categoria
                    {
                        Id = 2,
                        Nome = "Chás"
                    },
                },

                new Produto
                {
                    Nome = "Capuccino Expresso",
                    Descricao = "Capuccino Expresso de melhor qualidade do Brasil.",
                    FotoUrl = "https://example.com/cafe.jpg",
                    Preco = 10.99M,
                    QuantidadeEmEstoque = 50,
                    IsFavorito = true,
                    CategoriaId = 1,
                    Categoria = new Categoria
                    {
                        Id = 1,
                        Nome = "Bebidas"
                    },
                },
            };
            
            // Act
            var listaProdutoDto = listaProdutos.ConverterProdutosParaProdutosDto();


            // Assert 
            listaProdutoDto.Should().NotBeNullOrEmpty();
            listaProdutoDto.Should().HaveCount(3);
            listaProdutoDto.First().Id.Should().Be(listaProdutos.First().Id);
            listaProdutoDto.First().Nome.Should().Be("Café Expresso");
            listaProdutoDto.First().Preco.Should().Be(10.99M);
            listaProdutoDto.First().QuantidadeEmEstoque.Should().Be(50);

        }    
        
         [Fact]
        public void ConverterCategorias_Para_CategoriasDto_DeveRetornar_Valido_ListaDeCategorias( )
        {
            // Arrange
            var categorias = new List<Categoria>
            {
                new Categoria
                {
                    Id = 1,
                    Nome = "Bebidas",
                    IconeCss = "fas fa-coffee",
                    Produtos = new Collection<Produto>
                    {
                        new Produto
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Café Expresso",
                            Descricao = "Café Expresso de melhor qualidade do Brasil.",
                            FotoUrl = "https://example.com/cafe.jpg",
                            Preco = 60.99M,
                            QuantidadeEmEstoque = 50,
                            IsFavorito = true,
                            CategoriaId = 1
                        },
                        new Produto
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Chá Verde",
                            Descricao = "Chá Verde Orgânico.",
                            FotoUrl = "https://example.com/cha.jpg",
                            Preco = 45.50M,
                            QuantidadeEmEstoque = 30,
                            IsFavorito = false,
                            CategoriaId = 1
                        }
                    }
                },
                new Categoria
                {
                    Id = 2,
                    Nome = "Snacks",
                    IconeCss = "fas fa-cookie-bite",
                    Produtos = new Collection<Produto>
                    {
                        new Produto
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Biscoito de Polvilho",
                            Descricao = "Biscoito de polvilho crocante.",
                            FotoUrl = "https://example.com/biscoito.jpg",
                            Preco = 15.00M,
                            QuantidadeEmEstoque = 100,
                            IsFavorito = true,
                            CategoriaId = 2
                        },
                        new Produto
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Chips de Batata",
                            Descricao = "Chips de batata crocante e salgada.",
                            FotoUrl = "https://example.com/chips.jpg",
                            Preco = 20.00M,
                            QuantidadeEmEstoque = 80,
                            IsFavorito = false,
                            CategoriaId = 2
                        }
                    }
                },
                new Categoria
                {
                    Id = 3,
                    Nome = "Sobremesas",
                    IconeCss = "fas fa-ice-cream",
                    Produtos = new Collection<Produto>
                    {
                        new Produto
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Sorvete de Chocolate",
                            Descricao = "Sorvete de chocolate belga.",
                            FotoUrl = "https://example.com/sorvete.jpg",
                            Preco = 25.00M,
                            QuantidadeEmEstoque = 20,
                            IsFavorito = true,
                            CategoriaId = 3
                        },
                        new Produto
                        {
                            Id = Guid.NewGuid(),
                            Nome = "Pudim de Leite",
                            Descricao = "Pudim de leite condensado caseiro.",
                            FotoUrl = "https://example.com/pudim.jpg",
                            Preco = 12.00M,
                            QuantidadeEmEstoque = 40,
                            IsFavorito = false,
                            CategoriaId = 3
                        }
                    }
                }
            };

            // Act
            var listasCategoriasDto = categorias.ConverterCategoriasParaCategoriasDto();


            // Assert 
            listasCategoriasDto.Should().NotBeNullOrEmpty();
            listasCategoriasDto.Should().HaveCount(3);


            var categoria1 = listasCategoriasDto.FirstOrDefault(x => x.Id == 1);
            categoria1!.Nome.Should().Be("Bebidas");
            categoria1.IconeCss.Should().Be("fas fa-coffee");

            listasCategoriasDto.FirstOrDefault(x => x.Id == 2).Should().NotBeNull();
            listasCategoriasDto.FirstOrDefault(x => x.Id == 3).Should().NotBeNull();

        }    
        


    }
}
