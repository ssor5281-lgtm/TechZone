using System.Drawing;
using System.Windows.Forms;

namespace TechZone.UI.Views;

partial class SettingView
{
    private System.ComponentModel.IContainer components = null;
    
    private PictureBox appearanceIcon;
    private Label appearanceLabel;
    private Label appearanceDescription;
    private Label themeLabel;
    private ComboBox themeComboBox;
    private Label sidebarStyleLabel;
    private ComboBox sidebarStyleComboBox;

    private PictureBox saleIcon;
    private Label saleLabel;
    private Label saleDescription;
    private Label defaultDiscountLabel;
    private NumericUpDown defaultDiscountNumericUpDown;
    private CheckBox confirmQuickSaleCheckBox;
    private CheckBox confirmOrderCheckBox;

    private PictureBox inventoryIcon;
    private Label inventoryLabel;
    private Label inventoryDescription;
    private Label lowStockThresholdLabel;
    private NumericUpDown lowStockThresholdNumericUpDown;
    private CheckBox allowSellingWhenStockZeroCheckBox;

    private PictureBox systemIcon;
    private Label systemLabel;
    private Label systemDescription;
    private CheckBox rememberUsernameCheckBox;
    private CheckBox confirmLogoutCheckBox;
    private System.Windows.Forms.Button exportDatabaseButton;
    private Button importDatabaseButton;
    private Button resetDatabaseButton;

