using TechZone.Core.Enums;
using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Core.Settings;
using TechZone.Data.Repositories;
using TechZone.UI.Components;
using TechZone.UI.Controls;

namespace TechZone.UI.Forms.Create;

public partial class AddOrderForm : Form
{
    private readonly SaleRepository _saleRepo = new();
    private readonly ProductRepository _productRepo = new();
    private readonly CustomerRepository _customerRepo = new();
    private readonly UserRepository _userRepo = new();
    private readonly QuantityButtonRenderer _quantityButtons = new();

    private List<Customer> _customers = [];
    private List<Product> _products = [];
    private List<Product> _filteredProducts = [];
    private readonly List<PointOfSaleHelper.CartItem> _cart = [];

    public AddOrderForm()
    {
        InitializeComponent();

        ConfigurePickupDate();
        ConfigureTable();
        ConfigureCartTable();
        ConfigurePagination();
        ConfigureEvents();

        Load += AddOrderForm_Load;
    }

    private void AddOrderForm_Load(
        object? sender,
        EventArgs e)
    {
        LoadCustomers();
        LoadStaff();
        LoadProducts();

        discountTextBox.Text =
            AppSettings.DefaultDiscount.ToString("0.##");

        UpdateTotals();

        int nextOrderNumber =
            _saleRepo.GetNextOrderNumber();

        orderNumberLabel.Text =
            $@"ORD-{nextOrderNumber:D5}";
    }

    private void ConfigurePickupDate()
    {
        pickupDatePicker.Format =
            DateTimePickerFormat.Custom;

        pickupDatePicker.CustomFormat =
            @"dd MMM yyyy";

        pickupDatePicker.ShowUpDown = false;
        pickupDatePicker.MinDate = DateTime.Today;
        pickupDatePicker.Value =
            DateTime.Today.AddDays(1);
    }

    private void ConfigureEvents()
    {
        addCustomerButton.Click +=
            AddCustomerButton_Click;

        addToCartButton.Click +=
            AddToCartButton_Click;

        searchProductTextBox.TextChanged +=
            SearchProductTextBox_TextChanged;

        calculateDiscountButton.Click +=
            CalculateDiscountButton_Click;

        removeButton.Click +=
            RemoveButton_Click;

        cancelButton.Click +=
            CancelButton_Click;

        saveOrderButton.Click +=
            SaveOrderButton_Click;

        DataTable.Table.CellPainting +=
            CartTable_CellPainting;

        DataTable.Table.CellMouseClick +=
            CartTable_CellMouseClick;
    }

    private void ConfigurePagination()
    {
        dataTablePagination1.PageSize = 8;

        dataTablePagination1.PageChanged +=
            DataTablePagination_PageChanged;
    }

    private void DataTablePagination_PageChanged(
        object? sender,
        DataTablePageChangedEventArgs e)
    {
        LoadCurrentProductPage();
    }

    private void LoadCustomers()
    {
        try
        {
            _customers =
                _customerRepo.GetAll().ToList();

            customerComboBox.DataSource = null;
            customerComboBox.DisplayMember =
                nameof(Customer.Name);
            customerComboBox.ValueMember =
                nameof(Customer.Id);
            customerComboBox.DataSource =
                _customers;

            customerComboBox.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            ShowError(
                "Unable to load customers.",
                "Load Customers",
                ex);
        }
    }

    private void LoadStaff()
    {
        try
        {
            List<User> staff = _userRepo
                .GetAll()
                .Where(user =>
                    user.Role == UserRole.Staff)
                .ToList();

            staffComboBox.DataSource = null;
            staffComboBox.DisplayMember =
                nameof(User.Username);
            staffComboBox.ValueMember =
                nameof(User.Id);
            staffComboBox.DataSource = staff;

            staffComboBox.Enabled = true;

            if (staff.Count > 0)
                staffComboBox.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            ShowError(
                "Unable to load staff.",
                "Load Staff",
                ex);
        }
    }

    private void LoadProducts()
    {
        try
        {
            _products =
                _productRepo.GetAll().ToList();

            ApplyProductSearch();
        }
        catch (Exception ex)
        {
            ShowError(
                "Unable to load products.",
                "Load Products",
                ex);
        }
    }

