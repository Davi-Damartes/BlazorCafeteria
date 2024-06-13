using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!!!")]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório!!!")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }


        [Required(ErrorMessage = "O campo Foto é obrigatório!!!")]
        public string? FotoUrl { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório!!!")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo Quantidade em estoque é obrigatório!!!")]
        [Range(1, 150, ErrorMessage = "O campo Quantidade em estoque deve estar entre {1} e {2}.")]
        public int QuantidadeEmEstoque { get; set; }

        public bool IsFavorito { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!!")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo Categoria é obrigatório!!!")]
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }

    }
}
