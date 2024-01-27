namespace Simple.Mox.Sources;

using Simple.Mox.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class VM
{
    public Node Node { get; }
    public int VMID { get; }

    private string[] items;

    internal VM(Node node, int vmid, ResponseFolders[] data)
    {
        Node = node;
        VMID = vmid;
        items = data.Select(o => o.Subdir).ToArray();
    }

    private async Task<API.Response<T>> get<T>(string service)
    {
        var api = Node.Instance.api;
        return await api.GetAsync<T>($"/api2/json/nodes/{Node.NodeName}/qemu/{VMID}/{service}");
    }
    private async Task<API.Response<T>> post<T>(string service, object? value)
    {
        var api = Node.Instance.api;
        return await api.PostAsync<T>($"/api2/json/nodes/{Node.NodeName}/qemu/{VMID}/{service}", value);
    }

    public async Task<VMRRD[]?> GetStatistics(NodeRRD.TimeFrame timeFrame)
    {
        var r = await get<ResponseData<VMRRD[]>>($"rrddata?timeframe={timeFrame}");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<byte[]> GetStatisticsImage(NodeRRD.TimeFrame timeFrame, VMRRD.DataSet dataset)
    {
        var r = await get<ResponseData<VMRRD_StringImage>>($"rrd?timeframe={timeFrame}&ds={dataset}");
        r.EnsureSuccessStatusCode();
        return Node.ImageEncoding.GetBytes(r.Data.Data.Image);
    }

    public async Task<VMStatus?> GetStatus()
    {
        var r = await get<ResponseData<VMStatus>>("status/current");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task<string?> ChangeState(VMStatus.StatusActions action)
    {
        var r = await post<ResponseData<string>>($"status/{action.ToString().ToLower()}", null);
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task<string> Migrate(string targetNode, bool liveMigration = false)
    {
        var r = await post<ResponseData<string>>($"migrate", new
        {
            target = targetNode,
            online = liveMigration ? "1" : "0",
        });
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
}
