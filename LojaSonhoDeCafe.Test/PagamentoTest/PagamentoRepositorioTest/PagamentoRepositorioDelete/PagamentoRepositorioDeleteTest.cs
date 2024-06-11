using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Pagamento;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.PagamentoTest.PagamentoRepositorioTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoRepositorioTest.PagamentoRepositorioDelete
{
    public class PagamentoRepositorioDeleteTest
    {
        [Fact]
        public async Task PagRepositorio_ExcluirPagamento_IdValido_RetornaPagamentoVazio( )
        {
            // Arrange
            var dbContext = await BancoDeDadosInMemoryPag .GetBancoDeDadoPag();

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

            var pagamentoRepositorio = new PagamentoRepositoryApi(dbContext);

            // Act
            await pagamentoRepositorio.ExcluirPagamento(pagamentoDiario.Id);

            // Assert
            pagamentoRepositorio.Should().NotBeNull();

            var aposExclusao = await dbContext.PagamentosDiarios.FindAsync(pagamentoDiario.Id);
            aposExclusao.Should().BeNull();
            
        }

        [Fact]
        public async Task PagRepositorio_ExcluirPagamento_IdInválido_ReturPagamento()
        {
            // Arrange
            var dbContext = await BancoDeDadosInMemoryPag .GetBancoDeDadoPag();

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
            var pagamentoId = pagamentoDiario.Id;


            await dbContext.PagamentosDiarios.AddAsync(pagamentoDiario);
            await dbContext.SaveChangesAsync();

            var pagamentoRepositorio = new PagamentoRepositoryApi(dbContext);
            pagamentoDiario.Id = Guid.Empty;
            // Act
            await pagamentoRepositorio.ExcluirPagamento(pagamentoDiario.Id);

            // Assert
            pagamentoRepositorio.Should().NotBeNull();

            var aposExclusao = await dbContext.PagamentosDiarios.FindAsync(pagamentoId);
            aposExclusao.Should().NotBeNull();
            
        }

    }
}
