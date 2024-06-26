using System;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo de requisição de adição de um assinante à um documento.
/// </summary>
public class AddSignerRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public AddSignerRequest()
    {
        SignAs = SignType.Sign;
        Group = 0;
    }

    /// <summary>
    /// Chave única do documento dentro da Clicksign.
    /// </summary>
    [JsonProperty("document_key")]
    public Guid? DocumentKey { get; set; }

    /// <summary>
    /// Chave única do signatário dentro da Clicksign.
    /// </summary>
    [JsonProperty("signer_key")]
    public Guid? SignerKey { get; set; }

    /// <summary>
    /// A que título será realizada a assinatura. Veja <see cref="SignType" />.
    /// </summary>
    [JsonConverter(typeof(SignTypeConverter))]
    [JsonProperty("sign_as")]
    public SignType SignAs { get; set; }

    /// <summary>
    /// Determina o grupo que o signatário deve ser vinculado.
    /// O parâmetro funciona com sequence_enabled como true.
    /// </summary>
    [JsonProperty("group")]
    public int? Group { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[DOCUMENT:{DocumentKey}][SIGNER:{SignerKey}][AS:{SignAs}][GROUP:{Group}]";
    }
}