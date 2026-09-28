using System.ComponentModel;
using TechZone.UI.Components;

namespace TechZone.UI.Forms;

partial class LoginForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        loginBtn = new NoFocusButton();
        closeBtn = new System.Windows.Forms.Button();
        passwordViewBtn = new System.Windows.Forms.Button();
        usernameTextBox = new System.Windows.Forms.TextBox();
        passwordTextBox = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // loginBtn
        // 
        loginBtn.BackColor = System.Drawing.Color.Transparent;
        loginBtn.BackgroundImage = global::TechZone.Resources.buttonUi;
        loginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
        loginBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
        loginBtn.FlatAppearance.BorderSize = 0;
        loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        loginBtn.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        loginBtn.ForeColor = System.Drawing.Color.White;
        loginBtn.Location = new System.Drawing.Point(535, 426);
        loginBtn.Name = "loginBtn";
        loginBtn.Size = new System.Drawing.Size(175, 44);
        loginBtn.TabIndex = 0;
        loginBtn.Text = "Login";
        loginBtn.UseVisualStyleBackColor = false;
        loginBtn.Click += loginBtn_Click;
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
        passwordViewBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        passwordViewBtn.Cursor = System.Windows.Forms.Cursors.Hand;
        passwordViewBtn.FlatAppearance.BorderSize = 0;
        passwordViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        passwordViewBtn.ForeColor = System.Drawing.Color.Transparent;
        passwordViewBtn.Location = new System.Drawing.Point(737, 355);
        passwordViewBtn.Name = "passwordViewBtn";
        passwordViewBtn.Size = new System.Drawing.Size(25, 25);
        passwordViewBtn.TabIndex = 0;
        passwordViewBtn.UseVisualStyleBackColor = false;
        passwordViewBtn.Click += passwordViewBtn_Click;
        // 
        // usernameTextBox
        // 
        usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        usernameTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        usernameTextBox.Location = new System.Drawing.Point(486, 270);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.Size = new System.Drawing.Size(276, 22);
        usernameTextBox.TabIndex = 4;
        // 
        // passwordTextBox
        // 
        passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        passwordTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        passwordTextBox.Location = new System.Drawing.Point(486, 356);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.Size = new System.Drawing.Size(245, 22);
        passwordTextBox.TabIndex = 5;
        // 
        // LoginForm
        // 
        AcceptButton = loginBtn;
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = global::TechZone.Resources.loginBgTechZone;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(900, 600);
        Controls.Add(passwordTextBox);
        Controls.Add(usernameTextBox);
        Controls.Add(passwordViewBtn);
        Controls.Add(closeBtn);
        Controls.Add(loginBtn);
        Cursor = System.Windows.Forms.Cursors.Arrow;
        DoubleBuffered = true;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "LoginForm";
        Load += LoginForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.TextBox usernameTextBox;
    private System.Windows.Forms.Button passwordViewBtn;
    private System.Windows.Forms.Button closeBtn;
    private NoFocusButton loginBtn;

    #endregion
}