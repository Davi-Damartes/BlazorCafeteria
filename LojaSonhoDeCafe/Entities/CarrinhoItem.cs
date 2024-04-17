
using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Entities
{
    public class CarrinhoItem
    {
        public int Id { get; set; }

        public int CarrinhoId { get; set; }

        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }


        public Carrinho? Carrinho { get; set; }
        public Produto? Produto { get; set; }

        public CarrinhoItemDto ToDto( )
        {
            var carrinhoItemDto = new CarrinhoItemDto
            {
                Id = this.Id,
                CarrinhoId = this.CarrinhoId,
                ProdutoId = this.ProdutoId,
                Quantidade = this.Quantidade,

                ProdutoNome = this.Produto?.Nome,
                ProdutoDescricao = this.Produto?.Descricao,
                ProdutoFotoUrl = this.Produto?.FotoUrl,
                Preco = this.Produto?.Preco ?? 0,
                PrecoTotal = (this.Produto?.Preco ?? 0) * this.Quantidade  
            };

            return carrinhoItemDto;
        }
    }
}
