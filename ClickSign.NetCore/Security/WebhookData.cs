using System.IO;

namespace ClickSign.NetCore.Security;

/// <summary>
/// </summary>
public class WebhookData
{
    /// <summary>
    /// </summary>
    public Stream Body { get; set; }

    /// <summary>
    /// </summary>
    public string Signature { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[SIGNATURE:{Signature}]";
    }
}