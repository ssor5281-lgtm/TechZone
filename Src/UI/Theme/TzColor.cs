using System.Drawing;
using TechZone.Core.Settings;

namespace TechZone.UI.Theme;

public enum TzTheme
{
    TzRoyalBlue,
    Light,
    Dark
}

public static class TzColors
{
    public static TzTheme Current
    {
        get => AppSettings.Theme;
        set => AppSettings.Theme = value;
    }
    
    public static Image SidebarLogo =>
        Current switch
        {
            TzTheme.Light => Resources.techzone_logo_royalblue,
            _ => Resources.techzone_logo_white
        };

    public static Color SidebarLogoText =>
        Current switch
        {
            TzTheme.Light => Color.CornflowerBlue,
            TzTheme.Dark => Color.White,
            TzTheme.TzRoyalBlue => Color.White,
            _ => Color.RoyalBlue
        };
    
    public static Color Primary =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.RoyalBlue,
            TzTheme.Light => Color.FromArgb(37, 99, 235),
            TzTheme.Dark => Color.FromArgb(148, 163, 184),
            _ => Color.RoyalBlue
        };

    public static Color PrimaryHover =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(82, 128, 225),
            TzTheme.Light => Color.FromArgb(239, 246, 255),
            TzTheme.Dark => Color.FromArgb(35, 45, 62),
            _ => Color.FromArgb(82, 128, 225)
        };

    public static Color PrimaryActive =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(245, 249, 255),
            TzTheme.Light => Color.FromArgb(219, 234, 254),
            TzTheme.Dark => Color.FromArgb(55, 65, 81),
            _ => Color.FromArgb(245, 249, 255)
        };

    public static Color SidebarBackground =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.RoyalBlue,
            TzTheme.Light => Color.White,
            TzTheme.Dark => Color.FromArgb(17, 24, 39),
            _ => Color.RoyalBlue
        };

    public static Color SidebarText =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(210, 225, 255),
            TzTheme.Light => Color.FromArgb(30, 41, 59),
            TzTheme.Dark => Color.FromArgb(203, 213, 225),
            _ => Color.FromArgb(210, 225, 255)
        };

    public static Color SidebarHoverText =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.White,
            TzTheme.Light => Color.FromArgb(30, 41, 59),
            TzTheme.Dark => Color.White,
            _ => Color.White
        };

    public static Color SidebarActiveText =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.RoyalBlue,
            TzTheme.Light => Color.FromArgb(37, 99, 235),
            TzTheme.Dark => Color.White,
            _ => Color.RoyalBlue
        };

    public static Color SidebarTextMuted =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(165, 195, 235),
            TzTheme.Light => Color.FromArgb(100, 116, 139),
            TzTheme.Dark => Color.FromArgb(148, 163, 184),
            _ => Color.FromArgb(165, 195, 235)
        };

    public static Color SidebarBorder =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(70, 125, 220),
            TzTheme.Light => Color.FromArgb(226, 232, 240),
            TzTheme.Dark => Color.FromArgb(51, 65, 85),
            _ => Color.FromArgb(70, 125, 220)
        };

    public static Color Background =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(248, 250, 252),
            TzTheme.Light => Color.FromArgb(248, 250, 252),
            TzTheme.Dark => Color.FromArgb(15, 23, 42),
            _ => Color.FromArgb(248, 250, 252)
        };

    public static Color Surface =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.White,
            TzTheme.Light => Color.White,
            TzTheme.Dark => Color.FromArgb(30, 41, 59),
            _ => Color.White
        };

    public static Color Border =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(226, 232, 240),
            TzTheme.Light => Color.FromArgb(226, 232, 240),
            TzTheme.Dark => Color.FromArgb(51, 65, 85),
            _ => Color.FromArgb(226, 232, 240)
        };

    public static Color TextPrimary =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(30, 41, 59),
            TzTheme.Light => Color.FromArgb(30, 41, 59),
            TzTheme.Dark => Color.FromArgb(248, 250, 252),
            _ => Color.FromArgb(30, 41, 59)
        };

    public static Color TextSecondary =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(71, 85, 105),
            TzTheme.Light => Color.FromArgb(71, 85, 105),
            TzTheme.Dark => Color.FromArgb(203, 213, 225),
            _ => Color.FromArgb(71, 85, 105)
        };

    public static Color TextMuted =>
        Current switch
        {
            TzTheme.TzRoyalBlue => Color.FromArgb(100, 116, 139),
            TzTheme.Light => Color.FromArgb(100, 116, 139),
            TzTheme.Dark => Color.FromArgb(148, 163, 184),
            _ => Color.FromArgb(100, 116, 139)
        };

    public static Color Success =>
        Color.FromArgb(22, 163, 74);

    public static Color Warning =>
        Color.FromArgb(234, 179, 8);

    public static Color Danger =>
        Color.FromArgb(209, 15, 15);

    public static Color Info =>
        Color.FromArgb(37, 99, 235);
}