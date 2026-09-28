using System.ComponentModel;

namespace TechZone.UI.Forms.Edit;

partial class EditInventoryForm
{
    private IContainer components = null!;

    private Label productLabel;
    private Label productValueLabel;

    private Label stockLabel;
    private Button decreaseButton;
    private System.Windows.Forms.TextBox stockTextBox;
    private System.Windows.Forms.Button increaseButton;

    private Button cancelButton;
    private Button saveButton;

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
        productLabel = new System.Windows.Forms.Label();
        productValueLabel = new System.Windows.Forms.Label();
        stockLabel = new System.Windows.Forms.Label();
        decreaseButton = new System.Windows.Forms.Button();
        stockTextBox = new System.Windows.Forms.TextBox();
        increaseButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        saveButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // productLabel
        // 
        productLabel.AutoSize = true;
        productLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        productLabel.Location = new System.Drawing.Point(24, 24);
        productLabel.Name = "productLabel";
        productLabel.Size = new System.Drawing.Size(59, 18);
        productLabel.TabIndex = 0;
        productLabel.Text = "Product";
        // 
        // productValueLabel
        // 
        productValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        productValueLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
        productValueLabel.Location = new System.Drawing.Point(24, 46);
        productValueLabel.Name = "productValueLabel";
        productValueLabel.Size = new System.Drawing.Size(452, 30);
        productValueLabel.TabIndex = 1;
        productValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // stockLabel
        // 
        stockLabel.AutoSize = true;
        stockLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        stockLabel.Location = new System.Drawing.Point(24, 94);
        stockLabel.Name = "stockLabel";
        stockLabel.Size = new System.Drawing.Size(45, 18);
        stockLabel.TabIndex = 2;
        stockLabel.Text = "Stock";
        // 
        // decreaseButton
        // 
        decreaseButton.Font = new System.Drawing.Font("Bahnschrift", 11F);
        decreaseButton.Location = new System.Drawing.Point(24, 116);
        decreaseButton.Name = "decreaseButton";
        decreaseButton.Size = new System.Drawing.Size(45, 32);
        decreaseButton.TabIndex = 0;
        decreaseButton.Text = "−";
        decreaseButton.UseVisualStyleBackColor = true;
        // 
        // stockTextBox
        // 
        stockTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        stockTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
        stockTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
        stockTextBox.Location = new System.Drawing.Point(75, 118);
        stockTextBox.Name = "stockTextBox";
        stockTextBox.Size = new System.Drawing.Size(70, 28);
        stockTextBox.TabIndex = 1;
        stockTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // increaseButton
        // 
        increaseButton.Font = new System.Drawing.Font("Bahnschrift", 11F);
        increaseButton.Location = new System.Drawing.Point(150, 115);
        increaseButton.Name = "increaseButton";
        increaseButton.Size = new System.Drawing.Size(45, 32);
        increaseButton.TabIndex = 2;
        increaseButton.Text = "+";
        increaseButton.UseVisualStyleBackColor = true;
        // 
        // cancelButton
        // 
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        cancelButton.Location = new System.Drawing.Point(282, 196);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 30);
        cancelButton.TabIndex = 3;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;
        // 
        // saveButton
        // 
        saveButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        saveButton.Location = new System.Drawing.Point(388, 196);
        saveButton.Name = "saveButton";
        saveButton.Size = new System.Drawing.Size(100, 30);
        saveButton.TabIndex = 4;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;
        // 
        // EditInventoryForm
        // 
        AcceptButton = saveButton;
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.SystemColors.Window;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(500, 238);
        Controls.Add(productLabel);
        Controls.Add(productValueLabel);
        Controls.Add(stockLabel);
        Controls.Add(decreaseButton);
        Controls.Add(stockTextBox);
        Controls.Add(increaseButton);
        Controls.Add(cancelButton);
        Controls.Add(saveButton);
        Font = new System.Drawing.Font("Bahnschrift", 9F);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Edit Stock";
        ResumeLayout(false);
        PerformLayout();
    }
}