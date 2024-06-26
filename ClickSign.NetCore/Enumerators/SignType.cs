namespace ClickSign.NetCore.Enumerators;

/// <summary>
/// Enumerador com os tipos de assinatura disponíveis no serviço.
/// </summary>
public enum SignType
{
    /// <summary>
    /// Assinante
    /// </summary>
    Sign,

    /// <summary>
    /// Assinar para aprovar
    /// </summary>
    Approve,

    /// <summary>
    /// Assinar como parte
    /// </summary>
    Party,

    /// <summary>
    /// Assinar como testemunha
    /// </summary>
    Witness,

    /// <summary>
    /// Assinar como interveniente
    /// </summary>
    Interventing,

    /// <summary>
    /// Assinar para acusar recebimento
    /// </summary>
    Receipt,

    /// <summary>
    /// Assinar como endorssante
    /// </summary>
    Endorser,

    /// <summary>
    /// Assinar como endorssattário
    /// </summary>
    Endorsee,

    /// <summary>
    /// Assinar como administrador
    /// </summary>
    Administrator,

    /// <summary>
    /// Assinar como avalista
    /// </summary>
    Guarantor,

    /// <summary>
    /// Assinar como cedente
    /// </summary>
    Transferor,

    /// <summary>
    /// Assinar como cessionário
    /// </summary>
    Transferee,

    /// <summary>
    /// Assinar como contratante
    /// </summary>
    Contractor,

    /// <summary>
    /// Assinar como contratada
    /// </summary>
    Contractee,

    /// <summary>
    /// Assinar como devedor solidário
    /// </summary>
    JointDebtor,

    /// <summary>
    /// Assinar como emitente
    /// </summary>
    Issuer,

    /// <summary>
    /// Assinar como gestor
    /// </summary>
    Manager,

    /// <summary>
    /// Assinar como compradora
    /// </summary>
    Buyer,

    /// <summary>
    /// Assinar como vendedora
    /// </summary>
    Seller,

    /// <summary>
    /// Assinar como procurador
    /// </summary>
    Attorney,

    /// <summary>
    /// Assinar como representante legal
    /// </summary>
    LegalRepresentative,

    /// <summary>
    /// Assinar como responsável solidário
    /// </summary>
    CoResponsible,

    /// <summary>
    /// Assinar como validador
    /// </summary>
    Validator
}