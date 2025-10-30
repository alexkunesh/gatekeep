using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Gatekeep
{
    /// <summary>
    /// Utility class full of Windows API calls that are relevant.
    /// </summary>
    internal static class Win32
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCommandLine();


        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyIcon(IntPtr hIcon);

        public static string GetExecutableDisplayName(string filePath)
        {
            // Not a raw Win32 utility function... but this location is fitting enough.
            var versionInfo = FileVersionInfo.GetVersionInfo(filePath);
            return versionInfo.FileDescription ?? Path.GetFileName(filePath);
        }

        public static BitmapSource GetExecutableIcon(string filePath)
        {
            SHFILEINFO info = new SHFILEINFO();
            SHGetFileInfo(filePath, 0, ref info, (uint)Marshal.SizeOf(info), 0x100 /* SHGFI_ICON */);
            var image = Imaging.CreateBitmapSourceFromHIcon(info.hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DestroyIcon(info.hIcon); // We're in native land and need to free resources :)
            return image;
        }
    }
}
