using System;
using System.Collections.Generic;
using ClickSign.NetCore.Converters;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo de resposta de criação de assinatura em lotes.
/// </summary>
[JsonObject(Title = "batch")]
public class BatchResponse
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public BatchResponse()
    {
        DocumentKeys = new List<Guid>();
    }

    /// <summary>
    /// Chave única da assinatura em lotes.
    /// </summary>
    [JsonProperty("key")]
    public Guid Key { get; set; }

    /// <summary>
    /// Chave do assinante que fará a assinatura em lote.
    /// </summary>
    [JsonProperty("signer_key")]
    public Guid? SignerKey { get; set; }

    /// <summary>
    /// Lista de chaves dos documentos que farão parte da assinatura em lotes.
    /// </summary>
    [JsonProperty("document_keys")]
    public ICollection<Guid> DocumentKeys { get; set; }

    /// <summary>
    /// Atributo que indica se será apresentado um sumário com todos os documentos
    /// à serem assinados. Caso verdadeiro, o sumário será apresentado e todos os
    /// documentos serão assinados de uma única vez, do contrário serão assinados em
    /// sequência.
    /// </summary>
    public bool Summary { get; set; }

    /// <summary>
    /// Data de criação da assinatura em lotes.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Created { get; set; }

    /// <summary>
    /// Data de atualização da assinatura em lotes.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Updated { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[SIGNER:{SignerKey}][SUMMARY:{Summary}][CREATED:{Created.ToString("yyyy-MM-ddT:HH:mm:ss")}][KEYS:{DocumentKeys.Count}]";
    }
}