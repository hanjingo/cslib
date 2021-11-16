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
        file = file.Replace("/", "\\");
        if (!File.Exists(file))
            return;
        File.Delete(file);
    }
    public static void MkDir(string path) 
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
    public static void DelDir(string path, bool recursive = true)
    {
        if (Directory.Exists(path))
            Directory.Delete(path, recursive);
    }

    public static void CpDir(string src, 
                             string dst, 
                             string[] skipDirs = null, 
                             string[] skipExts = null)
    {
        DirectoryInfo source = new DirectoryInfo(src);
        DirectoryInfo target = new DirectoryInfo(dst);

        if (target.FullName.StartsWith(source.FullName))
            throw new System.Exception("can't copy sub dir by parent dir");
        if (source.Exists) 
            return;

        // skip the skipDirs
        int skipDirLength = skipDirs != null ? skipDirs.Length : 0 ;
        for (int j = 0; j < skipDirLength; ++j)
            if (src.Contains(skipDirs[j])) return;
        
        if (!target.Exists) target.Create();
        int skipExtLength = skipExts != null ? skipExts.Length : 0;

        // copy file in current dir
        FileInfo[] files = source.GetFiles();
        for (int i = 0; i < files.Length; ++i)
        {
            bool isSkiped = false;
            // skip file ext
            for (int j = 0; j < skipExtLength; ++j) 
            {
                if(files[i].Name.EndsWith(skipExts[j]))
                {
                    isSkiped = true; break;
                }
            }
            if (isSkiped)
                continue;

            File.Copy(files[i].FullName, Path.Combine(target.FullName, files[i].Name), true);
        }

        // copy dir in current dir
        DirectoryInfo[] dirs = source.GetDirectories();
        for (int j = 0; j < dirs.Length; ++j)
            CopyDir(dirs[j].FullName, Path.Combine(target.FullName, dirs[j].Name), skipDirs, skipExts);
    }

    public static void GetAllFiles(List<string> files, string dir)
    {
        string[] fs = Directory.GetFiles(dir);
        foreach (string f in fs)
            files.Add(f);

        string[] subs = Directory.GetDirectories(dir);
        foreach (string sub in subs)
            GetAllFiles(files, sub);
    }

    public static long GetFileSize(string path)
    {
        if (!File.Exists(path))
            return 0;
        FileInfo info = new FileInfo(path);
        return info.Length;
    }

    public static void WriteFile(string path, string content)
    {
        path = path.Replace("/", "\\");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            string dir = Path.GetDirectoryName(path);
            FilePath.MkDir(dir);
        }
        File.WriteAllText(path, content);
    }

    public static void WriteFile(string path, string content, Encoding encoding)
    {
        path = path.Replace("/", "\\");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            string dir = Path.GetDirectoryName(path);
            FilePath.MkDir(dir);
        }
        File.WriteAllText(path, content, encoding);
    }

    public static void WriteFile(string path, byte[] content)
    {
        path = path.Replace("/", "\\");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            string dir = Path.GetDirectoryName(path);
            FilePath.MkDir(dir);
        }
        File.WriteAllBytes(path, content);
    }

    public static string ReadFile(string path)
    {
        path = path.Replace("/", "\\");
        if (!File.Exists(path))
            return null;
        string content = File.ReadAllText(path);
        return content;
    }

    public static string ReadFile(string path, Encoding encoding)
    {
        path = path.Replace("/", "\\");
        if (!File.Exists(path))
            return null;
        string content = File.ReadAllText(path, encoding);
        return content;
    }

    public static string ReadFileByte(string path)
    {
        path = path.Replace("/", "\\");
        if (!File.Exists(path))
            return null;
        byte[] content = File.ReadAllBytes(path);
        return content;
    }

    public static string[] ReadAllLines(string path, Encoding encoding)
    {
        path = path.Replace("/", "\\");
        if (!File.Exists(path))
            return null;
        string[] content = File.ReadAllLines(path, encoding);
        return content;
    }

    public static string[] ReadAllLines(string path)
    {
        path = path.Replace("/", "\\");
        if (!File.Exists(path))
            return null;
        string[] content = File.ReadAllLines(path);
        return content;
    }
}