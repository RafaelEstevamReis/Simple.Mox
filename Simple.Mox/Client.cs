using Simple.API;
using Simple.Mox.Models;
using System.Linq;
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


    public async Task<InstanceInfo> GetInfo()
    {
        //var rBase = await api.GetAsync<ResponseData<ResponseFolders[]>>("/api2/json/");
        var rVersion = await api.GetAsync<ResponseData<InstanceVersion>>("/api2/json/version");
        var rCluster = await api.GetAsync<ResponseData<ResponseNames[]>>("/api2/json/cluster");
        var rNodes = await api.GetAsync<ResponseData<InstanceNodes[]>>("/api2/json/nodes");
        //var r4 = await api.GetAsync<string>("/api2/json/storage");
        var rAccess = await api.GetAsync<ResponseData<ResponseFolders[]>>("/api2/json/access");
        //var r6 = await api.GetAsync<string>("/api2/json/pools");
        
        return new InstanceInfo()
        {
            Version = rVersion.Data.Data,
            Nodes = rNodes.Data.Data,
            ClusterSections = rCluster.Data.Data?.Select(o => o.Name).ToArray(),
            AccessSections = rAccess.Data.Data?.Select(o => o.Subdir).ToArray(),
        };
    }

}