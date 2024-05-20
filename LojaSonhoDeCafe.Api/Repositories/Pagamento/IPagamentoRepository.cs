using LojaSonhoDeCafe.Components.CarrinhoPages;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Api.Repositories.Pagamento
{
    public interface IPagamentoRepository2
    {
        Task AdicionarPagamento(PagamentoDiario pagamentoDiario);

        Task<IEnumerable<PagamentoDiario>> BucarTodosPagamentosPeloMes(int mes);
    }
}
