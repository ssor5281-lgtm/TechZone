using TechZone.Core.Enums;
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.UI.Components;
using TechZone.UI.Effects;
using TechZone.UI.Forms.Create;
using TechZone.UI.Forms.Dialog;

namespace TechZone.UI.Views;

public partial class OrderView : UserControl
{
    private readonly SaleRepository _saleRepo = new();
    private readonly CustomerRepository _customerRepo = new();
    private readonly UserRepository _userRepo = new();

    private List<Sale> _orders = [];
    private List<OrderRow> _filteredOrders = [];
    private List<Customer> _customers = [];
    private List<User> _users = [];

    public OrderView()
    {
        InitializeComponent();

        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();
        ConfigureDropdowns();

        newOrderButton.TzEffect(
            nameof(newOrderButton.BackColor),
            Color.RoyalBlue,
            Color.FromArgb(59, 130, 246));

        dataTableOrder.ViewClicked += DataTableOrder_ViewClicked;
        dataTableOrder.CustomActionClicked += DataTableOrder_CustomActionClicked;
        newOrderButton.Click += newOrderButton_Click;
        Load += (_, _) => LoadOrders();
    }

    private void LoadOrders()
    {
        try
        {
            _customers = _customerRepo.GetAll();
            _users = _userRepo.GetAll();

            _orders =
            [
                .. _saleRepo.GetPendingSales(),
                .. _saleRepo.GetCancelledSales()
            ];

            ApplyFilters();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $@"Failed to load orders.

{ex.Message}",
                @"Orders",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void ApplyFilters()
    {
        string search = dataTableToolbar.SearchText.Trim();
        string status = statusDropdown.Value;

        IEnumerable<OrderRow> query = _orders
            .Select(CreateRow)
            .Where(x => status switch
            {
                "Pending" => x.Status == "Pending",
                "Canceled" => x.Status == "Canceled",
                _ => true
            });

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.Order.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                x.Customer.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                x.Staff.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        query = sortDropdown.Value switch
        {
            "Order Newest" => query.OrderByDescending(x => x.OrderNumber),
            "Order Oldest" => query.OrderBy(x => x.OrderNumber),
            "Pickup Date Newest" => query.OrderByDescending(x => x.PickupDateValue),
            "Pickup Date Oldest" => query.OrderBy(x => x.PickupDateValue),
            "Total High-Low" => query.OrderByDescending(x => x.TotalValue),
            "Total Low-High" => query.OrderBy(x => x.TotalValue),
            "Customer A-Z" => query.OrderBy(x => x.Customer),
            "Customer Z-A" => query.OrderByDescending(x => x.Customer),
            _ => query
        };

        _filteredOrders = query.ToList();
        dataTablePagination.TotalItems = _filteredOrders.Count;
        dataTablePagination.GoToFirstPage();
        LoadCurrentPage();
    }

    private void LoadCurrentPage()
    {
        int skip = (dataTablePagination.CurrentPage - 1) * dataTablePagination.PageSize;

        dataTableOrder.NumberStart = skip + 1;
        dataTableOrder.DataSource = _filteredOrders
            .Skip(skip)
            .Take(dataTablePagination.PageSize)
            .ToList();
    }

    private void ConfigurePagination()
    {
        dataTablePagination.PageSize = 10;
        dataTablePagination.PageChanged += (_, _) => LoadCurrentPage();
    }

    private void ConfigureToolbar()
    {
        dataTableToolbar.ShowAdd = false;
        dataTableToolbar.SearchChanged += (_, _) => ApplyFilters();

        dataTableToolbar.RefreshClicked += (_, _) =>
        {
            dataTableToolbar.ClearSearch();
            statusDropdown.Reset();
            sortDropdown.Reset();
            LoadOrders();
        };
    }

    private void ConfigureDropdowns()
    {
        statusDropdown.SetValues(
            "All Orders",
            "Pending",
            "Canceled");

        sortDropdown.SetValues(
            "Order Newest",
            "Order Oldest",
            "Pickup Date Newest",
            "Pickup Date Oldest",
            "Total High-Low",
            "Total Low-High",
            "Customer A-Z",
            "Customer Z-A");

        statusDropdown.ValueChanged += (_, _) => ApplyFilters();
        sortDropdown.ValueChanged += (_, _) => ApplyFilters();
    }

    private void ConfigureTable()
    {
        dataTableOrder.ClearColumns();
        dataTableOrder.ClearCustomActionButtons();
        dataTableOrder.FontSize = 10F;

        dataTableOrder.AddNumberColumn();
        dataTableOrder.AddTextColumn("Order", "Order", "Order");
        dataTableOrder.AddTextColumn("Customer", "Customer", "Customer");
        dataTableOrder.AddTextColumn("Staff", "Staff", "Staff");
        dataTableOrder.AddTextColumn("Items", "Items", "Items");
        dataTableOrder.AddTextColumn("Total", "Total", "Total");
        dataTableOrder.AddTextColumn("PickupDate", "Pickup Date", "PickupDate");
        dataTableOrder.AddTextColumn("Status", "Status", "Status");

        dataTableOrder.AddActionColumn(
            showView: true,
            showEdit: false,
            showDelete: false);

        dataTableOrder.AddCustomActionButton(
            name: "collectButton",
            image: Resources.icon_arrow,
            hint: "Confirm Pickup",
            position: 3,
            width: 50,
            height: 28,
            backgroundColor: Color.RoyalBlue,
            hoverColor: Color.FromArgb(96, 165, 250),
            textColor: Color.White,
            showBorder: false);

        dataTableOrder.AddCustomActionButton(
            name: "cancelButton",
            image: Resources.icon_order_cancel_white,
            hint: "Cancel Order",
            position: 2,
            width: 50,
            height: 28,
            backgroundColor: Color.FromArgb(239, 68, 68),
            hoverColor: Color.FromArgb(248, 113, 113),
            textColor: Color.White,
            showBorder: false);
        dataTableOrder.SetFixedWidth("No", 70, 70);
        dataTableOrder.SetFixedWidth("Order", 130, 130);
        dataTableOrder.SetFillColumn("Customer", 150, 500);
        dataTableOrder.SetFillColumn("Staff", 150, 500);
        dataTableOrder.SetFixedWidth("Items", 85, 85);
        dataTableOrder.SetFixedWidth("Total", 110, 110);
        dataTableOrder.SetFixedWidth("PickupDate", 140, 140);
        dataTableOrder.SetFixedWidth("Status", 110, 110);
        dataTableOrder.SetFixedWidth("Action", 200, 200);

        Center("No", "Items", "PickupDate", "Status", "Action", "Total");
        AlignLeft("Order", "Customer", "Staff");
    }

    private void Center(params string[] columns)
    {
        foreach (string column in columns)
        {
            dataTableOrder.SetAlignment(
                column,
                DataGridViewContentAlignment.MiddleCenter);

            dataTableOrder.SetHeaderAlignment(
                column,
                DataGridViewContentAlignment.MiddleCenter);
        }
    }

    private void AlignLeft(params string[] columns)
    {
        foreach (string column in columns)
        {
            dataTableOrder.SetAlignment(
                column,
                DataGridViewContentAlignment.MiddleLeft);

            dataTableOrder.SetHeaderAlignment(
                column,
                DataGridViewContentAlignment.MiddleLeft);
        }
    }

    private OrderRow CreateRow(Sale sale)
    {
        Customer? customer = sale.CustomerId is int id
            ? _customers.FirstOrDefault(x => x.Id == id)
            : null;

        User? staff = _users.FirstOrDefault(x => x.Id == sale.UserId);
        int items = _saleRepo.GetDetails(sale.Id).Sum(x => x.Quantity);

        return new OrderRow
        {
            SaleId = sale.Id,
            OrderNumber = sale.OrderNumber ?? 0,
            Order = sale.OrderNumber is int number
                ? $"ORD-{number:D5}"
                : "-",
            Customer = customer?.Name ?? "-",
            Staff = staff?.Username ?? "-",
            ItemCount = items,
            Items = items.ToString(),
            Total = $"${sale.TotalAmount:N2}",
            TotalValue = sale.TotalAmount,
            PickupDate = sale.PickupDate?.ToString("dd MMM yyyy") ?? "-",
            PickupDateValue = sale.PickupDate ?? DateTime.MinValue,
            Status = sale.Status == SaleStatus.Pending
                ? "Pending"
                : "Canceled"
        };
    }

    private void DataTableOrder_ViewClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not OrderRow row)
            return;

        Sale? order = _saleRepo.GetById(row.SaleId);

        if (order == null)
        {
            ShowNotFound();
            return;
        }

        ShowOrderDetails(order, row);
    }

