using LojaSonhoDeCafe.Enum;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.MapeandoDtos.PagamentoConversao
{
    public static class PagamentoConversoes
    {
        public static PagamentoDiario ConvertePagamentoDtoParaPagamento(this PagamentoDiarioDto diarioDto)
        {
            return new PagamentoDiario
            {
                Usuario = diarioDto.Usuario,
                Email = diarioDto.Email,
                TotalQuantDiaria = diarioDto.TotalQuantDiaria,
                TotalPrecoDiaria = diarioDto.TotalPrecoDiaria,
                EPagamento = (ETipoPagamento)diarioDto.EPagamento,
                HoraDoPagamento = diarioDto.HoraDoPagamento,

            };
        }

        public static IEnumerable<PagamentoDiarioDto> ConvertListPagamentosParaListPagamentosDto(
                                                this IEnumerable<PagamentoDiario> pagamentos
            )
        {
            return (from pagamento in pagamentos
                    select new PagamentoDiarioDto
                    {
                        Usuario = pagamento.Usuario,
                        Email = pagamento.Email,
                        TotalQuantDiaria = pagamento.TotalQuantDiaria,
                        TotalPrecoDiaria = pagamento.TotalPrecoDiaria,
                        EPagamento = (EPagamentoDto)pagamento.EPagamento,
                        HoraDoPagamento = pagamento.HoraDoPagamento,
                    }).ToList();

        }

       

    }
}
