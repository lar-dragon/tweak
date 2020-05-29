using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Tweak
{
    internal static class Program
    {
        public const string TaskName = "Tweak";
        
        private static readonly Dictionary<EnumKnownRegistry, RegistryValue> RegistryValues
            = new Dictionary<EnumKnownRegistry, RegistryValue>
            {
                {
                    EnumKnownRegistry.NoThemesTab,
                    new RegistryValue(
                        "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\NoThemesTab",
                        (uint) 0
                    )
                },
                {
                    EnumKnownRegistry.NoChangingWallPaper,
                    new RegistryValue(
                        "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\ActiveDesktop\\NoChangingWallPaper",
                        (uint) 0
                    )
                }
            };

        private static readonly Dictionary<EnumKnownFolder, DirectoryInfo> DirectoryInfos
            = new Dictionary<EnumKnownFolder, DirectoryInfo>
            {
                {
                    EnumKnownFolder.Desktop,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                },
                {
                    EnumKnownFolder.Documents,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                },
                {
                    EnumKnownFolder.Downloads,
                    GetDirectoryInfoByGuid(new Guid("{374DE290-123F-4565-9164-39C4925E467B}"))
                },
                {
                    EnumKnownFolder.Music,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                },
                {
                    EnumKnownFolder.Pictures,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                },
                {
                    EnumKnownFolder.Temp,
                    new DirectoryInfo(Path.GetTempPath())
                },
                {
                    EnumKnownFolder.InternetCache,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))
                    //GetDirectoryInfoByGuid(new Guid("{352481E8-33BE-4251-BA85-6007CAEDCF9D}"))
                }
            };

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Parser(args).Form.Show();
            Application.Run();
        }
        
        public static RegistryValue GetRegistryValue(EnumKnownRegistry enumKnownRegistry)
        {
            return RegistryValues[enumKnownRegistry];
        }

        public static DirectoryInfo GetDirectoryInfo(EnumKnownFolder enumKnownFolder)
        {
            return DirectoryInfos[enumKnownFolder];
        }

        private static DirectoryInfo GetDirectoryInfoByGuid(Guid guid, bool defaultUser = false)
        {
            var result = SHGetKnownFolderPath(
                guid,
                0x00004000,
                new IntPtr(defaultUser ? -1 : 0),
                out var outPath
            );

            if (result < 0)
                throw new ExternalException(
                    "Unable to retrieve the known folder path. It may not be available on this system.",
                    result
                );
            
            var path = Marshal.PtrToStringUni(outPath);
            Marshal.FreeCoTaskMem(outPath);
            
            if (path == null)
                throw new ExternalException(
                    "Undefined the known folder path. It may not be available on this system.",
                    result
                );
            
            return new DirectoryInfo(path);

        }
        
        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            uint dwFlags,
            IntPtr hToken,
            out IntPtr ppszPath
        );
    }
}