using System.Text;

public static class Byte
{
    public static string Hex(this byte b) { return b.ToString("X2"); }
    public static string Hex(this byte[] bytes) 
    {
        StringBuilder builder = new StringBuilder();
        foreach (byte b in bytes) { builder.Append(b.ToString("X2")); }
        return builder.ToString();
    }
    public static string Hex(this byte[] bytes, string fmt)
    {
        StringBuilder builder = new StringBuilder();
        foreach (byte b in bytes) { builder.Append(b.ToString(fmt)); }
        return builder.ToString();
    }
    public static string Hex(this byte[] bytes, int offset, int count)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = offset; i < offset + count; ++i) { builder.Append(bytes[i].ToString("X2")); }
        return builder.ToString();
    }

    public static string Str(this byte[] bytes) 
    { 
        return Encoding.Default.GetString(bytes); 
    }
    public static string Str(this byte[] bytes, int idx, int count) 
    { 
        return Encoding.Default.GetString(bytes, index, count); 
    }

    public static string Utf8ToStr(this byte[] bytes) 
    { 
        return Encoding.UTF8.GetString(bytes); 
    }
    public static string Utf8ToStr(this byte[] bytes, int index, int count) 
    {
        return Encoding.BigEndianUnicode.GetString(bytes); 
    }

    public static string Utf16BigEndianToStr(this byte[] bytes) 
    { 
        return Encoding.BigEndianUnicode.GetString(bytes); 
    }
    public static string Utf16BigEndianToStr(this byte[] bytes, int idx, int count) 
    { 
        return Encoding.BigEndianUnicode.GetString(bytes, idx, count);
    }

    public static void Write(this byte[] bytes, int offset, uint num)
    {
        bytes[offset]     = (byte)(num & 0xff);
        bytes[offset + 1] = (byte)((num & 0xff00) >> 8);
        bytes[offset + 2] = (byte)((num & 0xff0000) >> 16);
        bytes[offset + 3] = (byte)((num & 0xff000000) >> 24);
    }
    public static void Write(this byte[] bytes, int offset, int num)
    {
        bytes[offset]     = (byte)(num & 0xff);
        bytes[offset + 1] = (byte)((num & 0xff00) >> 8);
        bytes[offset + 2] = (byte)((num & 0xff0000) >> 16);
        bytes[offset + 3] = (byte)((num & 0xff000000) >> 24);
    }
    public static void Write(this byte[] bytes, int offset, byte num) { bytes[offset] = num; }
    public static void Write(this byte[] bytes, int offset, short num)
    {
        bytes[offset] = (byte)(num & 0xff);
        bytes[offset + 1] = (byte)((num & 0xff00) >> 8);
    }
    public static void Write(this byte[] bytes, int offset, ushort num)
    {
        bytes[offset] = (byte)(num & 0xff);
        bytes[offset + 1] = (byte)((num & 0xff00) >> 8);
    }
}