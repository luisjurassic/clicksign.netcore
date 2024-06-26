using System;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo de requisição de notificação de assinatura.
/// </summary>
public class NotificationRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public NotificationRequest()
    {
        Type = NotificationType.Email;
    }

    /// <summary>
    /// </summary>
    [JsonProperty("request_signature_key")]
    public Guid? SignatureKey { get; set; }

    /// <summary>
    /// Mensagem à ser enviada ao assinante.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// Url de assinatura.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// Canal de assinatura. Veja <see cref="NotificationType" />.
    /// </summary>
    [JsonIgnore]
    public NotificationType Type { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[KEY:{SignatureKey}][TYPE:{Type}][MESSAGE:{Message}]";
    }
}