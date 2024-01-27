namespace Simple.Mox.Models;

using System;

public record InstanceLXCs
{
    public int vmid { get; set; }
    public int diskread { get; set; }
    public long mem { get; set; }
    public long disk { get; set; }
    public string status { get; set; }
    public int diskwrite { get; set; }
    public long maxdisk { get; set; }
    public int cpus { get; set; }
    public string type { get; set; }
    public int pid { get; set; }
    public int netin { get; set; }
    public string name { get; set; }
    public int uptime { get; set; }
    public int netout { get; set; }
    public float cpu { get; set; }
    public int swap { get; set; }
    public long maxswap { get; set; }
    public long maxmem { get; set; }
    public string tags { get; set; }
}
