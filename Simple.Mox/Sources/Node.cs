namespace Simple.Mox.Sources;

using Simple.Mox.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    private static readonly Encoding ImageEncoding = Encoding.GetEncoding("iso-8859-1");
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

    public async Task<NodeRRD[]?> GetStatistics(NodeRRD.TimeFrame timeFrame)
    {
        var r = await get<ResponseData<NodeRRD[]>>($"rrddata?timeframe={timeFrame}");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }
    public async Task<byte[]> GetStatisticsImage(NodeRRD.TimeFrame timeFrame, NodeRRD.DataSet dataset)
    {
        var r = await get<ResponseData<NodeRRD_StringImage>>($"rrd?timeframe={timeFrame}&ds={dataset}");
        r.EnsureSuccessStatusCode();
        return ImageEncoding.GetBytes(r.Data.Data.Image);
    }

    public async Task<NodeStatus?> GetStatus()
    {
        var r = await get<ResponseData<NodeStatus>>("status");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task<string> Report()
    {
        var r = await get<ResponseData<string>>("report");
        r.EnsureSuccessStatusCode();
        return r.Data.Data;
    }

    public async Task WakeOnLan()
    {
        var r = await post<string>("wakeonlan", null);
        r.EnsureSuccessStatusCode();
    }
    public async Task RebootNode()
    {
        var r = await post<string>("status", new { command = "reboot" });
        r.EnsureSuccessStatusCode();
    }
    public async Task ShutdownNode()
    {
        var r = await post<string>("status", new { command = "shutdown" });
        r.EnsureSuccessStatusCode();
    }

}
