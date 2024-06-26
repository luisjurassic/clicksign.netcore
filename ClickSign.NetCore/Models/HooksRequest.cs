using System;
using ClickSign.NetCore.Converters;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa um hook.
/// </summary>
public class HooksRequest
{
    /// <summary>
    /// URL para recebimentos dos eventos de webhooks.
    /// </summary>
    [JsonProperty("endpoint")]
    [JsonRequired]
    public string Url { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// Definição dos eventos deverão ser retornados ao endpoint específico.
    /// </summary>
    [JsonProperty("events")]
    [JsonRequired]
    public string[] Events { get; set; }

    /// <summary>
    /// Definição do status
    /// </summary>
    [JsonProperty("status")]
    [JsonRequired]
    public string Status { get; set; }

    /// <summary>
    /// Chave do webhook.
    /// </summary>
    [JsonProperty("key")]
    public Guid Key { get; set; }

    /// <summary>
    /// Data de criação do hook.
    /// </summary>
    [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Created { get; set; }

    /// <summary>
    /// Data de atualização do hook.
    /// </summary>
    [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Updated { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[KEY:{Key}][URL:{Url}][SECRET:{Secret}][STATUS:{Status}][EVENTS:{string.Join(",", Events)}]";
    }
}