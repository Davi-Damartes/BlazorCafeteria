using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Entity
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Nome { get; set; }

        public string? IconeCss { get; set; }

        public Collection<Produto> Produtos { get; set; } = new Collection<Produto>();

    }
}
