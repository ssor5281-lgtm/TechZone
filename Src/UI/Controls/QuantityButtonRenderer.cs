using System.Drawing;

namespace TechZone.UI.Controls;

public sealed class QuantityButtonRenderer
{
    private const int ButtonSize = 24;
    private const int Spacing = 4;
    private const int ValueWidth = 25;
    private const int IconSize = 14;

    public (
        Rectangle minus,
        Rectangle value,
        Rectangle plus)
        GetButtonRects(Rectangle cellBounds)
    {
        int totalWidth =
            ButtonSize +
            Spacing +
            ValueWidth +
            Spacing +
            ButtonSize;

        int startX =
            cellBounds.X +
            (cellBounds.Width - totalWidth) / 2;

        int startY =
            cellBounds.Y +
            (cellBounds.Height - ButtonSize) / 2;

        Rectangle minus = new(
            startX,
            startY,
            ButtonSize,
            ButtonSize);

        Rectangle value = new(
            minus.Right + Spacing,
            startY,
            ValueWidth,
            ButtonSize);

        Rectangle plus = new(
            value.Right + Spacing,
            startY,
            ButtonSize,
            ButtonSize);

        return (minus, value, plus);
    }

    public void Draw(
        Graphics graphics,
        Rectangle cellBounds,
        int quantity,
        Bitmap minusIcon,
        Bitmap plusIcon)
    {
        var rects = GetButtonRects(cellBounds);

        DrawButton(
            graphics,
            rects.minus,
            minusIcon);

        DrawQuantity(
            graphics,
            rects.value,
            quantity);

        DrawButton(
            graphics,
            rects.plus,
            plusIcon);
    }

    private static void DrawButton(
        Graphics graphics,
        Rectangle rect,
        Bitmap image)
    {
        using SolidBrush brush = new(Color.RoyalBlue);

        graphics.FillRectangle(brush, rect);

        Rectangle imageRect = new(
            rect.X + (rect.Width - IconSize) / 2,
            rect.Y + (rect.Height - IconSize) / 2,
            IconSize,
            IconSize);

        graphics.DrawImage(image, imageRect);
    }

    private static void DrawQuantity(
        Graphics graphics,
        Rectangle rect,
        int quantity)
    {
        using SolidBrush textBrush =
            new(Color.FromArgb(30, 41, 59));

        using Font font =
            new("Bahnschrift", 9F);

        using StringFormat format = new()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        graphics.DrawString(
            quantity.ToString(),
            font,
            textBrush,
            rect,
            format);
    }
}