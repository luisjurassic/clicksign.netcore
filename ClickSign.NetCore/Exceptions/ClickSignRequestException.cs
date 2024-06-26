using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClickSign.NetCore.Exceptions;

/// <summary>
/// Classe container de mensagens de erro reportadas pelo serviço.
/// </summary>
public class ClickSignErrors
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public ClickSignErrors()
    {
        Errors = new List<string>();
    }

    /// <summary>
    /// Lista de erros reportados pelo serviço.
    /// </summary>
    [JsonProperty("errors")]
    public IEnumerable<string> Errors { get; set; }

    /// <summary>
    /// Método que transforma o objeto em sua representação textual (string).
    /// </summary>
    /// <returns>Representação textual do objeto.</returns>
    public override string ToString()
    {
        return string.Join("; ", Errors);
    }
}

/// <summary>
/// </summary>
public class ClickSignRequestException : ClickSignException
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public ClickSignRequestException()
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="message">Mensagem à ser definida na excessão.</param>
    public ClickSignRequestException(string message) : base(GetClickSignErrors(message))
    {
        try
        {
            Errors = JsonConvert.DeserializeObject<ClickSignErrors>(message);
        }
        catch
        {
        }
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="innerException">Excessão que causou a falha.</param>
    public ClickSignRequestException(Exception innerException) : base(innerException.Message)
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="message">Mensagem à ser definida na excessão.</param>
    /// <param name="innerException">Excessão que causou a falha.</param>
    public ClickSignRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Erros reportados pelo serviço.
    /// </summary>
    public ClickSignErrors Errors { get; set; }

    /// <summary>
    /// Método estático que transforma a mensagem retornada pelo serviço em uma
    /// lista de excessões. Caso não possa ser convertido, será exibida a mensagem de erro padrão.
    /// </summary>
    /// <param name="message">Mensagem de excessão.</param>
    /// <returns></returns>
    private static string GetClickSignErrors(string message)
    {
        try
        {
            var errors = JsonConvert.DeserializeObject<ClickSignErrors>(message);
            return errors.ToString();
        }
        catch
        {
            return message;
        }
    }

    /// <summary>
    /// Método que transforma o objeto em sua representação textual (string).
    /// </summary>
    /// <returns>Representação textual do objeto.</returns>
    public override string ToString()
    {
        return Errors != null ? Errors.ToString() : Message;
    }
}