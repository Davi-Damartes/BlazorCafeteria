using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Api.Repositories.Carrinho
{
    public interface ICarrinhoCompraRepositoryApi

    {
        Task<CarrinhoItem> ObtemItemDoCarrinhoPorId(int id);

        Task<IEnumerable<CarrinhoItem>> ObtemItensDoCarinho(string usuarioId);

        Task<CarrinhoItem> AtualizaQuantidade(int id,
            CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);


        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);


        Task<CarrinhoItem> DeletaItem(int id);

        Task<bool> LimpaItensDoCarrinho();



    }
}
