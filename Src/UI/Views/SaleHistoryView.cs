
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

public partial class SaleHistoryView : UserControl
{
    private readonly SaleRepository _saleRepo = new();
    private readonly InvoiceRepository _invoiceRepo = new();
    private readonly CustomerRepository _customerRepo = new();
    private readonly UserRepository _userRepo = new();

    private List<InvoiceRow> _sales = [];
    private List<InvoiceRow> _filteredSales = [];

    public SaleHistoryView()
    {
        InitializeComponent();

        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();
        ConfigureDropdowns();

        dataTableSaleHistory.ViewClicked +=
            DataTableSaleHistory_ViewClicked;

        Load += (_, _) => LoadSales();
    }

    private void LoadSales()
    {
        try
        {
            List<Invoice> invoices =
                _invoiceRepo.GetAll();

            List<Sale> completedSales =
                _saleRepo.GetCompletedSales();

            List<Customer> customers =
                _customerRepo.GetAll();

            List<User> users =
                _userRepo.GetAll();

            _sales = invoices
                .Join(
                    completedSales,
                    invoice => invoice.SaleId,
                    sale => sale.Id,
                    (invoice, sale) => new
                    {
                        Invoice = invoice,
                        Sale = sale
                    })
                .Select(x =>
                    CreateRow(
                        x.Invoice,
                        x.Sale,
                        customers,
                        users))
                .ToList();

            ApplyFilters();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $@"Failed to load sale history.

{ex.Message}",
                @"Sale History",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private InvoiceRow CreateRow(
        Invoice invoice,
        Sale sale,
        List<Customer> customers,
        List<User> users)
    {
        Customer? customer =
            invoice.CustomerId is int customerId
                ? customers.FirstOrDefault(
                    x => x.Id == customerId)
                : null;

        User? staff =
            users.FirstOrDefault(
                x => x.Id == sale.UserId);

        int itemCount =
            _saleRepo
                .GetDetails(sale.Id)
                .Sum(x => x.Quantity);

        return new InvoiceRow
        {
            InvoiceId = invoice.Id,
            SaleId = sale.Id,
            InvoiceNumber = invoice.InvoiceNumber,

            Invoice =
                invoice.InvoiceCode,

            Customer =
                customer?.Name ?? "-",

            Staff =
                staff?.Username ?? "-",

            SaleType =
                invoice.DisplaySaleType,

            ItemCount =
                itemCount,

            Items =
                itemCount.ToString(),

            Subtotal =
                $"${invoice.SubtotalAmount:N2}",

            SubtotalValue =
                invoice.SubtotalAmount,

            Discount =
                $"${invoice.DiscountAmount:N2}",

            DiscountValue =
                invoice.DiscountAmount,

            Total =
                $"${invoice.TotalAmount:N2}",

            TotalValue =
                invoice.TotalAmount,

            SaleDate =
                invoice.InvoiceDate.ToString("dd MMM yyyy"),

            SaleDateValue =
                invoice.InvoiceDate
        };
    }

    private void ApplyFilters()
    {
        string search =
            dataTableToolbar.SearchText.Trim();

        string filter =
            tzDropdownButtonFilter.Value;

        IEnumerable<InvoiceRow> query =
            _sales;

        query = filter switch
        {
            "Sale" =>
                query.Where(x =>
                    x.SaleType == "Sale"),

            "Quick Sale" =>
                query.Where(x =>
                    x.SaleType == "Quick Sale"),

            "Order" =>
                query.Where(x =>
                    x.SaleType == "Order"),

            _ =>
                query
        };

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.Invoice.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||

                x.Customer.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase) ||

                x.Staff.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase));
        }

        query = tzDropdownButtonSort.Value switch
        {
            "Invoice Newest" =>
                query.OrderByDescending(
                    x => x.InvoiceNumber),

            "Invoice Oldest" =>
                query.OrderBy(
                    x => x.InvoiceNumber),

            "Sale Newest" =>
                query.OrderByDescending(
                    x => x.SaleDateValue),

            "Sale Oldest" =>
                query.OrderBy(
                    x => x.SaleDateValue),

            "Total High-Low" =>
                query.OrderByDescending(
                    x => x.TotalValue),

            "Total Low-High" =>
                query.OrderBy(
                    x => x.TotalValue),

            "Customer A-Z" =>
                query.OrderBy(
                    x => x.Customer),

            "Customer Z-A" =>
                query.OrderByDescending(
                    x => x.Customer),

            _ =>
                query
        };

        _filteredSales =
            query.ToList();

        dataTablePagination1.TotalItems =
            _filteredSales.Count;

        dataTablePagination1.GoToFirstPage();

        LoadCurrentPage();
    }

    private void LoadCurrentPage()
    {
        int skip =
            (dataTablePagination1.CurrentPage - 1) *
            dataTablePagination1.PageSize;

        dataTableSaleHistory.NumberStart =
            skip + 1;

        dataTableSaleHistory.DataSource =
            _filteredSales
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

                tzDropdownButtonSort.Reset();
                tzDropdownButtonFilter.Reset();

                LoadSales();
            };
    }

    private void ConfigureDropdowns()
    {
        tzDropdownButtonSort.SetValues(
            "Invoice Newest",
            "Invoice Oldest",
            "Sale Newest",
            "Sale Oldest",
            "Total High-Low",
            "Total Low-High",
            "Customer A-Z",
            "Customer Z-A");

        tzDropdownButtonFilter.SetValues(
            "All Sales",
            "Sale",
            "Quick Sale",
            "Order");

        tzDropdownButtonSort.ValueChanged +=
            (_, _) => ApplyFilters();

        tzDropdownButtonFilter.ValueChanged +=
            (_, _) => ApplyFilters();
    }

    private void ConfigureTable()
    {
        dataTableSaleHistory.ClearColumns();
        dataTableSaleHistory.ClearCustomActionButtons();
        dataTableSaleHistory.FontSize = 9.5F;

        dataTableSaleHistory.AddNumberColumn();

        dataTableSaleHistory.AddTextColumn(
            "Invoice",
            "Invoice",
            nameof(InvoiceRow.Invoice));

        dataTableSaleHistory.AddTextColumn(
            "Customer",
            "Customer",
            nameof(InvoiceRow.Customer));

        dataTableSaleHistory.AddTextColumn(
            "Staff",
            "Staff",
            nameof(InvoiceRow.Staff));

        dataTableSaleHistory.AddTextColumn(
            "Type",
            "Type",
            nameof(InvoiceRow.SaleType));

        dataTableSaleHistory.AddTextColumn(
            "Items",
            "Items",
            nameof(InvoiceRow.Items));

        dataTableSaleHistory.AddTextColumn(
            "Subtotal",
            "Subtotal",
            nameof(InvoiceRow.Subtotal));

        dataTableSaleHistory.AddTextColumn(
            "Discount",
            "Discount",
            nameof(InvoiceRow.Discount));

        dataTableSaleHistory.AddTextColumn(
            "Total",
            "Total",
            nameof(InvoiceRow.Total));

        dataTableSaleHistory.AddTextColumn(
            "SaleDate",
            "Sale Date",
            nameof(InvoiceRow.SaleDate));

        dataTableSaleHistory.AddActionColumn(
            showView: true,
            showEdit: false,
            showDelete: false);

        dataTableSaleHistory.SetFixedWidth(
            "No",
            70,
            70);

        dataTableSaleHistory.SetFixedWidth(
            "Invoice",
            120,
            120);

        dataTableSaleHistory.SetFillColumn(
            "Customer",
            110,
            500);

        dataTableSaleHistory.SetFillColumn(
            "Staff",
            110,
            500);

        dataTableSaleHistory.SetFixedWidth(
            "Type",
            110,
            110);

        dataTableSaleHistory.SetFixedWidth(
            "Items",
            80,
            80);

        dataTableSaleHistory.SetFixedWidth(
            "Subtotal",
            105,
            105);

        dataTableSaleHistory.SetFixedWidth(
            "Discount",
            105,
            105);

        dataTableSaleHistory.SetFixedWidth(
            "Total",
            105,
            105);

        dataTableSaleHistory.SetFixedWidth(
            "SaleDate",
            130,
            130);

        dataTableSaleHistory.SetFixedWidth(
            "Action",
            90,
            90);

        Center(
            "No",
            "Invoice",
            "Type",
            "Items",
            "Subtotal",
            "Discount",
            "Total",
            "SaleDate",
            "Action");

        AlignLeft(
            "Customer",
            "Staff");
    }

    private void Center(
        params string[] columns)
    {
        foreach (string column in columns)
        {
            dataTableSaleHistory.SetAlignment(
                column,
                DataGridViewContentAlignment.MiddleCenter);

            dataTableSaleHistory.SetHeaderAlignment(
                column,
                DataGridViewContentAlignment.MiddleCenter);
        }
    }

    private void AlignLeft(
        params string[] columns)
    {
        foreach (string column in columns)
        {
            dataTableSaleHistory.SetAlignment(
                column,
                DataGridViewContentAlignment.MiddleLeft);

            dataTableSaleHistory.SetHeaderAlignment(
                column,
                DataGridViewContentAlignment.MiddleLeft);
        }
    }

    private void DataTableSaleHistory_ViewClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not InvoiceRow row)
            return;

        Invoice? invoice =
            _invoiceRepo.GetById(row.InvoiceId);

        if (invoice is null)
        {
            MessageBox.Show(
                @"The invoice could not be found.",
                @"Invoice",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            LoadSales();
            return;
        }

        ShowInvoiceDetails(invoice, row);
    }

    private static void ShowInvoiceDetails(
        Invoice invoice,
        InvoiceRow row)
    {
        MessageBox.Show(
            $@"Invoice: {invoice.InvoiceCode}
Sale Type: {invoice.DisplaySaleType}
Customer: {row.Customer}
Staff: {row.Staff}
Items: {row.Items}
Date: {invoice.InvoiceDate:dd MMM yyyy}

Subtotal: ${invoice.SubtotalAmount:N2}
Discount: ${invoice.DiscountAmount:N2}
Total: ${invoice.TotalAmount:N2}",
            @"Invoice Details",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private sealed class InvoiceRow
    {
        public int InvoiceId { get; init; }
        public int SaleId { get; init; }
        public int InvoiceNumber { get; init; }

        public string Invoice { get; init; } = "-";
        public string Customer { get; init; } = "-";
        public string Staff { get; init; } = "-";
        public string SaleType { get; init; } = "-";

        public int ItemCount { get; init; }
        public string Items { get; init; } = "0";

        public string Subtotal { get; init; } = "$0.00";
        public decimal SubtotalValue { get; init; }

        public string Discount { get; init; } = "$0.00";
        public decimal DiscountValue { get; init; }

        public string Total { get; init; } = "$0.00";
        public decimal TotalValue { get; init; }

        public string SaleDate { get; init; } = "-";
        public DateTime SaleDateValue { get; init; }
    }
}