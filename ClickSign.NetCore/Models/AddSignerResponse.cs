using System;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo de resposta de adição de um assinante à um documento.
/// </summary>
public class AddSignerResponse
{
    /// <summary>
    /// Chave da associação do assinante ao documento.
    /// </summary>
    [JsonProperty("key")]
    public Guid Key { get; set; }

    /// <summary>
    /// Chave de requisição de assinatura.
    /// </summary>
    [JsonProperty("request_signature_key")]
    public Guid? SignatureKey { get; set; }

    /// <summary>
    /// Chave de do documento.
    /// </summary>
    [JsonProperty("document_key")]
    public Guid? DocumentKey { get; set; }

    /// <summary>
    /// Chave do assinante.
    /// </summary>
    [JsonProperty("signer_key")]
    public Guid? SignerKey { get; set; }

    /// <summary>
    /// Atributo que define o tipo de assinatura que o assinante fará ao documento. <see cref="SignType" />
    /// </summary>
    [JsonConverter(typeof(SignTypeConverter))]
    [JsonProperty("sign_as")]
    public SignType SignAs { get; set; }

    /// <summary>
    /// Data de criação da associação de assinatura.
    /// </summary>
    [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Created { get; set; }

    /// <summary>
    /// Data de atualização da associação de assinatura.
    /// </summary>
    [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Updated { get; set; }

    /// <summary>
    /// Url de assinatura do documento.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// Determina o grupo que o signatário deve ser vinculado.
    /// </summary>
    [JsonProperty("group")]
    public int Group { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[KEY:{Key}][SIGNATURE.KEY:{SignatureKey}][DOCUMENT.KEY:{DocumentKey}][SIGNAS:{SignAs}][CREATED:{Created.ToString("yyyy-MM-ddTHH:mm:ss")}][GROUP:{Group}]";
    }
}