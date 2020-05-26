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
            {
                new Process
                {
                    EnableRaisingEvents = false, StartInfo =
                    {
                        FileName = "rundll32.exe",
                        Arguments = "%SystemRoot%\\system32\\shell32.dll,Control_RunDLL %SystemRoot%\\system32\\desk.cpl desk,@Themes /Action:OpenTheme /file:\"%SystemRoot%\\Resources\\Themes\\aero.theme\"",
                        UseShellExecute = true
                    }
                }.Start();
            }

            Program.GetRegistryValue(EnumKnownRegistry.NoThemesTab).SetValue((uint) (LockTheme ? 1 : 0));
            Program.GetRegistryValue(EnumKnownRegistry.NoChangingWallPaper).SetValue((uint) (LockWallpaper ? 1 : 0));
        }

        public override string ToString()
        {
            return "Обслуживание темы оформления";
        }
    }
}