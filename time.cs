using System;

public static class Time
{
    private static readonly long epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

    public static long Now() { return (DateTime.UtcNow.Ticks - epoch) / 10000; }
    public static long NowSeconds() { return (DateTime.UtcNow.Ticks - epoch) / 10000000; }
    public static DateTime FromMs(long ms)
    {
        DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        return start.AddMilliseconds(ms);
    }
    public static long ToMs(DateTime tm)
    {
        DateTime start = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, 0), TimeZoneInfo.Local);
        return (tm.Ticks - start.Ticks) / 10000;
    }

    public static string TimeStamp()
    {
        return (long)DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds;
    }

    public static string CountDown(int seconds)
    {
        if (seconds >= 3600)
        {
            var hour    = seconds / 3600;
            var minute  = seconds % 3600 / 60;
            var sec     = seconds % 3600 % 60;
            return hour.ToString().PadLeft(2, '0') + ":" 
                    + minute.ToString().PadLeft(2, '0') + ":"
                    + sec.ToString().PadLeft(2, '0');
        }
        else if (seconds >= 60)
        {
            var minute  = seconds / 60;
            var sec     = seconds % 60;
            return "00:" + minute.ToString().PadLeft(2, '0') + ":"
                    + sec.ToString().PadLeft(2, '0');
        }
        else if (seconds < 60)
        {
            return "00:00" + seconds.ToString();
        }
        return "";
    }
}