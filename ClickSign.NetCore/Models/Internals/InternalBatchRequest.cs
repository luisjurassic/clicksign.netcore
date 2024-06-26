using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe interna para requisição de criação de assinatura em lotes.
/// </summary>
internal class InternalBatchRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="request">Dados da assinatura em lote à ser criada.</param>
    public InternalBatchRequest(BatchRequest request)
    {
        Batch = request;
    }

    /// <summary>
    /// Dados da assinatura em lote à ser criada.
    /// </summary>
    [JsonProperty("batch")]
    internal BatchRequest Batch { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return Batch?.ToString();
    }
}