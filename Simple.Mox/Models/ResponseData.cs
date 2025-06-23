namespace Simple.Mox.Models;

using System;

public record ResponseData<T>
{
    public T? Data { get; set; }
}
public record ResponseFolders
{
    public string Subdir { get; set; }
}
public record ResponseNames
{
    public string Name { get; set; }
}
public class ResponseStorage
{
    public string storage { get; set; }
    public string thinpool { get; set; }
    public string type { get; set; }
    public string vgname { get; set; }
    public string content { get; set; }
    public string digest { get; set; }
    public string path { get; set; }
}
