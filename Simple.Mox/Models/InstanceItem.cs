namespace Simple.Mox.Models;

using System;

public record InstanceItem
{
    public int vmid { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public bool IsRunning => status == "running";
    public bool IsStopped => status == "stopped";

    public int cpus { get; set; }
    public float cpu { get; set; }
    public long uptime { get; set; }
    public long disk { get; set; }
    public long diskread { get; set; }
    public long diskwrite { get; set; }
    public long maxdisk { get; set; }
    public long mem { get; set; }
    public long maxmem { get; set; }
    public float fmem => mem / (float)maxmem;
    public long netin { get; set; }
    public long netout { get; set; }
    public long pid { get; set; }
}
