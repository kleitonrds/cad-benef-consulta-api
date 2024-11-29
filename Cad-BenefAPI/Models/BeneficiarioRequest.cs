using System.ComponentModel.DataAnnotations;

namespace Cad_BenefAPI.Models
{
    public class BeneficiarioRequest
    {
        [Required]
        public string? CodigoUnimed { get; set; }

        [Required]
        public string? CarteirinhaBeneficiario { get; set; }

        [Required]
        public string? CodigoControleUnimedBrasil { get; set; }

      
    }
}
