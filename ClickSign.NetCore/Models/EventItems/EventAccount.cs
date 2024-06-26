using System;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Evento da conta.
/// </summary>
public class EventAccount
{
    /// <summary>
    /// Id da conta.
    /// </summary>
    public Guid Key { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return Key.ToString();
    }
}