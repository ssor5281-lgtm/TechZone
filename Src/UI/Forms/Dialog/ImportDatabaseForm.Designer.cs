#nullable enable

namespace TechZone.UI.Forms.Dialog;

partial class ImportDatabaseForm
{
    private System.ComponentModel.IContainer? components = null;

    private Label titleLabel = null!;
    private Label descriptionLabel = null!;
    private Label backupLabel = null!;
    private ComboBox backupComboBox = null!;
    private Button importButton = null!;
    private Button cancelButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        titleLabel = new Label();
        descriptionLabel = new Label();
        backupLabel = new Label();
        backupComboBox = new ComboBox();
        importButton = new Button();
        cancelButton = new Button();

        SuspendLayout();

        titleLabel.AutoSize = true;
        titleLabel.Font = new Font(
            "Bahnschrift",
            15F,
            FontStyle.Bold);
        titleLabel.Location = new Point(24, 20);
        titleLabel.Text = "Import Database";

        descriptionLabel.AutoSize = true;
        descriptionLabel.Font = new Font(
            "Bahnschrift",
            9.5F);
        descriptionLabel.ForeColor =
            Color.FromArgb(100, 116, 139);
        descriptionLabel.Location = new Point(25, 52);
        descriptionLabel.Text =
            "Select a TechZone database backup to restore.";

        backupLabel.AutoSize = true;
        backupLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        backupLabel.Location = new Point(25, 94);
        backupLabel.Text = "Database Backup";

        backupComboBox.DropDownStyle =
            ComboBoxStyle.DropDownList;
        backupComboBox.Font = new Font(
            "Bahnschrift",
            10F);
        backupComboBox.FormattingEnabled = true;
        backupComboBox.Location = new Point(25, 118);
        backupComboBox.Size = new Size(430, 29);

        importButton.BackColor = Color.RoyalBlue;
        importButton.FlatAppearance.BorderSize = 0;
        importButton.FlatStyle = FlatStyle.Flat;
        importButton.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        importButton.ForeColor = Color.White;
        importButton.Location = new Point(274, 169);
        importButton.Size = new Size(88, 32);
        importButton.Text = "Import";
        importButton.UseVisualStyleBackColor = false;

        cancelButton.BackColor =
            Color.FromArgb(241, 245, 249);
        cancelButton.FlatAppearance.BorderSize = 0;
        cancelButton.FlatStyle = FlatStyle.Flat;
        cancelButton.Font = new Font(
            "Bahnschrift",
            9.5F);
        cancelButton.ForeColor =
            Color.FromArgb(51, 65, 85);
        cancelButton.Location = new Point(367, 169);
        cancelButton.Size = new Size(88, 32);
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;

        AutoScaleDimensions =
            new SizeF(7F, 15F);
        AutoScaleMode =
            AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(480, 225);
        Controls.Add(cancelButton);
        Controls.Add(importButton);
        Controls.Add(backupComboBox);
        Controls.Add(backupLabel);
        Controls.Add(descriptionLabel);
        Controls.Add(titleLabel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ImportDatabaseForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Import Database";

        ResumeLayout(false);
        PerformLayout();
    }
}