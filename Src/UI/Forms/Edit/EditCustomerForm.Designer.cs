using System.ComponentModel;

namespace TechZone.UI.Forms.Edit;

partial class EditCustomerForm
{
    private IContainer components = null!;

    private Label nameLabel;
    private System.Windows.Forms.TextBox nameTextBox;

    private Label phoneLabel;
    private System.Windows.Forms.TextBox phoneTextBox;

    private Label emailLabel;
    private System.Windows.Forms.TextBox emailTextBox;

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
        nameLabel = new System.Windows.Forms.Label();
        nameTextBox = new System.Windows.Forms.TextBox();
        phoneLabel = new System.Windows.Forms.Label();
        phoneTextBox = new System.Windows.Forms.TextBox();
        emailLabel = new System.Windows.Forms.Label();
        emailTextBox = new System.Windows.Forms.TextBox();
        cancelButton = new System.Windows.Forms.Button();
        saveButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // nameLabel
        // 
        nameLabel.AutoSize = true;
        nameLabel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        nameLabel.Location = new System.Drawing.Point(24, 24);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new System.Drawing.Size(123, 18);
        nameLabel.TabIndex = 0;
        nameLabel.Text = "Customer Name";
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
        // phoneLabel
        // 
        phoneLabel.AutoSize = true;
        phoneLabel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        phoneLabel.Location = new System.Drawing.Point(24, 88);
        phoneLabel.Name = "phoneLabel";
        phoneLabel.Size = new System.Drawing.Size(54, 18);
        phoneLabel.TabIndex = 1;
        phoneLabel.Text = "Phone";
        // 
        // phoneTextBox
        // 
        phoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        phoneTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        phoneTextBox.Location = new System.Drawing.Point(24, 110);
        phoneTextBox.Name = "phoneTextBox";
        phoneTextBox.Size = new System.Drawing.Size(452, 30);
        phoneTextBox.TabIndex = 1;
        // 
        // emailLabel
        // 
        emailLabel.AutoSize = true;
        emailLabel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        emailLabel.Location = new System.Drawing.Point(24, 155);
        emailLabel.Name = "emailLabel";
        emailLabel.Size = new System.Drawing.Size(46, 18);
        emailLabel.TabIndex = 2;
        emailLabel.Text = "Email";
        // 
        // emailTextBox
        // 
        emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        emailTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        emailTextBox.Location = new System.Drawing.Point(24, 177);
        emailTextBox.Name = "emailTextBox";
        emailTextBox.Size = new System.Drawing.Size(452, 30);
        emailTextBox.TabIndex = 2;
        // 
        // cancelButton
        // 
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        cancelButton.Location = new System.Drawing.Point(282, 326);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(100, 30);
        cancelButton.TabIndex = 3;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;
        // 
        // saveButton
        // 
        saveButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        saveButton.Location = new System.Drawing.Point(388, 326);
        saveButton.Name = "saveButton";
        saveButton.Size = new System.Drawing.Size(100, 30);
        saveButton.TabIndex = 4;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;
        // 
        // EditCustomerForm
        // 
        AcceptButton = saveButton;
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.SystemColors.Window;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(500, 368);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(phoneLabel);
        Controls.Add(phoneTextBox);
        Controls.Add(emailLabel);
        Controls.Add(emailTextBox);
        Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Edit Customer";
        ResumeLayout(false);
        PerformLayout();
    }
}