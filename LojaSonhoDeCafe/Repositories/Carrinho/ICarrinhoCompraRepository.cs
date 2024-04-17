using LojaSonhoDeCafe.Entities;
using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Repositories.Carrinho
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(
                    CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItem> AtualizaQuantidade(int id, 
            CarrinhoItemAtualizaQuantidadeDto ca);

        Task<CarrinhoItem> DeletaItem(int id);

        Task<CarrinhoItem> ObtemItemDoCarrinho(int id);

        Task<IEnumerable<CarrinhoItem>> ObtemItensDoCarinho(string usuarioId);
    }
}
