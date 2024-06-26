using System;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Converters;

/// <summary>
/// Classe para conversão do enumerador <see cref="AuthType" /> para json e vice-versa.
/// </summary>
public class AuthTypesConverter : JsonConverter
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
            "email" => AuthType.Email,
            "sms" => AuthType.Sms,
            "whatsapp" => AuthType.WhatsApp,
            "api" => AuthType.Api,
            _ => AuthType.Email
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
        var authType = (AuthType)value;
        switch (authType)
        {
            case AuthType.Email:
                writer.WriteValue("email");
                break;
            case AuthType.Sms:
                writer.WriteValue("sms");
                break;
            case AuthType.WhatsApp:
                writer.WriteValue("whatsapp");
                break;
            case AuthType.Api:
                writer.WriteValue("api");
                break;
            default:
                writer.WriteValue("email");
                break;
        }
    }
}