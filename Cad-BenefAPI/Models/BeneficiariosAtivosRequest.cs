using System.ComponentModel.DataAnnotations;

namespace Cad_BenefAPI.Models
{
    public class BeneficiariosAtivosRequest
    {
        [Required]
        public string? CodigoUnimed { get; set; }

        [Required]
        public string? DataInicio { get; set; }

        [Required]
        public string? DataFim { get; set; }
    }
}
