using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Produtos;
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
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObterTodosItens()
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
                    return NotFound("Produto não encontrado!");
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

        [HttpGet]
        [Route("{categoriaId}/ObterProdutosPorCategoria")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObterProdutosPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.ObterTodosProdutosPorCategoria(categoriaId);
                var produtosDto = produtos.ConvertProdutosParaDto();
                return Ok(produtosDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Erro ao acessar o banco de dados");
            }
        }

        [HttpGet]
        [Route("BuscarCategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> BuscarCategorias()
        {
            try
            {
                var categorias = await _produtoRepository.ObterCategorias();
                var categoriasDto = categorias.ConverterCategoriasParaDto();
                return Ok(categoriasDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "Erro ao acessar o banco de dados");
            }
        }

        [HttpGet]
        [Route("BuscarProdutoFavoritos")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> BuscarProdutoFavoritos()
        {
            try
            {
                var produtosFavoritos = await _produtoRepository.ObterProdutosFavoritos();
                if (produtosFavoritos is null)
                {
                    return NotFound("Não há produtos favoritos");
                }
                else
                {
                    var produtoFavoritosDtos = produtosFavoritos.ConvertProdutosParaDto();
                    return Ok(produtoFavoritosDtos);
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }


        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> AdicionarProduto(ProdutoDto produtoDto)
        {
            try
            {
                var produtoExiste = await _produtoRepository.ObterProdutoPorId(produtoDto.Id);
                if (produtoExiste == null)
                {
                    await _produtoRepository.AdicionarNovoProdutoDto(produtoDto);
                    return CreatedAtAction(nameof(AdicionarProduto), new { id = produtoDto.Id }, produtoDto);
                }
                return Conflict("Produto já existe!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> DeletarProduto(Guid Id)
        {
            try
            {
                var produtoExiste = await _produtoRepository.ObterProdutoPorId(Id);

                if(produtoExiste == null)
                {
                    return NotFound("Produto não encontrado");
                }

                await _produtoRepository.ExcluirProduto(produtoExiste.Id);
                return Ok("Produto Excluído com sucesso!");

                
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }

    }
}
