namespace Simple.Mox;

using Simple.API;
using Simple.Mox.Models;
using Simple.Mox.Sources;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class Instance
{
    // Reference:
    // https://pve.proxmox.com/pve-docs/api-viewer/index.html#/nodes

    internal readonly ClientInfo api;
    internal readonly bool allowInsecureCertificates;

    public Instance(string url, AuthParams auth) : this(url, $"PVEAPIToken={auth.GetApiToken()}")
    {
        allowInsecureCertificates = auth.AllowInsecureCertificates;
    }
    public Instance(string url, string pveToken)
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback ??= certificateValidation;
        api = new ClientInfo(url, handler);

        api.SetAuthorization(pveToken);
    }
    private bool certificateValidation(HttpRequestMessage message,
                                           System.Security.Cryptography.X509Certificates.X509Certificate2? certificate,
                                           System.Security.Cryptography.X509Certificates.X509Chain? chain,
                                           System.Net.Security.SslPolicyErrors policy)
    {
        if (allowInsecureCertificates) return true;
        return policy == System.Net.Security.SslPolicyErrors.None;
    }

    public async Task<InstanceInfo> GetInfoAsync()
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
            Version = (await rVersion).Data.Data,
            Nodes = (await rNodes).Data.Data,
            ClusterSections = (await rCluster).Data.Data?.Select(o => o.Name).ToArray(),
            AccessSections = (await rAccess).Data.Data?.Select(o => o.Subdir).ToArray(),
        };
    }
    public async Task<ItemsInfo> GetItemsAsync()
    {
        List<ItemInfo> lst = new List<ItemInfo>();
        var rNodes = await api.GetAsync<ResponseData<InstanceNodes[]>>("/api2/json/nodes");
        rNodes.EnsureSuccessStatusCode();
        var nodes = rNodes.Data.Data;

        foreach (var nodeInfo in nodes)
        {
            var nodeInstance = await GetNodeAsync(nodeInfo);
            var lxcs = await nodeInstance.GetLXCsAsync();
            foreach (var lxc in lxcs)
            {
                lst.Add(new ItemInfo()
                {
                    VMID = lxc.vmid,
                    Name = lxc.name,
                    Status = lxc.status,
                    Type = lxc.type,
                    Node = nodeInfo.Node,
                    ItemDetails = lxc,
                    NodeInfo = nodeInfo,
                    NodeInstance = nodeInstance,
                });
            }

            var vms = await nodeInstance.GetVMsAsync();
            foreach (var vm in vms)
            {
                lst.Add(new ItemInfo()
                {
                    VMID = vm.vmid,
                    Name = vm.name,
                    Status = vm.status,
                    Type = "qemu",
                    Node = nodeInfo.Node,
                    ItemDetails = vm,
                    NodeInfo = nodeInfo,
                    NodeInstance = nodeInstance,
                });
            }
        }
        return new ItemsInfo { Items = lst.ToArray() };
    }

    public async Task<Node> GetNodeAsync(InstanceNodes node) => await GetNodeAsync(node.Node);
    public async Task<Node> GetNodeAsync(string nodeName)
    {
        var r = await api.GetAsync<ResponseData<ResponseNames[]>>($"/api2/json/nodes/{nodeName}");
        r.EnsureSuccessStatusCode();
        return new Node(this, nodeName, r.Data.Data);
    }

}