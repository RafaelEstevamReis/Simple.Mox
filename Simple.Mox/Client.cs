using Simple.API;
using System.Net.Http;
using System.Threading.Tasks;

namespace Simple.Mox;

public class Client
{
    private readonly ClientInfo api;
    private readonly AuthParams auth;

    public Client(string url, AuthParams auth)
    {
        this.auth = auth;

        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback ??= certificateValidation;
        api = new ClientInfo(url, handler);

        api.SetAuthorization($"PVEAPIToken={auth.GetApiToken()}");
    }
    private bool certificateValidation(HttpRequestMessage message,
                                           System.Security.Cryptography.X509Certificates.X509Certificate2? certificate,
                                           System.Security.Cryptography.X509Certificates.X509Chain? chain,
                                           System.Net.Security.SslPolicyErrors policy)
    {
        if (auth.AllowInsecureCertificates) return true;

        return policy == System.Net.Security.SslPolicyErrors.None;
    }


}