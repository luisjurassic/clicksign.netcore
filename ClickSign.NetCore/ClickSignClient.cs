using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClickSign.NetCore.Enumerators;
using ClickSign.NetCore.Exceptions;
using ClickSign.NetCore.Models;
using ClickSign.NetCore.Models.Internals;
using ClickSign.NetCoreUtils;

namespace ClickSign.NetCore;

/// <summary>
/// Classe que atua como cliente para os serviços ClickSign.
/// </summary>
public class ClickSignClient
{
    /// <summary>
    /// Método construtor.
    /// </summary>
    /// <param name="apiKey">Chave de api usada na autenticação do serviço.</param>
    /// <param name="environment">Ambiente ao qual se destinarão as requisições. <see cref="ApiEnvironment" /></param>
    public ClickSignClient(Guid apiKey, ApiEnvironment environment = ApiEnvironment.Sandbox)
    {
        ApiKey = apiKey;
        ApiEnvironment = environment;
    }

    /// <summary>
    /// Chave de api usada na autenticação do serviço.
    /// </summary>
    private Guid ApiKey { get; }

    /// <summary>
    /// Tipo de ambiente
    /// </summary>
    private ApiEnvironment ApiEnvironment { get; }

    /// <summary>
    /// Cliente rest responsável pelo gerenciamento das requisições.
    /// </summary>
    private ApiHelper Client => new(ClickSignConstants.GetBaseUri(ApiEnvironment));

    /// <summary>
    /// Método que efetua o envio de um novo documento para assinatura no serviço.
    /// </summary>
    /// <param name="request">Requisição de upload de novo arquivo. <see cref="UploadRequest" /></param>
    /// <returns>Dados do documento criado no ambiente.</returns>
    public Document Upload(UploadRequest request)
    {
        Document result = UploadAsync(request).Result;
        return result;
    }

