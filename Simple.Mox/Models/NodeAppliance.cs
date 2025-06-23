namespace Simple.Mox.Models;

using System;

public record NodeAppliance
{
    public string architecture { get; set; }
    public string manageurl { get; set; }
    public string section { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public string os { get; set; }
    public string headline { get; set; }
    public string template { get; set; }
    public string source { get; set; }
    public string sha512sum { get; set; }
    public string type { get; set; }
    public string version { get; set; }
    public string infopage { get; set; }
    public string package { get; set; }
    public string md5sum { get; set; }
    public string maintainer { get; set; }
}
