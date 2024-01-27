namespace Simple.Mox.Models;

using System;
public record LXCStatus
{
    public enum StatusActions
    {
        Reboot,
        Resume,
        Shutdown,
        Start,
        Stop,
        Suspend,
    }

    public Ha ha { get; set; }
    public long maxmem { get; set; }
    public int swap { get; set; }
    public int maxswap { get; set; }
    public float cpu { get; set; }
    public int netout { get; set; }
    public int uptime { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public int pid { get; set; }
    public int netin { get; set; }
    public int cpus { get; set; }
    public long maxdisk { get; set; }
    public int diskwrite { get; set; }
    public string status { get; set; }
    public long disk { get; set; }
    public int mem { get; set; }
    public int vmid { get; set; }
    public int diskread { get; set; }

    public class Ha
    {
        public int managed { get; set; }
    }
}