    private PictureBox aboutIcon;
    private Label aboutLabel;
    private Label aboutDescription;
    private Label applicationNameLabel;
    private Label versionLabel;
    private Label aboutTextLabel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        appearanceIcon = new System.Windows.Forms.PictureBox();
        appearanceLabel = new System.Windows.Forms.Label();
        appearanceDescription = new System.Windows.Forms.Label();
        themeLabel = new System.Windows.Forms.Label();
        themeComboBox = new System.Windows.Forms.ComboBox();
        sidebarStyleLabel = new System.Windows.Forms.Label();
        sidebarStyleComboBox = new System.Windows.Forms.ComboBox();
        saleIcon = new System.Windows.Forms.PictureBox();
        saleLabel = new System.Windows.Forms.Label();
        saleDescription = new System.Windows.Forms.Label();
        defaultDiscountLabel = new System.Windows.Forms.Label();
        defaultDiscountNumericUpDown = new System.Windows.Forms.NumericUpDown();
        confirmQuickSaleCheckBox = new System.Windows.Forms.CheckBox();
        confirmOrderCheckBox = new System.Windows.Forms.CheckBox();
        inventoryIcon = new System.Windows.Forms.PictureBox();
        inventoryLabel = new System.Windows.Forms.Label();
        inventoryDescription = new System.Windows.Forms.Label();
        lowStockThresholdLabel = new System.Windows.Forms.Label();
        lowStockThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
        allowSellingWhenStockZeroCheckBox = new System.Windows.Forms.CheckBox();
        systemIcon = new System.Windows.Forms.PictureBox();
        systemLabel = new System.Windows.Forms.Label();
        systemDescription = new System.Windows.Forms.Label();
        rememberUsernameCheckBox = new System.Windows.Forms.CheckBox();
        confirmLogoutCheckBox = new System.Windows.Forms.CheckBox();
        exportDatabaseButton = new System.Windows.Forms.Button();
        importDatabaseButton = new System.Windows.Forms.Button();
        resetDatabaseButton = new System.Windows.Forms.Button();
        aboutIcon = new System.Windows.Forms.PictureBox();
        aboutLabel = new System.Windows.Forms.Label();
        aboutDescription = new System.Windows.Forms.Label();
        applicationNameLabel = new System.Windows.Forms.Label();
        versionLabel = new System.Windows.Forms.Label();
        aboutTextLabel = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)appearanceIcon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)saleIcon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)defaultDiscountNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)inventoryIcon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)lowStockThresholdNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)systemIcon).BeginInit();
        ((System.ComponentModel.ISupportInitialize)aboutIcon).BeginInit();
        SuspendLayout();
        // 
        // appearanceIcon
        // 
        appearanceIcon.Image = global::TechZone.Resources.setting_theme;
        appearanceIcon.Location = new System.Drawing.Point(15, 15);
        appearanceIcon.Name = "appearanceIcon";
        appearanceIcon.Size = new System.Drawing.Size(35, 35);
        appearanceIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        appearanceIcon.TabIndex = 0;
        appearanceIcon.TabStop = false;
        // 
        // appearanceLabel
        // 
        appearanceLabel.AutoSize = true;
        appearanceLabel.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold);
        appearanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        appearanceLabel.Location = new System.Drawing.Point(55, 17);
        appearanceLabel.Name = "appearanceLabel";
        appearanceLabel.Size = new System.Drawing.Size(130, 27);
        appearanceLabel.TabIndex = 1;
        appearanceLabel.Text = "Appearance";
        // 
        // appearanceDescription
        // 
        appearanceDescription.AutoSize = true;
        appearanceDescription.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        appearanceDescription.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        appearanceDescription.Location = new System.Drawing.Point(15, 58);
        appearanceDescription.Name = "appearanceDescription";
        appearanceDescription.Size = new System.Drawing.Size(389, 19);
        appearanceDescription.TabIndex = 2;
        appearanceDescription.Text = "Customize the application theme and sidebar layout.";
        // 
        // themeLabel
        // 
        themeLabel.AutoSize = true;
        themeLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        themeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        themeLabel.Location = new System.Drawing.Point(55, 101);
        themeLabel.Name = "themeLabel";
        themeLabel.Size = new System.Drawing.Size(60, 21);
        themeLabel.TabIndex = 3;
        themeLabel.Text = "Theme";
        // 
        // themeComboBox
        // 
        themeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        themeComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        themeComboBox.Items.AddRange(new object[] { "Light", "Dark", "Royal Blue" });
        themeComboBox.Location = new System.Drawing.Point(55, 125);
        themeComboBox.Name = "themeComboBox";
        themeComboBox.Size = new System.Drawing.Size(220, 29);
        themeComboBox.TabIndex = 4;
        // 
        // sidebarStyleLabel
        // 
        sidebarStyleLabel.AutoSize = true;
        sidebarStyleLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        sidebarStyleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        sidebarStyleLabel.Location = new System.Drawing.Point(338, 101);
        sidebarStyleLabel.Name = "sidebarStyleLabel";
        sidebarStyleLabel.Size = new System.Drawing.Size(110, 21);
        sidebarStyleLabel.TabIndex = 5;
        sidebarStyleLabel.Text = "Sidebar Style";
        // 
        // sidebarStyleComboBox
        // 
        sidebarStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        sidebarStyleComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        sidebarStyleComboBox.Items.AddRange(new object[] { "Expanded", "Compact" });
        sidebarStyleComboBox.Location = new System.Drawing.Point(338, 125);
        sidebarStyleComboBox.Name = "sidebarStyleComboBox";
        sidebarStyleComboBox.Size = new System.Drawing.Size(220, 29);
        sidebarStyleComboBox.TabIndex = 6;
        // 
        // saleIcon
        // 
        saleIcon.Image = global::TechZone.Resources.setting_sale;
        saleIcon.Location = new System.Drawing.Point(15, 200);
        saleIcon.Name = "saleIcon";
        saleIcon.Size = new System.Drawing.Size(34, 34);
        saleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        saleIcon.TabIndex = 7;
        saleIcon.TabStop = false;
        // 
        // saleLabel
        // 
        saleLabel.AutoSize = true;
        saleLabel.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold);
        saleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        saleLabel.Location = new System.Drawing.Point(55, 202);
        saleLabel.Name = "saleLabel";
        saleLabel.Size = new System.Drawing.Size(56, 27);
        saleLabel.TabIndex = 8;
        saleLabel.Text = "Sale";
        // 
        // saleDescription
        // 
        saleDescription.AutoSize = true;
        saleDescription.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        saleDescription.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        saleDescription.Location = new System.Drawing.Point(15, 243);
        saleDescription.Name = "saleDescription";
        saleDescription.Size = new System.Drawing.Size(387, 19);
        saleDescription.TabIndex = 9;
        saleDescription.Text = "Configure default sales behavior and draft handling.";
        // 
        // defaultDiscountLabel
        // 
        defaultDiscountLabel.AutoSize = true;
        defaultDiscountLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        defaultDiscountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        defaultDiscountLabel.Location = new System.Drawing.Point(52, 285);
        defaultDiscountLabel.Name = "defaultDiscountLabel";
        defaultDiscountLabel.Size = new System.Drawing.Size(163, 21);
        defaultDiscountLabel.TabIndex = 10;
        defaultDiscountLabel.Text = "Default Discount (%)";
        // 
        // defaultDiscountNumericUpDown
        // 
        defaultDiscountNumericUpDown.DecimalPlaces = 2;
        defaultDiscountNumericUpDown.Font = new System.Drawing.Font("Bahnschrift", 10F);
        defaultDiscountNumericUpDown.Location = new System.Drawing.Point(55, 310);
        defaultDiscountNumericUpDown.Name = "defaultDiscountNumericUpDown";
        defaultDiscountNumericUpDown.Size = new System.Drawing.Size(150, 28);
        defaultDiscountNumericUpDown.TabIndex = 11;
        // 
        // confirmQuickSaleCheckBox
        // 
        confirmQuickSaleCheckBox.AutoSize = true;
        confirmQuickSaleCheckBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        confirmQuickSaleCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        confirmQuickSaleCheckBox.Location = new System.Drawing.Point(338, 311);
        confirmQuickSaleCheckBox.Name = "confirmQuickSaleCheckBox";
        confirmQuickSaleCheckBox.Size = new System.Drawing.Size(199, 25);
        confirmQuickSaleCheckBox.TabIndex = 12;
        confirmQuickSaleCheckBox.Text = "Confirm on Quick Sale";
        confirmQuickSaleCheckBox.CheckedChanged += ConfirmQuickSaleCheckBox_CheckedChanged;
        // 
        // confirmOrderCheckBox
        // 
        confirmOrderCheckBox.AutoSize = true;
        confirmOrderCheckBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        confirmOrderCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        confirmOrderCheckBox.Location = new System.Drawing.Point(338, 345);
        confirmOrderCheckBox.Name = "confirmOrderCheckBox";
        confirmOrderCheckBox.Size = new System.Drawing.Size(163, 25);
        confirmOrderCheckBox.TabIndex = 13;
        confirmOrderCheckBox.Text = "Confirm on Order";
        confirmOrderCheckBox.CheckedChanged += ConfirmOrderCheckBox_CheckedChanged;
        // 
        // inventoryIcon
        // 
        inventoryIcon.Image = global::TechZone.Resources.setting_inventory;
        inventoryIcon.Location = new System.Drawing.Point(15, 385);
        inventoryIcon.Name = "inventoryIcon";
        inventoryIcon.Size = new System.Drawing.Size(34, 34);
        inventoryIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        inventoryIcon.TabIndex = 14;
        inventoryIcon.TabStop = false;
        // 
        // inventoryLabel
        // 
        inventoryLabel.AutoSize = true;
        inventoryLabel.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold);
        inventoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        inventoryLabel.Location = new System.Drawing.Point(55, 387);
        inventoryLabel.Name = "inventoryLabel";
        inventoryLabel.Size = new System.Drawing.Size(104, 27);
        inventoryLabel.TabIndex = 15;
        inventoryLabel.Text = "Inventory";
        // 
        // inventoryDescription
        // 
        inventoryDescription.AutoSize = true;
        inventoryDescription.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        inventoryDescription.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        inventoryDescription.Location = new System.Drawing.Point(15, 428);
        inventoryDescription.Name = "inventoryDescription";
        inventoryDescription.Size = new System.Drawing.Size(475, 19);
        inventoryDescription.TabIndex = 16;
        inventoryDescription.Text = "Control stock warnings, selling limits, and deletion confirmation.";
        // 
        // lowStockThresholdLabel
        // 
        lowStockThresholdLabel.AutoSize = true;
        lowStockThresholdLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        lowStockThresholdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        lowStockThresholdLabel.Location = new System.Drawing.Point(51, 470);
        lowStockThresholdLabel.Name = "lowStockThresholdLabel";
        lowStockThresholdLabel.Size = new System.Drawing.Size(168, 21);
        lowStockThresholdLabel.TabIndex = 17;
        lowStockThresholdLabel.Text = "Low Stock Threshold";
        // 
        // lowStockThresholdNumericUpDown
        // 
        lowStockThresholdNumericUpDown.Font = new System.Drawing.Font("Bahnschrift", 10F);
        lowStockThresholdNumericUpDown.Location = new System.Drawing.Point(55, 495);
        lowStockThresholdNumericUpDown.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        lowStockThresholdNumericUpDown.Name = "lowStockThresholdNumericUpDown";
        lowStockThresholdNumericUpDown.Size = new System.Drawing.Size(150, 28);
        lowStockThresholdNumericUpDown.TabIndex = 18;
        lowStockThresholdNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
        lowStockThresholdNumericUpDown.ValueChanged += LowStockThresholdNumericUpDown_ValueChanged;
        // 
        // allowSellingWhenStockZeroCheckBox
        // 
        allowSellingWhenStockZeroCheckBox.AutoSize = true;
        allowSellingWhenStockZeroCheckBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        allowSellingWhenStockZeroCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        allowSellingWhenStockZeroCheckBox.Location = new System.Drawing.Point(338, 496);
        allowSellingWhenStockZeroCheckBox.Name = "allowSellingWhenStockZeroCheckBox";
        allowSellingWhenStockZeroCheckBox.Size = new System.Drawing.Size(331, 25);
        allowSellingWhenStockZeroCheckBox.TabIndex = 19;
        allowSellingWhenStockZeroCheckBox.Text = "Allow selling when product out of stock";
        allowSellingWhenStockZeroCheckBox.CheckedChanged += AllowSellingWhenStockZeroCheckBox_CheckedChanged;
        // 
        // systemIcon
        // 
        systemIcon.Image = global::TechZone.Resources.setting_database;
        systemIcon.Location = new System.Drawing.Point(15, 570);
        systemIcon.Name = "systemIcon";
        systemIcon.Size = new System.Drawing.Size(34, 34);
        systemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        systemIcon.TabIndex = 20;
        systemIcon.TabStop = false;
        // 
        // systemLabel
        // 
        systemLabel.AutoSize = true;
        systemLabel.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold);
        systemLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        systemLabel.Location = new System.Drawing.Point(55, 572);
        systemLabel.Name = "systemLabel";
        systemLabel.Size = new System.Drawing.Size(221, 27);
        systemLabel.TabIndex = 21;
        systemLabel.Text = "Sercurity && Database";
        // 
        // systemDescription
        // 
        systemDescription.AutoSize = true;
        systemDescription.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        systemDescription.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        systemDescription.Location = new System.Drawing.Point(15, 613);
        systemDescription.Name = "systemDescription";
        systemDescription.Size = new System.Drawing.Size(282, 19);
        systemDescription.TabIndex = 22;
        systemDescription.Text = "Manage general application behavior.";
        // 
        // rememberUsernameCheckBox
        // 
        rememberUsernameCheckBox.AutoSize = true;
        rememberUsernameCheckBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        rememberUsernameCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        rememberUsernameCheckBox.Location = new System.Drawing.Point(55, 655);
        rememberUsernameCheckBox.Name = "rememberUsernameCheckBox";
        rememberUsernameCheckBox.Size = new System.Drawing.Size(199, 25);
        rememberUsernameCheckBox.TabIndex = 23;
        rememberUsernameCheckBox.Text = "Remember Username";
        rememberUsernameCheckBox.CheckedChanged += RememberUsernameCheckBox_CheckedChanged;
        // 
        // confirmLogoutCheckBox
        // 
        confirmLogoutCheckBox.AutoSize = true;
        confirmLogoutCheckBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        confirmLogoutCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        confirmLogoutCheckBox.Location = new System.Drawing.Point(55, 696);
        confirmLogoutCheckBox.Name = "confirmLogoutCheckBox";
        confirmLogoutCheckBox.Size = new System.Drawing.Size(197, 25);
        confirmLogoutCheckBox.TabIndex = 24;
        confirmLogoutCheckBox.Text = "Confirm before logout";
        confirmLogoutCheckBox.CheckedChanged += ConfirmLogoutCheckBox_CheckedChanged;
        // 
        // exportDatabaseButton
        // 
        exportDatabaseButton.AutoSize = true;
        exportDatabaseButton.BackColor = System.Drawing.Color.RoyalBlue;
        exportDatabaseButton.FlatAppearance.BorderSize = 0;
        exportDatabaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        exportDatabaseButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold);
        exportDatabaseButton.ForeColor = System.Drawing.Color.White;
        exportDatabaseButton.Location = new System.Drawing.Point(55, 746);
        exportDatabaseButton.Name = "exportDatabaseButton";
        exportDatabaseButton.Size = new System.Drawing.Size(134, 30);
        exportDatabaseButton.TabIndex = 25;
        exportDatabaseButton.Text = "Backup Database";
        exportDatabaseButton.UseVisualStyleBackColor = false;
        // 
        // importDatabaseButton
        // 
        importDatabaseButton.BackColor = System.Drawing.Color.RoyalBlue;
        importDatabaseButton.FlatAppearance.BorderSize = 0;
        importDatabaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        importDatabaseButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold);
        importDatabaseButton.ForeColor = System.Drawing.Color.White;
        importDatabaseButton.Location = new System.Drawing.Point(198, 746);
        importDatabaseButton.Name = "importDatabaseButton";
        importDatabaseButton.Size = new System.Drawing.Size(127, 30);
        importDatabaseButton.TabIndex = 26;
        importDatabaseButton.Text = "Import Database";
        importDatabaseButton.UseVisualStyleBackColor = false;
        // 
        // resetDatabaseButton
        // 
        resetDatabaseButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)38)), ((int)((byte)38)));
        resetDatabaseButton.FlatAppearance.BorderSize = 0;
        resetDatabaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        resetDatabaseButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold);
        resetDatabaseButton.ForeColor = System.Drawing.Color.White;
        resetDatabaseButton.Location = new System.Drawing.Point(338, 746);
        resetDatabaseButton.Name = "resetDatabaseButton";
        resetDatabaseButton.Size = new System.Drawing.Size(127, 30);
        resetDatabaseButton.TabIndex = 27;
        resetDatabaseButton.Text = "Reset Database";
        resetDatabaseButton.UseVisualStyleBackColor = false;
        // 
        // aboutIcon
        // 
        aboutIcon.Image = global::TechZone.Resources.setting_info;
        aboutIcon.Location = new System.Drawing.Point(15, 835);
        aboutIcon.Name = "aboutIcon";
        aboutIcon.Size = new System.Drawing.Size(34, 34);
        aboutIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        aboutIcon.TabIndex = 28;
        aboutIcon.TabStop = false;
        // 
        // aboutLabel
        // 
        aboutLabel.AutoSize = true;
        aboutLabel.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold);
        aboutLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        aboutLabel.Location = new System.Drawing.Point(55, 837);
        aboutLabel.Name = "aboutLabel";
        aboutLabel.Size = new System.Drawing.Size(69, 27);
        aboutLabel.TabIndex = 29;
        aboutLabel.Text = "About";
        // 
        // aboutDescription
        // 
        aboutDescription.AutoSize = true;
        aboutDescription.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        aboutDescription.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        aboutDescription.Location = new System.Drawing.Point(15, 878);
        aboutDescription.Name = "aboutDescription";
        aboutDescription.Size = new System.Drawing.Size(324, 19);
        aboutDescription.TabIndex = 30;
        aboutDescription.Text = "Application information and version details.";
        // 
        // applicationNameLabel
        // 
        applicationNameLabel.AutoSize = true;
        applicationNameLabel.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold);
        applicationNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        applicationNameLabel.Location = new System.Drawing.Point(55, 918);
        applicationNameLabel.Name = "applicationNameLabel";
        applicationNameLabel.Size = new System.Drawing.Size(89, 23);
        applicationNameLabel.TabIndex = 31;
        applicationNameLabel.Text = "TechZone";
        // 
        // versionLabel
        // 
        versionLabel.AutoSize = true;
        versionLabel.Font = new System.Drawing.Font("Bahnschrift", 10F);
        versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        versionLabel.Location = new System.Drawing.Point(55, 948);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new System.Drawing.Size(103, 21);
        versionLabel.TabIndex = 32;
        versionLabel.Text = "Version 1.0.0";
        // 
        // aboutTextLabel
        // 
        aboutTextLabel.AutoSize = true;
        aboutTextLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        aboutTextLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        aboutTextLabel.Location = new System.Drawing.Point(55, 978);
        aboutTextLabel.Name = "aboutTextLabel";
        aboutTextLabel.Size = new System.Drawing.Size(491, 19);
        aboutTextLabel.TabIndex = 33;
        aboutTextLabel.Text = "Inventory, sales, customer, product and user management system.";
        // 
        // SettingView
        // 
        AutoScroll = true;
        AutoScrollMinSize = new System.Drawing.Size(0, 1020);
        AutoValidate = System.Windows.Forms.AutoValidate.Disable;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        Controls.Add(confirmOrderCheckBox);
        Controls.Add(appearanceIcon);
        Controls.Add(appearanceLabel);
        Controls.Add(appearanceDescription);
        Controls.Add(themeLabel);
        Controls.Add(themeComboBox);
        Controls.Add(sidebarStyleLabel);
        Controls.Add(sidebarStyleComboBox);
        Controls.Add(saleIcon);
        Controls.Add(saleLabel);
        Controls.Add(saleDescription);
        Controls.Add(defaultDiscountLabel);
        Controls.Add(defaultDiscountNumericUpDown);
        Controls.Add(confirmQuickSaleCheckBox);
        Controls.Add(inventoryIcon);
        Controls.Add(inventoryLabel);
        Controls.Add(inventoryDescription);
        Controls.Add(lowStockThresholdLabel);
        Controls.Add(lowStockThresholdNumericUpDown);
        Controls.Add(allowSellingWhenStockZeroCheckBox);
        Controls.Add(systemIcon);
        Controls.Add(systemLabel);
        Controls.Add(systemDescription);
        Controls.Add(rememberUsernameCheckBox);
        Controls.Add(confirmLogoutCheckBox);
        Controls.Add(exportDatabaseButton);
        Controls.Add(importDatabaseButton);
        Controls.Add(resetDatabaseButton);
        Controls.Add(aboutIcon);
        Controls.Add(aboutLabel);
        Controls.Add(aboutDescription);
        Controls.Add(applicationNameLabel);
        Controls.Add(versionLabel);
        Controls.Add(aboutTextLabel);
        Font = new System.Drawing.Font("Bahnschrift", 10F);
        Margin = new System.Windows.Forms.Padding(0);
        Size = new System.Drawing.Size(930, 833);
        ((System.ComponentModel.ISupportInitialize)appearanceIcon).EndInit();
        ((System.ComponentModel.ISupportInitialize)saleIcon).EndInit();
        ((System.ComponentModel.ISupportInitialize)defaultDiscountNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)inventoryIcon).EndInit();
        ((System.ComponentModel.ISupportInitialize)lowStockThresholdNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)systemIcon).EndInit();
        ((System.ComponentModel.ISupportInitialize)aboutIcon).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}