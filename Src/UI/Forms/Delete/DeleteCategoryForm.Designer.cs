using System.ComponentModel;

namespace TechZone.UI.Forms.Delete;

partial class DeleteCategoryForm
{
    private IContainer components = null!;

    private Label titleLabel;
    private Label productCountLabel;
    private Label moveToLabel;
    private RadioButton existingCategoryRadioButton;
    private ComboBox categoryComboBox;
    private RadioButton noCategoryRadioButton;
    private Label infoLabel;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button deleteButton;

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
        titleLabel = new System.Windows.Forms.Label();
        productCountLabel = new System.Windows.Forms.Label();
        moveToLabel = new System.Windows.Forms.Label();
        existingCategoryRadioButton = new System.Windows.Forms.RadioButton();
        categoryComboBox = new System.Windows.Forms.ComboBox();
        noCategoryRadioButton = new System.Windows.Forms.RadioButton();
        infoLabel = new System.Windows.Forms.Label();
        cancelButton = new System.Windows.Forms.Button();
        deleteButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F, System.Drawing.FontStyle.Bold);
        titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)45)), ((int)((byte)45)), ((int)((byte)45)));
        titleLabel.Location = new System.Drawing.Point(28, 25);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(142, 19);
        titleLabel.TabIndex = 15;
        titleLabel.Text = "Delete Category";
        // 
        // productCountLabel
        // 
        productCountLabel.AutoSize = true;
        productCountLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        productCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)105)), ((int)((byte)105)), ((int)((byte)105)));
        productCountLabel.Location = new System.Drawing.Point(29, 51);
        productCountLabel.Name = "productCountLabel";
        productCountLabel.Size = new System.Drawing.Size(253, 18);
        productCountLabel.TabIndex = 14;
        productCountLabel.Text = "This category contains 0 products.";
        // 
        // moveToLabel
        // 
        moveToLabel.AutoSize = true;
        moveToLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        moveToLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)55)), ((int)((byte)55)), ((int)((byte)55)));
        moveToLabel.Location = new System.Drawing.Point(29, 92);
        moveToLabel.Name = "moveToLabel";
        moveToLabel.Size = new System.Drawing.Size(136, 18);
        moveToLabel.TabIndex = 13;
        moveToLabel.Text = "Move products to:";
        // 
        // existingCategoryRadioButton
        // 
        existingCategoryRadioButton.AutoSize = true;
        existingCategoryRadioButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        existingCategoryRadioButton.Location = new System.Drawing.Point(29, 120);
        existingCategoryRadioButton.Name = "existingCategoryRadioButton";
        existingCategoryRadioButton.Size = new System.Drawing.Size(151, 22);
        existingCategoryRadioButton.TabIndex = 12;
        existingCategoryRadioButton.Text = "Existing category";
        existingCategoryRadioButton.UseVisualStyleBackColor = true;
        // 
        // categoryComboBox
        // 
        categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        categoryComboBox.Font = new System.Drawing.Font("Bahnschrift", 9F);
        categoryComboBox.FormattingEnabled = true;
        categoryComboBox.Location = new System.Drawing.Point(49, 148);
        categoryComboBox.Name = "categoryComboBox";
        categoryComboBox.Size = new System.Drawing.Size(463, 26);
        categoryComboBox.TabIndex = 11;
        // 
        // noCategoryRadioButton
        // 
        noCategoryRadioButton.AutoSize = true;
        noCategoryRadioButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        noCategoryRadioButton.Location = new System.Drawing.Point(29, 184);
        noCategoryRadioButton.Name = "noCategoryRadioButton";
        noCategoryRadioButton.Size = new System.Drawing.Size(115, 22);
        noCategoryRadioButton.TabIndex = 10;
        noCategoryRadioButton.Text = "No category";
        noCategoryRadioButton.UseVisualStyleBackColor = true;
        // 
        // infoLabel
        // 
        infoLabel.AutoSize = true;
        infoLabel.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
        infoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)120)), ((int)((byte)120)), ((int)((byte)120)));
        infoLabel.Location = new System.Drawing.Point(29, 222);
        infoLabel.Name = "infoLabel";
        infoLabel.Size = new System.Drawing.Size(371, 18);
        infoLabel.TabIndex = 9;
        infoLabel.Text = "Products and inventory records will not be deleted.";
        // 
        // cancelButton
        // 
        cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        cancelButton.Location = new System.Drawing.Point(337, 270);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(85, 30);
        cancelButton.TabIndex = 7;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;
        // 
        // deleteButton
        // 
        deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
        deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)50)), ((int)((byte)65)));
        deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
        deleteButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        deleteButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)210)), ((int)((byte)50)), ((int)((byte)65)));
        deleteButton.Location = new System.Drawing.Point(427, 270);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new System.Drawing.Size(85, 30);
        deleteButton.TabIndex = 8;
        deleteButton.Text = "Delete";
        deleteButton.UseVisualStyleBackColor = true;
        // 
        // DeleteCategoryForm
        // 
        AcceptButton = deleteButton;
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.White;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(540, 325);
        Controls.Add(deleteButton);
        Controls.Add(cancelButton);
        Controls.Add(infoLabel);
        Controls.Add(noCategoryRadioButton);
        Controls.Add(categoryComboBox);
        Controls.Add(existingCategoryRadioButton);
        Controls.Add(moveToLabel);
        Controls.Add(productCountLabel);
        Controls.Add(titleLabel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Delete Category";
        ResumeLayout(false);
        PerformLayout();
    }
}