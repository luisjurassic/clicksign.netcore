using System;

namespace ClickSign.NetCore.Exceptions;

/// <summary>
/// Exceção ligada à não autorização do webhook.
/// </summary>
public class WebhookUnauthorizedException : ClickSignException
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public WebhookUnauthorizedException()
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="message">Mensagem à ser definida na excessão.</param>
    public WebhookUnauthorizedException(string message) : base(message)
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="innerException">Excessão que causou a falha.</param>
    public WebhookUnauthorizedException(Exception innerException) : base(innerException.Message)
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="message">Mensagem à ser definida na excessão.</param>
    /// <param name="innerException">Excessão que causou a falha.</param>
    public WebhookUnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}