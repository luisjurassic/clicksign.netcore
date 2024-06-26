using System;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Converters;

/// <summary>
/// Classe para conversão do enumerador <see cref="SignType" /> para json e vice-versa.
/// </summary>
public class SignTypeConverter : JsonConverter
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
            "sign" => SignType.Sign,
            "approve" => SignType.Approve,
            "party" => SignType.Party,
            "witness" => SignType.Witness,
            "interventing" => SignType.Interventing,
            "receipt" => SignType.Receipt,
            "endorser" => SignType.Endorser,
            "endorsee" => SignType.Endorsee,
            "administrator" => SignType.Administrator,
            "guarantor" => SignType.Guarantor,
            "transferor" => SignType.Transferor,
            "transferee" => SignType.Transferee,
            "contractor" => SignType.Contractor,
            "contractee" => SignType.Contractee,
            "joint_debtor" => SignType.JointDebtor,
            "issuer" => SignType.Issuer,
            "manager" => SignType.Manager,
            "buyer" => SignType.Buyer,
            "seller" => SignType.Seller,
            "attorney" => SignType.Attorney,
            "legal_representative" => SignType.LegalRepresentative,
            "co_responsible" => SignType.CoResponsible,
            "validator" => SignType.Validator,
            _ => SignType.Sign
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
        var signType = (SignType)value;
        switch (signType)
        {
            case SignType.Sign:
                writer.WriteValue("sign");
                break;
            case SignType.Approve:
                writer.WriteValue("approve");
                break;
            case SignType.Party:
                writer.WriteValue("party");
                break;
            case SignType.Witness:
                writer.WriteValue("witness");
                break;
            case SignType.Interventing:
                writer.WriteValue("interventing");
                break;
            case SignType.Receipt:
                writer.WriteValue("receipt");
                break;
            case SignType.Endorser:
                writer.WriteValue("endorser");
                break;
            case SignType.Endorsee:
                writer.WriteValue("endorsee");
                break;
            case SignType.Administrator:
                writer.WriteValue("administrator");
                break;
            case SignType.Guarantor:
                writer.WriteValue("guarantor");
                break;
            case SignType.Transferor:
                writer.WriteValue("transferor");
                break;
            case SignType.Transferee:
                writer.WriteValue("transferee");
                break;
            case SignType.Contractor:
                writer.WriteValue("contractor");
                break;
            case SignType.Contractee:
                writer.WriteValue("contractee");
                break;
            case SignType.JointDebtor:
                writer.WriteValue("joint_debtor");
                break;
            case SignType.Issuer:
                writer.WriteValue("issuer");
                break;
            case SignType.Manager:
                writer.WriteValue("manager");
                break;
            case SignType.Buyer:
                writer.WriteValue("buyer");
                break;
            case SignType.Seller:
                writer.WriteValue("seller");
                break;
            case SignType.Attorney:
                writer.WriteValue("attorney");
                break;
            case SignType.LegalRepresentative:
                writer.WriteValue("legal_representative");
                break;
            case SignType.CoResponsible:
                writer.WriteValue("co_responsible");
                break;
            case SignType.Validator:
                writer.WriteValue("validator");
                break;
            default:
                writer.WriteValue("sign");
                break;
        }
    }
}