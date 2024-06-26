using System;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Converters;

/// <summary>
/// Classe para conversão do enumerador <see cref="EventType" /> para json e vice-versa.
/// </summary>
public class EventTypeConverter : JsonConverter
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
            "upload" => EventType.Upload,
            "add_signer" => EventType.AddSigner,
            "remove_signer" => EventType.RemoveSigner,
            "sign" => EventType.Sign,
            "close" => EventType.Close,
            "auto_close" => EventType.AutoClose,
            "deadline" => EventType.Deadline,
            "cancel" => EventType.Cancel,
            "update_deadline" => EventType.UpdateDeadline,
            "update_auto_close" => EventType.UpdateAutoClose,
            _ => EventType.Unknow
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
        var locale = (EventType)value;
        switch (locale)
        {
            case EventType.Upload:
                writer.WriteValue("upload");
                break;
            case EventType.AddSigner:
                writer.WriteValue("add_signer");
                break;
            case EventType.RemoveSigner:
                writer.WriteValue("remove_signer");
                break;
            case EventType.Sign:
                writer.WriteValue("sign");
                break;
            case EventType.Close:
                writer.WriteValue("close");
                break;
            case EventType.AutoClose:
                writer.WriteValue("auto_close");
                break;
            case EventType.Deadline:
                writer.WriteValue("deadline");
                break;
            case EventType.Cancel:
                writer.WriteValue("cancel");
                break;
            case EventType.UpdateDeadline:
                writer.WriteValue("update_deadline");
                break;
            case EventType.UpdateAutoClose:
                writer.WriteValue("update_auto_close");
                break;
            case EventType.Unknow:
            default:
                writer.WriteValue("unknow");
                break;
        }
    }
}