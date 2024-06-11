using LojaSonhoDeCafe.Enum;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Models.MapeandoDtos.PagamentoConversao
{
    public static class PagamentoConversoes
    {
        public static PagamentoDiario ConvertePagamentoDtoParaPagamento(this PagamentoDiarioDto diarioDto)
        {
            return new PagamentoDiario
            {
                //ProdutoId = diarioDto.ProdutoId,
                Usuario = diarioDto.Usuario,
                Email = diarioDto.Email,
                TotalQuantDiaria = diarioDto.TotalQuantDiaria,
                TotalPrecoDiaria = diarioDto.TotalPrecoDiaria,
                EPagamento = (ETipoPagamento)diarioDto.EPagamento,
                HoraDoPagamento = diarioDto.HoraDoPagamento,

            };
        }
      
        public static IEnumerable<PagamentoDiarioDto> ConvertListPagamentosParaListPagamentosDto(
                                                this IEnumerable<PagamentoDiario> pagamentos)
        {
            return (from pagamento in pagamentos
                    select new PagamentoDiarioDto
                    {
                        //ProdutoId = pagamento.ProdutoId,
                        Usuario = pagamento.Usuario,
                        Email = pagamento.Email,
                        TotalQuantDiaria = pagamento.TotalQuantDiaria,
                        TotalPrecoDiaria = pagamento.TotalPrecoDiaria,
                        EPagamento = (EPagamentoDto)pagamento.EPagamento,
                        HoraDoPagamento = pagamento.HoraDoPagamento,
                    }).ToList();

        }

        public static IEnumerable<PagamentoDiarioDto> ConverteListPagamentosParaListPagamentosDtoNOVO(
                                               this IEnumerable<PagamentoDiario> pagamentos)
        {
            return pagamentos.Select(pagamento => new PagamentoDiarioDto
            {
                Usuario = pagamento.Usuario,
                Email = pagamento.Email,
                TotalQuantDiaria = pagamento.TotalQuantDiaria,
                TotalPrecoDiaria = pagamento.TotalPrecoDiaria,
                EPagamento = (EPagamentoDto)pagamento.EPagamento,
                HoraDoPagamento = pagamento.HoraDoPagamento,
                ProdutosDoPagamento = pagamento.PagamentoProdutos
                              .Select(produto => new PagamentoProdutoDto
                              {
                                  ProdutoId = produto.ProdutoId,
                                  QuantidadeComprada = produto.QuantidadeComprada,
                                  ProdutoNome = produto.ProdutoNome,
                                  PrecoTotal = produto.PrecoTotal
                              }).ToList()
            }).ToList();

        }



    }
}
