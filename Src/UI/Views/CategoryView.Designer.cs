using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

partial class CategoryView
{
    private IContainer components = null!;

    private DataTableToolbar dataTableToolbar;
    private System.Windows.Forms.Panel tableContainer;

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
        tableContainer = new System.Windows.Forms.Panel();
        dataTablePagination1 = new DataTablePagination();
        dataTableCategory = new DataTable();
        tzDropdownButtonSort = new TzDropdownButton();
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
        dataTableToolbar.TabIndex = 2;
        // 
        // tableContainer
        // 
        tableContainer.Location = new System.Drawing.Point(0, 0);
        tableContainer.Name = "tableContainer";
        tableContainer.Size = new System.Drawing.Size(200, 100);
        tableContainer.TabIndex = 0;
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
        // dataTableCategory
        // 
        dataTableCategory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        dataTableCategory.BackColor = System.Drawing.Color.White;
        dataTableCategory.DataSource = null;
        dataTableCategory.Dock = System.Windows.Forms.DockStyle.Fill;
        dataTableCategory.Location = new System.Drawing.Point(15, 75);
        dataTableCategory.Margin = new System.Windows.Forms.Padding(0);
        dataTableCategory.Name = "dataTableCategory";
        dataTableCategory.NumberStart = 1;
        dataTableCategory.Size = new System.Drawing.Size(1292, 712);
        dataTableCategory.TabIndex = 4;
        // 
        // tzDropdownButtonSort
        // 
        tzDropdownButtonSort.BackColor = System.Drawing.Color.Transparent;
        tzDropdownButtonSort.Cursor = System.Windows.Forms.Cursors.Hand;
        tzDropdownButtonSort.Location = new System.Drawing.Point(390, 15);
        tzDropdownButtonSort.Name = "tzDropdownButtonSort";
        tzDropdownButtonSort.Size = new System.Drawing.Size(175, 44);
        tzDropdownButtonSort.TabIndex = 5;
        // 
        // CategoryView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor =
            Color.FromArgb(
                248,
                250,
                252);
        Controls.Add(tzDropdownButtonSort);
        Controls.Add(dataTableCategory);
        Controls.Add(dataTablePagination1);
        Controls.Add(dataTableToolbar);
        Padding = new System.Windows.Forms.Padding(15);
        Size = new System.Drawing.Size(1322, 846);
        ResumeLayout(false);
    }

    private TzDropdownButton tzDropdownButtonSort;

    private DataTable dataTableCategory;

    private DataTablePagination dataTablePagination1;

    #endregion
}