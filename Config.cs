using System.Linq;

namespace Tweak
{
    public class Config
    {
        [Argument("1")]
        public EnumDesktopAction DesktopAction { get; set; } = EnumDesktopAction.Nothing;
        
        [Argument("2")]
        public bool DesktopReadonly { get; set; }

        [Argument("3")]
        public EnumFilesAction DownloadsAction { get; set; } = EnumFilesAction.Nothing;
        
        [Argument("4")]
        public bool DownloadsReadonly { get; set; }
        
        [Argument("5")]
        public EnumFilesAction OthersAction { get; set; } = EnumFilesAction.Nothing;
        
        [Argument("6")]
        public bool OthersReadonly { get; set; }
        
        [Argument("7")]
        public EnumThemeAction ThemeAction { get; set; } = EnumThemeAction.Nothing;

        [Argument("8")]
        public bool ThemeLock { get; set; }
            = Program.GetRegistryValue(EnumKnownRegistry.NoThemesTab).GetValue<uint>() != 0;
        
        [Argument("9")]
        public bool ThemeLockPicture { get; set; }
            = Program.GetRegistryValue(EnumKnownRegistry.NoChangingWallPaper).GetValue<uint>() != 0;

        [Argument("10")]
        public bool TempDelete { get; set; }

        [Argument("11")]
        public bool TempDeleteHistory { get; set; }

        [Argument("12")]
        public bool Daily { get; set; }

        public override string ToString()
        {
            return string.Join(
                " ",
                GetType()
                    .GetProperties()
                    .Where(property => property.GetCustomAttributes(typeof(Argument), true).Length > 0)
                    .Select(property =>
                        ((Argument[])property.GetCustomAttributes(typeof(Argument), true)).First()
                        + "="
                        + property.GetValue(this, null)
                    )
                    .ToArray()
            );
        }
    }
}