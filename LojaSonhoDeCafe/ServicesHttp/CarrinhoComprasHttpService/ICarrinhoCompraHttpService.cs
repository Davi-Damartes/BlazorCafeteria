using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService
{
    public interface ICarrinhoCompraHttpService
    {
        Task<List<CarrinhoItemDto>> ObterItensCarrinho(string usuarioId);

        Task<CarrinhoItemDto> AtualizarQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto atualizaQuantidadeDto);

        Task<CarrinhoItemDto> AdicionaItemCarrinhoDto(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItemDto> DeletaItemDoCarrinho(int id);

        Task LimpaItensCarrinhoDeCompra();


        //event Action<int> OnCarrinhoCompraChanged;
        //void RaiseEventCarrinhoCompraChanged(int totalQuantidade);
    }
}
