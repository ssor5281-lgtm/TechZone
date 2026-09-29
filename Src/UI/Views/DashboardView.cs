
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using TechZone.Data.Repositories;
using TechZone.UI.Forms;

namespace TechZone.UI.Views;

public sealed partial class DashboardView : UserControl
{
    private CartesianChart _salesChart = null!;
    private PieChart _categoryChart = null!;
    private CartesianChart _productsChart = null!;
    private PieChart _inventoryChart = null!;

    private Panel _categoryLegend = null!;
    private Panel _inventoryLegend = null!;

    private const double PieInnerRadiusSmall = 40;
    private const double PieInnerRadiusLarge = 60;
    private const int PieWidthThreshold = 400;
    private const float LegendFontSize = 7.5f;
    private const int LegendWidth = 130;
    private const int LegendItemHeight = 17;
    private const int MaxCategories = 10;
    private const string ChartFont = "Bahnschrift";
    private const float AxisFontSize = 12f;
    private const float TooltipFontSize = 13f;

    private static readonly SKColor[] PieColors =
    [
        new(37, 99, 235),
        new(16, 185, 129),
        new(245, 158, 11),
        new(239, 68, 68),
        new(139, 92, 246),
        new(6, 182, 212),
        new(236, 72, 153),
        new(132, 204, 22),
        new(249, 115, 22),
        new(100, 116, 139)
    ];

    private readonly DashboardRepository _repo = new();

    public DashboardView()
    {
        InitializeComponent();

        AutoScroll = true;
        HorizontalScroll.Enabled = HorizontalScroll.Visible = false;
        VerticalScroll.Enabled = VerticalScroll.Visible = true;

        Resize += (_, _) =>
        {
            UpdateMainTableWidth();
            UpdatePieChartThickness();
        };

        CreateCharts();
        ConfigureRecentTables();
        LoadDashboardData();

        Load += (_, _) =>
        {
            UpdateMainTableWidth();
            UpdatePieChartThickness();
        };
    }

    public void RefreshData()
    {
        LoadDashboardData();
    }

    private void UpdateMainTableWidth()
    {
        if (mainTable != null)
            mainTable.Width = Math.Max(0, ClientSize.Width);
    }

    private void CreateCharts()
    {
        _salesChart = CreateCartesianChart();
        _categoryChart = CreatePieChart();
        _productsChart = CreateCartesianChart();
        _inventoryChart = CreatePieChart();

        ConfigureTitle(salesChartTitle);
        ConfigureTitle(categoryChartTitle);
        ConfigureTitle(productsChartTitle);
        ConfigureTitle(inventoryChartTitle);

        _categoryLegend = CreateLegendPanel();
        _inventoryLegend = CreateLegendPanel();

        salesChartPanel.Controls.AddRange(
        [
            _salesChart,
            salesChartTitle
        ]);

        categoryChartPanel.Controls.AddRange(
        [
            _categoryChart,
            _categoryLegend,
            categoryChartTitle
        ]);

        productsChartPanel.Controls.AddRange(
        [
            _productsChart,
            productsChartTitle
        ]);

        inventoryChartPanel.Controls.AddRange(
        [
            _inventoryChart,
            _inventoryLegend,
            inventoryChartTitle
        ]);

        categoryChartPanel.Resize += (_, _) =>
        {
            UpdatePieChartThickness();
            UpdateLegendLayout(_categoryLegend);
        };

        inventoryChartPanel.Resize += (_, _) =>
        {
            UpdatePieChartThickness();
            UpdateLegendLayout(_inventoryLegend);
        };
    }

    private static CartesianChart CreateCartesianChart() => new()
    {
        Dock = DockStyle.Fill,
        BackColor = Color.White,
        LegendPosition = LegendPosition.Hidden,
        ZoomMode = ZoomAndPanMode.None,
        AnimationsSpeed = TimeSpan.FromMilliseconds(500),
        Padding = Padding.Empty,
        TooltipPosition = TooltipPosition.Auto,
        TooltipBackgroundPaint = new SolidColorPaint(
            new SKColor(15, 23, 42)),
        TooltipTextPaint = new SolidColorPaint(SKColors.White)
        {
            SKTypeface = SKTypeface.FromFamilyName(ChartFont)
        },
        TooltipTextSize = TooltipFontSize
    };

