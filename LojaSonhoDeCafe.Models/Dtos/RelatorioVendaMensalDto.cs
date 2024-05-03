
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class RelatorioVendaMensalDto
    {
        [Required]
        public int QuantidadeProdutosVendidos { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoTotalVendas { get; set; }

        [Required]
        public int QuantidadeUsuariosUnicos { get; set; }

        [MaybeNull]
        public int Mes { get; set; }
        [MaybeNull]
        public int Ano { get; set; }
    }
}