    private void ApplyProductSearch()
    {
        _filteredProducts =
            PointOfSaleHelper.FilterProducts(
                _products,
                searchProductTextBox.Text);

        dataTablePagination1.TotalItems =
            _filteredProducts.Count;

        dataTablePagination1.GoToFirstPage();

        LoadCurrentProductPage();
    }

    private void LoadCurrentProductPage()
    {
        int skip =
            (dataTablePagination1.CurrentPage - 1) *
            dataTablePagination1.PageSize;

        productTable.NumberStart =
            skip + 1;

        productTable.DataSource =
            _filteredProducts
                .Skip(skip)
                .Take(dataTablePagination1.PageSize)
                .ToList();
    }

    private void SearchProductTextBox_TextChanged(
        object? sender,
        EventArgs e)
    {
        ApplyProductSearch();
    }

    private void ConfigureTable()
    {
        productTable.FontSize = 9F;

        ConfigureDataGrid(productTable.Table);

        productTable.ClearColumns();

        productTable.AddTextColumn(
            "Product",
            "Product",
            nameof(Product.Name));

        productTable.AddTextColumn(
            "SKU",
            "SKU",
            nameof(Product.Sku));

        productTable.AddTextColumn(
            "Price",
            "Price",
            nameof(Product.Price));

        productTable.AddTextColumn(
            "Stock",
            "Stock",
            nameof(Product.Stock));

        productTable.SetFillColumn(
            "Product",
            200,
            500);

        productTable.SetFixedWidth(
            "SKU",
            120,
            120);

        productTable.SetFixedWidth(
            "Price",
            120,
            120);

        productTable.SetFixedWidth(
            "Stock",
            80,
            80);

        SetCenteredColumn(productTable, "Price");
        SetCenteredColumn(productTable, "Stock");

        productTable.Columns["Price"]!
            .DefaultCellStyle.Format =
            "$#,##0.00";
    }

    private void ConfigureCartTable()
    {
        ConfigureDataGrid(DataTable.Table);

        DataTable.ClearColumns();

        DataTable.AddTextColumn(
            "Product",
            "Product",
            nameof(CartRow.ProductName));

        DataTable.AddTextColumn(
            "Price",
            "Price",
            nameof(CartRow.Price));

        DataTable.AddTextColumn(
            "Quantity",
            "Quantity");

        DataTable.AddTextColumn(
            "Amount",
            "Amount",
            nameof(CartRow.Amount));

        DataTable.SetFillColumn(
            "Product",
            200,
            500);

        DataTable.SetFixedWidth(
            "Price",
            120,
            120);

        DataTable.SetFixedWidth(
            "Quantity",
            130,
            130);

        DataTable.SetFixedWidth(
            "Amount",
            120,
            120);

        SetCenteredColumn(DataTable, "Price");
        SetCenteredColumn(DataTable, "Quantity");
        SetCenteredColumn(DataTable, "Amount");

        DataTable.Columns["Price"]!
            .DefaultCellStyle.Format =
            "$#,##0.00";

        DataTable.Columns["Amount"]!
            .DefaultCellStyle.Format =
            "$#,##0.00";
    }

    private void AddCustomerButton_Click(
        object? sender,
        EventArgs e)
    {
        using var form =
            new AddCustomerForm();

        if (form.ShowDialog(this) !=
            DialogResult.OK)
        {
            return;
        }

        LoadCustomers();

        if (_customers.Count > 0)
        {
            customerComboBox.SelectedIndex =
                _customers.Count - 1;
        }
    }

    private void AddToCartButton_Click(
        object? sender,
        EventArgs e)
    {
        if (productTable.Table.CurrentRow?
                .DataBoundItem is not Product product)
        {
            ShowInfo(
                "Please select a product first.",
                "Add Product");

            return;
        }

        switch (PointOfSaleHelper.AddProduct(
            _cart,
            product))
        {
            case PointOfSaleHelper.CartActionResult.ProductOutOfStock:
                ShowWarning(
                    "This product is out of stock.",
                    "Add Product");
                return;

            case PointOfSaleHelper.CartActionResult.StockLimit:
                ShowInfo(
                    $@"Only {product.Stock} unit(s) available.",
                    "Stock Limit");
                return;
        }

        RefreshCartTable();
    }

