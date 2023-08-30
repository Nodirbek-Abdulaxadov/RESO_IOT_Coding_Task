namespace Core;

public static class Extensions
{
    public static DateTime ToDateTime(this long unixTimeStamp)
    {
        var dateTime = new DateTime( 1970, 1, 1, 0, 0, 0, 0,
                                          DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(unixTimeStamp)
                           .ToLocalTime();
        return dateTime;
    }
}