    /// <summary>
    /// Método que efetua o envio de um novo documento para assinatura no serviço de forma assíncrona.
    /// </summary>
    /// <param name="request">Requisição de upload de novo arquivo. <see cref="UploadRequest" /></param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do documento criado no ambiente.</returns>
    public async Task<Document> UploadAsync(UploadRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalUploadRequest uploadRequest = new(request);

            InternalResponse result = await Client.PostAsync<InternalResponse>($"v1/documents?access_token={ApiKey}", uploadRequest, cancellationToken);

            return result.Document;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua a busca de todos os documentos.
    /// </summary>
    /// <returns>Lista contendo os dados de todos os documentos do serviço.</returns>
    public IEnumerable<Document> Get()
    {
        IEnumerable<Document> result = GetAsync().Result;
        return result;
    }

    /// <summary>
    /// Método que efetua a busca de todos os documentos de forma assíncrona.
    /// </summary>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Lista contendo os dados de todos os documentos do serviço.</returns>
    public async Task<IEnumerable<Document>> GetAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.GetAsync<InternalResponse>($"v1/documents?access_token={ApiKey}", cancellationToken);

            return result.Documents;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua a busca de um documento previamente cadastrado no serviço.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <returns>Dados do documento associado à chave informada. <see cref="Document" /></returns>
    public Document Get(Guid key)
    {
        Document result = GetAsync(key).Result;
        return result;
    }

    /// <summary>
    /// Método que efetua a busca de um documento previamente cadastrado no serviço de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do documento associado à chave informada. <see cref="Document" /></returns>
    public async Task<Document> GetAsync(Guid key, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.GetAsync<InternalResponse>($"v1/documents/{key}?access_token={ApiKey}", cancellationToken);

            return result.Document;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua a finalização de um documento ativo.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <returns>Dados do documento associado à chave informada. <see cref="Document" /></returns>
    public Document Finalize(Guid key)
    {
        Document result = FinalizeAsync(key).Result;
        return result;
    }

    /// <summary>
    /// Método que efetua a finalização de um documento ativo de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do documento associado à chave informada. <see cref="Document" /></returns>
    public async Task<Document> FinalizeAsync(Guid key, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.PatchAsync<InternalResponse>($"v1/documents/{key}/finish?access_token={ApiKey}", cancellationToken);

            return result.Document;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua o cancelamento de um documento ativo.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <returns>Dados do documento associado à chave informada. <see cref="Document" /></returns>
    public Document Cancel(Guid key)
    {
        Document result = CancelAsync(key).Result;
        return result;
    }

    /// <summary>
    /// Método que efetua o cancelamento de um documento ativo de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do documento associado à chave informada. <see cref="Document" /></returns>
    public async Task<Document> CancelAsync(Guid key, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.PatchAsync<InternalResponse>($"v1/documents/{key}/cancel?access_token={ApiKey}", cancellationToken);

            return result.Document;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua a duplicação de um documento ativo.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <returns>Dados do documento duplicado. <see cref="Document" /></returns>
    public Document Duplicate(Guid key)
    {
        Document result = DuplicateAsync(key).Result;
        return result;
    }

    /// <summary>
    /// Método que efetua a duplicação de um documento ativo de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave única do documento.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do documento duplicado. <see cref="Document" /></returns>
    public async Task<Document> DuplicateAsync(Guid key, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.PostAsync<InternalResponse>($"v1/documents/{key}/duplicate?access_token={ApiKey}", cancellationToken);

            return result.Document;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que traz os dados de um determinado assinante.
    /// </summary>
    /// <param name="key">Chave única do assinante.</param>
    /// <returns>Dados do assinante referentes à chave informada. <see cref="Signer" /></returns>
    public Signer GetSigner(Guid key)
    {
        Signer result = GetSignerAsync(key).Result;
        return result;
    }

    /// <summary>
    /// Método que traz os dados de um determinado assinante de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave única do assinante.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do assinante referentes à chave informada. Veja <see cref="Signer" />.</returns>
    public async Task<Signer> GetSignerAsync(Guid key, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.GetAsync<InternalResponse>($"v2/signers/{key}?access_token={ApiKey}", cancellationToken);

            return result.Signer;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua o cadastro de um novo assinante.
    /// </summary>
    /// <param name="request">Dados de requisição de criação do novo assinante. <see cref="CreateSignerRequest" /></param>
    /// <returns>Dados do assinante recém criado. <see cref="Signer" /></returns>
    public Signer CreateSigner(CreateSignerRequest request)
    {
        Signer result = CreateSignerAsync(request).Result;
        return result;
    }

    /// <summary>
    /// Método que efetua o cadastro de um novo assinante de forma assíncrona.
    /// </summary>
    /// <param name="request">Dados de requisição de criação do novo assinante. <see cref="CreateSignerRequest" /></param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados do assinante recém criado. <see cref="Signer" /></returns>
    public async Task<Signer> CreateSignerAsync(CreateSignerRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalCreateSignerRequest createRequest = new(request);
            InternalResponse result = await Client.PostAsync<InternalResponse>($"v1/signers?access_token={ApiKey}", createRequest, cancellationToken);

            return result.Signer;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua a associação de um assinante à um documento à ser assinado.
    /// </summary>
    /// <param name="request">Dados da requisição de adição de assinante ao documento. <see cref="AddSignerRequest" /></param>
    /// <returns>Resposta da adição do assinante ao documento. <see cref="AddSignerResponse" /></returns>
    public AddSignerResponse AddSignerToDocument(AddSignerRequest request)
    {
        AddSignerResponse result = AddSignerToDocumentAsync(request).Result;
        return result;
    }

    /// <summary>
    /// Método que efetua a associação de um assinante à um documento à ser assinado de forma assíncrona.
    /// </summary>
    /// <param name="request">Dados da requisição de adição de assinante ao documento. <see cref="AddSignerRequest" /></param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Resposta da adição do assinante ao documento. <see cref="AddSignerResponse" /></returns>
    public async Task<AddSignerResponse> AddSignerToDocumentAsync(AddSignerRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalAddSignerDocumentRequest addRequest = new(request);
            InternalResponse result = await Client.PostAsync<InternalResponse>($"v1/lists?access_token={ApiKey}", addRequest, cancellationToken);

            return result.List;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua a remoção de um assinante de um documento.
    /// </summary>
    /// <param name="key">Chave da associação do assinante ao documento.</param>
    public void RemoveSignerFromDocument(Guid key)
    {
        RemoveSignerFromDocumentAsync(key).Wait();
    }

    /// <summary>
    /// Método que efetua a remoção de um assinante de um documento de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave da associação do assinante ao documento.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Tarefa assíncrona.</returns>
    public async Task RemoveSignerFromDocumentAsync(Guid key, CancellationToken cancellationToken = default)
    {
        try
        {
            await Client.DeleteAsync($"v1/lists/{key}?access_token={ApiKey}", cancellationToken);
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que cria uma assinatura em lotes de documentos com um assinante em comum.
    /// </summary>
    /// <param name="request">Dados da requisição de criação da assinatura em lotes. Veja <see cref="BatchRequest" /></param>
    /// <returns>Dados da assinatura em lotes criada. Veja <see cref="BatchResponse" />.</returns>
    public void SignerToDocument(SignerRequest request)
    {
        SignerToDocumentAsync(request).Wait();
    }

    /// <summary>
    /// Método que cria uma assinatura em lotes de documentos com um assinante em comum de forma assíncrona.
    /// </summary>
    /// <param name="request">Dados da requisição de criação da assinatura em lotes. Veja <see cref="BatchRequest" />.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da assinatura em lotes criada. Veja <see cref="BatchResponse" />.</returns>
    public async Task SignerToDocumentAsync(SignerRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            await Client.PostAsync<InternalResponse>($"v1/sign?access_token={ApiKey}", request, cancellationToken);
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua o envio de um lembrete de assinatura de um documento.
    /// </summary>
    /// <param name="request">Dados da requisição de envio de notificação. Veja <see cref="NotificationRequest" />.</param>
    public void SendNotification(NotificationRequest request)
    {
        SendNotificationAsync(request).Wait();
    }

    /// <summary>
    /// Método que efetua o envio de um lembrete de assinatura de um documento de forma assíncrona.
    /// </summary>
    /// <param name="request">Dados da requisição de envio de notificação. Veja <see cref="NotificationRequest" />.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Tarefa assíncrona.</returns>
    public async Task SendNotificationAsync(NotificationRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var path = request?.Type switch
            {
                NotificationType.Whatsapp => "notify_by_whatsapp",
                NotificationType.Sms => "notify_by_sms",
                _ => "notifications"
            };
            await Client.PostAsync<InternalResponse>($"v1/{path}?access_token={ApiKey}", request, cancellationToken);
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que efetua o cadastro de um hook.
    /// </summary>
    /// <param name="request">Dados do hook. Veja <see cref="HooksRequest" />.</param>
    public void CreateHooks(HooksRequest request)
    {
        CreateHooksAsync(request).Wait();
    }

    /// <summary>
    /// Método que efetua o cadastro de um hook de forma assíncrona.
    /// </summary>
    /// <param name="request">Dados do hook. Veja <see cref="HooksRequest" />.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Tarefa assíncrona.</returns>
    public async Task CreateHooksAsync(HooksRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            await Client.PostAsync<InternalResponse>($"v2/webhooks?access_token={ApiKey}", request, cancellationToken);
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que consulta o cadastro de um hook.
    /// </summary>
    /// <returns>Lista contendo os dados de todos os webhooks.</returns>
    public IEnumerable<HooksRequest> GetHooks()
    {
        IEnumerable<HooksRequest> result = GetHooksAsync().Result;
        return result;
    }

    /// <summary>
    /// Método que consulta o cadastro de um hook de forma assíncrona.
    /// </summary>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Lista contendo os dados de todos os webhooks.</returns>
    public async Task<IEnumerable<HooksRequest>> GetHooksAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.GetAsync<InternalResponse>($"v2/webhooks?access_token={ApiKey}", cancellationToken);

            return result.Webhooks;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }

    /// <summary>
    /// Método que de consulta o cadastro da conta.
    /// </summary>
    /// <returns>Dados da conta.</returns>
    public Account GetAccount()
    {
        Account result = GetAccountAsync().Result;
        return result;
    }

    /// <summary>
    /// Método que de consulta o cadastro da conta de forma assíncrona.
    /// </summary>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da conta.</returns>
    public async Task<Account> GetAccountAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            InternalResponse result = await Client.GetAsync<InternalResponse>($"v1/accounts?access_token={ApiKey}", cancellationToken);

            return result.Account;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }


    /// <summary>
    /// Método que cria uma assinatura em lotes de documentos com um assinante em comum.
    /// </summary>
    /// <param name="request">Dados da requisição de criação da assinatura em lotes. Veja <see cref="BatchRequest" /></param>
    /// <returns>Dados da assinatura em lotes criada. Veja <see cref="BatchResponse" />.</returns>
    public BatchResponse CreateBatch(BatchRequest request)
    {
        BatchResponse result = CreateBatchAsync(request).Result;
        return result;
    }

    /// <summary>
    /// Método que cria uma assinatura em lotes de documentos com um assinante em comum de forma assíncrona.
    /// </summary>
    /// <param name="request">Dados da requisição de criação da assinatura em lotes. Veja <see cref="BatchRequest" />.</param>
    /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
    /// <returns>Dados da assinatura em lotes criada. Veja <see cref="BatchResponse" />.</returns>
    public async Task<BatchResponse> CreateBatchAsync(BatchRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            InternalBatchRequest batchRequest = new(request);
            BatchResponse result = await Client.PostAsync<BatchResponse>($"v1/batches?access_token={ApiKey}", batchRequest, cancellationToken);

            return result;
        }
        catch (HttpException ex)
        {
            throw new ClickSignRequestException(ex.Content);
        }
        catch (Exception ex)
        {
            throw new ClickSignException(ex.Message);
        }
    }
}