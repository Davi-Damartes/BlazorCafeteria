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
        private readonly IPagamentoRepositoryApi _pagamentoRepository;
        public PagamentoController(IPagamentoRepositoryApi pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoDiarioDto>>> BuscarTodosPagamentos( )
        {
            try
            {
                var pagamentos = await _pagamentoRepository.BucarTodosOsPagamentosXXX();
                if (pagamentos != null)
                {
                    var pagamentoDto = pagamentos.ConverteListPagamentosParaListPagamentosDtoNOVO();

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

        [HttpGet]
        [Route("BuscarTodosPagamentosProd")]
        public async Task<ActionResult<IEnumerable<PagamentoProduto>>> BuscarTodosPagamentosProd( )
        {
            try
            {
                var pagamento = await _pagamentoRepository.BucarTodosOsPagamentosProdutos();
                if (pagamento != null)
                {
                    return Ok(pagamento);
                }
                return BadRequest("Erro ----------");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("BuscarPagamentsPorId/{Id:Guid}")]
        public async Task<ActionResult<PagamentoDiarioDto>> BuscarPagamentoPorId(Guid Id)
        {
            try
            {
                var pagamento = await _pagamentoRepository.BucarPagamentoPorId(Id);
                if (pagamento != null)
                {
                    //Cria metodo para Converter PAGAMETNODIARIO PARA DTO
                    return Ok(pagamento);
                }
                return BadRequest("Pagamento não Encontrado!!!");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }


        [HttpGet("{mes:int}")]
        public async Task<ActionResult<IEnumerable<PagamentoDiarioDto>>> BuscarPagamentoPeloMes(int mes)
        {
            try
            {
                if (mes <= 0)
                {
                    return NoContent();
                }

                var pagamentosDoMês = await _pagamentoRepository.BucarTodosPagamentosPeloMes(mes);
                if (pagamentosDoMês != null)
                {
                    var pagamentoDto = pagamentosDoMês.ConverteListPagamentosParaListPagamentosDtoNOVO();

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
        public async Task<ActionResult<bool>> RealizarPagamento(PagamentoDiarioDto pagamentoDiarioDto)
        {

            if (!ValidarDataPagamento(pagamentoDiarioDto))
            {
                return BadRequest("A loja está fechada. O pagamento não pôde ser processado.");
            }

            try
            {
                var pagamentoRealizado = await _pagamentoRepository.AdicionarPagamento(pagamentoDiarioDto);

                if (pagamentoRealizado == false)
                {
                    return NoContent();
                }

                return Ok(pagamentoDiarioDto);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> DeletarPagamento(Guid Id)
        {
            try
            {
                var pagamento = await _pagamentoRepository.BucarPagamentoPorId(Id);
                if (pagamento == null)
                {
                    return NotFound("Pagamento não encontrado!");
                }
                 await _pagamentoRepository.ExcluirPagamento(pagamento.Id);
                 return Ok("Pagamento deletado com sucesso");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }


        private bool ValidarDataPagamento(PagamentoDiarioDto pagamento)
        {
            var horaAbertura = new TimeSpan(07, 00, 00);
            var horaFechamento = new TimeSpan(22, 00, 00);

            TimeSpan horaPagamento = pagamento.HoraDoPagamento.TimeOfDay;

            // Verifica se a hora do pagamento está entre 07:00:00 e 19:00:00
            return horaPagamento >= horaAbertura && horaPagamento <= horaFechamento;
        }
    }
}
