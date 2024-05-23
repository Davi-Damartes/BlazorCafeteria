using LojaSonhoDeCafe.Api.Repositories.Pagamento;
using LojaSonhoDeCafe.MapeandoDtos.PagamentoConversao;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Api.Controllers.PagamentoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepository2 _pagamentoRepository;
        public PagamentoController(IPagamentoRepository2 pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;

        }

        [HttpGet("{mes:int}")]
        public async Task<ActionResult<IEnumerable<PagamentoDiarioDto>>> BuscarTodosPagMes(int mes)
        {
            try
            {
                if(mes <= 0)
                {
                    return NoContent();
                }

                var pagamentosDoMês = await _pagamentoRepository.BucarTodosPagamentosPeloMes(mes);
                if(pagamentosDoMês != null)
                {
                    var pagamentoDto = pagamentosDoMês.ConvertListPagamentosParaListPagamentosDto();
                        
                    return Ok(pagamentoDto);
                }
                return NoContent();
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }


        [HttpPost]
        public async Task<ActionResult<bool>> RealizarPagamento(PagamentoDiarioDto pagamentoDiario)
        {
            try
            {
                var pagamentoRealizado = await _pagamentoRepository.AdicionarPagamento(pagamentoDiario);

                if(pagamentoRealizado == false)
                {
                    return NoContent();
                }

                return Ok(pagamentoDiario);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }
    }
}
