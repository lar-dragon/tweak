using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace Tweak
{
    public class Config
    {
        public EnumDesktopAction DesktopAction { get; set; }
            = EnumDesktopAction.Nothing;
        
        public bool DesktopReadonly { get; set; }
            = (Program.GetDirectoryInfo(EnumKnownFolder.Desktop).Attributes & FileAttributes.ReadOnly) == 0;

        public EnumFilesAction DownloadsAction { get; set; }
            = EnumFilesAction.Nothing;
        
        public bool DownloadsReadonly { get; set; }
            = (Program.GetDirectoryInfo(EnumKnownFolder.Downloads).Attributes & FileAttributes.ReadOnly) == 0;
        
        public EnumFilesAction OthersAction { get; set; }
            = EnumFilesAction.Nothing;
        
        public bool OthersReadonly { get; set; }
            = (Program.GetDirectoryInfo(EnumKnownFolder.Documents).Attributes & FileAttributes.ReadOnly) == 0
              | (Program.GetDirectoryInfo(EnumKnownFolder.Pictures).Attributes & FileAttributes.ReadOnly) == 0
              | (Program.GetDirectoryInfo(EnumKnownFolder.Music).Attributes & FileAttributes.ReadOnly) == 0;

        public EnumThemeAction ThemeAction { get; set; }
            = EnumThemeAction.Nothing;

        public bool ThemeLock { get; set; }
            = (uint) Program.GetRegistryValue(EnumKnownRegistry.NoThemesTab).GetValue() != 0;
        
        public bool ThemeLockPicture { get; set; }
            = (uint) Program.GetRegistryValue(EnumKnownRegistry.NoChangingWallPaper).GetValue() != 0;

        public bool TempDelete { get; set; }
            = false;

        public bool TempDeleteHistory { get; set; }
            = false;

        public bool Daily { get; set; }
            = Program.TaskService.FindTask(Program.TaskName)?.Enabled ?? false;

        public override string ToString()
        {
            return string.Join(
                " ",
                GetType()
                    .GetProperties()
                    .Select(property => property.Name + "=" + property.GetValue(this, null))
                    .ToArray()
            );
        }
    }
}