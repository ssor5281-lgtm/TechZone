using System.ComponentModel;

namespace TechZone.UI.Views;

sealed partial class DashboardView
{
    private IContainer components = null!;

    private TableLayoutPanel mainTable = null!;
    private TableLayoutPanel kpiTable = null!;

    private Panel salesKpiCard = null!;
    private Panel revenueKpiCard = null!;
    private Panel productsKpiCard = null!;
    private Panel lowStockKpiCard = null!;

    private Label salesKpiTitle = null!;
    private Label salesKpiValue = null!;
    private Label salesKpiChange = null!;

    private Label revenueKpiTitle = null!;
    private Label revenueKpiValue = null!;
    private Label revenueKpiChange = null!;

    private Label productsKpiTitle = null!;
    private Label productsKpiValue = null!;
    private Label productsKpiChange = null!;

    private Label lowStockKpiTitle = null!;
    private Label lowStockKpiValue = null!;
    private Label lowStockKpiChange = null!;

    private TableLayoutPanel firstChartTable = null!;
    private TableLayoutPanel secondChartTable = null!;

    private Panel salesChartPanel = null!;
    private Panel categoryChartPanel = null!;
    private Panel productsChartPanel = null!;
    private Panel inventoryChartPanel = null!;

    private Label salesChartTitle = null!;
    private Label categoryChartTitle = null!;
    private Label productsChartTitle = null!;
    private Label inventoryChartTitle = null!;

    private TableLayoutPanel recentPanel = null!;

    private Panel recentSalesPanel = null!;
    private Panel recentOrdersPanel = null!;

    private TableLayoutPanel recentSalesHeaderTable = null!;
    private TableLayoutPanel recentOrdersHeaderTable = null!;

    private Label recentSalesTitleLabel = null!;
    private Label recentOrdersTitleLabel = null!;

    private Button recentSalesViewAllButton = null!;
    private Button recentOrdersViewAllButton = null!;

    private TableLayoutPanel recentTable = null!;
    private TableLayoutPanel recentOrdersTable = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();

        mainTable = new TableLayoutPanel();
        kpiTable = new TableLayoutPanel();

        salesKpiCard = CreateCard();
        revenueKpiCard = CreateCard();
        productsKpiCard = CreateCard();
        lowStockKpiCard = CreateCard();

        salesKpiTitle = CreateLabel(
            "Total Sales",
            9.5F,
            Color.FromArgb(100, 116, 139));

        salesKpiValue = CreateLabel(
            "128",
            22F,
            Color.FromArgb(15, 23, 42),
            FontStyle.Bold);

        salesKpiChange = CreateLabel(
            "+12.5% from last week",
            8.5F,
            Color.FromArgb(22, 163, 74));

        revenueKpiTitle = CreateLabel(
            "Revenue",
            9.5F,
            Color.FromArgb(100, 116, 139));

        revenueKpiValue = CreateLabel(
            "$9,390",
            22F,
            Color.FromArgb(15, 23, 42),
            FontStyle.Bold);

        revenueKpiChange = CreateLabel(
            "+8.4% from last week",
            8.5F,
            Color.FromArgb(22, 163, 74));

        productsKpiTitle = CreateLabel(
            "Products",
            9.5F,
            Color.FromArgb(100, 116, 139));

        productsKpiValue = CreateLabel(
            "246",
            22F,
            Color.FromArgb(15, 23, 42),
            FontStyle.Bold);

        productsKpiChange = CreateLabel(
            "+3 this week",
            8.5F,
            Color.FromArgb(37, 99, 235));

        lowStockKpiTitle = CreateLabel(
            "Low Stock",
            9.5F,
            Color.FromArgb(100, 116, 139));

        lowStockKpiValue = CreateLabel(
            "17",
            22F,
            Color.FromArgb(15, 23, 42),
            FontStyle.Bold);

        lowStockKpiChange = CreateLabel(
            "Needs attention",
            8.5F,
            Color.FromArgb(220, 38, 38));

        firstChartTable = CreateSectionTable();
        secondChartTable = CreateSectionTable();

        salesChartPanel = CreateChartPanel();
        categoryChartPanel = CreateChartPanel();
        productsChartPanel = CreateChartPanel();
        inventoryChartPanel = CreateChartPanel();

        salesChartTitle =
            CreateChartTitle("Sales Overview");

        categoryChartTitle =
            CreateChartTitle("Sales by Category");

        productsChartTitle =
            CreateChartTitle("Top Selling Products");

        inventoryChartTitle =
            CreateChartTitle("Inventory Status");

        recentPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 1,
            BackColor = Color.Transparent,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        recentPanel.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                50F));

        recentPanel.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Absolute,
                16F));

        recentPanel.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                50F));

        recentSalesPanel = CreateRecentPanel();
        recentOrdersPanel = CreateRecentPanel();

        recentSalesHeaderTable =
            CreateRecentHeaderTable();

        recentOrdersHeaderTable =
            CreateRecentHeaderTable();

        recentSalesTitleLabel =
            CreateRecentTitle("Recent Sales");

        recentOrdersTitleLabel =
            CreateRecentTitle("Recent Orders");

        recentSalesViewAllButton =
            CreateViewAllButton();

        recentOrdersViewAllButton =
            CreateViewAllButton();

        recentSalesViewAllButton.Click +=
            recentSalesViewAllButton_Click;

        recentOrdersViewAllButton.Click +=
            recentOrdersViewAllButton_Click;

        recentSalesHeaderTable.Controls.Add(
            recentSalesTitleLabel,
            0,
            0);

        recentSalesHeaderTable.Controls.Add(
            recentSalesViewAllButton,
            1,
            0);

        recentOrdersHeaderTable.Controls.Add(
            recentOrdersTitleLabel,
            0,
            0);

        recentOrdersHeaderTable.Controls.Add(
            recentOrdersViewAllButton,
            1,
            0);

        recentTable = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        recentOrdersTable = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        recentSalesPanel.Controls.Add(
            recentTable);

        recentSalesPanel.Controls.Add(
            recentSalesHeaderTable);

        recentOrdersPanel.Controls.Add(
            recentOrdersTable);

        recentOrdersPanel.Controls.Add(
            recentOrdersHeaderTable);

        recentPanel.Controls.Add(
            recentSalesPanel,
            0,
            0);

        recentPanel.Controls.Add(
            recentOrdersPanel,
            2,
            0);

        SuspendLayout();

        mainTable.Dock = DockStyle.Top;

        mainTable.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Left |
            AnchorStyles.Right;

        mainTable.ColumnCount = 1;
        mainTable.RowCount = 7;

        mainTable.AutoSize = false;
        mainTable.Width = ClientSize.Width;
        mainTable.Height = 1050;

        mainTable.Padding =
            new Padding(16);

        mainTable.BackColor =
            Color.FromArgb(
                248,
                250,
                252);

        mainTable.Margin =
            new Padding(0);

        mainTable.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                110F));

        mainTable.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                16F));

        mainTable.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                300F));

        mainTable.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                16F));

        mainTable.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                300F));

        mainTable.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                16F));

        mainTable.RowStyles.Add(
            new RowStyle(
                SizeType.Absolute,
                260F));

        ConfigureKpis();
        ConfigureCharts();

        mainTable.Controls.Add(
            kpiTable,
            0,
            0);

        mainTable.Controls.Add(
            firstChartTable,
            0,
            2);

        mainTable.Controls.Add(
            secondChartTable,
            0,
            4);

        mainTable.Controls.Add(
            recentPanel,
            0,
            6);

        Controls.Add(mainTable);

        AutoScaleMode =
            AutoScaleMode.Font;

        AutoScroll = true;

        HorizontalScroll.Enabled = false;
        HorizontalScroll.Visible = false;

        VerticalScroll.Enabled = true;
        VerticalScroll.Visible = true;

        BackColor =
            Color.FromArgb(
                248,
                250,
                252);

        Font = new Font(
            "Bahnschrift",
            9.5F);

        Name = "DashboardView";

        MinimumSize = new Size(
            900,
            700);

        ResumeLayout(false);
    }

    private void ConfigureKpis()
    {
        kpiTable.Dock = DockStyle.Fill;
        kpiTable.ColumnCount = 4;
        kpiTable.RowCount = 1;

        kpiTable.BackColor =
            Color.Transparent;

        kpiTable.Margin =
            new Padding(0);

        kpiTable.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                25F));

        kpiTable.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                25F));

        kpiTable.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                25F));

        kpiTable.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                25F));

        salesKpiCard.Margin =
            new Padding(0, 0, 8, 0);

        revenueKpiCard.Margin =
            new Padding(8, 0, 8, 0);

        productsKpiCard.Margin =
            new Padding(8, 0, 8, 0);

        lowStockKpiCard.Margin =
            new Padding(8, 0, 0, 0);

        AddKpiControls(
            salesKpiCard,
            salesKpiTitle,
            salesKpiValue,
            salesKpiChange);

        AddKpiControls(
            revenueKpiCard,
            revenueKpiTitle,
            revenueKpiValue,
            revenueKpiChange);

        AddKpiControls(
            productsKpiCard,
            productsKpiTitle,
            productsKpiValue,
            productsKpiChange);

        AddKpiControls(
            lowStockKpiCard,
            lowStockKpiTitle,
            lowStockKpiValue,
            lowStockKpiChange);

        kpiTable.Controls.Add(
            salesKpiCard,
            0,
            0);

        kpiTable.Controls.Add(
            revenueKpiCard,
            1,
            0);

        kpiTable.Controls.Add(
            productsKpiCard,
            2,
            0);

        kpiTable.Controls.Add(
            lowStockKpiCard,
            3,
            0);
    }

    private void ConfigureCharts()
    {
        ConfigureChartPanel(
            salesChartPanel,
            salesChartTitle);

        ConfigureChartPanel(
            categoryChartPanel,
            categoryChartTitle);

        ConfigureChartPanel(
            productsChartPanel,
            productsChartTitle);

        ConfigureChartPanel(
            inventoryChartPanel,
            inventoryChartTitle);

        salesChartPanel.Margin =
            new Padding(0, 0, 8, 0);

        categoryChartPanel.Margin =
            new Padding(8, 0, 0, 0);

        productsChartPanel.Margin =
            new Padding(0, 0, 8, 0);

        inventoryChartPanel.Margin =
            new Padding(8, 0, 0, 0);

        firstChartTable.Controls.Add(
            salesChartPanel,
            0,
            0);

        firstChartTable.Controls.Add(
            categoryChartPanel,
            1,
            0);

        secondChartTable.Controls.Add(
            productsChartPanel,
            0,
            0);

        secondChartTable.Controls.Add(
            inventoryChartPanel,
            1,
            0);
    }

    private static void ConfigureChartPanel(
        Panel panel,
        Label title)
    {
        panel.Dock = DockStyle.Fill;
        panel.BackColor = Color.White;
        panel.Padding = new Padding(16);
        panel.Margin = new Padding(0);

        title.Dock = DockStyle.Top;
        title.Height = 28;
        title.TextAlign =
            ContentAlignment.MiddleLeft;
        title.Margin = new Padding(0);

        panel.Controls.Add(title);
    }

    private static TableLayoutPanel CreateSectionTable()
    {
        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.Transparent,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        table.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                65F));

        table.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                35F));

        return table;
    }

    private static Panel CreateChartPanel()
    {
        return new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Margin = new Padding(0)
        };
    }

    private static Panel CreateRecentPanel()
    {
        return new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Padding = new Padding(16),
            Margin = new Padding(0)
        };
    }

    private static TableLayoutPanel CreateRecentHeaderTable()
    {
        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 32,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.Transparent,
            Margin = new Padding(
                0,
                0,
                0,
                8),
            Padding = new Padding(0)
        };

        table.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Percent,
                100F));

        table.ColumnStyles.Add(
            new ColumnStyle(
                SizeType.Absolute,
                82F));

        return table;
    }

    private static Label CreateRecentTitle(
        string text)
    {
        return new Label
        {
            Text = text,
            Dock = DockStyle.Fill,
            TextAlign =
                ContentAlignment.MiddleLeft,
            BackColor = Color.Transparent,
            Font = new Font(
                "Bahnschrift",
                11F,
                FontStyle.Bold),
            ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42),
            Margin = new Padding(0),
            Padding = new Padding(0)
        };
    }

    private static Button CreateViewAllButton()
    {
        var button = new Button
        {
            Text = "View All  →",
            Dock = DockStyle.Fill,
            Font = new Font(
                "Bahnschrift",
                8.5F,
                FontStyle.Bold),
            ForeColor =
                Color.FromArgb(
                    37,
                    99,
                    235),
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            Margin = new Padding(0),
            Padding = new Padding(0),
            TextAlign =
                ContentAlignment.MiddleRight
        };

        button.FlatAppearance.BorderSize = 0;

        button.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(
                248,
                250,
                252);

        button.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(
                241,
                245,
                249);

        return button;
    }

    private static Panel CreateCard()
    {
        return new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            Padding = new Padding(16),
            Margin = new Padding(0)
        };
    }

    private static Label CreateLabel(
        string text,
        float size,
        Color color,
        FontStyle style =
            FontStyle.Regular)
    {
        return new Label
        {
            Text = text,
            AutoSize = true,
            BackColor = Color.Transparent,
            Font = new Font(
                "Bahnschrift",
                size,
                style),
            ForeColor = color
        };
    }

    private static Label CreateChartTitle(
        string text)
    {
        return new Label
        {
            Text = text,
            BackColor = Color.Transparent,
            Font = new Font(
                "Bahnschrift",
                11F,
                FontStyle.Bold),
            ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42),
            Margin = new Padding(0)
        };
    }

    private static void AddKpiControls(
        Panel card,
        Label title,
        Label value,
        Label change)
    {
        title.Location =
            new Point(14, 12);

        value.Location =
            new Point(14, 34);

        change.Location =
            new Point(14, 76);

        card.Controls.Add(title);
        card.Controls.Add(value);
        card.Controls.Add(change);
    }
}