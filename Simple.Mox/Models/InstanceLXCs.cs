namespace Simple.Mox.Models;

using System;

public record InstanceLXCs
{
    public int vmid { get; set; }
    public long diskread { get; set; }
    public long mem { get; set; }
    public long disk { get; set; }
    public string status { get; set; }
    public long diskwrite { get; set; }
    public long maxdisk { get; set; }
    public int cpus { get; set; }
    public string type { get; set; }
    public long pid { get; set; }
    public long netin { get; set; }
    public string name { get; set; }
    public long uptime { get; set; }
    public long netout { get; set; }
    public float cpu { get; set; }
    public long swap { get; set; }
    public long maxswap { get; set; }
    public long maxmem { get; set; }
    public string tags { get; set; }
}
