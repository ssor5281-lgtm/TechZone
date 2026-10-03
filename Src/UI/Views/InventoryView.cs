using TechZone.Core.Enums;
using TechZone.Core.Models;
using TechZone.Core.Settings;
using TechZone.Data.Repositories;
using TechZone.Data.Services;
using TechZone.UI.Components;
using TechZone.UI.Forms;
using TechZone.UI.Forms.Edit;

namespace TechZone.UI.Views;

public partial class InventoryView : UserControl
{
    private bool _isStaff = AuthService.CurrentUser?.Role == Role.Staff;
    private readonly InventoryRepository _inventoryRepo = new();
    private List<Inventory> _inventories = [];
    private List<Inventory> _filteredInventories = [];

    public InventoryView()
    {
        InitializeComponent();
        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();
        ConfigureDropdowns();

        dataTableInventory.EditClicked +=
            DataTableInventory_EditClicked;

        Load += (_, _) => LoadInventory();
    }
        
    private void LoadInventory()
    {
        _inventories = _inventoryRepo.GetAll().ToList();
        LoadCategoryDropdown();
        UpdateSummaryCards();
        ApplyFilters();
    }

    private void LoadCategoryDropdown()
    {
        string[] categories = _inventories
            .Select(x => x.CategoryName)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct()
            .OrderBy(x => x)
            .ToArray();

        categoryDropdown.SetValues(
            new[] { "All Categories" }
                .Concat(categories)
                .ToArray());
    }

    private void ApplyFilters()
    {
        string search = dataTableToolbar.SearchText.Trim();
        string status = statusDropdown.Value;
        string category = categoryDropdown.Value;

        _filteredInventories = _inventories
            .Where(x =>
                string.IsNullOrWhiteSpace(search) ||
                x.ProductName.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||
                x.Stock.ToString().Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||
                x.GetStatus().Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase))
            .Where(x =>
                status == "All Status" ||
                x.GetStatus() == status)
            .Where(x =>
                category == "All Categories" ||
                x.CategoryName == category)
            .ToList();

        dataTablePagination1.TotalItems =
            _filteredInventories.Count;

        dataTablePagination1.GoToFirstPage();
        LoadCurrentPage();
    }

    private void LoadCurrentPage()
    {
        int skip =
            (dataTablePagination1.CurrentPage - 1) *
            dataTablePagination1.PageSize;

        dataTableInventory.NumberStart = skip + 1;

        dataTableInventory.DataSource =
            _filteredInventories
                .Skip(skip)
                .Take(dataTablePagination1.PageSize)
                .ToList();
    }

    private void ConfigurePagination()
    {
        dataTablePagination1.PageSize = 10;

        dataTablePagination1.PageChanged +=
            (_, _) => LoadCurrentPage();
    }

    private void ConfigureToolbar()
    {
        dataTableToolbar.ShowAdd = false;

        dataTableToolbar.SearchChanged +=
            (_, _) => ApplyFilters();

        dataTableToolbar.RefreshClicked +=
            (_, _) =>
            {
                dataTableToolbar.ClearSearch();
                statusDropdown.Reset();
                LoadInventory();
            };
    }

    private void ConfigureDropdowns()
    {
        statusDropdown.SetValues(
            "All Status",
            "In Stock",
            "Low Stock",
            "Out of Stock");

        statusDropdown.ValueChanged +=
            (_, _) => ApplyFilters();

        categoryDropdown.ValueChanged +=
            (_, _) => ApplyFilters();
    }

    private void UpdateSummaryCards()
    {
        int threshold = AppSettings.LowStockThreshold;

        cardStateStockIn.ValueColor = Color.Green;
        cardStateStockLow.ValueColor = Color.Goldenrod;
        cardStateStockOut.ValueColor = Color.Red;
        cardStateTotalProduct.ValueColor = Color.Blue;

        cardStateTotalProduct.Value =
            _inventories.Count.ToString();

        cardStateStockIn.Value =
            _inventories.Count(
                x => x.Stock > threshold).ToString();

        cardStateStockLow.Value =
            _inventories.Count(
                x => x.Stock > 0 &&
                     x.Stock <= threshold).ToString();

        cardStateStockOut.Value =
            _inventories.Count(
                x => x.Stock == 0).ToString();
    }

    private void ConfigureTable()
    {
        dataTableInventory.ClearColumns();
        dataTableInventory.FontSize = 10F;

        dataTableInventory.AddNumberColumn();
        dataTableInventory.AddTextColumn(
            "Sku",
            "SKU",
            "Sku");

        dataTableInventory.AddTextColumn(
            "ProductName",
            "Product",
            "ProductName");

        dataTableInventory.AddTextColumn(
            "CategoryName",
            "Category",
            "CategoryName");

        dataTableInventory.AddTextColumn(
            "Stock",
            "Stock",
            "Stock");

        dataTableInventory.AddTextColumn(
            "Status",
            "Status",
            "Status");

        dataTableInventory.AddTextColumn(
            "LastUpdated",
            "Last Updated",
            "LastUpdated");
        
        if (!_isStaff)
        {
            dataTableInventory.AddActionColumn(
                showEdit: true,
                showDelete: false,
                showView: false);
        }
        dataTableInventory.SetFixedWidth(
            "No",
            70,
            70);

        dataTableInventory.SetFixedWidth(
            "Sku",
            150,
            150);

        dataTableInventory.SetFillColumn(
            "ProductName",
            200,
            1000);

        dataTableInventory.SetFixedWidth(
            "CategoryName",
            220,
            220);

        dataTableInventory.SetFixedWidth(
            "Stock",
            80,
            80);

        dataTableInventory.SetFixedWidth(
            "Status",
            130,
            130);

        dataTableInventory.SetFixedWidth(
            "LastUpdated",
            180,
            180);

        dataTableInventory.SetFixedWidth(
            "Action",
            90,
            90);

        Center(
            "No",
            "Stock",
            "Status",
            "LastUpdated",
            "Action");

        AlignLeft(
            "Sku",
            "ProductName",
            "CategoryName");
    }

    private void Center(params string[] columns)
    {
        foreach (string column in columns)
        {
            dataTableInventory.SetAlignment(
                column,
                DataGridViewContentAlignment.MiddleCenter);

            dataTableInventory.SetHeaderAlignment(
                column,
                DataGridViewContentAlignment.MiddleCenter);
        }
    }

    private void AlignLeft(params string[] columns)
    {
        foreach (string column in columns)
        {
            dataTableInventory.SetAlignment(
                column,
                DataGridViewContentAlignment.MiddleLeft);

            dataTableInventory.SetHeaderAlignment(
                column,
                DataGridViewContentAlignment.MiddleLeft);
        }
    }

    private void DataTableInventory_EditClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Inventory inventory)
            return;

        using EditInventoryForm form = new(inventory);

        if (form.ShowDialog() != DialogResult.OK)
            return;

        inventory.Stock = form.UpdatedStock;

        if (!_inventoryRepo.Update(inventory))
            return;

        LoadInventory();

        if (FindForm() is MainForm mainForm)
            mainForm.RefreshDashboard();
    }
}