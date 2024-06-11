using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Pagamento;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.PagamentoTest.PagamentoRepositorioTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoRepositorioTest.PagamentoRepositorioGet
{
    public class PagamentoRepositorioGetTest
    {
        [Fact]
        public async Task PagRepositorio_BucarPagamentoPorId_ReturnPagamentoDiario( )
        {
            // Arrange
            var dbContext = await BancoDeDadosInMemoryPag.GetBancoDeDadoPag();

            var listaPagamentoDiario = A.Fake<List<PagamentoProduto>>();

            var pagamentoDiario = new PagamentoDiario
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = Enum.ETipoPagamento.paypal,
                HoraDoPagamento = DateTime.Now,
                PagamentoProdutos = listaPagamentoDiario
            };


            await dbContext.PagamentosDiarios.AddAsync(pagamentoDiario);
            await dbContext.SaveChangesAsync();


            var repositoryPagamento = new PagamentoRepositoryApi(dbContext);

            // Act
            var result = await repositoryPagamento.BucarPagamentoPorId(pagamentoDiario.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<PagamentoDiario>();
            Assert.Equal(pagamentoDiario.Id, result.Id);
            Assert.Equal(pagamentoDiario.Usuario, result.Usuario);

        }

        [Fact]
        public async Task PagRepositorio_BucarTodosOsPagamentosXXX_ReturnListPagamentoDiario( )
        {
            // Arrange
            var dbContext = await BancoDeDadosInMemoryPag.GetBancoDeDadoPag();

            var listaPagamentoDiario = A.Fake<List<PagamentoProduto>>();
            var listaPagamentoDiario2 = A.Fake<List<PagamentoProduto>>();

            var pagamentoDiario = new PagamentoDiario
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = Enum.ETipoPagamento.paypal,
                HoraDoPagamento = DateTime.Now,
                PagamentoProdutos = listaPagamentoDiario
            };   

            var pagamentoDiario2 = new PagamentoDiario
            {
                Usuario = "Usuario2Teste",
                Email = "email2@teste.com",
                TotalQuantDiaria = 5,
                TotalPrecoDiaria = 12.5m,
                EPagamento = Enum.ETipoPagamento.mastercard,
                HoraDoPagamento = DateTime.Now,
                PagamentoProdutos = listaPagamentoDiario2
            };


            await dbContext.PagamentosDiarios.AddAsync(pagamentoDiario);
            await dbContext.PagamentosDiarios.AddAsync(pagamentoDiario2);
            await dbContext.SaveChangesAsync();


            var repositoryPagamento = new PagamentoRepositoryApi(dbContext);

            // Act
            var result =  await repositoryPagamento.BucarTodosOsPagamentos();
            var contador = result.Count();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<PagamentoDiario>>();
            result.Count().Should().BeGreaterThanOrEqualTo(0);
            result.Count().Should().Be(contador);
            result.FirstOrDefault()?.Usuario.Should().Be("UsuarioTeste");

        }
        
        [Fact]
        public async Task PagRepositorio_BucarTodosPagamentosPeloMes_ReturnListPagamentoDiario( )
        {
            // Arrange
            int mes = 6;
            var dbContext = await BancoDeDadosInMemoryPag.GetBancoDeDadoPag();

            var listaPagamentoDiario = A.Fake<List<PagamentoProduto>>();

            var pagamentoDiario = new PagamentoDiario
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = Enum.ETipoPagamento.paypal,
                HoraDoPagamento = DateTime.Now,
                PagamentoProdutos = listaPagamentoDiario
            };   

            await dbContext.PagamentosDiarios.AddAsync(pagamentoDiario);
            await dbContext.SaveChangesAsync();


            var repositoryPagamento = new PagamentoRepositoryApi(dbContext);

            // Act
            var result =  await repositoryPagamento.BucarTodosPagamentosPeloMes(mes);
            var contador = result.Count();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<PagamentoDiario>>();
            result.Count().Should().BeGreaterThanOrEqualTo(0);
            result.Count().Should().Be(contador);
            result.FirstOrDefault()?.Usuario.Should().Be("UsuarioTeste2");

        }
    
        [Fact]
        public async Task PagRepositorio_BucarTodosOsPagamentosProdutos_ReturnListPagamentoProduto( )
        {
            // Arrange
            var dbContext = await BancoDeDadosInMemoryPag.GetBancoDeDadoPag();

            var listaPagamentoProdutos = A.Fake<List<PagamentoProduto>>();

            var pagamentoDiario = new PagamentoDiario
            {
                Usuario = "UsuarioTeste2",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = Enum.ETipoPagamento.paypal,
                HoraDoPagamento = DateTime.Now,
                PagamentoProdutos = listaPagamentoProdutos
            };

            var pagamentoProduto = new PagamentoProduto
            {

                ProdutoId = Guid.NewGuid(),
                ProdutoNome = "Produto Teste",
                QuantidadeComprada = 10,
                PrecoTotal = 299.99m,
                PagamentoDiarioId = Guid.NewGuid(),
                PagamentoDiario = pagamentoDiario
            };   

            await dbContext.PagamentoProdutos.AddAsync(pagamentoProduto);
            await dbContext.SaveChangesAsync();


            var repositoryPagamento = new PagamentoRepositoryApi(dbContext);

            // Act
            var result =  await repositoryPagamento.BucarTodosOsPagamentosDeProdutos();
            var contador = result.Count();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<PagamentoProduto>>();
            result.Count().Should().BeGreaterThanOrEqualTo(0);
            result.Count().Should().Be(contador);
            result.FirstOrDefault(x => x.Id == pagamentoProduto.Id)!.ProdutoNome.Should().Be("Produto Teste");

        }
       
    }
}
