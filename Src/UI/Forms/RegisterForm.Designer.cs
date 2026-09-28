using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Forms;

partial class RegisterForm
{
    private IContainer components = null;

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
        usernameTextBox = new System.Windows.Forms.TextBox();
        passwordTextBox = new System.Windows.Forms.TextBox();
        comfirmPasswordTextBox = new System.Windows.Forms.TextBox();
        closeBtn = new System.Windows.Forms.Button();
        passwordViewBtn = new System.Windows.Forms.Button();
        registerBtn = new NoFocusButton();
        SuspendLayout();
        // 
        // usernameTextBox
        // 
        usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        usernameTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        usernameTextBox.Location = new System.Drawing.Point(499, 211);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.Size = new System.Drawing.Size(276, 22);
        usernameTextBox.TabIndex = 4;
        // 
        // passwordTextBox
        // 
        passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        passwordTextBox.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        passwordTextBox.Location = new System.Drawing.Point(499, 297);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.Size = new System.Drawing.Size(245, 21);
        passwordTextBox.TabIndex = 5;
        // 
        // comfirmPasswordTextBox
        // 
        comfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        comfirmPasswordTextBox.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        comfirmPasswordTextBox.Location = new System.Drawing.Point(499, 383);
        comfirmPasswordTextBox.Name = "comfirmPasswordTextBox";
        comfirmPasswordTextBox.Size = new System.Drawing.Size(245, 21);
        comfirmPasswordTextBox.TabIndex = 6;
        // 
        // closeBtn
        // 
        closeBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
        closeBtn.Font = new System.Drawing.Font("SF Pro Display", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        closeBtn.Location = new System.Drawing.Point(858, 12);
        closeBtn.Name = "closeBtn";
        closeBtn.Size = new System.Drawing.Size(30, 30);
        closeBtn.TabIndex = 1;
        closeBtn.Text = "X";
        closeBtn.UseVisualStyleBackColor = false;
        closeBtn.Click += closeBtn_Click;
        // 
        // passwordViewBtn
        // 
        passwordViewBtn.BackColor = System.Drawing.Color.Transparent;
        passwordViewBtn.BackgroundImage = global::TechZone.Resources.PasswordShow;
        passwordViewBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        passwordViewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
        passwordViewBtn.FlatAppearance.BorderSize = 0;
        passwordViewBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        passwordViewBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        passwordViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        passwordViewBtn.ForeColor = System.Drawing.Color.Transparent;
        passwordViewBtn.Location = new System.Drawing.Point(750, 295);
        passwordViewBtn.Name = "passwordViewBtn";
        passwordViewBtn.Size = new System.Drawing.Size(25, 25);
        passwordViewBtn.TabIndex = 0;
        passwordViewBtn.TabStop = false;
        passwordViewBtn.UseVisualStyleBackColor = false;
        passwordViewBtn.Click += passwordViewBtn_Click;
        // 
        // registerBtn
        // 
        registerBtn.BackColor = System.Drawing.Color.Transparent;
        registerBtn.BackgroundImage = global::TechZone.Resources.buttonUi200;
        registerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        registerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
        registerBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
        registerBtn.FlatAppearance.BorderSize = 0;
        registerBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        registerBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        registerBtn.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        registerBtn.ForeColor = System.Drawing.Color.White;
        registerBtn.Location = new System.Drawing.Point(535, 451);
        registerBtn.Name = "registerBtn";
        registerBtn.Size = new System.Drawing.Size(200, 44);
        registerBtn.TabIndex = 0;
        registerBtn.Text = "Create Account";
        registerBtn.UseVisualStyleBackColor = false;
        registerBtn.Click += registerBtn_Click;
        // 
        // RegisterForm
        // 
        AcceptButton = registerBtn;
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)244)), ((int)((byte)248)), ((int)((byte)252)));
        BackgroundImage = global::TechZone.Resources.RegBgTechZone;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(900, 600);
        Controls.Add(registerBtn);
        Controls.Add(closeBtn);
        Controls.Add(passwordViewBtn);
        Controls.Add(comfirmPasswordTextBox);
        Controls.Add(passwordTextBox);
        Controls.Add(usernameTextBox);
        Cursor = System.Windows.Forms.Cursors.Arrow;
        DoubleBuffered = true;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Create Account";
        Load += RegisterForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private NoFocusButton registerBtn;

    private System.Windows.Forms.Button closeBtn;

    private System.Windows.Forms.Button passwordViewBtn;

    private System.Windows.Forms.TextBox comfirmPasswordTextBox;

    private System.Windows.Forms.TextBox passwordTextBox;

    private System.Windows.Forms.TextBox usernameTextBox;
}