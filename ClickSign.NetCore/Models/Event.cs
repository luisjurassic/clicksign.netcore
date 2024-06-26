using System;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa um evento recebido.
/// </summary>
public class Event
{
    /// <summary>
    /// Nome do evento.
    /// </summary>
    [JsonProperty("name")]
    [JsonConverter(typeof(EventTypeConverter))]
    public EventType Name { get; set; }

    /// <summary>
    /// Data em que o evento ocorreu.
    /// </summary>
    [JsonProperty("occurred_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Occurred { get; set; }

    /// <summary>
    /// Dados do evento ocorrido. <see cref="EventData" />
    /// </summary>
    [JsonProperty("data")]
    public EventData Data { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[NAME:{Name}][OCCURREDAT:{Occurred.ToString("dd/MM/yyyy HH:mm:ss")}]";
    }
}