using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa as urls de download de um documento.
/// </summary>
public class Download
{
    /// <summary>
    /// Endereço de download do arquivo original.
    /// </summary>
    [JsonProperty("original_file_url")]
    public string OriginalUrl { get; set; }

    /// <summary>
    /// Endereço de download do arquivo assinado.
    /// </summary>
    [JsonProperty("signed_file_url")]
    public string SignedUrl { get; set; }

    /// <summary>
    /// endereço de download do arquivo .zip contendo o arquivo original e o assinado.
    /// </summary>
    [JsonProperty("ziped_file_url")]
    public string ZippedUrl { get; set; }

    /// <summary>
    /// Método que traz uma cadeia de caracteres que representa o objeto atual.
    /// </summary>
    /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
    public override string ToString()
    {
        return $"[ORIGINAL:{!string.IsNullOrEmpty(OriginalUrl)}][SIGNED:{!string.IsNullOrEmpty(SignedUrl)}][ZIPPED:{!string.IsNullOrEmpty(ZippedUrl)}]";
    }
}