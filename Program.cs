using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Linq;

namespace Tweak
{
    internal static class Program
    {
        public const string TaskName = "Tweak";

        private static readonly SecurityIdentifier User = WindowsIdentity.GetCurrent().User;
        
        private static readonly Dictionary<EnumKnownRegistry, RegistryValue> RegistryValues
            = new Dictionary<EnumKnownRegistry, RegistryValue>
            {
                {
                    EnumKnownRegistry.PasswordHash,
                    new RegistryValue(
                        "Software\\Tweak\\PasswordHash",
                        ""
                    )
                },
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

        private static readonly Dictionary<EnumKnownDirectories, DirectoryInfo> DirectoryInfos
            = new Dictionary<EnumKnownDirectories, DirectoryInfo>
            {
                {
                    EnumKnownDirectories.Desktop,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                },
                {
                    EnumKnownDirectories.Documents,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                },
                {
                    EnumKnownDirectories.Downloads,
                    GetDirectoryInfoByGuid(new Guid("{374DE290-123F-4565-9164-39C4925E467B}"))
                },
                {
                    EnumKnownDirectories.Music,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
                },
                {
                    EnumKnownDirectories.Pictures,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
                },
                {
                    EnumKnownDirectories.Temp,
                    new DirectoryInfo(Path.GetTempPath())
                },
                {
                    EnumKnownDirectories.InternetCache,
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))
                }
            };
        
        public static readonly FileSystemAccessRule AccessRule = User == null ? null : new FileSystemAccessRule(
            User,
            FileSystemRights.CreateFiles | FileSystemRights.CreateDirectories | FileSystemRights.WriteData,
            AccessControlType.Deny
        );

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Parser(args).Form.Show();
            Application.Run();
        }
        
        public static bool HasAccessRule(EnumKnownDirectories enumKnownDirectories)
        {
            return GetDirectoryInfo(enumKnownDirectories)
                .GetAccessControl()
                .GetAccessRules(true, false, User.GetType())
                .Cast<FileSystemAccessRule>()
                .Any(
                    item => item.FileSystemRights == AccessRule.FileSystemRights
                           && item.AccessControlType == AccessRule.AccessControlType
                           && item.IdentityReference == AccessRule.IdentityReference
                );
        }

        public static string GetUuid()
        {
            var process = new Process
            {
                EnableRaisingEvents = false,
                StartInfo =
                {
                    FileName = "cmd.exe",
                    Arguments = "/c wmic csproduct get uuid",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
            
            return process.StandardOutput.ReadToEnd();
        }

        public static string ComputeHash(string plainText, string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];
            for (var i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            
            for (var i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
            
            var hashBytes = new MD5CryptoServiceProvider().ComputeHash(plainTextWithSaltBytes);
            var hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];
            for (var i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];
            
            for (var i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
            
            return Convert.ToBase64String(hashWithSaltBytes);
        }

        public static RegistryValue GetRegistryValue(EnumKnownRegistry enumKnownRegistry)
        {
            return RegistryValues[enumKnownRegistry];
        }

        public static DirectoryInfo GetDirectoryInfo(EnumKnownDirectories enumKnownDirectories)
        {
            return DirectoryInfos[enumKnownDirectories];
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