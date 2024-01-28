namespace Simple.Mox.Models;

using System;

public record InstanceLXCs : InstanceItem
{
    public string type { get; set; }
    public long swap { get; set; }
    public long maxswap { get; set; }
    public float fswap =>  swap / (float)maxswap;
}
