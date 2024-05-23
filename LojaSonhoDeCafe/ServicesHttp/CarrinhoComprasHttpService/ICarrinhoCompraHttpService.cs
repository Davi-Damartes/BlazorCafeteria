using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService
{
    public interface ICarrinhoCompraHttpService
    {
        Task<List<CarrinhoItemDto>> ObterItensCarrinho(string usuarioId);

        Task<CarrinhoItemDto> AdicionaItemCarrinhoDto(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItemDto> DeletaItemDoCarrinho(int id);

        Task LimpaItensCarrinhoDeCompra();

        Task<CarrinhoItemDto> AtualizarQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto atualizaQuantidadeDto);

        //event Action<int> OnCarrinhoCompraChanged;
        //void RaiseEventCarrinhoCompraChanged(int totalQuantidade);
    }
}
