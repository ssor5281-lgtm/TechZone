using System.ComponentModel;
using System.Globalization;
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.UI.Components;
using TechZone.UI.Forms;
using TechZone.UI.Forms.Create;
using TechZone.UI.Forms.Edit;

namespace TechZone.UI.Views;

public partial class ProductView : UserControl
{
    private readonly ProductRepository _productRepo = new();

    private List<Product> _products = [];
    private List<Product> _filteredProducts = [];

    private bool _isGridView;

    public ProductView()
    {
        InitializeComponent();

        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();
        ConfigureDropdowns();
        ConfigureViewSwitch();

        Load += ProductView_Load;
    }

    private void ProductView_Load(
        object? sender,
        EventArgs e)
    {
        LoadProducts();
    }

    private void LoadProducts()
    {
        _products =
            _productRepo
                .GetAll()
                .ToList();

        LoadCategoryDropdown();
        ApplyFiltersAndSort();
    }

    private void LoadCategoryDropdown()
    {
        string[] categories = _products
            .Select(x => x.CategoryName)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct()
            .OrderBy(x => x)
            .ToArray();

        tzDropdownButtonCategory.SetValues(
            new[] { "All Categories" }
                .Concat(categories)
                .ToArray());
    }

    private void ApplyFiltersAndSort()
    {
        string search =
            dataTableToolbar.SearchText.Trim();

        string sort =
            tzDropdownButtonSort.Value;

        string category =
            tzDropdownButtonCategory.Value;

        IEnumerable<Product> query =
            _products
                .Where(product =>
                    string.IsNullOrWhiteSpace(search) ||

                    product.Sku.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase)

                    || product.Name.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase)

