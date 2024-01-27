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
}
