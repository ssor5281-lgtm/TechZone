using TechZone.Core.Enums;
using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Core.Settings;
using TechZone.Data.Repositories;
using TechZone.UI.Components;
using TechZone.UI.Controls;
using TechZone.UI.Forms.Dialog;

namespace TechZone.UI.Forms.Create;

public partial class AddQuickSaleForm : Form
{
    private readonly SaleRepository _saleRepo = new();
    private readonly ProductRepository _productRepo = new();
    private readonly UserRepository _userRepo = new();
    private readonly QuantityButtonRenderer _quantityButtons = new();

    private List<Product> _products = [];
    private readonly List<PointOfSaleHelper.CartItem> _cart = [];

    public AddQuickSaleForm()
    {
        InitializeComponent();

        ConfigureTables();
        ConfigurePagination();
        ConfigureEvents();

        Load += (_, _) => LoadData();
    }

    private void LoadData()
    {
        LoadStaff();

        _products = _productRepo
            .GetAll()
            .ToList();

        LoadProducts();

        discountTextBox.Text =
            AppSettings.DefaultDiscount.ToString("0.##");

        invoiceLabel.Text = @"----------";
        Text = @"Quick Sale";

        UpdateTotal();
    }

    private void ConfigureTables()
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

        productTable.SetFillColumn("Product", 200, 500);
        productTable.SetFixedWidth("SKU", 120, 120);
        productTable.SetFixedWidth("Price", 120, 120);
        productTable.SetFixedWidth("Stock", 80, 80);

        SetCenteredColumn(productTable, "Price");
        SetCenteredColumn(productTable, "Stock");

        productTable.Columns["Price"]!
            .DefaultCellStyle.Format = "$#,##0.00";

        ConfigureDataGrid(cartTable.Table);

        cartTable.ClearColumns();

        cartTable.AddTextColumn(
            "Product",
            "Product",
            nameof(CartRow.Name));

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

        cartTable.SetFillColumn("Product", 220, 500);
        cartTable.SetFixedWidth("Price", 120, 120);
        cartTable.SetFixedWidth("Quantity", 150, 150);
        cartTable.SetFixedWidth("Amount", 120, 120);

        SetCenteredColumn(cartTable, "Price");
        SetCenteredColumn(cartTable, "Quantity");
        SetCenteredColumn(cartTable, "Amount");

        cartTable.Columns["Price"]!
            .DefaultCellStyle.Format = "$#,##0.00";

