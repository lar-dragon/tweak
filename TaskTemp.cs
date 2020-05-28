using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tweak
{
    public class TaskTemp: ITask
    {
        private IEnumerable<FileInfo> _tempFiles;
        private IEnumerable<FileInfo> _cacheFiles;
        
        private ulong _weight = 0;
        public ulong Weight => _weight;
        
        public bool ClearTemp { get; set; }
        
        public bool ClearCache { get; set; }

        public TaskTemp()
        {
            _tempFiles = Program.GetDirectoryInfo(EnumKnownFolder.Temp)
                .EnumerateFiles("*", SearchOption.AllDirectories);
            _weight += _tempFiles
                .Aggregate<FileInfo, ulong>(0, (current, fileInfo) => current + (ulong) fileInfo.Length);
            _cacheFiles = Program.GetDirectoryInfo(EnumKnownFolder.InternetCache)
                .EnumerateFiles("*", SearchOption.AllDirectories);
            //_weight += _cacheFiles
            //    .Aggregate<FileInfo, ulong>(0, (current, fileInfo) => current + (ulong) fileInfo.Length);
        }
        public void Apply()
        {
            if (ClearTemp)
                foreach (var file in _tempFiles)
                    file.Delete();
            if (ClearCache)
                foreach (var file in _cacheFiles)
                    file.Delete();
        }

        public override string ToString()
        {
            return "Обслуживание врекменных файлов";
        }
    }
}