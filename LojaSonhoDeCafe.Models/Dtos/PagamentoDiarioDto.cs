using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class PagamentoDiarioDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "O campo {0} não pode ser nullo!")]
        [Name("Usuario")]
        public string? Usuario { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O campo {0} não pode ser nullo!")]
        [EmailAddress]
        [Name("Email")]
        public string? Email { get; set; }

        [Required]
         [Name("Quantidade de Produtos Vendidos Dia")]   
        public int TotalQuantDiaria { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
         [Name("Produtos vendido no Dia")]
        public decimal TotalPrecoDiaria { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um tipo de pagamento.")]
        [NotNull]
         [Name("Tipo De Pagamento")]    
        public EPagamentoDto EPagamento { get; set; }

        [Required]
         [Name("Hora Do Pagamento")]   
        public DateTime HoraDoPagamento { get; set; } = DateTime.Now;
    }


}
