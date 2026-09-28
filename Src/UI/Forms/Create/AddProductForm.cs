using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Create;

public partial class AddProductForm : Form
{
    private readonly ProductRepository _productRepo = new();
    private readonly CategoryRepository _categoryRepo = new();

    private string? _selectedImagePath;
    private string? _copiedImagePath;

    public AddProductForm()
    {
        InitializeComponent();

        Load += AddProductForm_Load;

        chooseImageButton.Click += ChooseImageButton_Click;
        removeImageButton.Click += RemoveImageButton_Click;

        addButton.Click += AddButton_Click;
        cancelButton.Click += CancelButton_Click;

        ImageHelper.SetPlaceholder(
            productPictureBox);

        UpdateImageControls(false);
    }

    private void AddProductForm_Load(
        object? sender,
        EventArgs e)
    {
        LoadCategories();
    }

    private void LoadCategories()
    {
        var categories =
            _categoryRepo.GetAll();

        categoryComboBox.DataSource =
            categories;

        categoryComboBox.DisplayMember =
            "Name";

        categoryComboBox.ValueMember =
            "Id";

        categoryComboBox.SelectedIndex =
            -1;
    }

    private void ChooseImageButton_Click(
        object? sender,
        EventArgs e)
    {
        string? imagePath =
            ImageHelper.SelectImage(
                this,
                "Select Product Image");

        if (string.IsNullOrWhiteSpace(imagePath))
            return;

        try
        {
            ImageHelper.LoadPreview(
                productPictureBox,
                imagePath);

            _selectedImagePath =
                imagePath;

            UpdateImageControls(true);
        }
        catch
        {
            _selectedImagePath = null;

            ImageHelper.SetPlaceholder(
                productPictureBox);

            UpdateImageControls(false);

            MessageBox.Show(
                @"The selected image could not be loaded.",
                @"Image",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void RemoveImageButton_Click(
        object? sender,
        EventArgs e)
    {
        _selectedImagePath = null;

        ImageHelper.SetPlaceholder(
            productPictureBox);

        UpdateImageControls(false);
    }

    private void UpdateImageControls(
        bool hasImage)
    {
        chooseImageButton.Text =
            hasImage
                ? "Change Image"
                : "Choose Image";

        removeImageButton.Visible =
            hasImage;
    }

    private void AddButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            var product =
                new Product
                {
                    Sku =
                        skuTextBox.Text.Trim(),

                    Name =
                        nameTextBox.Text.Trim(),

                    CategoryId =
                        Convert.ToInt32(
                            categoryComboBox.SelectedValue),

                    Price =
                        decimal.Parse(
                            priceTextBox.Text.Trim())
                };

            bool added =
                _productRepo.Add(product);

            if (!added)
            {
                MessageBox.Show(
                    @"Failed to add product.",
                    @"Add Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            string? imagePath =
                SaveProductImage(
                    product.Id);

            if (!string.IsNullOrWhiteSpace(
                    imagePath))
            {
                product.ImagePath =
                    imagePath;

                if (!_productRepo.Update(
                        product))
                {
                    DeleteCopiedImage();

                    MessageBox.Show(
                        @"Product was added, but the image could not be saved.",
                        @"Add Product",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            MessageBox.Show(
                @"Product added successfully.",
                @"Add Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult =
                DialogResult.OK;

            Close();
        }
        catch
        {
            DeleteCopiedImage();

            MessageBox.Show(
                @"An error occurred while adding the product.",
                @"Add Product",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private string? SaveProductImage(
        int productId)
    {
        string? savedPath =
            ImageHelper.SaveImage(
                _selectedImagePath,
                AppPaths.ProductImages,
                $"product_{productId}");

        if (string.IsNullOrWhiteSpace(
                savedPath))
        {
            return null;
        }

        _copiedImagePath =
            savedPath;

        return Path.Combine(
            "Asset",
            "Products",
            $"product_{productId}.jpg");
    }

    private void DeleteCopiedImage()
    {
        if (string.IsNullOrWhiteSpace(
                _copiedImagePath))
        {
            return;
        }

        ImageHelper.DeleteImage(
            _copiedImagePath);

        _copiedImagePath = null;
    }

    private bool ValidateInput()
    {
        string sku =
            skuTextBox.Text.Trim();

        string name =
            nameTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(sku))
        {
            MessageBox.Show(
                @"Please enter a SKU.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            skuTextBox.Focus();

            return false;
        }

        if (sku.Length > 50)
        {
            MessageBox.Show(
                @"SKU cannot be longer than 50 characters.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            skuTextBox.Focus();

            return false;
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(
                @"Please enter a product name.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nameTextBox.Focus();

            return false;
        }

        if (name.Length < 2)
        {
            MessageBox.Show(
                @"Product name must be at least 2 characters.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nameTextBox.Focus();

            return false;
        }

        if (categoryComboBox.SelectedIndex < 0)
        {
            MessageBox.Show(
                @"Please select a category.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            categoryComboBox.Focus();

            return false;
        }

        if (!decimal.TryParse(
                priceTextBox.Text.Trim(),
                out decimal price))
        {
            MessageBox.Show(
                @"Please enter a valid price.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            priceTextBox.Focus();

            return false;
        }

        if (price < 0)
        {
            MessageBox.Show(
                @"Price cannot be negative.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            priceTextBox.Focus();

            return false;
        }

        return true;
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.Cancel;

        Close();
    }

    protected override void OnFormClosed(
        FormClosedEventArgs e)
    {
        ImageHelper.DisposeImage(
            productPictureBox);

        base.OnFormClosed(e);
    }
}
