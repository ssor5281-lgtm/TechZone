using System.ComponentModel;

namespace TechZone.UI.Forms.Create;

partial class AddOrderForm
{
    private IContainer components = null!;

    private System.Windows.Forms.Label customerLabel;
    private System.Windows.Forms.ComboBox customerComboBox;
    private System.Windows.Forms.Button addCustomerButton;

    private System.Windows.Forms.Label staffLabel;
    private System.Windows.Forms.ComboBox staffComboBox;

    private System.Windows.Forms.Label pickupDateLabel;
    private System.Windows.Forms.DateTimePicker pickupDatePicker;

    private System.Windows.Forms.Label productLabel;
    private System.Windows.Forms.TextBox searchProductTextBox;
    private System.Windows.Forms.Button addToCartButton;
    private TechZone.UI.Components.DataTable productTable;

    private TechZone.UI.Components.DataTable DataTable = null!;

    private System.Windows.Forms.Panel totalPanel;
    private System.Windows.Forms.Label subtotalLabel;
    private System.Windows.Forms.Label subtotalValueLabel;
    private System.Windows.Forms.Label discountLabel;
    private System.Windows.Forms.Label discountValueLabel;
    private System.Windows.Forms.Label totalLabel;
    private System.Windows.Forms.Label totalValueLabel;

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button saveOrderButton;

    private TechZone.UI.Components.DataTablePagination dataTablePagination1;
    private System.Windows.Forms.Button removeButton;

