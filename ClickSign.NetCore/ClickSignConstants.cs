using ClickSign.NetCore.Enumerators;

namespace ClickSign.NetCore;

/// <summary>
/// Classe de constantes da biblioteca.
/// </summary>
internal abstract class ClickSignConstants
{
    /// <summary>
    /// URL padrão do serviço de sandbox.
    /// </summary>
    private const string SANDBOX_BASE_URL = "https://sandbox.clicksign.com";

    /// <summary>
    /// Url padrão do serviço de produção.
    /// </summary>
    private const string PRODUCTION_BASE_URL = "https://app.clicksign.com";

    /// <summary>
    /// Método que traz a url correta de acordo com a versão e ambiente definidos.
    /// </summary>
    /// <param name="environment">Ambiente de execução. <see cref="ApiEnvironment" /></param>
    /// <returns></returns>
    internal static string GetBaseUri(ApiEnvironment environment)
    {
        return environment switch
        {
            ApiEnvironment.Sandbox => $"{SANDBOX_BASE_URL}/api/",
            ApiEnvironment.Production => $"{PRODUCTION_BASE_URL}/api/",
            _ => $"{SANDBOX_BASE_URL}/api/"
        };
    }
}