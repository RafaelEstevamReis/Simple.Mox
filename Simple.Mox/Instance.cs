namespace Simple.Mox;

using Simple.API;
using Simple.Mox.Models;
using Simple.Mox.Sources;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class Instance
{
    // Reference:
    // https://pve.proxmox.com/pve-docs/api-viewer/index.html#/nodes

    internal readonly ClientInfo api;
    internal readonly AuthParams auth;

    public Instance(string url, AuthParams auth)
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
        var rBase = await api.GetAsync<ResponseData<ResponseFolders[]>>("/api2/json/");
        rBase.EnsureSuccessStatusCode();

        var rVersion = api.GetAsync<ResponseData<InstanceVersion>>("/api2/json/version");
        var rCluster = api.GetAsync<ResponseData<ResponseNames[]>>("/api2/json/cluster");
        var rNodes = api.GetAsync<ResponseData<InstanceNodes[]>>("/api2/json/nodes");
        //var r4 = await api.GetAsync<string>("/api2/json/storage");
        var rAccess = api.GetAsync<ResponseData<ResponseFolders[]>>("/api2/json/access");
        //var r6 = await api.GetAsync<string>("/api2/json/pools");
        
        return new InstanceInfo()
        {
            Version = (await  rVersion).Data.Data,
            Nodes = (await rNodes).Data.Data,
            ClusterSections = (await rCluster).Data.Data?.Select(o => o.Name).ToArray(),
            AccessSections = (await rAccess).Data.Data?.Select(o => o.Subdir).ToArray(),
        };
    }

    public async Task<Node> GetNode(InstanceNodes node) => await GetNode(node.Node);
    public async Task<Node> GetNode(string nodeName)
    {    
        var r = await api.GetAsync<ResponseData<ResponseNames[]>>($"/api2/json/nodes/{nodeName}");
        r.EnsureSuccessStatusCode();
        return new Node(this, nodeName, r.Data.Data);
    }

}