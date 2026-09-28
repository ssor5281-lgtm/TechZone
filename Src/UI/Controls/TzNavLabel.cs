using System.Drawing;
using System.Windows.Forms;

namespace TechZone.UI.Controls;

public class TzNavLabel : Label
{
    protected override void OnPaint(PaintEventArgs e)
    {
        TextRenderer.DrawText(
            e.Graphics,
            Text,
            Font,
            ClientRectangle,
            ForeColor,
            TextFormatFlags.Left |
            TextFormatFlags.VerticalCenter |
            TextFormatFlags.NoPadding);
    }
}