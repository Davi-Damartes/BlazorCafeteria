using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SonhoDeCafe.Server.MapeandoDto;

namespace LojaSonhoDeCafe.Api.Controllers.CarrinhoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoCompraRepositoryApi _carrinhoCompraRepository;
        private readonly IProdutoRepositoryApi _produtoRepository;

        private ILogger<CarrinhoController> _logger;

        public CarrinhoController(ICarrinhoCompraRepositoryApi carrinhoCompraRepository,
                                  IProdutoRepositoryApi produtoRepository,
                                  ILogger<CarrinhoController> logger)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{usuarioId}/ObterItensCarrinhoDoUsuario")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObterItensCarrinhoDoUsuario(string usuarioId)
        {
            try
            {
                var carrinhoItens = await _carrinhoCompraRepository.ObtemItensDoCarinho(usuarioId);

                if (carrinhoItens == null)
                {
                    return NoContent();
                }

                var produtos = await _produtoRepository.ObterTodosOsProdutos();
                if (produtos == null)
                {
                    throw new Exception("Não existem produtos...");
                }

                var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);
                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao obter itens do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> ObterItemCarrinhoId(int id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.ObtemItemDoCarrinhoPorId(id);
                if (carrinhoItem == null)
                {
                    return NotFound($"Item não encontrado"); //404 status code
                }

                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId);

                if (produto == null)
                {
                    return NotFound($"Item não existe na fonte de dados");
                }
                var cartItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"## Erro ao obter o item ={id} do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> AtualizaQuantidadeItemNoCarrinho(int id,
                                                                    CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.AtualizaQuantidade(id, carrinhoItemAtualizaQuantidadeDto);

                if (carrinhoItem == null)
                {
                    return NotFound("Item do Carrinho não encontrado!"); 
                }

                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId);

                if (produto == null)
                {
                    return NotFound("Produto do Carrinho não encontrado!");
                }

                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);

                return Ok(carrinhoItemDto); 

            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro Ao atulizar Quantidade do Item no Carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> AdicionarItemCarrinho([FromBody]
                                                        CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await _carrinhoCompraRepository.AdicionaItem(carrinhoItemAdicionaDto);

                if (novoCarrinhoItem == null)
                {
                    return NoContent(); //Status 204
                }

                var produto = await _produtoRepository.ObterProdutoPorId(novoCarrinhoItem.ProdutoId);

                if (produto == null)
                {
                    throw new Exception($"Produto não localizado (Id:({carrinhoItemAdicionaDto.ProdutoId})");
                }

                var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItemParaDto(produto);

                return CreatedAtAction(nameof(ObterItemCarrinhoId), new { id = novoCarrinhoItemDto.Id },
               novoCarrinhoItemDto);

            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro criar um novo item no carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> LimparItensDoCarrinho()
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.LimpaItensDoCarrinho();

                if (carrinhoItem == false)
                {
                    return BadRequest("Erro ao excluir itens do Carrinho de Compra");
                }

                return Ok("Carrinho de compras esvaziado com Sucesso!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}/DeletarItemCarrinho")]
        public async Task<ActionResult<CarrinhoItemDto>> DeletarItemCarrinho(int id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.DeletaItem(id);

                if (carrinhoItem == null)
                {
                    return NotFound("Item do Carrinho não encotrado");
                }

                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId);

                if (produto is null)
                    return NotFound("Produto do Carrinho não encotrado");

                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                return Ok(carrinhoItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       
    }
    
}
