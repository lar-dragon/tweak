using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;

namespace Tweak
{
    public class TaskDirectory : ITask
    {
        private readonly DirectoryInfo _directoryInfo;
        
        private readonly IEnumerable<FileInfo> _files;

        public ulong Weight { get; }

        public bool Readonly { get; set; }
        
        public bool Delete { get; set; }
        
        public bool ByDate { get; set; }
        
        public bool Move { get; set; }
        
        public double Older { get; set; } = -7;

        public TaskDirectory(DirectoryInfo directoryInfo)
        {
            _directoryInfo = directoryInfo;
            _files = directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories);
            Weight = _files.Aggregate<FileInfo, ulong>(0, (current, fileInfo) => current + (ulong) fileInfo.Length);
        }
        
        public void Apply()
        {
            var date = DateTime.Now.AddDays(Older);
            File.SetAttributes(_directoryInfo.FullName, _directoryInfo.Attributes & ~FileAttributes.ReadOnly);
            foreach (var file in _files)
            {
                if (
                    file.Attributes.HasFlag(FileAttributes.ReadOnly)
                    || file.Attributes.HasFlag(FileAttributes.System)
                    || file.Attributes.HasFlag(FileAttributes.Hidden)
                ) continue;

                if (Delete && (!ByDate || file.LastWriteTime < date))
                {
                    file.Delete();
                }
                else if (Move)
                {
                    var to = Program.GetDirectoryInfo(EnumKnownFolder.Documents).FullName;
                    var sub = GetRelativePathTo(_directoryInfo, file);
                    var target = Path.Combine(to, sub);
                    new FileInfo(target).Directory?.Create();
                    file.MoveTo(target);
                }
            }

            if (Move || Delete)
            {
                DeleteEmptyDirs(_directoryInfo.FullName);
            }

            var user = WindowsIdentity.GetCurrent().User;
            if (user == null) return;
            var rule = new FileSystemAccessRule(
                user,
                FileSystemRights.CreateFiles | FileSystemRights.CreateDirectories | FileSystemRights.WriteData,
                AccessControlType.Deny
            );
            if (Readonly)
            {
                File.SetAttributes(_directoryInfo.FullName, _directoryInfo.Attributes | FileAttributes.ReadOnly);
                var access = _directoryInfo.GetAccessControl();
                access.AddAccessRule(rule);
                _directoryInfo.SetAccessControl(access);
            }
            else
            {
                var access = _directoryInfo.GetAccessControl();
                access.RemoveAccessRuleSpecific(rule);
                _directoryInfo.SetAccessControl(access);
            }
        }

        public override string ToString()
        {
            return "Обслуживание директории " + _directoryInfo.Name;
        }
        
        private static string GetRelativePathTo(FileSystemInfo from, FileSystemInfo to)
        {
            Func<FileSystemInfo, string> getPath = fsi =>
            {
                var d = fsi as DirectoryInfo;
                return d == null ? fsi.FullName : d.FullName.TrimEnd('\\') + "\\";
            };

            var fromPath = getPath(from);
            var toPath = getPath(to);

            var fromUri = new Uri(fromPath);
            var toUri = new Uri(toPath);

            var relativeUri = fromUri.MakeRelativeUri(toUri);
            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            return relativePath.Replace('/', Path.DirectorySeparatorChar);
        }
        
        private static void DeleteEmptyDirs(string dir)
        {
            try
            {
                foreach (var d in Directory.EnumerateDirectories(dir))
                {
                    DeleteEmptyDirs(d);
                }

                var entries = Directory.EnumerateFileSystemEntries(dir);

                if (entries.Any()) return;
                try
                {
                    Directory.Delete(dir);
                }
                catch (UnauthorizedAccessException) { }
                catch (DirectoryNotFoundException) { }
            }
            catch (UnauthorizedAccessException) { }
        }
    }
}