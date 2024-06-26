using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ClickSign.NetCore.Exceptions;
using ClickSign.NetCore.Extensions;
using ClickSign.NetCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClickSign.NetCore.Tests;

[TestClass]
public class DocumentsTests
{
    public DocumentsTests()
    {
        Guid apiKey = Guid.Parse("e3183ab4-a828-472f-abe5-0c7f973422cd");
        Client = new ClickSignClient(apiKey);
    }

    private ClickSignClient Client { get; }

    [TestMethod]
    public void GetAllDocs()
    {
        IEnumerable<Document> result = Client.Get();

        Assert.IsNotNull(result, "Nenhum documento encontrado");

        JsonSerializer.Serialize(result);
    }

    [TestMethod]
    public void GetDoc()
    {
        Guid doc = Guid.Parse("5d5c834b-3a5d-43a3-add5-025cf1867f63");
        Document result = Client.Get(doc);

        Assert.IsNotNull(result, "Nenhum documento encontrado");

        JsonSerializer.Serialize(result);
    }

    [TestMethod]
    public void UploadFile()
    {
        const string docFile = "document-test.pdf";
        if (!File.Exists(docFile))
            Assert.Fail("Arquivo de testes não localizado");
        UploadRequest request = new();
        request.SetContent(docFile);
        request.Path = $"/document_{DateTime.Now:yyyy-MM-ddTHH:mm:ss}.pdf";

        try
        {
            Document result = Client.Upload(request);
            JsonSerializer.Serialize(result);
        }
        catch (ClickSignRequestException ex)
        {
            Assert.Fail(ex.ToString());
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.GetBaseException().Message);
        }
    }
}