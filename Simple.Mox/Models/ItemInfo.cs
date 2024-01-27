namespace Simple.Mox.Models;

using System.Linq;

public record ItemsInfo
{
    public ItemInfo? this[int vmid] => Items.FirstOrDefault(o => o.VMId == vmid);
    public ItemInfo? this[string name] => Items.FirstOrDefault(o => o.Name == name);

    public ItemInfo[] Items { get; set; } = System.Array.Empty<ItemInfo>();
}

public record ItemInfo
{
    public int VMId { get; set; }
    public string Node { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public InstanceNodes NodeInstance { get; set; }
    public InstanceItem ItemDetails { get; internal set; }
}
