using System.ComponentModel;

namespace TechZone.UI.Components;

partial class DataTablePagination
{
    private IContainer components = null!;

    private System.Windows.Forms.Panel paginationPanel;
    private System.Windows.Forms.Button previousButton;
    private System.Windows.Forms.Label pageLabel;
    private System.Windows.Forms.Button nextButton;

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
        paginationPanel = new System.Windows.Forms.Panel();
        previousButton = new System.Windows.Forms.Button();
        pageLabel = new System.Windows.Forms.Label();
        nextButton = new System.Windows.Forms.Button();
        paginationPanel.SuspendLayout();
        SuspendLayout();
        // 
        // paginationPanel
        // 
        paginationPanel.BackColor = System.Drawing.Color.Transparent;
        paginationPanel.Controls.Add(previousButton);
        paginationPanel.Controls.Add(pageLabel);
        paginationPanel.Controls.Add(nextButton);
        paginationPanel.Location = new System.Drawing.Point(0, 0);
        paginationPanel.Margin = new System.Windows.Forms.Padding(0);
        paginationPanel.Name = "paginationPanel";
        paginationPanel.Size = new System.Drawing.Size(400, 44);
        paginationPanel.TabIndex = 0;
        // 
        // previousButton
        // 
        previousButton.BackColor = System.Drawing.Color.White;
        previousButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
        previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        previousButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        previousButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        previousButton.Location = new System.Drawing.Point(0, 6);
        previousButton.Margin = new System.Windows.Forms.Padding(0);
        previousButton.Name = "previousButton";
        previousButton.Size = new System.Drawing.Size(82, 32);
        previousButton.TabIndex = 0;
        previousButton.Text = "Previous";
        previousButton.UseVisualStyleBackColor = false;
        previousButton.Click += previousButton_Click;
        // 
        // pageLabel
        // 
        pageLabel.Font = new System.Drawing.Font("Bahnschrift", 9F);
        pageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        pageLabel.Location = new System.Drawing.Point(82, 6);
        pageLabel.Margin = new System.Windows.Forms.Padding(0);
        pageLabel.Name = "pageLabel";
        pageLabel.Size = new System.Drawing.Size(100, 32);
        pageLabel.TabIndex = 1;
        pageLabel.Text = "1 of 1";
        pageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // nextButton
        // 
        nextButton.BackColor = System.Drawing.Color.White;
        nextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
        nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        nextButton.Font = new System.Drawing.Font("Bahnschrift", 9F);
        nextButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)41)), ((int)((byte)59)));
        nextButton.Location = new System.Drawing.Point(185, 6);
        nextButton.Margin = new System.Windows.Forms.Padding(0);
        nextButton.Name = "nextButton";
        nextButton.Size = new System.Drawing.Size(60, 32);
        nextButton.TabIndex = 2;
        nextButton.Text = "Next";
        nextButton.UseVisualStyleBackColor = false;
        nextButton.Click += nextButton_Click;
        // 
        // DataTablePagination
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.Transparent;
        Controls.Add(paginationPanel);
        Margin = new System.Windows.Forms.Padding(0);
        MaximumSize = new System.Drawing.Size(400, 44);
        MinimumSize = new System.Drawing.Size(400, 44);
        Size = new System.Drawing.Size(400, 44);
        paginationPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
}