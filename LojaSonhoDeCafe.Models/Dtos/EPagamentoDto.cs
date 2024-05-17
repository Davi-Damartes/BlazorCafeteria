using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.Dtos
{
    public enum EPagamentoDto
    {
        visa = 1,
        mastercard = 2,
        paypal = 3,
        boleto = 4,
    }
}