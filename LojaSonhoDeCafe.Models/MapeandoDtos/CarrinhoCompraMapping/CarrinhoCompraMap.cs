using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Models.MapeandoDtos.CarrinhoCompraMapping
{
    public static class CarrinhoCompraMap
    {
        public static CarrinhoItemDto ConverterCarrinhoItemProdParaCarrinhoItemDto(this CarrinhoItem carrinhoItem,
                                            Produto produto)
        {
            return new CarrinhoItemDto
            {
                Id = carrinhoItem.Id,
                ProdutoId = carrinhoItem.ProdutoId,
                ProdutoNome = produto.Nome,
                ProdutoDescricao = produto.Descricao,
                ProdutoFotoUrl = produto.FotoUrl,
                Preco = produto.Preco,
                CarrinhoId = carrinhoItem.CarrinhoId,
                Quantidade = carrinhoItem.Quantidade, 
                
                PrecoTotal = produto.Preco * carrinhoItem.Quantidade
            };
        }

        public static CarrinhoItemDto ConverteCarrinhoItemParaCarrinhoDto(this CarrinhoItem carrinhoItem,
                                                                          Produto produto)
        {
            return new CarrinhoItemDto
            {
                Id = carrinhoItem.Id,
                CarrinhoId = carrinhoItem.CarrinhoId,
                ProdutoId = carrinhoItem.ProdutoId,
                Quantidade = carrinhoItem.Quantidade,
                ProdutoNome = produto?.Nome,
                ProdutoDescricao = produto?.Descricao,
                ProdutoFotoUrl = produto?.FotoUrl,
                Preco = produto!.Preco,
                PrecoTotal = (produto?.Preco ?? 0) * carrinhoItem.Quantidade
            };
        }


        public static IEnumerable<CarrinhoItemDto> ConverterCarrinhoItensParaCarrinhoItensDto(
        this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.ProdutoId equals produto.Id
                    select new CarrinhoItemDto
                    {
                        Id = carrinhoItem.Id,
                        ProdutoId = carrinhoItem.ProdutoId,
                        ProdutoNome = produto.Nome,
                        ProdutoDescricao = produto.Descricao,
                        ProdutoFotoUrl = produto.FotoUrl,
                        Preco = produto.Preco,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        Quantidade = carrinhoItem.Quantidade,
                        QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                        PrecoTotal = produto.Preco * carrinhoItem.Quantidade
                    }).ToList();
        }


      
    }
}
