using System.ComponentModel.DataAnnotations;

namespace Cad_BenefAPI.Models
{
    public class BeneficiarioConsultaCarteiraPorCpfRequest
    {
        [Required]
        public string CodigoUnimed { get; set; }

        [Required]
        public string Cpf { get; set; }


    }
}
