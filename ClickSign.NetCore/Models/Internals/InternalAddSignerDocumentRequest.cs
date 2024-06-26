using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe interna para requisição de adição de um assinante à um documento.
/// </summary>
internal class InternalAddSignerDocumentRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="request">Dados do assinante à ser adicionado à um documento.</param>
    internal InternalAddSignerDocumentRequest(AddSignerRequest request)
    {
        List = request;
    }

    /// <summary>
    /// Dados do assinante à ser adicionado à um documento.
    /// </summary>
    [JsonProperty("list")]
    internal AddSignerRequest List { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return List?.ToString();
    }
}