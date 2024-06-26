using Newtonsoft.Json.Converters;

namespace ClickSign.NetCore.Converters;

/// <summary>
/// Classe responsável pela conversão da data para um formato específico.
/// </summary>
public class DateFormatConverter : IsoDateTimeConverter
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="format">Formado de data desejado.</param>
    public DateFormatConverter(string format)
    {
        DateTimeFormat = format;
    }
}