using System;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Objeto com os dados de upload de um documento.
/// </summary>
public class UploadRequest
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public UploadRequest()
    {
        var now = DateTime.Now;
        Path = "/";
        Deadline = now.AddDays(30);
        AutoClose = true;
        Locale = Locales.PtBR;
        RemindInterval = 3;
    }

    /// <summary>
    /// Diretório onde o documento deve ser armazenado.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; }

    /// <summary>
    /// Conteúdo do documento.
    /// </summary>
    [JsonProperty("content_base64")]
    public string Content { get; set; }

    /// <summary>
    /// Data limite para efetuar assinaturas no documento.
    /// </summary>
    [JsonProperty("deadline_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Deadline { get; set; }

    /// <summary>
    /// Indica que o documento deve ser fechado logo após a última assinatura.
    /// </summary>
    [JsonProperty("auto_close")]
    public bool AutoClose { get; set; }

    /// <summary>
    /// Localização do documento.
    /// </summary>
    [JsonConverter(typeof(LocalesConverter))]
    [JsonProperty("locale")]
    public Locales Locale { get; set; }

    /// <summary>
    /// Determina se o documento terá a funcionalidade de ordenação de assinaturas ativada.
    /// Ao Adicionar signatário a documento deverá definir o grupo pertencente.
    /// </summary>
    [JsonProperty("sequence_enabled")]
    public bool SequenceEnabled { get; set; }

    /// <summary>
    /// Determina se o documento terá opção de lembretes automáticos ativada. O intervalo é medido em dias.
    /// Com a inclusão do parâmetro serão enviados até três lembretes automaticamente.
    /// Intervalos suportados: 1; 2; 3; 7; 14.
    /// </summary>
    [JsonProperty("remind_interval")]
    public int RemindInterval { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[PATH:{Path}][DEADLINE:{Deadline.ToString("yyyy-MM-ddTHH:mm:ss")}][LOCALE:{Locale}][AUTOCLOSE:{AutoClose}]";
    }
}