using TechZone.Core.Helpers;
using TechZone.Core.Models;

namespace TechZone.UI.Components;

public partial class ProductCard : UserControl
{
    private Product? _product;

    public Product? Product
    {
        get => _product;
        set
        {
            _product = value;
            UpdateCard();
        }
    }

    public ProductCard()
    {
        InitializeComponent();

        picProduct.SizeMode = PictureBoxSizeMode.CenterImage;

        btnCopySku.Click += BtnCopySku_Click;

        UpdateCard();
    }

    private void UpdateCard()
    {
        if (_product == null)
        {
            ClearCard();
            return;
        }

        lblName.Text = _product.Name;
        lblSku.Text = _product.Sku;
        lblCategory.Text = _product.CategoryName;
        lblPrice.Text = _product.Price.ToString("C2");
        lblStock.Text = $"Stock: {_product.Stock}";

        LoadProductImage(_product.ImagePath);
    }

    private void LoadProductImage(
        string? imagePath)
    {
        DisposeProductImage();

        if (string.IsNullOrWhiteSpace(imagePath))
        {
            SetImagePlaceholder();
            return;
        }

        string? fullPath =
            ImageHelper.GetFullPath(
                imagePath);

        if (string.IsNullOrWhiteSpace(fullPath) ||
            !File.Exists(fullPath))
        {
            SetImagePlaceholder();
            return;
        }

        try
        {
            using var stream =
                new FileStream(
                    fullPath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read);

            using var sourceImage =
                Image.FromStream(stream);

            picProduct.Image =
                CreateCenterCrop(
                    sourceImage,
                    picProduct.ClientSize);

            picProduct.BackColor =
                Color.White;
        }
        catch
        {
            SetImagePlaceholder();
        }
    }

    private Bitmap CreateCenterCrop(Image source, Size targetSize)
    {
        if (targetSize.Width <= 0 || targetSize.Height <= 0)
            throw new ArgumentException("Invalid target size.");

        double sourceRatio =
            (double)source.Width / source.Height;

        double targetRatio =
            (double)targetSize.Width / targetSize.Height;

        int cropWidth;
        int cropHeight;

        if (sourceRatio > targetRatio)
        {
            cropHeight = source.Height;
            cropWidth = (int)(source.Height * targetRatio);
        }
        else
        {
            cropWidth = source.Width;
            cropHeight = (int)(source.Width / targetRatio);
        }

        int cropX =
            (source.Width - cropWidth) / 2;

        int cropY =
            (source.Height - cropHeight) / 2;

        var result = new Bitmap(
            targetSize.Width,
            targetSize.Height);

        using var graphics = Graphics.FromImage(result);

        graphics.InterpolationMode =
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        graphics.PixelOffsetMode =
            System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

        graphics.SmoothingMode =
            System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        graphics.DrawImage(
            source,
            new Rectangle(
                0,
                0,
                targetSize.Width,
                targetSize.Height),
            new Rectangle(
                cropX,
                cropY,
                cropWidth,
                cropHeight),
            GraphicsUnit.Pixel);

        return result;
    }

    private void SetImagePlaceholder()
    {
        picProduct.Image = null;
        picProduct.BackColor =
            System.Drawing.Color.FromArgb(
                222,
                230,
                238);
    }

    private void DisposeProductImage()
    {
        if (picProduct.Image == null)
            return;

        Image image = picProduct.Image;

        picProduct.Image = null;

        image.Dispose();
    }

    private void ClearCard()
    {
        lblName.Text = "Product Name";
        lblSku.Text = "SKU-0001";
        lblCategory.Text = "Category";
        lblPrice.Text = "$0.00";
        lblStock.Text = "Stock: 0";

        DisposeProductImage();
        SetImagePlaceholder();
    }

    private void BtnCopySku_Click(object? sender, EventArgs e)
    {
        if (_product == null ||
            string.IsNullOrWhiteSpace(_product.Sku))
        {
            return;
        }

        try
        {
            Clipboard.SetText(_product.Sku);

            btnCopySku.Text = "Copied";

            var timer = new System.Windows.Forms.Timer
            {
                Interval = 1200
            };

            timer.Tick += (_, _) =>
            {
                timer.Stop();
                timer.Dispose();

                if (!IsDisposed)
                    btnCopySku.Text = "Copy";
            };

            timer.Start();
        }
        catch
        {
            // ignored
        }
    }
}