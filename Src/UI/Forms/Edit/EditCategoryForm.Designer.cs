using System.ComponentModel;

namespace TechZone.UI.Forms.Edit;

partial class EditCategoryForm
{
    private IContainer components = null!;

    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.TextBox nameTextBox;

    private System.Windows.Forms.Label descriptionLabel;
    private System.Windows.Forms.TextBox descriptionTextBox;

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button saveButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        nameLabel = new System.Windows.Forms.Label();
        nameTextBox = new System.Windows.Forms.TextBox();
        descriptionLabel = new System.Windows.Forms.Label();
        descriptionTextBox = new System.Windows.Forms.TextBox();
        cancelButton = new System.Windows.Forms.Button();
        saveButton = new System.Windows.Forms.Button();
        SuspendLayout();

        // 
        // nameLabel
        // 
        nameLabel.AutoSize = true;
        nameLabel.Font = new System.Drawing.Font(
            "Bahnschrift Semibold",
            9F,
            System.Drawing.FontStyle.Bold,
            System.Drawing.GraphicsUnit.Point,
            ((byte)0));
        nameLabel.Location = new System.Drawing.Point(24, 24);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new System.Drawing.Size(117, 20);
        nameLabel.TabIndex = 0;
        nameLabel.Text = "Category Name";

        // 
        // nameTextBox
        // 
        nameTextBox.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;
        nameTextBox.Font = new System.Drawing.Font(
            "Bahnschrift",
            10.5F,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point,
            ((byte)0));
        nameTextBox.ForeColor =
            System.Drawing.SystemColors.ControlText;
        nameTextBox.Location = new System.Drawing.Point(24, 46);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new System.Drawing.Size(452, 31);
        nameTextBox.TabIndex = 0;

        // 
        // descriptionLabel
        // 
        descriptionLabel.AutoSize = true;
        descriptionLabel.Font = new System.Drawing.Font(
            "Bahnschrift Semibold",
            9F,
            System.Drawing.FontStyle.Bold,
            System.Drawing.GraphicsUnit.Point,
            ((byte)0));
        descriptionLabel.Location = new System.Drawing.Point(24, 88);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new System.Drawing.Size(87, 20);
        descriptionLabel.TabIndex = 1;
        descriptionLabel.Text = "Description";

        // 
        // descriptionTextBox
        // 
        descriptionTextBox.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;
        descriptionTextBox.Font = new System.Drawing.Font(
            "Bahnschrift",
            10.5F,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point,
            ((byte)0));
        descriptionTextBox.Location = new System.Drawing.Point(24, 110);
        descriptionTextBox.Multiline = true;
        descriptionTextBox.Name = "descriptionTextBox";
        descriptionTextBox.ScrollBars =
            System.Windows.Forms.ScrollBars.Vertical;
        descriptionTextBox.Size = new System.Drawing.Size(452, 120);
        descriptionTextBox.TabIndex = 1;

        // 
        // cancelButton
        // 
        cancelButton.DialogResult =
            System.Windows.Forms.DialogResult.Cancel;
        cancelButton.Font = new System.Drawing.Font(
            "Bahnschrift Semibold",
            9F,
            System.Drawing.FontStyle.Bold,
            System.Drawing.GraphicsUnit.Point,
            ((byte)0));
        cancelButton.Location = new System.Drawing.Point(282, 326);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 30);
        cancelButton.TabIndex = 2;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;

        // 
        // saveButton
        // 
        saveButton.Font = new System.Drawing.Font(
            "Bahnschrift Semibold",
            9F,
            System.Drawing.FontStyle.Bold,
            System.Drawing.GraphicsUnit.Point,
            ((byte)0));
        saveButton.Location = new System.Drawing.Point(388, 326);
        saveButton.Name = "saveButton";
        saveButton.Size = new System.Drawing.Size(100, 30);
        saveButton.TabIndex = 3;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;

        // 
        // EditCategoryForm
        // 
        AcceptButton = saveButton;
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.SystemColors.Window;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(500, 368);

        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(descriptionLabel);
        Controls.Add(descriptionTextBox);
        Controls.Add(cancelButton);
        Controls.Add(saveButton);

        Font = new System.Drawing.Font(
            "Bahnschrift",
            9F,
            System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point,
            ((byte)0));

        FormBorderStyle =
            System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition =
            System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Edit Category";

        ResumeLayout(false);
        PerformLayout();
    }
}