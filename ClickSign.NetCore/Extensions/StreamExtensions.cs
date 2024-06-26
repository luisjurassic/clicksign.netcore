using System.IO;

namespace ClickSign.NetCore.Extensions;

/// <summary>
/// Classe de extensões para <see cref="Stream" />.
/// </summary>
internal static class StreamExtensions
{
    /// <summary>
    /// Método de extensão para converter um <see cref="Stream" /> em um vetor de bytes.
    /// </summary>
    /// <param name="stream">Instância do stream à ser convertido.</param>
    /// <returns>Vetor de bytes relativo ao stream de bytes informado.</returns>
    internal static byte[] ToByteArray(this Stream stream)
    {
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }
}