using Cad_BenefAPI.Models;

namespace Cad_BenefAPI.Interfaces
{  


    public interface IBeneficiarioService
    {
        Task<BeneficiarioResponse> ConsultaDadosBeneficiario(BeneficiarioRequest request,
                                                             string caminhoCertificado,
                                                             string senhaCertificado,
                                                             string clientId,
                                                             string secretId,
                                                             string tokenAccessCode,
                                                             string apiUrl);
        Task<BeneficiariosAtivosResponse> ConsultaAtivosPorPeriodo(BeneficiariosAtivosRequest request,
                                                                   string caminhoCertificado,
                                                                   string senhaCertificado,
                                                                   string clientId,
                                                                   string secretId,
                                                                   string tokenAccessCode,
                                                                   string apiUrl);
        Task<BeneficiarioConsultaCarteiraPorCpfResponse> ConsultaCarteiraPorCpf(BeneficiarioConsultaCarteiraPorCpfRequest request,
                                                                                string caminhoCertificado,
                                                                                string senhaCertificado,
                                                                                string clientId,
                                                                                string secretId,
                                                                                string tokenAccessCode,
                                                                                string apiUrl);
            
    }
}
