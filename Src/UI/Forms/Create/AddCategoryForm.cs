using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Create;

public partial class AddCategoryForm : Form
{
    private readonly CategoryRepository _categoryRepo = new();

    public AddCategoryForm()
    {
        InitializeComponent();

        addButton.Click += AddButton_Click;
        cancelButton.Click += CancelButton_Click;
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        var category = new Category
        {
            Name = nameTextBox.Text.Trim(),
            Description = descriptionTextBox.Text.Trim()
        };

        bool added = _categoryRepo.Add(category);

        if (!added)
        {
            MessageBox.Show(
                @"Failed to add category.",
                @"Add Category",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            @"Category added successfully.",
            @"Add Category",
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

