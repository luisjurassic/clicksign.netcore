using Newtonsoft.Json;

namespace ClickSign.NetCore.Models;

/// <summary>
/// Classe que representa uma conta.
/// </summary>
public class Account
{
    /// <summary>
    /// Nome da conta
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Chave da conta
    /// </summary>
    [JsonProperty("key")]
    public string Key { get; set; }

    /// <summary>
    /// Emails dos administradores da conta
    /// </summary>
    [JsonProperty("admins")]
    public string[] Admins { get; set; }
}