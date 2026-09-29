namespace TechZone.UI.Forms.View;

partial class CategoryDetailForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelHeader;
    private Label labelTitle;
    private Label labelSubtitle;

    private System.Windows.Forms.Panel panelContent;

    private Label labelCategoryNameTitle;
    private Label labelCategoryName;

    private Label labelProductCountTitle;
    private Label labelProductCount;

    private System.Windows.Forms.Label labelDescriptionTitle;
    private Label labelDescription;

    private System.Windows.Forms.Panel panelFooter;
    private Button buttonClose;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
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
        panelHeader = new System.Windows.Forms.Panel();
        labelTitle = new System.Windows.Forms.Label();
        labelSubtitle = new System.Windows.Forms.Label();
        panelContent = new System.Windows.Forms.Panel();
        labelCategoryNameTitle = new System.Windows.Forms.Label();
        labelCategoryName = new System.Windows.Forms.Label();
        labelProductCountTitle = new System.Windows.Forms.Label();
        labelProductCount = new System.Windows.Forms.Label();
        labelDescriptionTitle = new System.Windows.Forms.Label();
        labelDescription = new System.Windows.Forms.Label();
        panelFooter = new System.Windows.Forms.Panel();
        buttonClose = new System.Windows.Forms.Button();
        panelHeader.SuspendLayout();
        panelContent.SuspendLayout();
        panelFooter.SuspendLayout();
        SuspendLayout();
        // 
        // panelHeader
        // 
        panelHeader.BackColor = System.Drawing.Color.White;
        panelHeader.Controls.Add(labelTitle);
        panelHeader.Controls.Add(labelSubtitle);
        panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        panelHeader.Location = new System.Drawing.Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new System.Drawing.Size(540, 82);
        panelHeader.TabIndex = 0;
        // 
        // labelTitle
        // 
        labelTitle.AutoSize = true;
        labelTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 16F, System.Drawing.FontStyle.Bold);
        labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        labelTitle.Location = new System.Drawing.Point(28, 18);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new System.Drawing.Size(215, 33);
        labelTitle.TabIndex = 0;
        labelTitle.Text = "Category Details";
        // 
        // labelSubtitle
        // 
        labelSubtitle.AutoSize = true;
        labelSubtitle.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        labelSubtitle.Location = new System.Drawing.Point(30, 50);
        labelSubtitle.Name = "labelSubtitle";
        labelSubtitle.Size = new System.Drawing.Size(199, 19);
        labelSubtitle.TabIndex = 1;
        labelSubtitle.Text = "View category information";
        // 
        // panelContent
        // 
        panelContent.BackColor = System.Drawing.Color.White;
        panelContent.Controls.Add(labelCategoryNameTitle);
        panelContent.Controls.Add(labelCategoryName);
        panelContent.Controls.Add(labelProductCountTitle);
        panelContent.Controls.Add(labelProductCount);
        panelContent.Controls.Add(labelDescriptionTitle);
        panelContent.Controls.Add(labelDescription);
        panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
        panelContent.Location = new System.Drawing.Point(0, 82);
        panelContent.Name = "panelContent";
        panelContent.Padding = new System.Windows.Forms.Padding(28, 24, 28, 20);
        panelContent.Size = new System.Drawing.Size(540, 250);
        panelContent.TabIndex = 1;
        // 
        // labelCategoryNameTitle
        // 
        labelCategoryNameTitle.AutoSize = true;
        labelCategoryNameTitle.Font = new System.Drawing.Font("Bahnschrift", 9F);
        labelCategoryNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        labelCategoryNameTitle.Location = new System.Drawing.Point(28, 24);
        labelCategoryNameTitle.Name = "labelCategoryNameTitle";
        labelCategoryNameTitle.Size = new System.Drawing.Size(111, 18);
        labelCategoryNameTitle.TabIndex = 0;
        labelCategoryNameTitle.Text = "Category Name";
        // 
        // labelCategoryName
        // 
        labelCategoryName.AutoEllipsis = true;
        labelCategoryName.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
        labelCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        labelCategoryName.Location = new System.Drawing.Point(28, 45);
        labelCategoryName.Name = "labelCategoryName";
        labelCategoryName.Size = new System.Drawing.Size(484, 25);
        labelCategoryName.TabIndex = 1;
        labelCategoryName.Text = "-";
        // 
        // labelProductCountTitle
        // 
        labelProductCountTitle.AutoSize = true;
        labelProductCountTitle.Font = new System.Drawing.Font("Bahnschrift", 9F);
        labelProductCountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        labelProductCountTitle.Location = new System.Drawing.Point(28, 88);
        labelProductCountTitle.Name = "labelProductCountTitle";
        labelProductCountTitle.Size = new System.Drawing.Size(101, 18);
        labelProductCountTitle.TabIndex = 2;
        labelProductCountTitle.Text = "Product Count";
        // 
        // labelProductCount
        // 
        labelProductCount.AutoSize = true;
        labelProductCount.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold);
        labelProductCount.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        labelProductCount.Location = new System.Drawing.Point(28, 109);
        labelProductCount.Name = "labelProductCount";
        labelProductCount.Size = new System.Drawing.Size(21, 24);
        labelProductCount.TabIndex = 3;
        labelProductCount.Text = "0";
        // 
        // labelDescriptionTitle
        // 
        labelDescriptionTitle.AutoSize = true;
        labelDescriptionTitle.Font = new System.Drawing.Font("Bahnschrift", 9F);
        labelDescriptionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        labelDescriptionTitle.Location = new System.Drawing.Point(28, 157);
        labelDescriptionTitle.Name = "labelDescriptionTitle";
        labelDescriptionTitle.Size = new System.Drawing.Size(84, 18);
        labelDescriptionTitle.TabIndex = 4;
        labelDescriptionTitle.Text = "Description";
        // 
        // labelDescription
        // 
        labelDescription.Font = new System.Drawing.Font("Bahnschrift", 10F);
        labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        labelDescription.Location = new System.Drawing.Point(28, 175);
        labelDescription.Name = "labelDescription";
        labelDescription.Size = new System.Drawing.Size(484, 72);
        labelDescription.TabIndex = 5;
        labelDescription.Text = "No description";
        // 
        // panelFooter
        // 
        panelFooter.BackColor = System.Drawing.SystemColors.Window;
        panelFooter.Controls.Add(buttonClose);
        panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelFooter.Location = new System.Drawing.Point(0, 332);
        panelFooter.Name = "panelFooter";
        panelFooter.Size = new System.Drawing.Size(540, 68);
        panelFooter.TabIndex = 2;
        // 
        // buttonClose
        // 
        buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
        buttonClose.FlatAppearance.BorderSize = 0;
        buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        buttonClose.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.5F, System.Drawing.FontStyle.Bold);
        buttonClose.ForeColor = System.Drawing.Color.White;
        buttonClose.Location = new System.Drawing.Point(410, 16);
        buttonClose.Name = "buttonClose";
        buttonClose.Size = new System.Drawing.Size(102, 36);
        buttonClose.TabIndex = 0;
        buttonClose.Text = "Close";
        buttonClose.UseVisualStyleBackColor = false;
        buttonClose.Click += buttonClose_Click;
        // 
        // CategoryDetailForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(540, 400);
        Controls.Add(panelContent);
        Controls.Add(panelHeader);
        Controls.Add(panelFooter);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Category Details";
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        panelContent.ResumeLayout(false);
        panelContent.PerformLayout();
        panelFooter.ResumeLayout(false);
        ResumeLayout(false);
    }
}