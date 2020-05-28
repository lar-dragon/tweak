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
                    GetDirectoryInfoByGuid(new Guid("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}"))
                },
                {
                    EnumKnownFolder.Documents,
                    GetDirectoryInfoByGuid(new Guid("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}"))
                },
                {
                    EnumKnownFolder.Downloads,
                    GetDirectoryInfoByGuid(new Guid("{374DE290-123F-4565-9164-39C4925E467B}"))
                },
                {
                    EnumKnownFolder.Music,
                    GetDirectoryInfoByGuid(new Guid("{4BD8D571-6D19-48D3-BE97-422220080E43}"))
                },
                {
                    EnumKnownFolder.Pictures,
                    GetDirectoryInfoByGuid(new Guid("{33E28130-4E1E-4676-835A-98395C3BC3BB}"))
                },
                {
                    EnumKnownFolder.Temp,
                    new DirectoryInfo(Path.GetTempPath())
                },
                {
                    EnumKnownFolder.InternetCache,
                    GetDirectoryInfoByGuid(new Guid("{352481E8-33BE-4251-BA85-6007CAEDCF9D}"))
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