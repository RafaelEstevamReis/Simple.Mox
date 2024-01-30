using System;
using System.IO;

namespace Simple.Mox;

public class AuthParams
{
    public string User { get; set; } = string.Empty;
    public string Realm { get; set; } = "pam";
    public string TokenName { get; set; } = string.Empty;
    public string TokenSecret { get; set; } = string.Empty;

    public bool AllowInsecureCertificates { get; set; } = false;

    public string GetApiToken()
        => $"{User}@{Realm}!{TokenName}={TokenSecret}";

    public void Save(string path)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
        File.WriteAllText(path, json);
    }
    public static AuthParams Load(string path)
    {
        var json = File.ReadAllText(path);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthParams>(json) ?? throw new NullReferenceException();
    }
}
