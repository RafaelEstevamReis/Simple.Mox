namespace Simple.Mox.Models;

using System;

public record ItemInfo
{
    public int VMId { get; set; }
    public string Node { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public InstanceNodes NodeInstance { get; set; }
}
