#nullable disable

using System.ComponentModel;

namespace TechZone.UI.Forms.Create;

partial class AddProductForm
{
    private IContainer components = null!;

    private PictureBox productPictureBox;
    private Panel imagePanel;
    private System.Windows.Forms.Button chooseImageButton;
    private System.Windows.Forms.Button removeImageButton;
    private System.Windows.Forms.Label imageHintLabel;

    private System.Windows.Forms.Label formTitleLabel;
    private Label formSubtitleLabel;

    private Label nameLabel;
    private TextBox nameTextBox;

    private Label skuLabel;
    private TextBox skuTextBox;

    private Label categoryLabel;
    private System.Windows.Forms.ComboBox categoryComboBox;

    private Label priceLabel;
    private System.Windows.Forms.TextBox priceTextBox;

    private Panel footerPanel;
    private Button cancelButton;
    private Button addButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        imagePanel = new System.Windows.Forms.Panel();
        productPictureBox = new System.Windows.Forms.PictureBox();

        chooseImageButton = new System.Windows.Forms.Button();
        removeImageButton = new System.Windows.Forms.Button();
        imageHintLabel = new System.Windows.Forms.Label();

        formTitleLabel = new System.Windows.Forms.Label();
        formSubtitleLabel = new System.Windows.Forms.Label();

        nameLabel = new System.Windows.Forms.Label();
        nameTextBox = new System.Windows.Forms.TextBox();

        skuLabel = new System.Windows.Forms.Label();
        skuTextBox = new System.Windows.Forms.TextBox();

        categoryLabel = new System.Windows.Forms.Label();
        categoryComboBox = new System.Windows.Forms.ComboBox();

        priceLabel = new System.Windows.Forms.Label();
        priceTextBox = new System.Windows.Forms.TextBox();

        footerPanel = new System.Windows.Forms.Panel();
        cancelButton = new System.Windows.Forms.Button();
        addButton = new System.Windows.Forms.Button();

        imagePanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)productPictureBox).BeginInit();
        footerPanel.SuspendLayout();
        SuspendLayout();

        imagePanel.BackColor =
            System.Drawing.Color.FromArgb(248, 250, 252);

        imagePanel.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;

        imagePanel.Controls.Add(productPictureBox);

        imagePanel.Location =
            new System.Drawing.Point(28, 28);

        imagePanel.Name = "imagePanel";
        imagePanel.Size =
            new System.Drawing.Size(230, 230);
        imagePanel.TabIndex = 0;

        productPictureBox.BackColor =
            System.Drawing.Color.FromArgb(241, 245, 249);

        productPictureBox.Dock =
            System.Windows.Forms.DockStyle.Fill;

        productPictureBox.Location =
            new System.Drawing.Point(0, 0);

        productPictureBox.Name =
            "productPictureBox";

        productPictureBox.Size =
            new System.Drawing.Size(228, 228);

        productPictureBox.SizeMode =
            System.Windows.Forms.PictureBoxSizeMode.CenterImage;

        productPictureBox.TabIndex = 1;
        productPictureBox.TabStop = false;

        

        chooseImageButton.BackColor =
            System.Drawing.Color.FromArgb(
                239, 246, 255);

        chooseImageButton.Cursor =
            System.Windows.Forms.Cursors.Hand;

        chooseImageButton.FlatAppearance.BorderSize = 0;

        chooseImageButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                219, 234, 254);

        chooseImageButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                219, 234, 254);

        chooseImageButton.FlatStyle =
            System.Windows.Forms.FlatStyle.Flat;

        chooseImageButton.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                9F);

        chooseImageButton.ForeColor =
            System.Drawing.Color.FromArgb(
                37, 99, 235);

        chooseImageButton.Location =
            new System.Drawing.Point(28, 273);

        chooseImageButton.Margin =
            new System.Windows.Forms.Padding(0);

        chooseImageButton.Name =
            "chooseImageButton";

        chooseImageButton.Size =
            new System.Drawing.Size(110, 36);

        chooseImageButton.TabIndex = 2;
        chooseImageButton.Text = "Choose Image";

        chooseImageButton.UseVisualStyleBackColor = false;

        removeImageButton.BackColor =
            System.Drawing.Color.White;

        removeImageButton.Cursor =
            System.Windows.Forms.Cursors.Hand;

        removeImageButton.FlatAppearance.BorderColor =
            System.Drawing.Color.FromArgb(
                226, 232, 240);

        removeImageButton.FlatAppearance.BorderSize = 1;

        removeImageButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                254, 242, 242);

        removeImageButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                254, 242, 242);

        removeImageButton.FlatStyle =
            System.Windows.Forms.FlatStyle.Flat;

        removeImageButton.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                9F);

        removeImageButton.ForeColor =
            System.Drawing.Color.FromArgb(
                220, 38, 38);

        removeImageButton.Location =
            new System.Drawing.Point(148, 273);

        removeImageButton.Margin =
            new System.Windows.Forms.Padding(0);

        removeImageButton.Name =
            "removeImageButton";

        removeImageButton.Size =
            new System.Drawing.Size(110, 36);

        removeImageButton.TabIndex = 3;
        removeImageButton.Text = "Remove";

        removeImageButton.UseVisualStyleBackColor = false;

        imageHintLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                8.5F);

        imageHintLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                100, 116, 139);

        imageHintLabel.Location =
            new System.Drawing.Point(28, 314);

        imageHintLabel.Name =
            "imageHintLabel";

        imageHintLabel.Size =
            new System.Drawing.Size(230, 24);

        imageHintLabel.TabIndex = 4;

        imageHintLabel.Text =
            "PNG, JPG or JPEG";

        imageHintLabel.TextAlign =
            System.Drawing.ContentAlignment.TopCenter;

        formTitleLabel.AutoSize = true;

        formTitleLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                14F);

        formTitleLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                15, 23, 42);

        formTitleLabel.Location =
            new System.Drawing.Point(286, 28);

        formTitleLabel.Name =
            "formTitleLabel";

        formTitleLabel.Size =
            new System.Drawing.Size(177, 29);

        formTitleLabel.TabIndex = 5;
        formTitleLabel.Text = "Product Details";

        formSubtitleLabel.AutoSize = true;

        formSubtitleLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                8.5F);

        formSubtitleLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                100, 116, 139);

        formSubtitleLabel.Location =
            new System.Drawing.Point(288, 57);

        formSubtitleLabel.Name =
            "formSubtitleLabel";

        formSubtitleLabel.Size =
            new System.Drawing.Size(298, 18);

        formSubtitleLabel.TabIndex = 6;

        formSubtitleLabel.Text =
            "Enter the basic information for this product.";

        nameLabel.AutoSize = true;

        nameLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        nameLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51, 65, 85);

        nameLabel.Location =
            new System.Drawing.Point(286, 91);

        nameLabel.Name =
            "nameLabel";

        nameLabel.Size =
            new System.Drawing.Size(103, 18);

        nameLabel.TabIndex = 7;
        nameLabel.Text = "Product Name";

        nameTextBox.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;

        nameTextBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        nameTextBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15, 23, 42);

        nameTextBox.Location =
            new System.Drawing.Point(286, 112);

        nameTextBox.Margin =
            new System.Windows.Forms.Padding(0);

        nameTextBox.Name =
            "nameTextBox";

        nameTextBox.Size =
            new System.Drawing.Size(390, 28);

        nameTextBox.TabIndex = 0;

        skuLabel.AutoSize = true;

        skuLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        skuLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51, 65, 85);

        skuLabel.Location =
            new System.Drawing.Point(286, 157);

        skuLabel.Name =
            "skuLabel";

        skuLabel.Size =
            new System.Drawing.Size(37, 18);

        skuLabel.TabIndex = 8;
        skuLabel.Text = "SKU";

        skuTextBox.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;

        skuTextBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        skuTextBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15, 23, 42);

        skuTextBox.Location =
            new System.Drawing.Point(286, 178);

        skuTextBox.Margin =
            new System.Windows.Forms.Padding(0);

        skuTextBox.Name =
            "skuTextBox";

        skuTextBox.Size =
            new System.Drawing.Size(390, 28);

        skuTextBox.TabIndex = 1;

        categoryLabel.AutoSize = true;

        categoryLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        categoryLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51, 65, 85);

        categoryLabel.Location =
            new System.Drawing.Point(286, 223);

        categoryLabel.Name =
            "categoryLabel";

        categoryLabel.Size =
            new System.Drawing.Size(67, 18);

        categoryLabel.TabIndex = 9;
        categoryLabel.Text = "Category";

        categoryComboBox.BackColor =
            System.Drawing.Color.White;

        categoryComboBox.DropDownStyle =
            System.Windows.Forms.ComboBoxStyle.DropDownList;

        categoryComboBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        categoryComboBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15, 23, 42);

        categoryComboBox.FormattingEnabled = true;

        categoryComboBox.Location =
            new System.Drawing.Point(286, 244);

        categoryComboBox.Margin =
            new System.Windows.Forms.Padding(0);

        categoryComboBox.Name =
            "categoryComboBox";

        categoryComboBox.Size =
            new System.Drawing.Size(390, 29);

        categoryComboBox.TabIndex = 2;

        priceLabel.AutoSize = true;

        priceLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        priceLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51, 65, 85);

        priceLabel.Location =
            new System.Drawing.Point(286, 289);

        priceLabel.Name =
            "priceLabel";

        priceLabel.Size =
            new System.Drawing.Size(65, 18);

        priceLabel.TabIndex = 10;
        priceLabel.Text = "Price ($)";

        priceTextBox.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;

        priceTextBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        priceTextBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15, 23, 42);

        priceTextBox.Location =
            new System.Drawing.Point(286, 310);

        priceTextBox.Margin =
            new System.Windows.Forms.Padding(0);

        priceTextBox.Name =
            "priceTextBox";

        priceTextBox.PlaceholderText =
            " 0.00";

        priceTextBox.Size =
            new System.Drawing.Size(390, 28);

        priceTextBox.TabIndex = 3;

        footerPanel.BackColor =
            System.Drawing.Color.FromArgb(
                248, 250, 252);

        footerPanel.Controls.Add(cancelButton);
        footerPanel.Controls.Add(addButton);

        footerPanel.Location =
            new System.Drawing.Point(0, 382);

        footerPanel.Name =
            "footerPanel";

        footerPanel.Size =
            new System.Drawing.Size(704, 70);

        footerPanel.TabIndex = 11;

        cancelButton.BackColor =
            System.Drawing.Color.White;

        cancelButton.DialogResult =
            System.Windows.Forms.DialogResult.Cancel;

        cancelButton.FlatAppearance.BorderColor =
            System.Drawing.Color.FromArgb(
                203, 213, 225);

        cancelButton.FlatAppearance.BorderSize = 1;

        cancelButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                241, 245, 249);

        cancelButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                248, 250, 252);

        cancelButton.FlatStyle =
            System.Windows.Forms.FlatStyle.Flat;

        cancelButton.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                9F);

        cancelButton.ForeColor =
            System.Drawing.Color.FromArgb(
                71, 85, 105);

        cancelButton.Location =
            new System.Drawing.Point(462, 17);

        cancelButton.Margin =
            new System.Windows.Forms.Padding(0);

        cancelButton.Name =
            "cancelButton";

        cancelButton.Size =
            new System.Drawing.Size(100, 36);

        cancelButton.TabIndex = 5;
        cancelButton.Text = "Cancel";

        cancelButton.UseVisualStyleBackColor = false;

        addButton.BackColor =
            System.Drawing.Color.FromArgb(
                37, 99, 235);

        addButton.FlatAppearance.BorderSize = 0;

        addButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                29, 78, 216);

        addButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                59, 130, 246);

        addButton.FlatStyle =
            System.Windows.Forms.FlatStyle.Flat;

        addButton.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        addButton.ForeColor =
            System.Drawing.Color.White;

        addButton.Location =
            new System.Drawing.Point(570, 17);

        addButton.Margin =
            new System.Windows.Forms.Padding(0);

        addButton.Name =
            "addButton";

        addButton.Size =
            new System.Drawing.Size(106, 36);

        addButton.TabIndex = 6;
        addButton.Text = "Add Product";

        addButton.UseVisualStyleBackColor = false;

        AcceptButton = addButton;
        AutoScaleMode =
            System.Windows.Forms.AutoScaleMode.None;

        BackColor =
            System.Drawing.Color.White;

        CancelButton = cancelButton;

        ClientSize =
            new System.Drawing.Size(704, 452);

        Controls.Add(footerPanel);
        Controls.Add(priceTextBox);
        Controls.Add(priceLabel);
        Controls.Add(categoryComboBox);
        Controls.Add(categoryLabel);
        Controls.Add(skuTextBox);
        Controls.Add(skuLabel);
        Controls.Add(nameTextBox);
        Controls.Add(nameLabel);
        Controls.Add(formSubtitleLabel);
        Controls.Add(formTitleLabel);
        Controls.Add(imageHintLabel);
        Controls.Add(removeImageButton);
        Controls.Add(chooseImageButton);
        Controls.Add(imagePanel);

        Font =
            new System.Drawing.Font(
                "Bahnschrift",
                9F);

        FormBorderStyle =
            System.Windows.Forms.FormBorderStyle.FixedDialog;

        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;

        StartPosition =
            System.Windows.Forms.FormStartPosition.CenterParent;

        Text = "Add Product";

        imagePanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)
            productPictureBox).EndInit();
        
        footerPanel.ResumeLayout(false);

        ResumeLayout(false);
        PerformLayout();
    }
}