using System;
using System.Collections.Generic;
using ClickSign.NetCore.Converters;
using ClickSign.NetCore.Enumerators;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa um documento.
/// </summary>
public class Document
{
    /// <summary>
    /// Chave única do documento.
    /// </summary>
    [JsonProperty("key")]
    public Guid Key { get; set; }

    /// <summary>
    /// Caminho do documento.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; }

    /// <summary>
    /// Nome do arquivo.
    /// </summary>
    [JsonProperty("filename")]
    public string Filename { get; set; }

    /// <summary>
    /// Data de upload do documento.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("uploaded_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Uploaded { get; set; }

    /// <summary>
    /// Data de atualização do documento.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Updated { get; set; }

    /// <summary>
    /// Data de finalização do documento.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("finished_at")]
    public DateTime? Finished { get; set; }

    /// <summary>
    /// Data limite de assinaturas do documento.
    /// </summary>
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    [JsonProperty("deadline_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime Deadline { get; set; }

    /// <summary>
    /// Estado atual do documento.
    /// </summary>
    [JsonConverter(typeof(DocumentStatusConverter))]
    [JsonProperty("status")]
    public DocumentStatus Status { get; set; }

    /// <summary>
    /// Atributo que indica se o documento será finalizado após a última assinatura automaticamente.
    /// </summary>
    [JsonProperty("auto_close")]
    public bool AutoClose { get; set; }

    /// <summary>
    /// Atributo que define o idioma desejado para o documento.
    /// </summary>
    [JsonConverter(typeof(LocalesConverter))]
    [JsonProperty("locale")]
    public Locales Locale { get; set; }

    /// <summary>
    /// Atributo que contém os dados de download do documento. <see cref="Download" />
    /// </summary>
    [JsonProperty("downloads")]
    public Download Downloads { get; set; }

    /// <summary>
    /// Lista contendo os assinantes do documento.
    /// </summary>
    [JsonProperty("signers")]
    public ICollection<DocumentSigner> Signers { get; set; }

    /// <summary>
    /// Lista contendo os eventos do documento.
    /// </summary>
    [JsonProperty("events")]
    public ICollection<Event> Events { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return Status switch
        {
            DocumentStatus.Running => $"[KEY:{Key}][FILENAME:{Filename}][STATUS:{Status}][DEADLINE:{Deadline.ToString("yyyy-MM-dd")}]",
            DocumentStatus.Closed => $"[KEY:{Key}][FILENAME:{Filename}][STATUS:{Status}][FINISHED:{Finished.Value.ToString("yyyy-MM-dd")}]",
            _ => $"[KEY:{Key}][FILENAME:{Filename}][STATUS:{Status}][FINISHED:{Finished.Value.ToString("yyyy-MM-dd")}]"
        };
    }
}