using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClickSign.NetCore.Exceptions;
using ClickSign.NetCoreUtils.Mimetype;
using Newtonsoft.Json;

namespace ClickSign.NetCoreUtils;

/// <summary>
/// Contem metodos para realizar a comunicação via HttpClient
/// </summary>
public class ApiHelper
{
    private readonly int[] _requestAllowedStatusRange = { 400, 401, 403, 404, 422 };

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="urlBase">Url base da comunicação</param>
    public ApiHelper(string urlBase)
    {
        UrlBase = urlBase;
    }

    /// <summary>
    /// Url base para a comunicação
    /// </summary>
    private string UrlBase { get; }

    /// <summary>
    /// Realiza uma consulta no endereço especificado na <see cref="UrlBase" /> de forma assíncrona.
    /// </summary>
    /// <param name="endPoint">O endpoint da url base</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <typeparam name="T">O tipo de dados de retorno</typeparam>
    /// <returns>Os dados</returns>
    public async Task<T> GetAsync<T>(string endPoint, CancellationToken cancellationToken)
    {
        var result = await Send<T>(endPoint, null, HttpMethod.Get, cancellationToken);
        return result;
    }

    /// <summary>
    /// Realiza o envio de dados para o endereço especificado na <see cref="UrlBase" /> de forma assíncrona.
    /// </summary>
    /// <param name="endPoint">O endpoint da url base</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <typeparam name="T">O tipo de dados de retorno</typeparam>
    /// <returns>Os dados</returns>
    public async Task<T> PostAsync<T>(string endPoint, CancellationToken cancellationToken)
    {
        return await PostAsync<T>(endPoint, null, cancellationToken);
    }

    /// <summary>
    /// Realiza o envio de dados para o endereço especificado na <see cref="UrlBase" /> de forma assíncrona.
    /// </summary>
    /// <param name="endPoint">O endpoint da url base</param>
    /// <param name="obj">O objeto que sera envia do no corpo da requisição</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <typeparam name="T">O tipo de dados de retorno</typeparam>
    /// <returns>Os dados</returns>
    public async Task<T> PostAsync<T>(string endPoint, object obj, CancellationToken cancellationToken)
    {
        var result = await Send<T>(endPoint, obj, HttpMethod.Post, cancellationToken);
        return result;
    }

    /// <summary>
    /// Realiza o envio de um comando de DELETE para o endereço especificado na <see cref="UrlBase" /> de forma assíncrona.
    /// </summary>
    /// <param name="endPoint">O endpoint da url base</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    public async Task DeleteAsync(string endPoint, CancellationToken cancellationToken)
    {
        await Send(endPoint, HttpMethod.Delete, cancellationToken);
    }

    /// <summary>
    /// Realiza o envio de um comando de PATCH para o endereço especificado na <see cref="UrlBase" /> de forma assíncrona.
    /// </summary>
    /// <param name="endPoint">O endpoint da url base</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <typeparam name="T">O tipo de dados de retorno</typeparam>
    /// <returns>Os dados</returns>
    public async Task<T> PatchAsync<T>(string endPoint, CancellationToken cancellationToken)
    {
        return await PatchAsync<T>(endPoint, null, cancellationToken);
    }

    /// <summary>
    /// Realiza o envio de um comando de PATCH para o endereço especificado na <see cref="UrlBase" /> de forma assíncrona.
    /// </summary>
    /// <param name="endPoint">O endpoint da url base</param>
    /// <param name="obj">O objeto que sera envia do no corpo da requisição</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <typeparam name="T">O tipo de dados de retorno</typeparam>
    /// <returns>Os dados</returns>
    public async Task<T> PatchAsync<T>(string endPoint, object obj, CancellationToken cancellationToken)
    {
        var result = await Send<T>(endPoint, obj, new HttpMethod("PATCH"), cancellationToken);
        return result;
    }

    private async Task Send(string endPoint, HttpMethod httpMethod, CancellationToken cancellationToken)
    {
        var content = string.Empty;
        HttpClient client = new();
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        endPoint = $"{UrlBase.TrimEnd('/')}/{endPoint.TrimStart('/')}";

        var request = new HttpRequestMessage(httpMethod, endPoint);

        var response = await client.SendAsync(request, cancellationToken);
        try
        {
            if (!response.IsSuccessStatusCode)
            {
                var haveToEnsureSuccessStatusCode = false;
                if (CheckIfStatusCodeIsError(response.StatusCode))
                {
                    haveToEnsureSuccessStatusCode = true;
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                }

                if (haveToEnsureSuccessStatusCode) response.EnsureSuccessStatusCode();
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw CreateHttpException(response, content, ex);
        }
    }

    private async Task<T> Send<T>(string endPoint, object obj, HttpMethod httpMethod, CancellationToken cancellationToken)
    {
        var content = string.Empty;
        T result = default;
        HttpClient client = new();
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

        endPoint = $"{UrlBase.TrimEnd('/')}/{endPoint.TrimStart('/')}";

        var request = new HttpRequestMessage(httpMethod, endPoint);

        if (obj != null)
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, MimeTypes.GetMimeType("json"));

        var response = await client.SendAsync(request, cancellationToken);
        try
        {
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                var haveToEnsureSuccessStatusCode = false;
                if (CheckIfStatusCodeIsError(response.StatusCode))
                {
                    haveToEnsureSuccessStatusCode = true;
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                }

                if (haveToEnsureSuccessStatusCode) response.EnsureSuccessStatusCode();
            }

            return result;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw CreateHttpException(response, content, ex);
        }
    }

    private bool CheckIfStatusCodeIsError(HttpStatusCode responseStatusCode)
    {
        return _requestAllowedStatusRange.Any(r => r == (int)responseStatusCode);
    }

    private static HttpException CreateHttpException(HttpResponseMessage response, string content, Exception ex)
    {
        Uri requestUri = null;
        string method = null;
        HttpRequestHeaders requestHeaders = null;
        var requestMessage = response.RequestMessage;
        if (requestMessage != null)
        {
            requestUri = requestMessage.RequestUri;
            method = requestMessage.Method.ToString();
            requestHeaders = requestMessage.Headers;
        }

        return new HttpException(
            requestUri,
            method,
            response.ReasonPhrase,
            requestHeaders,
            content,
            response.StatusCode,
            response.Headers,
            ex);
    }
}