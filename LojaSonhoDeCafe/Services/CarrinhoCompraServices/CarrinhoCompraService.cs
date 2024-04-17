using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Carrinho;
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
                if (itemAdicionado == null)
                {
                    _logger.LogError("Erro ao buscar Produto");
                }
                var produto = await _produtoRepository.ObterProdutoPorId(carrinhoItemAdicionaDto.ProdutoId);

                var itemAdicionadoDto = itemAdicionado!.ConverterCarrinhoItemParaDto(produto);

                return itemAdicionadoDto;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produtos");
                throw;
            }
        }




        public async Task<List<CarrinhoItemDto>> obterItens(string usuarioId)
        {
            var carrinhoItens = await _carrinhocompraRepository.ObtemItensDoCarinho(usuarioId);
            if (carrinhoItens == null)
            {
                _logger.LogError("Erro ao buscar item do carrinho");
            }

            var carrinhoItensDto = new List<CarrinhoItemDto>();
            foreach (var carrinhoItem in carrinhoItens!)
            {

                carrinhoItensDto.Add(carrinhoItem.ToDto());
            }

            return carrinhoItensDto;

        }

    }
}
