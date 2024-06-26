﻿using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.MapeandoDtos.ProdutosMapping;
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

        public async Task AtualizaProdutoServiceFavorito(ProdutoDto produtoDto)
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

                var categoriasDto = categorias.ConverterCategoriasParaCategoriasDto();

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
                    return Enumerable.Empty<ProdutoDto>();
                }

                var itensPorCategoriaDto = itensPorCategoria!.ConverterProdutosParaProdutosDto();
                
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
                    return Enumerable.Empty<ProdutoDto>();
                }

                var produtosDto = produtos!.ConverterProdutosParaProdutosDto();
                return produtosDto;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produtos");
                throw;
            }

        }

        public async Task<IEnumerable<ProdutoDto>> ObterProdutosFavoritos()
        {
            try
            {
                var produtos = await _produtoRepository.ObterProdutosFavoritos();

                if (produtos == null)
                {
                    _logger.LogError("Erro ao buscar Produto");
                    return Enumerable.Empty<ProdutoDto>();
                }

                var produtosDto = produtos.ConverterProdutosParaProdutosDto();
                return produtosDto ?? Enumerable.Empty<ProdutoDto>();

            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produto");
                throw;
            }
        }

        public async Task<ProdutoDto> ObterUmProduto(Guid Id)
        {
            try
            {
                var produto = await _produtoRepository.ObterProdutoPorId(Id);
                if (produto == null)
                {
                    _logger.LogError($"Produto com ID: {Id} não encontrado");
                    return null!;
                }

                var produtoDto = produto.ConverterProdutoParaDto();
                return produtoDto;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produto");
                throw;
            }

        }

        public async Task RemoverProduto(Guid Id)
        {
            try
            {
                var produtoExiste = await _produtoRepository.ObterProdutoPorId(Id);

                if (produtoExiste != null)
                {
                    await _produtoRepository.ExcluirProduto(produtoExiste.Id);
                }
            }

            catch (Exception)
            {
                _logger.LogError($"Erro ao excluir Produto");
                throw;
            }
        
        }
    }
}
