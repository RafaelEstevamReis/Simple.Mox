namespace Simple.Mox;

using System;

public static class DateTimeExtensions
{
    public static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    public static long GetEpochMili(this DateTime dt)
    {
#if NETSTANDARD2_0
        return (long)(dt - UnixEpoch).TotalMilliseconds;
#else
        return (long)(dt - DateTime.UnixEpoch).TotalMilliseconds;
#endif
    }
    public static long GetEpoch(this DateTime dt)
    {
#if NETSTANDARD2_0
        return (long)(dt - UnixEpoch).TotalSeconds;
#else
        return (long)(dt - DateTime.UnixEpoch).TotalSeconds;
#endif
    }
}
