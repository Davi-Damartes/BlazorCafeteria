using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.ServicesHttp.PagamentoHttpService
{
    public interface IPagamentoHttpService
    {
        Task<IEnumerable<PagamentoDiarioDto>> ObterTodosPagamentosPorMes(int mes);

        Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto);

    }
}
