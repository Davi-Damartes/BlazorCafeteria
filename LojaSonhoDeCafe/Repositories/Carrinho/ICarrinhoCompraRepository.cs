﻿
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Repositories.Carrinho
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto);

        Task<CarrinhoItem> AtualizaQuantidade(int id, 
            CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto);

        Task<CarrinhoItem> DeletaItem(int id);

        Task LimpaItensDoCarrinho();

        Task<CarrinhoItem> ObtemItemDoCarrinho(int id);

        Task<IEnumerable<CarrinhoItem>> ObtemItensDoCarinho(string usuarioId);

        

    }
}
