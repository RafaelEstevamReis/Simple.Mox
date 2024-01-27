namespace Simple.Mox.Models;

using System;

public record InstanceVMs : InstanceItem
{
    public long balloon_min { get; set; }
    public long shares { get; set; }
}
