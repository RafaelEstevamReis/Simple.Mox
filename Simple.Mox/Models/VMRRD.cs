namespace Simple.Mox.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

public record VMRRD
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

    public float cpu { get; set; }
    public float netout { get; set; }
    public long maxmem { get; set; }
    public int maxcpu { get; set; }
    public float mem { get; set; }
    public int disk { get; set; }
    public float diskread { get; set; }
    public float diskwrite { get; set; }
    public long maxdisk { get; set; }
    public float netin { get; set; }
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public int time { get; set; }
}
public record VMRRD_StringImage
{
    public string Image { get; set; }
}
