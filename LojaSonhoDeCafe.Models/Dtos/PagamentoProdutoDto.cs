using LojaSonhoDeCafe.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class PagamentoProdutoDto
    {
        [Required]
        public Guid ProdutoId { get; set; }

        [Required]
        public int QuantidadeComprada { get; set; }


        [MaxLength(200)]
        public string? ProdutoNome { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoTotal { get; set; }


    }
}
