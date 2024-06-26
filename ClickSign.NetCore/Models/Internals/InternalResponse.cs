using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de resposta das requisições ao serviço.
/// </summary>
internal class InternalResponse
{
    /// <summary>
    /// Documento criado ou retornado com base na chave informada.
    /// </summary>
    [JsonProperty("document")]
    internal Document Document { get; set; }

    /// <summary>
    /// Lista de documentos criados ou retornados.
    /// </summary>
    [JsonProperty("documents")]
    internal IEnumerable<Document> Documents { get; set; }

    /// <summary>
    /// Lista de webhooks criados ou retornados.
    /// </summary>
    [JsonProperty("hooks")]
    internal IEnumerable<HooksRequest> Webhooks { get; set; }

    /// <summary>
    /// Assinante criado ou retornado com base na chave informada.
    /// </summary>
    [JsonProperty("signer")]
    internal Signer Signer { get; set; }

    /// <summary>
    /// Dados da associação de um assinante à um documento.
    /// </summary>
    [JsonProperty("list")]
    internal AddSignerResponse List { get; set; }

    /// <summary>
    /// Dados de resposta à criação de uma assinatura em lotes.
    /// </summary>
    [JsonProperty("batch")]
    internal BatchResponse Batch { get; set; }


    /// <summary>
    /// Dados de resposta de uma conta.
    /// </summary>
    [JsonProperty("account")]
    internal Account Account { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        if (Document != null)
            return Document.ToString();
        if (Documents != null)
            return Documents.Any() ? string.Join(string.Empty, Documents.Select(x => x.ToString())) : "[EMPTY RESPONSE]";
        if (Webhooks != null)
            return Webhooks.Any() ? string.Join(string.Empty, Webhooks.Select(x => x.ToString())) : "[EMPTY RESPONSE]";
        if (Signer != null)
            return Signer.ToString();
        if (List != null)
            return List.ToString();
        if (Batch != null)
            return Batch.ToString();
        if (Account != null)
            return Account.ToString();
        return "[EMPTY RESPONSE]";
    }
}