using System;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Converters;

/// <summary>
/// Classe para conversão do enumerador <see cref="Locales" /> para json e vice-versa.
/// </summary>
public class LocalesConverter : JsonConverter
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
            "pt-BR" => Locales.PtBR,
            "en-US" => Locales.EnUS,
            _ => Locales.PtBR
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
        var locale = (Locales)value;
        switch (locale)
        {
            case Locales.PtBR:
                writer.WriteValue("pt-BR");
                break;
            case Locales.EnUS:
                writer.WriteValue("en-US");
                break;
            default:
                writer.WriteValue("pt-BR");
                break;
        }
    }
}