using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Api.Repositories.Carrinho
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository2
    {
        private readonly BancoDeDado _context;

        public CarrinhoCompraRepository(BancoDeDado context)
        {
            _context = context;
        }

        private async Task<bool> CarrinhoItemJaExiste(int carrinhoId, Guid produtoId)
        {
            return await _context.CarrinhoItens.AnyAsync(c => c.CarrinhoId == carrinhoId &&
                                                              c.ProdutoId == produtoId);
        }
        private async Task<CarrinhoItem> CarrinhoExistenteAttQuantidade(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            var carrinhoItemExistente = await _context.CarrinhoItens
                   .FirstOrDefaultAsync(c =>
                       c.CarrinhoId == carrinhoItemAdicionaDto.CarrinhoId &&
                       c.ProdutoId == carrinhoItemAdicionaDto.ProdutoId);

            carrinhoItemExistente!.Quantidade += carrinhoItemAdicionaDto.Quantidade;
            await _context.SaveChangesAsync();

            return carrinhoItemExistente;
        }

        //public async Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        //{
        //    if (await CarrinhoItemJaExiste(carrinhoItemAdicionaDto.CarrinhoId,
        //        carrinhoItemAdicionaDto.ProdutoId) == false)
        //    {
        //        //verifica se o produto existe 
        //        //cria um novo item no carrinho
        //        var itemDoCarrinho = await (from produto in _context.Produtos
        //                          where produto.Id == carrinhoItemAdicionaDto.ProdutoId
        //                          select new CarrinhoItem
        //                          {
        //                              CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
        //                              ProdutoId = produto.Id,
        //                              Quantidade = carrinhoItemAdicionaDto.Quantidade
        //                          }).SingleOrDefaultAsync();

        //        //se o item existe então incluir o item no carrinho.
        //        if (itemDoCarrinho is not null)
        //        {
        //            var resultado = await _context.CarrinhoItens.AddAsync(itemDoCarrinho);
        //            await _context.SaveChangesAsync();
        //            return resultado.Entity;
        //        }
        //    }
        //    return null!;
        //}

        public async Task<CarrinhoItem> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            if (await CarrinhoItemJaExiste(carrinhoItemAdicionaDto.CarrinhoId, carrinhoItemAdicionaDto.ProdutoId))
            {
                var carrinhoItemExistente = await CarrinhoExistenteAttQuantidade(carrinhoItemAdicionaDto);

                return carrinhoItemExistente;
            }
            else
            {
                // Se o item não existe no carrinho, crie um novo item
                var item = await (from produto in _context.Produtos
                                  where produto.Id == carrinhoItemAdicionaDto.ProdutoId
                                  select new CarrinhoItem
                                  {
                                      CarrinhoId = carrinhoItemAdicionaDto.CarrinhoId,
                                      ProdutoId = produto.Id,
                                      Quantidade = carrinhoItemAdicionaDto.Quantidade
                                  }).SingleOrDefaultAsync();

                if (item is not null)
                {
                    var resultado = await _context.CarrinhoItens.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return resultado.Entity;
                }
            }

            return null!;
        }


        public async Task<CarrinhoItem> AtualizaQuantidade(int id,
                                        CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            var carrinhoItem = await _context.CarrinhoItens.FindAsync(id);

            if (carrinhoItem is not null)
            {
                carrinhoItem.Quantidade = carrinhoItemAtualizaQuantidadeDto.Quantidade;
                await _context.SaveChangesAsync();
                return carrinhoItem;
            }

            return null!;

        }


        public async Task<Usuario> ObterUsuario(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(i => i.Id == id) ?? null!;

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


        public async Task<CarrinhoItem> DeletaItem(int id)
        {
            var item = await _context.CarrinhoItens.FindAsync(id);

            if (item is not null)
            {

                _context.CarrinhoItens.Remove(item);
                await _context.SaveChangesAsync();
            }

            return item!;

        }

        public async Task LimpaItensDoCarrinho()
        {
            var itensDoCarrinho = await _context.CarrinhoItens.ToListAsync();

            _context.CarrinhoItens.RemoveRange(itensDoCarrinho);
            await _context.SaveChangesAsync();
        }
    }
}
