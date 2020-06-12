using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Tweak
{
    internal static class Program
    {
        public const string TaskName = "Tweak";
        
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
        
        public static string GetUuid()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "CMD.exe",
                    Arguments = "/C wmic csproduct get UUID",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            process.Start();
            process.WaitForExit();
            
            return process.StandardOutput.ReadToEnd();
        }

        public static string ComputeHash(
            string plainText,
            ref string salt,
            EnumHashAlgorithm hashAlgorithm = EnumHashAlgorithm.Md56
        )
        {
            byte[] saltBytes;
            if (salt == null)
            {
                saltBytes = new byte[new Random().Next(4, 8)];
                var rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(saltBytes);
                salt = Convert.ToString(saltBytes);
            }
            else
            {
                saltBytes = Encoding.UTF8.GetBytes(salt);
            }
            
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];
            for (var i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            
            for (var i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
            
            HashAlgorithm hash;
            switch (hashAlgorithm)
            {
                case EnumHashAlgorithm.Sha1:
                    hash = new SHA1Managed();
                    break;
                case EnumHashAlgorithm.Sha256:
                    hash = new SHA256Managed();
                    break;
                case EnumHashAlgorithm.Sha384:
                    hash = new SHA384Managed();
                    break;
                case EnumHashAlgorithm.Sha512:
                    hash = new SHA512Managed();
                    break;
                case EnumHashAlgorithm.Md56:
                    hash = new MD5CryptoServiceProvider();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(hashAlgorithm), hashAlgorithm, null);
            }
            
            var hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
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