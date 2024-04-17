using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public class CarrinhoItemAdicionaDto
    {
        [Required]
        public int CarrinhoId { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }


    }
}
