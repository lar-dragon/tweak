using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tweak
{
    public class TaskDirectory : ITask
    {
        private readonly DirectoryInfo _directoryInfo;
        
        private readonly IEnumerable<FileInfo> _files;
                
        private readonly ulong _weight;

        public ulong Weight => _weight;

        public bool Readonly { get; set; }
        
        public bool Delete { get; set; }
        
        public bool ByDate { get; set; }
        
        public bool Move { get; set; }
        
        public double Older { get; set; } = -7;

        public TaskDirectory(DirectoryInfo directoryInfo)
        {
            _directoryInfo = directoryInfo;
            _files = directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories);
            _weight = _files.Aggregate<FileInfo, ulong>(0, (current, fileInfo) => current + (ulong) fileInfo.Length);
        }
        
        public void Apply()
        {
            var date = DateTime.Now.AddDays(Older);
            _directoryInfo.Attributes &= ~FileAttributes.ReadOnly;
            foreach (var file in _files)
            {
                if (Delete && (!ByDate || file.LastWriteTimeUtc < date))
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