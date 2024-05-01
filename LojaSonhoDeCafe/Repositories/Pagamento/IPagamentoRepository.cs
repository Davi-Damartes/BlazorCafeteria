using LojaSonhoDeCafe.Components.CarrinhoPages;
using LojaSonhoDeCafe.Entities;

namespace LojaSonhoDeCafe.Repositories.Pagamento
{
    public interface IPagamentoRepository
    {

        Task AdicionarPagamento(PagamentoDiario pagamentoDiario);
    }
}
