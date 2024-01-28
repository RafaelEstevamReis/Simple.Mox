namespace Simple.Mox.Models;

using System;

public record InstanceVMs : InstanceItem
{
    public long balloon_min { get; set; }
    public long shares { get; set; }
    public bool agent { get; set; }
    public bool spice { get; set; }
    public string clipboard { get; set; }
    public string qmpstatus { get; set; }
}
