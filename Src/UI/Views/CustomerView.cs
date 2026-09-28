using System.Globalization;
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.UI.Components;
using TechZone.UI.Forms.Create;
using TechZone.UI.Forms.Edit;

namespace TechZone.UI.Views;

public partial class CustomerView : UserControl
{
    private readonly CustomerRepository _customerRepo = new();

    private List<Customer> _customers = [];
    private List<Customer> _filteredCustomers = [];

    public CustomerView()
    {
        InitializeComponent();

        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();
        ConfigureDropdowns();

        dataTableCustomer.EditClicked += DataTableCustomer_EditClicked;
        dataTableCustomer.DeleteClicked += DataTableCustomer_DeleteClicked;
        Load += CustomerView_Load;
    }

    private void CustomerView_Load(
        object? sender,
        EventArgs e)
    {
        LoadCustomers();
    }

    private void LoadCustomers()
    {
        _customers = _customerRepo.GetAll().ToList();
        ApplyFiltersAndSort();
    }

    private void ApplyFiltersAndSort()
    {
        string search = dataTableToolbar.SearchText.Trim();
        string sort = tzDropdownButtonSort.Value;
        string filter = tzDropdownButtonFilter.Value;

        IEnumerable<Customer> query = _customers
            .Where(customer =>
                string.IsNullOrWhiteSpace(search)
                || customer.Name.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase)
                || customer.Phone.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase)
                || customer.Email.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase)
                || customer.PurchaseCount
                    .ToString()
                    .Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase)
                || customer.ItemsBought
                    .ToString()
                    .Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase)
                || customer.TotalSpent
                    .ToString(CultureInfo.CurrentCulture)
                    .Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase))
            .Where(customer =>
                filter switch
                {
                    "Has Purchases" =>
                        customer.PurchaseCount > 0,

                    "No Purchases" =>
                        customer.PurchaseCount == 0,

                    "1+ Purchase" =>
                        customer.PurchaseCount >= 1,

                    "5+ Purchases" =>
                        customer.PurchaseCount >= 5,

                    "10+ Purchases" =>
                        customer.PurchaseCount >= 10,

                    _ => true
                });

        _filteredCustomers = sort switch
        {
            "Customer A-Z" =>
                query.OrderBy(x => x.Name).ToList(),

            "Customer Z-A" =>
                query.OrderByDescending(x => x.Name).ToList(),

            "Most Purchases" =>
                query.OrderByDescending(x => x.PurchaseCount).ToList(),

            "Most Items Bought" =>
                query.OrderByDescending(x => x.ItemsBought).ToList(),

            "Highest Spending" =>
                query.OrderByDescending(x => x.TotalSpent).ToList(),

            "Lowest Spending" =>
                query.OrderBy(x => x.TotalSpent).ToList(),

            "Latest Purchase" =>
                query.OrderByDescending(x => x.LastPurchase).ToList(),

            "Oldest Purchase" =>
                query.OrderBy(x => x.LastPurchase).ToList(),

            _ => query.ToList()
        };

        dataTablePagination1.TotalItems =
            _filteredCustomers.Count;

        dataTablePagination1.GoToFirstPage();
        LoadCurrentPage();
    }

    private void ConfigureDropdowns()
    {
        tzDropdownButtonSort.SetValues(
            "Customer A-Z",
            "Customer Z-A",
            "Most Purchases",
            "Most Bought",
            "Highest Spend",
            "Lowest Spend",
            "Latest Purchase",
            "Oldest Purchase");

        tzDropdownButtonFilter.SetValues(
            "All",
            "Has Purchases",
            "No Purchases",
            "1+ Purchase",
            "5+ Purchases",
            "10+ Purchases");

        tzDropdownButtonSort.ValueChanged +=
            (_, _) => ApplyFiltersAndSort();

        tzDropdownButtonFilter.ValueChanged +=
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
        dataTableToolbar.AddButtonIcon = Resources.icon_add_customer;
        dataTableToolbar.AddButtonWidth = 160;
        dataTableToolbar.AddButtonText = "New Customer";
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
        tzDropdownButtonFilter.Reset();

        LoadCustomers();
    }

    private void DataTableToolbar_AddClicked(
        object? sender,
        EventArgs e)
    {
        using var form = new AddCustomerForm();

        if (form.ShowDialog(this) == DialogResult.OK)
            LoadCustomers();
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

        List<Customer> pageItems = _filteredCustomers
            .Skip(skip)
            .Take(dataTablePagination1.PageSize)
            .ToList();

        dataTableCustomer.NumberStart = skip + 1;
        dataTableCustomer.DataSource = pageItems;
    }

    private void ConfigureTable()
    {
        dataTableCustomer.ClearColumns();

        dataTableCustomer.AddNumberColumn();

        dataTableCustomer.FontSize = 10F;

        dataTableCustomer.AddTextColumn(
            "Name",
            "Customer Name",
            "Name");

        dataTableCustomer.AddTextColumn(
            "Phone",
            "Phone",
            "Phone");

        dataTableCustomer.AddTextColumn(
            "Email",
            "Email",
            "Email");

        dataTableCustomer.AddTextColumn(
            "TotalSpent",
            "Total Spent",
            "TotalSpentDisplay");

        dataTableCustomer.AddActionColumn(showDelete:true, showEdit:true,showView:false);

        dataTableCustomer.SetFixedWidth(
            "No",
            70,
            70);

        dataTableCustomer.SetFixedWidth(
            "Name",
            200,
            200);

        dataTableCustomer.SetFixedWidth(
            "Phone",
            160,
            160);

        dataTableCustomer.SetFillColumn(
            "Email",
            200,
            int.MaxValue);

        dataTableCustomer.SetFixedWidth(
            "TotalSpent",
            150,
            150);

        dataTableCustomer.SetFixedWidth(
            "Action",
            150,
            150);

        dataTableCustomer.SetAlignment(
            "No",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableCustomer.SetHeaderAlignment(
            "No",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableCustomer.SetAlignment(
            "Name",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableCustomer.SetHeaderAlignment(
            "Name",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableCustomer.SetAlignment(
            "Phone",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableCustomer.SetHeaderAlignment(
            "Phone",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableCustomer.SetAlignment(
            "Email",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableCustomer.SetHeaderAlignment(
            "Email",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableCustomer.SetAlignment(
            "TotalSpent",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableCustomer.SetHeaderAlignment(
            "TotalSpent",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableCustomer.SetHeaderAlignment(
            "Action",
            DataGridViewContentAlignment.MiddleCenter);
    }

    private void DataTableCustomer_EditClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Customer customer)
            return;

        using var form = new EditCustomerForm(customer);

        if (form.ShowDialog() == DialogResult.OK)
            LoadCustomers();
    }

    private void DataTableCustomer_DeleteClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not Customer customer)
            return;

        DialogResult result = MessageBox.Show(
            $@"Are you sure you want to delete ""{customer.Name}""?",
            @"Delete Customer",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        bool deleted = _customerRepo.Delete(customer.Id);

        if (!deleted)
        {
            MessageBox.Show(
                @"Failed to delete customer.",
                @"Delete Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        LoadCustomers();
    }
}