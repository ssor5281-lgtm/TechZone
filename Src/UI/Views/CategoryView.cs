using TechZone.Core.Enums;
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.Data.Services;
using TechZone.UI.Components;
using TechZone.UI.Forms;
using TechZone.UI.Forms.Create;
using TechZone.UI.Forms.Delete;
using TechZone.UI.Forms.Edit;
using TechZone.UI.Forms.View;

namespace TechZone.UI.Views;

public partial class CategoryView : UserControl
{
    private readonly CategoryRepository _categoryRepo = new();

    private List<Category> _categories = [];
    private List<Category> _filteredCategories = [];

    public CategoryView()
    {
        InitializeComponent();

        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();
        ConfigureDropdowns();
        ConfigureRoleAccess();

        Load += CategoryView_Load;
    }
    
    private void ConfigureRoleAccess()
    {
        bool isStaff =
            AuthService.CurrentUser?.Role == Role.Staff;

        if (isStaff)
        {
            dataTableToolbar.ShowAdd = false;
        }
    }

    private void CategoryView_Load(
        object? sender,
        EventArgs e)
    {
        LoadCategories();
    }

    private void LoadCategories()
    {
        _categories =
            _categoryRepo
                .GetAll()
                .ToList();

        ApplySearchAndSort();
    }

    private void ConfigureDropdowns()
    {
        tzDropdownButtonSort.SetValues(
            "Category A-Z",
            "Category Z-A",
            "Most Products",
            "Fewest Products");

        tzDropdownButtonSort.ValueChanged +=
            (_, _) => ApplySearchAndSort();
    }

