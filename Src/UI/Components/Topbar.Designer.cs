using System.ComponentModel;

namespace TechZone.UI.Components;

partial class Topbar
{
    private IContainer components = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        parentHeader = new System.Windows.Forms.Label();
        separatorLabel = new System.Windows.Forms.Label();
        pageHeader = new System.Windows.Forms.Label();
        profileContainer = new System.Windows.Forms.Panel();
        displayNameLabel = new System.Windows.Forms.Label();
        roleLabel = new System.Windows.Forms.Label();
        profilePictureBox = new System.Windows.Forms.PictureBox();
        profileContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
        SuspendLayout();
        // 
        // parentHeader
        // 
        parentHeader.AutoSize = true;
        parentHeader.BackColor = System.Drawing.Color.Transparent;
        parentHeader.Font = new System.Drawing.Font("Bahnschrift", 11F);
        parentHeader.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        parentHeader.Location = new System.Drawing.Point(24, 23);
        parentHeader.Name = "parentHeader";
        parentHeader.Size = new System.Drawing.Size(117, 23);
        parentHeader.TabIndex = 0;
        parentHeader.Text = "Point of Sale";
        parentHeader.Visible = false;
        // 
        // separatorLabel
        // 
        separatorLabel.AutoSize = true;
        separatorLabel.BackColor = System.Drawing.Color.Transparent;
        separatorLabel.Font = new System.Drawing.Font("Bahnschrift", 11F);
        separatorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)148)), ((int)((byte)163)), ((int)((byte)184)));
        separatorLabel.Location = new System.Drawing.Point(142, 23);
        separatorLabel.Name = "separatorLabel";
        separatorLabel.Size = new System.Drawing.Size(18, 23);
        separatorLabel.TabIndex = 1;
        separatorLabel.Text = ">";
        separatorLabel.Visible = false;
        // 
        // pageHeader
        // 
        pageHeader.AutoSize = true;
        pageHeader.BackColor = System.Drawing.Color.Transparent;
        pageHeader.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold);
        pageHeader.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        pageHeader.Location = new System.Drawing.Point(24, 23);
        pageHeader.Name = "pageHeader";
        pageHeader.Size = new System.Drawing.Size(101, 23);
        pageHeader.TabIndex = 2;
        pageHeader.Text = "Dashboard";
        // 
        // profileContainer
        // 
        profileContainer.BackColor = System.Drawing.Color.Transparent;
        profileContainer.Controls.Add(displayNameLabel);
        profileContainer.Controls.Add(roleLabel);
        profileContainer.Controls.Add(profilePictureBox);
        profileContainer.Dock = System.Windows.Forms.DockStyle.Right;
        profileContainer.Location = new System.Drawing.Point(852, 0);
        profileContainer.Name = "profileContainer";
        profileContainer.Size = new System.Drawing.Size(330, 70);
        profileContainer.TabIndex = 3;
        // 
        // displayNameLabel
        // 
        displayNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        displayNameLabel.AutoEllipsis = true;
        displayNameLabel.BackColor = System.Drawing.Color.Transparent;
        displayNameLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        displayNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        displayNameLabel.Location = new System.Drawing.Point(52, 17);
        displayNameLabel.Name = "displayNameLabel";
        displayNameLabel.Size = new System.Drawing.Size(189, 20);
        displayNameLabel.TabIndex = 0;
        displayNameLabel.Text = "Username";
        displayNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // roleLabel
        // 
        roleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        roleLabel.BackColor = System.Drawing.Color.Transparent;
        roleLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 7.2000003F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        roleLabel.ForeColor = System.Drawing.Color.Purple;
        roleLabel.Location = new System.Drawing.Point(111, 37);
        roleLabel.Name = "roleLabel";
        roleLabel.Size = new System.Drawing.Size(127, 17);
        roleLabel.TabIndex = 1;
        roleLabel.Text = "Role";
        roleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // profilePictureBox
        // 
        profilePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        profilePictureBox.BackColor = System.Drawing.Color.Transparent;
        profilePictureBox.Location = new System.Drawing.Point(247, 11);
        profilePictureBox.Name = "profilePictureBox";
        profilePictureBox.Size = new System.Drawing.Size(50, 50);
        profilePictureBox.TabIndex = 2;
        profilePictureBox.TabStop = false;
        // 
        // Topbar
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        Controls.Add(parentHeader);
        Controls.Add(separatorLabel);
        Controls.Add(pageHeader);
        Controls.Add(profileContainer);
        Size = new System.Drawing.Size(1182, 70);
        profileContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)profilePictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Panel profileContainer;

    private System.Windows.Forms.PictureBox profilePictureBox;
    private System.Windows.Forms.Label displayNameLabel;
    private System.Windows.Forms.Label roleLabel;

    private System.Windows.Forms.Label parentHeader;
    private System.Windows.Forms.Label separatorLabel;
    private System.Windows.Forms.Label pageHeader;

    #endregion
}