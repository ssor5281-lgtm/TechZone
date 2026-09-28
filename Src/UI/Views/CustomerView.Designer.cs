
using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

partial class CustomerView
{
    private IContainer components = null!;

    private DataTableToolbar dataTableToolbar;
    private DataTable dataTableCustomer;
    private DataTablePagination dataTablePagination1;

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
        dataTableToolbar = new DataTableToolbar();
        dataTableCustomer = new DataTable();
        dataTablePagination1 = new DataTablePagination();
        tzDropdownButtonSort = new TzDropdownButton();
        tzDropdownButtonFilter = new TzDropdownButton();
        SuspendLayout();
        // 
        // dataTableToolbar
        // 
        dataTableToolbar.BackColor = System.Drawing.Color.Transparent;
        dataTableToolbar.Dock = System.Windows.Forms.DockStyle.Top;
        dataTableToolbar.Location = new System.Drawing.Point(15, 15);
        dataTableToolbar.Margin = new System.Windows.Forms.Padding(0);
        dataTableToolbar.Name = "dataTableToolbar";
        dataTableToolbar.Size = new System.Drawing.Size(1292, 60);
        dataTableToolbar.TabIndex = 0;
        // 
        // dataTableCustomer
        // 
        dataTableCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        dataTableCustomer.BackColor = System.Drawing.Color.White;
        dataTableCustomer.DataSource = null;
        dataTableCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
        dataTableCustomer.Location = new System.Drawing.Point(15, 75);
        dataTableCustomer.Margin = new System.Windows.Forms.Padding(0);
        dataTableCustomer.Name = "dataTableCustomer";
        dataTableCustomer.NumberStart = 1;
        dataTableCustomer.Size = new System.Drawing.Size(1292, 712);
        dataTableCustomer.TabIndex = 1;
        // 
        // dataTablePagination1
        // 
        dataTablePagination1.BackColor = System.Drawing.Color.Transparent;
        dataTablePagination1.Dock = System.Windows.Forms.DockStyle.Bottom;
        dataTablePagination1.Location = new System.Drawing.Point(15, 787);
        dataTablePagination1.Margin = new System.Windows.Forms.Padding(0);
        dataTablePagination1.MaximumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.MinimumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.Name = "dataTablePagination1";
        dataTablePagination1.Size = new System.Drawing.Size(400, 44);
        dataTablePagination1.TabIndex = 3;
        // 
        // tzDropdownButtonSort
        // 
        tzDropdownButtonSort.BackColor = System.Drawing.Color.White;
        tzDropdownButtonSort.BackgroundImage = TechZone.Resources.dropdown_frame;
        tzDropdownButtonSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        tzDropdownButtonSort.Cursor = System.Windows.Forms.Cursors.Hand;
        tzDropdownButtonSort.Location = new System.Drawing.Point(390, 15);
        tzDropdownButtonSort.Name = "tzDropdownButtonSort";
        tzDropdownButtonSort.Size = new System.Drawing.Size(175, 44);
        tzDropdownButtonSort.TabIndex = 4;
        // 
        // tzDropdownButtonFilter
        // 
        tzDropdownButtonFilter.BackColor = System.Drawing.Color.White;
        tzDropdownButtonFilter.BackgroundImage = TechZone.Resources.dropdown_frame;
        tzDropdownButtonFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        tzDropdownButtonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
        tzDropdownButtonFilter.Location = new System.Drawing.Point(580, 15);
        tzDropdownButtonFilter.Name = "tzDropdownButtonFilter";
        tzDropdownButtonFilter.Size = new System.Drawing.Size(175, 44);
        tzDropdownButtonFilter.TabIndex = 5;
        // 
        // CustomerView
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
        Controls.Add(dataTableCustomer);
        Controls.Add(dataTablePagination1);
        Controls.Add(dataTableToolbar);
        Padding = new System.Windows.Forms.Padding(15);
        Size = new System.Drawing.Size(1322, 846);
        ResumeLayout(false);
    }

    private TzDropdownButton tzDropdownButtonFilter;

    private TzDropdownButton tzDropdownButtonSort;

    #endregion
}
