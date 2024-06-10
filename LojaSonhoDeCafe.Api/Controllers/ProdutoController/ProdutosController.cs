using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.MapeandoDtos.ProdutosMapping;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Api.Controllers.ProdutoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepositoryApi _produtoRepository;
        public ProdutosController(IProdutoRepositoryApi produtoRepository)
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
                    return NotFound("Produtos não encontrados!");
 
                var produtoDtos = produtos.ConvertProdutosParaDto();
                return Ok(produtoDtos);
                
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
            }
        }

        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<ProdutoDto>> ObterProdutoId(Guid Id)
        {
            try
             {
                var produto = await _produtoRepository.ObterProdutoPorId(Id);
                if (produto is null)
                    return NotFound("Produto não encontrado!");
                
                var produtoDto = produto.ConvertProdutoParaDto();
                return Ok(produtoDto);
                
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
                var produtosPorCategoria = await _produtoRepository.ObterTodosProdutosPorCategoria(categoriaId);
                if (produtosPorCategoria is null)
                    return NotFound("Produtos não encotrados");

                var produtosDto = produtosPorCategoria.ConvertProdutosParaDto();
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
                if(categorias == null)
                {
                    return NotFound("Categorias não encontradas");
                }
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


        [HttpPatch("{Id:guid}/favorito")]
        public async Task<IActionResult> AtualizarProdutoFavoritoPorId(ProdutoDto produtoExistente)
        {
            try
            {              
                if (produtoExistente == null)
                    return NotFound("Produto não encontrado!");

                var produto = produtoExistente.ConvertProdutoDtoParaProduto();
                await _produtoRepository.AtualizaProdutoFavorito(produto);
                return Ok("Produto Atualizado com Sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
            }
        }


        [HttpPut("{Id:Guid}/{Quantidade:int}")]
        public async Task<IActionResult> AdicionarEstoqueAoProduto(Guid Id, int Quantidade)
        {
            try
            {
                var produtoExistente = await _produtoRepository.ObterProdutoPorId(Id);

                if (produtoExistente == null)
                    return NotFound("Produto não encontrado!");

                if (Quantidade <= 0 || Quantidade > 80)
                {
                    return BadRequest("Quantidade Inválida");
                }
                if (produtoExistente.QuantidadeEmEstoque != 0)
                {
                    return BadRequest("Produto ainda possui Estoque!");
                }


                await _produtoRepository.AdicionarEstoqueAoProduto(Id, Quantidade);
                return Ok($"Produto Reabastecido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                  "Erro ao acessar a base de dados");
            }
        }


        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> CriarNovoProduto(ProdutoDto produtoDto)
        {
            try
            {
                var produtoExiste = await _produtoRepository.ObterProdutoPorId(produtoDto.Id);
                if (produtoExiste != null)
                {
                    return Conflict("Produto já existe!");
                }
                var produto = produtoDto.ConvertProdutoDtoParaProduto();
                await _produtoRepository.AdicionarNovoProduto(produto);

                return Created($"Produto Criado com sucesso!", produtoDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                    "Erro ao acessar a base de dados");
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
