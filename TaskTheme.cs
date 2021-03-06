using System;
using System.Diagnostics;

namespace Tweak
{
    public class TaskTheme : ITask
    {
        public ulong Weight => 4;

        public bool SetDefault { get; set; }
        
        public bool LockTheme { get; set; }
        
        public bool LockWallpaper { get; set; }

        public void Apply()
        {
            if (SetDefault)
                new Process
                {
                    EnableRaisingEvents = false,
                    StartInfo =
                    {
                        FileName = "rundll32.exe",
                        Arguments = "themecpl.dll,OpenThemeAction "
                                    + Environment.GetFolderPath(Environment.SpecialFolder.Windows)
                                    + "\\Resources\\Themes\\aero.theme",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                }.Start();

            Program.GetRegistryValue(EnumKnownRegistry.NoThemesTab).SetValue((uint) (LockTheme ? 1 : 0));
            Program.GetRegistryValue(EnumKnownRegistry.NoChangingWallPaper).SetValue((uint) (LockWallpaper ? 1 : 0));
        }

        public override string ToString()
        {
            return "Обслуживание темы оформления";
        }
    }
}