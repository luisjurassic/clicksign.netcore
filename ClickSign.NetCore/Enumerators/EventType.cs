namespace ClickSign.NetCore.Enumerators;

/// <summary>
/// Enumerador com os tipos de eventos que podem ocorrer.
/// </summary>
public enum EventType
{
    /// <summary>
    /// Ocorre quando o evento é desconhecido.
    /// </summary>
    Unknow,

    /// <summary>
    /// Ocorre quando é realizado o upload de um documento.
    /// </summary>
    Upload,

    /// <summary>
    /// Ocorre quando são adicionados signatários a um documento.
    /// </summary>
    AddSigner,

    /// <summary>
    /// Ocorre quando são removidos signatários de um documento.
    /// </summary>
    RemoveSigner,

    /// <summary>
    /// Ocorre quando um signatário assina um documento.
    /// </summary>
    Sign,

    /// <summary>
    /// Ocorre quando um documento é finalizado manualmente.
    /// </summary>
    Close,

    /// <summary>
    /// Ocorre quando um documento é finalizado automaticamente logo após a última assinatura.
    /// </summary>
    AutoClose,

    /// <summary>
    /// Ocorre quando a data limite de assinatura de um documento for atingida. Se o documento contiver ao menos uma
    /// assinatura, ele é finalizado. Caso contrário, o documento é cancelado.
    /// </summary>
    Deadline,

    /// <summary>
    /// Ocorre quando um documento é cancelado manualmente.
    /// </summary>
    Cancel,

    /// <summary>
    /// Ocorre quando a data limite de assinatura de um documento é alterada.
    /// </summary>
    UpdateDeadline,

    /// <summary>
    /// Ocorre quando a opção de finalização automática de um documento é alterada.
    /// </summary>
    UpdateAutoClose
}