namespace Simple.Mox.Models;

using System;

public record NodeUpdate
{
    public string Package { get; set; }
    public string Description { get; set; }
    public string Section { get; set; }
    public string Arch { get; set; }
    public string Origin { get; set; }
    public string Title { get; set; }
    public string Priority { get; set; }
    public string OldVersion { get; set; }
    public string Version { get; set; }
}

