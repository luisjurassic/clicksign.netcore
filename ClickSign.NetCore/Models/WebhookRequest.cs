using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa uma requisição webhook.
/// </summary>
public class WebhookRequest
{
    /// <summary>
    /// Dados do evento reportado
    /// </summary>
    [JsonProperty("event")]
    public Event Event { get; set; }

    /// <summary>
    /// Dados do documento associado ao evento.
    /// </summary>
    [JsonProperty("document")]
    public Document Document { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[DOCUMENT:{Document.Key}][EVENT:{Event.Name}][OCCURRENCE:{Event.Occurred}]";
    }
}