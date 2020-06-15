using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tweak
{
    public class Tasks : IEnumerable<ITask>
    {
        private readonly List<ITask> _tasks = new List<ITask>();

        public ulong Total { get; private set; }

        public Tasks(Config config)
        {
            try
            {
                AddTask(
                    new TaskDirectory(Program.GetDirectoryInfo(EnumKnownDirectories.Desktop))
                    {
                        Delete = config.DesktopAction != EnumDesktopAction.Move
                                 && config.DesktopAction != EnumDesktopAction.Nothing,
                        Move = config.DesktopAction == EnumDesktopAction.DeleteOldAndMove
                               || config.DesktopAction == EnumDesktopAction.Move,
                        ByDate = config.DesktopAction == EnumDesktopAction.DeleteOld
                                 || config.DesktopAction == EnumDesktopAction.DeleteOldAndMove,
                        Readonly = config.DesktopReadonly
                    }
                );
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownDirectories.Downloads))
                {
                    Delete = config.DownloadsAction != EnumFilesAction.Nothing,
                    ByDate = config.DownloadsAction == EnumFilesAction.DeleteOld,
                    Readonly = config.DownloadsReadonly
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownDirectories.Documents))
                {
                    Delete = config.OthersAction != EnumFilesAction.Nothing,
                    ByDate = config.OthersAction == EnumFilesAction.DeleteOld,
                    Readonly = config.OthersReadonly,
                    Older = -14
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownDirectories.Pictures))
                {
                    Delete = config.OthersAction != EnumFilesAction.Nothing,
                    ByDate = config.OthersAction == EnumFilesAction.DeleteOld,
                    Readonly = config.OthersReadonly,
                    Older = -14
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            try
            {
                AddTask(new TaskDirectory(Program.GetDirectoryInfo(EnumKnownDirectories.Music))
                {
                    Delete = config.OthersAction != EnumFilesAction.Nothing,
                    ByDate = config.OthersAction == EnumFilesAction.DeleteOld,
                    Readonly = config.OthersReadonly,
                    Older = -14
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            try
            {
                AddTask(new TaskTheme
                {
                    LockTheme = config.ThemeLock,
                    LockWallpaper = config.ThemeLockPicture,
                    SetDefault = config.ThemeAction == EnumThemeAction.Default
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            try
            {
                AddTask(new TaskTemp
                {
                    ClearTemp = config.TempDelete,
                    ClearCache = config.TempDeleteHistory
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            try
            {
                AddTask(new TaskDaily(config.ToString())
                {
                    Active = config.Daily
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
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