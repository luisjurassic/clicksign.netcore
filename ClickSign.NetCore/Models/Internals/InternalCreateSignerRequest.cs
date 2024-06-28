using Newtonsoft.Json;

namespace ClickSign.NetCore.Models.Internals;

/// <summary>
/// Classe interna para requisição de criação de assinante.
/// </summary>
internal class InternalCreateSignerRequest
{
    /// <summary>
    /// Método construtor
    /// </summary>
    /// <param name="request">Dados do assinante à ser criado.</param>
    public InternalCreateSignerRequest(CreateSignerRequest request)
    {
        Signer = request;
    }

    /// <summary>
    /// Dados do assinante à ser criado.
    /// </summary>
    [JsonProperty("signer")]
    public CreateSignerRequest Signer { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return Signer?.ToString();
    }
}