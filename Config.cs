using System.IO;
using System.Linq;

namespace Tweak
{
    public class Config
    {
        public EnumDesktopAction DesktopAction { get; set; }
            = EnumDesktopAction.Nothing;
        
        public bool DesktopReadonly { get; set; }
            = Program.GetDirectoryInfo(EnumKnownFolder.Desktop).Attributes.HasFlag(FileAttributes.ReadOnly);

        public EnumFilesAction DownloadsAction { get; set; }
            = EnumFilesAction.Nothing;
        
        public bool DownloadsReadonly { get; set; }
            = Program.GetDirectoryInfo(EnumKnownFolder.Downloads).Attributes.HasFlag(FileAttributes.ReadOnly);
        
        public EnumFilesAction OthersAction { get; set; }
            = EnumFilesAction.Nothing;
        
        public bool OthersReadonly { get; set; }
            = Program.GetDirectoryInfo(EnumKnownFolder.Documents).Attributes.HasFlag(FileAttributes.ReadOnly)
              | Program.GetDirectoryInfo(EnumKnownFolder.Pictures).Attributes.HasFlag(FileAttributes.ReadOnly)
              | Program.GetDirectoryInfo(EnumKnownFolder.Music).Attributes.HasFlag(FileAttributes.ReadOnly);

        public EnumThemeAction ThemeAction { get; set; }
            = EnumThemeAction.Nothing;

        public bool ThemeLock { get; set; }
            = Program.GetRegistryValue(EnumKnownRegistry.NoThemesTab).GetValue<uint>() != 0;
        
        public bool ThemeLockPicture { get; set; }
            = Program.GetRegistryValue(EnumKnownRegistry.NoChangingWallPaper).GetValue<uint>() != 0;

        public bool TempDelete { get; set; }

        public bool TempDeleteHistory { get; set; }

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