        cartTable.Columns["Amount"]!
            .DefaultCellStyle.Format = "$#,##0.00";
    }

    private void ConfigurePagination()
    {
        dataTablePagination1.PageSize = 8;

        dataTablePagination1.PageChanged += (_, _) =>
            LoadProducts();
    }

    private void ConfigureEvents()
    {
        searchProductTextBox.TextChanged += (_, _) =>
            LoadProducts();

        addToCartButton.Click += (_, _) =>
            AddSelectedProduct();

        productTable.Table.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0)
                AddSelectedProduct(e.RowIndex);
        };

        removeButton.Click += (_, _) =>
            RemoveSelected();

        calculateDiscountButton.Click += (_, _) =>
            UpdateTotal();

        saveSaleButton.Click += SaveSaleButton_Click;

        cancelButton.Click += (_, _) =>
        {
            DialogResult = DialogResult.Cancel;
            Close();
        };

        cartTable.Table.CellMouseClick += CartMouseClick;
        cartTable.Table.CellPainting += CartPainting;
    }

    private void LoadStaff()
    {
        var staff = _userRepo
            .GetAll()
            .Where(user => user.Role == UserRole.Staff)
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

    private void LoadProducts()
    {
        var products =
            PointOfSaleHelper.FilterProducts(
                _products,
                searchProductTextBox.Text);

        dataTablePagination1.TotalItems =
            products.Count;

        int skip =
            (dataTablePagination1.CurrentPage - 1) *
            dataTablePagination1.PageSize;

        productTable.NumberStart =
            skip + 1;

        productTable.DataSource =
            products
                .Skip(skip)
                .Take(dataTablePagination1.PageSize)
                .ToList();
    }

    private void AddSelectedProduct(
        int rowIndex = -1)
    {
        Product? product =
            rowIndex >= 0
                ? productTable.Table.Rows[rowIndex]
                    .DataBoundItem as Product
                : productTable.Table.CurrentRow?
                    .DataBoundItem as Product;

        if (product is null)
            return;

        switch (PointOfSaleHelper.AddProduct(
            _cart,
            product))
        {
            case PointOfSaleHelper.CartActionResult.ProductOutOfStock:
                MessageBox.Show(
                    @"This product is out of stock.",
                    @"Add Product",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;

            case PointOfSaleHelper.CartActionResult.StockLimit:
                MessageBox.Show(
                    $@"Only {product.Stock} unit(s) available.",
                    @"Stock Limit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
        }

        RefreshCart();
    }

    private void RemoveSelected()
    {
        if (cartTable.Table.CurrentRow?.DataBoundItem
            is not CartRow row)
        {
            return;
        }

        PointOfSaleHelper.RemoveItem(
            _cart,
            row.Id);

        RefreshCart();
    }

    private void RefreshCart()
    {
        var rows =
            PointOfSaleHelper.FilterCart(
                _cart,
                null)
            .Select(item => new CartRow
            {
                Id = item.Product.Id,
                Name = item.Product.Name,
                Price = item.Product.Price,
                Quantity = item.Quantity,
                Amount = item.Amount
            })
            .ToList();

        cartTable.NumberStart = 1;
        cartTable.DataSource = rows;

        UpdateTotal();
    }

    private void UpdateTotal()
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

    private void SaveSaleButton_Click(
        object? sender,
        EventArgs e)
    {
        if (_cart.Count == 0)
        {
            MessageBox.Show(
                @"Please add at least one product.",
                @"Quick Sale",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (staffComboBox.SelectedValue is not int staffId)
        {
            MessageBox.Show(
                @"Please select a staff member.",
                @"Quick Sale",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!PointOfSaleHelper.TryParseDiscount(
                discountTextBox.Text,
                out decimal discount))
        {
            MessageBox.Show(
                @"Discount must be between 0 and 100.",
                @"Discount",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

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
            CustomerId = null,
            UserId = staffId,
            SubtotalAmount = totals.Subtotal,
            DiscountPercent = discount,
            DiscountAmount = totals.DiscountAmount,
            TotalAmount = totals.Total,
            SaleDate = DateTime.Now,
            Status = SaleStatus.Pending
        };

        string staff =
            staffComboBox.SelectedItem is User selectedStaff
                ? selectedStaff.Username
                : "-";

        int items =
            PointOfSaleHelper.GetItemCount(_cart);

        try
        {
            int saleId =
                _saleRepo.CreateSale(
                    sale,
                    PointOfSaleHelper.BuildSaleDetails(_cart),
                    false);

            if (AppSettings.ConfirmQuickSale)
            {
                using var payment =
                    new ConfirmPaymentForm(
                        $"SALE-{saleId:D5}",
                        null,
                        staff,
                        items,
                        sale.SubtotalAmount,
                        sale.DiscountAmount,
                        sale.TotalAmount);

                if (payment.ShowDialog(this) !=
                    DialogResult.OK)
                {
                    _saleRepo.CancelSale(saleId);
                    return;
                }
            }

            int invoiceNumber =
                _saleRepo.CompleteSale(
                    saleId,
                    AppSettings.AllowSellingWhenStockZero);

            MessageBox.Show(
                $@"Sale INV-{invoiceNumber:D5} completed.",
                @"Sale Completed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $@"Failed to complete sale.

{ex.Message}",
                @"Save Sale",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void CartMouseClick(
        object? sender,
        DataGridViewCellMouseEventArgs e)
    {
        if (!IsQuantityCell(e.RowIndex, e.ColumnIndex) ||
            e.Button != MouseButtons.Left)
        {
            return;
        }

        if (cartTable.Table.Rows[e.RowIndex]
            .DataBoundItem is not CartRow row)
        {
            return;
        }

        PointOfSaleHelper.CartItem? item =
            PointOfSaleHelper.FindCartItem(
                _cart,
                row.Id);

        if (item is null)
            return;

        Rectangle cellBounds =
            cartTable.Table.GetCellDisplayRectangle(
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
            RefreshCart();
            return;
        }

        if (!rects.plus.Contains(mousePoint))
            return;

        if (PointOfSaleHelper.IncreaseQuantity(item) ==
            PointOfSaleHelper.CartActionResult.StockLimit)
        {
            MessageBox.Show(
                $@"Only {item.Product.Stock} unit(s) available.",
                @"Stock Limit",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        RefreshCart();
    }

    private void CartPainting(
        object? sender,
        DataGridViewCellPaintingEventArgs e)
    {
        if (!IsQuantityCell(e.RowIndex, e.ColumnIndex))
            return;

        e.PaintBackground(
            e.CellBounds,
            true);

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

    private sealed class CartRow
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public decimal Amount { get; init; }
    }
}