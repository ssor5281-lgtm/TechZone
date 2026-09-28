#nullable disable

using System.ComponentModel;

namespace TechZone.UI.Forms.Create;

partial class AddUserForm
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

    private Label passwordLabel;
    private TextBox passwordTextBox;

    private Label confirmPasswordLabel;
    private TextBox confirmPasswordTextBox;

    private Label roleLabel;
    private ComboBox roleComboBox;

    private CheckBox showPasswordCheckBox;

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
        imagePanel = new Panel();
        profilePictureBox = new PictureBox();

        chooseImageButton = new Button();
        removeImageButton = new Button();
        imageHintLabel = new Label();

        formTitleLabel = new Label();
        formSubtitleLabel = new Label();

        usernameLabel = new Label();
        usernameTextBox = new TextBox();

        passwordLabel = new Label();
        passwordTextBox = new TextBox();

        confirmPasswordLabel = new Label();
        confirmPasswordTextBox = new TextBox();

        roleLabel = new Label();
        roleComboBox = new ComboBox();

        showPasswordCheckBox = new CheckBox();

        footerPanel = new Panel();
        cancelButton = new Button();
        addButton = new Button();

        imagePanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
        footerPanel.SuspendLayout();
        SuspendLayout();

        imagePanel.BackColor =
            System.Drawing.Color.FromArgb(248, 250, 252);

        imagePanel.BorderStyle =
            BorderStyle.FixedSingle;

        imagePanel.Controls.Add(profilePictureBox);

        imagePanel.Location =
            new System.Drawing.Point(28, 28);

        imagePanel.Name =
            "imagePanel";

        imagePanel.Size =
            new System.Drawing.Size(230, 230);

        imagePanel.TabIndex = 0;

        profilePictureBox.BackColor =
            System.Drawing.Color.FromArgb(241, 245, 249);

        profilePictureBox.Dock =
            DockStyle.Fill;

        profilePictureBox.Location =
            new System.Drawing.Point(0, 0);

        profilePictureBox.Name =
            "profilePictureBox";

        profilePictureBox.Size =
            new System.Drawing.Size(228, 228);

        profilePictureBox.SizeMode =
            PictureBoxSizeMode.CenterImage;

        profilePictureBox.TabIndex = 1;
        profilePictureBox.TabStop = false;

        chooseImageButton.BackColor =
            System.Drawing.Color.FromArgb(
                239,
                246,
                255);

        chooseImageButton.Cursor =
            Cursors.Hand;

        chooseImageButton.FlatAppearance.BorderSize = 0;

        chooseImageButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                219,
                234,
                254);

        chooseImageButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                219,
                234,
                254);

        chooseImageButton.FlatStyle =
            FlatStyle.Flat;

        chooseImageButton.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                9F);

        chooseImageButton.ForeColor =
            System.Drawing.Color.FromArgb(
                37,
                99,
                235);

        chooseImageButton.Location =
            new System.Drawing.Point(28, 273);

        chooseImageButton.Margin =
            new Padding(0);

        chooseImageButton.Name =
            "chooseImageButton";

        chooseImageButton.Size =
            new System.Drawing.Size(110, 36);

        chooseImageButton.TabIndex = 2;

        chooseImageButton.Text =
            "Choose Image";

        chooseImageButton.UseVisualStyleBackColor = false;

        removeImageButton.BackColor =
            System.Drawing.Color.White;

        removeImageButton.Cursor =
            Cursors.Hand;

        removeImageButton.FlatAppearance.BorderColor =
            System.Drawing.Color.FromArgb(
                226,
                232,
                240);

        removeImageButton.FlatAppearance.BorderSize = 1;

        removeImageButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                254,
                242,
                242);

        removeImageButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                254,
                242,
                242);

        removeImageButton.FlatStyle =
            FlatStyle.Flat;

        removeImageButton.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                9F);

        removeImageButton.ForeColor =
            System.Drawing.Color.FromArgb(
                220,
                38,
                38);

        removeImageButton.Location =
            new System.Drawing.Point(148, 273);

        removeImageButton.Margin =
            new Padding(0);

        removeImageButton.Name =
            "removeImageButton";

        removeImageButton.Size =
            new System.Drawing.Size(110, 36);

        removeImageButton.TabIndex = 3;

        removeImageButton.Text =
            "Remove";

        removeImageButton.UseVisualStyleBackColor = false;

        imageHintLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                8.5F);

        imageHintLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                100,
                116,
                139);

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
            ContentAlignment.TopCenter;

        formTitleLabel.AutoSize = true;

        formTitleLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                14F);

        formTitleLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                15,
                23,
                42);

        formTitleLabel.Location =
            new System.Drawing.Point(286, 28);

        formTitleLabel.Name =
            "formTitleLabel";

        formTitleLabel.Size =
            new System.Drawing.Size(143, 29);

        formTitleLabel.TabIndex = 5;

        formTitleLabel.Text =
            "User Details";

        formSubtitleLabel.AutoSize = true;

        formSubtitleLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                8.5F);

        formSubtitleLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                100,
                116,
                139);

        formSubtitleLabel.Location =
            new System.Drawing.Point(288, 57);

        formSubtitleLabel.Name =
            "formSubtitleLabel";

        formSubtitleLabel.Size =
            new System.Drawing.Size(286, 18);

        formSubtitleLabel.TabIndex = 6;

        formSubtitleLabel.Text =
            "Enter the account information for this user.";

        usernameLabel.AutoSize = true;

        usernameLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        usernameLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51,
                65,
                85);

        usernameLabel.Location =
            new System.Drawing.Point(286, 91);

        usernameLabel.Name =
            "usernameLabel";

        usernameLabel.Size =
            new System.Drawing.Size(78, 18);

        usernameLabel.TabIndex = 7;

        usernameLabel.Text =
            "Username";

        usernameTextBox.BorderStyle =
            BorderStyle.FixedSingle;

        usernameTextBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        usernameTextBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15,
                23,
                42);

        usernameTextBox.Location =
            new System.Drawing.Point(286, 112);

        usernameTextBox.Margin =
            new Padding(0);

        usernameTextBox.Name =
            "usernameTextBox";

        usernameTextBox.Size =
            new System.Drawing.Size(390, 28);

        usernameTextBox.TabIndex = 0;

        passwordLabel.AutoSize = true;

        passwordLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        passwordLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51,
                65,
                85);

        passwordLabel.Location =
            new System.Drawing.Point(286, 157);

        passwordLabel.Name =
            "passwordLabel";

        passwordLabel.Size =
            new System.Drawing.Size(75, 18);

        passwordLabel.TabIndex = 8;

        passwordLabel.Text =
            "Password";

        passwordTextBox.BorderStyle =
            BorderStyle.FixedSingle;

        passwordTextBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        passwordTextBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15,
                23,
                42);

        passwordTextBox.Location =
            new System.Drawing.Point(286, 178);

        passwordTextBox.Margin =
            new Padding(0);

        passwordTextBox.Name =
            "passwordTextBox";

        passwordTextBox.Size =
            new System.Drawing.Size(390, 28);

        passwordTextBox.TabIndex = 1;

        passwordTextBox.UseSystemPasswordChar = true;

        confirmPasswordLabel.AutoSize = true;

        confirmPasswordLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        confirmPasswordLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51,
                65,
                85);

        confirmPasswordLabel.Location =
            new System.Drawing.Point(286, 223);

        confirmPasswordLabel.Name =
            "confirmPasswordLabel";

        confirmPasswordLabel.Size =
            new System.Drawing.Size(129, 18);

        confirmPasswordLabel.TabIndex = 9;

        confirmPasswordLabel.Text =
            "Confirm Password";

        confirmPasswordTextBox.BorderStyle =
            BorderStyle.FixedSingle;

        confirmPasswordTextBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        confirmPasswordTextBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15,
                23,
                42);

        confirmPasswordTextBox.Location =
            new System.Drawing.Point(286, 244);

        confirmPasswordTextBox.Margin =
            new Padding(0);

        confirmPasswordTextBox.Name =
            "confirmPasswordTextBox";

        confirmPasswordTextBox.Size =
            new System.Drawing.Size(390, 28);

        confirmPasswordTextBox.TabIndex = 2;

        confirmPasswordTextBox.UseSystemPasswordChar = true;

        showPasswordCheckBox.AutoSize = true;

        showPasswordCheckBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                8.5F);

        showPasswordCheckBox.ForeColor =
            System.Drawing.Color.FromArgb(
                100,
                116,
                139);

        showPasswordCheckBox.Location =
            new System.Drawing.Point(286, 280);

        showPasswordCheckBox.Margin =
            new Padding(0);

        showPasswordCheckBox.Name =
            "showPasswordCheckBox";

        showPasswordCheckBox.Size =
            new System.Drawing.Size(112, 21);

        showPasswordCheckBox.TabIndex = 4;

        showPasswordCheckBox.Text =
            "Show Password";

        showPasswordCheckBox.UseVisualStyleBackColor = true;

        roleLabel.AutoSize = true;

        roleLabel.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        roleLabel.ForeColor =
            System.Drawing.Color.FromArgb(
                51,
                65,
                85);

        roleLabel.Location =
            new System.Drawing.Point(286, 310);

        roleLabel.Name =
            "roleLabel";

        roleLabel.Size =
            new System.Drawing.Size(38, 18);

        roleLabel.TabIndex = 10;

        roleLabel.Text =
            "Role";

        roleComboBox.BackColor =
            System.Drawing.Color.White;

        roleComboBox.DropDownStyle =
            ComboBoxStyle.DropDownList;

        roleComboBox.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                10F);

        roleComboBox.ForeColor =
            System.Drawing.Color.FromArgb(
                15,
                23,
                42);

        roleComboBox.FormattingEnabled = true;

        roleComboBox.Location =
            new System.Drawing.Point(286, 331);

        roleComboBox.Margin =
            new Padding(0);

        roleComboBox.Name =
            "roleComboBox";

        roleComboBox.Size =
            new System.Drawing.Size(390, 29);

        roleComboBox.TabIndex = 3;

        footerPanel.BackColor =
            System.Drawing.Color.FromArgb(
                248,
                250,
                252);

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
            DialogResult.Cancel;

        cancelButton.FlatAppearance.BorderColor =
            System.Drawing.Color.FromArgb(
                203,
                213,
                225);

        cancelButton.FlatAppearance.BorderSize = 1;

        cancelButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                241,
                245,
                249);

        cancelButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                248,
                250,
                252);

        cancelButton.FlatStyle =
            FlatStyle.Flat;

        cancelButton.Font =
            new System.Drawing.Font(
                "Bahnschrift",
                9F);

        cancelButton.ForeColor =
            System.Drawing.Color.FromArgb(
                71,
                85,
                105);

        cancelButton.Location =
            new System.Drawing.Point(462, 17);

        cancelButton.Margin =
            new Padding(0);

        cancelButton.Name =
            "cancelButton";

        cancelButton.Size =
            new System.Drawing.Size(100, 36);

        cancelButton.TabIndex = 5;

        cancelButton.Text =
            "Cancel";

        cancelButton.UseVisualStyleBackColor = false;

        addButton.BackColor =
            System.Drawing.Color.FromArgb(
                37,
                99,
                235);

        addButton.FlatAppearance.BorderSize = 0;

        addButton.FlatAppearance.MouseDownBackColor =
            System.Drawing.Color.FromArgb(
                29,
                78,
                216);

        addButton.FlatAppearance.MouseOverBackColor =
            System.Drawing.Color.FromArgb(
                59,
                130,
                246);

        addButton.FlatStyle =
            FlatStyle.Flat;

        addButton.Font =
            new System.Drawing.Font(
                "Bahnschrift SemiBold",
                9F);

        addButton.ForeColor =
            System.Drawing.Color.White;

        addButton.Location =
            new System.Drawing.Point(570, 17);

        addButton.Margin =
            new Padding(0);

        addButton.Name =
            "addButton";

        addButton.Size =
            new System.Drawing.Size(106, 36);

        addButton.TabIndex = 6;

        addButton.Text =
            "Add User";

        addButton.UseVisualStyleBackColor = false;

        AcceptButton = addButton;

        AutoScaleMode =
            AutoScaleMode.None;

        BackColor =
            System.Drawing.Color.White;

        CancelButton = cancelButton;

        ClientSize =
            new System.Drawing.Size(704, 452);

        Controls.Add(footerPanel);
        Controls.Add(roleComboBox);
        Controls.Add(roleLabel);
        Controls.Add(showPasswordCheckBox);
        Controls.Add(confirmPasswordTextBox);
        Controls.Add(confirmPasswordLabel);
        Controls.Add(passwordTextBox);
        Controls.Add(passwordLabel);
        Controls.Add(usernameTextBox);
        Controls.Add(usernameLabel);
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
            FormBorderStyle.FixedDialog;

        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;

        StartPosition =
            FormStartPosition.CenterParent;

        Text =
            "Add User";

        imagePanel.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize)
            profilePictureBox).EndInit();

        footerPanel.ResumeLayout(false);

        ResumeLayout(false);
        PerformLayout();
    }
}