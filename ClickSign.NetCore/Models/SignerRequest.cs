using System;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo para assinar documentos via API.
/// </summary>
public class SignerRequest
{
    /// <summary>
    /// Chave de requisição de assinatura.
    /// </summary>
    [JsonProperty("request_signature_key")]
    public Guid? SignatureKey { get; set; }

    /// <summary>
    /// Codigo de autenticação da requisição
    /// </summary>
    [JsonProperty("secret_hmac_sha256")]
    public string Secret { get; set; }
}