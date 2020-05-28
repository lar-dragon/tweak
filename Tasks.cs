using System.Collections;
using System.Collections.Generic;

namespace Tweak
{
    public class Tasks : IEnumerable<ITask>
    {
        private readonly List<ITask> _tasks = new List<ITask>();

        public ulong Total { get; private set; }

        public Tasks(Config config)
        {
            AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownFolder.Desktop))
            {
                Delete = config.DesktopAction != EnumDesktopAction.Move
                         && config.DesktopAction != EnumDesktopAction.Nothing,
                Move = config.DesktopAction == EnumDesktopAction.DeleteOldAndMove
                       || config.DesktopAction == EnumDesktopAction.Move,
                ByDate = config.DesktopAction == EnumDesktopAction.DeleteOld
                         || config.DesktopAction == EnumDesktopAction.DeleteOldAndMove,
                Readonly = config.DesktopReadonly
            });
            
            AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownFolder.Downloads))
            {
                Delete = config.DownloadsAction != EnumFilesAction.Nothing,
                ByDate = config.DownloadsAction == EnumFilesAction.DeleteOld,
                Readonly = config.DownloadsReadonly
            });
            
            AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownFolder.Documents))
            {
                Delete = config.OthersAction != EnumFilesAction.Nothing,
                ByDate = config.OthersAction == EnumFilesAction.DeleteOld,
                Readonly = config.OthersReadonly,
                Older = -14
            });
            
            AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownFolder.Pictures))
            {
                Delete = config.OthersAction != EnumFilesAction.Nothing,
                ByDate = config.OthersAction == EnumFilesAction.DeleteOld,
                Readonly = config.OthersReadonly,
                Older = -14
            });
            
            AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownFolder.Music))
            {
                Delete = config.OthersAction != EnumFilesAction.Nothing,
                ByDate = config.OthersAction == EnumFilesAction.DeleteOld,
                Readonly = config.OthersReadonly,
                Older = -14
            });
            
            AddTask(new TaskTheme
            {
                LockTheme = config.ThemeLock,
                LockWallpaper = config.ThemeLockPicture,
                SetDefault = config.ThemeAction == EnumThemeAction.Default
            });
            
            AddTask(new TaskTemp
            {
                ClearTemp = config.TempDelete,
                ClearCache = config.TempDeleteHistory
            });
            
            AddTask(new TaskDaily(config.ToString())
            {
                Active = config.Daily
            });
        }

        private void AddTask(ITask task)
        {
            Total += task.Weight;
            _tasks.Add(task);
        }
        
        public IEnumerator<ITask> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}