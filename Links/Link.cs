namespace Links
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml.Serialization;
    public enum LinkType
    {
        None = 0,
        Symbolic = 1,
        Junction = 2,
        MountPoint = 3
    }
    [XmlRoot]
    public class Link : IEquatable<Link>
    {
        private string source;
        private string destination;
        private LinkType type;
        private static IList<string> ignoredDirs = IgnoredDirs();

        public Link()
        {
        }
        public Link(string source, string destination, LinkType type)
        {
            this.source = source;
            this.destination = destination;
            this.type = type;
        }
        [XmlElement]
        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        [XmlElement]
        public LinkType Type
        {
            get { return type; }
            set { type = value; }
        }
        [XmlElement]
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public bool RestoreLink()
        {
            if (!CheckLink())
            {
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }
                if (Directory.Exists(source))
                {
                    if (!CopyToDestination())
                    {
                        RenameDir(source);
                    }
                }
                Create();
            }
            return true;
        }

        private static void RenameDir(string dir)
        {
            if (Directory.Exists(dir))
            {
                string newDir = dir + "_old";
                int count = 1;
                while (Directory.Exists(newDir))
                {
                    newDir += "" + count;
                    count++;
                }
                NativeMethods.SHFILEOPSTRUCT fileOP = new NativeMethods.SHFILEOPSTRUCT();
                fileOP.hNameMappings = IntPtr.Zero;
                fileOP.hwnd = IntPtr.Zero;
                fileOP.lpszProgressTitle = "Rename Directory";
                fileOP.pFrom = dir + "\0";
                fileOP.pTo = newDir + "\0";
                fileOP.wFunc = NativeMethods.FileFuncFlags.FO_RENAME;
                fileOP.fFlags = NativeMethods.FILEOP_FLAGS.FOF_SILENT;
                int ret = NativeMethods.SHFileOperation(ref fileOP);
            }
        }

        private bool CopyToDestination()
        {
            bool ok = true;
            var originalDirectories = Directory.GetDirectories(source, "*", SearchOption.TopDirectoryOnly);
            var originalFiles = Directory.GetFiles(source, "*", SearchOption.AllDirectories);
            Array.ForEach(originalFiles, (originalFileLocation) =>
            {
                FileInfo originalFile = new FileInfo(originalFileLocation);
                FileInfo destFile = new FileInfo(originalFileLocation.Replace(source, destination));
                if (destFile.Exists)
                {
                    if (originalFile.LastWriteTime > destFile.LastWriteTime)
                    {
                        originalFile.CopyTo(destFile.FullName, true);
                    }
                    originalFile.Delete();
                }
                else
                {
                    Directory.CreateDirectory(destFile.DirectoryName);
                    originalFile.CopyTo(destFile.FullName);
                }
            }
            );
            Array.ForEach(originalDirectories, (originalDirectoryLocation) =>
            {
                DirectoryInfo originalDir = new DirectoryInfo(originalDirectoryLocation);
                try
                {
                    originalDir.Delete(true);
                }
                catch (Exception)
                {
                    ok = false;
                }
            }
            );
            return ok;
        }

        public bool DeleteLink()
        {
            return JunctionPoint.Delete(source);
        }

        public bool CheckLink()
        {
            if (Directory.Exists(source) && Directory.Exists(destination))
            {
                return Equals(JunctionPoint.GetLink(source));
            }
            return false;
        }

        public override string ToString()
        {
            return $"{type}:{source} <==> {destination}";
        }

        public static IList<Link> FindLinks(string path)
        {
            List<Link> list = new List<Link>();
            if (Directory.Exists(path))
            {
                AddLinks(path, list);
            }
            return list;
        }

        private static IList<string> IgnoredDirs()
        {
            List<string> list = new List<string>();
            list.Add(@"C:\$");
            list.Add(@"C:\Users");
            list.Add(@"C:\inetpub");
            list.Add(@"C:\PerfLogs");
            list.Add(@"C:\Logs");
            list.Add(@"C:\ProgramData");
            list.Add(@"C:\Recovery");
            list.Add(@"C:\Windows\System32");
            list.Add(@"C:\Windows\SysWOW64");
            list.Add(@"C:\Windows\Temp");
            list.Add(@"C:\Windows\security");
            list.Add(@"C:\Windows\Prefetch");
            list.Add(@"C:\Windows\Logs");
            list.Add(@"C:\Windows\CSC");
            list.Add(@"C:\Windows\ServiceProfiles");
            list.Add(@"C:\Windows\ModemLogs");
            list.Add(@"C:\Windows\LiveKernelReports");
            list.Add(@"C:\Windows\InfusedApps");
            list.Add(@"C:\Windows\appcompat");
            list.Add(@"C:\Program Files\WindowsApps");
            list.Add(@"C:\System Volume Information");
            list.Add(@"C:\Windows\Resources");
            return list;
        }

        private static bool Ignore(string dir)
        {
            foreach (string s in ignoredDirs)
            {
                if (dir.StartsWith(s, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private static void AddLinks(string path, List<Link> list)
        {
            if (Ignore(path)) return;
            foreach (var dir in Directory.GetDirectories(path))
            {
                if (!Ignore(dir))
                {
                    try
                    {
                        Link link = JunctionPoint.GetLink(dir);
                        if (link != null)
                        {
                            list.Add(link);
                        }
                        else
                        {
                            AddLinks(dir, list);
                        }
                    }
                    catch (IOException)
                    {
                    }
                }
            }
        }

        public void Create()
        {
            try
            {
                if (type == LinkType.Junction)
                {
                    JunctionPoint.CreateJunction(source, destination, true);
                }
                else if (type == LinkType.Symbolic)
                {
                    JunctionPoint.CreateSymLink(source, destination);
                }
            }
            catch (Exception)
            {
                CreateWithMkLink(source, destination, type);
            }
        }

        public static void CreateWithMkLink(string sourceDir, string targetDir, LinkType type)
        {
            sourceDir = Path.GetFullPath(sourceDir);
            if (Directory.Exists(sourceDir))
            {
                Directory.Delete(sourceDir);
            }
            targetDir = Path.GetFullPath(targetDir);
            string mklinkSwitch = type == LinkType.Junction ? "/J" : "/D";
            string args = $"/c MKLINK {mklinkSwitch} \"{sourceDir}\" \"{targetDir}\"";
            var p = Process.Start("CMD.exe", args);
            p.WaitForExit();
        }

        public bool Equals(Link other)
        {
            if (other != null)
            {
                return type == other.type &&
                    string.Equals(source, other.source, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(destination, other.destination, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
