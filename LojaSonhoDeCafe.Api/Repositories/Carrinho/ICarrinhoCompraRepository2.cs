using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Api.Repositories.Carrinho
{
    public interface ICarrinhoCompraRepository2
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItem> AtualizaQuantidade(int id,
            CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);

        Task<CarrinhoItem> DeletaItem(int id);

        Task<bool> LimpaItensDoCarrinho();

        Task<CarrinhoItem> ObtemItemDoCarrinhoPorId(int id);

        Task<IEnumerable<CarrinhoItem>> ObtemItensDoCarinho(string usuarioId);



    }
}