    private void RefreshCartTable()
    {
        List<CartRow> rows =
            PointOfSaleHelper.FilterCart(
                    _cart,
                    null)
                .Select(item => new CartRow
                {
                    ProductId =
                        item.Product.Id,

                    ProductName =
                        item.Product.Name,

                    Price =
                        item.Product.Price,

                    Quantity =
                        item.Quantity,

                    Amount =
                        item.Amount
                })
                .ToList();

        DataTable.NumberStart = 1;
        DataTable.DataSource = rows;

        UpdateTotals();
    }

    private void UpdateTotals()
    {
        decimal discount =
            PointOfSaleHelper.ParseDiscount(
                discountTextBox.Text);

        var totals =
            PointOfSaleHelper.CalculateTotals(
                _cart,
                discount);

        subtotalValueLabel.Text =
            $@"${totals.Subtotal:N2}";

        discountValueLabel.Text =
            $@"${totals.DiscountAmount:N2}";

        totalValueLabel.Text =
            $@"${totals.Total:N2}";
    }

    private void CalculateDiscountButton_Click(
        object? sender,
        EventArgs e)
    {
        string value =
            discountTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(value))
        {
            discountTextBox.Text = @"0";
            UpdateTotals();
            return;
        }

        if (!PointOfSaleHelper.TryParseDiscount(
                value,
                out decimal discount))
        {
            ShowWarning(
                "Discount must be between 0 and 100.",
                "Discount");

            discountTextBox.Focus();
            discountTextBox.SelectAll();
            return;
        }

        discountTextBox.Text =
            discount.ToString("0.##");

