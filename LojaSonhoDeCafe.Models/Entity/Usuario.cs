using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Entity
{
    public class Usuario : BaseEntity
    {

        [MaxLength(100)]
        public string NomeUsuario { get; set; } = string.Empty;

        public Carrinho? Carrinho { get; set; }
    }
}