    private static PieChart CreatePieChart() => new()
    {
        Dock = DockStyle.Fill,
        BackColor = Color.White,
        LegendPosition = LegendPosition.Hidden,
        AnimationsSpeed = TimeSpan.FromMilliseconds(500),
        Padding = Padding.Empty,
        TooltipPosition = TooltipPosition.Auto,
        TooltipBackgroundPaint = new SolidColorPaint(
            new SKColor(15, 23, 42)),
        TooltipTextPaint = new SolidColorPaint(SKColors.White)
        {
            SKTypeface = SKTypeface.FromFamilyName(ChartFont)
        },
        TooltipTextSize = TooltipFontSize
    };

    private static void ConfigureTitle(Label title)
    {
        title.Dock = DockStyle.Top;
        title.Height = 28;
        title.TextAlign = ContentAlignment.MiddleLeft;
        title.Margin = Padding.Empty;
        title.BringToFront();
    }

    private static Panel CreateLegendPanel() => new()
    {
        Dock = DockStyle.Right,
        Width = LegendWidth,
        BackColor = Color.White,
        Padding = new Padding(4, 6, 4, 4)
    };

    private static void UpdateLegendLayout(Panel legend)
    {
        legend.Width = LegendWidth;

        foreach (Control control in legend.Controls)
        {
            if (control is FlowLayoutPanel flow)
            {
                flow.Width = legend.ClientSize.Width;
                flow.Height = legend.ClientSize.Height;
            }
        }
    }