    private void DataTableOrder_CustomActionClicked(
        object? sender,
        DataTableCustomActionEventArgs e)
    {
        if (e.DataItem is not OrderRow row)
            return;

        Sale? order = _saleRepo.GetById(row.SaleId);

        if (order == null)
        {
            ShowNotFound();
            return;
        }

        switch (e.ActionName)
        {
            case "collectButton":
                CollectOrder(order, row);
                break;

            case "cancelButton":
                CancelOrder(order, row);
                break;
        }
    }

    private void CollectOrder(Sale order, OrderRow row)
    {
        if (order.Status != SaleStatus.Pending)
        {
            MessageBox.Show(
                @"Only pending orders can be collected.",
                @"Collect Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        using var form = new ConfirmPaymentForm(
            row.Order,
            row.Customer,
            row.Staff,
            row.ItemCount,
            order.SubtotalAmount,
            order.DiscountAmount,
            order.TotalAmount);

        if (form.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            int invoiceNumber =
                _saleRepo.CompleteSale(order.Id);

            MessageBox.Show(
                $@"Order {row.Order} completed successfully.

Invoice: INV-{invoiceNumber:D5}",
                @"Order Completed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadOrders();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $@"Unable to complete the order.

{ex.Message}",
                @"Collect Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void CancelOrder(Sale order, OrderRow row)
    {
        if (order.Status != SaleStatus.Pending)
        {
            MessageBox.Show(
                @"Only pending orders can be canceled.",
                @"Cancel Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(
                $@"Order: {row.Order}
Customer: {row.Customer}
Total: {row.Total}

Are you sure you want to cancel this order?",
                @"Cancel Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            _saleRepo.CancelSale(order.Id);

            MessageBox.Show(
                @"Order canceled successfully.",
                @"Cancel Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadOrders();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $@"Unable to cancel the order.

{ex.Message}",
                @"Cancel Order",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void ShowNotFound()
    {
        MessageBox.Show(
            @"The order could not be found.",
            @"Order",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        LoadOrders();
    }

    private static void ShowOrderDetails(
        Sale order,
        OrderRow row)
    {
        string orderCode =
            order.OrderNumber is int number
                ? $"ORD-{number:D5}"
                : "-";

        string status =
            order.Status switch
            {
                SaleStatus.Pending => "Pending",
                SaleStatus.Cancelled => "Canceled",
                SaleStatus.Completed => "Completed",
                _ => "-"
            };

        string pickupDate =
            order.PickupDate?.ToString("dd MMM yyyy") ?? "-";

        MessageBox.Show(
            $@"Order: {orderCode}
Customer: {row.Customer}
Staff: {row.Staff}
Items: {row.Items}
Status: {status}

Subtotal: ${order.SubtotalAmount:N2}
Discount: {order.DiscountPercent:N2}%
Discount Amount: ${order.DiscountAmount:N2}
Total: ${order.TotalAmount:N2}
Pickup Date: {pickupDate}",
            @"Order Details",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void newOrderButton_Click(object? sender, EventArgs e)
    {
        using var form = new AddOrderForm();

        if (form.ShowDialog(this) == DialogResult.OK)
            LoadOrders();
    }

    private sealed class OrderRow
    {
        public int SaleId { get; init; }
        public int OrderNumber { get; init; }
        public string Order { get; init; } = "-";
        public string Customer { get; init; } = "-";
        public string Staff { get; init; } = "-";
        public int ItemCount { get; init; }
        public string Items { get; init; } = "0";
        public string Total { get; init; } = "$0.00";
        public decimal TotalValue { get; init; }
        public string PickupDate { get; init; } = "-";
        public DateTime PickupDateValue { get; init; }
        public string Status { get; init; } = "-";
    }
}