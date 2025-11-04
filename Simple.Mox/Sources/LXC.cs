namespace Simple.Mox.Sources;

using Simple.Mox.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LXC
{
    public Node Node { get; }
    public int VMID { get; }

    internal LXC(Node node, int vmid)
    {
        Node = node;
        VMID = vmid;
    }

    private async Task<API.Response<T>> get<T>(string service)
    {
        var api = Node.Instance.api;
        return await api.GetAsync<T>($"/api2/json/nodes/{Node.NodeName}/lxc/{VMID}/{service}");
    }
    private async Task<API.Response<T>> post<T>(string service, object? value)
    {
        var api = Node.Instance.api;
        return await api.PostAsync<T>($"/api2/json/nodes/{Node.NodeName}/lxc/{VMID}/{service}", value);
    }

    public async Task<LXCRRD[]?> GetStatisticsAsync(NodeRRD.TimeFrame timeFrame)
    {
        var r = await get<ResponseData<LXCRRD[]>>($"rrddata?timeframe={timeFrame}");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<byte[]> GetStatisticsImageAsync(NodeRRD.TimeFrame timeFrame, LXCRRD.DataSet dataset)
    {
        var r = await get<ResponseData<LXCRRD_StringImage>>($"rrd?timeframe={timeFrame}&ds={dataset}");
        r.EnsureSuccessStatusCode();
        return Node.ImageEncoding.GetBytes(r.Data.Data.Image);
    }

    public async Task<ResponseData<Dictionary<string, string>>> GetConfigAsync(bool pending = false)
    {
        var r = await get<ResponseData<Dictionary<string, string>>>($"config?current={(pending ? "0" : "1")}"); // INVERTED!!!
        r.EnsureSuccessStatusCode();
        return r.Data;
    }
    public async Task<LXCStatus?> GetStatusAsync()
    {
        var r = await get<ResponseData<LXCStatus>>("status/current");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<string?> ChangeStateAsync(LXCStatus.StatusActions action)
    {
        var r = await post<ResponseData<string>>($"status/{action.ToString().ToLower()}", null);
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task<string> MigrateAsync(string targetNode, bool liveMigration = false)
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
