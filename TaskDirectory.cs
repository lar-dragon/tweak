using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;

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
            _directoryInfo.Attributes &= ~FileAttributes.ReadOnly;
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
                    file.MoveTo(Program.GetDirectoryInfo(EnumKnownFolder.Documents).FullName);
                }
            }
            _directoryInfo.Attributes &= Readonly ? FileAttributes.ReadOnly : ~FileAttributes.ReadOnly;
        }

        public override string ToString()
        {
            return "Обслуживание директории " + _directoryInfo.Name;
        }
    }
}