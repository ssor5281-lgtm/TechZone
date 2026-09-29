using System.Globalization;
using TechZone.Core.Enums;
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.Data.Services;
using TechZone.UI.Components;
using TechZone.UI.Forms;
using TechZone.UI.Forms.Create;
using TechZone.UI.Forms.Edit;

namespace TechZone.UI.Views;

public partial class CustomerView : UserControl
{
    private readonly CustomerRepository _customerRepo = new();
    private bool _isStaff = AuthService.CurrentUser?.Role == Role.Staff;
    private List<Customer> _customers = [];
    private List<Customer> _filteredCustomers = [];

    public CustomerView()
    {
        InitializeComponent();

        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();
        ConfigureDropdowns();

        dataTableCustomer.EditClicked +=
            DataTableCustomer_EditClicked;

        dataTableCustomer.DeleteClicked +=
            DataTableCustomer_DeleteClicked;

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

        if (!_isStaff)
        {
            dataTableToolbar.AddButtonX = 755;
            dataTableToolbar.AddButtonIcon =
                Resources.icon_add_customer;

            dataTableToolbar.AddButtonWidth = 160;
            dataTableToolbar.AddButtonText = "New Customer";
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
        tzDropdownButtonFilter.Reset();

        LoadCustomers();
    }

    private void DataTableToolbar_AddClicked(
        object? sender,
        EventArgs e)
    {
        using var form = new AddCustomerForm();

        if (form.ShowDialog(this) != DialogResult.OK)
            return;

        LoadCustomers();

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

        List<Customer> pageItems =
            _filteredCustomers
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

    Role role =
        AuthService.CurrentUser?.Role ?? Role.Staff;

    bool isAdmin = role == Role.Admin;
    bool isStaff = role == Role.Staff;

    dataTableCustomer.AddActionColumn(
        showDelete: isAdmin,
        showEdit: !isStaff,
        showView: true);

    dataTableCustomer.SetFixedWidth(
        "No",
        60,
        60);

    dataTableCustomer.SetFixedWidth(
        "Name",
        200,
        200);

    dataTableCustomer.SetFixedWidth(
        "Phone",
        150,
        150);

    dataTableCustomer.SetFillColumn(
        "Email",
        180,
        int.MaxValue);

    dataTableCustomer.SetFixedWidth(
        "TotalSpent",
        140,
        140);

    int actionWidth = role switch
    {
        Role.Admin => 210,
        Role.Manager => 150,
        _ => 90
    };

    dataTableCustomer.SetFixedWidth(
        "Action",
        actionWidth,
        actionWidth);

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

    dataTableCustomer.SetAlignment(
        "Action",
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

        if (form.ShowDialog() != DialogResult.OK)
            return;

        LoadCustomers();

        if (FindForm() is MainForm mainForm)
            mainForm.RefreshDashboard();
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

        if (FindForm() is MainForm mainForm)
            mainForm.RefreshDashboard();
    }
}