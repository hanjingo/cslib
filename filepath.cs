using System.Text;
using System.IO;
using System.Collections.Generic;

public class FilePath
{
    public static bool FileExists(string file) { return File.Exists(path); }
    public static bool PathExists(string path) { return Directory.Exists(path); }
    public static string Directory(string path) { return Path.GetDirectoryName(path); }
    public static string FileNameWithoutExt(string path) { return Path.GetFileNameWithoutExtension(path); }
    public static string CopyFile(string src, string dst) 
    {
        src = src.Replace("/", "\\");
        if (!File.Exists(src)) { return; }
        
        dst = dst.Replace("/", "\\");
        if (File.Exists(dst)) { File.Delete(dst); }

        FilePath.MkDir(Path.GetDirectoryName(dst));
        File.Copy(src, dst);
    }
    public static void DeleteFile(string file)
    {
        
    }
    public static void MkDir(string path) 
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
}