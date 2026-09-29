using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TechZone.Core.Helpers;

public static class ImageHelper
{
    private const int DefaultImageSize = 800;
    private const long DefaultJpegQuality = 85L;

    private static readonly string[] SupportedExtensions =
    [
        ".jpg",
        ".jpeg",
        ".png"
    ];

    public static string? SelectImage(
        IWin32Window owner,
        string title = "Select Image")
    {
        using var dialog = new OpenFileDialog
        {
            Title = title,
            Filter = @"Image Files|*.jpg;*.jpeg;*.png",
            Multiselect = false
        };

        return dialog.ShowDialog(owner) == DialogResult.OK
            ? dialog.FileName
            : null;
    }

    public static bool IsValidImage(
        string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            return false;

        if (!File.Exists(imagePath))
            return false;

        string extension =
            Path.GetExtension(imagePath)
                .ToLowerInvariant();

        if (!SupportedExtensions.Contains(extension))
            return false;

        try
        {
            using var image =
                Image.FromFile(imagePath);

            return image.Width > 0 &&
                   image.Height > 0;
        }
        catch
        {
            return false;
        }
    }

    public static void LoadPreview(
        PictureBox pictureBox,
        string imagePath)
    {
        DisposeImage(pictureBox);

        if (!IsValidImage(imagePath))
            throw new InvalidOperationException(
                "The image could not be loaded.");

        using var source =
            LoadImage(imagePath);

        pictureBox.Image =
            CreateSquareImage(
                source,
                pictureBox.ClientSize.Width,
                pictureBox.ClientSize.Height);

        pictureBox.BackColor =
            Color.White;
    }

    public static bool TryLoadPreview(
        PictureBox pictureBox,
        string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
        {
            SetPlaceholder(pictureBox);
            return false;
        }

        try
        {
            string? fullPath =
                GetFullPath(imagePath);

            if (string.IsNullOrWhiteSpace(fullPath))
            {
                SetPlaceholder(pictureBox);
                return false;
            }

            LoadPreview(
                pictureBox,
                fullPath);

            return true;
        }
        catch
        {
            SetPlaceholder(pictureBox);
            return false;
        }
    }

    public static void SetPlaceholder(
        PictureBox pictureBox)
    {
        DisposeImage(pictureBox);

        pictureBox.BackColor =
            Color.FromArgb(
                241,
                245,
                249);
    }

    public static void DisposeImage(
        PictureBox pictureBox)
    {
        if (pictureBox.Image == null)
            return;

        Image image =
            pictureBox.Image;

        pictureBox.Image = null;

        image.Dispose();
    }

    public static string? SaveImage(
        string? sourcePath,
        string destinationDirectory,
        string fileName,
        int size = DefaultImageSize,
        long quality = DefaultJpegQuality)
    {
        if (!IsValidImage(sourcePath))
            return null;

        if (string.IsNullOrWhiteSpace(
                destinationDirectory))
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(fileName))
            return null;

        if (size <= 0)
            return null;

        try
        {
            Directory.CreateDirectory(
                destinationDirectory);

            string destinationPath =
                Path.Combine(
                    destinationDirectory,
                    $"{fileName}.jpg");

            using var source =
                LoadImage(sourcePath!);

            using var processed =
                CreateSquareImage(
                    source,
                    size,
                    size);

            SaveJpeg(
                processed,
                destinationPath,
                quality);

            return destinationPath;
        }
        catch
        {
            return null;
        }
    }

    public static string? GetFullPath(
        string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            return null;

        if (Path.IsPathRooted(imagePath))
            return imagePath;

        string normalizedPath =
            imagePath
                .Replace(
                    '/',
                    Path.DirectorySeparatorChar)
                .TrimStart(
                    Path.DirectorySeparatorChar);

        if (normalizedPath.StartsWith(
                "Asset" +
                Path.DirectorySeparatorChar,
                StringComparison.OrdinalIgnoreCase))
        {
            return Path.Combine(
                AppPaths.ProjectRoot,
                normalizedPath);
        }

        if (normalizedPath.StartsWith(
                "Products" +
                Path.DirectorySeparatorChar,
                StringComparison.OrdinalIgnoreCase))
        {
            return Path.Combine(
                AppPaths.ProductImages,
                normalizedPath[
                    ("Products" +
                     Path.DirectorySeparatorChar).Length..]);
        }

        if (normalizedPath.StartsWith(
                "Users" +
                Path.DirectorySeparatorChar,
                StringComparison.OrdinalIgnoreCase))
        {
            return Path.Combine(
                AppPaths.UserImages,
                normalizedPath[
                    ("Users" +
                     Path.DirectorySeparatorChar).Length..]);
        }

        return Path.Combine(
            AppPaths.AppDataRoot,
            normalizedPath);
    }

    public static bool DeleteImage(
        string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            return false;

        try
        {
            string? fullPath =
                GetFullPath(imagePath);

            if (string.IsNullOrWhiteSpace(fullPath))
                return false;

            if (!File.Exists(fullPath))
                return false;

            File.Delete(fullPath);

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static Image LoadImage(
        string imagePath)
    {
        using var stream =
            new FileStream(
                imagePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);

        using var source =
            Image.FromStream(stream);

        return new Bitmap(source);
    }

    private static Bitmap CreateSquareImage(
        Image source,
        int targetWidth,
        int targetHeight)
    {
        if (targetWidth <= 0 ||
            targetHeight <= 0)
        {
            throw new ArgumentException(
                "Invalid target size.");
        }

        int cropSize =
            Math.Min(
                source.Width,
                source.Height);

        int cropX =
            (source.Width - cropSize) / 2;

        int cropY =
            (source.Height - cropSize) / 2;

        var result =
            new Bitmap(
                targetWidth,
                targetHeight,
                PixelFormat.Format24bppRgb);

        using var graphics =
            Graphics.FromImage(result);

        graphics.CompositingQuality =
            CompositingQuality.HighQuality;

        graphics.InterpolationMode =
            InterpolationMode.HighQualityBicubic;

        graphics.PixelOffsetMode =
            PixelOffsetMode.HighQuality;

        graphics.SmoothingMode =
            SmoothingMode.HighQuality;

        graphics.DrawImage(
            source,
            new Rectangle(
                0,
                0,
                targetWidth,
                targetHeight),
            new Rectangle(
                cropX,
                cropY,
                cropSize,
                cropSize),
            GraphicsUnit.Pixel);

        return result;
    }

    private static void SaveJpeg(
        Image image,
        string filePath,
        long quality)
    {
        quality =
            Math.Clamp(
                quality,
                1L,
                100L);

        ImageCodecInfo? encoder =
            ImageCodecInfo.GetImageEncoders()
                .FirstOrDefault(codec =>
                    codec.FormatID ==
                    ImageFormat.Jpeg.Guid);

        if (encoder == null)
        {
            throw new InvalidOperationException(
                "JPEG encoder was not found.");
        }

        using var parameters =
            new EncoderParameters(1);

        parameters.Param[0] =
            new EncoderParameter(
                Encoder.Quality,
                quality);

        image.Save(
            filePath,
            encoder,
            parameters);
    }
}