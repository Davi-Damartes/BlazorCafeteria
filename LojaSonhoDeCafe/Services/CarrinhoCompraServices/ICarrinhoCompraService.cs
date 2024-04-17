using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.CarrinhoCompraServices
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDto>> obterItens(string usuarioId);
        Task<CarrinhoItemDto> AdicionaItemDto(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);
    }
}
