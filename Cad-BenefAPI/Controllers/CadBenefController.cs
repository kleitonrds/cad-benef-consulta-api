using Cad_BenefAPI.Interfaces;
using Cad_BenefAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cad_BenefAPI.Controllers;

[ApiController]
[Route("[controller]")]
///
public class CadBenefController : ControllerBase
{
    private readonly IBeneficiarioService _beneficiarioService;

    public CadBenefController(IBeneficiarioService beneficiarioService)
    {
        _beneficiarioService = beneficiarioService;
    }

    /// <summary>
    /// Consulta os dados do beneficiário.
    /// </summary>
    /// <param name="request">Dados do Beneficiário para a consulta (codigoUnimed, codigoCarteirinha e codigoControleUnimedBrasil). </param>
    /// <param name="caminhoCertificado">Caminho do certificado usado na homologação do Cad-Benef.</param>
    /// <param name="senhaCertificado">Senha do certificado usado no Cad-Benef.</param>
    /// <param name="clientId">CLIENT-ID fornecido pela Unimed Brasil.</param>
    /// <param name="secretId">SECRET-ID fornecido pela Unimed Brasil.</param>
    /// <param name="tokenAccessCode">Token de acesso utilizado na homologação do Cad-Benef</param>
    /// <param name="apiUrl">Endereço do endpoint que vai consumir o serviço de consulta de dados</param>
    /// <returns>Dados do beneficiário no formato JSON ou mensagem de erro.</returns>
    [HttpGet("consulta-dados-beneficiario")]
    public async Task<IActionResult> ConsultaDadosBeneficiario([FromQuery] BeneficiarioRequest request,
                                                                string caminhoCertificado,
                                                                string senhaCertificado,
                                                                string clientId,
                                                                string secretId,
                                                                string tokenAccessCode,
                                                                string apiUrl)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.CodigoUnimed) || string.IsNullOrWhiteSpace(request.CarteirinhaBeneficiario) || string.IsNullOrWhiteSpace(request.CodigoControleUnimedBrasil))
        {
            return BadRequest("Parâmetros inválidos.");
        }

        var result = await _beneficiarioService.ConsultaDadosBeneficiario(request, caminhoCertificado, senhaCertificado, clientId, secretId, tokenAccessCode, apiUrl);

        if (!string.IsNullOrWhiteSpace(result.Erro))
        {
            return StatusCode(500, result.Erro);
        }

        return Ok(result.Dados);
    }

    /// <summary>
    /// Consulta os beneficiários que foram ativados dentro de um determinado período.
    /// </summary>
    /// <param name="request">Dados do Beneficiário para a consulta (codigoUnimed, codigoCarteirinha e codigoControleUnimedBrasil). </param>
    /// <param name="caminhoCertificado">Caminho do certificado usado na homologação do Cad-Benef.</param>
    /// <param name="senhaCertificado">Senha do certificado usado no Cad-Benef.</param>
    /// <param name="clientId">CLIENT-ID fornecido pela Unimed Brasil.</param>
    /// <param name="secretId">SECRET-ID fornecido pela Unimed Brasil.</param>
    /// <param name="tokenAccessCode">Token de acesso utilizado na homologação do Cad-Benef</param>
    /// <param name="apiUrl">Endereço do endpoint que vai consumir o serviço de consulta de dados</param>
    /// <returns>Dados do beneficiário no formato JSON ou mensagem de erro.</returns>
    [HttpGet("consulta-ativos-por-periodo")]

    public async Task<IActionResult> ConsultaAtivosPorPeriodo([FromQuery] BeneficiariosAtivosRequest request,
                                                               string caminhoCertificado,
                                                               string senhaCertificado,
                                                               string clientId,
                                                               string secretId,
                                                               string tokenAccessCode,
                                                               string apiUrl)
    {

        if (request == null || string.IsNullOrWhiteSpace(request.CodigoUnimed) || string.IsNullOrWhiteSpace(request.DataInicio) || string.IsNullOrWhiteSpace(request.DataFim))
        {
            return BadRequest("Parâmetros inválidos.");
        }

        var result = await _beneficiarioService.ConsultaAtivosPorPeriodo(request, caminhoCertificado, senhaCertificado, clientId, secretId, tokenAccessCode, apiUrl);

        if (!string.IsNullOrWhiteSpace(result.Erro))
        {
            return StatusCode(500, result.Erro);
        }

        return Ok(result.Dados);

    }
    /// <summary>
    ///  Consulta a carteirinha e o código de controle Unimed do Brasil do beneficiário.
    /// </summary>
    /// <param name="request">Dados do Beneficiário para a consulta (codigoUnimed, codigoCarteirinha e codigoControleUnimedBrasil). </param>
    /// <param name="caminhoCertificado">Caminho do certificado usado na homologação do Cad-Benef.</param>
    /// <param name="senhaCertificado">Senha do certificado usado no Cad-Benef.</param>
    /// <param name="clientId">CLIENT-ID fornecido pela Unimed Brasil.</param>
    /// <param name="secretId">SECRET-ID fornecido pela Unimed Brasil.</param>
    /// <param name="tokenAccessCode">Token de acesso utilizado na homologação do Cad-Benef</param>
    /// <param name="apiUrl">Endereço do endpoint que vai consumir o serviço de consulta de dados</param>
    /// <returns>Dados do beneficiário no formato JSON ou mensagem de erro.</returns>

    [HttpGet("consulta-carteira-por-cpf")]
    public async Task<IActionResult> ConsultaCarteiraPorCpf([FromQuery] BeneficiarioConsultaCarteiraPorCpfRequest request,
                                                             string caminhoCertificado,
                                                             string senhaCertificado,
                                                             string clientId,
                                                             string secretId,
                                                             string tokenAccessCode,
                                                             string apiUrl)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.CodigoUnimed) || string.IsNullOrWhiteSpace(request.Cpf))
        {
            return BadRequest("Parâmetros inválidos.");
        }

        var result = await _beneficiarioService.ConsultaCarteiraPorCpf(request, caminhoCertificado, senhaCertificado, clientId, secretId, tokenAccessCode, apiUrl);

        if (!string.IsNullOrWhiteSpace(result.Erro))
        {
            return StatusCode(500, result.Erro);
        }

        return Ok(result.Dados);

    }





}

