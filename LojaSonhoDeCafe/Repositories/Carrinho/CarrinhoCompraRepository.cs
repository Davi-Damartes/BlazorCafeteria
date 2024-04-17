using LojaSonhoDeCafe.Data;
using LojaSonhoDeCafe.Entities;
using LojaSonhoDeCafe.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Repositories.Carrinho
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly BancoDeDados _context;

        public CarrinhoCompraRepository(BancoDeDados context)
        {
            _context = context;
        }

        private async Task<bool> CarrinhoItemJaExiste(int carrinhoId, Guid produtoId)
        {
            return await _context.CarrinhoItens
                                 .AnyAsync(c => c.CarrinhoId == carrinhoId
                                                       &&
                                           c.ProdutoId == produtoId);
        }



        public async Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {

            if (await CarrinhoItemJaExiste(
                carrinhoItemAdicionaDto.CarrinhoId,
                carrinhoItemAdicionaDto.ProdutoId) == false)
            {
                var item = await (from produto in _context.Produtos
                                  where produto.Id == carrinhoItemAdicionaDto.ProdutoId
                                  select new CarrinhoItem
                                  {
                                      CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
                                      ProdutoId = produto.Id,
                                      Quantidade = carrinhoItemAdicionaDto.Quantidade,
                                  }).SingleOrDefaultAsync();

                //se o item existe então incluir o item no carrinho
                if (item is not null)
                {
                    var resultado = await _context.CarrinhoItens.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return resultado.Entity;
                }
            }
            return null!;
        }

        public Task<CarrinhoItem> AtualizaQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto ca)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoItem> DeletaItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoItem> ObtemItemDoCarrinho(int id)
        {
            return await (from carrinho in _context.Carrinhos
                          join carrinhoItem in _context.CarrinhoItens
                          on carrinho.Id equals carrinhoItem.CarrinhoId
                          where carrinhoItem.Id == id
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).SingleOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<CarrinhoItem>> ObtemItensDoCarinho(string usuarioId)
        {
            return await (from carrinho in _context.Carrinhos
                          join carrinhoItem in _context.CarrinhoItens
                          on carrinho.Id equals carrinhoItem.CarrinhoId
                          where carrinho.UsuarioId == usuarioId
                          select new CarrinhoItem
                          {
                              Id = carrinhoItem.Id,
                              ProdutoId = carrinhoItem.ProdutoId,
                              Quantidade = carrinhoItem.Quantidade,
                              CarrinhoId = carrinhoItem.CarrinhoId
                          }).ToListAsync();
        }
    }
}
