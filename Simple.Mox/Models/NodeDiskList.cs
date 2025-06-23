namespace Simple.Mox.Models;

using System;

public record NodeDiskList
{
    public int? rpm { get; set; }
    public string by_id_link { get; set; }
    public int gpt { get; set; }
    public int osdid { get; set; }
    public long size { get; set; }
    public string model { get; set; }
    public string used { get; set; }
    public string serial { get; set; }
    public string health { get; set; }
    public string vendor { get; set; }
    public string type { get; set; }
    public string wearout { get; set; }
    public object osdidlist { get; set; }
    public string wwn { get; set; }
    public string devpath { get; set; }
}

public class NodeDiskSmart
{
    public string health { get; set; }
    public string type { get; set; }
    public Attribute[] attributes { get; set; }

    public class Attribute
    {
        public int value { get; set; }
        public int worst { get; set; }
        public string raw { get; set; }
        public string fail { get; set; }
        public int threshold { get; set; }
        public string name { get; set; }
        public int normalized { get; set; }
        public string id { get; set; }
        public string flags { get; set; }
    }
}
