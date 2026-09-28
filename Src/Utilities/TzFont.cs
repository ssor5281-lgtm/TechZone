namespace TechZone.Utilities;

public static class TzFont
{
    public static Font Regular(float size)
        => new("Bahnschrift", size);

    public static Font Bold(float size)
        => new("Bahnschrift", size, FontStyle.Bold);

    public static Font Title(float size = 20F)
        => new("Bahnschrift", size, FontStyle.Bold);

    public static Font Button(float size = 9.5F)
        => new("Bahnschrift", size, FontStyle.Bold);

    public static Font Table(float size = 9.5F)
        => new("Bahnschrift", size);

    public static Font TableHeader(float size = 9.5F)
        => new("Bahnschrift", size, FontStyle.Bold);
}