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
