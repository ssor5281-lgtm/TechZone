using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Edit;

public partial class EditProductForm : Form
{
    private readonly ProductRepository _productRepo;
    private readonly CategoryRepository _categoryRepo;
    private readonly Product _product;

    private string? _selectedImagePath;
    private string? _originalImagePath;
    private bool _removeImage;
    private string? _copiedImagePath;

    public EditProductForm(Product product)
    {
        InitializeComponent();

        _product = product;

        _productRepo =
            new ProductRepository();

        _categoryRepo =
            new CategoryRepository();

        chooseImageButton.Click +=
            ChooseImageButton_Click;

        removeImageButton.Click +=
            RemoveImageButton_Click;

        saveButton.Click +=
            SaveButton_Click;

        cancelButton.Click +=
            CancelButton_Click;

        LoadCategories();
        LoadProduct();
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
    }

    private void LoadProduct()
    {
        nameTextBox.Text =
            _product.Name;

        skuTextBox.Text =
            _product.Sku;

        priceTextBox.Text =
            _product.Price.ToString("0.##");

        categoryComboBox.SelectedValue =
            _product.CategoryId;

        _originalImagePath =
            _product.ImagePath;

        _selectedImagePath =
            _product.ImagePath;

        _removeImage = false;

        if (string.IsNullOrWhiteSpace(
                _product.ImagePath))
        {
            ImageHelper.SetPlaceholder(
                productPictureBox);

            UpdateImageControls(false);

            return;
        }

        LoadProductImage(
            _product.ImagePath);
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

            _removeImage = false;

            UpdateImageControls(true);
        }
        catch
        {
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
        _removeImage = true;

        ImageHelper.SetPlaceholder(
            productPictureBox);

        UpdateImageControls(false);
    }

    private void LoadProductImage(
        string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(
                imagePath))
        {
            ImageHelper.SetPlaceholder(
                productPictureBox);

            UpdateImageControls(false);

            return;
        }

        string? fullPath =
            ImageHelper.GetFullPath(
                imagePath);

        if (string.IsNullOrWhiteSpace(
                fullPath))
        {
            ImageHelper.SetPlaceholder(
                productPictureBox);

            UpdateImageControls(false);

            return;
        }

        bool loaded =
            ImageHelper.TryLoadPreview(
                productPictureBox,
                fullPath);

        UpdateImageControls(
            loaded);
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

    private void SaveButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidateProduct())
            return;

        try
        {
            string? oldImagePath =
                _product.ImagePath;

            string? newImagePath =
                oldImagePath;

            bool imageChanged =
                !string.Equals(
                    _selectedImagePath,
                    _originalImagePath,
                    StringComparison.OrdinalIgnoreCase);

            if (_removeImage)
            {
                newImagePath = null;
            }
            else if (
                imageChanged &&
                !string.IsNullOrWhiteSpace(
                    _selectedImagePath))
            {
                newImagePath =
                    SaveProductImage(
                        _product.Id);

                if (string.IsNullOrWhiteSpace(
                        newImagePath))
                {
                    MessageBox.Show(
                        @"The product image could not be saved.",
                        @"Image",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            _product.Name =
                nameTextBox.Text.Trim();

            _product.Sku =
                skuTextBox.Text.Trim();

            _product.Price =
                decimal.Parse(
                    priceTextBox.Text.Trim());

            _product.CategoryId =
                Convert.ToInt32(
                    categoryComboBox.SelectedValue);

            _product.ImagePath =
                newImagePath;

            bool updated =
                _productRepo.Update(
                    _product);

            if (!updated)
            {
                DeleteCopiedImage();

                MessageBox.Show(
                    @"Failed to update product.",
                    @"Update Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DeleteOldImageIfNeeded(
                oldImagePath,
                newImagePath);

            DialogResult =
                DialogResult.OK;

            Close();
        }
        catch
        {
            DeleteCopiedImage();

            MessageBox.Show(
                @"An error occurred while updating the product.",
                @"Update Product",
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

    private void DeleteOldImageIfNeeded(
        string? oldImagePath,
        string? newImagePath)
    {
        if (string.IsNullOrWhiteSpace(
                oldImagePath))
        {
            return;
        }

        if (string.Equals(
                oldImagePath,
                newImagePath,
                StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        ImageHelper.DeleteImage(
            oldImagePath);
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

    private bool ValidateProduct()
    {
        string name =
            nameTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(
                @"Product name is required.",
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

        string sku =
            skuTextBox.Text.Trim();

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

        if (categoryComboBox.SelectedValue == null)
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
            priceTextBox.SelectAll();

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
            priceTextBox.SelectAll();

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
