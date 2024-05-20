using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using SonhoDeCafe.Server.MapeandoDto;

namespace LojaSonhoDeCafe.Api.Controllers.CarrinhoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository2 _produtoRepository;
        public ProdutosController(IProdutoRepository2 produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObterTodosItens( )
        {
            try
            {
                var produtos = await _produtoRepository.ObterTodosOsProdutos();
                if (produtos is null)
                {
                    return NotFound();
                }
                else
                {
                    var produtoDtos = produtos.ConvertProdutosParaDto();
                    return Ok(produtoDtos);
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObterUmProduto(Guid Id)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorId(Id);
                if (produto is null)
                {
                    return NotFound("Produto não localizado");
                }
                else
                {
                    var produtoDto = produto.ConvertProdutoParaDto();
                    return Ok(produtoDto);
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }

    }
}
