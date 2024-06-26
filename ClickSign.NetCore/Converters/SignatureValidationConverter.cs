using System;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Converters;

/// <summary>
/// Classe para conversão do enumerador <see cref="SignatureValidationStatus" /> para json e vice-versa.
/// </summary>
public class SignatureValidationConverter : JsonConverter
{
    /// <summary>
    /// Método que valida se o tipo informado pode ser convertido.
    /// </summary>
    /// <param name="objectType">Tipo do objeto à ser convertido.</param>
    /// <returns>Verdadeiro caso o objeto possa ser convertido e falso caso contrário.</returns>
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }

    /// <summary>
    /// Método que transforma o valor json no objeto referente.
    /// </summary>
    /// <param name="reader">Leitor do arquivo json.</param>
    /// <param name="objectType">tipo do objeto à ser convertido.</param>
    /// <param name="existingValue">Valor existente.</param>
    /// <param name="serializer">Serializador json.</param>
    /// <returns>Objeto referente ao valor informado.</returns>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var value = (string)reader.Value;

        return value switch
        {
            "pending" => SignatureValidationStatus.Pending,
            "conferred" => SignatureValidationStatus.Conferred,
            "cpf_not_found" => SignatureValidationStatus.CpfNotFound,
            "cpf_invalid" => SignatureValidationStatus.CpfInvalid,
            "divergent_name" => SignatureValidationStatus.DivergentName,
            "divergent_birthday" => SignatureValidationStatus.DivergentBirthday,
            "signer_validation_fail" => SignatureValidationStatus.SignerValidationFail,
            _ => SignatureValidationStatus.Unknow
        };
    }

    /// <summary>
    /// Método que transforma o objeto em sua representação json referente.
    /// </summary>
    /// <param name="writer">Escritor do arquivo json.</param>
    /// <param name="value">Objeto à ser traduzido.</param>
    /// <param name="serializer">Serializador json.</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var authType = (SignatureValidationStatus)value;
        switch (authType)
        {
            case SignatureValidationStatus.Pending:
                writer.WriteValue("pending");
                break;
            case SignatureValidationStatus.Conferred:
                writer.WriteValue("conferred");
                break;
            case SignatureValidationStatus.CpfNotFound:
                writer.WriteValue("cpf_not_found");
                break;
            case SignatureValidationStatus.CpfInvalid:
                writer.WriteValue("cpf_invalid");
                break;
            case SignatureValidationStatus.DivergentName:
                writer.WriteValue("divergent_name");
                break;
            case SignatureValidationStatus.DivergentBirthday:
                writer.WriteValue("divergent_birthday");
                break;
            case SignatureValidationStatus.SignerValidationFail:
                writer.WriteValue("signer_validation_fail");
                break;
            case SignatureValidationStatus.Unknow:
            default:
                writer.WriteValue("unknow");
                break;
        }
    }
}