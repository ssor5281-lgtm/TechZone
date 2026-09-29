using TechZone.Core.Enums;
using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Core.Settings;
using TechZone.Data.Repositories;
using TechZone.UI.Components;
using TechZone.UI.Controls;
using TechZone.UI.Forms.Dialog;

namespace TechZone.UI.Forms.Create;

public partial class AddSaleForm : Form
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

    public AddSaleForm()
    {
        InitializeComponent();

        ConfigureTable();
        ConfigureCartTable();
        ConfigurePagination();
        ConfigureEvents();

        Load += AddSaleForm_Load;
    }

    private void AddSaleForm_Load(object? sender, EventArgs e)
    {
        LoadCustomers();
        LoadStaff();
        LoadProducts();

        discountTextBox.Text =
            AppSettings.DefaultDiscount.ToString("0.##");

        UpdateTotals();
        Text = @"New Sale";
    }

    private void ConfigureEvents()
    {
        addCustomerButton.Click += AddCustomerButton_Click;
        addToCartButton.Click += AddToCartButton_Click;
        searchProductTextBox.TextChanged += (_, _) => ApplyProductSearch();
        searchCartTextBox.TextChanged += (_, _) => RefreshCartTable();
        calculateDiscountButton.Click += CalculateDiscountButton_Click;
        removeButton.Click += RemoveButton_Click;
        cancelButton.Click += CancelButton_Click;
        saveSaleButton.Click += SaveSaleButton_Click;

        cartTable.Table.CellPainting += CartTable_CellPainting;
        cartTable.Table.CellMouseClick += CartTable_CellMouseClick;
    }

    private void ConfigurePagination()
    {
        dataTablePagination1.PageSize = 8;
        dataTablePagination1.PageChanged += (_, _) =>
            LoadCurrentProductPage();
    }

    private void ConfigureTable()
    {
        ConfigureDataGrid(productTable.Table);

        productTable.FontSize = 9F;
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

        productTable.SetFillColumn("Product", 150, 500);
        productTable.SetFixedWidth("SKU", 120, 120);
        productTable.SetFixedWidth("Price", 120, 120);
        productTable.SetFixedWidth("Stock", 80, 80);

        SetCenteredColumn(productTable, "Price");
        SetCenteredColumn(productTable, "Stock");

        productTable.Columns["Price"]!
            .DefaultCellStyle.Format = "$#,##0.00";
    }

    private void ConfigureCartTable()
    {
        ConfigureDataGrid(cartTable.Table);

        cartTable.ClearColumns();

        cartTable.AddTextColumn(
            "Product",
            "Product",
            nameof(CartRow.ProductName));

        cartTable.AddTextColumn(
            "Price",
            "Price",
            nameof(CartRow.Price));

        cartTable.AddTextColumn(
            "Quantity",
            "Quantity");

        cartTable.AddTextColumn(
            "Amount",
            "Amount",
            nameof(CartRow.Amount));

        cartTable.SetFillColumn("Product", 200, 500);
        cartTable.SetFixedWidth("Price", 120, 120);
        cartTable.SetFixedWidth("Quantity", 130, 130);
        cartTable.SetFixedWidth("Amount", 120, 120);

        SetCenteredColumn(cartTable, "Price");
        SetCenteredColumn(cartTable, "Quantity");
        SetCenteredColumn(cartTable, "Amount");

        cartTable.Columns["Price"]!
            .DefaultCellStyle.Format = "$#,##0.00";

        cartTable.Columns["Amount"]!
            .DefaultCellStyle.Format = "$#,##0.00";
    }

    private static void ConfigureDataGrid(DataGridView table)
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
            customerComboBox.DataSource = _customers;
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
            var staff = _userRepo
                .GetAll()
                .Where(user => user.Role == Role.Staff)
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

        productTable.NumberStart = skip + 1;

        productTable.DataSource =
            _filteredProducts
                .Skip(skip)
                .Take(dataTablePagination1.PageSize)
                .ToList();
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

    private void AddCustomerButton_Click(
        object? sender,
        EventArgs e)
    {
        using var form = new AddCustomerForm();

        if (form.ShowDialog(this) != DialogResult.OK)
            return;

        LoadCustomers();

        if (_customers.Count > 0)
            customerComboBox.SelectedIndex =
                _customers.Count - 1;
    }

    private void RefreshCartTable()
    {
        var rows = PointOfSaleHelper
            .FilterCart(
                _cart,
                searchCartTextBox.Text)
            .Select(item => new CartRow
            {
                ProductId = item.Product.Id,
                ProductName = item.Product.Name,
                Price = item.Product.Price,
                Quantity = item.Quantity,
                Amount = item.Amount
            })
            .ToList();

        cartTable.NumberStart = 1;
        cartTable.DataSource = rows;

        UpdateTotals();
    }

    private void RemoveButton_Click(
        object? sender,
        EventArgs e)
    {
        if (cartTable.Table.CurrentRow?
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
        if (!PointOfSaleHelper.TryParseDiscount(
                discountTextBox.Text,
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

    private void CartTable_CellPainting(
        object? sender,
        DataGridViewCellPaintingEventArgs e)
    {
        if (!IsQuantityCell(e.RowIndex, e.ColumnIndex))
            return;

        e.PaintBackground(e.CellBounds, true);

        if (cartTable.Table.Rows[e.RowIndex]
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
        if (!IsQuantityCell(e.RowIndex, e.ColumnIndex) ||
            e.Button != MouseButtons.Left)
            return;

        if (cartTable.Table.Rows[e.RowIndex]
                .DataBoundItem is not CartRow row)
            return;

        PointOfSaleHelper.CartItem? item =
            PointOfSaleHelper.FindCartItem(
                _cart,
                row.ProductId);

        if (item is null)
            return;

        Rectangle cell =
            cartTable.Table.GetCellDisplayRectangle(
                e.ColumnIndex,
                e.RowIndex,
                false);

        Point mouse = new(
            cell.X + e.X,
            cell.Y + e.Y);

        var buttons =
            _quantityButtons.GetButtonRects(cell);

        if (buttons.minus.Contains(mouse))
        {
            PointOfSaleHelper.DecreaseQuantity(item);
            RefreshCartTable();
            return;
        }

        if (buttons.plus.Contains(mouse))
        {
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
    }

    private bool IsQuantityCell(
        int rowIndex,
        int columnIndex)
    {
        return rowIndex >= 0 &&
               columnIndex >= 0 &&
               cartTable.Columns.Contains("Quantity") &&
               columnIndex ==
               cartTable.Columns["Quantity"]!.Index;
    }

    private void SaveSaleButton_Click(
        object? sender,
        EventArgs e)
    {
        if (_cart.Count == 0)
        {
            ShowWarning(
                "Please add at least one product.",
                "Sale");
            return;
        }

        if (staffComboBox.SelectedValue is not int staffId ||
            staffId <= 0)
        {
            ShowWarning(
                "Please select the staff responsible for this sale.",
                "Staff Required");

            staffComboBox.Focus();
            return;
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
            return;
        }

        var totals =
            PointOfSaleHelper.CalculateTotals(
                _cart,
                discount);

        var sale = new Sale
        {
            CustomerId =
                customerComboBox.SelectedValue is int customerId &&
                customerId > 0
                    ? customerId
                    : null,

            UserId = staffId,
            SubtotalAmount = totals.Subtotal,
            DiscountPercent = discount,
            DiscountAmount = totals.DiscountAmount,
            TotalAmount = totals.Total,
            SaleDate = DateTime.Now,
            Status = SaleStatus.Pending
        };

        string? customer =
            (customerComboBox.SelectedItem as Customer)?.Name;

        string staff =
            (staffComboBox.SelectedItem as User)?.Username ?? "-";

        try
        {
            int saleId =
                _saleRepo.CreateSale(
                    sale,
                    PointOfSaleHelper.BuildSaleDetails(_cart),
                    false);

            using var payment =
                new ConfirmPaymentForm(
                    $"SALE-{saleId:D5}",
                    customer,
                    staff,
                    PointOfSaleHelper.GetItemCount(_cart),
                    sale.SubtotalAmount,
                    sale.DiscountAmount,
                    sale.TotalAmount);

            if (payment.ShowDialog(this) !=
                DialogResult.OK)
            {
                _saleRepo.CancelSale(saleId);
                return;
            }
            int invoice =
                _saleRepo.CompleteSale(
                    saleId,
                    AppSettings.AllowSellingWhenStockZero);

            if (Owner is MainForm mainForm)
                mainForm.RefreshDashboard();

            MessageBox.Show(
                $@"Sale INV-{invoice:D5} has been completed.",
                @"Sale Completed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            ShowError(
                "Failed to complete sale.",
                "Save Sale",
                ex);
        }
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
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