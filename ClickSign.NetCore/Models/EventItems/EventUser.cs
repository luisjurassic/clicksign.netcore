namespace ClickSign.NetCore.Models;

/// <summary>
/// Evento do usuário.
/// </summary>
public class EventUser
{
    /// <summary>
    /// Nome do usuário do sistema.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Email do usuário do sistema.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[NAME:{Name}][EMAIL:{Email}]";
    }
}