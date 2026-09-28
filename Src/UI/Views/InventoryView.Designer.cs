using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

partial class InventoryView
{
    private IContainer components = null!;

    private System.Windows.Forms.Panel containerInventory;

    private CardState cardStateTotalProduct;
    private CardState cardStateStockIn;
    private CardState cardStateStockLow;
    private CardState cardStateStockOut;

    private DataTableToolbar dataTableToolbar;
    private TzDropdownButton statusDropdown;
    private TzDropdownButton categoryDropdown;

    private DataTable dataTableInventory;
    private DataTablePagination dataTablePagination1;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        containerInventory = new Panel();
        categoryDropdown = new TzDropdownButton();
        statusDropdown = new TzDropdownButton();
        dataTableToolbar = new DataTableToolbar();
        cardStateStockLow = new CardState();
        cardStateStockIn = new CardState();
        cardStateTotalProduct = new CardState();
        dataTableInventory = new DataTable();
        dataTablePagination1 = new DataTablePagination();
        cardStateStockOut = new CardState();

        containerInventory.SuspendLayout();
        SuspendLayout();

        containerInventory.BackColor = Color.Transparent;
        containerInventory.Controls.Add(cardStateStockOut);
        containerInventory.Controls.Add(categoryDropdown);
        containerInventory.Controls.Add(statusDropdown);
        containerInventory.Controls.Add(dataTableToolbar);
        containerInventory.Controls.Add(cardStateStockLow);
        containerInventory.Controls.Add(cardStateStockIn);
        containerInventory.Controls.Add(cardStateTotalProduct);
        containerInventory.Dock = DockStyle.Top;
        containerInventory.Location = new Point(15, 15);
        containerInventory.Name = "containerInventory";
        containerInventory.Size = new Size(1292, 175);
        containerInventory.TabIndex = 0;

        categoryDropdown.BackColor = Color.White;
        categoryDropdown.Cursor = Cursors.Hand;
        categoryDropdown.Location = new Point(560, 115);
        categoryDropdown.Name = "categoryDropdown";
        categoryDropdown.Size = new Size(175, 44);
        categoryDropdown.TabIndex = 5;

        statusDropdown.BackColor = Color.White;
        statusDropdown.Cursor = Cursors.Hand;
        statusDropdown.Location = new Point(372, 115);
        statusDropdown.Name = "statusDropdown";
        statusDropdown.Size = new Size(175, 44);
        statusDropdown.TabIndex = 4;

        dataTableToolbar.BackColor = Color.Transparent;
        dataTableToolbar.Location = new Point(0, 115);
        dataTableToolbar.Margin = new Padding(0);
        dataTableToolbar.Name = "dataTableToolbar";
        dataTableToolbar.Size = new Size(359, 44);
        dataTableToolbar.TabIndex = 3;

        cardStateStockLow.Location = new Point(330, 0);
        cardStateStockLow.Name = "cardStateStockLow";
        cardStateStockLow.Size = new Size(150, 100);
        cardStateStockLow.TabIndex = 2;
        cardStateStockLow.Title = "Low Stock";
        cardStateStockLow.TitleColor = SystemColors.ControlText;
        cardStateStockLow.Value = "0";
        cardStateStockLow.ValueColor = SystemColors.ControlText;

        cardStateStockIn.Location = new Point(165, 0);
        cardStateStockIn.Name = "cardStateStockIn";
        cardStateStockIn.Size = new Size(150, 100);
        cardStateStockIn.TabIndex = 1;
        cardStateStockIn.Title = "In Stock";
        cardStateStockIn.TitleColor = SystemColors.ControlText;
        cardStateStockIn.Value = "0";
        cardStateStockIn.ValueColor = SystemColors.ControlText;

        cardStateTotalProduct.Location = new Point(0, 0);
        cardStateTotalProduct.Name = "cardStateTotalProduct";
        cardStateTotalProduct.Size = new Size(150, 100);
        cardStateTotalProduct.TabIndex = 0;
        cardStateTotalProduct.Title = "Total Products";
        cardStateTotalProduct.TitleColor = SystemColors.ControlText;
        cardStateTotalProduct.Value = "0";
        cardStateTotalProduct.ValueColor = SystemColors.ControlText;

        cardStateStockOut.Location = new Point(495, 0);
        cardStateStockOut.Name = "cardStateStockOut";
        cardStateStockOut.Size = new Size(150, 100);
        cardStateStockOut.TabIndex = 6;
        cardStateStockOut.Title = "Out of Stock";
        cardStateStockOut.TitleColor = SystemColors.ControlText;
        cardStateStockOut.Value = "0";
        cardStateStockOut.ValueColor = SystemColors.ControlText;

        dataTableInventory.BackColor = Color.White;
        dataTableInventory.Dock = DockStyle.Fill;
        dataTableInventory.Location = new Point(15, 190);
        dataTableInventory.Margin = new Padding(0);
        dataTableInventory.Name = "dataTableInventory";
        dataTableInventory.Size = new Size(1292, 597);
        dataTableInventory.TabIndex = 1;

        dataTablePagination1.BackColor = Color.Transparent;
        dataTablePagination1.Dock = DockStyle.Bottom;
        dataTablePagination1.Location = new Point(15, 787);
        dataTablePagination1.Margin = new Padding(0);
        dataTablePagination1.MaximumSize = new Size(400, 44);
        dataTablePagination1.MinimumSize = new Size(400, 44);
        dataTablePagination1.Name = "dataTablePagination1";
        dataTablePagination1.Size = new Size(400, 44);
        dataTablePagination1.TabIndex = 2;

        AutoScaleMode = AutoScaleMode.None;
        BackColor =
            Color.FromArgb(
                248,
                250,
                252);
        Controls.Add(dataTableInventory);
        Controls.Add(dataTablePagination1);
        Controls.Add(containerInventory);
        Padding = new Padding(15);
        Size = new Size(1322, 846);

        containerInventory.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
}