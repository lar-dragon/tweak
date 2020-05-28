using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Tweak
{
    public class TaskTemp: ITask
    {
        private readonly IEnumerable<FileInfo> _files;

        public ulong Weight { get; } = 0;

        public bool ClearTemp { get; set; }
        
        public bool ClearCache { get; set; }

        public TaskTemp()
        {
            _files = Program.GetDirectoryInfo(EnumKnownFolder.Temp)
                .EnumerateFiles("*", SearchOption.AllDirectories);
            Weight = _files
                .Aggregate<FileInfo, ulong>(0, (current, fileInfo) => current + (ulong) fileInfo.Length);
        }
        public void Apply()
        {
            if (ClearTemp)
                foreach (var file in _files)
                    file.Delete();
            if (ClearCache)
            {
                new Process
                {
                    EnableRaisingEvents = false,
                    StartInfo =
                    {
                        FileName = "rundll32.exe",
                        Arguments = "InetCpl.cpl,ClearMyTracksByProcess 8",
                        UseShellExecute = true
                    }
                }.Start();
            }
        }

        public override string ToString()
        {
            return "Обслуживание врекменных файлов";
        }
    }
}