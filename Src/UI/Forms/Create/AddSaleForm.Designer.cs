using System.ComponentModel;

namespace TechZone.UI.Forms.Create;

partial class AddSaleForm
{
private IContainer components = null!;

private System.Windows.Forms.Label customerLabel;
private System.Windows.Forms.ComboBox customerComboBox;
private System.Windows.Forms.Button addCustomerButton;

private System.Windows.Forms.Label productLabel;
private System.Windows.Forms.TextBox searchProductTextBox;
private System.Windows.Forms.Button addToCartButton;
private TechZone.UI.Components.DataTable productTable;

private TechZone.UI.Components.DataTable cartTable;

private Panel totalPanel = null!;
private Label subtotalLabel = null!;
private Label subtotalValueLabel = null!;
private System.Windows.Forms.Label discountLabel;
private System.Windows.Forms.Label discountValueLabel;
private Label totalLabel = null!;
private Label totalValueLabel = null!;

private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Button saveSaleButton;

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
    productLabel = new System.Windows.Forms.Label();
    searchProductTextBox = new System.Windows.Forms.TextBox();
    addToCartButton = new System.Windows.Forms.Button();
    productTable = new TechZone.UI.Components.DataTable();
    cartTable = new TechZone.UI.Components.DataTable();
    totalPanel = new System.Windows.Forms.Panel();
    subtotalLabel = new System.Windows.Forms.Label();
    subtotalValueLabel = new System.Windows.Forms.Label();
    discountLabel = new System.Windows.Forms.Label();
    discountValueLabel = new System.Windows.Forms.Label();
    totalLabel = new System.Windows.Forms.Label();
    totalValueLabel = new System.Windows.Forms.Label();
    cancelButton = new System.Windows.Forms.Button();
    saveSaleButton = new System.Windows.Forms.Button();
    dataTablePagination1 = new TechZone.UI.Components.DataTablePagination();
    removeButton = new System.Windows.Forms.Button();
    searchCartTextBox = new System.Windows.Forms.TextBox();
    discountLbl = new System.Windows.Forms.Label();
    discountTextBox = new System.Windows.Forms.TextBox();
    calculateDiscountButton = new System.Windows.Forms.Button();
    staffLabel = new System.Windows.Forms.Label();
    staffComboBox = new System.Windows.Forms.ComboBox();
    label1 = new System.Windows.Forms.Label();
    label2 = new System.Windows.Forms.Label();
    label3 = new System.Windows.Forms.Label();
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
    customerLabel.TabIndex = 0;
    customerLabel.Text = "Customer";
    // 
    // customerComboBox
    // 
    customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    customerComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    customerComboBox.Location = new System.Drawing.Point(23, 46);
    customerComboBox.Name = "customerComboBox";
    customerComboBox.Size = new System.Drawing.Size(200, 29);
    customerComboBox.TabIndex = 1;
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
    addCustomerButton.TabIndex = 2;
    addCustomerButton.UseVisualStyleBackColor = false;
    // 
    // productLabel
    // 
    productLabel.AutoSize = true;
    productLabel.Font = new System.Drawing.Font("Bahnschrift", 10.8F);
    productLabel.Location = new System.Drawing.Point(23, 117);
    productLabel.Name = "productLabel";
    productLabel.Size = new System.Drawing.Size(83, 22);
    productLabel.TabIndex = 3;
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
    searchProductTextBox.TabIndex = 4;
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
    addToCartButton.TabIndex = 5;
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
    productTable.TabIndex = 6;
    // 
    // cartTable
    // 
    cartTable.BackColor = System.Drawing.Color.White;
    cartTable.DataSource = null;
    cartTable.FontSize = 9.5F;
    cartTable.Location = new System.Drawing.Point(603, 79);
    cartTable.Margin = new System.Windows.Forms.Padding(0);
    cartTable.Name = "cartTable";
    cartTable.NumberStart = 1;
    cartTable.Size = new System.Drawing.Size(659, 277);
    cartTable.TabIndex = 8;
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
    totalPanel.TabIndex = 9;
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
    cancelButton.Location = new System.Drawing.Point(1024, 590);
    cancelButton.Name = "cancelButton";
    cancelButton.Size = new System.Drawing.Size(100, 40);
    cancelButton.TabIndex = 10;
    cancelButton.Text = "Cancel";
    cancelButton.UseVisualStyleBackColor = false;
    // 
    // saveSaleButton
    // 
    saveSaleButton.BackColor = System.Drawing.Color.RoyalBlue;
    saveSaleButton.Cursor = System.Windows.Forms.Cursors.Hand;
    saveSaleButton.FlatAppearance.BorderSize = 0;
    saveSaleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    saveSaleButton.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
    saveSaleButton.ForeColor = System.Drawing.Color.White;
    saveSaleButton.Location = new System.Drawing.Point(1137, 590);
    saveSaleButton.Margin = new System.Windows.Forms.Padding(10);
    saveSaleButton.Name = "saveSaleButton";
    saveSaleButton.Size = new System.Drawing.Size(125, 40);
    saveSaleButton.TabIndex = 11;
    saveSaleButton.Text = "Add to Sale";
    saveSaleButton.UseVisualStyleBackColor = false;
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
    dataTablePagination1.TabIndex = 12;
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
    removeButton.TabIndex = 13;
    removeButton.UseVisualStyleBackColor = false;
    // 
    // searchCartTextBox
    // 
    searchCartTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    searchCartTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    searchCartTextBox.Location = new System.Drawing.Point(603, 46);
    searchCartTextBox.Name = "searchCartTextBox";
    searchCartTextBox.PlaceholderText = " search cart...";
    searchCartTextBox.Size = new System.Drawing.Size(603, 28);
    searchCartTextBox.TabIndex = 14;
    // 
    // discountLbl
    // 
    discountLbl.AutoSize = true;
    discountLbl.Font = new System.Drawing.Font("Bahnschrift", 10.8F);
    discountLbl.Location = new System.Drawing.Point(603, 392);
    discountLbl.Name = "discountLbl";
    discountLbl.Size = new System.Drawing.Size(98, 22);
    discountLbl.TabIndex = 15;
    discountLbl.Text = "Discount %";
    // 
    // discountTextBox
    // 
    discountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    discountTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
    discountTextBox.Location = new System.Drawing.Point(707, 389);
    discountTextBox.Name = "discountTextBox";
    discountTextBox.PlaceholderText = "0.0";
    discountTextBox.Size = new System.Drawing.Size(100, 28);
    discountTextBox.TabIndex = 16;
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
    calculateDiscountButton.TabIndex = 17;
    calculateDiscountButton.UseVisualStyleBackColor = false;
    // 
    // staffLabel
    // 
    staffLabel.AutoSize = true;
    staffLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
    staffLabel.Location = new System.Drawing.Point(317, 23);
    staffLabel.Name = "staffLabel";
    staffLabel.Size = new System.Drawing.Size(45, 21);
    staffLabel.TabIndex = 19;
    staffLabel.Text = "Staff";
    // 
    // staffComboBox
    // 
    staffComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    staffComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    staffComboBox.Location = new System.Drawing.Point(317, 47);
    staffComboBox.Name = "staffComboBox";
    staffComboBox.Size = new System.Drawing.Size(256, 29);
    staffComboBox.TabIndex = 20;
    // 
    // label1
    // 
    label1.AutoSize = true;
    label1.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
    label1.ForeColor = System.Drawing.SystemColors.ControlDark;
    label1.Location = new System.Drawing.Point(23, 90);
    label1.Name = "label1";
    label1.Size = new System.Drawing.Size(389, 18);
    label1.TabIndex = 21;
    label1.Text = "> Select a product, then click → button to add it to the cart.";
    // 
    // label2
    // 
    label2.AutoSize = true;
    label2.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
    label2.ForeColor = System.Drawing.SystemColors.ControlDark;
    label2.Location = new System.Drawing.Point(603, 26);
    label2.Name = "label2";
    label2.Size = new System.Drawing.Size(536, 18);
    label2.TabIndex = 22;
    label2.Text = "> Review the products added to your cart and modify their quantities as needed.";
    // 
    // label3
    // 
    label3.AutoSize = true;
    label3.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
    label3.ForeColor = System.Drawing.SystemColors.ControlDark;
    label3.Location = new System.Drawing.Point(603, 365);
    label3.Name = "label3";
    label3.Size = new System.Drawing.Size(593, 18);
    label3.TabIndex = 23;
    label3.Text = ("> Enter a discount percentage, then click → to calculate the discount and update " + "the total.");
    // 
    // AddSaleForm
    // 
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
    BackColor = System.Drawing.Color.White;
    ClientSize = new System.Drawing.Size(1285, 650);
    Controls.Add(label3);
    Controls.Add(label2);
    Controls.Add(label1);
    Controls.Add(staffComboBox);
    Controls.Add(staffLabel);
    Controls.Add(addCustomerButton);
    Controls.Add(customerComboBox);
    Controls.Add(customerLabel);
    Controls.Add(calculateDiscountButton);
    Controls.Add(discountTextBox);
    Controls.Add(discountLbl);
    Controls.Add(searchCartTextBox);
    Controls.Add(removeButton);
    Controls.Add(dataTablePagination1);
    Controls.Add(cancelButton);
    Controls.Add(saveSaleButton);
    Controls.Add(totalPanel);
    Controls.Add(cartTable);
    Controls.Add(productTable);
    Controls.Add(addToCartButton);
    Controls.Add(searchProductTextBox);
    Controls.Add(productLabel);
    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
    MaximizeBox = false;
    MinimizeBox = false;
    ShowInTaskbar = false;
    StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    Text = "New Sale";
    totalPanel.ResumeLayout(false);
    totalPanel.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
}

private System.Windows.Forms.Label label3;

private System.Windows.Forms.Label label2;

private System.Windows.Forms.Label label1;

private System.Windows.Forms.Label staffLabel;
private System.Windows.Forms.ComboBox staffComboBox;

private System.Windows.Forms.Button calculateDiscountButton;

private System.Windows.Forms.TextBox discountTextBox;

private System.Windows.Forms.Label discountLbl;

private System.Windows.Forms.Button removeButton;
private System.Windows.Forms.TextBox searchCartTextBox;

private TechZone.UI.Components.DataTablePagination dataTablePagination1;
}
