using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe de modelo com os dados da validação de uma assinatura.
/// </summary>
public class SignatureValidation
{
    /// <summary>
    /// Status da validação.
    /// </summary>
    [JsonConverter(typeof(SignatureValidationConverter))]
    [JsonProperty("status")]
    public SignatureValidationStatus Status { get; set; }

    /// <summary>
    /// Nome validado.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Nome na receita federal.
    /// </summary>
    [JsonProperty("federal_tax_name")]
    public string FederalName { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        if (string.IsNullOrEmpty(Name))
            return $"[STATUS:{Status}]";
        return $"[NAME:{Name}][STATUS:{Status}]";
    }
}