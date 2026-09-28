using System.ComponentModel;

namespace TechZone.UI.Components;

partial class DataTableToolbar
{
    private IContainer components = null!;

    private System.Windows.Forms.Panel toolbarPanel;
    private Button refreshButton;

    private System.Windows.Forms.Panel searchPanel;
    private System.Windows.Forms.TextBox searchTextBox;

    private System.Windows.Forms.Button addButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        toolbarPanel = new System.Windows.Forms.Panel();
        refreshButton = new System.Windows.Forms.Button();
        searchPanel = new System.Windows.Forms.Panel();
        searchTextBox = new System.Windows.Forms.TextBox();
        addButton = new System.Windows.Forms.Button();
        toolbarPanel.SuspendLayout();
        searchPanel.SuspendLayout();
        SuspendLayout();
        // 
        // toolbarPanel
        // 
        toolbarPanel.BackColor = System.Drawing.Color.Transparent;
        toolbarPanel.Controls.Add(refreshButton);
        toolbarPanel.Controls.Add(searchPanel);
        toolbarPanel.Controls.Add(addButton);
        toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        toolbarPanel.Location = new System.Drawing.Point(0, 0);
        toolbarPanel.Margin = new System.Windows.Forms.Padding(0);
        toolbarPanel.Name = "toolbarPanel";
        toolbarPanel.Size = new System.Drawing.Size(841, 44);
        toolbarPanel.TabIndex = 0;
        // 
        // refreshButton
        // 
        refreshButton.BackColor = System.Drawing.Color.White;
        refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
        refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
        refreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)208)), ((int)((byte)235)), ((int)((byte)255)));
        refreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)235)), ((int)((byte)247)), ((int)((byte)255)));
        refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        refreshButton.ForeColor = System.Drawing.Color.Gray;
        refreshButton.Image = global::TechZone.Resources.refresh;
        refreshButton.Location = new System.Drawing.Point(0, 0);
        refreshButton.Margin = new System.Windows.Forms.Padding(0);
        refreshButton.Name = "refreshButton";
        refreshButton.Size = new System.Drawing.Size(44, 44);
        refreshButton.TabIndex = 0;
        refreshButton.UseVisualStyleBackColor = false;
        // 
        // searchPanel
        // 
        searchPanel.BackColor = System.Drawing.Color.White;
        searchPanel.BackgroundImage = global::TechZone.Resources.searchContainerpng;
        searchPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        searchPanel.Controls.Add(searchTextBox);
        searchPanel.Cursor = System.Windows.Forms.Cursors.IBeam;
        searchPanel.Location = new System.Drawing.Point(60, 0);
        searchPanel.Margin = new System.Windows.Forms.Padding(0);
        searchPanel.Name = "searchPanel";
        searchPanel.Size = new System.Drawing.Size(300, 44);
        searchPanel.TabIndex = 1;
        // 
        // searchTextBox
        // 
        searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        searchTextBox.BackColor = System.Drawing.Color.White;
        searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        searchTextBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        searchTextBox.ForeColor = System.Drawing.Color.Black;
        searchTextBox.Location = new System.Drawing.Point(13, 12);
        searchTextBox.Margin = new System.Windows.Forms.Padding(0);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.PlaceholderText = "Search...";
        searchTextBox.Size = new System.Drawing.Size(275, 21);
        searchTextBox.TabIndex = 0;
        // 
        // addButton
        // 
        addButton.BackColor = System.Drawing.Color.RoyalBlue;
        addButton.Cursor = System.Windows.Forms.Cursors.Hand;
        addButton.FlatAppearance.BorderSize = 0;
        addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)29)), ((int)((byte)78)), ((int)((byte)216)));
        addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)59)), ((int)((byte)130)), ((int)((byte)246)));
        addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        addButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
        addButton.ForeColor = System.Drawing.Color.White;
        addButton.Image = global::TechZone.Resources.icon_logout_red;
        addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        addButton.Location = new System.Drawing.Point(375, 0);
        addButton.Margin = new System.Windows.Forms.Padding(0);
        addButton.Name = "addButton";
        addButton.Size = new System.Drawing.Size(130, 44);
        addButton.TabIndex = 3;
        addButton.Text = "Add Button";
        addButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        addButton.UseVisualStyleBackColor = false;
        // 
        // DataTableToolbar
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        Controls.Add(toolbarPanel);
        Margin = new System.Windows.Forms.Padding(0);
        Size = new System.Drawing.Size(841, 44);
        toolbarPanel.ResumeLayout(false);
        searchPanel.ResumeLayout(false);
        searchPanel.PerformLayout();
        ResumeLayout(false);
    }
    
    #endregion
}