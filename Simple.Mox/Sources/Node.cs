namespace Simple.Mox.Sources;

using Simple.Mox.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    internal static readonly Encoding ImageEncoding = Encoding.GetEncoding("iso-8859-1");
    public Instance Instance { get; }
    public string NodeName { get; }

    private string[] items;

    internal Node(Instance instance, string nodeName, Models.ResponseNames[] data)
    {
        Instance = instance;
        NodeName = nodeName;
        items = data.Select(o => o.Name).ToArray();
    }

    private async Task<API.Response<T>> get<T>(string service)
    {
        return await Instance.api.GetAsync<T>($"/api2/json/nodes/{NodeName}/{service}");
    }
    private async Task<API.Response<T>> post<T>(string service, object? value)
    {
        return await Instance.api.PostAsync<T>($"/api2/json/nodes/{NodeName}/{service}", value);
    }

    public async Task<NodeRRD[]?> GetStatisticsAsync(NodeRRD.TimeFrame timeFrame)
    {
        var r = await get<ResponseData<NodeRRD[]>>($"rrddata?timeframe={timeFrame}");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<byte[]> GetStatisticsImageAsync(NodeRRD.TimeFrame timeFrame, NodeRRD.DataSet dataset)
    {
        var r = await get<ResponseData<NodeRRD_StringImage>>($"rrd?timeframe={timeFrame}&ds={dataset}");
        r.EnsureSuccessStatusCode();
        return ImageEncoding.GetBytes(r.Data.Data.Image);
    }

    public async Task<NodeStatus?> GetStatusAsync()
    {
        var r = await get<ResponseData<NodeStatus>>("status");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task<string> GenerateReportAsync()
    {
        var r = await get<ResponseData<string>>("report");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task<InstanceLXCs[]?> GetLXCsAsync()
    {
        var r = await get<ResponseData<InstanceLXCs[]>>("lxc");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<LXC> GetLXCAsync(InstanceLXCs lxc) => await GetLXCAsync(lxc.vmid);
    public async Task<LXC> GetLXCAsync(int vmid)
    {
        var r = await get<ResponseData<ResponseFolders[]>>($"lxc/{vmid}");
        r.EnsureSuccessStatusCode();
        return new LXC(this, vmid, r.Data.Data);
    }

    public async Task<InstanceVMs[]?> GetVMsAsync()
    {
        var r = await get<ResponseData<InstanceVMs[]>>("qemu");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<VM> GetVMAsync(InstanceVMs vm) => await GetVMAsync(vm.vmid);
    public async Task<VM> GetVMAsync(int vmid)
    {
        var r = await get<ResponseData<ResponseFolders[]>>($"qemu/{vmid}");
        r.EnsureSuccessStatusCode();
        return new VM(this, vmid, r.Data.Data);
    }

    public async Task WakeOnLanAsync()
    {
        var r = await post<string>("wakeonlan", null);
        r.EnsureSuccessStatusCode();
    }
    public async Task RebootNodeAsync()
    {
        var r = await post<string>("status", new { command = "reboot" });
        r.EnsureSuccessStatusCode();
    }
    public async Task ShutdownNodeAsync()
    {
        var r = await post<string>("status", new { command = "shutdown" });
        r.EnsureSuccessStatusCode();
    }

}