    private void LoadDashboardData()
    {
        try
        {
            var data = _repo.GetDashboardData();

            LoadKpis(data.Kpi, data.Inventory);
            LoadSalesChart(data.SalesOverview);
            LoadCategoryChart(data.SalesByCategory);
            LoadProductsChart(data.TopProducts);
            LoadInventoryChart(data.Inventory);
            LoadRecentSales(data.RecentSales);
            LoadRecentOrders(data.RecentOrders);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $@"Failed to load dashboard data.

{ex.Message}",
                @"Dashboard",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LoadKpis(
        DashboardKpi kpi,
        InventorySummary inventory)
    {
        salesKpiValue.Text = kpi.TotalSales.ToString("N0");
        revenueKpiValue.Text = $@"${kpi.Revenue:N2}";
        productsKpiValue.Text = kpi.ProductCount.ToString("N0");

        var attention =
            inventory.LowStock +
            inventory.OutOfStock;

        lowStockKpiValue.Text = attention.ToString("N0");

        salesKpiChange.Text =
            FormatChange(kpi.SalesChange, "from last week");

        revenueKpiChange.Text =
            FormatChange(kpi.RevenueChange, "from last week");

        productsKpiChange.Text =
            kpi.ProductsThisWeek == 0
                ? "No new products this week"
                : $"+{kpi.ProductsThisWeek:N0} this week";

        if (attention == 0)
        {
            lowStockKpiChange.Text = @"Stock looks good";
            lowStockKpiChange.ForeColor =
                Color.FromArgb(22, 163, 74);
        }
        else
        {
            lowStockKpiChange.Text =
                $@"{inventory.LowStock} low · {inventory.OutOfStock} out";

            lowStockKpiChange.ForeColor =
                Color.FromArgb(220, 38, 38);
        }

        salesKpiChange.ForeColor =
            GetChangeColor(kpi.SalesChange);

        revenueKpiChange.ForeColor =
            GetChangeColor(kpi.RevenueChange);

        productsKpiChange.ForeColor =
            Color.FromArgb(37, 99, 235);
    }

    private static string FormatChange(
        decimal value,
        string suffix) =>
        $"{(value > 0 ? "+" : "")}{value:N1}% {suffix}";

    private static Color GetChangeColor(
        decimal value) =>
        value switch
        {
            > 0 => Color.FromArgb(22, 163, 74),
            < 0 => Color.FromArgb(220, 38, 38),
            _ => Color.FromArgb(100, 116, 139)
        };

    private void UpdatePieChartThickness()
    {
        UpdatePieThickness(_categoryChart);
        UpdatePieThickness(_inventoryChart);
    }

    private static void UpdatePieThickness(PieChart chart)
    {
        var radius =
            chart.Width < PieWidthThreshold
                ? PieInnerRadiusSmall
                : PieInnerRadiusLarge;

        foreach (var series in chart.Series)
        {
            if (series is PieSeries<double> pie)
                pie.InnerRadius = radius;
        }

        chart.Update();
    }

    private void LoadSalesChart(
        List<SalesOverviewItem> sales)
    {
        _salesChart.Series =
        [
            new LineSeries<double>
            {
                Name = "Revenue",
                Values = sales
                    .Select(x => (double)x.Revenue)
                    .ToArray(),
                GeometrySize = 6,
                LineSmoothness = 0.7,
                Fill = new SolidColorPaint(
                    new SKColor(37, 99, 235, 35)),
                Stroke = new SolidColorPaint(
                    new SKColor(37, 99, 235))
                {
                    StrokeThickness = 2
                }
            }
        ];

        _salesChart.XAxes =
        [
            new Axis
            {
                Labels = sales
                    .Select(x =>
                        x.Date.ToString(
                            "ddd",
                            System.Globalization.CultureInfo.InvariantCulture))
                    .ToArray(),
                TextSize = AxisFontSize,
                LabelsPaint = CreateAxisPaint(),
                SeparatorsPaint = GridPaint()
            }
        ];

        _salesChart.YAxes =
        [
            new Axis
            {
                Labeler = v => $"${v:N0}",
                TextSize = AxisFontSize,
                MinLimit = 0,
                LabelsPaint = CreateAxisPaint(),
                SeparatorsPaint = GridPaint()
            }
        ];
    }

    private static SolidColorPaint CreateAxisPaint() =>
        new(SKColors.Black)
        {
            SKTypeface = SKTypeface.FromFamilyName(ChartFont)
        };

    private static SolidColorPaint GridPaint() =>
        new(new SKColor(226, 232, 240));

    private void LoadCategoryChart(
        List<SalesCategoryItem> categories)
    {
        var visible =
            categories.Take(MaxCategories).ToArray();

        _categoryChart.Series = visible
            .Select((category, index) =>
                new PieSeries<double>
                {
                    Name = category.Name,
                    Values = [category.Units],
                    Fill = new SolidColorPaint(
                        PieColors[index])
                })
            .ToArray();

        CreateLegend(
            _categoryLegend,
            visible
                .Select((category, index) =>
                    (category.Name, PieColors[index]))
                .ToArray());

        UpdatePieChartThickness();
    }

    private void LoadProductsChart(
        List<TopProductItem> products)
    {
        var visible =
            products.Take(5).ToArray();

        _productsChart.Series =
        [
            new RowSeries<int>
            {
                Name = "Units Sold",
                Values = visible
                    .Select(x => x.Units)
                    .ToArray(),

                XToolTipLabelFormatter = point =>
                {
                    var index = point.Index;

                    if (index < 0 ||
                        index >= visible.Length)
                        return string.Empty;

                    return $"{visible[index].Units:N0} units sold";
                },

                YToolTipLabelFormatter = point =>
                {
                    var index = point.Index;

                    if (index < 0 ||
                        index >= visible.Length)
                        return string.Empty;

                    return visible[index].Name;
                }
            }
        ];

        _productsChart.XAxes =
        [
            new Axis
            {
                Labeler = v => $"{v:N0}",
                TextSize = AxisFontSize,
                LabelsPaint = CreateAxisPaint(),
                MinLimit = 0,
                SeparatorsPaint = GridPaint()
            }
        ];

        _productsChart.YAxes =
        [
            new Axis
            {
                Labels = visible
                    .Select(x => x.Name)
                    .ToArray(),
                TextSize = AxisFontSize,
                LabelsPaint = CreateAxisPaint(),
                SeparatorsPaint = null
            }
        ];
    }

    private void LoadInventoryChart(
        InventorySummary inventory)
    {
        var items =
            new (string Name, double Value)[]
            {
                ("In Stock", inventory.InStock),
                ("Low Stock", inventory.LowStock),
                ("Out of Stock", inventory.OutOfStock)
            };

        _inventoryChart.Series = items
            .Select((item, index) =>
                new PieSeries<double>
                {
                    Name = item.Name,
                    Values = [item.Value],
                    Fill = new SolidColorPaint(
                        PieColors[index])
                })
            .ToArray();

        CreateLegend(
            _inventoryLegend,
            items
                .Select((item, index) =>
                    (item.Name, PieColors[index]))
                .ToArray());

        UpdatePieChartThickness();
    }

    private void CreateLegend(
        Panel legend,
        (string Name, SKColor Color)[] items)
    {
        legend.Controls.Clear();

        var flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = false,
            Margin = Padding.Empty,
            Padding = Padding.Empty,
            BorderStyle = BorderStyle.None
        };

        foreach (var (name, color) in items.Take(MaxCategories))
            flow.Controls.Add(
                CreateLegendItem(name, color));

        legend.Controls.Add(flow);
    }

    private static Panel CreateLegendItem(
        string name,
        SKColor color)
    {
        var row = new Panel
        {
            Width = LegendWidth - 8,
            Height = LegendItemHeight,
            Margin = Padding.Empty,
            Padding = Padding.Empty,
            BackColor = Color.White
        };

        var indicator = new Panel
        {
            Width = 8,
            Height = 8,
            Left = 2,
            Top = (LegendItemHeight - 8) / 2,
            BackColor = Color.FromArgb(
                color.Red,
                color.Green,
                color.Blue)
        };

        var label = new Label
        {
            AutoSize = false,
            Left = 16,
            Top = 0,
            Width = row.Width - 18,
            Height = LegendItemHeight,
            Text = name,
            Font = new Font(
                ChartFont,
                LegendFontSize),
            ForeColor = Color.FromArgb(
                71,
                85,
                105),
            TextAlign = ContentAlignment.MiddleLeft,
            Margin = Padding.Empty,
            Padding = Padding.Empty,
            AutoEllipsis = true
        };

        row.Controls.Add(indicator);
        row.Controls.Add(label);

        return row;
    }

    private void ConfigureRecentTables()
    {
        ConfigureTable(
            recentTable,
            6,
            [
                (SizeType.Absolute, 105f),
                (SizeType.Percent, 25f),
                (SizeType.Percent, 20f),
                (SizeType.Absolute, 55f),
                (SizeType.Absolute, 85f),
                (SizeType.Absolute, 125f)
            ],
            [
                "Invoice",
                "Customer",
                "Staff",
                "Items",
                "Total",
                "Sale Date"
            ]);

        ConfigureTable(
            recentOrdersTable,
            5,
            [
                (SizeType.Absolute, 100f),
                (SizeType.Percent, 25f),
                (SizeType.Percent, 20f),
                (SizeType.Percent, 30f),
                (SizeType.Absolute, 80f)
            ],
            [
                "Order",
                "Customer",
                "Staff",
                "Pickup Date",
                "Total"
            ]);
    }

    private static void ConfigureTable(
        TableLayoutPanel table,
        int columns,
        (SizeType Type, float Width)[] colStyles,
        string[] headers)
    {
        table.Controls.Clear();
        table.ColumnStyles.Clear();
        table.RowStyles.Clear();

        table.ColumnCount = columns;
        table.RowCount = 5;

        foreach (var (type, width) in colStyles)
            table.ColumnStyles.Add(
                new ColumnStyle(type, width));

        table.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                30f));

