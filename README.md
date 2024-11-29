# Cad Benef Consulta API

Bem-vindo ao repositório **Cad Benef Consulta API**! Este projeto fornece uma interface para consultar informações de beneficiários, integrada ao sistema Unimed Brasil.

---

## 🚀 Como Usar

Antes de consumir os serviços desta API, **certifique-se de que todos os parâmetros necessários estejam configurados corretamente**. Abaixo, seguem as instruções detalhadas.

### 🛠️ Pré-requisitos

1. **Certificado Digital A1**:
   - O caminho da rede onde está armazenado o certificado.
   - A senha do certificado fornecido pela Unimed.

2. **Credenciais de Autenticação**:
   - **Client ID** e **Secret ID** fornecidos pela Unimed Brasil para cada unidade Unimed.

3. **Token de Acesso**:
   - O token deve ser obtido através do endpoint:
     ```
     https://ua-gateway-hml.unimed.coop.br/oauth/v1/access-token
     ```

4. **URL do Endpoint**:
   - Consulte a documentação oficial fornecida pela Unimed Brasil para obter a URL do serviço desejado.

---

### 🧩 Estrutura de Configuração

Crie um arquivo de configuração ou insira essas informações no local apropriado de sua aplicação para garantir que os dados sejam passados corretamente para a API.

#### Exemplo de Configuração:

```json
{
  "CertificadoDigital": {
    "Caminho": "\\\\caminho\\para\\certificado.pfx",
    "Senha": "sua-senha"
  },
  "CredenciaisUnimed": {
    "ClientId": "seu-client-id",
    "SecretId": "seu-secret-id"
  },
  "Token": "token-de-acesso-gerado",
  "EndpointURL": "https://url-do-servico.unimed.com.br/api"
}

