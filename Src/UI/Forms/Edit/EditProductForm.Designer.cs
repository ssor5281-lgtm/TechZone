#nullable disable

using System.ComponentModel;

namespace TechZone.UI.Forms.Edit;

partial class EditProductForm
{
private IContainer components = null!;

private Panel imagePanel;
private PictureBox productPictureBox;
private Button chooseImageButton;
private Button removeImageButton;
private Label imageHintLabel;

private Label formTitleLabel;
private Label formSubtitleLabel;

private Label nameLabel;
private TextBox nameTextBox;

private Label skuLabel;
private TextBox skuTextBox;

private Label categoryLabel;
private ComboBox categoryComboBox;

private Label priceLabel;
private TextBox priceTextBox;

private Panel footerPanel;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Button saveButton;

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
    saveButton = new System.Windows.Forms.Button();
    imagePanel.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)productPictureBox).BeginInit();
    footerPanel.SuspendLayout();
    SuspendLayout();
    // 
    // imagePanel
    // 
    imagePanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)241)), ((int)((byte)245)), ((int)((byte)249)));
    imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    imagePanel.Controls.Add(productPictureBox);
    imagePanel.Location = new System.Drawing.Point(28, 28);
    imagePanel.Name = "imagePanel";
    imagePanel.Size = new System.Drawing.Size(230, 230);
    imagePanel.TabIndex = 0;
    // 
    // productPictureBox
    // 
    productPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)((byte)241)), ((int)((byte)245)), ((int)((byte)249)));
    productPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
    productPictureBox.Location = new System.Drawing.Point(0, 0);
    productPictureBox.Name = "productPictureBox";
    productPictureBox.Size = new System.Drawing.Size(228, 228);
    productPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
    productPictureBox.TabIndex = 1;
    productPictureBox.TabStop = false;
    // 
    // chooseImageButton
    // 
    chooseImageButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)239)), ((int)((byte)246)), ((int)((byte)255)));
    chooseImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
    chooseImageButton.FlatAppearance.BorderSize = 0;
    chooseImageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)219)), ((int)((byte)234)), ((int)((byte)254)));
    chooseImageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)219)), ((int)((byte)234)), ((int)((byte)254)));
    chooseImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    chooseImageButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
    chooseImageButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
    chooseImageButton.Location = new System.Drawing.Point(28, 273);
    chooseImageButton.Margin = new System.Windows.Forms.Padding(0);
    chooseImageButton.Name = "chooseImageButton";
    chooseImageButton.Size = new System.Drawing.Size(110, 36);
    chooseImageButton.TabIndex = 2;
    chooseImageButton.Text = "Choose Image";
    chooseImageButton.UseVisualStyleBackColor = false;
    // 
    // removeImageButton
    // 
    removeImageButton.BackColor = System.Drawing.Color.White;
    removeImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
    removeImageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
    removeImageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)254)), ((int)((byte)242)), ((int)((byte)242)));
    removeImageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)254)), ((int)((byte)242)), ((int)((byte)242)));
    removeImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    removeImageButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
    removeImageButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)38)), ((int)((byte)38)));
    removeImageButton.Location = new System.Drawing.Point(148, 273);
    removeImageButton.Margin = new System.Windows.Forms.Padding(0);
    removeImageButton.Name = "removeImageButton";
    removeImageButton.Size = new System.Drawing.Size(110, 36);
    removeImageButton.TabIndex = 3;
    removeImageButton.Text = "Remove";
    removeImageButton.UseVisualStyleBackColor = false;
    // 
    // imageHintLabel
    // 
    imageHintLabel.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
    imageHintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    imageHintLabel.Location = new System.Drawing.Point(28, 316);
    imageHintLabel.Name = "imageHintLabel";
    imageHintLabel.Size = new System.Drawing.Size(230, 24);
    imageHintLabel.TabIndex = 4;
    imageHintLabel.Text = "PNG, JPG or JPEG";
    imageHintLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
    // 
    // formTitleLabel
    // 
    formTitleLabel.AutoSize = true;
    formTitleLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F);
    formTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
    formTitleLabel.Location = new System.Drawing.Point(286, 28);
    formTitleLabel.Name = "formTitleLabel";
    formTitleLabel.Size = new System.Drawing.Size(177, 29);
    formTitleLabel.TabIndex = 5;
    formTitleLabel.Text = "Product Details";
    // 
    // formSubtitleLabel
    // 
    formSubtitleLabel.AutoSize = true;
    formSubtitleLabel.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
    formSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    formSubtitleLabel.Location = new System.Drawing.Point(288, 57);
    formSubtitleLabel.Name = "formSubtitleLabel";
    formSubtitleLabel.Size = new System.Drawing.Size(270, 18);
    formSubtitleLabel.TabIndex = 6;
    formSubtitleLabel.Text = "Update the information for this product.";
    // 
    // nameLabel
    // 
    nameLabel.AutoSize = true;
    nameLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
    nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
    nameLabel.Location = new System.Drawing.Point(286, 91);
    nameLabel.Name = "nameLabel";
    nameLabel.Size = new System.Drawing.Size(103, 18);
    nameLabel.TabIndex = 7;
    nameLabel.Text = "Product Name";
    // 
    // nameTextBox
    // 
    nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    nameTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    nameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
    nameTextBox.Location = new System.Drawing.Point(286, 112);
    nameTextBox.Margin = new System.Windows.Forms.Padding(0);
    nameTextBox.Name = "nameTextBox";
    nameTextBox.Size = new System.Drawing.Size(390, 28);
    nameTextBox.TabIndex = 0;
    // 
    // skuLabel
    // 
    skuLabel.AutoSize = true;
    skuLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
    skuLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
    skuLabel.Location = new System.Drawing.Point(286, 157);
    skuLabel.Name = "skuLabel";
    skuLabel.Size = new System.Drawing.Size(37, 18);
    skuLabel.TabIndex = 8;
    skuLabel.Text = "SKU";
    // 
    // skuTextBox
    // 
    skuTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    skuTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    skuTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
    skuTextBox.Location = new System.Drawing.Point(286, 178);
    skuTextBox.Margin = new System.Windows.Forms.Padding(0);
    skuTextBox.Name = "skuTextBox";
    skuTextBox.Size = new System.Drawing.Size(390, 28);
    skuTextBox.TabIndex = 1;
    // 
    // categoryLabel
    // 
    categoryLabel.AutoSize = true;
    categoryLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
    categoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
    categoryLabel.Location = new System.Drawing.Point(286, 223);
    categoryLabel.Name = "categoryLabel";
    categoryLabel.Size = new System.Drawing.Size(67, 18);
    categoryLabel.TabIndex = 9;
    categoryLabel.Text = "Category";
    // 
    // categoryComboBox
    // 
    categoryComboBox.BackColor = System.Drawing.Color.White;
    categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    categoryComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    categoryComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
    categoryComboBox.FormattingEnabled = true;
    categoryComboBox.Location = new System.Drawing.Point(286, 244);
    categoryComboBox.Margin = new System.Windows.Forms.Padding(0);
    categoryComboBox.Name = "categoryComboBox";
    categoryComboBox.Size = new System.Drawing.Size(390, 29);
    categoryComboBox.TabIndex = 2;
    // 
    // priceLabel
    // 
    priceLabel.AutoSize = true;
    priceLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
    priceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
    priceLabel.Location = new System.Drawing.Point(286, 289);
    priceLabel.Name = "priceLabel";
    priceLabel.Size = new System.Drawing.Size(65, 18);
    priceLabel.TabIndex = 10;
    priceLabel.Text = "Price ($)";
    // 
    // priceTextBox
    // 
    priceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    priceTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    priceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
    priceTextBox.Location = new System.Drawing.Point(286, 310);
    priceTextBox.Margin = new System.Windows.Forms.Padding(0);
    priceTextBox.Name = "priceTextBox";
    priceTextBox.PlaceholderText = " 0.00";
    priceTextBox.Size = new System.Drawing.Size(390, 28);
    priceTextBox.TabIndex = 3;
    // 
    // footerPanel
    // 
    footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
    footerPanel.Controls.Add(cancelButton);
    footerPanel.Controls.Add(saveButton);
    footerPanel.Location = new System.Drawing.Point(0, 382);
    footerPanel.Name = "footerPanel";
    footerPanel.Size = new System.Drawing.Size(704, 70);
    footerPanel.TabIndex = 11;
    // 
    // cancelButton
    // 
    cancelButton.BackColor = System.Drawing.Color.White;
    cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
    cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)241)), ((int)((byte)245)), ((int)((byte)249)));
    cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
    cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
    cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
    cancelButton.Location = new System.Drawing.Point(462, 17);
    cancelButton.Margin = new System.Windows.Forms.Padding(0);
    cancelButton.Name = "cancelButton";
    cancelButton.Size = new System.Drawing.Size(100, 36);
    cancelButton.TabIndex = 5;
    cancelButton.Text = "Cancel";
    cancelButton.UseVisualStyleBackColor = false;
    // 
    // saveButton
    // 
    saveButton.AutoSize = true;
    saveButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
    saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
    saveButton.FlatAppearance.BorderSize = 0;
    saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)29)), ((int)((byte)78)), ((int)((byte)216)));
    saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)59)), ((int)((byte)130)), ((int)((byte)246)));
    saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    saveButton.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
    saveButton.ForeColor = System.Drawing.Color.White;
    saveButton.Location = new System.Drawing.Point(570, 17);
    saveButton.Margin = new System.Windows.Forms.Padding(0);
    saveButton.Name = "saveButton";
    saveButton.Size = new System.Drawing.Size(112, 36);
    saveButton.TabIndex = 6;
    saveButton.Text = "Save Changes";
    saveButton.UseVisualStyleBackColor = false;
    // 
    // EditProductForm
    // 
    AcceptButton = saveButton;
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
    BackColor = System.Drawing.Color.White;
    CancelButton = cancelButton;
    ClientSize = new System.Drawing.Size(704, 452);
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
    Font = new System.Drawing.Font("Bahnschrift", 9F);
    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
    MaximizeBox = false;
    MinimizeBox = false;
    ShowInTaskbar = false;
    StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
    Text = "Edit Product";
    imagePanel.ResumeLayout(false);
    ((System.ComponentModel.ISupportInitialize)productPictureBox).EndInit();
    footerPanel.ResumeLayout(false);
    footerPanel.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
}
}
