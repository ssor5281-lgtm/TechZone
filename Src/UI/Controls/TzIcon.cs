using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Svg;

namespace TechZone.UI.Controls;

public class TzIcon : Control
{


    private const int RenderScale = 4;

    private readonly Dictionary<int, Bitmap> _colorCache = new();

    private Bitmap? _sourceBitmap;
    private Bitmap? _displayBitmap;

    private string? _svgPath;
    private Color _iconColor = Color.Black;

    public TzIcon()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);

        BackColor = Color.Transparent;
        Size = new Size(24, 24);
    }

    public string? SvgPath
    {
        get => _svgPath;
        set
        {
            if (_svgPath == value)
                return;

            _svgPath = value;

            LoadSvg();
        }
    }

    public Color IconColor
    {
        get => _iconColor;
        set
        {
            if (_iconColor == value)
                return;

            _iconColor = value;

            SetDisplayColor(value);
        }
    }

    public void PrepareColor(Color color)
    {
        if (_sourceBitmap == null)
            return;

        int key = GetColorKey(color);

        if (_colorCache.ContainsKey(key))
            return;

        Bitmap bitmap =
            CreateColorBitmap(
                _sourceBitmap,
                color);

        _colorCache[key] = bitmap;
    }

    public void PrepareColors(
        params Color[] colors)
    {
        if (_sourceBitmap == null)
            return;

        foreach (Color color in colors)
            PrepareColor(color);
    }

    protected override void OnPaint(
        PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_displayBitmap == null)
            return;

        e.Graphics.CompositingMode =
            CompositingMode.SourceOver;

        e.Graphics.CompositingQuality =
            CompositingQuality.HighQuality;

        e.Graphics.InterpolationMode =
            InterpolationMode.HighQualityBicubic;

        e.Graphics.PixelOffsetMode =
            PixelOffsetMode.HighQuality;

        e.Graphics.SmoothingMode =
            SmoothingMode.HighQuality;

        e.Graphics.DrawImage(
            _displayBitmap,
            new Rectangle(
                0,
                0,
                Width,
                Height),
            0,
            0,
            _displayBitmap.Width,
            _displayBitmap.Height,
            GraphicsUnit.Pixel);
    }

    private void LoadSvg()
    {
        ClearBitmaps();

        if (string.IsNullOrWhiteSpace(_svgPath))
        {
            Invalidate();
            return;
        }

        if (!File.Exists(_svgPath))
        {
            Invalidate();
            return;
        }

        try
        {
            string svg =
                File.ReadAllText(_svgPath);

            using var stream =
                new MemoryStream(
                    Encoding.UTF8.GetBytes(svg));

            var document =
                SvgDocument.Open<SvgDocument>(
                    stream);

            RenderSvg(document);

            if (_sourceBitmap != null)
            {
                Bitmap display =
                    CreateColorBitmap(
                        _sourceBitmap,
                        _iconColor);

                int key =
                    GetColorKey(_iconColor);

                _colorCache[key] =
                    display;

                _displayBitmap =
                    display;
            }
        }
        catch
        {
            ClearBitmaps();
        }

        Invalidate();
    }

    private void RenderSvg(
        SvgDocument document)
    {
        if (Width <= 0 ||
            Height <= 0)
        {
            return;
        }

        int renderWidth =
            Math.Max(
                1,
                Width * RenderScale);

        int renderHeight =
            Math.Max(
                1,
                Height * RenderScale);

        document.Width =
            renderWidth;

        document.Height =
            renderHeight;

        var bitmap =
            new Bitmap(
                renderWidth,
                renderHeight,
                PixelFormat.Format32bppArgb);

        using (Graphics graphics =
               Graphics.FromImage(bitmap))
        {
            graphics.Clear(
                Color.Transparent);

            graphics.CompositingMode =
                CompositingMode.SourceOver;

            graphics.CompositingQuality =
                CompositingQuality.HighQuality;

            graphics.SmoothingMode =
                SmoothingMode.HighQuality;

            graphics.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            graphics.PixelOffsetMode =
                PixelOffsetMode.HighQuality;

            document.Draw(graphics);
        }

        _sourceBitmap?.Dispose();

        _sourceBitmap =
            bitmap;
    }

    private void SetDisplayColor(
        Color color)
    {
        if (_sourceBitmap == null)
        {
            Invalidate();
            return;
        }

        int key =
            GetColorKey(color);

        if (!_colorCache.TryGetValue(
                key,
                out Bitmap? bitmap))
        {
            bitmap =
                CreateColorBitmap(
                    _sourceBitmap,
                    color);

            _colorCache[key] =
                bitmap;
        }

        _displayBitmap =
            bitmap;

        Invalidate();
    }

    private static Bitmap CreateColorBitmap(
        Bitmap source,
        Color color)
    {
        var result =
            new Bitmap(
                source.Width,
                source.Height,
                PixelFormat.Format32bppArgb);

        Rectangle rectangle =
            new(
                0,
                0,
                source.Width,
                source.Height);

        BitmapData sourceData =
            source.LockBits(
                rectangle,
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

        BitmapData resultData =
            result.LockBits(
                rectangle,
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

        try
        {
            int sourceByteCount =
                Math.Abs(
                    sourceData.Stride) *
                sourceData.Height;

            int resultByteCount =
                Math.Abs(
                    resultData.Stride) *
                resultData.Height;

            byte[] sourcePixels =
                new byte[sourceByteCount];

            byte[] resultPixels =
                new byte[resultByteCount];

            Marshal.Copy(
                sourceData.Scan0,
                sourcePixels,
                0,
                sourceByteCount);

            byte targetR =
                color.R;

            byte targetG =
                color.G;

            byte targetB =
                color.B;

            int sourceStride =
                sourceData.Stride;

            int resultStride =
                resultData.Stride;

            for (int y = 0;
                 y < source.Height;
                 y++)
            {
                int sourceRow =
                    y * sourceStride;

                int resultRow =
                    y * resultStride;

                for (int x = 0;
                     x < source.Width;
                     x++)
                {
                    int sourceIndex =
                        sourceRow + (x * 4);

                    int resultIndex =
                        resultRow + (x * 4);

                    byte alpha =
                        sourcePixels[
                            sourceIndex + 3];

                    if (alpha == 0)
                        continue;

                    resultPixels[
                        resultIndex] =
                        targetB;

                    resultPixels[
                        resultIndex + 1] =
                        targetG;

                    resultPixels[
                        resultIndex + 2] =
                        targetR;

                    resultPixels[
                        resultIndex + 3] =
                        alpha;
                }
            }

            Marshal.Copy(
                resultPixels,
                0,
                resultData.Scan0,
                resultByteCount);
        }
        finally
        {
            source.UnlockBits(
                sourceData);

            result.UnlockBits(
                resultData);
        }

        return result;
    }

    private static int GetColorKey(
        Color color)
    {
        return color.ToArgb();
    }

    protected override void OnResize(
        EventArgs e)
    {
        base.OnResize(e);

        if (string.IsNullOrWhiteSpace(_svgPath))
            return;

        LoadSvg();
    }

    private void ClearBitmaps()
    {
        foreach (Bitmap bitmap in _colorCache.Values)
            bitmap.Dispose();

        _colorCache.Clear();

        _displayBitmap = null;

        _sourceBitmap?.Dispose();
        _sourceBitmap = null;
    }

    protected override void Dispose(
        bool disposing)
    {
        if (disposing)
            ClearBitmaps();

        base.Dispose(disposing);
    }
}