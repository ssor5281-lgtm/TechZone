using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Forms.Create;

partial class AddQuickSaleForm
{
    private IContainer components = null!;

    private Label titleLabel = null!;
    private Label invoiceLabel = null!;
    private System.Windows.Forms.Label productLabel;
    private System.Windows.Forms.TextBox searchProductTextBox;
    private System.Windows.Forms.Button addToCartButton;
    private TechZone.UI.Components.DataTable productTable;
    private DataTablePagination dataTablePagination1 = null!;

    private Label cartLabel = null!;
    private System.Windows.Forms.Button removeButton;
    private TechZone.UI.Components.DataTable cartTable;

    private System.Windows.Forms.Label staffLabel;
    private System.Windows.Forms.ComboBox staffComboBox;

    private System.Windows.Forms.Label discountLabel;
    private System.Windows.Forms.TextBox discountTextBox;
    private System.Windows.Forms.Button calculateDiscountButton;

    private Panel totalPanel = null!;
    private Label subtotalLabel = null!;
    private Label subtotalValueLabel = null!;
    private Label discountValueTitleLabel = null!;
    private Label discountValueLabel = null!;
    private Label totalLabel = null!;
    private Label totalValueLabel = null!;

    private Button cancelButton = null!;
    private Button saveSaleButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        titleLabel = new System.Windows.Forms.Label();
        invoiceLabel = new System.Windows.Forms.Label();
        productLabel = new System.Windows.Forms.Label();
        searchProductTextBox = new System.Windows.Forms.TextBox();
        addToCartButton = new System.Windows.Forms.Button();
        productTable = new TechZone.UI.Components.DataTable();
        cartLabel = new System.Windows.Forms.Label();
        removeButton = new System.Windows.Forms.Button();
        cartTable = new TechZone.UI.Components.DataTable();
        staffLabel = new System.Windows.Forms.Label();
        staffComboBox = new System.Windows.Forms.ComboBox();
        discountLabel = new System.Windows.Forms.Label();
        discountTextBox = new System.Windows.Forms.TextBox();
        calculateDiscountButton = new System.Windows.Forms.Button();
        totalPanel = new System.Windows.Forms.Panel();
        totalValueLabel = new System.Windows.Forms.Label();
        totalLabel = new System.Windows.Forms.Label();
        discountValueLabel = new System.Windows.Forms.Label();
        discountValueTitleLabel = new System.Windows.Forms.Label();
        subtotalValueLabel = new System.Windows.Forms.Label();
        subtotalLabel = new System.Windows.Forms.Label();
        cancelButton = new System.Windows.Forms.Button();
        saveSaleButton = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        dataTablePagination1 = new TechZone.UI.Components.DataTablePagination();
        totalPanel.SuspendLayout();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new System.Drawing.Font("Bahnschrift", 16F, System.Drawing.FontStyle.Bold);
        titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        titleLabel.Location = new System.Drawing.Point(23, 18);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(142, 33);
        titleLabel.TabIndex = 15;
        titleLabel.Text = "Quick Sale";
        // 
        // invoiceLabel
        // 
        invoiceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        invoiceLabel.Font = new System.Drawing.Font("Bahnschrift", 10F);
        invoiceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        invoiceLabel.Location = new System.Drawing.Point(1000, 21);
        invoiceLabel.Name = "invoiceLabel";
        invoiceLabel.Size = new System.Drawing.Size(260, 22);
        invoiceLabel.TabIndex = 14;
        invoiceLabel.Text = "INV-00001";
        invoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // productLabel
        // 
        productLabel.AutoSize = true;
        productLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        productLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        productLabel.Location = new System.Drawing.Point(23, 66);
        productLabel.Name = "productLabel";
        productLabel.Size = new System.Drawing.Size(83, 22);
        productLabel.TabIndex = 13;
        productLabel.Text = "Products";
        // 
        // searchProductTextBox
        // 
        searchProductTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        searchProductTextBox.Location = new System.Drawing.Point(23, 91);
        searchProductTextBox.Name = "searchProductTextBox";
        searchProductTextBox.PlaceholderText = "Search product by SKU, name or category...";
        searchProductTextBox.Size = new System.Drawing.Size(495, 28);
        searchProductTextBox.TabIndex = 11;
        // 
        // addToCartButton
        // 
        addToCartButton.BackColor = System.Drawing.Color.RoyalBlue;
        addToCartButton.Cursor = System.Windows.Forms.Cursors.Hand;
        addToCartButton.FlatAppearance.BorderSize = 0;
        addToCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        addToCartButton.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        addToCartButton.ForeColor = System.Drawing.Color.White;
        addToCartButton.Image = global::TechZone.Resources.icon_arrow;
        addToCartButton.Location = new System.Drawing.Point(528, 91);
        addToCartButton.Name = "addToCartButton";
        addToCartButton.Size = new System.Drawing.Size(50, 29);
        addToCartButton.TabIndex = 10;
        addToCartButton.UseVisualStyleBackColor = false;
        // 
        // productTable
        // 
        productTable.BackColor = System.Drawing.Color.White;
        productTable.DataSource = null;
        productTable.FontSize = 9F;
        productTable.Location = new System.Drawing.Point(23, 129);
        productTable.Margin = new System.Windows.Forms.Padding(0);
        productTable.Name = "productTable";
        productTable.NumberStart = 1;
        productTable.Size = new System.Drawing.Size(544, 398);
        productTable.TabIndex = 12;
        // 
        // cartLabel
        // 
        cartLabel.AutoSize = true;
        cartLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        cartLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        cartLabel.Location = new System.Drawing.Point(608, 69);
        cartLabel.Name = "cartLabel";
        cartLabel.Size = new System.Drawing.Size(28, 15);
        cartLabel.TabIndex = 0;
        cartLabel.Text = "Cart";
        // 
        // removeButton
        // 
        removeButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)38)), ((int)((byte)38)));
        removeButton.Cursor = System.Windows.Forms.Cursors.Hand;
        removeButton.FlatAppearance.BorderSize = 0;
        removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        removeButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        removeButton.ForeColor = System.Drawing.Color.White;
        removeButton.Image = global::TechZone.Resources.icon_remove_cart;
        removeButton.Location = new System.Drawing.Point(1180, 96);
        removeButton.Name = "removeButton";
        removeButton.Size = new System.Drawing.Size(80, 29);
        removeButton.TabIndex = 8;
        removeButton.UseVisualStyleBackColor = false;
        // 
        // cartTable
        // 
        cartTable.BackColor = System.Drawing.Color.White;
        cartTable.DataSource = null;
        cartTable.FontSize = 9F;
        cartTable.Location = new System.Drawing.Point(608, 129);
        cartTable.Margin = new System.Windows.Forms.Padding(0);
        cartTable.Name = "cartTable";
        cartTable.NumberStart = 1;
        cartTable.Size = new System.Drawing.Size(652, 266);
        cartTable.TabIndex = 9;
        // 
        // staffLabel
        // 
        staffLabel.AutoSize = true;
        staffLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        staffLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        staffLabel.Location = new System.Drawing.Point(608, 416);
        staffLabel.Name = "staffLabel";
        staffLabel.Size = new System.Drawing.Size(40, 18);
        staffLabel.TabIndex = 7;
        staffLabel.Text = "Staff";
        // 
        // staffComboBox
        // 
        staffComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        staffComboBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        staffComboBox.FormattingEnabled = true;
        staffComboBox.Location = new System.Drawing.Point(608, 438);
        staffComboBox.Name = "staffComboBox";
        staffComboBox.Size = new System.Drawing.Size(230, 29);
        staffComboBox.TabIndex = 6;
        // 
        // discountLabel
        // 
        discountLabel.AutoSize = true;
        discountLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        discountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        discountLabel.Location = new System.Drawing.Point(609, 478);
        discountLabel.Name = "discountLabel";
        discountLabel.Size = new System.Drawing.Size(66, 18);
        discountLabel.TabIndex = 5;
        discountLabel.Text = "Discount";
        // 
        // discountTextBox
        // 
        discountTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        discountTextBox.Location = new System.Drawing.Point(609, 499);
        discountTextBox.Name = "discountTextBox";
        discountTextBox.PlaceholderText = "0 %";
        discountTextBox.Size = new System.Drawing.Size(90, 28);
        discountTextBox.TabIndex = 4;
        discountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // calculateDiscountButton
        // 
        calculateDiscountButton.BackColor = System.Drawing.Color.RoyalBlue;
        calculateDiscountButton.Cursor = System.Windows.Forms.Cursors.Hand;
        calculateDiscountButton.FlatAppearance.BorderSize = 0;
        calculateDiscountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        calculateDiscountButton.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        calculateDiscountButton.ForeColor = System.Drawing.Color.White;
        calculateDiscountButton.Image = global::TechZone.Resources.icon_arrow;
        calculateDiscountButton.Location = new System.Drawing.Point(705, 498);
        calculateDiscountButton.Name = "calculateDiscountButton";
        calculateDiscountButton.Size = new System.Drawing.Size(45, 29);
        calculateDiscountButton.TabIndex = 3;
        calculateDiscountButton.UseVisualStyleBackColor = false;
        // 
        // totalPanel
        // 
        totalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        totalPanel.Controls.Add(totalValueLabel);
        totalPanel.Controls.Add(totalLabel);
        totalPanel.Controls.Add(discountValueLabel);
        totalPanel.Controls.Add(discountValueTitleLabel);
        totalPanel.Controls.Add(subtotalValueLabel);
        totalPanel.Controls.Add(subtotalLabel);
        totalPanel.Location = new System.Drawing.Point(860, 416);
        totalPanel.Name = "totalPanel";
        totalPanel.Size = new System.Drawing.Size(400, 111);
        totalPanel.TabIndex = 2;
        // 
        // totalValueLabel
        // 
        totalValueLabel.AutoSize = true;
        totalValueLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        totalValueLabel.ForeColor = System.Drawing.Color.RoyalBlue;
        totalValueLabel.Location = new System.Drawing.Point(300, 73);
        totalValueLabel.Name = "totalValueLabel";
        totalValueLabel.Size = new System.Drawing.Size(51, 21);
        totalValueLabel.TabIndex = 0;
        totalValueLabel.Text = "$0.00";
        // 
        // totalLabel
        // 
        totalLabel.AutoSize = true;
        totalLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
        totalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        totalLabel.Location = new System.Drawing.Point(18, 73);
        totalLabel.Name = "totalLabel";
        totalLabel.Size = new System.Drawing.Size(46, 21);
        totalLabel.TabIndex = 1;
        totalLabel.Text = "Total";
        // 
        // discountValueLabel
        // 
        discountValueLabel.AutoSize = true;
        discountValueLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        discountValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        discountValueLabel.Location = new System.Drawing.Point(300, 39);
        discountValueLabel.Name = "discountValueLabel";
        discountValueLabel.Size = new System.Drawing.Size(44, 18);
        discountValueLabel.TabIndex = 2;
        discountValueLabel.Text = "$0.00";
        // 
        // discountValueTitleLabel
        // 
        discountValueTitleLabel.AutoSize = true;
        discountValueTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        discountValueTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        discountValueTitleLabel.Location = new System.Drawing.Point(18, 39);
        discountValueTitleLabel.Name = "discountValueTitleLabel";
        discountValueTitleLabel.Size = new System.Drawing.Size(66, 18);
        discountValueTitleLabel.TabIndex = 3;
        discountValueTitleLabel.Text = "Discount";
        // 
        // subtotalValueLabel
        // 
        subtotalValueLabel.AutoSize = true;
        subtotalValueLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        subtotalValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        subtotalValueLabel.Location = new System.Drawing.Point(300, 12);
        subtotalValueLabel.Name = "subtotalValueLabel";
        subtotalValueLabel.Size = new System.Drawing.Size(44, 18);
        subtotalValueLabel.TabIndex = 4;
        subtotalValueLabel.Text = "$0.00";
        // 
        // subtotalLabel
        // 
        subtotalLabel.AutoSize = true;
        subtotalLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        subtotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        subtotalLabel.Location = new System.Drawing.Point(18, 12);
        subtotalLabel.Name = "subtotalLabel";
        subtotalLabel.Size = new System.Drawing.Size(63, 18);
        subtotalLabel.TabIndex = 5;
        subtotalLabel.Text = "Subtotal";
        // 
        // cancelButton
        // 
        cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        cancelButton.BackColor = System.Drawing.Color.White;
        cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
        cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
        cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        cancelButton.Location = new System.Drawing.Point(955, 590);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 38);
        cancelButton.TabIndex = 1;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        // 
        // saveSaleButton
        // 
        saveSaleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        saveSaleButton.BackColor = System.Drawing.Color.RoyalBlue;
        saveSaleButton.Cursor = System.Windows.Forms.Cursors.Hand;
        saveSaleButton.FlatAppearance.BorderSize = 0;
        saveSaleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saveSaleButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold);
        saveSaleButton.ForeColor = System.Drawing.Color.White;
        saveSaleButton.Location = new System.Drawing.Point(1070, 590);
        saveSaleButton.Name = "saveSaleButton";
        saveSaleButton.Size = new System.Drawing.Size(190, 38);
        saveSaleButton.TabIndex = 0;
        saveSaleButton.Text = "Confirm Payment";
        saveSaleButton.UseVisualStyleBackColor = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        label1.Location = new System.Drawing.Point(608, 98);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(126, 22);
        label1.TabIndex = 16;
        label1.Text = "Product\'s Cart";
        // 
        // dataTablePagination1
        // 
        dataTablePagination1.BackColor = System.Drawing.Color.Transparent;
        dataTablePagination1.Location = new System.Drawing.Point(23, 540);
        dataTablePagination1.Margin = new System.Windows.Forms.Padding(0);
        dataTablePagination1.MaximumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.MinimumSize = new System.Drawing.Size(400, 44);
        dataTablePagination1.Name = "dataTablePagination1";
        dataTablePagination1.PageSize = 7;
        dataTablePagination1.Size = new System.Drawing.Size(400, 44);
        dataTablePagination1.TabIndex = 17;
        // 
        // AddQuickSaleForm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(1285, 650);
        Controls.Add(dataTablePagination1);
        Controls.Add(label1);
        Controls.Add(saveSaleButton);
        Controls.Add(cancelButton);
        Controls.Add(totalPanel);
        Controls.Add(calculateDiscountButton);
        Controls.Add(discountTextBox);
        Controls.Add(discountLabel);
        Controls.Add(staffComboBox);
        Controls.Add(staffLabel);
        Controls.Add(removeButton);
        Controls.Add(cartTable);
        Controls.Add(addToCartButton);
        Controls.Add(searchProductTextBox);
        Controls.Add(productTable);
        Controls.Add(productLabel);
        Controls.Add(invoiceLabel);
        Controls.Add(titleLabel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quick Sale";
        totalPanel.ResumeLayout(false);
        totalPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label1;
}