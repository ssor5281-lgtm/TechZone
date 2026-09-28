using System.ComponentModel;

namespace TechZone.UI.Forms.Edit;

partial class UserProfile
{
private IContainer components = null!;


private Panel headerPanel;
private Label titleLabel;
private Label subtitleLabel;

private Panel avatarPanel;
private PictureBox profilePictureBox;
private Button chooseImageButton;
private Button removeImageButton;
private Label imageHintLabel;

private Panel detailsPanel;

private Label displayNameTitleLabel;
private TextBox displayNameTextBox;

private Label usernameTitleLabel;
private Label usernameLabel;

private Label roleTitleLabel;
private Label roleLabel;

private Label statusTitleLabel;
private Label statusLabel;

private Label createdTitleLabel;
private Label createdLabel;

private Panel footerPanel;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Button saveButton;

protected override void Dispose(bool disposing)
{
    if (disposing)
        components?.Dispose();

    base.Dispose(disposing);
}

/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
{
    headerPanel = new System.Windows.Forms.Panel();
    titleLabel = new System.Windows.Forms.Label();
    subtitleLabel = new System.Windows.Forms.Label();
    avatarPanel = new System.Windows.Forms.Panel();
    profilePictureBox = new System.Windows.Forms.PictureBox();
    chooseImageButton = new System.Windows.Forms.Button();
    removeImageButton = new System.Windows.Forms.Button();
    imageHintLabel = new System.Windows.Forms.Label();
    detailsPanel = new System.Windows.Forms.Panel();
    displayNameTitleLabel = new System.Windows.Forms.Label();
    displayNameTextBox = new System.Windows.Forms.TextBox();
    usernameTitleLabel = new System.Windows.Forms.Label();
    usernameLabel = new System.Windows.Forms.Label();
    roleTitleLabel = new System.Windows.Forms.Label();
    roleLabel = new System.Windows.Forms.Label();
    statusTitleLabel = new System.Windows.Forms.Label();
    statusLabel = new System.Windows.Forms.Label();
    createdTitleLabel = new System.Windows.Forms.Label();
    createdLabel = new System.Windows.Forms.Label();
    footerPanel = new System.Windows.Forms.Panel();
    cancelButton = new System.Windows.Forms.Button();
    saveButton = new System.Windows.Forms.Button();
    headerPanel.SuspendLayout();
    avatarPanel.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
    detailsPanel.SuspendLayout();
    footerPanel.SuspendLayout();
    SuspendLayout();
    // 
    // headerPanel
    // 
    headerPanel.BackColor = System.Drawing.Color.White;
    headerPanel.Controls.Add(titleLabel);
    headerPanel.Controls.Add(subtitleLabel);
    headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
    headerPanel.Location = new System.Drawing.Point(0, 0);
    headerPanel.Name = "headerPanel";
    headerPanel.Size = new System.Drawing.Size(620, 88);
    headerPanel.TabIndex = 0;
    // 
    // titleLabel
    // 
    titleLabel.AutoSize = true;
    titleLabel.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold);
    titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
    titleLabel.Location = new System.Drawing.Point(28, 18);
    titleLabel.Name = "titleLabel";
    titleLabel.Size = new System.Drawing.Size(150, 36);
    titleLabel.TabIndex = 0;
    titleLabel.Text = "My Profile";
    // 
    // subtitleLabel
    // 
    subtitleLabel.AutoSize = true;
    subtitleLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
    subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    subtitleLabel.Location = new System.Drawing.Point(30, 52);
    subtitleLabel.Name = "subtitleLabel";
    subtitleLabel.Size = new System.Drawing.Size(321, 19);
    subtitleLabel.TabIndex = 1;
    subtitleLabel.Text = "Manage your personal account information";
    // 
    // avatarPanel
    // 
    avatarPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
    avatarPanel.Controls.Add(profilePictureBox);
    avatarPanel.Controls.Add(chooseImageButton);
    avatarPanel.Controls.Add(removeImageButton);
    avatarPanel.Controls.Add(imageHintLabel);
    avatarPanel.Location = new System.Drawing.Point(28, 104);
    avatarPanel.Name = "avatarPanel";
    avatarPanel.Size = new System.Drawing.Size(564, 150);
    avatarPanel.TabIndex = 1;
    // 
    // profilePictureBox
    // 
    profilePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)((byte)219)), ((int)((byte)234)), ((int)((byte)254)));
    profilePictureBox.Location = new System.Drawing.Point(24, 22);
    profilePictureBox.Name = "profilePictureBox";
    profilePictureBox.Size = new System.Drawing.Size(106, 106);
    profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
    profilePictureBox.TabIndex = 0;
    profilePictureBox.TabStop = false;
    // 
    // chooseImageButton
    // 
    chooseImageButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
    chooseImageButton.FlatAppearance.BorderSize = 0;
    chooseImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    chooseImageButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold);
    chooseImageButton.ForeColor = System.Drawing.Color.White;
    chooseImageButton.Location = new System.Drawing.Point(154, 38);
    chooseImageButton.Name = "chooseImageButton";
    chooseImageButton.Size = new System.Drawing.Size(125, 36);
    chooseImageButton.TabIndex = 1;
    chooseImageButton.Text = "Choose Image";
    chooseImageButton.UseVisualStyleBackColor = false;
    // 
    // removeImageButton
    // 
    removeImageButton.BackColor = System.Drawing.Color.White;
    removeImageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
    removeImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    removeImageButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
    removeImageButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
    removeImageButton.Location = new System.Drawing.Point(289, 38);
    removeImageButton.Name = "removeImageButton";
    removeImageButton.Size = new System.Drawing.Size(110, 36);
    removeImageButton.TabIndex = 2;
    removeImageButton.Text = "Remove";
    removeImageButton.UseVisualStyleBackColor = false;
    removeImageButton.Visible = false;
    // 
    // imageHintLabel
    // 
    imageHintLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
    imageHintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    imageHintLabel.Location = new System.Drawing.Point(154, 82);
    imageHintLabel.Name = "imageHintLabel";
    imageHintLabel.Size = new System.Drawing.Size(360, 42);
    imageHintLabel.TabIndex = 3;
    imageHintLabel.Text = ("Choose a profile image to personalize your account.\r\nJPG, PNG and other common im" + "age formats are supported.");
    // 
    // detailsPanel
    // 
    detailsPanel.BackColor = System.Drawing.Color.White;
    detailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    detailsPanel.Controls.Add(displayNameTitleLabel);
    detailsPanel.Controls.Add(displayNameTextBox);
    detailsPanel.Controls.Add(usernameTitleLabel);
    detailsPanel.Controls.Add(usernameLabel);
    detailsPanel.Controls.Add(roleTitleLabel);
    detailsPanel.Controls.Add(roleLabel);
    detailsPanel.Controls.Add(statusTitleLabel);
    detailsPanel.Controls.Add(statusLabel);
    detailsPanel.Controls.Add(createdTitleLabel);
    detailsPanel.Controls.Add(createdLabel);
    detailsPanel.Location = new System.Drawing.Point(28, 274);
    detailsPanel.Name = "detailsPanel";
    detailsPanel.Size = new System.Drawing.Size(564, 192);
    detailsPanel.TabIndex = 2;
    // 
    // displayNameTitleLabel
    // 
    displayNameTitleLabel.AutoSize = true;
    displayNameTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
    displayNameTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    displayNameTitleLabel.Location = new System.Drawing.Point(20, 17);
    displayNameTitleLabel.Name = "displayNameTitleLabel";
    displayNameTitleLabel.Size = new System.Drawing.Size(101, 18);
    displayNameTitleLabel.TabIndex = 0;
    displayNameTitleLabel.Text = "Display Name";
    // 
    // displayNameTextBox
    // 
    displayNameTextBox.BackColor = System.Drawing.Color.White;
    displayNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    displayNameTextBox.Font = new System.Drawing.Font("Bahnschrift", 10F);
    displayNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
    displayNameTextBox.Location = new System.Drawing.Point(20, 38);
    displayNameTextBox.MaxLength = 100;
    displayNameTextBox.Name = "displayNameTextBox";
    displayNameTextBox.Size = new System.Drawing.Size(522, 28);
    displayNameTextBox.TabIndex = 1;
    // 
    // usernameTitleLabel
    // 
    usernameTitleLabel.AutoSize = true;
    usernameTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
    usernameTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    usernameTitleLabel.Location = new System.Drawing.Point(20, 82);
    usernameTitleLabel.Name = "usernameTitleLabel";
    usernameTitleLabel.Size = new System.Drawing.Size(77, 18);
    usernameTitleLabel.TabIndex = 2;
    usernameTitleLabel.Text = "Username";
    // 
    // usernameLabel
    // 
    usernameLabel.AutoSize = true;
    usernameLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
    usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
    usernameLabel.Location = new System.Drawing.Point(20, 103);
    usernameLabel.Name = "usernameLabel";
    usernameLabel.Size = new System.Drawing.Size(18, 21);
    usernameLabel.TabIndex = 3;
    usernameLabel.Text = "-";
    // 
    // roleTitleLabel
    // 
    roleTitleLabel.AutoSize = true;
    roleTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
    roleTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    roleTitleLabel.Location = new System.Drawing.Point(200, 82);
    roleTitleLabel.Name = "roleTitleLabel";
    roleTitleLabel.Size = new System.Drawing.Size(38, 18);
    roleTitleLabel.TabIndex = 4;
    roleTitleLabel.Text = "Role";
    // 
    // roleLabel
    // 
    roleLabel.AutoSize = true;
    roleLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
    roleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
    roleLabel.Location = new System.Drawing.Point(200, 103);
    roleLabel.Name = "roleLabel";
    roleLabel.Size = new System.Drawing.Size(18, 21);
    roleLabel.TabIndex = 5;
    roleLabel.Text = "-";
    // 
    // statusTitleLabel
    // 
    statusTitleLabel.AutoSize = true;
    statusTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
    statusTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    statusTitleLabel.Location = new System.Drawing.Point(335, 82);
    statusTitleLabel.Name = "statusTitleLabel";
    statusTitleLabel.Size = new System.Drawing.Size(51, 18);
    statusTitleLabel.TabIndex = 6;
    statusTitleLabel.Text = "Status";
    // 
    // statusLabel
    // 
    statusLabel.AutoSize = true;
    statusLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
    statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
    statusLabel.Location = new System.Drawing.Point(335, 103);
    statusLabel.Name = "statusLabel";
    statusLabel.Size = new System.Drawing.Size(57, 21);
    statusLabel.TabIndex = 7;
    statusLabel.Text = "Active";
    // 
    // createdTitleLabel
    // 
    createdTitleLabel.AutoSize = true;
    createdTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
    createdTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
    createdTitleLabel.Location = new System.Drawing.Point(430, 82);
    createdTitleLabel.Name = "createdTitleLabel";
    createdTitleLabel.Size = new System.Drawing.Size(60, 18);
    createdTitleLabel.TabIndex = 8;
    createdTitleLabel.Text = "Created";
    // 
    // createdLabel
    // 
    createdLabel.AutoSize = true;
    createdLabel.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
    createdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
    createdLabel.Location = new System.Drawing.Point(430, 103);
    createdLabel.Name = "createdLabel";
    createdLabel.Size = new System.Drawing.Size(18, 21);
    createdLabel.TabIndex = 9;
    createdLabel.Text = "-";
    // 
    // footerPanel
    // 
    footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
    footerPanel.Controls.Add(cancelButton);
    footerPanel.Controls.Add(saveButton);
    footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
    footerPanel.Location = new System.Drawing.Point(0, 490);
    footerPanel.Name = "footerPanel";
    footerPanel.Size = new System.Drawing.Size(620, 70);
    footerPanel.TabIndex = 3;
    // 
    // cancelButton
    // 
    cancelButton.BackColor = System.Drawing.Color.White;
    cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
    cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    cancelButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
    cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
    cancelButton.Location = new System.Drawing.Point(354, 16);
    cancelButton.Name = "cancelButton";
    cancelButton.Size = new System.Drawing.Size(105, 38);
    cancelButton.TabIndex = 0;
    cancelButton.Text = "Cancel";
    cancelButton.UseVisualStyleBackColor = false;
    // 
    // saveButton
    // 
    saveButton.AutoSize = true;
    saveButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
    saveButton.FlatAppearance.BorderSize = 0;
    saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    saveButton.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
    saveButton.ForeColor = System.Drawing.Color.White;
    saveButton.Location = new System.Drawing.Point(465, 16);
    saveButton.Name = "saveButton";
    saveButton.Size = new System.Drawing.Size(127, 38);
    saveButton.TabIndex = 1;
    saveButton.Text = "Save Changes";
    saveButton.UseVisualStyleBackColor = false;
    // 
    // UserProfile
    // 
    BackColor = System.Drawing.Color.White;
    ClientSize = new System.Drawing.Size(620, 560);
    Controls.Add(headerPanel);
    Controls.Add(avatarPanel);
    Controls.Add(detailsPanel);
    Controls.Add(footerPanel);
    Font = new System.Drawing.Font("Bahnschrift", 10F);
    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
    MaximizeBox = false;
    MinimizeBox = false;
    ShowInTaskbar = false;
    StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
    Text = "My Profile";
    headerPanel.ResumeLayout(false);
    headerPanel.PerformLayout();
    avatarPanel.ResumeLayout(false);
    ((System.ComponentModel.ISupportInitialize)profilePictureBox).EndInit();
    detailsPanel.ResumeLayout(false);
    detailsPanel.PerformLayout();
    footerPanel.ResumeLayout(false);
    footerPanel.PerformLayout();
    ResumeLayout(false);
}

}
