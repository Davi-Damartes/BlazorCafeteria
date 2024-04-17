namespace LojaSonhoDeCafe.Models.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }


        public string? Descricao { get; set; }

        public string? FotoUrl { get; set; }

        public decimal Preco { get; set; }

        public int QuantidadeEmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }

    }
}
