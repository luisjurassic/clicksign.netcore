using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClickSign.NetCore.Exceptions;

namespace ClickSign.NetCore.Security;

/// <summary>
/// Classe responsável pela validação de assinatura de dados vindos de uma requisição Webhook do serviço.
/// </summary>
public static class HmacSignatureValidator
{
    /// <summary>
    /// Método que efetua a validação do conteúdo da mensagem de acordo com a assinatura Hmac.
    /// </summary>
    /// <param name="data">dados da requisição à serem validados.</param>
    /// <param name="hmacKey">Chave HMAC para validação.</param>
    public static async Task Validate(WebhookData data, string hmacKey)
    {
        if (string.IsNullOrEmpty(hmacKey)) throw new ArgumentNullException("A chave HMAC não foi informada!");

        using var stream = new StreamReader(data.Body);
        var bodyString = await stream.ReadToEndAsync();
        var bodySha256 = GenerateHmacSignature(bodyString, hmacKey);
        var result = !string.IsNullOrEmpty(data.Signature) && data.Signature.Equals(bodySha256);
        if (!result)
            throw new WebhookUnauthorizedException("Assinatura de requisição não validada!");
    }

    /// <summary>
    /// Método que efetua a validação do conteúdo da mensagem de acordo com a assinatura Hmac.
    /// </summary>
    /// <param name="body">Conteúdo à ser validado.</param>
    /// <param name="requestHmac">HMAC enviado juntamente com o conteúdo.</param>
    /// <param name="hmacKey">Chave HMAC para validação.</param>
    public static void Validate(string body, string requestHmac, string hmacKey)
    {
        if (string.IsNullOrEmpty(hmacKey))
            throw new ArgumentNullException("A chave HMAC não foi informada!");

        var bodySha256 = GenerateHmacSignature(body, hmacKey);
        var result = !string.IsNullOrEmpty(requestHmac) && requestHmac.Equals(hmacKey);
        if (!result)
            throw new WebhookUnauthorizedException("Assinatura de requisição não validada!");
    }

    /// <summary>
    /// Método que faz a geração do valor Hmac de um conjunto de dados.
    /// </summary>
    /// <param name="value">Dados à terem seu valor Hmac gerado.</param>
    /// <param name="key">Chave de criação.</param>
    /// <returns>Assinatura Hmac gerada.</returns>
    public static string GenerateHmacSignature(string value, string key)
    {
        var encoding = new UTF8Encoding();
        var textBytes = encoding.GetBytes(value);
        var keyBytes = encoding.GetBytes(key);
        byte[] hashBytes;
        using (var hash = new HMACSHA256(keyBytes))
        {
            hashBytes = hash.ComputeHash(textBytes);
        }

        var result = BitConverter.ToString(hashBytes);
        return result.Replace("-", string.Empty).ToLower();
    }
}