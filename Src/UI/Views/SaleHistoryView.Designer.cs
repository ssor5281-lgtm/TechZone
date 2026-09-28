using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

partial class SaleHistoryView
{
    private IContainer components = null!;

    private DataTableToolbar dataTableToolbar;
    private DataTable dataTableSaleHistory;
    private TechZone.UI.Components.DataTablePagination dataTablePagination1;
    private TzDropdownButton tzDropdownButtonSort;
    private TzDropdownButton tzDropdownButtonFilter;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dataTableToolbar = new TechZone.UI.Components.DataTableToolbar();
        dataTableSaleHistory = new TechZone.UI.Components.DataTable();
        dataTablePagination1 = new TechZone.UI.Components.DataTablePagination();
        tzDropdownButtonSort = new TechZone.UI.Components.TzDropdownButton();
        tzDropdownButtonFilter = new TechZone.UI.Components.TzDropdownButton();
        SuspendLayout();
        // 
        // dataTableToolbar
        // 
        dataTableToolbar.BackColor = System.Drawing.Color.Transparent;
        dataTableToolbar.Dock = System.Windows.Forms.DockStyle.Top;
        dataTableToolbar.Location = new System.Drawing.Point(15, 15);
        dataTableToolbar.Margin = new System.Windows.Forms.Padding(0);
        dataTableToolbar.Name = "dataTableToolbar";
        dataTableToolbar.Size = new System.Drawing.Size(999, 60);
        dataTableToolbar.TabIndex = 0;
        // 
        // dataTableSaleHistory
        // 
        dataTableSaleHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        dataTableSaleHistory.BackColor = System.Drawing.Color.White;
        dataTableSaleHistory.DataSource = null;
        dataTableSaleHistory.Dock = System.Windows.Forms.DockStyle.Fill;
        dataTableSaleHistory.FontSize = 9.5F;
        dataTableSaleHistory.Location = new System.Drawing.Point(15, 75);
        dataTableSaleHistory.Margin = new System.Windows.Forms.Padding(0);
        dataTableSaleHistory.Name = "dataTableSaleHistory";
        dataTableSaleHistory.NumberStart = 1;
        dataTableSaleHistory.Size = new System.Drawing.Size(999, 582);
        dataTableSaleHistory.TabIndex = 1;
        // 
        // dataTablePagination1
        // 
        dataTablePagination1.BackColor = System.Drawing.Color.Transparent;
        dataTablePagination1.Dock = System.Windows.Forms.DockStyle.Bottom;
        dataTablePagination1.Location = new System.Drawing.Point(15, 657);
        dataTablePagination1.Margin = new System.Windows.Forms.Padding(0);
        dataTablePagination1.MaximumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.MinimumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.Name = "dataTablePagination1";
        dataTablePagination1.Size = new System.Drawing.Size(400, 44);
        dataTablePagination1.TabIndex = 2;
        // 
        // tzDropdownButtonSort
        // 
        tzDropdownButtonSort.BackColor = System.Drawing.Color.White;
        tzDropdownButtonSort.BackgroundImage = global::TechZone.Resources.dropdown_frame;
        tzDropdownButtonSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        tzDropdownButtonSort.Cursor = System.Windows.Forms.Cursors.Hand;
        tzDropdownButtonSort.Location = new System.Drawing.Point(390, 15);
        tzDropdownButtonSort.Name = "tzDropdownButtonSort";
        tzDropdownButtonSort.Size = new System.Drawing.Size(175, 44);
        tzDropdownButtonSort.TabIndex = 3;
        // 
        // tzDropdownButtonFilter
        // 
        tzDropdownButtonFilter.BackColor = System.Drawing.Color.White;
        tzDropdownButtonFilter.BackgroundImage = global::TechZone.Resources.dropdown_frame;
        tzDropdownButtonFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        tzDropdownButtonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
        tzDropdownButtonFilter.Location = new System.Drawing.Point(580, 15);
        tzDropdownButtonFilter.Name = "tzDropdownButtonFilter";
        tzDropdownButtonFilter.Size = new System.Drawing.Size(175, 44);
        tzDropdownButtonFilter.TabIndex = 4;
        // 
        // SaleHistoryView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor =
            Color.FromArgb(
                248,
                250,
                252);
        Controls.Add(tzDropdownButtonFilter);
        Controls.Add(tzDropdownButtonSort);
        Controls.Add(dataTableSaleHistory);
        Controls.Add(dataTablePagination1);
        Controls.Add(dataTableToolbar);
        Padding = new System.Windows.Forms.Padding(15);
        Size = new System.Drawing.Size(1029, 716);
        ResumeLayout(false);
    }

    #endregion
}