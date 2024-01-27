namespace Simple.Mox.Models;

using System;

public record InstanceInfo
{
    public InstanceVersion? Version { get; set; }
    public InstanceNodes[]? Nodes { get; set; }
    public string[]? ClusterSections { get; set; }
    public string[]? AccessSections { get; set; }
}
public record InstanceVersion
{
    public string Version { get; set; }
    public string RepoId { get; set; }
    public string Release { get; set; }
}
public record InstanceNodes
{
    public string SSL_Fingerprint { get; set; }
    public string Id { get; set; }
    public string Type { get; set; }
    public string Level { get; set; }
    public string Node { get; set; }
    public string Status { get; set; }
}