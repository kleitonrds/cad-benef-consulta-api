using System.ComponentModel.DataAnnotations;

namespace Cad_BenefAPI.Models
{
    public class BeneficiariosAtivosRequest
    {
        [Required]
        public string? CodigoUnimed { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$",ErrorMessage = "A data início deve estar no formato AAAA-MM-DD.")]
        public string? DataInicio { get; set; }

        [Required(ErrorMessage = "A data fim é obrigatória.")]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$", ErrorMessage = "A data fim deve estar no formato AAAA-MM-DD.")]
        public string? DataFim { get; set; }
    }
}
