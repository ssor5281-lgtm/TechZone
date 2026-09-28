#nullable disable

using System.ComponentModel;

namespace TechZone.UI.Forms.Edit;

partial class EditUserForm
{
    private IContainer components = null!;

    private PictureBox profilePictureBox;
    private Panel imagePanel;
    private Button chooseImageButton;
    private Button removeImageButton;
    private Label imageHintLabel;

    private Label formTitleLabel;
    private Label formSubtitleLabel;

    private Label usernameLabel;
    private TextBox usernameTextBox;

    private Label roleLabel;
    private ComboBox roleComboBox;

    private CheckBox resetPasswordCheckBox;

    private Label newPasswordLabel;
    private TextBox newPasswordTextBox;

    private Label confirmPasswordLabel;
    private TextBox confirmPasswordTextBox;

    private CheckBox showPasswordCheckBox;

    private Panel footerPanel;
    private Button cancelButton;
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
        profilePictureBox = new System.Windows.Forms.PictureBox();
        chooseImageButton = new System.Windows.Forms.Button();
        removeImageButton = new System.Windows.Forms.Button();
        imageHintLabel = new System.Windows.Forms.Label();
        formTitleLabel = new System.Windows.Forms.Label();
        formSubtitleLabel = new System.Windows.Forms.Label();
        usernameLabel = new System.Windows.Forms.Label();
        usernameTextBox = new System.Windows.Forms.TextBox();
        roleLabel = new System.Windows.Forms.Label();
        roleComboBox = new System.Windows.Forms.ComboBox();
        resetPasswordCheckBox = new System.Windows.Forms.CheckBox();
        newPasswordLabel = new System.Windows.Forms.Label();
        newPasswordTextBox = new System.Windows.Forms.TextBox();
        confirmPasswordLabel = new System.Windows.Forms.Label();
        confirmPasswordTextBox = new System.Windows.Forms.TextBox();
        showPasswordCheckBox = new System.Windows.Forms.CheckBox();
        footerPanel = new System.Windows.Forms.Panel();
        cancelButton = new System.Windows.Forms.Button();
        saveButton = new System.Windows.Forms.Button();
        imagePanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
        footerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // imagePanel
        // 
        imagePanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        imagePanel.Controls.Add(profilePictureBox);
        imagePanel.Location = new System.Drawing.Point(28, 28);
        imagePanel.Name = "imagePanel";
        imagePanel.Size = new System.Drawing.Size(230, 230);
        imagePanel.TabIndex = 0;
        // 
        // profilePictureBox
        // 
        profilePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)((byte)241)), ((int)((byte)245)), ((int)((byte)249)));
        profilePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
        profilePictureBox.Location = new System.Drawing.Point(0, 0);
        profilePictureBox.Name = "profilePictureBox";
        profilePictureBox.Size = new System.Drawing.Size(228, 228);
        profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        profilePictureBox.TabIndex = 1;
        profilePictureBox.TabStop = false;
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
        imageHintLabel.Location = new System.Drawing.Point(28, 314);
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
        formTitleLabel.Size = new System.Drawing.Size(145, 29);
        formTitleLabel.TabIndex = 5;
        formTitleLabel.Text = "User Details";
        // 
        // formSubtitleLabel
        // 
        formSubtitleLabel.AutoSize = true;
        formSubtitleLabel.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
        formSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        formSubtitleLabel.Location = new System.Drawing.Point(288, 57);
        formSubtitleLabel.Name = "formSubtitleLabel";
        formSubtitleLabel.Size = new System.Drawing.Size(268, 18);
        formSubtitleLabel.TabIndex = 6;
        formSubtitleLabel.Text = "Update this user\'s account information.";
        // 
        // usernameLabel
        // 
        usernameLabel.AutoSize = true;
        usernameLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
        usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        usernameLabel.Location = new System.Drawing.Point(286, 91);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new System.Drawing.Size(77, 18);
        usernameLabel.TabIndex = 7;
        usernameLabel.Text = "Username";
        // 
        // usernameTextBox
        // 
        usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        usernameTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        usernameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        usernameTextBox.Location = new System.Drawing.Point(286, 112);
        usernameTextBox.Margin = new System.Windows.Forms.Padding(0);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.Size = new System.Drawing.Size(390, 28);
        usernameTextBox.TabIndex = 0;
        // 
        // roleLabel
        // 
        roleLabel.AutoSize = true;
        roleLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
        roleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        roleLabel.Location = new System.Drawing.Point(286, 157);
        roleLabel.Name = "roleLabel";
        roleLabel.Size = new System.Drawing.Size(38, 18);
        roleLabel.TabIndex = 8;
        roleLabel.Text = "Role";
        // 
        // roleComboBox
        // 
        roleComboBox.BackColor = System.Drawing.Color.White;
        roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        roleComboBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        roleComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        roleComboBox.FormattingEnabled = true;
        roleComboBox.Location = new System.Drawing.Point(286, 178);
        roleComboBox.Margin = new System.Windows.Forms.Padding(0);
        roleComboBox.Name = "roleComboBox";
        roleComboBox.Size = new System.Drawing.Size(390, 29);
        roleComboBox.TabIndex = 1;
        // 
        // resetPasswordCheckBox
        // 
        resetPasswordCheckBox.AutoSize = true;
        resetPasswordCheckBox.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
        resetPasswordCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        resetPasswordCheckBox.Location = new System.Drawing.Point(286, 223);
        resetPasswordCheckBox.Margin = new System.Windows.Forms.Padding(0);
        resetPasswordCheckBox.Name = "resetPasswordCheckBox";
        resetPasswordCheckBox.Size = new System.Drawing.Size(140, 22);
        resetPasswordCheckBox.TabIndex = 2;
        resetPasswordCheckBox.Text = "Reset Password";
        resetPasswordCheckBox.UseVisualStyleBackColor = true;
        // 
        // newPasswordLabel
        // 
        newPasswordLabel.AutoSize = true;
        newPasswordLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
        newPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        newPasswordLabel.Location = new System.Drawing.Point(286, 257);
        newPasswordLabel.Name = "newPasswordLabel";
        newPasswordLabel.Size = new System.Drawing.Size(110, 18);
        newPasswordLabel.TabIndex = 9;
        newPasswordLabel.Text = "New Password";
        newPasswordLabel.Visible = false;
        // 
        // newPasswordTextBox
        // 
        newPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        newPasswordTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        newPasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        newPasswordTextBox.Location = new System.Drawing.Point(286, 278);
        newPasswordTextBox.Margin = new System.Windows.Forms.Padding(0);
        newPasswordTextBox.Name = "newPasswordTextBox";
        newPasswordTextBox.Size = new System.Drawing.Size(390, 28);
        newPasswordTextBox.TabIndex = 3;
        newPasswordTextBox.UseSystemPasswordChar = true;
        newPasswordTextBox.Visible = false;
        // 
        // confirmPasswordLabel
        // 
        confirmPasswordLabel.AutoSize = true;
        confirmPasswordLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F);
        confirmPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        confirmPasswordLabel.Location = new System.Drawing.Point(286, 323);
        confirmPasswordLabel.Name = "confirmPasswordLabel";
        confirmPasswordLabel.Size = new System.Drawing.Size(132, 18);
        confirmPasswordLabel.TabIndex = 10;
        confirmPasswordLabel.Text = "Confirm Password";
        confirmPasswordLabel.Visible = false;
        // 
        // confirmPasswordTextBox
        // 
        confirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        confirmPasswordTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
        confirmPasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        confirmPasswordTextBox.Location = new System.Drawing.Point(286, 344);
        confirmPasswordTextBox.Margin = new System.Windows.Forms.Padding(0);
        confirmPasswordTextBox.Name = "confirmPasswordTextBox";
        confirmPasswordTextBox.Size = new System.Drawing.Size(390, 28);
        confirmPasswordTextBox.TabIndex = 4;
        confirmPasswordTextBox.UseSystemPasswordChar = true;
        confirmPasswordTextBox.Visible = false;
        // 
        // showPasswordCheckBox
        // 
        showPasswordCheckBox.AutoSize = true;
        showPasswordCheckBox.Font = new System.Drawing.Font("Bahnschrift", 8.5F);
        showPasswordCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        showPasswordCheckBox.Location = new System.Drawing.Point(286, 377);
        showPasswordCheckBox.Margin = new System.Windows.Forms.Padding(0);
        showPasswordCheckBox.Name = "showPasswordCheckBox";
        showPasswordCheckBox.Size = new System.Drawing.Size(138, 22);
        showPasswordCheckBox.TabIndex = 5;
        showPasswordCheckBox.Text = "Show Password";
        showPasswordCheckBox.UseVisualStyleBackColor = true;
        showPasswordCheckBox.Visible = false;
        // 
        // footerPanel
        // 
        footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        footerPanel.Controls.Add(cancelButton);
        footerPanel.Controls.Add(saveButton);
        footerPanel.Location = new System.Drawing.Point(0, 402);
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
        cancelButton.TabIndex = 6;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        // 
        // saveButton
        // 
        saveButton.AutoSize = true;
        saveButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
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
        saveButton.TabIndex = 7;
        saveButton.Text = "Save Changes";
        saveButton.UseVisualStyleBackColor = false;
        // 
        // EditUserForm
        // 
        AcceptButton = saveButton;
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.White;
        CancelButton = cancelButton;
        ClientSize = new System.Drawing.Size(704, 472);
        Controls.Add(footerPanel);
        Controls.Add(showPasswordCheckBox);
        Controls.Add(confirmPasswordTextBox);
        Controls.Add(confirmPasswordLabel);
        Controls.Add(newPasswordTextBox);
        Controls.Add(newPasswordLabel);
        Controls.Add(resetPasswordCheckBox);
        Controls.Add(roleComboBox);
        Controls.Add(roleLabel);
        Controls.Add(usernameTextBox);
        Controls.Add(usernameLabel);
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
        Text = "Edit User";
        imagePanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)profilePictureBox).EndInit();
        footerPanel.ResumeLayout(false);
        footerPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}