#nullable disable

using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

partial class ProductView
{
    private IContainer components = null!;

    private DataTableToolbar dataTableToolbar;
    private DataTable dataTableProduct;
    private DataTablePagination dataTablePagination1;
    private TzDropdownButton tzDropdownButtonSort;
    private TzDropdownButton tzDropdownButtonCategory;
    private ProductGridView productGridView;
    private Panel productPanel;
    private Button btnViewSwitch;
    private ToolTip toolTip;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();

        dataTableToolbar = new DataTableToolbar();
        dataTableProduct = new DataTable();
        dataTablePagination1 = new DataTablePagination();
        tzDropdownButtonSort = new TzDropdownButton();
        tzDropdownButtonCategory = new TzDropdownButton();
        productGridView = new ProductGridView();
        productPanel = new Panel();
        btnViewSwitch = new Button();
        toolTip = new ToolTip(components);

        SuspendLayout();

        // dataTableToolbar

        dataTableToolbar.BackColor =
            Color.Transparent;

        dataTableToolbar.Dock =
            DockStyle.Top;

        dataTableToolbar.Location =
            new Point(15, 15);

        dataTableToolbar.Margin =
            new Padding(0);

        dataTableToolbar.Name =
            "dataTableToolbar";

        dataTableToolbar.Size =
            new Size(1292, 60);

        dataTableToolbar.TabIndex = 0;

        // dataTablePagination1

        dataTablePagination1.BackColor =
            Color.Transparent;

        dataTablePagination1.Dock =
            DockStyle.Bottom;

        dataTablePagination1.Location =
            new Point(15, 787);

        dataTablePagination1.Margin =
            new Padding(0);

        dataTablePagination1.MaximumSize =
            new Size(400, 44);

        dataTablePagination1.MinimumSize =
            new Size(400, 44);

        dataTablePagination1.Name =
            "dataTablePagination1";

        dataTablePagination1.Size =
            new Size(400, 44);

        dataTablePagination1.TabIndex = 1;

        // productPanel

        productPanel.BackColor =
            Color.FromArgb(
                248,
                250,
                252);

        productPanel.Dock =
            DockStyle.Fill;

        productPanel.Location =
            new Point(15, 75);

        productPanel.Margin =
            new Padding(0);

        productPanel.Name =
            "productPanel";

        productPanel.Padding =
            new Padding(0);

        productPanel.Size =
            new Size(1292, 712);

        productPanel.TabIndex = 2;

        // dataTableProduct

        dataTableProduct.AutoSizeMode =
            AutoSizeMode.GrowAndShrink;

        dataTableProduct.BackColor =
            Color.White;

        dataTableProduct.DataSource =
            null;

        dataTableProduct.Dock =
            DockStyle.Fill;

        dataTableProduct.Location =
            new Point(0, 0);

        dataTableProduct.Margin =
            new Padding(0);

        dataTableProduct.Name =
            "dataTableProduct";

        dataTableProduct.NumberStart =
            1;

        dataTableProduct.Size =
            new Size(1292, 712);

        dataTableProduct.TabIndex = 0;

        // productGridView

        productGridView.BackColor =
            Color.FromArgb(
                248,
                250,
                252);

        productGridView.Dock =
            DockStyle.Fill;

        productGridView.Location =
            new Point(0, 0);

        productGridView.Margin =
            new Padding(0);

        productGridView.Name =
            "productGridView";

        productGridView.Size =
            new Size(1292, 712);

        productGridView.TabIndex = 1;

        productGridView.Visible =
            false;

        productPanel.Controls.Add(
            productGridView);

        productPanel.Controls.Add(
            dataTableProduct);

        // tzDropdownButtonSort

        tzDropdownButtonSort.BackColor =
            Color.White;

        tzDropdownButtonSort.BackgroundImage =
            TechZone.Resources.dropdown_frame;

        tzDropdownButtonSort.BackgroundImageLayout =
            ImageLayout.Stretch;

        tzDropdownButtonSort.Cursor =
            Cursors.Hand;

        tzDropdownButtonSort.Location =
            new Point(390, 15);

        tzDropdownButtonSort.Name =
            "tzDropdownButtonSort";

        tzDropdownButtonSort.Size =
            new Size(175, 44);

        tzDropdownButtonSort.TabIndex = 3;

        // tzDropdownButtonCategory

        tzDropdownButtonCategory.BackColor =
            Color.White;

        tzDropdownButtonCategory.BackgroundImage =
            TechZone.Resources.dropdown_frame;

        tzDropdownButtonCategory.BackgroundImageLayout =
            ImageLayout.Stretch;

        tzDropdownButtonCategory.Cursor =
            Cursors.Hand;

        tzDropdownButtonCategory.Location =
            new Point(580, 15);

        tzDropdownButtonCategory.Name =
            "tzDropdownButtonCategory";

        tzDropdownButtonCategory.Size =
            new Size(175, 44);

        tzDropdownButtonCategory.TabIndex = 4;

        // btnViewSwitch

        btnViewSwitch.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Right;

        btnViewSwitch.BackColor =
            Color.Transparent;

        btnViewSwitch.BackgroundImage =
            null;

        btnViewSwitch.BackgroundImageLayout =
            ImageLayout.Stretch;

        btnViewSwitch.Cursor =
            Cursors.Hand;

        btnViewSwitch.FlatAppearance.BorderSize =
            0;

        btnViewSwitch.FlatAppearance.MouseDownBackColor =
            Color.Transparent;

        btnViewSwitch.FlatAppearance.MouseOverBackColor =
            Color.Transparent;

        btnViewSwitch.FlatStyle =
            FlatStyle.Flat;

        btnViewSwitch.ForeColor =
            Color.Transparent;

        btnViewSwitch.Location =
            new Point(1272, 15);

        btnViewSwitch.Margin =
            new Padding(0);

        btnViewSwitch.Name =
            "btnViewSwitch";

        btnViewSwitch.Size =
            new Size(35, 35);

        btnViewSwitch.TabIndex =
            5;

        btnViewSwitch.Text =
            string.Empty;

        btnViewSwitch.UseVisualStyleBackColor =
            false;

        toolTip.SetToolTip(
            btnViewSwitch,
            "Switch to Grid View");

        // ProductView

        AutoScaleDimensions =
            new SizeF(8F, 20F);

        AutoScaleMode =
            AutoScaleMode.Font;

        BackColor =
            Color.FromArgb(
                248,
                250,
                252);

        Controls.Add(
            productPanel);

        Controls.Add(
            dataTablePagination1);

        Controls.Add(
            btnViewSwitch);

        Controls.Add(
            tzDropdownButtonCategory);

        Controls.Add(
            tzDropdownButtonSort);

        Controls.Add(
            dataTableToolbar);

        Padding =
            new Padding(15);

        Size =
            new Size(1322, 846);

        ResumeLayout(false);
    }
}