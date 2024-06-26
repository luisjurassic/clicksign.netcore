using System;
using System.Text.Json;
using ClickSign.NetCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClickSign.NetCore.Tests;

[TestClass]
public class SignersTests
{
    public SignersTests()
    {
        Guid apiKey = Guid.Parse("e3183ab4-a828-472f-abe5-0c7f973422cd");
        Client = new ClickSignClient(apiKey);
    }

    private ClickSignClient Client { get; }

    [TestMethod]
    public void CreateSigner()
    {
        CreateSignerRequest signerReq = new CreateSignerRequest
        {
            Birthday = new DateTime(1988, 10, 1),
            HasDocumentation = true,
            Documentation = "19489068055",
            Email = "test@dev.com.br",
            Name = "Test User",
            Phone = "4799988554433"
        };
        Signer result = Client.CreateSigner(signerReq);
        
        Assert.IsNotNull(result, "Erro ao criar o signatário");

        JsonSerializer.Serialize(result);
    }

    [TestMethod]
    public void AddSignerToDoc()
    {
        Guid docId = Guid.Parse("a700f02c-c6fd-428f-b6c2-50a04da7bbb3");
        Guid signerId = Guid.Parse("0b4952df-97fd-4ac4-8395-87999c05e7ab");
        AddSignerRequest addSigner = new AddSignerRequest
        {
            DocumentKey = docId,
            SignerKey = signerId
        };

        AddSignerResponse result = Client.AddSignerToDocument(addSigner);
        
        Assert.IsNotNull(result, "Erro ao adicionar o signatário ao documento");
        JsonSerializer.Serialize(result);
    }
}