using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TechZone.UI.Startup;

partial class SplashLoading
{
    private IContainer components = null!;

    private System.Windows.Forms.Panel mainPanel;
    private PictureBox logoPictureBox;
    private Label titleLabel;
    private Label subtitleLabel;
    private Panel progressPanel;
    private Panel progressBar;
    private Label lblStatus;
    private System.Windows.Forms.Label lblPercent;
    private System.Windows.Forms.Label versionLabel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        mainPanel = new System.Windows.Forms.Panel();
        logoPictureBox = new System.Windows.Forms.PictureBox();
        titleLabel = new System.Windows.Forms.Label();
        subtitleLabel = new System.Windows.Forms.Label();
        progressPanel = new System.Windows.Forms.Panel();
        progressBar = new System.Windows.Forms.Panel();
        lblStatus = new System.Windows.Forms.Label();
        lblPercent = new System.Windows.Forms.Label();
        versionLabel = new System.Windows.Forms.Label();
        mainPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
        progressPanel.SuspendLayout();
        SuspendLayout();
        // 
        // mainPanel
        // 
        mainPanel.BackColor = System.Drawing.Color.White;
        mainPanel.BackgroundImage = global::TechZone.Resources.splashscreen_background;
        mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        mainPanel.Controls.Add(logoPictureBox);
        mainPanel.Controls.Add(titleLabel);
        mainPanel.Controls.Add(subtitleLabel);
        mainPanel.Controls.Add(progressPanel);
        mainPanel.Controls.Add(lblStatus);
        mainPanel.Controls.Add(lblPercent);
        mainPanel.Controls.Add(versionLabel);
        mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        mainPanel.Location = new System.Drawing.Point(0, 0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new System.Drawing.Size(800, 450);
        mainPanel.TabIndex = 0;
        // 
        // logoPictureBox
        // 
        logoPictureBox.BackColor = System.Drawing.Color.Transparent;
        logoPictureBox.Image = global::TechZone.Resources.techzone_logo_royalblue;
        logoPictureBox.Location = new System.Drawing.Point(350, 62);
        logoPictureBox.Name = "logoPictureBox";
        logoPictureBox.Size = new System.Drawing.Size(100, 100);
        logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        logoPictureBox.TabIndex = 1;
        logoPictureBox.TabStop = false;
        // 
        // titleLabel
        // 
        titleLabel.BackColor = System.Drawing.Color.Transparent;
        titleLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 26F, System.Drawing.FontStyle.Bold);
        titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        titleLabel.Location = new System.Drawing.Point(150, 170);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(500, 48);
        titleLabel.TabIndex = 2;
        titleLabel.Text = "TECHZONE";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // subtitleLabel
        // 
        subtitleLabel.BackColor = System.Drawing.Color.Transparent;
        subtitleLabel.Font = new System.Drawing.Font("Bahnschrift", 10F);
        subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        subtitleLabel.Location = new System.Drawing.Point(150, 216);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new System.Drawing.Size(500, 28);
        subtitleLabel.TabIndex = 3;
        subtitleLabel.Text = "Store Management System";
        subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // progressPanel
        // 
        progressPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        progressPanel.Controls.Add(progressBar);
        progressPanel.Location = new System.Drawing.Point(200, 300);
        progressPanel.Name = "progressPanel";
        progressPanel.Size = new System.Drawing.Size(400, 4);
        progressPanel.TabIndex = 4;
        // 
        // progressBar
        // 
        progressBar.BackColor = System.Drawing.Color.RoyalBlue;
        progressBar.Location = new System.Drawing.Point(0, 0);
        progressBar.Name = "progressBar";
        progressBar.Size = new System.Drawing.Size(0, 4);
        progressBar.TabIndex = 0;
        // 
        // lblStatus
        // 
        lblStatus.BackColor = System.Drawing.Color.Transparent;
        lblStatus.Font = new System.Drawing.Font("Bahnschrift", 9F);
        lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        lblStatus.Location = new System.Drawing.Point(200, 315);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new System.Drawing.Size(320, 25);
        lblStatus.TabIndex = 5;
        lblStatus.Text = "Starting TechZone...";
        lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblPercent
        // 
        lblPercent.BackColor = System.Drawing.Color.Transparent;
        lblPercent.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
        lblPercent.ForeColor = System.Drawing.Color.RoyalBlue;
        lblPercent.Location = new System.Drawing.Point(540, 315);
        lblPercent.Name = "lblPercent";
        lblPercent.Size = new System.Drawing.Size(60, 25);
        lblPercent.TabIndex = 6;
        lblPercent.Text = "0%";
        lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // versionLabel
        // 
        versionLabel.BackColor = System.Drawing.Color.Transparent;
        versionLabel.Font = new System.Drawing.Font("Bahnschrift", 8F);
        versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        versionLabel.Location = new System.Drawing.Point(150, 375);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new System.Drawing.Size(500, 24);
        versionLabel.TabIndex = 7;
        versionLabel.Text = "TechZone • Store Management System";
        versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SplashLoading
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(mainPanel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "TechZone";
        mainPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
        progressPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}