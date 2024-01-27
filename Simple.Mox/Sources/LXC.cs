namespace Simple.Mox.Sources;

using System.Linq;
using System.Threading.Tasks;

public class LXC
{
    public Node Node { get; }
    public int VMID { get; }

    private string[] items;

    internal LXC(Node node, int vmid, Models.ResponseNames[] data)
    {
        Node = node;
        VMID = vmid;
        items = data.Select(o => o.Name).ToArray();
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

}
