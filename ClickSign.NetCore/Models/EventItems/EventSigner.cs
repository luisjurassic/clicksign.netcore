using System;
using System.Collections.Generic;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Evento do assinante.
/// </summary>
public class EventSigner
{
    /// <summary>
    /// Id do assinante.
    /// </summary>
    public Guid Key { get; set; }

    /// <summary>
    /// Nome do assinante.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Número do documento do assinante.
    /// </summary>
    public string Documentation { get; set; }

    /// <summary>
    /// Data de nascimento do assinante.
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    /// Endereço do assinante.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Email do assinante.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Indica se o assinate possui documentação.
    /// </summary>
    public bool HasDocumentation { get; set; }

    /// <summary>
    /// Data de criação do assinante.
    /// </summary>
    [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Creation { get; set; }

    /// <summary>
    /// A que título será realizada a assinatura. Veja <see cref="SignType" />.
    /// </summary>
    [JsonConverter(typeof(SignTypeConverter))]
    [JsonProperty("sign_as")]
    public SignType SignAs { get; set; }

    /// <summary>
    /// Método de autenticação do assinante.
    /// </summary>
    [JsonProperty("auths", ItemConverterType = typeof(AuthTypesConverter))]
    public ICollection<AuthType> Auths { get; set; }

    /// <summary>
    /// Url de assinatura do documento.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        if (HasDocumentation)
            return $"[KEY:{Key}][NAME:{Name}][DOCUMENTATION:{Documentation}][SIGNAS:{SignAs}]";
        return $"[KEY:{Key}][NAME:{Name}][SIGNAS:{SignAs}]";
    }
}