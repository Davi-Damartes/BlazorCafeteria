using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Entity
{
    public class PagamentoProduto : BaseEntity
    {
        [Required]
        public Guid ProdutoId { get; set; }

        [MaxLength(200)]
        public string? ProdutoNome { get; set; }

        [Required]
        public int QuantidadeComprada { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoTotal { get; set; }

        public Guid PagamentoDiarioId { get; set; }
        public PagamentoDiario? PagamentoDiario { get; set; }


    }
}
