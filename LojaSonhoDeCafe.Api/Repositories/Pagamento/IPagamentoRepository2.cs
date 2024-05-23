using LojaSonhoDeCafe.Components.CarrinhoPages;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Api.Repositories.Pagamento
{
    public interface IPagamentoRepository2
    {
        Task<IEnumerable<PagamentoDiario>> BucarTodosPagamentosPeloMes(int mes);

        Task<PagamentoDiario> BucarPagamentoPorId(Guid Id);

        Task<IEnumerable<PagamentoDiario>> BucarTodosOsPagamentosXXX();

        Task<IEnumerable<PagamentoProduto>> BucarTodosOsPagamentosProdutos();

        Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiario);

        Task ExcluirPagamento(Guid Id);

    }
}
