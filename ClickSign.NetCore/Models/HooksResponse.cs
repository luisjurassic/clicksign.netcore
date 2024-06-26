using System;
using ClickSign.NetCore.Converters;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa um disparo de hook.
/// </summary>
public class HooksResponse
{
    /// <summary>
    /// Evento recebido
    /// </summary>
    [JsonProperty("event")]
    public Event Event { get; set; }

    /// <summary>
    /// Dados enviados
    /// </summary>
    [JsonProperty("acceptance")]
    public Acceptance Acceptance { get; set; }
}

/// <summary>
/// Dados do evento
/// </summary>
public class Data
{
    /// <summary>
    /// Usuario da conta associada
    /// </summary>
    [JsonProperty("user")]
    public User User { get; set; }

    /// <summary>
    /// Conta associada
    /// </summary>
    [JsonProperty("account")]
    public Account Account { get; set; }
}

/// <summary>
/// Classe que representa um usuário.
/// </summary>
public class User
{
    /// <summary>
    /// Email do usuário
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Nome do usuário
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}

/// <summary>
/// Classe que representa os dados enviados.
/// </summary>
public class Acceptance
{
    /// <summary>
    /// Chave
    /// </summary>
    [JsonProperty("key")]
    public Guid Key { get; set; }

    /// <summary>
    /// Descrição do envio
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Nome do responsável do envio
    /// </summary>
    [JsonProperty("sender_name")]
    public string SenderName { get; set; }

    /// <summary>
    /// Telefone do responsável do envio
    /// </summary>
    [JsonProperty("sender_phone")]
    public string SenderPhone { get; set; }

    /// <summary>
    /// Conteudo do envio
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }

    /// <summary>
    /// Status do envio
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    /// <summary>
    /// Telefone do signatário
    /// </summary>
    [JsonProperty("signer_phone")]
    public string SignerPhone { get; set; }

    /// <summary>
    /// Nome do signatário
    /// </summary>
    [JsonProperty("signer_name")]
    public string SignerName { get; set; }

    /// <summary>
    /// Data do envio
    /// </summary>
    [JsonProperty("sent_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Sent { get; set; }

    /// <summary>
    /// Data da criação
    /// </summary>
    [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public DateTime Created { get; set; }

    /// <summary>
    /// Lista de mensagens enviadas
    /// </summary>
    [JsonProperty("messages")]
    public Messages[] Messages { get; set; }
}

/// <summary>
/// Classe que representa as mensagens enviadas.
/// </summary>
public class Messages
{
    /// <summary>
    /// Id da mensagem
    /// </summary>
    [JsonProperty("message_id")]
    public string MessageId { get; set; }

    /// <summary>
    /// Descrição da mensagem
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// Nome do destinatário da mensagem
    /// </summary>
    [JsonProperty("profile_name")]
    public string ProfileName { get; set; }

    /// <summary>
    /// Mensagem de erro
    /// </summary>
    [JsonProperty("error_message")]
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Status da mensagem
    /// </summary>
    [JsonProperty("direction")]
    public string Direction { get; set; }

    /// <summary>
    /// Data de criação da mensagem
    /// </summary>
    [JsonProperty("created_at")]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
    public string Created { get; set; }
}