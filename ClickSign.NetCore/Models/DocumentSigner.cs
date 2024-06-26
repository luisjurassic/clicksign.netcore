using System;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo que representa um assinante de um documento.
/// </summary>
public class DocumentSigner : Signer
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public DocumentSigner()
    {
        SignAs = SignType.Sign;
        Delivery = DeliveryType.Email;
    }

    /// <summary>
    /// Id da associação do assinante ao documento.
    /// </summary>
    [JsonProperty("list_key")]
    public Guid? ListKey { get; set; }

    /// <summary>
    /// Id da requisição de assinatura.
    /// </summary>
    [JsonProperty("request_signature_key")]
    public Guid? RequestSignatureKey { get; set; }

    /// <summary>
    /// Tipo de assinatura do assinante ao documento. Veja <see cref="SignType" />.
    /// </summary>
    [JsonConverter(typeof(SignTypeConverter))]
    [JsonProperty("sign_as")]
    public SignType SignAs { get; set; }

    /// <summary>
    /// Tipo de envio de notificação de assinatura ao assinante.
    /// </summary>
    [JsonConverter(typeof(DeliveryTypeConverter))]
    [JsonProperty("delivery")]
    public DeliveryType Delivery { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return HasDocumentation ? $"[KEY:{Key}][NAME:{Name}][DOCUMENT:{Documentation}][SIGNAS:{SignAs}]" : $"[KEY:{Key}][NAME:{Name}][SIGNAS:{SignAs}]";
    }
}