namespace ClickSign.NetCore.Enumerators;

/// <summary>
/// Enumerador com os tipos de status de validação.
/// </summary>
public enum SignatureValidationStatus
{
    /// <summary>
    /// Desconhecido.
    /// </summary>
    Unknow,

    /// <summary>
    /// Aguardando validação na base da Receita Federal.
    /// </summary>
    Pending,

    /// <summary>
    /// Nome confere com a base de dados da Receita Federal.
    /// </summary>
    Conferred,

    /// <summary>
    /// CPF informado não existe na base de dados da Receita Federal.
    /// </summary>
    CpfNotFound,

    /// <summary>
    /// Nome preenchido diverge do nome cadastrado na base de dados da Receita Federal
    /// </summary>
    DivergentName,

    /// <summary>
    /// Data de nascimento preenchida diverge da data cadastrada na base de dados da Receita Federal.
    /// </summary>
    DivergentBirthday,

    /// <summary>
    /// CPF informado não é válido.
    /// </summary>
    CpfInvalid,

    /// <summary>
    /// Validação do signatário apresentou erro ocorrido durante a consulta na base de dados da Receita Federal.
    /// </summary>
    SignerValidationFail
}