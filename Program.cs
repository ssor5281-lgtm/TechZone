using TechZone.Core.Enums;
using TechZone.Core.Models;
using TechZone.Core.Settings;
using TechZone.UI.Forms;
using TechZone.UI.Startup;

namespace TechZone;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        AppSettings.Load();
        ApplicationConfiguration.Initialize();

        var testAdmin = new User
        {
            Id = 1,
            Username = "admin",
            Role = UserRole.Admin,
            CreatedAt = DateTime.Now
        };
        Application.Run(new MainForm(testAdmin));

        // Application.Run(new SplashLoading());
    }
}