using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.CarrinhoCompraServices
{
    public interface ICarrinhoCompraService
    {
        Task<List<CarrinhoItemDto>> ObterItens(string usuarioId);
        Task<CarrinhoItemDto> AdicionaItemDto(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItemDto> DeletaItem (int id);
       
        Task<CarrinhoItemDto> AtualizarQuantidade(int id, 
                                        CarrinhoItemAtualizaQuantidadeDto atualizaQuantidadeDto);
    }
}