        for (var i = 1; i < 5; i++)
        {
            table.RowStyles.Add(
                new RowStyle(
                    SizeType.Absolute,
                    38f));
        }

        for (var column = 0;
             column < headers.Length;
             column++)
        {
            AddRecentHeader(
                table,
                headers[column],
                column);
        }
    }

    private void LoadRecentSales(
        List<RecentSaleItem> sales)
    {
        ClearRecentRows(recentTable);

        for (var i = 0;
             i < sales.Count && i < 4;
             i++)
        {
            var sale = sales[i];
            var row = i + 1;

            AddRecentCell(
                recentTable,
                $"INV-{sale.InvoiceNumber:D5}",
                row,
                0,
                true);

            AddRecentCell(
                recentTable,
                sale.Customer,
                row,
                1);

            AddRecentCell(
                recentTable,
                sale.Staff,
                row,
                2);

            AddRecentCell(
                recentTable,
                sale.Items.ToString("N0"),
                row,
                3);

            AddRecentCell(
                recentTable,
                $"${sale.Total:N2}",
                row,
                4,
                true);

            AddRecentCell(
                recentTable,
                FormatDate(sale.SaleDate),
                row,
                5);
        }
    }

    private void LoadRecentOrders(
        List<RecentOrderItem> orders)
    {
        ClearRecentRows(recentOrdersTable);

        for (var i = 0;
             i < orders.Count && i < 4;
             i++)
        {
            var order = orders[i];
            var row = i + 1;

            AddRecentCell(
                recentOrdersTable,
                $"ORD-{order.OrderNumber:D5}",
                row,
                0,
                true);

            AddRecentCell(
                recentOrdersTable,
                order.Customer,
                row,
                1);

            AddRecentCell(
                recentOrdersTable,
                order.Staff,
                row,
                2);

            AddRecentCell(
                recentOrdersTable,
                FormatDate(order.PickupDate),
                row,
                3);

            AddRecentCell(
                recentOrdersTable,
                $"${order.Total:N2}",
                row,
                4,
                true);
        }
    }

    private static string FormatDate(DateTime date) =>
        date.Date == DateTime.Today
            ? $"Today, {date:h:mm tt}"
            : date.Date == DateTime.Today.AddDays(-1)
                ? $"Yesterday, {date:h:mm tt}"
                : date.ToString("MMM dd, h:mm tt");

    private static string FormatDate(DateTime? date) =>
        date.HasValue
            ? FormatDate(date.Value)
            : "-";

    private static void ClearRecentRows(
        TableLayoutPanel table)
    {
        for (var i = table.Controls.Count - 1;
             i >= 0;
             i--)
        {
            if (table.GetRow(table.Controls[i]) > 0)
                table.Controls.RemoveAt(i);
        }
    }

    private static void AddRecentHeader(
        TableLayoutPanel table,
        string text,
        int column)
    {
        table.Controls.Add(
            new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                Font = new Font(
                    ChartFont,
                    8.5f,
                    FontStyle.Bold),
                ForeColor = Color.FromArgb(
                    100,
                    116,
                    139),
                Padding = new Padding(4, 0, 4, 0),
                Margin = Padding.Empty
            },
            column,
            0);
    }

    private static void AddRecentCell(
        TableLayoutPanel table,
        string text,
        int row,
        int column,
        bool bold = false)
    {
        table.Controls.Add(
            new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                Font = new Font(
                    ChartFont,
                    8.5f,
                    bold
                        ? FontStyle.Bold
                        : FontStyle.Regular),
                ForeColor = Color.FromArgb(
                    30,
                    41,
                    59),
                Padding = new Padding(4, 0, 4, 0),
                Margin = Padding.Empty,
                AutoEllipsis = true
            },
            column,
            row);
    }

    private void recentSalesViewAllButton_Click(
        object? sender,
        EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
            mainForm.OpenInvoiceHistoryView();
    }

    private void recentOrdersViewAllButton_Click(
        object? sender,
        EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
            mainForm.OpenOrderView();
    }
}