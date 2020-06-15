using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tweak
{
    public class TaskDirectory : ITask
    {
        private readonly DirectoryInfo _directoryInfo;
        
        private IEnumerable<FileInfo> _files;

        private ulong _weight;

        private IEnumerable<FileInfo> Files
        {
            get
            {
                return _files ?? (
                    _files = _directoryInfo
                    .EnumerateFiles("*", SearchOption.AllDirectories)
                    .Where(
                        file => !file.Attributes.HasFlag(FileAttributes.ReadOnly)
                                && !file.Attributes.HasFlag(FileAttributes.System)
                                && !file.Attributes.HasFlag(FileAttributes.Hidden)
                    )
                );
            }
        }

        public ulong Weight {
            get
            {
                if (!Delete && !Move)
                    return (ulong) (Readonly ? 4 : 0);

                return _weight != default
                    ? _weight
                    : _weight = Files.Aggregate<FileInfo, ulong>(
                        0,
                        (current, fileInfo) => current + (ulong) fileInfo.Length
                    );
            }
        }

        public bool Readonly { get; set; }
        
        public bool Delete { get; set; }
        
        public bool ByDate { get; set; }
        
        public bool Move { get; set; }
        
        public double Older { get; set; } = -7;

        public TaskDirectory(DirectoryInfo directoryInfo)
        {
            _directoryInfo = directoryInfo;
        }
        
        public void Apply()
        {
            var date = DateTime.Now.AddDays(Older);
            File.SetAttributes(_directoryInfo.FullName, _directoryInfo.Attributes & ~FileAttributes.ReadOnly);
            if (Delete || Move)
            {
                foreach (var file in Files)
                {
                    try
                    {
                        if (Delete && (!ByDate || file.LastWriteTime < date))
                            file.Delete();
                        else if (Move)
                        {
                            var to = Program.GetDirectoryInfo(EnumKnownDirectories.Documents).FullName;
                            var sub = GetRelativePathTo(_directoryInfo, file);
                            var target = Path.Combine(to, sub);
                            new FileInfo(target).Directory?.Create();
                            file.MoveTo(target);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                
                DeleteEmptyDirs(_directoryInfo.FullName);
            }

            try
            {
                if (Readonly)
                {
                    File.SetAttributes(_directoryInfo.FullName, _directoryInfo.Attributes | FileAttributes.ReadOnly);
                    var access = _directoryInfo.GetAccessControl();
                    access.AddAccessRule(Program.AccessRule);
                    _directoryInfo.SetAccessControl(access);
                }
                else
                {
                    var access = _directoryInfo.GetAccessControl();
                    access.RemoveAccessRuleSpecific(Program.AccessRule);
                    _directoryInfo.SetAccessControl(access);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public override string ToString()
        {
            return "Обслуживание директории " + _directoryInfo.Name;
        }
        
        private static string GetRelativePathTo(FileSystemInfo from, FileSystemInfo to)
        {
            string GetPath(FileSystemInfo fsi)
            {
                return !(fsi is DirectoryInfo d) ? fsi.FullName : d.FullName.TrimEnd('\\') + "\\";
            }

            var fromPath = GetPath(from);
            var toPath = GetPath(to);

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
                    DeleteEmptyDirs(d);

                var entries = Directory.EnumerateFileSystemEntries(dir);
                if (entries.Any())
                    return;
                
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