
namespace TechZone.Core.Helpers;

public static class AppPaths
{
    public static string ProjectRoot
    {
        get
        {
            var directory =
                new DirectoryInfo(AppContext.BaseDirectory);

            while (directory != null)
            {
                if (File.Exists(
                        Path.Combine(
                            directory.FullName,
                            "TechZone.csproj")))
                {
                    return directory.FullName;
                }

                directory = directory.Parent;
            }

            return AppContext.BaseDirectory;
        }
    }

    public static string ApplicationDirectory =>
        AppContext.BaseDirectory;

    public static string AppDataRoot
    {
        get
        {
            var path = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "TechZone");

            Directory.CreateDirectory(path);

            return path;
        }
    }

    public static string ProductImages
    {
        get
        {
            var path = Path.Combine(
                AppDataRoot,
                "Products");

            Directory.CreateDirectory(path);

            return path;
        }
    }

    public static string UserImages
    {
        get
        {
            var path = Path.Combine(
                AppDataRoot,
                "Users");

            Directory.CreateDirectory(path);

            return path;
        }
    }
}