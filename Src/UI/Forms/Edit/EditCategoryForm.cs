
using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Edit;

public partial class EditCategoryForm : Form
{
    private readonly CategoryRepository _categoryRepo = new();

    private readonly int _categoryId;

    public EditCategoryForm(int categoryId)
    {
        InitializeComponent();

        _categoryId = categoryId;

        Load += EditCategoryForm_Load;
        saveButton.Click += SaveButton_Click;
        cancelButton.Click += CancelButton_Click;
    }

    private void EditCategoryForm_Load(object? sender, EventArgs e)
    {
        LoadCategory();
    }

    private void LoadCategory()
    {
        var category = _categoryRepo.GetById(_categoryId);

        if (category == null)
        {
            MessageBox.Show(
                @"Category not found.",
                @"Edit Category",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            DialogResult = DialogResult.Cancel;
            Close();

            return;
        }

        nameTextBox.Text = category.Name;
        descriptionTextBox.Text = category.Description;
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        var category = new Category
        {
            Id = _categoryId,
            Name = nameTextBox.Text.Trim(),
            Description = descriptionTextBox.Text.Trim()
        };

        bool updated = _categoryRepo.Update(category);

        if (!updated)
        {
            MessageBox.Show(
                @"Failed to update category.",
                @"Edit Category",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            @"Category updated successfully.",
            @"Edit Category",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult = DialogResult.OK;
        Close();
    }

    private bool ValidateInput()
    {
        string name = nameTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(
                @"Please enter a category name.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nameTextBox.Focus();
            return false;
        }

        if (name.Length < 2)
        {
            MessageBox.Show(
                @"Category name must be at least 2 characters.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nameTextBox.Focus();
            return false;
        }

        return true;
    }

    private void CancelButton_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

