namespace Simple.Mox.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

public record LXCRRD
{
    public enum DataSet
    {
        maxcpu,
        cpu,
        maxmem,
        mem,
        maxdisk,
        disk,
        netin,
        netout,
        diskread,
        diskwrite,
    }

    public int maxcpu { get; set; }
    public long swaptotal { get; set; }
    public long swapused { get; set; }
    public float fswap => swapused / (float)swaptotal;

    public float cpu { get; set; }
    public float netout { get; set; }
    public float netin { get; set; }
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime time { get; set; }
    public long memtotal { get; set; }
    public long roottotal { get; set; }
    public float rootused { get; set; }
    public float froot => rootused / (float)roottotal;
    public long memused { get; set; }
    public float iowait { get; set; }
    public float loadavg { get; set; }
}
public record LXCRRD_StringImage
{
    public string Image { get; set; }
}
