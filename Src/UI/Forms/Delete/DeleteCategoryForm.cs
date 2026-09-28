using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Delete;

public partial class DeleteCategoryForm : Form
{
    private readonly CategoryRepository _categoryRepo = new();
    private readonly Category _category;

    public DeleteCategoryForm(Category category)
    {
        InitializeComponent();

        _category = category;

        Load += DeleteCategoryForm_Load;
        existingCategoryRadioButton.CheckedChanged += RadioButton_CheckedChanged;
        noCategoryRadioButton.CheckedChanged += RadioButton_CheckedChanged;
        deleteButton.Click += DeleteButton_Click;
        cancelButton.Click += CancelButton_Click;
    }

    private void DeleteCategoryForm_Load(
        object? sender,
        EventArgs e)
    {
        titleLabel.Text = $@"Delete ""{_category.Name}""?";

        productCountLabel.Text =
            $@"This category contains {_category.ProductCount} products.";

        LoadCategories();
    }

    private void LoadCategories()
    {
        var categories = _categoryRepo
            .GetAll()
            .Where(x => x.Id != _category.Id)
            .OrderBy(x => x.Name)
            .ToList();

        categoryComboBox.DataSource = categories;
        categoryComboBox.DisplayMember = "Name";
        categoryComboBox.ValueMember = "Id";

        if (categories.Count == 0)
        {
            existingCategoryRadioButton.Enabled = false;
            existingCategoryRadioButton.Checked = false;

            noCategoryRadioButton.Checked = true;
            categoryComboBox.Enabled = false;

            return;
        }

        existingCategoryRadioButton.Checked = true;
        categoryComboBox.Enabled = true;
    }

    private void RadioButton_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        categoryComboBox.Enabled =
            existingCategoryRadioButton.Checked;
    }

    private void DeleteButton_Click(
        object? sender,
        EventArgs e)
    {
        int? targetCategoryId = null;
        string targetName = "No category";

        if (existingCategoryRadioButton.Checked)
        {
            if (categoryComboBox.SelectedValue == null)
            {
                MessageBox.Show(
                    @"Please select a category.",
                    @"Delete Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            targetCategoryId =
                Convert.ToInt32(categoryComboBox.SelectedValue);

            targetName = categoryComboBox.Text;
        }

        string message = _category.ProductCount > 0
            ? $"Are you sure you want to delete \"{_category.Name}\"?\n\n" +
              $"{_category.ProductCount} product(s) will be moved to \"{targetName}\"."
            : $"Are you sure you want to delete \"{_category.Name}\"?";

        DialogResult result = MessageBox.Show(
            message,
            @"Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        bool deleted = _categoryRepo.DeleteWithProducts(
            _category.Id,
            targetCategoryId);

        if (!deleted)
        {
            MessageBox.Show(
                @"Failed to delete category.",
                @"Delete Category",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}