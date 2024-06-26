using System;
using System.Collections.Generic;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa os dados de um evento.
/// </summary>
public class EventData
{
    /// <summary>
    /// Dados do usuário do sistema.
    /// </summary>
    [JsonProperty("user")]
    public EventUser User { get; set; }

    /// <summary>
    /// Dados da conta do sistema.
    /// </summary>
    [JsonProperty("account")]
    public EventAccount Account { get; set; }

    /// <summary>
    /// Dados do assinante.
    /// </summary>
    [JsonProperty("signer")]
    public EventSigner Signer { get; set; }

    /// <summary>
    /// Dados de versão do log.
    /// </summary>
    [JsonProperty("log_version")]
    public string LogVersion { get; set; }

    /// <summary>
    /// Indica que o documento será fechado após a assinatura de todos os assinantes.
    /// </summary>
    [JsonProperty("auto_close")]
    public bool AutoClose { get; set; }

    /// <summary>
    /// Data limite para assinaturas ao documento.
    /// </summary>
    [JsonProperty("deadline_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Deadline { get; set; }

    /// <summary>
    /// Lista contendo assinantes.
    /// </summary>
    [JsonProperty("signers")]
    public IEnumerable<EventSigner> Signers { get; set; }

    /// <summary>
    /// Localização do documento.
    /// </summary>
    [JsonConverter(typeof(LocalesConverter))]
    [JsonProperty("locale")]
    public Locales Locale { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        if (string.IsNullOrEmpty(LogVersion))
            return $"[AUTO.CLOSE:{AutoClose}][LOCALE:{Locale}][DEADLINE:{Deadline.ToString("yyyy-MM-ddTHH:mm:ss")}]";
        return $"[LOG.VERSION:{LogVersion}][AUTO.CLOSE:{AutoClose}][LOCALE:{Locale}][DEADLINE:{Deadline.ToString("yyyy-MM-ddTHH:mm:ss")}]";
    }
}