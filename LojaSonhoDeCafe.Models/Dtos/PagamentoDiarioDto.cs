using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class PagamentoDiarioDto
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
        public EPagamentoDto EPagamento { get; set; }

        [Required]
        public DateTime HoraDoPagamento { get; } = DateTime.Now;
    }


}
