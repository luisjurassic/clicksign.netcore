using System;

namespace ClickSign.NetCore.Exceptions;

/// <summary>
/// Classe de exceção básica da biblioteca.
/// </summary>
public class ClickSignException : Exception
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    public ClickSignException()
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="message">Mensagem à ser definida na excessão.</param>
    public ClickSignException(string message) : base(message)
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="innerException">Excessão que causou a falha.</param>
    public ClickSignException(Exception innerException) : base(innerException.Message)
    {
    }

    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="message">Mensagem à ser definida na excessão.</param>
    /// <param name="innerException">Excessão que causou a falha.</param>
    public ClickSignException(string message, Exception innerException) : base(message, innerException)
    {
    }
}