namespace ClickSign.NetCore.Enumerators;

/// <summary>
/// Enumerador com os tipos de notificação de assinatura disponíveis no serviço.
/// </summary>
public enum DeliveryType
{
    /// <summary>
    /// Não receberá confirmação de assinatura
    /// </summary>
    None,

    /// <summary>
    /// Receberá confirmação de assinatura por email
    /// </summary>
    Email
}