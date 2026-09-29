#nullable disable

namespace TechZone.UI.Components;

partial class ProductCard
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.PictureBox picProduct;
    private System.Windows.Forms.Panel pnlContent;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblSku;
    private System.Windows.Forms.Button btnCopySku;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.Label lblStock;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
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
        picProduct = new System.Windows.Forms.PictureBox();
        pnlContent = new System.Windows.Forms.Panel();
        lblName = new System.Windows.Forms.Label();
        lblSku = new System.Windows.Forms.Label();
        btnCopySku = new System.Windows.Forms.Button();
        lblCategory = new System.Windows.Forms.Label();
        lblPrice = new System.Windows.Forms.Label();
        lblStock = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
        pnlContent.SuspendLayout();
        SuspendLayout();
        // 
        // picProduct
        // 
        picProduct.BackColor = System.Drawing.Color.FromArgb(((int)((byte)195)), ((int)((byte)220)), ((int)((byte)248)));
        picProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        picProduct.Dock = System.Windows.Forms.DockStyle.Top;
        picProduct.Location = new System.Drawing.Point(0, 0);
        picProduct.Name = "picProduct";
        picProduct.Size = new System.Drawing.Size(265, 265);
        picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picProduct.TabIndex = 0;
        picProduct.TabStop = false;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)((byte)236)), ((int)((byte)241)), ((int)((byte)246)));
        pnlContent.Controls.Add(lblName);
        pnlContent.Controls.Add(lblSku);
        pnlContent.Controls.Add(btnCopySku);
        pnlContent.Controls.Add(lblCategory);
        pnlContent.Controls.Add(lblPrice);
        pnlContent.Controls.Add(lblStock);
        pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlContent.Location = new System.Drawing.Point(0, 265);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new System.Windows.Forms.Padding(14, 12, 14, 14);
        pnlContent.Size = new System.Drawing.Size(265, 145);
        pnlContent.TabIndex = 0;
        // 
        // lblName
        // 
        lblName.AutoEllipsis = true;
        lblName.AutoSize = true;
        lblName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.5F, System.Drawing.FontStyle.Bold);
        lblName.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        lblName.Location = new System.Drawing.Point(14, 12);
        lblName.Name = "lblName";
        lblName.Size = new System.Drawing.Size(127, 22);
        lblName.TabIndex = 0;
        lblName.Text = "Product Name";
        // 
        // lblSku
        // 
        lblSku.AutoEllipsis = true;
        lblSku.Font = new System.Drawing.Font("Bahnschrift", 9F);
        lblSku.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        lblSku.Location = new System.Drawing.Point(14, 48);
        lblSku.Name = "lblSku";
        lblSku.Size = new System.Drawing.Size(155, 20);
        lblSku.TabIndex = 1;
        lblSku.Text = "SKU-0001";
        // 
        // btnCopySku
        // 
        btnCopySku.AutoSize = true;
        btnCopySku.BackColor = System.Drawing.Color.Gainsboro;
        btnCopySku.Cursor = System.Windows.Forms.Cursors.Hand;
        btnCopySku.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)191)), ((int)((byte)219)), ((int)((byte)254)));
        btnCopySku.FlatAppearance.BorderSize = 0;
        btnCopySku.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)191)), ((int)((byte)219)), ((int)((byte)254)));
        btnCopySku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCopySku.Font = new System.Drawing.Font("Bahnschrift", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnCopySku.ForeColor = System.Drawing.Color.Black;
        btnCopySku.Location = new System.Drawing.Point(180, 40);
        btnCopySku.Name = "btnCopySku";
        btnCopySku.Size = new System.Drawing.Size(68, 28);
        btnCopySku.TabIndex = 2;
        btnCopySku.TabStop = false;
        btnCopySku.Text = "Copy";
        btnCopySku.UseVisualStyleBackColor = false;
        // 
        // lblCategory
        // 
        lblCategory.AutoEllipsis = true;
        lblCategory.AutoSize = true;
        lblCategory.Font = new System.Drawing.Font("Bahnschrift", 9F);
        lblCategory.ForeColor = System.Drawing.Color.Maroon;
        lblCategory.Location = new System.Drawing.Point(14, 68);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new System.Drawing.Size(67, 18);
        lblCategory.TabIndex = 3;
        lblCategory.Text = "Category";
        // 
        // lblPrice
        // 
        lblPrice.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
        lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        lblPrice.Location = new System.Drawing.Point(14, 100);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new System.Drawing.Size(120, 24);
        lblPrice.TabIndex = 4;
        lblPrice.Text = "$95.00";
        // 
        // lblStock
        // 
        lblStock.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        lblStock.Location = new System.Drawing.Point(140, 102);
        lblStock.Name = "lblStock";
        lblStock.Size = new System.Drawing.Size(110, 22);
        lblStock.TabIndex = 5;
        lblStock.Text = "Stock: 22";
        lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // ProductCard
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)236)), ((int)((byte)241)), ((int)((byte)246)));
        Controls.Add(pnlContent);
        Controls.Add(picProduct);
        Font = new System.Drawing.Font("Bahnschrift", 10F);
        Margin = new System.Windows.Forms.Padding(10);
        Size = new System.Drawing.Size(265, 410);
        ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
        pnlContent.ResumeLayout(false);
        pnlContent.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
}