    private void ApplySearchAndSort()
    {
        string search =
            dataTableToolbar.SearchText.Trim();

        string sort =
            tzDropdownButtonSort.Value;

        IEnumerable<Category> query =
            _categories.Where(category =>
                string.IsNullOrWhiteSpace(search)
                || category.Name.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase)
                || category.Description.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase)
                || category.ProductCount
                    .ToString()
                    .Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase));

        _filteredCategories = sort switch
        {
            "Category A-Z" =>
                query.OrderBy(x => x.Name).ToList(),

            "Category Z-A" =>
                query.OrderByDescending(x => x.Name).ToList(),

            "Most Products" =>
                query.OrderByDescending(x => x.ProductCount).ToList(),

            "Fewest Products" =>
                query.OrderBy(x => x.ProductCount).ToList(),

            _ =>
                query.ToList()
        };

        dataTablePagination1.TotalItems =
            _filteredCategories.Count;

        dataTablePagination1.GoToFirstPage();

        LoadCurrentPage();
    }

    private void ConfigureToolbar()
    {
        dataTableToolbar.SearchChanged +=
            DataTableToolbar_SearchChanged;

        dataTableToolbar.RefreshClicked +=
            DataTableToolbar_RefreshClicked;

        dataTableToolbar.AddClicked +=
            DataTableToolbar_AddClicked;

        dataTableToolbar.AddButtonIcon =
            Resources.icon_add_category_white;

        dataTableToolbar.AddButtonWidth = 155;
        dataTableToolbar.AddButtonText = "New Category";
        dataTableToolbar.AddButtonX = 565;
    }

    private void DataTableToolbar_SearchChanged(
        object? sender,
        EventArgs e)
    {
        ApplySearchAndSort();
    }

    private void DataTableToolbar_RefreshClicked(
        object? sender,
        EventArgs e)
    {
        dataTableToolbar.ClearSearch();
        tzDropdownButtonSort.Reset();

        LoadCategories();
    }

    private void DataTableToolbar_AddClicked(
        object? sender,
        EventArgs e)
    {
        using var form = new AddCategoryForm();

        if (form.ShowDialog(this) != DialogResult.OK)
            return;

        LoadCategories();

        if (FindForm() is MainForm mainForm)
            mainForm.RefreshDashboard();
    }

    private void ConfigurePagination()
    {
        dataTablePagination1.PageSize = 10;

        dataTablePagination1.PageChanged +=
            DataTablePagination_PageChanged;
    }

    private void DataTablePagination_PageChanged(
        object? sender,
        DataTablePageChangedEventArgs e)
    {
        LoadCurrentPage();
    }

    private void LoadCurrentPage()
    {
        int skip =
            (dataTablePagination1.CurrentPage - 1)
            * dataTablePagination1.PageSize;

        List<Category> pageItems =
            _filteredCategories
                .Skip(skip)
                .Take(dataTablePagination1.PageSize)
                .ToList();

        dataTableCategory.NumberStart =
            skip + 1;

        dataTableCategory.DataSource =
            pageItems;
    }

    private void ConfigureTable()
{
    dataTableCategory.ClearColumns();
    dataTableCategory.AddNumberColumn();
    dataTableCategory.FontSize = 10F;

    dataTableCategory.AddTextColumn(
        "Name",
        "Category Name",
        "Name");

    dataTableCategory.AddTextColumn(
        "ProductCount",
        "Product Count",
        "ProductCountDisplay");

    dataTableCategory.AddTextColumn(
        "Description",
        "Description",
        "Description");

    bool isStaff =
        AuthService.CurrentUser?.Role == Role.Staff;

    dataTableCategory.AddActionColumn(
        showEdit: !isStaff,
        showDelete: !isStaff,
        showView: true);

    dataTableCategory.ViewClicked +=
        DataTableCategory_ViewClicked;
    
    dataTableCategory.EditClicked +=
        DataTableCategory_EditClicked;

    dataTableCategory.DeleteClicked +=
        DataTableCategory_DeleteClicked;

    dataTableCategory.SetFixedWidth("No", 70, 70);
    dataTableCategory.SetFixedWidth("Name", 220, 220);
    dataTableCategory.SetFixedWidth("ProductCount", 150, 150);

    dataTableCategory.SetFillColumn(
        "Description",
        300,
        int.MaxValue);

    dataTableCategory.SetFixedWidth(
        "Action",
        isStaff ? 90 : 220,
        isStaff ? 90 : 220);

    dataTableCategory.SetAlignment(
        "No",
        DataGridViewContentAlignment.MiddleCenter);

    dataTableCategory.SetHeaderAlignment(
        "No",
        DataGridViewContentAlignment.MiddleCenter);

    dataTableCategory.SetAlignment(
        "Name",
        DataGridViewContentAlignment.MiddleLeft);

    dataTableCategory.SetHeaderAlignment(
        "Name",
        DataGridViewContentAlignment.MiddleLeft);

    dataTableCategory.SetAlignment(
        "ProductCount",
        DataGridViewContentAlignment.MiddleLeft);

    dataTableCategory.SetHeaderAlignment(
        "ProductCount",
        DataGridViewContentAlignment.MiddleLeft);

    dataTableCategory.SetAlignment(
        "Description",
        DataGridViewContentAlignment.MiddleLeft);

    dataTableCategory.SetHeaderAlignment(
        "Description",
        DataGridViewContentAlignment.MiddleLeft);

    dataTableCategory.SetHeaderAlignment(
        "Action",
        DataGridViewContentAlignment.MiddleCenter);
}

    private void DataTableCategory_EditClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Category category)
            return;

        using var form =
            new EditCategoryForm(category.Id);

        if (form.ShowDialog() != DialogResult.OK)
            return;

        LoadCategories();

        if (FindForm() is MainForm mainForm)
            mainForm.RefreshDashboard();
    }

    private void DataTableCategory_DeleteClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Category category)
            return;

        using var form =
            new DeleteCategoryForm(category);

        if (form.ShowDialog() != DialogResult.OK)
            return;

        LoadCategories();

        if (FindForm() is MainForm mainForm)
            mainForm.RefreshDashboard();
    }
    
    private void DataTableCategory_ViewClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Category category)
            return;

        using var form =
            new CategoryDetailForm(category);

        form.ShowDialog(this);
    }
}