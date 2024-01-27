namespace Simple.Mox.Sources;

using Simple.Mox.Models;
using System.Linq;
using System.Threading.Tasks;

public class LXC
{
    public Node Node { get; }
    public int VMID { get; }

    private string[] items;

    internal LXC(Node node, int vmid, ResponseFolders[] data)
    {
        Node = node;
        VMID = vmid;
        items = data.Select(o => o.Subdir).ToArray();
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

    public async Task<LXCRRD[]?> GetStatistics(NodeRRD.TimeFrame timeFrame)
    {
        var r = await get<ResponseData<LXCRRD[]>>($"rrddata?timeframe={timeFrame}");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<byte[]> GetStatisticsImage(NodeRRD.TimeFrame timeFrame, LXCRRD.DataSet dataset)
    {
        var r = await get<ResponseData<LXCRRD_StringImage>>($"rrd?timeframe={timeFrame}&ds={dataset}");
        r.EnsureSuccessStatusCode();
        return Node.ImageEncoding.GetBytes(r.Data.Data.Image);
    }

    public async Task<LXCStatus?> GetStatus()
    {
        var r = await get<ResponseData<LXCStatus>>("status/current");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task<string?> ChangeState(LXCStatus.StatusActions action)
    {
        var r = await post<ResponseData<string>>($"status/{action.ToString().ToLower()}", null);
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

}