        UpdateTotals();
    }

    private void RemoveButton_Click(
        object? sender,
        EventArgs e)
    {
        if (DataTable.Table.CurrentRow?
                .DataBoundItem is not CartRow row)
        {
            ShowInfo(
                "Please select a cart item first.",
                "Remove Product");

            return;
        }

        PointOfSaleHelper.RemoveItem(
            _cart,
            row.ProductId);

        RefreshCartTable();
    }

    private void CartTable_CellPainting(
        object? sender,
        DataGridViewCellPaintingEventArgs e)
    {
        if (!IsQuantityCell(
                e.RowIndex,
                e.ColumnIndex))
        {
            return;
        }

        e.PaintBackground(
            e.CellBounds,
            true);

        if (DataTable.Table.Rows[e.RowIndex]
            .DataBoundItem is CartRow row)
        {
            _quantityButtons.Draw(
                e.Graphics!,
                e.CellBounds,
                row.Quantity,
                Resources.icon_minus_white,
                Resources.icon_plus_white);
        }

        e.Handled = true;
    }

    private void CartTable_CellMouseClick(
        object? sender,
        DataGridViewCellMouseEventArgs e)
    {
        if (!IsQuantityCell(
                e.RowIndex,
                e.ColumnIndex) ||
            e.Button != MouseButtons.Left)
        {
            return;
        }

        if (DataTable.Table.Rows[e.RowIndex]
            .DataBoundItem is not CartRow row)
        {
            return;
        }

        PointOfSaleHelper.CartItem? item =
            PointOfSaleHelper.FindCartItem(
                _cart,
                row.ProductId);

        if (item is null)
            return;

        Rectangle cellBounds =
            DataTable.Table.GetCellDisplayRectangle(
                e.ColumnIndex,
                e.RowIndex,
                false);

        Point mousePoint = new(
            cellBounds.X + e.X,
            cellBounds.Y + e.Y);

        var rects =
            _quantityButtons.GetButtonRects(
                cellBounds);

        if (rects.minus.Contains(mousePoint))
        {
            PointOfSaleHelper.DecreaseQuantity(item);
            RefreshCartTable();
            return;
        }

        if (!rects.plus.Contains(mousePoint))
            return;

        if (PointOfSaleHelper.IncreaseQuantity(item) ==
            PointOfSaleHelper.CartActionResult.StockLimit)
        {
            ShowInfo(
                $@"Only {item.Product.Stock} unit(s) available.",
                "Stock Limit");

            return;
        }

        RefreshCartTable();
    }

    private void SaveOrderButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidateOrder(
                out Sale.Order order))
        {
            return;
        }

        if (AppSettings.ConfirmOrder)
        {
            DialogResult result =
                MessageBox.Show(
                    $@"Are you sure you want to save order {order.OrderCode}?",
                    @"Confirm Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }
        }

        try
        {
            _saleRepo.CreateSale(
                order,
                PointOfSaleHelper.BuildSaleDetails(_cart),
                false);

            MessageBox.Show(
                $@"Order {order.OrderCode} has been saved.",
                @"Order Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult =
                DialogResult.OK;

            Close();
        }
        catch (Exception ex)
        {
            ShowError(
                "Failed to save order.",
                "Save Order",
                ex);
        }
    }

    private bool ValidateOrder(
        out Sale.Order order)
    {
        order = new Sale.Order();

        if (_cart.Count == 0)
        {
            ShowWarning(
                "Please add at least one product.",
                "Order");

            return false;
        }

        if (staffComboBox.SelectedValue
            is not int staffId ||
            staffId <= 0)
        {
            ShowWarning(
                "Please select the staff responsible for this order.",
                "Staff Required");

            staffComboBox.Focus();
            return false;
        }

        if (pickupDatePicker.Value.Date <
            DateTime.Today)
        {
            ShowWarning(
                "Pickup date cannot be before today.",
                "Pickup Date");

            pickupDatePicker.Focus();
            return false;
        }

        if (!PointOfSaleHelper.TryParseDiscount(
                discountTextBox.Text,
                out decimal discount))
        {
            ShowWarning(
                "Discount must be between 0 and 100.",
                "Discount");

            discountTextBox.Focus();
            discountTextBox.SelectAll();
            return false;
        }

        var totals =
            PointOfSaleHelper.CalculateTotals(
                _cart,
                discount);

        int orderNumber =
            _saleRepo.GetNextOrderNumber();

        order = new Sale.Order
        {
            OrderNumber =
                orderNumber,

            CustomerId =
                GetSelectedCustomerId(),

            UserId =
                staffId,

            SubtotalAmount =
                totals.Subtotal,

            DiscountPercent =
                discount,

            DiscountAmount =
                totals.DiscountAmount,

            TotalAmount =
                totals.Total,

            SaleDate =
                DateTime.Now,

            PickupDate =
                pickupDatePicker.Value.Date,

            Status =
                SaleStatus.Pending
        };

        return true;
    }

    private int? GetSelectedCustomerId()
    {
        return customerComboBox.SelectedValue
            is int customerId &&
            customerId > 0
            ? customerId
            : null;
    }

    private bool IsQuantityCell(
        int rowIndex,
        int columnIndex)
    {
        return rowIndex >= 0 &&
               columnIndex >= 0 &&
               DataTable.Columns.Contains("Quantity") &&
               columnIndex ==
               DataTable.Columns["Quantity"]!.Index;
    }

    private static void ConfigureDataGrid(
        DataGridView table)
    {
        table.AutoGenerateColumns = false;
        table.AllowUserToAddRows = false;
        table.AllowUserToDeleteRows = false;
        table.AllowUserToResizeColumns = false;
        table.AllowUserToResizeRows = false;
        table.RowHeadersVisible = false;
        table.MultiSelect = false;
        table.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        table.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.None;
    }

    private static void SetCenteredColumn(
        DataTable table,
        string columnName)
    {
        table.SetAlignment(
            columnName,
            DataGridViewContentAlignment.MiddleCenter);

        table.SetHeaderAlignment(
            columnName,
            DataGridViewContentAlignment.MiddleCenter);
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.Cancel;

        Close();
    }

    private static void ShowInfo(
        string message,
        string title)
    {
        MessageBox.Show(
            message,
            title,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private static void ShowWarning(
        string message,
        string title)
    {
        MessageBox.Show(
            message,
            title,
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    private static void ShowError(
        string message,
        string title,
        Exception ex)
    {
        MessageBox.Show(
            $@"{message}

{ex.Message}",
            title,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }

    private sealed class CartRow
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public decimal Amount { get; init; }
    }
}