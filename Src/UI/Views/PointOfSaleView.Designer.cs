using System.ComponentModel;

namespace TechZone.UI.Views;

partial class PointOfSaleView
{
    private IContainer components = null!;

    private System.Windows.Forms.Panel navigationPanel;
    private System.Windows.Forms.Button saleButton;
    private Button orderButton;
    private System.Windows.Forms.Button invoiceButton;
    private Panel navIndicator;
    private System.Windows.Forms.Panel contentPanel;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        navigationPanel = new System.Windows.Forms.Panel();
        saleButton = new System.Windows.Forms.Button();
        orderButton = new System.Windows.Forms.Button();
        invoiceButton = new System.Windows.Forms.Button();
        navIndicator = new System.Windows.Forms.Panel();
        contentPanel = new System.Windows.Forms.Panel();
        navigationPanel.SuspendLayout();
        SuspendLayout();
        // 
        // navigationPanel
        // 
        navigationPanel.BackColor = System.Drawing.Color.White;
        navigationPanel.Controls.Add(invoiceButton);
        navigationPanel.Controls.Add(saleButton);
        navigationPanel.Controls.Add(orderButton);
        navigationPanel.Controls.Add(navIndicator);
        navigationPanel.Dock = System.Windows.Forms.DockStyle.Top;
        navigationPanel.Location = new System.Drawing.Point(0, 0);
        navigationPanel.Name = "navigationPanel";
        navigationPanel.Size = new System.Drawing.Size(1016, 40);
        navigationPanel.TabIndex = 0;
        // 
        // saleButton
        // 
        saleButton.BackColor = System.Drawing.Color.White;
        saleButton.FlatAppearance.BorderSize = 0;
        saleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        saleButton.Font = new System.Drawing.Font("Bahnschrift", 11F);
        saleButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        saleButton.Location = new System.Drawing.Point(0, 0);
        saleButton.Name = "saleButton";
        saleButton.Size = new System.Drawing.Size(85, 40);
        saleButton.TabIndex = 0;
        saleButton.Text = "Sale";
        saleButton.UseVisualStyleBackColor = false;
        // 
        // orderButton
        // 
        orderButton.BackColor = System.Drawing.Color.White;
        orderButton.FlatAppearance.BorderSize = 0;
        orderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        orderButton.Font = new System.Drawing.Font("Bahnschrift", 11F);
        orderButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        orderButton.Location = new System.Drawing.Point(85, 0);
        orderButton.Name = "orderButton";
        orderButton.Size = new System.Drawing.Size(85, 40);
        orderButton.TabIndex = 1;
        orderButton.Text = "Order";
        orderButton.UseVisualStyleBackColor = false;
        // 
        // invoiceButton
        // 
        invoiceButton.BackColor = System.Drawing.Color.White;
        invoiceButton.FlatAppearance.BorderSize = 0;
        invoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        invoiceButton.Font = new System.Drawing.Font("Bahnschrift", 11F);
        invoiceButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        invoiceButton.Location = new System.Drawing.Point(170, 0);
        invoiceButton.Name = "invoiceButton";
        invoiceButton.Size = new System.Drawing.Size(85, 40);
        invoiceButton.TabIndex = 2;
        invoiceButton.Text = "History";
        invoiceButton.UseVisualStyleBackColor = false;
        // 
        // navIndicator
        // 
        navIndicator.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        navIndicator.Location = new System.Drawing.Point(0, 37);
        navIndicator.Name = "navIndicator";
        navIndicator.Size = new System.Drawing.Size(85, 2);
        navIndicator.TabIndex = 3;
        // 
        // contentPanel
        // 
        contentPanel.BackColor = System.Drawing.Color.White;
        contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        contentPanel.Location = new System.Drawing.Point(0, 40);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new System.Drawing.Size(1016, 750);
        contentPanel.TabIndex = 4;
        // 
        // PointOfSaleView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor =
            Color.FromArgb(
                248,
                250,
                252);
        Controls.Add(contentPanel);
        Controls.Add(navigationPanel);
        Size = new System.Drawing.Size(1016, 790);
        navigationPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
}