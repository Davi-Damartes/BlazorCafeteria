using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.MapeandoDtos.CarrinhoCompraMapping;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Api.Controllers.CarrinhoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoCompraRepositoryApi _carrinhoCompraRepository;
        private readonly IProdutoRepositoryApi _produtoRepository;

        //private ILogger<CarrinhoController> _logger;

        public CarrinhoController(ICarrinhoCompraRepositoryApi carrinhoCompraRepository,
                                  IProdutoRepositoryApi produtoRepository)
                                 //ILogger<CarrinhoController> logger)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _produtoRepository = produtoRepository;
           // _logger = logger;
        }

        [HttpGet]
        [Route("{usuarioId}/ObterItensCarrinhoDoUsuario")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> ObterItensCarrinhoDoUsuario(string usuarioId)
        {
            try
            {
                var carrinhoItens = await _carrinhoCompraRepository.ObtemItensDoCarinho(usuarioId);

                if (carrinhoItens == null)
                {
                    return NotFound("Itens do Carrinho não encontrados!");
                }

                var produtos = await _produtoRepository.ObterTodosOsProdutos();
                if (produtos == null)
                {
                    return NotFound("Produtos do Carrinho não encontrados!");
                }

                var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaCarrinhoItensDto(produtos);
                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                //_logger.LogError("## Erro ao obter itens do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> ObterItemCarrinhoId(int Id)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.ObtemItemDoCarrinhoPorId(Id);
                if (carrinhoItem == null)
                {
                    return NotFound($"Item não encontrado"); //404 status code
                }

                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId);

                if (produto == null)
                {
                    return NotFound($"Item não existe na fonte de dados");
                }
                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemProdParaCarrinhoItemDto(produto);

                return Ok(carrinhoItemDto);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"## Erro ao obter o item ={id} do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CarrinhoItemDto>> AtualizaQuantidadeItemNoCarrinho(int Id,
                                                                    CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var carrinhoItem = await _carrinhoCompraRepository.AtualizaQuantidade(Id, carrinhoItemAtualizaQuantidadeDto);

                if (carrinhoItem == null)
                {
                    return NotFound("Item do Carrinho não encontrado!"); 
                }

                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId);

                if (produto == null)
                {
                    return NotFound("Produto do Carrinho não encontrado!");
                }

                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemProdParaCarrinhoItemDto(produto);

                return Ok(carrinhoItemDto); 

            }
            catch (Exception ex)
            {
                //_logger.LogError("## Erro Ao atulizar Quantidade do Item no Carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> AdicionarItemCarrinho(
                                                        CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await _carrinhoCompraRepository.AdicionaItem(carrinhoItemAdicionaDto);

                if (novoCarrinhoItem == null)
                {
                    return NotFound("Erro ao adicionar item ao carrinho"); 
                }

                var produto = await _produtoRepository.ObterProdutoPorId(novoCarrinhoItem.ProdutoId);

                if (produto == null)
                {
                    return NotFound("Erro ao obter Produto do carrinho");
                }

                var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItemProdParaCarrinhoItemDto(produto);

                return CreatedAtAction(nameof(ObterItemCarrinhoId), new { id = novoCarrinhoItemDto.Id },
                                        novoCarrinhoItemDto);

            }
            catch (Exception ex)
            {
                //_logger.LogError("## Erro criar um novo item no carrinho");
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

                return Ok("Carrinho de compras Limpo com Sucesso!");

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

                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemProdParaCarrinhoItemDto(produto);
                return Ok(carrinhoItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       
    }
    
}
