using System.ComponentModel;
using TechZone.UI.Controls;
using TechZone.UI.Theme;

namespace TechZone.UI.Forms;

partial class MainForm
{
    private IContainer components = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        sidebarPanel = new System.Windows.Forms.Panel();
        navSetting = new System.Windows.Forms.Panel();
        navSettingIcon = new TechZone.UI.Controls.TzIcon();
        navSettingLabel = new TechZone.UI.Controls.TzNavLabel();
        navUser = new System.Windows.Forms.Panel();
        navUserIcon = new TechZone.UI.Controls.TzIcon();
        navUserLabel = new TechZone.UI.Controls.TzNavLabel();
        sidebarAdminLabel = new System.Windows.Forms.Label();
        navCustomer = new System.Windows.Forms.Panel();
        navCustomerIcon = new TechZone.UI.Controls.TzIcon();
        navCustomerLabel = new TechZone.UI.Controls.TzNavLabel();
        navSale = new System.Windows.Forms.Panel();
        navSaleIcon = new TechZone.UI.Controls.TzIcon();
        navSaleLabel = new TechZone.UI.Controls.TzNavLabel();
        navInventory = new System.Windows.Forms.Panel();
        navInventoryIcon = new TechZone.UI.Controls.TzIcon();
        navInventoryLabel = new TechZone.UI.Controls.TzNavLabel();
        navCategory = new System.Windows.Forms.Panel();
        navCategoryIcon = new TechZone.UI.Controls.TzIcon();
        navCategoryLabel = new TechZone.UI.Controls.TzNavLabel();
        navProduct = new System.Windows.Forms.Panel();
        navProductIcon = new TechZone.UI.Controls.TzIcon();
        navProductLabel = new TechZone.UI.Controls.TzNavLabel();
        sidebarManagementLabel = new System.Windows.Forms.Label();
        sidebarHomeLabel = new System.Windows.Forms.Label();
        navDashboard = new System.Windows.Forms.Panel();
        navDashboardIcon = new TechZone.UI.Controls.TzIcon();
        navDashboardLabel = new TechZone.UI.Controls.TzNavLabel();
        sidebarBorder = new System.Windows.Forms.Panel();
        logoPanel = new System.Windows.Forms.Panel();
        logoLabel = new System.Windows.Forms.Label();
        logoPictureBox = new System.Windows.Forms.PictureBox();
        mainPanel = new System.Windows.Forms.Panel();
        contentPanel = new System.Windows.Forms.Panel();
        topbarPanel = new System.Windows.Forms.Panel();
        topbar = new TechZone.UI.Components.Topbar();
        topbarBorder = new System.Windows.Forms.Panel();
        sidebarPanel.SuspendLayout();
        navSetting.SuspendLayout();
        navUser.SuspendLayout();
        navCustomer.SuspendLayout();
        navSale.SuspendLayout();
        navInventory.SuspendLayout();
        navCategory.SuspendLayout();
        navProduct.SuspendLayout();
        navDashboard.SuspendLayout();
        logoPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
        mainPanel.SuspendLayout();
        topbarPanel.SuspendLayout();
        SuspendLayout();
        // 
        // sidebarPanel
        // 
        sidebarPanel.BackColor = System.Drawing.Color.RoyalBlue;
        sidebarPanel.Controls.Add(navSetting);
        sidebarPanel.Controls.Add(navUser);
        sidebarPanel.Controls.Add(sidebarAdminLabel);
        sidebarPanel.Controls.Add(navCustomer);
        sidebarPanel.Controls.Add(navSale);
        sidebarPanel.Controls.Add(navInventory);
        sidebarPanel.Controls.Add(navCategory);
        sidebarPanel.Controls.Add(navProduct);
        sidebarPanel.Controls.Add(sidebarManagementLabel);
        sidebarPanel.Controls.Add(sidebarHomeLabel);
        sidebarPanel.Controls.Add(navDashboard);
        sidebarPanel.Controls.Add(sidebarBorder);
        sidebarPanel.Controls.Add(logoPanel);
        sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
        sidebarPanel.Location = new System.Drawing.Point(0, 0);
        sidebarPanel.Name = "sidebarPanel";
        sidebarPanel.Size = new System.Drawing.Size(240, 903);
        sidebarPanel.TabIndex = 0;
        // 
        // navSetting
        // 
        navSetting.BackColor = System.Drawing.Color.Transparent;
        navSetting.Controls.Add(navSettingIcon);
        navSetting.Controls.Add(navSettingLabel);
        navSetting.Cursor = System.Windows.Forms.Cursors.Hand;
        navSetting.Location = new System.Drawing.Point(12, 520);
        navSetting.Name = "navSetting";
        navSetting.Size = new System.Drawing.Size(216, 44);
        navSetting.TabIndex = 11;
        // 
        // navSettingIcon
        // 
        navSettingIcon.BackColor = System.Drawing.Color.Transparent;
        navSettingIcon.Enabled = false;
        navSettingIcon.IconColor = System.Drawing.Color.Black;
        navSettingIcon.Location = new System.Drawing.Point(16, 12);
        navSettingIcon.Name = "navSettingIcon";
        navSettingIcon.Size = new System.Drawing.Size(24, 24);
        navSettingIcon.SvgPath = null;
        navSettingIcon.TabIndex = 0;
        // 
        // navSettingLabel
        // 
        navSettingLabel.BackColor = System.Drawing.Color.Transparent;
        navSettingLabel.Enabled = false;
        navSettingLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navSettingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navSettingLabel.Location = new System.Drawing.Point(50, 0);
        navSettingLabel.Name = "navSettingLabel";
        navSettingLabel.Size = new System.Drawing.Size(155, 44);
        navSettingLabel.TabIndex = 1;
        navSettingLabel.Text = "Setting";
        navSettingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // navUser
        // 
        navUser.BackColor = System.Drawing.Color.Transparent;
        navUser.Controls.Add(navUserIcon);
        navUser.Controls.Add(navUserLabel);
        navUser.Cursor = System.Windows.Forms.Cursors.Hand;
        navUser.Location = new System.Drawing.Point(12, 475);
        navUser.Name = "navUser";
        navUser.Size = new System.Drawing.Size(216, 44);
        navUser.TabIndex = 10;
        // 
        // navUserIcon
        // 
        navUserIcon.BackColor = System.Drawing.Color.Transparent;
        navUserIcon.Enabled = false;
        navUserIcon.IconColor = System.Drawing.Color.Black;
        navUserIcon.Location = new System.Drawing.Point(16, 12);
        navUserIcon.Name = "navUserIcon";
        navUserIcon.Size = new System.Drawing.Size(24, 24);
        navUserIcon.SvgPath = null;
        navUserIcon.TabIndex = 0;
        // 
        // navUserLabel
        // 
        navUserLabel.BackColor = System.Drawing.Color.Transparent;
        navUserLabel.Enabled = false;
        navUserLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navUserLabel.Location = new System.Drawing.Point(50, 0);
        navUserLabel.Name = "navUserLabel";
        navUserLabel.Size = new System.Drawing.Size(155, 44);
        navUserLabel.TabIndex = 1;
        navUserLabel.Text = "User";
        navUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // sidebarAdminLabel
        // 
        sidebarAdminLabel.BackColor = System.Drawing.Color.Transparent;
        sidebarAdminLabel.Font = new System.Drawing.Font("Bahnschrift", 8F, System.Drawing.FontStyle.Bold);
        sidebarAdminLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)165)), ((int)((byte)195)), ((int)((byte)235)));
        sidebarAdminLabel.Location = new System.Drawing.Point(12, 450);
        sidebarAdminLabel.Name = "sidebarAdminLabel";
        sidebarAdminLabel.Size = new System.Drawing.Size(216, 23);
        sidebarAdminLabel.TabIndex = 9;
        sidebarAdminLabel.Text = "ADMINISTRATION";
        // 
        // navCustomer
        // 
        navCustomer.BackColor = System.Drawing.Color.Transparent;
        navCustomer.Controls.Add(navCustomerIcon);
        navCustomer.Controls.Add(navCustomerLabel);
        navCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
        navCustomer.Location = new System.Drawing.Point(12, 385);
        navCustomer.Name = "navCustomer";
        navCustomer.Size = new System.Drawing.Size(216, 44);
        navCustomer.TabIndex = 8;
        // 
        // navCustomerIcon
        // 
        navCustomerIcon.BackColor = System.Drawing.Color.Transparent;
        navCustomerIcon.Enabled = false;
        navCustomerIcon.IconColor = System.Drawing.Color.Black;
        navCustomerIcon.Location = new System.Drawing.Point(16, 12);
        navCustomerIcon.Name = "navCustomerIcon";
        navCustomerIcon.Size = new System.Drawing.Size(24, 24);
        navCustomerIcon.SvgPath = null;
        navCustomerIcon.TabIndex = 0;
        // 
        // navCustomerLabel
        // 
        navCustomerLabel.BackColor = System.Drawing.Color.Transparent;
        navCustomerLabel.Enabled = false;
        navCustomerLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navCustomerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navCustomerLabel.Location = new System.Drawing.Point(50, 0);
        navCustomerLabel.Name = "navCustomerLabel";
        navCustomerLabel.Size = new System.Drawing.Size(155, 44);
        navCustomerLabel.TabIndex = 1;
        navCustomerLabel.Text = "Customer";
        navCustomerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // navSale
        // 
        navSale.BackColor = System.Drawing.Color.Transparent;
        navSale.Controls.Add(navSaleIcon);
        navSale.Controls.Add(navSaleLabel);
        navSale.Cursor = System.Windows.Forms.Cursors.Hand;
        navSale.Location = new System.Drawing.Point(12, 340);
        navSale.Name = "navSale";
        navSale.Size = new System.Drawing.Size(216, 44);
        navSale.TabIndex = 7;
        // 
        // navSaleIcon
        // 
        navSaleIcon.BackColor = System.Drawing.Color.Transparent;
        navSaleIcon.Enabled = false;
        navSaleIcon.IconColor = System.Drawing.Color.Black;
        navSaleIcon.Location = new System.Drawing.Point(16, 12);
        navSaleIcon.Name = "navSaleIcon";
        navSaleIcon.Size = new System.Drawing.Size(24, 24);
        navSaleIcon.SvgPath = null;
        navSaleIcon.TabIndex = 0;
        // 
        // navSaleLabel
        // 
        navSaleLabel.BackColor = System.Drawing.Color.Transparent;
        navSaleLabel.Enabled = false;
        navSaleLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navSaleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navSaleLabel.Location = new System.Drawing.Point(50, 0);
        navSaleLabel.Name = "navSaleLabel";
        navSaleLabel.Size = new System.Drawing.Size(155, 44);
        navSaleLabel.TabIndex = 1;
        navSaleLabel.Text = "Sale";
        navSaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // navInventory
        // 
        navInventory.BackColor = System.Drawing.Color.Transparent;
        navInventory.Controls.Add(navInventoryIcon);
        navInventory.Controls.Add(navInventoryLabel);
        navInventory.Cursor = System.Windows.Forms.Cursors.Hand;
        navInventory.Location = new System.Drawing.Point(12, 295);
        navInventory.Name = "navInventory";
        navInventory.Size = new System.Drawing.Size(216, 44);
        navInventory.TabIndex = 6;
        // 
        // navInventoryIcon
        // 
        navInventoryIcon.BackColor = System.Drawing.Color.Transparent;
        navInventoryIcon.Enabled = false;
        navInventoryIcon.IconColor = System.Drawing.Color.Black;
        navInventoryIcon.Location = new System.Drawing.Point(16, 12);
        navInventoryIcon.Name = "navInventoryIcon";
        navInventoryIcon.Size = new System.Drawing.Size(24, 24);
        navInventoryIcon.SvgPath = null;
        navInventoryIcon.TabIndex = 0;
        // 
        // navInventoryLabel
        // 
        navInventoryLabel.BackColor = System.Drawing.Color.Transparent;
        navInventoryLabel.Enabled = false;
        navInventoryLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navInventoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navInventoryLabel.Location = new System.Drawing.Point(50, 0);
        navInventoryLabel.Name = "navInventoryLabel";
        navInventoryLabel.Size = new System.Drawing.Size(155, 44);
        navInventoryLabel.TabIndex = 1;
        navInventoryLabel.Text = "Inventory";
        navInventoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // navCategory
        // 
        navCategory.BackColor = System.Drawing.Color.Transparent;
        navCategory.Controls.Add(navCategoryIcon);
        navCategory.Controls.Add(navCategoryLabel);
        navCategory.Cursor = System.Windows.Forms.Cursors.Hand;
        navCategory.Location = new System.Drawing.Point(12, 250);
        navCategory.Name = "navCategory";
        navCategory.Size = new System.Drawing.Size(216, 44);
        navCategory.TabIndex = 5;
        // 
        // navCategoryIcon
        // 
        navCategoryIcon.BackColor = System.Drawing.Color.Transparent;
        navCategoryIcon.Enabled = false;
        navCategoryIcon.IconColor = System.Drawing.Color.Black;
        navCategoryIcon.Location = new System.Drawing.Point(16, 12);
        navCategoryIcon.Name = "navCategoryIcon";
        navCategoryIcon.Size = new System.Drawing.Size(24, 24);
        navCategoryIcon.SvgPath = null;
        navCategoryIcon.TabIndex = 0;
        // 
        // navCategoryLabel
        // 
        navCategoryLabel.BackColor = System.Drawing.Color.Transparent;
        navCategoryLabel.Enabled = false;
        navCategoryLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navCategoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navCategoryLabel.Location = new System.Drawing.Point(50, 0);
        navCategoryLabel.Name = "navCategoryLabel";
        navCategoryLabel.Size = new System.Drawing.Size(155, 44);
        navCategoryLabel.TabIndex = 1;
        navCategoryLabel.Text = "Category";
        navCategoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // navProduct
        // 
        navProduct.BackColor = System.Drawing.Color.Transparent;
        navProduct.Controls.Add(navProductIcon);
        navProduct.Controls.Add(navProductLabel);
        navProduct.Cursor = System.Windows.Forms.Cursors.Hand;
        navProduct.Location = new System.Drawing.Point(12, 205);
        navProduct.Name = "navProduct";
        navProduct.Size = new System.Drawing.Size(216, 44);
        navProduct.TabIndex = 4;
        // 
        // navProductIcon
        // 
        navProductIcon.BackColor = System.Drawing.Color.Transparent;
        navProductIcon.Enabled = false;
        navProductIcon.IconColor = System.Drawing.Color.Black;
        navProductIcon.Location = new System.Drawing.Point(16, 12);
        navProductIcon.Name = "navProductIcon";
        navProductIcon.Size = new System.Drawing.Size(24, 24);
        navProductIcon.SvgPath = null;
        navProductIcon.TabIndex = 0;
        // 
        // navProductLabel
        // 
        navProductLabel.BackColor = System.Drawing.Color.Transparent;
        navProductLabel.Enabled = false;
        navProductLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navProductLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navProductLabel.Location = new System.Drawing.Point(50, 0);
        navProductLabel.Name = "navProductLabel";
        navProductLabel.Size = new System.Drawing.Size(155, 44);
        navProductLabel.TabIndex = 1;
        navProductLabel.Text = "Product";
        navProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // sidebarManagementLabel
        // 
        sidebarManagementLabel.BackColor = System.Drawing.Color.Transparent;
        sidebarManagementLabel.Font = new System.Drawing.Font("Bahnschrift", 8F, System.Drawing.FontStyle.Bold);
        sidebarManagementLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)165)), ((int)((byte)195)), ((int)((byte)235)));
        sidebarManagementLabel.Location = new System.Drawing.Point(12, 180);
        sidebarManagementLabel.Name = "sidebarManagementLabel";
        sidebarManagementLabel.Size = new System.Drawing.Size(216, 23);
        sidebarManagementLabel.TabIndex = 3;
        sidebarManagementLabel.Text = "MANAGEMENT";
        // 
        // sidebarHomeLabel
        // 
        sidebarHomeLabel.BackColor = System.Drawing.Color.Transparent;
        sidebarHomeLabel.Font = new System.Drawing.Font("Bahnschrift", 8F, System.Drawing.FontStyle.Bold);
        sidebarHomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)165)), ((int)((byte)195)), ((int)((byte)235)));
        sidebarHomeLabel.Location = new System.Drawing.Point(12, 90);
        sidebarHomeLabel.Name = "sidebarHomeLabel";
        sidebarHomeLabel.Size = new System.Drawing.Size(216, 23);
        sidebarHomeLabel.TabIndex = 2;
        sidebarHomeLabel.Text = "HOME";
        // 
        // navDashboard
        // 
        navDashboard.BackColor = System.Drawing.Color.Transparent;
        navDashboard.Controls.Add(navDashboardIcon);
        navDashboard.Controls.Add(navDashboardLabel);
        navDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
        navDashboard.Location = new System.Drawing.Point(12, 115);
        navDashboard.Name = "navDashboard";
        navDashboard.Size = new System.Drawing.Size(216, 44);
        navDashboard.TabIndex = 1;
        // 
        // navDashboardIcon
        // 
        navDashboardIcon.BackColor = System.Drawing.Color.Transparent;
        navDashboardIcon.Enabled = false;
        navDashboardIcon.IconColor = System.Drawing.Color.Black;
        navDashboardIcon.Location = new System.Drawing.Point(16, 12);
        navDashboardIcon.Name = "navDashboardIcon";
        navDashboardIcon.Size = new System.Drawing.Size(24, 24);
        navDashboardIcon.SvgPath = null;
        navDashboardIcon.TabIndex = 0;
        // 
        // navDashboardLabel
        // 
        navDashboardLabel.BackColor = System.Drawing.Color.Transparent;
        navDashboardLabel.Enabled = false;
        navDashboardLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        navDashboardLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)225)), ((int)((byte)255)));
        navDashboardLabel.Location = new System.Drawing.Point(50, 0);
        navDashboardLabel.Name = "navDashboardLabel";
        navDashboardLabel.Size = new System.Drawing.Size(155, 44);
        navDashboardLabel.TabIndex = 1;
        navDashboardLabel.Text = "Dashboard";
        navDashboardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // sidebarBorder
        // 
        sidebarBorder.BackColor = System.Drawing.Color.FromArgb(((int)((byte)70)), ((int)((byte)125)), ((int)((byte)220)));
        sidebarBorder.Dock = System.Windows.Forms.DockStyle.Right;
        sidebarBorder.Location = new System.Drawing.Point(239, 0);
        sidebarBorder.Name = "sidebarBorder";
        sidebarBorder.Size = new System.Drawing.Size(1, 903);
        sidebarBorder.TabIndex = 0;
        // 
        // logoPanel
        // 
        logoPanel.BackColor = System.Drawing.Color.Transparent;
        logoPanel.Controls.Add(logoLabel);
        logoPanel.Controls.Add(logoPictureBox);
        logoPanel.Location = new System.Drawing.Point(0, 0);
        logoPanel.Name = "logoPanel";
        logoPanel.Size = new System.Drawing.Size(240, 80);
        logoPanel.TabIndex = 0;
        // 
        // logoLabel
        // 
        logoLabel.AutoSize = true;
        logoLabel.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        logoLabel.ForeColor = System.Drawing.Color.White;
        logoLabel.Location = new System.Drawing.Point(58, 29);
        logoLabel.Name = "logoLabel";
        logoLabel.Size = new System.Drawing.Size(109, 28);
        logoLabel.TabIndex = 1;
        logoLabel.Text = "TechZone";
        // 
        // logoPictureBox
        // 
        logoPictureBox.BackColor = System.Drawing.Color.Transparent;
        logoPictureBox.BackgroundImage = global::TechZone.Resources.techzone_logo_white;
        logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        logoPictureBox.Location = new System.Drawing.Point(17, 22);
        logoPictureBox.Name = "logoPictureBox";
        logoPictureBox.Size = new System.Drawing.Size(35, 35);
        logoPictureBox.TabIndex = 0;
        logoPictureBox.TabStop = false;
        // 
        // mainPanel
        // 
        mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        mainPanel.Controls.Add(contentPanel);
        mainPanel.Controls.Add(topbarPanel);
        mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        mainPanel.Location = new System.Drawing.Point(240, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new System.Drawing.Size(1182, 903);
        mainPanel.TabIndex = 1;
        // 
        // contentPanel
        // 
        contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        contentPanel.Location = new System.Drawing.Point(0, 70);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new System.Drawing.Size(1182, 833);
        contentPanel.TabIndex = 1;
        // 
        // topbarPanel
        // 
        topbarPanel.BackColor = System.Drawing.Color.White;
        topbarPanel.Controls.Add(topbar);
        topbarPanel.Controls.Add(topbarBorder);
        topbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
        topbarPanel.Location = new System.Drawing.Point(0, 0);
        topbarPanel.Name = "topbarPanel";
        topbarPanel.Size = new System.Drawing.Size(1182, 70);
        topbarPanel.TabIndex = 0;
        // 
        // topbar
        // 
        topbar.BackColor = System.Drawing.Color.White;
        topbar.Dock = System.Windows.Forms.DockStyle.Fill;
        topbar.Location = new System.Drawing.Point(0, 0);
        topbar.Name = "topbar";
        topbar.Size = new System.Drawing.Size(1182, 69);
        topbar.TabIndex = 0;
        // 
        // topbarBorder
        // 
        topbarBorder.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        topbarBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
        topbarBorder.Location = new System.Drawing.Point(0, 69);
        topbarBorder.Name = "topbarBorder";
        topbarBorder.Size = new System.Drawing.Size(1182, 1);
        topbarBorder.TabIndex = 1;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        ClientSize = new System.Drawing.Size(1422, 903);
        Controls.Add(mainPanel);
        Controls.Add(sidebarPanel);
        MinimumSize = new System.Drawing.Size(1440, 950);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "TechZone";
        sidebarPanel.ResumeLayout(false);
        navSetting.ResumeLayout(false);
        navUser.ResumeLayout(false);
        navCustomer.ResumeLayout(false);
        navSale.ResumeLayout(false);
        navInventory.ResumeLayout(false);
        navCategory.ResumeLayout(false);
        navProduct.ResumeLayout(false);
        navDashboard.ResumeLayout(false);
        logoPanel.ResumeLayout(false);
        logoPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
        mainPanel.ResumeLayout(false);
        topbarPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label logoLabel;

    private System.Windows.Forms.Panel sidebarPanel;

    private System.Windows.Forms.Panel logoPanel;
    private System.Windows.Forms.PictureBox logoPictureBox;

    private Label sidebarHomeLabel;
    private Label sidebarManagementLabel;
    private Label sidebarAdminLabel;

    private Panel navDashboard;
    private TzIcon navDashboardIcon;

    private Panel navProduct;
    private TzIcon navProductIcon;

    private Panel navCategory;
    private TzIcon navCategoryIcon;

    private Panel navInventory;
    private TzIcon navInventoryIcon;

    private Panel navSale;
    private TzIcon navSaleIcon;

    private Panel navCustomer;
    private TzIcon navCustomerIcon;

    private Panel navUser;
    private TzIcon navUserIcon;

    private Panel navSetting;
    private TzIcon navSettingIcon;

    private Panel sidebarBorder;

    private Panel mainPanel;
    private Panel topbarPanel;
    private TechZone.UI.Components.Topbar topbar;
    private Panel topbarBorder;
    private System.Windows.Forms.Panel contentPanel;

    private TzNavLabel navDashboardLabel;
    private TzNavLabel navProductLabel;
    private TzNavLabel navCategoryLabel;
    private TzNavLabel navInventoryLabel;
    private TzNavLabel navSaleLabel;
    private TzNavLabel navCustomerLabel;
    private TzNavLabel navUserLabel;
    private TzNavLabel navSettingLabel;

    #endregion
}