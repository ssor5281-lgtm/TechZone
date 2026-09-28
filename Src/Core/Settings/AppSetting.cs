using System.Text.Json;
using System.Text.Json.Serialization;
using TechZone.UI.Theme;

namespace TechZone.Core.Settings;

public static class AppSettings
{
    private static readonly string SettingsPath =
        Path.Combine(
            AppContext.BaseDirectory,
            "appsettings.json");

    private static TzTheme _theme = TzTheme.TzRoyalBlue;
    private static bool _compactSidebar;
    private static decimal _defaultDiscount;
    private static bool _confirmQuickSale = true;
    private static bool _confirmOrder = true;
    private static int _lowStockThreshold = 10;
    private static bool _allowSellingWhenStockZero;
    private static bool _rememberUsername;
    private static bool _confirmLogout = true;
    private static string _rememberedUsername = string.Empty;

    private static bool _isLoading;

    public static TzTheme Theme
    {
        get => _theme;
        set
        {
            _theme = value;
            Save();
        }
    }

    public static bool CompactSidebar
    {
        get => _compactSidebar;
        set
        {
            _compactSidebar = value;
            Save();
        }
    }

    public static decimal DefaultDiscount
    {
        get => _defaultDiscount;
        set
        {
            _defaultDiscount = value;
            Save();
        }
    }

    public static bool ConfirmQuickSale
    {
        get => _confirmQuickSale;
        set
        {
            _confirmQuickSale = value;
            Save();
        }
    }

    public static bool ConfirmOrder
    {
        get => _confirmOrder;
        set
        {
            _confirmOrder = value;
            Save();
        }
    }

    public static int LowStockThreshold
    {
        get => _lowStockThreshold;
        set
        {
            _lowStockThreshold = value;
            Save();
        }
    }

    public static bool AllowSellingWhenStockZero
    {
        get => _allowSellingWhenStockZero;
        set
        {
            _allowSellingWhenStockZero = value;
            Save();
        }
    }

    public static bool RememberUsername
    {
        get => _rememberUsername;
        set
        {
            _rememberUsername = value;
            Save();
        }
    }

    public static bool ConfirmLogout
    {
        get => _confirmLogout;
        set
        {
            _confirmLogout = value;
            Save();
        }
    }

    public static string RememberedUsername
    {
        get => _rememberedUsername;
        set
        {
            _rememberedUsername = value;
            Save();
        }
    }

    public static void Load()
    {
        if (!File.Exists(SettingsPath))
        {
            Save();
            return;
        }

        try
        {
            string json =
                File.ReadAllText(SettingsPath);

            AppSettingsData? settings =
                JsonSerializer.Deserialize<AppSettingsData>(
                    json);

            if (settings is null)
                return;

            _isLoading = true;

            _theme = settings.Theme;
            _compactSidebar = settings.CompactSidebar;
            _defaultDiscount = settings.DefaultDiscount;
            _confirmQuickSale = settings.ConfirmQuickSale;
            _confirmOrder = settings.ConfirmOrder;
            _lowStockThreshold = settings.LowStockThreshold;
            _allowSellingWhenStockZero =
                settings.AllowSellingWhenStockZero;
            _rememberUsername = settings.RememberUsername;
            _confirmLogout = settings.ConfirmLogout;
            _rememberedUsername =
                settings.RememberedUsername ?? string.Empty;
        }
        catch
        {
            _theme = TzTheme.TzRoyalBlue;
            _compactSidebar = false;
            _defaultDiscount = 0;
            _confirmQuickSale = true;
            _confirmOrder = true;
            _lowStockThreshold = 10;
            _allowSellingWhenStockZero = false;
            _rememberUsername = false;
            _confirmLogout = true;
            _rememberedUsername = string.Empty;
        }
        finally
        {
            _isLoading = false;
        }
    }

    private static void Save()
    {
        if (_isLoading)
            return;

        try
        {
            AppSettingsData settings =
                new()
                {
                    Theme = _theme,
                    CompactSidebar = _compactSidebar,
                    DefaultDiscount = _defaultDiscount,
                    ConfirmQuickSale = _confirmQuickSale,
                    ConfirmOrder = _confirmOrder,
                    LowStockThreshold = _lowStockThreshold,
                    AllowSellingWhenStockZero =
                        _allowSellingWhenStockZero,
                    RememberUsername = _rememberUsername,
                    ConfirmLogout = _confirmLogout,
                    RememberedUsername =
                        _rememberedUsername
                };

            JsonSerializerOptions options =
                new()
                {
                    WriteIndented = true
                };

            string json =
                JsonSerializer.Serialize(
                    settings,
                    options);

            File.WriteAllText(
                SettingsPath,
                json);
        }
        catch
        {
        }
    }

    private sealed class AppSettingsData
    {
        public TzTheme Theme { get; set; } =
            TzTheme.TzRoyalBlue;

        public bool CompactSidebar { get; set; }

        public decimal DefaultDiscount { get; set; }

        public bool ConfirmQuickSale { get; set; } = true;

        public bool ConfirmOrder { get; set; } = true;

        public int LowStockThreshold { get; set; } = 10;

        public bool AllowSellingWhenStockZero { get; set; }

        public bool RememberUsername { get; set; }

        public bool ConfirmLogout { get; set; } = true;

        public string? RememberedUsername { get; set; }
    }
}