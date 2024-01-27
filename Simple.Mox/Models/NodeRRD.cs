namespace Simple.Mox.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;


public record NodeRRD
{
    public enum TimeFrame
    {
        hour,
        day,
        week,
        month,
        year
    }
    public enum DataSet
    {
        loadavg,
        maxcpu,
        cpu,
        iowait,
        memtotal,
        memused,
        swaptotal,
        swapused,
        roottotal,
        rootused,
        netin,
        netout,
    }

    public int maxcpu { get; set; }
    public long swaptotal { get; set; }
    public int swapused { get; set; }
    public float cpu { get; set; }
    public float netout { get; set; }
    public float netin { get; set; }
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime time { get; set; }
    public long memtotal { get; set; }
    public long roottotal { get; set; }
    public float rootused { get; set; }
    public long memused { get; set; }
    public float iowait { get; set; }
    public float loadavg { get; set; }
}
public record NodeRRD_StringImage
{
    public string Image { get; set; }
}
