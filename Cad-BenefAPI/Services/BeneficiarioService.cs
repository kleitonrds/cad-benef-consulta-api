using Cad_BenefAPI.Interfaces;
using Cad_BenefAPI.Models;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Cad_BenefAPI.Services
{
    /// <summary>
    /// Classe responsável por consumir os serviços de consulta do CAD-BENEF
    /// </summary>
    public class BeneficiarioService : IBeneficiarioService
    {
        /// <summary>
        /// Método responsável pela consulta dos beneficiários que foram ativados dentro de um determinado período.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="caminhoCertificado"></param>
        /// <param name="senhaCertificado"></param>
        /// <param name="clientId"></param>
        /// <param name="secretId"></param>
        /// <param name="tokenAccessCode"></param>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
    
        public async Task<BeneficiariosAtivosResponse> ConsultaAtivosPorPeriodo(BeneficiariosAtivosRequest request, string caminhoCertificado, string senhaCertificado, string clientId, string secretId, string tokenAccessCode, string apiUrl)
        {
            var response = new BeneficiariosAtivosResponse();

            try
            {
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12
                };
                handler.ClientCertificates.Add(new X509Certificate2(caminhoCertificado, senhaCertificado));

                using var httpClient = new HttpClient(handler);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAccessCode);
                httpClient.DefaultRequestHeaders.Add("username", clientId);
                httpClient.DefaultRequestHeaders.Add("password", secretId);

                apiUrl = $"{apiUrl}?codigoUnimed={request.CodigoUnimed}&dataInicio={request.DataInicio}&dataFim={request.DataFim}";

                var httpResponse = await httpClient.GetAsync(apiUrl);
                if (httpResponse.IsSuccessStatusCode)
                {
                    response.Dados = await httpResponse.Content.ReadAsStringAsync();


                }
                else
                {
                    response.Erro = await httpResponse.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex)
            {
                response.Erro = ex.Message;
            }


            return response;
        }

        /// <summary>
        /// Metódo responsável por consultar a carteirinha e o código de controle Unimed do Brasil do beneficiário através do envio do código da Unimed e CPF
        /// </summary>
        /// <param name="request"></param>
        /// <param name="caminhoCertificado"></param>
        /// <param name="senhaCertificado"></param>
        /// <param name="clientId"></param>
        /// <param name="secretId"></param>
        /// <param name="tokenAccessCode"></param>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
        public async Task<BeneficiarioConsultaCarteiraPorCpfResponse> ConsultaCarteiraPorCpf(BeneficiarioConsultaCarteiraPorCpfRequest request, string caminhoCertificado, string senhaCertificado, string clientId, string secretId, string tokenAccessCode, string apiUrl)
        {
            var response = new BeneficiarioConsultaCarteiraPorCpfResponse();
            try
            {
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12
                };
                handler.ClientCertificates.Add(new X509Certificate2(caminhoCertificado, senhaCertificado));

                using var httpClient = new HttpClient(handler);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAccessCode);
                httpClient.DefaultRequestHeaders.Add("username", clientId);
                httpClient.DefaultRequestHeaders.Add("password", secretId);

                apiUrl = $"{apiUrl}?codigoUnimed={request.CodigoUnimed}&cpf={request.Cpf}";

                var httpResponse = await httpClient.GetAsync(apiUrl);
                if (httpResponse.IsSuccessStatusCode)
                {
                    response.Dados = await httpResponse.Content.ReadAsStringAsync();


                }
                else
                {
                    response.Erro = await httpResponse.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex)
            {
                response.Erro = ex.Message;
            }


            return response;
        }


        /// <summary>
        /// Metódo responsável por consultar os dados do beneficiário.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="caminhoCertificado"></param>
        /// <param name="senhaCertificado"></param>
        /// <param name="clientId"></param>
        /// <param name="secretId"></param>
        /// <param name="tokenAccessCode"></param>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
        public async Task<BeneficiarioResponse> ConsultaDadosBeneficiario(BeneficiarioRequest request, string caminhoCertificado, string senhaCertificado, string clientId, string secretId, string tokenAccessCode, string apiUrl)
        {
            var response = new BeneficiarioResponse();

            try
            {
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12
                };
                handler.ClientCertificates.Add(new X509Certificate2(caminhoCertificado, senhaCertificado));

                using var httpClient = new HttpClient(handler);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAccessCode);
                httpClient.DefaultRequestHeaders.Add("username", clientId);
                httpClient.DefaultRequestHeaders.Add("password", secretId);

                apiUrl = $"{apiUrl}?codigoUnimed={request.CodigoUnimed}&carteirinhaBeneficiario={request.CarteirinhaBeneficiario}&codigoControleUnimedBrasil={request.CodigoControleUnimedBrasil}";

                var httpResponse = await httpClient.GetAsync(apiUrl);
                if (httpResponse.IsSuccessStatusCode)
                {
                    response.Dados = await httpResponse.Content.ReadAsStringAsync();


                }
                else
                {
                    response.Erro = await httpResponse.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex)
            {
                response.Erro = ex.Message;
            }


            return response;
        }
    }
    
}
