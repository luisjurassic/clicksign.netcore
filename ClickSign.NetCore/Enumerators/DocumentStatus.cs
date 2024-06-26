namespace ClickSign.NetCore.Enumerators;

/// <summary>
/// Enumerador com os status possíveis de um documento no serviço.
/// </summary>
public enum DocumentStatus
{
    /// <summary>
    /// Documento em processo de assinatura
    /// </summary>
    Running,

    /// <summary>
    /// Documento finalizado
    /// </summary>
    Closed,

    /// <summary>
    /// Documento cancelado
    /// </summary>
    Cancelled
}