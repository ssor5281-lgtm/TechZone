using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

partial class UserView
{
    private IContainer components = null!;

    private DataTableToolbar dataTableToolbar;
    private DataTable dataTableUser;
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
        dataTableUser = new DataTable();
        dataTablePagination1 = new DataTablePagination();
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
        // dataTableUser
        // 
        dataTableUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        dataTableUser.BackColor = System.Drawing.Color.White;
        dataTableUser.DataSource = null;
        dataTableUser.Dock = System.Windows.Forms.DockStyle.Fill;
        dataTableUser.Location = new System.Drawing.Point(15, 75);
        dataTableUser.Margin = new System.Windows.Forms.Padding(0);
        dataTableUser.Name = "dataTableUser";
        dataTableUser.Size = new System.Drawing.Size(1292, 712);
        dataTableUser.TabIndex = 1;
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
        dataTablePagination1.TabIndex = 2;
        // 
        // UserView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor =
            Color.FromArgb(
                248,
                250,
                252);
        Controls.Add(dataTableUser);
        Controls.Add(dataTablePagination1);
        Controls.Add(dataTableToolbar);
        Padding = new System.Windows.Forms.Padding(15);
        Size = new System.Drawing.Size(1322, 846);
        ResumeLayout(false);
    }

    #endregion
}