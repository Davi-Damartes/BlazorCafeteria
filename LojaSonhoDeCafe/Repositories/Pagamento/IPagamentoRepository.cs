using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Repositories.Pagamento
{
    public interface IPagamentoRepository
    {
        Task AdicionarPagamento(PagamentoDiario pagamentoDiario);

        Task<IEnumerable<PagamentoDiario>> BucarTodosPagamentosPeloMes(int mes);
    }
}
