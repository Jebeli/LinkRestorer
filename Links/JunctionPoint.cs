namespace Links
{
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    internal static class JunctionPoint
    {
        private const string NonInterpretedPathPrefix = @"\??\";

        public static void CreateSymLink(string sourceDir, string targetDir)
        {
            NativeMethods.CreateSymbolicLink(sourceDir, targetDir, NativeMethods.TARGET_IS_DIRECTORY);
        }

        public static void CreateJunction(string junctionPoint, string targetDir, bool overwrite)
        {
            targetDir = Path.GetFullPath(targetDir);

            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);

            if (Directory.Exists(junctionPoint))
            {
                if (!overwrite)
                    throw new IOException("Directory already exists and overwrite parameter is false.");
            }
            else
            {
                Directory.CreateDirectory(junctionPoint);
            }

            using (SafeFileHandle handle = NativeMethods.OpenReparsePoint(junctionPoint, NativeMethods.EFileAccess.GenericWrite))
            {
                byte[] targetDirBytes = Encoding.Unicode.GetBytes(NonInterpretedPathPrefix + Path.GetFullPath(targetDir));

                NativeMethods.REPARSE_DATA_BUFFER reparseDataBuffer = new NativeMethods.REPARSE_DATA_BUFFER();

                reparseDataBuffer.ReparseTag = NativeMethods.IO_REPARSE_TAG_MOUNT_POINT;
                reparseDataBuffer.ReparseDataLength = (ushort)(targetDirBytes.Length + 12);
                reparseDataBuffer.SubstituteNameOffset = 0;
                reparseDataBuffer.SubstituteNameLength = (ushort)targetDirBytes.Length;
                reparseDataBuffer.PrintNameOffset = (ushort)(targetDirBytes.Length + 2);
                reparseDataBuffer.PrintNameLength = 0;
                reparseDataBuffer.PathBuffer = new byte[0x3ff0];
                Array.Copy(targetDirBytes, reparseDataBuffer.PathBuffer, targetDirBytes.Length);

                int inBufferSize = Marshal.SizeOf(reparseDataBuffer);
                IntPtr inBuffer = Marshal.AllocHGlobal(inBufferSize);

                try
                {
                    Marshal.StructureToPtr(reparseDataBuffer, inBuffer, false);

                    int bytesReturned;
                    bool result = NativeMethods.DeviceIoControl(handle.DangerousGetHandle(), NativeMethods.FSCTL_SET_REPARSE_POINT,
                        inBuffer, targetDirBytes.Length + 20, IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);

                    if (!result)
                        NativeMethods.ThrowLastWin32Error("Unable to create junction point.");
                }
                finally
                {
                    Marshal.FreeHGlobal(inBuffer);
                }
            }
        }
        public static bool Delete(string path)
        {
            return InternalDelete(path, GetLinkType(path));
        }

        public static bool InternalDelete(string path, LinkType type)
        {
            if (type == LinkType.None) return false;
            if (!Directory.Exists(path))
            {
                if (File.Exists(path))
                    throw new IOException("Path is not a junction point.");

                return false;
            }

            using (SafeFileHandle handle = NativeMethods.OpenReparsePoint(path, NativeMethods.EFileAccess.GenericWrite))
            {
                NativeMethods.REPARSE_DATA_BUFFER reparseDataBuffer = new NativeMethods.REPARSE_DATA_BUFFER();

                reparseDataBuffer.ReparseTag = type == LinkType.Junction ? NativeMethods.IO_REPARSE_TAG_MOUNT_POINT : NativeMethods.IO_REPARSE_TAG_SYM_LINK;
                reparseDataBuffer.ReparseDataLength = 0;
                reparseDataBuffer.PathBuffer = new byte[0x3ff0];

                int inBufferSize = Marshal.SizeOf(reparseDataBuffer);
                IntPtr inBuffer = Marshal.AllocHGlobal(inBufferSize);
                try
                {
                    Marshal.StructureToPtr(reparseDataBuffer, inBuffer, false);

                    int bytesReturned;
                    bool result = NativeMethods.DeviceIoControl(handle.DangerousGetHandle(), NativeMethods.FSCTL_DELETE_REPARSE_POINT,
                        inBuffer, 8, IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);

                    if (!result)
                        NativeMethods.ThrowLastWin32Error("Unable to delete junction point.");
                }
                finally
                {
                    Marshal.FreeHGlobal(inBuffer);
                }

                try
                {
                    Directory.Delete(path);
                    return true;
                }
                catch (IOException ex)
                {
                    throw new IOException("Unable to delete junction point.", ex);
                }
            }
        }

        public static bool Exists(string path)
        {
            return GetLinkType(path) != LinkType.None;
        }
        public static LinkType GetLinkType(string path)
        {
            if (!Directory.Exists(path))
                return LinkType.None;

            using (SafeFileHandle handle = NativeMethods.OpenReparsePoint(path, NativeMethods.EFileAccess.GenericRead))
            {
                LinkType type;
                string target = InternalGetTarget(handle, out type);
                return type;
            }
        }

        public static Link GetLink(string path)
        {
            LinkType type;
            using (SafeFileHandle handle = NativeMethods.OpenReparsePoint(path, NativeMethods.EFileAccess.GenericRead))
            {
                string target = InternalGetTarget(handle, out type);
                if (target != null && type != LinkType.None)
                {
                    return new Link(path, target, type);
                }
            }
            return null;
        }
        private static string InternalGetTarget(SafeFileHandle handle, out LinkType type)
        {
            int outBufferSize = Marshal.SizeOf(typeof(NativeMethods.REPARSE_DATA_BUFFER));
            IntPtr outBuffer = Marshal.AllocHGlobal(outBufferSize);
            type = LinkType.None;
            try
            {
                int bytesReturned;
                bool result = NativeMethods.DeviceIoControl(handle.DangerousGetHandle(), NativeMethods.FSCTL_GET_REPARSE_POINT,
                    IntPtr.Zero, 0, outBuffer, outBufferSize, out bytesReturned, IntPtr.Zero);

                if (!result)
                {
                    int error = Marshal.GetLastWin32Error();
                    if (error == NativeMethods.ERROR_NOT_A_REPARSE_POINT)
                        return null;

                    NativeMethods.ThrowLastWin32Error("Unable to get information about junction point.");
                }

                NativeMethods.REPARSE_DATA_BUFFER reparseDataBuffer = (NativeMethods.REPARSE_DATA_BUFFER)
                    Marshal.PtrToStructure(outBuffer, typeof(NativeMethods.REPARSE_DATA_BUFFER));


                if (reparseDataBuffer.ReparseTag == NativeMethods.IO_REPARSE_TAG_MOUNT_POINT)
                {
                    type = LinkType.Junction;
                    string targetDir = Encoding.Unicode.GetString(reparseDataBuffer.PathBuffer,
                        reparseDataBuffer.SubstituteNameOffset, reparseDataBuffer.SubstituteNameLength);

                    if (targetDir.StartsWith(NonInterpretedPathPrefix))
                        targetDir = targetDir.Substring(NonInterpretedPathPrefix.Length);

                    return targetDir;

                }
                else if (reparseDataBuffer.ReparseTag == NativeMethods.IO_REPARSE_TAG_SYM_LINK)
                {
                    type = LinkType.Symbolic;
                    string targetDir = Encoding.Unicode.GetString(reparseDataBuffer.PathBuffer,
                        reparseDataBuffer.PrintNameOffset + 4, reparseDataBuffer.PrintNameLength);

                    if (targetDir.StartsWith(NonInterpretedPathPrefix))
                        targetDir = targetDir.Substring(NonInterpretedPathPrefix.Length);

                    return targetDir;

                }

                return null;
            }
            finally
            {
                Marshal.FreeHGlobal(outBuffer);
            }
        }

    }

}
