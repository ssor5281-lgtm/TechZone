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

            throw new DirectoryNotFoundException(
                "TechZone project root could not be found.");
        }
    }

    public static string ProductImages =>
        Path.Combine(
            ProjectRoot,
            "Asset",
            "Products");
    public static string UserImages =>
        Path.Combine(
            ProjectRoot,
            "Asset",
            "Users");
    
}