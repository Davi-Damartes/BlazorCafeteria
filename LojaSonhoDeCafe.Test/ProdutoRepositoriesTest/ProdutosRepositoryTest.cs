using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.ProdutoRepositoriesTest;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Test.RepositoriesTest
{
    public class ProdutosRepositoryTest
    {

        private readonly IProdutoRepositoryApi _produtoRepository;

        private readonly BancoDeDado _context;
        public ProdutosRepositoryTest( )
        {
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();

        }
        private async Task<BancoDeDado> GetBancoDeDado( )
        {
            var options = new DbContextOptionsBuilder<BancoDeDado>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new BancoDeDado(options);
            databaseContext.Database.EnsureCreated();


            if (!await databaseContext.Produtos.AnyAsync()) // Negando a condição
            {
                databaseContext.Add(
                    new Categoria()
                    {
                        Id = 5,
                        Nome = "Bebidas",
                        IconeCss = "Café"
                    }
                 );
                
                databaseContext.Add(
                    new Categoria()
                    {
                        Id = 6,
                        Nome = "Doce",
                        IconeCss = "Bolo"
                    }
                 );

                databaseContext.Add(
                    new Produto()
                    {
                        Nome = "Calça Jeans",
                        Descricao = "Uma calça jeans clássica",
                        FotoUrl = "http://example.com/calca-jeans.jpg",
                        Preco = 59.99m,
                        QuantidadeEmEstoque = 25,
                        IsFavorito = true,
                        CategoriaId = 1
                    }
                 );
                databaseContext.Add(
                    new Produto()
                    {
                        Nome = "Camisa Polo",
                        Descricao = "Uma camisa polo elegante",
                        FotoUrl = "http://example.com/camisa-polo.jpg",
                        Preco = 39.99m,
                        QuantidadeEmEstoque = 35,
                        IsFavorito = false,
                        CategoriaId = 2
                    }
                );
                databaseContext.Add(
                    new Produto()
                    {
                        Nome = "Tênis Esportivo",
                        Descricao = "Um tênis confortável para atividades físicas",
                        FotoUrl = "http://example.com/tenis-esportivo.jpg",
                        Preco = 79.99m,
                        QuantidadeEmEstoque = 15,
                        IsFavorito = true,
                        CategoriaId = 3
                    }
                );



                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [Fact]
        public async Task ProdutoRepository_ObterProdutoPorId_ReturnaIEnumerableProduto()
        {
            //Arange
            var produtoId = Guid.NewGuid();

            var dbContext = await GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = repository.ObterProdutoPorId(produtoId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Produto>>();

        }

        [Fact]
        public async Task ProdutoRepository_ObterTodosOsProdutos_ReturnaIEnumerableProduto()
        {
            //Arange
            var dbContext = await GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = await repository.ObterTodosOsProdutos();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Produto>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task ProdutoRepository_ObterCategoria_ReturnaIEnumerableCategorias()
        {
            //Arange

            var dbContext = await GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = repository.ObterCategorias();

            //Assert         
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IEnumerable<Categoria>>>();
        }

        [Fact]
        public async Task ProdutoRepository_AdicionarNovoProduto_ReturnoNaoPodeSerNull()
        {
            //Arange
            var produto = A.Fake<Produto>();

            var dbContext = await GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = repository.AdicionarNovoProduto(produto);

            //Assert
            result.Should().NotBeNull();

        }

        [Fact]
        public async Task ProdutoRepository_AdicionarProdutoAoEstoque_ReturnoNaoPodeSerNull()
        {
            //Arange
            var produtoId = Guid.NewGuid();
            int quantidade = 1;

            var dbContext = await GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = repository.AdicionarEstoqueAoProduto(produtoId, quantidade);

            //Assert
            result.Should().NotBeNull();

        }

        [Fact]
        public async Task ProdutoRepository_ExcluirProduto_ReturnTrue()
        {
            //Arange
            var produtoId = Guid.NewGuid();


            var dbContext = await GetBancoDeDado();

            var repository = new ProdutoRepositoryApi(dbContext);

            //Act
            var result = repository.ExcluirProduto(produtoId);

            //Assert
            result.Should().NotBeNull();

            var produto = repository.ObterProdutoPorId(produtoId);

            produto.Result.Should().BeNull();

        }

   
    }
}
