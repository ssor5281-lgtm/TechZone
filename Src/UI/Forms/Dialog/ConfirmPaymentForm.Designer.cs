using System.ComponentModel;

namespace TechZone.UI.Forms.Dialog;

partial class ConfirmPaymentForm
{

    private Panel headerPanel;
    private Label titleLabel;
    private Label messageLabel;

    private Panel detailsCard;
    private Label detailsTitleLabel;

    private System.Windows.Forms.Label invoiceLabel;
    private System.Windows.Forms.Label invoiceValueLabel;
    private System.Windows.Forms.Label customerLabel;
    private System.Windows.Forms.Label customerValueLabel;
    private System.Windows.Forms.Label staffLabel;
    private System.Windows.Forms.Label staffValueLabel;
    private System.Windows.Forms.Label itemsLabel;
    private System.Windows.Forms.Label itemsValueLabel;

    private Panel summaryCard;
    private Label summaryTitleLabel;
    private Label subtotalLabel;
    private Label subtotalValueLabel;
    private Label discountLabel;
    private Label discountValueLabel;
    private Label totalDivider;
    private Label totalLabel;
    private System.Windows.Forms.Label totalValueLabel;

    private Panel footerPanel;
    private Button cancelButton;
    private Button confirmButton;

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        headerPanel = new System.Windows.Forms.Panel();
        titleLabel = new System.Windows.Forms.Label();
        messageLabel = new System.Windows.Forms.Label();
        detailsCard = new System.Windows.Forms.Panel();
        detailsTitleLabel = new System.Windows.Forms.Label();
        invoiceLabel = new System.Windows.Forms.Label();
        invoiceValueLabel = new System.Windows.Forms.Label();
        customerLabel = new System.Windows.Forms.Label();
        customerValueLabel = new System.Windows.Forms.Label();
        staffLabel = new System.Windows.Forms.Label();
        staffValueLabel = new System.Windows.Forms.Label();
        itemsLabel = new System.Windows.Forms.Label();
        itemsValueLabel = new System.Windows.Forms.Label();
        summaryCard = new System.Windows.Forms.Panel();
        summaryTitleLabel = new System.Windows.Forms.Label();
        subtotalLabel = new System.Windows.Forms.Label();
        subtotalValueLabel = new System.Windows.Forms.Label();
        discountLabel = new System.Windows.Forms.Label();
        discountValueLabel = new System.Windows.Forms.Label();
        totalDivider = new System.Windows.Forms.Label();
        totalLabel = new System.Windows.Forms.Label();
        totalValueLabel = new System.Windows.Forms.Label();
        footerPanel = new System.Windows.Forms.Panel();
        cancelButton = new System.Windows.Forms.Button();
        confirmButton = new System.Windows.Forms.Button();
        headerPanel.SuspendLayout();
        detailsCard.SuspendLayout();
        summaryCard.SuspendLayout();
        footerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // headerPanel
        // 
        headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        headerPanel.Controls.Add(titleLabel);
        headerPanel.Controls.Add(messageLabel);
        headerPanel.Location = new System.Drawing.Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new System.Drawing.Size(560, 82);
        headerPanel.TabIndex = 0;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new System.Drawing.Font("Bahnschrift", 16F, System.Drawing.FontStyle.Bold);
        titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        titleLabel.Location = new System.Drawing.Point(24, 13);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(224, 33);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Confirm Payment";
        // 
        // messageLabel
        // 
        messageLabel.AutoSize = true;
        messageLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        messageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)100)), ((int)((byte)116)), ((int)((byte)139)));
        messageLabel.Location = new System.Drawing.Point(24, 48);
        messageLabel.Name = "messageLabel";
        messageLabel.Size = new System.Drawing.Size(368, 19);
        messageLabel.TabIndex = 1;
        messageLabel.Text = "Please review the sale details before completing.";
        // 
        // detailsCard
        // 
        detailsCard.BackColor = System.Drawing.Color.White;
        detailsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        detailsCard.Controls.Add(detailsTitleLabel);
        detailsCard.Controls.Add(invoiceLabel);
        detailsCard.Controls.Add(invoiceValueLabel);
        detailsCard.Controls.Add(customerLabel);
        detailsCard.Controls.Add(customerValueLabel);
        detailsCard.Controls.Add(staffLabel);
        detailsCard.Controls.Add(staffValueLabel);
        detailsCard.Controls.Add(itemsLabel);
        detailsCard.Controls.Add(itemsValueLabel);
        detailsCard.Location = new System.Drawing.Point(24, 98);
        detailsCard.Name = "detailsCard";
        detailsCard.Size = new System.Drawing.Size(512, 148);
        detailsCard.TabIndex = 1;
        // 
        // detailsTitleLabel
        // 
        detailsTitleLabel.AutoSize = true;
        detailsTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 10.5F, System.Drawing.FontStyle.Bold);
        detailsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        detailsTitleLabel.Location = new System.Drawing.Point(16, 12);
        detailsTitleLabel.Name = "detailsTitleLabel";
        detailsTitleLabel.Size = new System.Drawing.Size(108, 22);
        detailsTitleLabel.TabIndex = 0;
        detailsTitleLabel.Text = "Sale Details";
        // 
        // invoiceLabel
        // 
        invoiceLabel.AutoSize = true;
        invoiceLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        invoiceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        invoiceLabel.Location = new System.Drawing.Point(16, 48);
        invoiceLabel.Name = "invoiceLabel";
        invoiceLabel.Size = new System.Drawing.Size(51, 18);
        invoiceLabel.TabIndex = 1;
        invoiceLabel.Text = "SaleID";
        // 
        // invoiceValueLabel
        // 
        invoiceValueLabel.AutoSize = true;
        invoiceValueLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        invoiceValueLabel.ForeColor = System.Drawing.Color.Gray;
        invoiceValueLabel.Location = new System.Drawing.Point(95, 48);
        invoiceValueLabel.Name = "invoiceValueLabel";
        invoiceValueLabel.Size = new System.Drawing.Size(90, 21);
        invoiceValueLabel.TabIndex = 2;
        invoiceValueLabel.Text = "----------";
        // 
        // customerLabel
        // 
        customerLabel.AutoSize = true;
        customerLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        customerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        customerLabel.Location = new System.Drawing.Point(16, 82);
        customerLabel.Name = "customerLabel";
        customerLabel.Size = new System.Drawing.Size(73, 18);
        customerLabel.TabIndex = 3;
        customerLabel.Text = "Customer";
        // 
        // customerValueLabel
        // 
        customerValueLabel.AutoSize = true;
        customerValueLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        customerValueLabel.ForeColor = System.Drawing.Color.Gray;
        customerValueLabel.Location = new System.Drawing.Point(95, 81);
        customerValueLabel.Name = "customerValueLabel";
        customerValueLabel.Size = new System.Drawing.Size(90, 21);
        customerValueLabel.TabIndex = 4;
        customerValueLabel.Text = "----------";
        // 
        // staffLabel
        // 
        staffLabel.AutoSize = true;
        staffLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        staffLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        staffLabel.Location = new System.Drawing.Point(242, 46);
        staffLabel.Name = "staffLabel";
        staffLabel.Size = new System.Drawing.Size(40, 18);
        staffLabel.TabIndex = 5;
        staffLabel.Text = "Staff";
        // 
        // staffValueLabel
        // 
        staffValueLabel.AutoSize = true;
        staffValueLabel.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        staffValueLabel.ForeColor = System.Drawing.Color.Gray;
        staffValueLabel.Location = new System.Drawing.Point(329, 46);
        staffValueLabel.Name = "staffValueLabel";
        staffValueLabel.Size = new System.Drawing.Size(90, 21);
        staffValueLabel.TabIndex = 6;
        staffValueLabel.Text = "----------";
        // 
        // itemsLabel
        // 
        itemsLabel.AutoSize = true;
        itemsLabel.BackColor = System.Drawing.Color.Transparent;
        itemsLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        itemsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        itemsLabel.Location = new System.Drawing.Point(242, 82);
        itemsLabel.Name = "itemsLabel";
        itemsLabel.Size = new System.Drawing.Size(81, 18);
        itemsLabel.TabIndex = 7;
        itemsLabel.Text = "Total Items";
        // 
        // itemsValueLabel
        // 
        itemsValueLabel.AutoSize = true;
        itemsValueLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F, System.Drawing.FontStyle.Bold);
        itemsValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)192)), ((int)((byte)0)), ((int)((byte)0)));
        itemsValueLabel.Location = new System.Drawing.Point(329, 81);
        itemsValueLabel.Name = "itemsValueLabel";
        itemsValueLabel.Size = new System.Drawing.Size(18, 19);
        itemsValueLabel.TabIndex = 8;
        itemsValueLabel.Text = "0";
        // 
        // summaryCard
        // 
        summaryCard.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        summaryCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        summaryCard.Controls.Add(summaryTitleLabel);
        summaryCard.Controls.Add(subtotalLabel);
        summaryCard.Controls.Add(subtotalValueLabel);
        summaryCard.Controls.Add(discountLabel);
        summaryCard.Controls.Add(discountValueLabel);
        summaryCard.Controls.Add(totalDivider);
        summaryCard.Controls.Add(totalLabel);
        summaryCard.Controls.Add(totalValueLabel);
        summaryCard.Location = new System.Drawing.Point(24, 262);
        summaryCard.Name = "summaryCard";
        summaryCard.Size = new System.Drawing.Size(512, 148);
        summaryCard.TabIndex = 2;
        // 
        // summaryTitleLabel
        // 
        summaryTitleLabel.AutoSize = true;
        summaryTitleLabel.Font = new System.Drawing.Font("Bahnschrift", 10.5F, System.Drawing.FontStyle.Bold);
        summaryTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        summaryTitleLabel.Location = new System.Drawing.Point(16, 12);
        summaryTitleLabel.Name = "summaryTitleLabel";
        summaryTitleLabel.Size = new System.Drawing.Size(164, 22);
        summaryTitleLabel.TabIndex = 0;
        summaryTitleLabel.Text = "Payment Summary";
        // 
        // subtotalLabel
        // 
        subtotalLabel.AutoSize = true;
        subtotalLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        subtotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        subtotalLabel.Location = new System.Drawing.Point(16, 46);
        subtotalLabel.Name = "subtotalLabel";
        subtotalLabel.Size = new System.Drawing.Size(70, 19);
        subtotalLabel.TabIndex = 1;
        subtotalLabel.Text = "Subtotal";
        // 
        // subtotalValueLabel
        // 
        subtotalValueLabel.AutoSize = true;
        subtotalValueLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F, System.Drawing.FontStyle.Bold);
        subtotalValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        subtotalValueLabel.Location = new System.Drawing.Point(402, 45);
        subtotalValueLabel.Name = "subtotalValueLabel";
        subtotalValueLabel.Size = new System.Drawing.Size(49, 19);
        subtotalValueLabel.TabIndex = 2;
        subtotalValueLabel.Text = "$0.00";
        // 
        // discountLabel
        // 
        discountLabel.AutoSize = true;
        discountLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        discountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)71)), ((int)((byte)85)), ((int)((byte)105)));
        discountLabel.Location = new System.Drawing.Point(16, 72);
        discountLabel.Name = "discountLabel";
        discountLabel.Size = new System.Drawing.Size(72, 19);
        discountLabel.TabIndex = 3;
        discountLabel.Text = "Discount";
        // 
        // discountValueLabel
        // 
        discountValueLabel.AutoSize = true;
        discountValueLabel.Font = new System.Drawing.Font("Bahnschrift", 9.5F, System.Drawing.FontStyle.Bold);
        discountValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)38)), ((int)((byte)38)));
        discountValueLabel.Location = new System.Drawing.Point(402, 71);
        discountValueLabel.Name = "discountValueLabel";
        discountValueLabel.Size = new System.Drawing.Size(49, 19);
        discountValueLabel.TabIndex = 4;
        discountValueLabel.Text = "$0.00";
        // 
        // totalDivider
        // 
        totalDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        totalDivider.Location = new System.Drawing.Point(16, 96);
        totalDivider.Name = "totalDivider";
        totalDivider.Size = new System.Drawing.Size(478, 1);
        totalDivider.TabIndex = 5;
        // 
        // totalLabel
        // 
        totalLabel.AutoSize = true;
        totalLabel.Font = new System.Drawing.Font("Bahnschrift", 11.5F, System.Drawing.FontStyle.Bold);
        totalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        totalLabel.Location = new System.Drawing.Point(16, 110);
        totalLabel.Name = "totalLabel";
        totalLabel.Size = new System.Drawing.Size(129, 24);
        totalLabel.TabIndex = 6;
        totalLabel.Text = "Total Amount";
        // 
        // totalValueLabel
        // 
        totalValueLabel.AutoSize = true;
        totalValueLabel.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold);
        totalValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        totalValueLabel.Location = new System.Drawing.Point(378, 104);
        totalValueLabel.Name = "totalValueLabel";
        totalValueLabel.Size = new System.Drawing.Size(73, 30);
        totalValueLabel.TabIndex = 7;
        totalValueLabel.Text = "$0.00";
        // 
        // footerPanel
        // 
        footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        footerPanel.Controls.Add(cancelButton);
        footerPanel.Controls.Add(confirmButton);
        footerPanel.Location = new System.Drawing.Point(0, 430);
        footerPanel.Name = "footerPanel";
        footerPanel.Size = new System.Drawing.Size(560, 60);
        footerPanel.TabIndex = 3;
        // 
        // cancelButton
        // 
        cancelButton.BackColor = System.Drawing.Color.White;
        cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
        cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)((byte)203)), ((int)((byte)213)), ((int)((byte)225)));
        cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cancelButton.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
        cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)51)), ((int)((byte)65)), ((int)((byte)85)));
        cancelButton.Location = new System.Drawing.Point(308, 13);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(108, 34);
        cancelButton.TabIndex = 0;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        cancelButton.Click += cancelButton_Click;
        // 
        // confirmButton
        // 
        confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)37)), ((int)((byte)99)), ((int)((byte)235)));
        confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
        confirmButton.FlatAppearance.BorderSize = 0;
        confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        confirmButton.Font = new System.Drawing.Font("Bahnschrift", 9.5F, System.Drawing.FontStyle.Bold);
        confirmButton.ForeColor = System.Drawing.Color.White;
        confirmButton.Location = new System.Drawing.Point(424, 13);
        confirmButton.Name = "confirmButton";
        confirmButton.Size = new System.Drawing.Size(112, 34);
        confirmButton.TabIndex = 1;
        confirmButton.Text = "Confirm";
        confirmButton.UseVisualStyleBackColor = false;
        confirmButton.Click += confirmButton_Click;
        // 
        // ConfirmPaymentForm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(560, 490);
        Controls.Add(headerPanel);
        Controls.Add(detailsCard);
        Controls.Add(summaryCard);
        Controls.Add(footerPanel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Confirm Payment";
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        detailsCard.ResumeLayout(false);
        detailsCard.PerformLayout();
        summaryCard.ResumeLayout(false);
        summaryCard.PerformLayout();
        footerPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}