using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.PagamentoServices
{
    public interface IPagamentoService
    {
        Task AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto);

        Task<IEnumerable<PagamentoDiarioDto>> ObterTodosPagamentosPorMes(int mes);

    }
}
