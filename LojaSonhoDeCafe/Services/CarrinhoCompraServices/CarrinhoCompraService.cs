using LojaSonhoDeCafe.Entities;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Carrinho;
using SonhoDeCafe.Server.MapeandoDto;
using SonhoDeCafe.Server.Repositories.Produtos;

namespace LojaSonhoDeCafe.Services.CarrinhoCompraServices
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly ILogger<CarrinhoCompraService> _logger;
        private readonly CarrinhoCompraRepository _carrinhocompraRepository;
        private readonly ProdutoRepository _produtoRepository;

        public CarrinhoCompraService(ILogger<CarrinhoCompraService> logger,
                                    CarrinhoCompraRepository carrinhocompraRepository,
                                    ProdutoRepository produtoRepository)
        {
            _logger = logger;
            _carrinhocompraRepository = carrinhocompraRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<CarrinhoItemDto> AdicionaItemDto(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var itemAdicionado = await _carrinhocompraRepository.AdicionaItem(carrinhoItemAdicionaDto);
                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItemAdicionaDto.ProdutoId);
                if (itemAdicionado == null)
                {
                    _logger.LogError("Erro ao Adicionar Produto");
                }

                var itemAdicionadoDto = itemAdicionado!.ConverterCarrinhoItemParaDto(produto);

                return itemAdicionadoDto;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produtos");
                throw;
            }
        }
        public async Task<List<CarrinhoItemDto>> ObterItens(string usuarioId)
        {

            var carrinhoItens = await _carrinhocompraRepository.ObtemItensDoCarinho(usuarioId);
            if (carrinhoItens == null)
            {
                _logger.LogError("Erro ao buscar item do carrinho");
            }

            var produtoIds = carrinhoItens.Select(item => item.ProdutoId).ToList();
            var produtos = await _produtoRepository.ObterTodosOsProdutos();

            // Converter cada item do carrinho em um DTO
            var carrinhoItemDtos = new List<CarrinhoItemDto>();
            foreach (var carrinhoItem in carrinhoItens)
            {
                var produto = produtos.FirstOrDefault(p => p.Id == carrinhoItem.ProdutoId);
                var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);
                carrinhoItemDtos.Add(carrinhoItemDto);
            }

            return carrinhoItemDtos;

        }

        public async Task<CarrinhoItemDto> AtualizarQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto atualizaQuantidadeDto)
        {
            try
            {
                var carrinhoItem = await _carrinhocompraRepository
                                            .AtualizaQuantidade(id, atualizaQuantidadeDto);

                if (carrinhoItem == null)
                {
                    _logger.LogError("Erro ao Atualizar item do carrinho");
                }

                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItem!.ProdutoId);

                var carrinhoItemDto = carrinhoItem.ConverteCarrinhoItemParaCarrinhoDto(produto);


                return carrinhoItemDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro no {ex.Message}");
                throw;
            }
        }




        public async Task<CarrinhoItemDto> DeletaItem(int id)
        {
            var carrinhoItem = await _carrinhocompraRepository.DeletaItem(id);
            if (carrinhoItem == null)
            {
                _logger.LogError("Erro ao Deletar Produto");
            }
            var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId);

            var carrinhoItemDto = carrinhoItem.ConverterCarrinhoItemParaDto(produto);

            return carrinhoItemDto;

        }





    }
}
