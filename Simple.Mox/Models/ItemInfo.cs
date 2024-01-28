namespace Simple.Mox.Models;

using Simple.Mox.Sources;
using System;
using System.Linq;
using System.Threading.Tasks;

public record ItemsInfo
{
    public ItemInfo this[int vmid] => Items.FirstOrDefault(o => o.VMID == vmid) ?? throw new ArgumentException("ID not found");
    public ItemInfo this[string name] => Items.FirstOrDefault(o => o.Name == name) ?? throw new ArgumentException("ID not found");
    public ItemInfo this[InstanceItem item] => Items.FirstOrDefault(o => o.VMID == item.vmid) ?? throw new ArgumentException("ID not found");

    public ItemInfo[] Items { get; set; } = System.Array.Empty<ItemInfo>();
}

public record ItemInfo
{
    public int VMID { get; set; }
    public string Node { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public InstanceNodes NodeInfo { get; set; }
    public InstanceItem ItemDetails { get; internal set; }
    public Node NodeInstance { get; set; }
    public bool IsVM { get; set; }
    public bool IsLXC => !IsVM;
    public bool IsRunning => Status == "running";
    public bool IsStopped => Status == "stopped";

    public async Task<VM> AsVMAsync()
    {
        if (Type != "qemu") throw new InvalidOperationException("Is not a VM");
        return await NodeInstance.GetVMAsync(VMID);
    }
    public async Task<LXC> AsLXCAsync()
    {
        if (Type == "qemu") throw new InvalidOperationException("Is not a LXC");
        return await NodeInstance.GetLXCAsync(VMID);
    }

}
