public static class IdGenerator
{
    public static long AppId { private get; set; }
    private static ushort value;
    public static long Gen()
    {
        long time = Time.Now();
        return (AppId << 48) + (time << 16) + ++value;
    }
    public static int ParseAppId(long id)
    {
        return (int)(id >> 48);
    }
}