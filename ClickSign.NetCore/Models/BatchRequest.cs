using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo de requisição de criação de assinatura em lotes.
/// </summary>
[JsonObject(Title = "batch")]
public class BatchRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public BatchRequest()
    {
        DocumentKeys = new List<Guid>();
    }

    /// <summary>
    /// Chave única do signatário dentro da Clicksign.
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
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[SIGNER:{SignerKey}][SUMMARY:{Summary}][DOCUMENTS:{DocumentKeys.Count}]";
    }
}