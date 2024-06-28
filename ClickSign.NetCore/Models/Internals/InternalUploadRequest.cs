using Newtonsoft.Json;

namespace ClickSign.NetCore.Models.Internals;

/// <summary>
/// Classe interna para requisição de uplaod de arquivo.
/// </summary>
internal class InternalUploadRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="request">Dados do documento à ser enviado ao serviço.</param>
    public InternalUploadRequest(UploadRequest request)
    {
        Document = request;
    }

    /// <summary>
    /// Dados do documento à ser enviado ao serviço.
    /// </summary>
    [JsonProperty("document")]
    public UploadRequest Document { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return Document?.ToString();
    }
}