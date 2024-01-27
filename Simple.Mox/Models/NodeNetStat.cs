namespace Simple.Mox.Models;

using System;

public record NodeNetStat
{
    public string VMID { get; set; }
    public string In { get; set; }
    public string Out { get; set; }
    public string Dev { get; set; }
}
