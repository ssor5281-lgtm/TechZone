using System.ComponentModel;

namespace TechZone.UI.Forms.Create;

partial class AddCategoryForm
{
    private IContainer components = null!;

    private Label nameLabel;
    private System.Windows.Forms.TextBox nameTextBox;

    private Label descriptionLabel;
    private System.Windows.Forms.TextBox descriptionTextBox;

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button addButton;

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
        nameLabel = new System.Windows.Forms.Label();
        nameTextBox = new System.Windows.Forms.TextBox();
        descriptionLabel = new System.Windows.Forms.Label();
        descriptionTextBox = new System.Windows.Forms.TextBox();
        cancelButton = new System.Windows.Forms.Button();
        addButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // nameLabel
        // 
        nameLabel.AutoSize = true;
        nameLabel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        nameLabel.Location = new System.Drawing.Point(24, 24);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new System.Drawing.Size(118, 18);
        nameLabel.TabIndex = 0;
        nameLabel.Text = "Category Name";
        // 
        // nameTextBox
        // 
        nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        nameTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        nameTextBox.Location = new System.Drawing.Point(24, 46);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new System.Drawing.Size(452, 30);
        nameTextBox.TabIndex = 0;
        // 
        // descriptionLabel
        // 
        descriptionLabel.AutoSize = true;
        descriptionLabel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        descriptionLabel.Location = new System.Drawing.Point(24, 88);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new System.Drawing.Size(90, 18);
        descriptionLabel.TabIndex = 1;
        descriptionLabel.Text = "Description";
        // 
        // descriptionTextBox
        // 
        descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        descriptionTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
        descriptionTextBox.Location = new System.Drawing.Point(24, 110);
        descriptionTextBox.Multiline = true;
        descriptionTextBox.Name = "descriptionTextBox";
        descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        descriptionTextBox.Size = new System.Drawing.Size(452, 120);
        descriptionTextBox.TabIndex = 1;
        // 
        // cancelButton
        // 
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        cancelButton.Location = new System.Drawing.Point(282, 326);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 30);
        cancelButton.TabIndex = 2;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;
        // 
        // addButton
        // 
        addButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        addButton.Location = new System.Drawing.Point(388, 326);
        addButton.Name = "addButton";
        addButton.Size = new System.Drawing.Size(100, 30);
        addButton.TabIndex = 3;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        // 
        // AddCategoryForm
        // 
        AcceptButton = addButton;
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.SystemColors.Window;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(500, 368);
        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(descriptionLabel);
        Controls.Add(descriptionTextBox);
        Controls.Add(cancelButton);
        Controls.Add(addButton);
        Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Add Category";
        ResumeLayout(false);
        PerformLayout();
    }
}