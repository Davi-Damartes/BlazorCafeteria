using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Api.Repositories.Pagamento
{
    public interface IPagamentoRepositoryApi
    {
        Task<IEnumerable<PagamentoDiario>> BucarTodosPagamentosPeloMes(int mes);

        Task<PagamentoDiario> BucarPagamentoPorId(Guid Id);

        Task<IEnumerable<PagamentoDiario>> BucarTodosOsPagamentos();

        Task<IEnumerable<PagamentoProduto>> BucarTodosOsPagamentosDeProdutos();

        Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiario);

        Task ExcluirPagamento(Guid Id);

    }
}
