using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Produtos;

namespace LojaSonhoDeCafe.Services.ProdutoServices
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger<ProdutoService> _logger;

        public ProdutoService(IProdutoRepository produtoRepository,
                              ILogger<ProdutoService> logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ProdutoDto>> ObterProdutos( )
        {
            try
            {
                var produtos = await _produtoRepository.ObterTodosOsProdutos();
                if (produtos == null)
                {
                    _logger.LogError("Erro ao buscar Produto");
                }


                var produtosDto = produtos!.ConvertProdutosParaDto();
                return produtosDto;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produtos");
                throw;
            }

        }


        public async Task<ProdutoDto> ObterUmProduto(Guid Id)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorId(Id);

                var produtoDto = produto.ConvertProdutoParaDto();
                return produtoDto;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produto");
                throw;
            }

        }
    }
}
