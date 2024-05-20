using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSonhoDeCafe.Models.Entity
{
    public class RelatorioVendasMensal : BaseEntity
    {
        [Required]
        public int QuantidadeProdutosVendidos { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoTotalVendas { get; set; }

        [Required]
        public int QuantidadeUsuariosUnicos { get; set; }

        public int Mes { get; set; }
        public int Ano { get; set; }

    }

}
