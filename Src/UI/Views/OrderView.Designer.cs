using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

partial class OrderView
{
    private IContainer components = null!;

    private System.Windows.Forms.Panel containerOrder;
    private DataTableToolbar dataTableToolbar;
    private TzDropdownButton statusDropdown;
    private TzDropdownButton sortDropdown;
    private DataTable dataTableOrder;
    private TechZone.UI.Components.DataTablePagination dataTablePagination;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        
        containerOrder = new System.Windows.Forms.Panel();
        newOrderButton = new System.Windows.Forms.Button();
        sortDropdown = new TechZone.UI.Components.TzDropdownButton();
        statusDropdown = new TechZone.UI.Components.TzDropdownButton();
        dataTableToolbar = new TechZone.UI.Components.DataTableToolbar();
        dataTableOrder = new TechZone.UI.Components.DataTable();
        dataTablePagination = new TechZone.UI.Components.DataTablePagination();
        containerOrder.SuspendLayout();
        SuspendLayout();
        // 
        // containerOrder
        // 
        containerOrder.BackColor = System.Drawing.Color.Transparent;
        containerOrder.Controls.Add(newOrderButton);
        containerOrder.Controls.Add(sortDropdown);
        containerOrder.Controls.Add(statusDropdown);
        containerOrder.Controls.Add(dataTableToolbar);
        containerOrder.Dock = System.Windows.Forms.DockStyle.Top;
        containerOrder.Location = new System.Drawing.Point(15, 15);
        containerOrder.Name = "containerOrder";
        containerOrder.Size = new System.Drawing.Size(1292, 59);
        containerOrder.TabIndex = 0;
        // 
        // newOrderButton
        // 
        newOrderButton.AutoSize = true;
        newOrderButton.BackColor = System.Drawing.Color.RoyalBlue;
        newOrderButton.FlatAppearance.BorderSize = 0;
        newOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        newOrderButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
        newOrderButton.ForeColor = System.Drawing.Color.White;
        newOrderButton.Image = global::TechZone.Resources.icon_cart_plus;
        newOrderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        newOrderButton.Location = new System.Drawing.Point(749, 0);
        newOrderButton.Name = "newOrderButton";
        newOrderButton.Size = new System.Drawing.Size(130, 44);
        newOrderButton.TabIndex = 3;
        newOrderButton.Text = "New Order";
        newOrderButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        newOrderButton.UseVisualStyleBackColor = false;
        // 
        // sortDropdown
        // 
        sortDropdown.BackColor = System.Drawing.Color.White;
        sortDropdown.Cursor = System.Windows.Forms.Cursors.Hand;
        sortDropdown.Location = new System.Drawing.Point(560, 0);
        sortDropdown.Name = "sortDropdown";
        sortDropdown.Size = new System.Drawing.Size(175, 44);
        sortDropdown.TabIndex = 2;
        // 
        // statusDropdown
        // 
        statusDropdown.BackColor = System.Drawing.Color.White;
        statusDropdown.Cursor = System.Windows.Forms.Cursors.Hand;
        statusDropdown.Location = new System.Drawing.Point(372, 0);
        statusDropdown.Name = "statusDropdown";
        statusDropdown.Size = new System.Drawing.Size(175, 44);
        statusDropdown.TabIndex = 1;
        // 
        // dataTableToolbar
        // 
        dataTableToolbar.AddButtonIcon = global::TechZone.Resources.icon_cart_plus;
        dataTableToolbar.AddButtonIconAlign = System.Drawing.ContentAlignment.MiddleLeft;
        dataTableToolbar.AddButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight;
        dataTableToolbar.BackColor = System.Drawing.Color.Transparent;
        dataTableToolbar.Location = new System.Drawing.Point(0, 0);
        dataTableToolbar.Margin = new System.Windows.Forms.Padding(0);
        dataTableToolbar.Name = "dataTableToolbar";
        dataTableToolbar.Size = new System.Drawing.Size(359, 44);
        dataTableToolbar.TabIndex = 0;
        // 
        // dataTableOrder
        // 
        dataTableOrder.BackColor = System.Drawing.Color.White;
        dataTableOrder.DataSource = null;
        dataTableOrder.Dock = System.Windows.Forms.DockStyle.Fill;
        dataTableOrder.FontSize = 9.5F;
        dataTableOrder.Location = new System.Drawing.Point(15, 74);
        dataTableOrder.Margin = new System.Windows.Forms.Padding(0);
        dataTableOrder.Name = "dataTableOrder";
        dataTableOrder.NumberStart = 1;
        dataTableOrder.Size = new System.Drawing.Size(1292, 713);
        dataTableOrder.TabIndex = 1;
        // 
        // dataTablePagination
        // 
        dataTablePagination.BackColor = System.Drawing.Color.Transparent;
        dataTablePagination.Dock = System.Windows.Forms.DockStyle.Bottom;
        dataTablePagination.Location = new System.Drawing.Point(15, 787);
        dataTablePagination.Margin = new System.Windows.Forms.Padding(0);
        dataTablePagination.MaximumSize = new System.Drawing.Size(400, 44);
        dataTablePagination.MinimumSize = new System.Drawing.Size(400, 44);
        dataTablePagination.Name = "dataTablePagination";
        dataTablePagination.Size = new System.Drawing.Size(400, 44);
        dataTablePagination.TabIndex = 2;
        // 
        // OrderView
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        Controls.Add(dataTableOrder);
        Controls.Add(dataTablePagination);
        Controls.Add(containerOrder);
        Padding = new System.Windows.Forms.Padding(15);
        Size = new System.Drawing.Size(1322, 846);
        containerOrder.ResumeLayout(false);
        containerOrder.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button newOrderButton;
}