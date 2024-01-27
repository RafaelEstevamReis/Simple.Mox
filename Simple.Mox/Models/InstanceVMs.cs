namespace Simple.Mox.Models;

using System;

public record InstanceVMs
{
    public long netin { get; set; }
    public int cpus { get; set; }
    public long uptime { get; set; }
    public string name { get; set; }
    public long mem { get; set; }
    public long disk { get; set; }
    public long diskread { get; set; }
    public int vmid { get; set; }
    public long diskwrite { get; set; }
    public long maxdisk { get; set; }
    public string status { get; set; }
    public long maxmem { get; set; }
    public float cpu { get; set; }
    public long netout { get; set; }
    public long pid { get; set; }
    public long balloon_min { get; set; }
    public long shares { get; set; }
}
