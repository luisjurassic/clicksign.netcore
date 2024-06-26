using System;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo com os dados de uma assinantura.
/// </summary>
public class Signature
{
    /// <summary>
    /// Nome do assinante.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Email do assinante.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Data de nascimento do assinante.
    /// </summary>
    [JsonProperty("birthday", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Birthday { get; set; }

    /// <summary>
    /// Número do documento do assinante.
    /// </summary>
    [JsonProperty("documentation")]
    public string Documentation { get; set; }

    /// <summary>
    /// Endereço IP do assinante.
    /// </summary>
    [JsonProperty("ip_address")]
    public string IpAddress { get; set; }

    /// <summary>
    /// Data de assinatura.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("signed_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime SignedAt { get; set; }

    /// <summary>
    /// A que título será realizada a assinatura. Veja <see cref="SignType" />.
    /// </summary>
    [JsonConverter(typeof(SignTypeConverter))]
    [JsonProperty("sign_as")]
    public SignType SignAs { get; set; }

    /// <summary>
    /// Dados de validação do assinante.
    /// </summary>
    [JsonProperty("validation")]
    public SignatureValidation Validation { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[NAME:{Name}][DOCUMENTATION:{Documentation}][IP:{IpAddress}][SIGN.AS:{SignAs}][SIGNED.AT:{SignedAt}][STATUS:{Validation?.Status}]";
    }
}