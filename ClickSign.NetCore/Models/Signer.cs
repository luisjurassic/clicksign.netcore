using System;
using System.Collections.Generic;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo com os dados de um assinante.
/// </summary>
public class Signer
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public Signer()
    {
        Auths = new List<AuthType> { AuthType.Email };
    }

    /// <summary>
    /// Chave do signatário. Essa chave é utilizada no Widget Embedded e na requisição para Remover Signatários.
    /// </summary>
    [JsonProperty("key")]
    public Guid Key { get; set; }

    /// <summary>
    /// Data de criação do signatário no documento.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Created { get; set; }

    /// <summary>
    /// Data de atualização do signatário no documento.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Updated { get; set; }

    /// <summary>
    /// Email do signatário que deverá assinar o documento.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Nome completo do signatário.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Não solicita os campos CPF e data de nascimento do signatário no momento da assinatura. Útil para signatários que
    /// não possuem CPF.
    /// </summary>
    [JsonProperty("has_documentation")]
    public bool HasDocumentation { get; set; }

    /// <summary>
    /// CPF do signatário.
    /// </summary>
    [JsonProperty("documentation")]
    public string Documentation { get; set; }

    /// <summary>
    /// Data de nascimento do signatário.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
    [JsonProperty("birthday", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Birthday { get; set; }

    /// <summary>
    /// Número de telefone para o envio do SMS.
    /// </summary>
    [JsonProperty("phone_number")]
    public string Phone { get; set; }

    /// <summary>
    /// Tipo de autenticação para realizar assinatura.
    /// </summary>
    [JsonProperty("auths", ItemConverterType = typeof(AuthTypesConverter))]
    public ICollection<AuthType> Auths { get; set; }

    /// <summary>
    /// Tipo de autenticação para realizar assinatura.
    /// </summary>
    [JsonProperty("signature")]
    public Signature Signature { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return HasDocumentation ? $"[KEY:{Key}][NAME:{Name}][DOCUMENT:{Documentation}]" : $"[KEY:{Key}][NAME:{Name}]";
    }
}