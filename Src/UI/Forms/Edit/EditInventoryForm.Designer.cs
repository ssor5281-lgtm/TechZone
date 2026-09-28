using System.ComponentModel;

namespace TechZone.UI.Forms.Edit;

partial class EditInventoryForm
{
    private IContainer components = null!;

    private Label productLabel;
    private Label productValueLabel;
    private Label stockLabel;
    private System.Windows.Forms.Button decreaseButton;
    private System.Windows.Forms.TextBox stockValueLabel;
    private Button increaseButton;
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
        increaseButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        saveButton = new System.Windows.Forms.Button();
        stockValueLabel = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // productLabel
        // 
        productLabel.AutoSize = true;
        productLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        productLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        productLabel.Location = new System.Drawing.Point(28, 24);
        productLabel.Name = "productLabel";
        productLabel.Size = new System.Drawing.Size(59, 18);
        productLabel.TabIndex = 0;
        productLabel.Text = "Product";
        // 
        // productValueLabel
        // 
        productValueLabel.AutoEllipsis = true;
        productValueLabel.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold);
        productValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        productValueLabel.Location = new System.Drawing.Point(28, 46);
        productValueLabel.Name = "productValueLabel";
        productValueLabel.Size = new System.Drawing.Size(494, 38);
        productValueLabel.TabIndex = 1;
        productValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // stockLabel
        // 
        stockLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        stockLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        stockLabel.Location = new System.Drawing.Point(28, 101);
        stockLabel.Name = "stockLabel";
        stockLabel.Size = new System.Drawing.Size(494, 18);
        stockLabel.TabIndex = 2;
        stockLabel.Text = "Stock";
        stockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // decreaseButton
        // 
        decreaseButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)239)), ((int)((byte)246)), ((int)((byte)255)));
        decreaseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)191)), ((int)((byte)219)), ((int)((byte)254)));
        decreaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        decreaseButton.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold);
        decreaseButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        decreaseButton.Location = new System.Drawing.Point(190, 128);
        decreaseButton.Name = "decreaseButton";
        decreaseButton.Size = new System.Drawing.Size(48, 38);
        decreaseButton.TabIndex = 3;
        decreaseButton.Text = "-";
        decreaseButton.UseVisualStyleBackColor = false;
        // 
        // increaseButton
        // 
        increaseButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)239)), ((int)((byte)246)), ((int)((byte)255)));
        increaseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)191)), ((int)((byte)219)), ((int)((byte)254)));
        increaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        increaseButton.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold);
        increaseButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        increaseButton.Location = new System.Drawing.Point(330, 128);
        increaseButton.Name = "increaseButton";
        increaseButton.Size = new System.Drawing.Size(48, 38);
        increaseButton.TabIndex = 5;
        increaseButton.Text = "+";
        increaseButton.UseVisualStyleBackColor = false;
        // 
        // cancelButton
        // 
        cancelButton.BackColor = System.Drawing.Color.White;
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
        cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        cancelButton.Location = new System.Drawing.Point(318, 216);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 34);
        cancelButton.TabIndex = 6;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        // 
        // saveButton
        // 
        saveButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        saveButton.FlatAppearance.BorderSize = 0;
        saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saveButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        saveButton.ForeColor = System.Drawing.Color.White;
        saveButton.Location = new System.Drawing.Point(424, 216);
        saveButton.Name = "saveButton";
        saveButton.Size = new System.Drawing.Size(100, 34);
        saveButton.TabIndex = 7;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = false;
        // 
        // stockValueLabel
        // 
        stockValueLabel.BackColor = System.Drawing.SystemColors.Window;
        stockValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
        stockValueLabel.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        stockValueLabel.Location = new System.Drawing.Point(245, 129);
        stockValueLabel.Name = "stockValueLabel";
        stockValueLabel.Size = new System.Drawing.Size(79, 37);
        stockValueLabel.TabIndex = 8;
        stockValueLabel.Text = "0";
        stockValueLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // EditInventoryForm
        // 
        AcceptButton = saveButton;
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.White;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(550, 260);
        Controls.Add(stockValueLabel);
        Controls.Add(productLabel);
        Controls.Add(productValueLabel);
        Controls.Add(stockLabel);
        Controls.Add(decreaseButton);
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