namespace LojaSonhoDeCafe.Models.Dtos
{
    public class CarrinhoItemDto
    {
        public int Id { get; set; }

        public int CarrinhoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }


        public string? ProdutoNome { get; set; }
        public string? ProdutoDescricao { get; set; }
        public string? ProdutoFotoUrl { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoTotal { get; set; }

        public int QuantidadeEmEstoque { get; set; }

    }
}
