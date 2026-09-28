using System.ComponentModel;

namespace TechZone.UI.Views;

partial class SaleView
{
    private IContainer components = null!;

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
        contentContainer = new System.Windows.Forms.Panel();
        titleLabel = new System.Windows.Forms.Label();
        descriptionLabel = new System.Windows.Forms.Label();
        newSaleButton = new System.Windows.Forms.Button();
        newSaleLabel = new System.Windows.Forms.Label();
        quickSaleButton = new System.Windows.Forms.Button();
        quickSaleLabel = new System.Windows.Forms.Label();
        newOrderButton = new System.Windows.Forms.Button();
        saleHistoryLabel = new System.Windows.Forms.Label();
        contentContainer.SuspendLayout();
        SuspendLayout();
        // 
        // contentContainer
        // 
        contentContainer.BackColor = System.Drawing.Color.Transparent;
        contentContainer.Controls.Add(titleLabel);
        contentContainer.Controls.Add(descriptionLabel);
        contentContainer.Controls.Add(newSaleButton);
        contentContainer.Controls.Add(newSaleLabel);
        contentContainer.Controls.Add(quickSaleButton);
        contentContainer.Controls.Add(quickSaleLabel);
        contentContainer.Controls.Add(newOrderButton);
        contentContainer.Controls.Add(saleHistoryLabel);
        contentContainer.Location = new System.Drawing.Point(249, 200);
        contentContainer.Name = "contentContainer";
        contentContainer.Size = new System.Drawing.Size(500, 310);
        contentContainer.TabIndex = 0;
        // 
        // titleLabel
        // 
        titleLabel.Font = new System.Drawing.Font("Bahnschrift", 24F);
        titleLabel.Location = new System.Drawing.Point(0, 0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(500, 50);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "TechZone Point of Sale";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // descriptionLabel
        // 
        descriptionLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
        descriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        descriptionLabel.Location = new System.Drawing.Point(0, 50);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new System.Drawing.Size(500, 75);
        descriptionLabel.TabIndex = 1;
        descriptionLabel.Text = ("New Sale lets you create a full invoice with customer details, Quick Sale offers " + "a fast checkout with no customer required, and Sale History allows you to review" + " all past transactions.");
        descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // newSaleButton
        // 
        newSaleButton.BackColor = System.Drawing.Color.White;
        newSaleButton.Cursor = System.Windows.Forms.Cursors.Hand;
        newSaleButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        newSaleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)219)), ((int)((byte)234)), ((int)((byte)254)));
        newSaleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)239)), ((int)((byte)246)), ((int)((byte)255)));
        newSaleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        newSaleButton.Image = global::TechZone.Resources.icon_plus;
        newSaleButton.Location = new System.Drawing.Point(25, 155);
        newSaleButton.Name = "newSaleButton";
        newSaleButton.Size = new System.Drawing.Size(100, 100);
        newSaleButton.TabIndex = 2;
        newSaleButton.UseVisualStyleBackColor = false;
        newSaleButton.Click += newSaleButton_Click;
        // 
        // newSaleLabel
        // 
        newSaleLabel.Font = new System.Drawing.Font("Bahnschrift", 10.8F);
        newSaleLabel.Location = new System.Drawing.Point(25, 260);
        newSaleLabel.Name = "newSaleLabel";
        newSaleLabel.Size = new System.Drawing.Size(100, 23);
        newSaleLabel.TabIndex = 3;
        newSaleLabel.Text = "New Sale";
        newSaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // quickSaleButton
        // 
        quickSaleButton.BackColor = System.Drawing.Color.White;
        quickSaleButton.Cursor = System.Windows.Forms.Cursors.Hand;
        quickSaleButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        quickSaleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)219)), ((int)((byte)234)), ((int)((byte)254)));
        quickSaleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)239)), ((int)((byte)246)), ((int)((byte)255)));
        quickSaleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        quickSaleButton.Image = global::TechZone.Resources.icon_fastshop;
        quickSaleButton.Location = new System.Drawing.Point(200, 155);
        quickSaleButton.Name = "quickSaleButton";
        quickSaleButton.Size = new System.Drawing.Size(100, 100);
        quickSaleButton.TabIndex = 4;
        quickSaleButton.UseVisualStyleBackColor = false;
        quickSaleButton.Click += quickSaleButton_Click;
        // 
        // quickSaleLabel
        // 
        quickSaleLabel.Font = new System.Drawing.Font("Bahnschrift", 10.8F);
        quickSaleLabel.Location = new System.Drawing.Point(200, 260);
        quickSaleLabel.Name = "quickSaleLabel";
        quickSaleLabel.Size = new System.Drawing.Size(100, 23);
        quickSaleLabel.TabIndex = 5;
        quickSaleLabel.Text = "Quick Sale";
        quickSaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // newOrderButton
        // 
        newOrderButton.BackColor = System.Drawing.Color.White;
        newOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
        newOrderButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        newOrderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)((byte)219)), ((int)((byte)234)), ((int)((byte)254)));
        newOrderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)((byte)239)), ((int)((byte)246)), ((int)((byte)255)));
        newOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        newOrderButton.Image = global::TechZone.Resources.icon_history;
        newOrderButton.Location = new System.Drawing.Point(375, 155);
        newOrderButton.Name = "newOrderButton";
        newOrderButton.Size = new System.Drawing.Size(100, 100);
        newOrderButton.TabIndex = 6;
        newOrderButton.UseVisualStyleBackColor = false;
        newOrderButton.Click += newOrderButton_Click;
        // 
        // saleHistoryLabel
        // 
        saleHistoryLabel.Font = new System.Drawing.Font("Bahnschrift", 10.8F);
        saleHistoryLabel.Location = new System.Drawing.Point(370, 260);
        saleHistoryLabel.Name = "saleHistoryLabel";
        saleHistoryLabel.Size = new System.Drawing.Size(110, 23);
        saleHistoryLabel.TabIndex = 7;
        saleHistoryLabel.Text = "New Order";
        saleHistoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SaleView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor =
            Color.FromArgb(
                248,
                250,
                252);
        Controls.Add(contentContainer);
        Padding = new System.Windows.Forms.Padding(15);
        Size = new System.Drawing.Size(1000, 800);
        contentContainer.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel contentContainer;

    private Label titleLabel;
    private Label descriptionLabel;

    private System.Windows.Forms.Button newSaleButton;
    private Label newSaleLabel;

    private System.Windows.Forms.Button quickSaleButton;
    private Label quickSaleLabel;

    private System.Windows.Forms.Button newOrderButton;
    private System.Windows.Forms.Label saleHistoryLabel;
}