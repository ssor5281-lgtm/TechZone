#nullable disable

namespace TechZone.UI.Views;

partial class ProductGridView
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel bottomPanel;
    private System.Windows.Forms.Button btnLoadMore;
    private System.Windows.Forms.FlowLayoutPanel flowProducts;

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
        flowProducts = new System.Windows.Forms.FlowLayoutPanel();
        bottomPanel = new System.Windows.Forms.Panel();
        btnLoadMore = new System.Windows.Forms.Button();
        bottomPanel.SuspendLayout();
        SuspendLayout();
        // 
        // flowProducts
        // 
        flowProducts.AutoScroll = true;
        flowProducts.BackColor = System.Drawing.Color.White;
        flowProducts.Dock = System.Windows.Forms.DockStyle.Fill;
        flowProducts.Location = new System.Drawing.Point(0, 0);
        flowProducts.Name = "flowProducts";
        flowProducts.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
        flowProducts.Size = new System.Drawing.Size(1000, 666);
        flowProducts.TabIndex = 0;
        // 
        // bottomPanel
        // 
        bottomPanel.BackColor = System.Drawing.Color.White;
        bottomPanel.Controls.Add(btnLoadMore);
        bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        bottomPanel.Location = new System.Drawing.Point(0, 666);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
        bottomPanel.Size = new System.Drawing.Size(1000, 44);
        bottomPanel.TabIndex = 1;
        // 
        // btnLoadMore
        // 
        btnLoadMore.Anchor = System.Windows.Forms.AnchorStyles.None;
        btnLoadMore.BackColor = System.Drawing.Color.White;
        btnLoadMore.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLoadMore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
        btnLoadMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnLoadMore.Font = new System.Drawing.Font("Bahnschrift", 9F);
        btnLoadMore.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        btnLoadMore.Location = new System.Drawing.Point(877, 5);
        btnLoadMore.Name = "btnLoadMore";
        btnLoadMore.Size = new System.Drawing.Size(120, 36);
        btnLoadMore.TabIndex = 0;
        btnLoadMore.Text = "Load More";
        btnLoadMore.UseVisualStyleBackColor = false;
        // 
        // ProductGridView
        // 
        Controls.Add(flowProducts);
        Controls.Add(bottomPanel);
        Size = new System.Drawing.Size(1000, 710);
        bottomPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}