                    || product.CategoryName.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase)

                    || product.Price
                        .ToString(
                            CultureInfo.InvariantCulture)
                        .Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase)

                    || product.Stock
                        .ToString()
                        .Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase)
                )
                .Where(product =>
                    category == "All Categories" ||
                    product.CategoryName == category);

        _filteredProducts = sort switch
        {
            "Newest" =>
                query
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList(),

            "Oldest" =>
                query
                    .OrderBy(x => x.CreatedAt)
                    .ToList(),

            "Product A-Z" =>
                query
                    .OrderBy(x => x.Name)
                    .ToList(),

            "Product Z-A" =>
                query
                    .OrderByDescending(x => x.Name)
                    .ToList(),

            "Stock Low-High" =>
                query
                    .OrderBy(x => x.Stock)
                    .ToList(),

            "Stock High-Low" =>
                query
                    .OrderByDescending(x => x.Stock)
                    .ToList(),

            "Price Low-High" =>
                query
                    .OrderBy(x => x.Price)
                    .ToList(),

            "Price High-Low" =>
                query
                    .OrderByDescending(x => x.Price)
                    .ToList(),

            _ =>
                query.ToList()
        };

        dataTablePagination1.TotalItems =
            _filteredProducts.Count;

        dataTablePagination1.GoToFirstPage();

        if (_isGridView)
        {
            productGridView.SetProducts(
                _filteredProducts);

            return;
        }

        LoadCurrentPage();
    }

    private void ConfigureDropdowns()
    {
        tzDropdownButtonSort.SetValues(
            "Newest",
            "Oldest",
            "Product A-Z",
            "Product Z-A",
            "Stock Low-High",
            "Stock High-Low",
            "Price Low-High",
            "Price High-Low");

        tzDropdownButtonSort.ValueChanged +=
            (_, _) => ApplyFiltersAndSort();

        tzDropdownButtonCategory.ValueChanged +=
            (_, _) => ApplyFiltersAndSort();
    }

    private void ConfigureToolbar()
    {
        dataTableToolbar.SearchChanged +=
            DataTableToolbar_SearchChanged;

        dataTableToolbar.RefreshClicked +=
            DataTableToolbar_RefreshClicked;

        dataTableToolbar.AddClicked +=
            DataTableToolbar_AddClicked;

        dataTableToolbar.AddButtonX = 755;
        dataTableToolbar.AddButtonWidth = 145;
        dataTableToolbar.AddButtonIcon = Resources.icon_product_add_white;
        dataTableToolbar.AddButtonText = "New Product";
    }

    private void ConfigureViewSwitch()
    {
        btnViewSwitch.Click +=
            BtnViewSwitch_Click;

        UpdateView();
    }

    private void BtnViewSwitch_Click(
        object? sender,
        EventArgs e)
    {
        _isGridView = !_isGridView;

        UpdateView();
    }

    private void UpdateView()
    {
        dataTableProduct.Visible =
            !_isGridView;

        productGridView.Visible =
            _isGridView;

        dataTablePagination1.Visible =
            !_isGridView;

        btnViewSwitch.BackgroundImage =
            _isGridView
                ? Resources.icon_table_view_switch
                : Resources.icon_grid_view;

        toolTip.SetToolTip(
            btnViewSwitch,
            _isGridView
                ? "Switch to Table View"
                : "Switch to Grid View");

        if (_isGridView)
        {
            productGridView.SetProducts(
                _filteredProducts);
        }
        else
        {
            LoadCurrentPage();
        }

        if (FindForm() is MainForm mainForm)
        {
            mainForm.SetTopbar(
                "Products",
                _isGridView
                    ? "Grid"
                    : "Table");
        }
    }

    private void DataTableToolbar_SearchChanged(
        object? sender,
        EventArgs e)
    {
        ApplyFiltersAndSort();
    }

    private void DataTableToolbar_RefreshClicked(
        object? sender,
        EventArgs e)
    {
        dataTableToolbar.ClearSearch();

        tzDropdownButtonSort.Reset();
        tzDropdownButtonCategory.Reset();

        LoadProducts();
    }

    private void DataTableToolbar_AddClicked(
        object? sender,
        EventArgs e)
    {
        using var form =
            new AddProductForm();

        if (form.ShowDialog(this) ==
            DialogResult.OK)
        {
            LoadProducts();
        }
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

        List<Product> pageItems =
            _filteredProducts
                .Skip(skip)
                .Take(dataTablePagination1.PageSize)
                .ToList();

        dataTableProduct.NumberStart =
            skip + 1;

        dataTableProduct.DataSource =
            pageItems;
    }

    private void ConfigureTable()
    {
        dataTableProduct.FontSize = 10F;

        dataTableProduct.ClearColumns();

        dataTableProduct.AddNumberColumn();

        dataTableProduct.AddTextColumn(
            "Sku",
            "SKU",
            "Sku");

        dataTableProduct.AddTextColumn(
            "Name",
            "Product Name",
            "Name");

        dataTableProduct.AddTextColumn(
            "CategoryName",
            "Category",
            "CategoryName");

        dataTableProduct.AddTextColumn(
            "Price",
            "Price ($)",
            "Price");

        dataTableProduct.AddTextColumn(
            "Stock",
            "Stock",
            "Stock");

        dataTableProduct.AddActionColumn(
            showDelete: true,
            showEdit: true,
            showView: false);

        dataTableProduct.EditClicked +=
            DataTableProduct_EditClicked;

        dataTableProduct.DeleteClicked +=
            DataTableProduct_DeleteClicked;

        dataTableProduct.SetFixedWidth(
            "No",
            70,
            70);

        dataTableProduct.SetFixedWidth(
            "Sku",
            150,
            150);

        dataTableProduct.SetFillColumn(
            "Name",
            250,
            int.MaxValue);

        dataTableProduct.SetFixedWidth(
            "CategoryName",
            220,
            220);

        dataTableProduct.SetFixedWidth(
            "Price",
            120,
            120);

        dataTableProduct.SetFixedWidth(
            "Stock",
            80,
            80);

        dataTableProduct.SetFixedWidth(
            "Action",
            150,
            150);

        dataTableProduct.SetAlignment(
            "No",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableProduct.SetHeaderAlignment(
            "No",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableProduct.SetAlignment(
            "Sku",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableProduct.SetHeaderAlignment(
            "Sku",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableProduct.SetAlignment(
            "Name",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableProduct.SetHeaderAlignment(
            "Name",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableProduct.SetAlignment(
            "CategoryName",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableProduct.SetHeaderAlignment(
            "CategoryName",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableProduct.SetAlignment(
            "Price",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableProduct.SetHeaderAlignment(
            "Price",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableProduct.SetAlignment(
            "Stock",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableProduct.SetHeaderAlignment(
            "Stock",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableProduct.SetHeaderAlignment(
            "Action",
            DataGridViewContentAlignment.MiddleCenter);
    }

    private void DataTableProduct_EditClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Product product)
            return;

        using var form =
            new EditProductForm(product);

        if (form.ShowDialog() ==
            DialogResult.OK)
        {
            LoadProducts();
        }
    }

    private void DataTableProduct_DeleteClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Product product)
            return;

        DialogResult result =
            MessageBox.Show(
                $@"Are you sure you want to delete ""{product.Name}""?",
                @"Delete Product",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        bool deleted =
            _productRepo.Delete(product.Id);

        if (!deleted)
        {
            MessageBox.Show(
                @"Failed to delete product.",
                @"Delete Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        LoadProducts();
    }
}