using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class PagamentoDiarioDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "O campo {0} não pode ser nullo!")]
        public string? Usuario { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O campo {0} não pode ser nullo!")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public int TotalQuantDiaria { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrecoDiaria { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um tipo de pagamento.")]
        [NotNull]
        public EPagamentoDto EPagamento { get; set; }

        [Required]
        public DateTime HoraDoPagamento { get; set; } = DateTime.Now;
    }


}
