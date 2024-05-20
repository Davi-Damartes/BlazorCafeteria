using LojaSonhoDeCafe.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSonhoDeCafe.Models.Entity
{
    public class PagamentoDiario : BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public string? Usuario { get; set; }

        [MaxLength(100)]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public int TotalQuantDiaria { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrecoDiaria { get; set; }

        [Required]
        public ETipoPagamento EPagamento { get; set; }

        [Required]
        public DateTime HoraDoPagamento { get; set; } = DateTime.Now;


    }
}
