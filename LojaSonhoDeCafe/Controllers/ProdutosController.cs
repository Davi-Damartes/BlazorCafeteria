using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Produtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SonhoDeCafe.Server.MapeandoDto;

namespace LojaSonhoDeCafe.Controllers
{
    [Route("produtosTeste")]
    [ApiController]
    [Authorize]
    public class Produtos2Controller : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        public Produtos2Controller(IProdutoRepository produtoRepository)  
        {
            _produtoRepository = produtoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObtendoProdutoss()
        {
            var produtos = await _produtoRepository.ObterTodosOsProdutos();

            var produtosDto = produtos.ConvertProdutosParaDto();

            return Ok(produtosDto);
        }
    }
}
