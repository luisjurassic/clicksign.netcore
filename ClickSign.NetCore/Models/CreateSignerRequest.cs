using System;
using System.Collections.Generic;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo de requisição de criação de assinante.
/// </summary>
public class CreateSignerRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public CreateSignerRequest()
    {
        Auths = new List<AuthType> { AuthType.Email };
    }

    /// <summary>
    /// Nome do assinante.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Endereço de email do assinante.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Indica se o assinante possui documento associado.
    /// </summary>
    [JsonProperty("has_documentation")]
    public bool HasDocumentation { get; set; }

    /// <summary>
    /// Número do documento do assinante.
    /// </summary>
    [JsonProperty("documentation")]
    public string Documentation { get; set; }

    /// <summary>
    /// Data de aniversário do assinante.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
    [JsonProperty("birthday", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Birthday { get; set; }

    /// <summary>
    /// Número de telefone do assinante.
    /// </summary>
    [JsonProperty("phone_number")]
    public string Phone { get; set; }

    /// <summary>
    /// Tipo de autenticação à ser utilizada pelo assinante.
    /// </summary>
    [JsonProperty("auths", ItemConverterType = typeof(AuthTypesConverter))]
    public ICollection<AuthType> Auths { get; set; }

    /// <summary>
    /// Método para definir o tipo de autenticação do assinante.
    /// </summary>
    /// <param name="authType">Tipo de autenticação à ser utilizada pelo assinante.</param>
    public void SetAuth(AuthType authType)
    {
        Auths.Clear();
        Auths.Add(authType);
    }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        if (HasDocumentation)
            return $"[NAME:{Name}][DOCUMENT:{Documentation}][BIRTHDAY:{Birthday.ToString("yyyy-MM-dd")}][EMAIL:{Email}][PHONE:{Phone}]";
        return $"[NAME:{Name}][BIRTHDAY:{Birthday.ToString("yyyy-MM-dd")}][EMAIL:{Email}][PHONE:{Phone}]";
    }
}