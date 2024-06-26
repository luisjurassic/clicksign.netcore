namespace ClickSign.NetCore.Enumerators;

/// <summary>
/// Enumerador com os tipos de autenticação disponíveis no serviço.
/// </summary>
public enum AuthType
{
    /// <summary>
    /// Envio de token por e-mail
    /// </summary>
    Email,

    /// <summary>
    /// Envio de token por SMS
    /// </summary>
    Sms,

    /// <summary>
    /// Envio de token por Whatsapp
    /// </summary>
    WhatsApp,

    /// <summary>
    /// Assinatura via API
    /// </summary>
    Api
}