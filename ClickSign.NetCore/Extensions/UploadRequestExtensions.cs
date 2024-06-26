using System;
using System.IO;
using ClickSign.NetCore.Models;
using ClickSign.NetCore.Utils;

namespace ClickSign.NetCore.Extensions;

/// <summary>
/// Classe de extensões para <see cref="UploadRequest" />.
/// </summary>
public static class UploadRequestExtensions
{
    /// <summary>
    /// Método que define o conteúdo da requisição com base no endereço de um arquivo.
    /// </summary>
    /// <param name="request">Instância do objeto.</param>
    /// <param name="path">Nome do arquivo completo para adição à requisição.</param>
    /// <returns>Instância do objeto.</returns>
    public static UploadRequest SetContent(this UploadRequest request, string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        return SetContent(request, stream);
    }

    /// <summary>
    /// Método que define o conteúdo da requisição com base no fluxo de dados de um arquivo.
    /// </summary>
    /// <param name="request">Instância do objeto.</param>
    /// <param name="stream">Fluxo de dados à ser adicionado à requisição.</param>
    /// <returns>Instância do objeto.</returns>
    public static UploadRequest SetContent(this UploadRequest request, Stream stream)
    {
        stream.Position = 0;
        var streamBytes = stream.ToByteArray();
        stream.Position = 0;
        var base64Data = Convert.ToBase64String(streamBytes);
        var mimeType = MimetypeDetector.DetectMimeType(stream);
        request.Content = $"data:{mimeType};base64,{base64Data}";
        return request;
    }
}