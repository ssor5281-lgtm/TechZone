using TechZone.Core.Models;

namespace TechZone.UI.Forms.View;

public partial class CategoryDetailForm : Form
{
    private readonly Category _category;

    public CategoryDetailForm(Category category)
    {
        InitializeComponent();

        _category = category;

        LoadCategory();
    }

    private void LoadCategory()
    {
        labelCategoryName.Text =
            string.IsNullOrWhiteSpace(_category.Name)
                ? "-"
                : _category.Name;

        labelProductCount.Text =
            _category.ProductCount.ToString();

        labelDescription.Text =
            string.IsNullOrWhiteSpace(_category.Description)
                ? "No description"
                : _category.Description;
    }

    private void buttonClose_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }
}