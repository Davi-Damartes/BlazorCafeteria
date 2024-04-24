using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Produtos;
using SonhoDeCafe.Server.MapeandoDto;

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

        public async Task AdicionarProduto(ProdutoDto produtoDto)
        {
            try
            {
                if(produtoDto != null)
                { 
                    await _produtoRepository.AdicionarNovoProdutoDto(produtoDto);
                }
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao Adicionar novo Produto");
                throw;
            }

        }

        public async Task AtualizaProdutoService(ProdutoDto produtoDto)
        {
            try
            {
                if(produtoDto != null)
                {
                    await _produtoRepository.AtualizaProduto(produtoDto);

                }
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao Atualizar produto");
                throw;
            }
        }

        public async Task<IEnumerable<CategoriaDto>> BuscarCategorias()
        {
            try
            {
                var categorias = await _produtoRepository.ObterCategorias();

                var categoriasDto = categorias.ConverterCategoriasParaDto();

                return categoriasDto;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Categorias");
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> BuscarItensPorCategoria(int categoriaId)
        {
            try
            {
                var itensPorCategoria = await _produtoRepository
                                    .ObterTodosProdutosPorCategoria(categoriaId);

                if (itensPorCategoria == null)
                {

                    _logger.LogError("Erro ao obter Produtos pela Categorias");
                }

                var itensPorCategoriaDto = itensPorCategoria!.ConvertProdutosParaDto();
                
                return itensPorCategoriaDto;

            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Categorias");
                throw;
            }
        }


        public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
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