    private System.Windows.Forms.Label discountLbl;
    private System.Windows.Forms.TextBox discountTextBox;
    private System.Windows.Forms.Button calculateDiscountButton;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label orderNumberLabel;

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
        customerLabel = new System.Windows.Forms.Label();
        customerComboBox = new System.Windows.Forms.ComboBox();
        addCustomerButton = new System.Windows.Forms.Button();
        staffLabel = new System.Windows.Forms.Label();
        staffComboBox = new System.Windows.Forms.ComboBox();
        pickupDateLabel = new System.Windows.Forms.Label();
        pickupDatePicker = new System.Windows.Forms.DateTimePicker();
        productLabel = new System.Windows.Forms.Label();
        searchProductTextBox = new System.Windows.Forms.TextBox();
        addToCartButton = new System.Windows.Forms.Button();
        productTable = new TechZone.UI.Components.DataTable();
        DataTable = new TechZone.UI.Components.DataTable();
        totalPanel = new System.Windows.Forms.Panel();
        subtotalLabel = new System.Windows.Forms.Label();
        subtotalValueLabel = new System.Windows.Forms.Label();
        discountLabel = new System.Windows.Forms.Label();
        discountValueLabel = new System.Windows.Forms.Label();
        totalLabel = new System.Windows.Forms.Label();
        totalValueLabel = new System.Windows.Forms.Label();
        cancelButton = new System.Windows.Forms.Button();
        saveOrderButton = new System.Windows.Forms.Button();
        dataTablePagination1 = new TechZone.UI.Components.DataTablePagination();
        removeButton = new System.Windows.Forms.Button();
        discountLbl = new System.Windows.Forms.Label();
        discountTextBox = new System.Windows.Forms.TextBox();
        calculateDiscountButton = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        orderNumberLabel = new System.Windows.Forms.Label();
        totalPanel.SuspendLayout();
        SuspendLayout();
        // 
        // customerLabel
        // 
        customerLabel.AutoSize = true;
        customerLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
        customerLabel.Location = new System.Drawing.Point(23, 22);
        customerLabel.Name = "customerLabel";
        customerLabel.Size = new System.Drawing.Size(85, 21);
        customerLabel.TabIndex = 7;
        customerLabel.Text = "Customer";
        // 
        // customerComboBox
        // 
        customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        customerComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        customerComboBox.Location = new System.Drawing.Point(23, 46);
        customerComboBox.Name = "customerComboBox";
        customerComboBox.Size = new System.Drawing.Size(200, 29);
        customerComboBox.TabIndex = 6;
        // 
        // addCustomerButton
        // 
        addCustomerButton.BackColor = System.Drawing.Color.RoyalBlue;
        addCustomerButton.Cursor = System.Windows.Forms.Cursors.Hand;
        addCustomerButton.FlatAppearance.BorderSize = 0;
        addCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        addCustomerButton.Image = global::TechZone.Resources.icon_add_customer;
        addCustomerButton.Location = new System.Drawing.Point(229, 46);
        addCustomerButton.Name = "addCustomerButton";
        addCustomerButton.Size = new System.Drawing.Size(48, 29);
        addCustomerButton.TabIndex = 5;
        addCustomerButton.UseVisualStyleBackColor = false;
        // 
        // staffLabel
        // 
        staffLabel.AutoSize = true;
        staffLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
        staffLabel.Location = new System.Drawing.Point(317, 22);
        staffLabel.Name = "staffLabel";
        staffLabel.Size = new System.Drawing.Size(45, 21);
        staffLabel.TabIndex = 4;
        staffLabel.Text = "Staff";
        // 
        // staffComboBox
        // 
        staffComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        staffComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        staffComboBox.Location = new System.Drawing.Point(317, 46);
        staffComboBox.Name = "staffComboBox";
        staffComboBox.Size = new System.Drawing.Size(256, 29);
        staffComboBox.TabIndex = 3;
        // 
        // pickupDateLabel
        // 
        pickupDateLabel.AutoSize = true;
        pickupDateLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
        pickupDateLabel.Location = new System.Drawing.Point(603, 24);
        pickupDateLabel.Name = "pickupDateLabel";
        pickupDateLabel.Size = new System.Drawing.Size(100, 21);
        pickupDateLabel.TabIndex = 2;
        pickupDateLabel.Text = "Pickup Date";
        // 
        // pickupDatePicker
        // 
        pickupDatePicker.CustomFormat = "dd MMM yyyy";
        pickupDatePicker.Font = new System.Drawing.Font("Bahnschrift", 10F);
        pickupDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        pickupDatePicker.Location = new System.Drawing.Point(603, 48);
        pickupDatePicker.Name = "pickupDatePicker";
        pickupDatePicker.Size = new System.Drawing.Size(260, 28);
        pickupDatePicker.TabIndex = 1;
        // 
        // productLabel
        // 
        productLabel.AutoSize = true;
        productLabel.Font = new System.Drawing.Font("Bahnschrift", 10.8F);
        productLabel.Location = new System.Drawing.Point(23, 117);
        productLabel.Name = "productLabel";
        productLabel.Size = new System.Drawing.Size(83, 22);
        productLabel.TabIndex = 23;
        productLabel.Text = "Products";
        // 
        // searchProductTextBox
        // 
        searchProductTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        searchProductTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        searchProductTextBox.Location = new System.Drawing.Point(23, 142);
        searchProductTextBox.Name = "searchProductTextBox";
        searchProductTextBox.PlaceholderText = " search product...";
        searchProductTextBox.Size = new System.Drawing.Size(494, 28);
        searchProductTextBox.TabIndex = 22;
        // 
        // addToCartButton
        // 
        addToCartButton.BackColor = System.Drawing.Color.RoyalBlue;
        addToCartButton.Cursor = System.Windows.Forms.Cursors.Hand;
        addToCartButton.FlatAppearance.BorderSize = 0;
        addToCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        addToCartButton.Image = global::TechZone.Resources.icon_arrow;
        addToCartButton.Location = new System.Drawing.Point(523, 141);
        addToCartButton.Name = "addToCartButton";
        addToCartButton.Size = new System.Drawing.Size(50, 28);
        addToCartButton.TabIndex = 21;
        addToCartButton.UseVisualStyleBackColor = false;
        // 
        // productTable
        // 
        productTable.BackColor = System.Drawing.Color.White;
        productTable.DataSource = null;
        productTable.FontSize = 9.5F;
        productTable.Location = new System.Drawing.Point(23, 172);
        productTable.Margin = new System.Windows.Forms.Padding(0);
        productTable.Name = "productTable";
        productTable.NumberStart = 1;
        productTable.Size = new System.Drawing.Size(550, 398);
        productTable.TabIndex = 20;
        // 
        // cartTable
        // 
        DataTable.BackColor = System.Drawing.Color.White;
        DataTable.DataSource = null;
        DataTable.FontSize = 9.5F;
        DataTable.Location = new System.Drawing.Point(603, 79);
        DataTable.Margin = new System.Windows.Forms.Padding(0);
        DataTable.Name = "DataTable";
        DataTable.NumberStart = 1;
        DataTable.Size = new System.Drawing.Size(659, 277);
        DataTable.TabIndex = 19;
        // 
        // totalPanel
        // 
        totalPanel.BackColor = System.Drawing.Color.White;
        totalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        totalPanel.Controls.Add(subtotalLabel);
        totalPanel.Controls.Add(subtotalValueLabel);
        totalPanel.Controls.Add(discountLabel);
        totalPanel.Controls.Add(discountValueLabel);
        totalPanel.Controls.Add(totalLabel);
        totalPanel.Controls.Add(totalValueLabel);
        totalPanel.Location = new System.Drawing.Point(603, 425);
        totalPanel.Name = "totalPanel";
        totalPanel.Size = new System.Drawing.Size(659, 146);
        totalPanel.TabIndex = 18;
        // 
        // subtotalLabel
        // 
        subtotalLabel.AutoSize = true;
        subtotalLabel.Font = new System.Drawing.Font("Bahnschrift", 10F);
        subtotalLabel.Location = new System.Drawing.Point(20, 17);
        subtotalLabel.Name = "subtotalLabel";
        subtotalLabel.Size = new System.Drawing.Size(73, 21);
        subtotalLabel.TabIndex = 0;
        subtotalLabel.Text = "Subtotal";
        // 
        // subtotalValueLabel
        // 
        subtotalValueLabel.Font = new System.Drawing.Font("Bahnschrift", 10F);
        subtotalValueLabel.Location = new System.Drawing.Point(470, 17);
        subtotalValueLabel.Name = "subtotalValueLabel";
        subtotalValueLabel.Size = new System.Drawing.Size(165, 21);
        subtotalValueLabel.TabIndex = 1;
        subtotalValueLabel.Text = "$0.00";
        subtotalValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // discountLabel
        // 
        discountLabel.AutoSize = true;
        discountLabel.Font = new System.Drawing.Font("Bahnschrift", 10F);
        discountLabel.Location = new System.Drawing.Point(20, 50);
        discountLabel.Name = "discountLabel";
        discountLabel.Size = new System.Drawing.Size(75, 21);
        discountLabel.TabIndex = 2;
        discountLabel.Text = "Discount";
        // 
        // discountValueLabel
        // 
        discountValueLabel.Font = new System.Drawing.Font("Bahnschrift", 10F);
        discountValueLabel.Location = new System.Drawing.Point(470, 50);
        discountValueLabel.Name = "discountValueLabel";
        discountValueLabel.Size = new System.Drawing.Size(165, 21);
        discountValueLabel.TabIndex = 3;
        discountValueLabel.Text = "$0.00";
        discountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // totalLabel
        // 
        totalLabel.AutoSize = true;
        totalLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
        totalLabel.Location = new System.Drawing.Point(20, 91);
        totalLabel.Name = "totalLabel";
        totalLabel.Size = new System.Drawing.Size(54, 24);
        totalLabel.TabIndex = 4;
        totalLabel.Text = "Total";
        // 
        // totalValueLabel
        // 
        totalValueLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
        totalValueLabel.Location = new System.Drawing.Point(450, 88);
        totalValueLabel.Name = "totalValueLabel";
        totalValueLabel.Size = new System.Drawing.Size(185, 27);
        totalValueLabel.TabIndex = 5;
        totalValueLabel.Text = "$0.00";
        totalValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cancelButton
        // 
        cancelButton.BackColor = System.Drawing.Color.White;
        cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
        cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
        cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
        cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        cancelButton.Location = new System.Drawing.Point(1017, 590);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 40);
        cancelButton.TabIndex = 17;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        // 
        // saveOrderButton
        // 
        saveOrderButton.BackColor = System.Drawing.Color.RoyalBlue;
        saveOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
        saveOrderButton.FlatAppearance.BorderSize = 0;
        saveOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saveOrderButton.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        saveOrderButton.ForeColor = System.Drawing.Color.White;
        saveOrderButton.Location = new System.Drawing.Point(1137, 590);
        saveOrderButton.Name = "saveOrderButton";
        saveOrderButton.Size = new System.Drawing.Size(125, 40);
        saveOrderButton.TabIndex = 11;
        saveOrderButton.Text = "Save Order";
        saveOrderButton.UseVisualStyleBackColor = false;
        // 
        // dataTablePagination1
        // 
        dataTablePagination1.BackColor = System.Drawing.Color.Transparent;
        dataTablePagination1.Location = new System.Drawing.Point(23, 586);
        dataTablePagination1.Margin = new System.Windows.Forms.Padding(0);
        dataTablePagination1.MaximumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.MinimumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.Name = "dataTablePagination1";
        dataTablePagination1.Size = new System.Drawing.Size(400, 44);
        dataTablePagination1.TabIndex = 16;
        // 
        // removeButton
        // 
        removeButton.BackColor = System.Drawing.Color.Crimson;
        removeButton.Cursor = System.Windows.Forms.Cursors.Hand;
        removeButton.FlatAppearance.BorderSize = 0;
        removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        removeButton.Image = global::TechZone.Resources.icon_remove_cart;
        removeButton.Location = new System.Drawing.Point(1212, 45);
        removeButton.Name = "removeButton";
        removeButton.Size = new System.Drawing.Size(50, 28);
        removeButton.TabIndex = 15;
        removeButton.UseVisualStyleBackColor = false;
        // 
        // discountLbl
        // 
        discountLbl.AutoSize = true;
        discountLbl.Font = new System.Drawing.Font("Bahnschrift", 10.8F);
        discountLbl.Location = new System.Drawing.Point(603, 392);
        discountLbl.Name = "discountLbl";
        discountLbl.Size = new System.Drawing.Size(98, 22);
        discountLbl.TabIndex = 14;
        discountLbl.Text = "Discount %";
        // 
        // discountTextBox
        // 
        discountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        discountTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
        discountTextBox.Location = new System.Drawing.Point(707, 389);
        discountTextBox.Name = "discountTextBox";
        discountTextBox.PlaceholderText = "0.0";
        discountTextBox.Size = new System.Drawing.Size(100, 28);
        discountTextBox.TabIndex = 13;
        discountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // calculateDiscountButton
        // 
        calculateDiscountButton.BackColor = System.Drawing.Color.RoyalBlue;
        calculateDiscountButton.Cursor = System.Windows.Forms.Cursors.Hand;
        calculateDiscountButton.FlatAppearance.BorderSize = 0;
        calculateDiscountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        calculateDiscountButton.Image = global::TechZone.Resources.icon_arrow;
        calculateDiscountButton.Location = new System.Drawing.Point(813, 389);
        calculateDiscountButton.Name = "calculateDiscountButton";
        calculateDiscountButton.Size = new System.Drawing.Size(50, 28);
        calculateDiscountButton.TabIndex = 12;
        calculateDiscountButton.UseVisualStyleBackColor = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
        label1.ForeColor = System.Drawing.SystemColors.ControlDark;
        label1.Location = new System.Drawing.Point(23, 90);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(389, 18);
        label1.TabIndex = 10;
        label1.Text = "> Select a product, then click → button to add it to the cart.";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
        label3.ForeColor = System.Drawing.SystemColors.ControlDark;
        label3.Location = new System.Drawing.Point(603, 365);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(593, 18);
        label3.TabIndex = 8;
        label3.Text = ("> Enter a discount percentage, then click → to calculate the discount and update " + "the total.");
        // 
        // orderNumberLabel
        // 
        orderNumberLabel.AutoSize = true;
        orderNumberLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        orderNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        orderNumberLabel.Location = new System.Drawing.Point(1180, 22);
        orderNumberLabel.Name = "orderNumberLabel";
        orderNumberLabel.Size = new System.Drawing.Size(82, 18);
        orderNumberLabel.TabIndex = 0;
        orderNumberLabel.Text = "ORD-00001";
        orderNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // AddOrderForm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(1285, 650);
        Controls.Add(orderNumberLabel);
        Controls.Add(pickupDatePicker);
        Controls.Add(pickupDateLabel);
        Controls.Add(staffComboBox);
        Controls.Add(staffLabel);
        Controls.Add(addCustomerButton);
        Controls.Add(customerComboBox);
        Controls.Add(customerLabel);
        Controls.Add(label3);
        Controls.Add(label1);
        Controls.Add(saveOrderButton);
        Controls.Add(calculateDiscountButton);
        Controls.Add(discountTextBox);
        Controls.Add(discountLbl);
        Controls.Add(removeButton);
        Controls.Add(dataTablePagination1);
        Controls.Add(cancelButton);
        Controls.Add(totalPanel);
        Controls.Add(DataTable);
        Controls.Add(productTable);
        Controls.Add(addToCartButton);
        Controls.Add(searchProductTextBox);
        Controls.Add(productLabel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "New Order";
        totalPanel.ResumeLayout(false);
        totalPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}