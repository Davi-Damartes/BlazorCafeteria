using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }



        [Required(ErrorMessage = "O campo foto é obrigatório!!!")]
        public string? FotoUrl { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório!!!")]

        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!!")]
        [Range(1, 150, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        public int QuantidadeEmEstoque { get; set; }

        public bool IsFavorito { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!!")]
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }

    }
}
