namespace Simple.Mox.Models;

using Simple.Mox.Sources;
using System;
using System.Linq;

public record ItemsInfo
{
    public ItemInfo this[int vmid] => Items.FirstOrDefault(o => o.VMID == vmid) ?? throw new ArgumentException("ID not found");
    public ItemInfo this[string name] => Items.FirstOrDefault(o => o.Name == name) ?? throw new ArgumentException("ID not found");
    public ItemInfo this[InstanceItem item] => Items.FirstOrDefault(o => o.VMID == item.vmid) ?? throw new ArgumentException("ID not found");

    public ItemInfo[] Items { get; set; } = [];
}

public record ItemInfoBase
{
    public int VMID { get; set; }
    public string Node { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool IsVM { get; set; }
    public bool IsLXC => !IsVM;
    public bool IsRunning => Status == "running";
    public bool IsStopped => Status == "stopped";

    public Node NodeInstance { get; set; } = null!;
    public VM AsVM()
    {
        if (Type != "qemu") throw new InvalidOperationException("Is not a VM");
        return NodeInstance.GetVM(VMID);
    }
    public LXC AsLXC()
    {
        if (Type == "qemu") throw new InvalidOperationException("Is not a LXC");
        return NodeInstance.GetLXC(VMID);
    }
}
public record ItemInfo : ItemInfoBase
{
    public InstanceNodes NodeInfo { get; set; } = null!;
    public InstanceItem ItemDetails { get; set; } = null!;
}
