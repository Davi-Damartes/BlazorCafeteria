using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.ServicesHttp.PagamentoHttpService
{
    public interface IPagamentoHttpService
    {
        Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto);

        Task<IEnumerable<PagamentoDiarioDto>> ObterTodosPagamentosPorMes(int mes);
    }
}
