namespace ClickSign.NetCore.Enumerators;

/// <summary>
/// Enumerador com os tipos de envio de chave de assinatura do serviço.
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// Envio por e-mail.
    /// </summary>
    Email,

    /// <summary>
    /// Envio por sms.
    /// </summary>
    Sms,

    /// <summary>
    /// Envio por Whatsapp.
    /// </summary>
    Whatsapp
}