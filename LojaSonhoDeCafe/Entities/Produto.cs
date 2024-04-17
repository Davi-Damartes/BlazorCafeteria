using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSonhoDeCafe.Entities
{
    public class Produto : BaseEntity
    {
        [MaxLength(100)]
        public string? Nome { get; set; }

        [MaxLength(200)]
        public string? Descricao { get; set; }
    

        [MaxLength(200)]
        public string? FotoUrl { get; set; }


        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        public int QuantidadeEmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public ICollection<CarrinhoItem> Itens { get; set; }
           = new List<CarrinhoItem>();

    }
}
