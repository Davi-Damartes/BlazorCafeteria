using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Models.Entity
{
    public class CarrinhoItem
    {
        public int Id { get; set; }

        public int CarrinhoId { get; set; }

        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public int QuantidadeEmEstoque { get; set; }


        public Carrinho? Carrinho { get; set; }
        public Produto? Produto { get; set; }

    }
}
