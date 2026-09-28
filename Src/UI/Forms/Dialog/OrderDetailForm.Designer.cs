using System.ComponentModel;

namespace TechZone.UI.Forms.Dialog;

partial class OrderDetailForm
{
    private IContainer components = null!;

    private Label titleLabel;
    private Label orderLabel;
    private Label orderValueLabel;
    private Label customerLabel;
    private Label customerValueLabel;
    private Label staffLabel;
    private Label staffValueLabel;
    private Label itemsLabel;
    private Label itemsValueLabel;
    private Label statusLabel;
    private Label statusValueLabel;
    private Label pickupDateLabel;
    private Label pickupDateValueLabel;
    private Panel separatorPanel;
    private Label paymentLabel;
    private Label subtotalLabel;
    private Label subtotalValueLabel;
    private Label discountLabel;
    private Label discountValueLabel;
    private Label discountAmountLabel;
    private Label discountAmountValueLabel;
    private Label totalLabel;
    private Label totalValueLabel;
    private Button closeButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();

        titleLabel = new Label();
        orderLabel = new Label();
        orderValueLabel = new Label();
        customerLabel = new Label();
        customerValueLabel = new Label();
        staffLabel = new Label();
        staffValueLabel = new Label();
        itemsLabel = new Label();
        itemsValueLabel = new Label();
        statusLabel = new Label();
        statusValueLabel = new Label();
        pickupDateLabel = new Label();
        pickupDateValueLabel = new Label();
        separatorPanel = new Panel();
        paymentLabel = new Label();
        subtotalLabel = new Label();
        subtotalValueLabel = new Label();
        discountLabel = new Label();
        discountValueLabel = new Label();
        discountAmountLabel = new Label();
        discountAmountValueLabel = new Label();
        totalLabel = new Label();
        totalValueLabel = new Label();
        closeButton = new Button();

        SuspendLayout();

        titleLabel.AutoSize = false;
        titleLabel.Font = new Font(
            "Bahnschrift",
            15F,
            FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        titleLabel.Location = new Point(
            30,
            22);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(
            640,
            32);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Order Details";
        titleLabel.TextAlign = ContentAlignment.MiddleLeft;

        orderLabel.AutoSize = false;
        orderLabel.Font = new Font(
            "Bahnschrift",
            9F);
        orderLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        orderLabel.Location = new Point(
            30,
            70);
        orderLabel.Name = "orderLabel";
        orderLabel.Size = new Size(
            130,
            24);
        orderLabel.TabIndex = 1;
        orderLabel.Text = "Order";
        orderLabel.TextAlign = ContentAlignment.MiddleLeft;

        orderValueLabel.AutoEllipsis = true;
        orderValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        orderValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        orderValueLabel.Location = new Point(
            170,
            70);
        orderValueLabel.Name = "orderValueLabel";
        orderValueLabel.Size = new Size(
            190,
            24);
        orderValueLabel.TabIndex = 2;
        orderValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        customerLabel.AutoSize = false;
        customerLabel.Font = new Font(
            "Bahnschrift",
            9F);
        customerLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        customerLabel.Location = new Point(
            30,
            108);
        customerLabel.Name = "customerLabel";
        customerLabel.Size = new Size(
            130,
            24);
        customerLabel.TabIndex = 3;
        customerLabel.Text = "Customer";
        customerLabel.TextAlign = ContentAlignment.MiddleLeft;

        customerValueLabel.AutoEllipsis = true;
        customerValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        customerValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        customerValueLabel.Location = new Point(
            170,
            108);
        customerValueLabel.Name = "customerValueLabel";
        customerValueLabel.Size = new Size(
            190,
            24);
        customerValueLabel.TabIndex = 4;
        customerValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        staffLabel.AutoSize = false;
        staffLabel.Font = new Font(
            "Bahnschrift",
            9F);
        staffLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        staffLabel.Location = new Point(
            30,
            146);
        staffLabel.Name = "staffLabel";
        staffLabel.Size = new Size(
            130,
            24);
        staffLabel.TabIndex = 5;
        staffLabel.Text = "Staff";
        staffLabel.TextAlign = ContentAlignment.MiddleLeft;

        staffValueLabel.AutoEllipsis = true;
        staffValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        staffValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        staffValueLabel.Location = new Point(
            170,
            146);
        staffValueLabel.Name = "staffValueLabel";
        staffValueLabel.Size = new Size(
            190,
            24);
        staffValueLabel.TabIndex = 6;
        staffValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        itemsLabel.AutoSize = false;
        itemsLabel.Font = new Font(
            "Bahnschrift",
            9F);
        itemsLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        itemsLabel.Location = new Point(
            30,
            184);
        itemsLabel.Name = "itemsLabel";
        itemsLabel.Size = new Size(
            130,
            24);
        itemsLabel.TabIndex = 7;
        itemsLabel.Text = "Items";
        itemsLabel.TextAlign = ContentAlignment.MiddleLeft;

        itemsValueLabel.AutoEllipsis = true;
        itemsValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        itemsValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        itemsValueLabel.Location = new Point(
            170,
            184);
        itemsValueLabel.Name = "itemsValueLabel";
        itemsValueLabel.Size = new Size(
            190,
            24);
        itemsValueLabel.TabIndex = 8;
        itemsValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        statusLabel.AutoSize = false;
        statusLabel.Font = new Font(
            "Bahnschrift",
            9F);
        statusLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        statusLabel.Location = new Point(
            400,
            70);
        statusLabel.Name = "statusLabel";
        statusLabel.Size = new Size(
            110,
            24);
        statusLabel.TabIndex = 9;
        statusLabel.Text = "Status";
        statusLabel.TextAlign = ContentAlignment.MiddleLeft;

        statusValueLabel.AutoSize = false;
        statusValueLabel.Font = new Font(
            "Bahnschrift",
            8.5F,
            FontStyle.Bold);
        statusValueLabel.ForeColor = Color.FromArgb(
            217,
            119,
            6);
        statusValueLabel.BackColor = Color.FromArgb(
            255,
            247,
            237);
        statusValueLabel.Location = new Point(
            520,
            67);
        statusValueLabel.Name = "statusValueLabel";
        statusValueLabel.Size = new Size(
            150,
            28);
        statusValueLabel.TabIndex = 10;
        statusValueLabel.TextAlign = ContentAlignment.MiddleCenter;

        pickupDateLabel.AutoSize = false;
        pickupDateLabel.Font = new Font(
            "Bahnschrift",
            9F);
        pickupDateLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        pickupDateLabel.Location = new Point(
            400,
            108);
        pickupDateLabel.Name = "pickupDateLabel";
        pickupDateLabel.Size = new Size(
            110,
            24);
        pickupDateLabel.TabIndex = 11;
        pickupDateLabel.Text = "Pickup Date";
        pickupDateLabel.TextAlign = ContentAlignment.MiddleLeft;

        pickupDateValueLabel.AutoEllipsis = true;
        pickupDateValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        pickupDateValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        pickupDateValueLabel.Location = new Point(
            520,
            108);
        pickupDateValueLabel.Name = "pickupDateValueLabel";
        pickupDateValueLabel.Size = new Size(
            150,
            24);
        pickupDateValueLabel.TabIndex = 12;
        pickupDateValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        separatorPanel.BackColor = Color.FromArgb(
            226,
            232,
            240);
        separatorPanel.Location = new Point(
            30,
            222);
        separatorPanel.Name = "separatorPanel";
        separatorPanel.Size = new Size(
            640,
            1);
        separatorPanel.TabIndex = 13;

        paymentLabel.AutoSize = false;
        paymentLabel.Font = new Font(
            "Bahnschrift",
            10F,
            FontStyle.Bold);
        paymentLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        paymentLabel.Location = new Point(
            30,
            240);
        paymentLabel.Name = "paymentLabel";
        paymentLabel.Size = new Size(
            640,
            24);
        paymentLabel.TabIndex = 14;
        paymentLabel.Text = "Payment";
        paymentLabel.TextAlign = ContentAlignment.MiddleLeft;

        subtotalLabel.AutoSize = false;
        subtotalLabel.Font = new Font(
            "Bahnschrift",
            9F);
        subtotalLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        subtotalLabel.Location = new Point(
            30,
            276);
        subtotalLabel.Name = "subtotalLabel";
        subtotalLabel.Size = new Size(
            130,
            24);
        subtotalLabel.TabIndex = 15;
        subtotalLabel.Text = "Subtotal";
        subtotalLabel.TextAlign = ContentAlignment.MiddleLeft;

        subtotalValueLabel.AutoSize = false;
        subtotalValueLabel.Font = new Font(
            "Bahnschrift",
            9F);
        subtotalValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        subtotalValueLabel.Location = new Point(
            538,
            276);
        subtotalValueLabel.Name = "subtotalValueLabel";
        subtotalValueLabel.Size = new Size(
            132,
            24);
        subtotalValueLabel.TabIndex = 16;
        subtotalValueLabel.TextAlign = ContentAlignment.MiddleRight;

        discountLabel.AutoSize = false;
        discountLabel.Font = new Font(
            "Bahnschrift",
            9F);
        discountLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        discountLabel.Location = new Point(
            30,
            312);
        discountLabel.Name = "discountLabel";
        discountLabel.Size = new Size(
            130,
            24);
        discountLabel.TabIndex = 17;
        discountLabel.Text = "Discount";
        discountLabel.TextAlign = ContentAlignment.MiddleLeft;

        discountValueLabel.AutoSize = false;
        discountValueLabel.Font = new Font(
            "Bahnschrift",
            9F);
        discountValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        discountValueLabel.Location = new Point(
            538,
            312);
        discountValueLabel.Name = "discountValueLabel";
        discountValueLabel.Size = new Size(
            132,
            24);
        discountValueLabel.TabIndex = 18;
        discountValueLabel.TextAlign = ContentAlignment.MiddleRight;

        discountAmountLabel.AutoSize = false;
        discountAmountLabel.Font = new Font(
            "Bahnschrift",
            9F);
        discountAmountLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        discountAmountLabel.Location = new Point(
            30,
            348);
        discountAmountLabel.Name = "discountAmountLabel";
        discountAmountLabel.Size = new Size(
            180,
            24);
        discountAmountLabel.TabIndex = 19;
        discountAmountLabel.Text = "Discount Amount";
        discountAmountLabel.TextAlign = ContentAlignment.MiddleLeft;

        discountAmountValueLabel.AutoSize = false;
        discountAmountValueLabel.Font = new Font(
            "Bahnschrift",
            9F);
        discountAmountValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        discountAmountValueLabel.Location = new Point(
            538,
            348);
        discountAmountValueLabel.Name = "discountAmountValueLabel";
        discountAmountValueLabel.Size = new Size(
            132,
            24);
        discountAmountValueLabel.TabIndex = 20;
        discountAmountValueLabel.TextAlign = ContentAlignment.MiddleRight;

        totalLabel.AutoSize = false;
        totalLabel.Font = new Font(
            "Bahnschrift",
            10F,
            FontStyle.Bold);
        totalLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        totalLabel.Location = new Point(
            30,
            390);
        totalLabel.Name = "totalLabel";
        totalLabel.Size = new Size(
            200,
            26);
        totalLabel.TabIndex = 21;
        totalLabel.Text = "Total";
        totalLabel.TextAlign = ContentAlignment.MiddleLeft;

        totalValueLabel.AutoSize = false;
        totalValueLabel.Font = new Font(
            "Bahnschrift",
            13F,
            FontStyle.Bold);
        totalValueLabel.ForeColor = Color.FromArgb(
            37,
            99,
            235);
        totalValueLabel.Location = new Point(
            400,
            386);
        totalValueLabel.Name = "totalValueLabel";
        totalValueLabel.Size = new Size(
            270,
            32);
        totalValueLabel.TabIndex = 22;
        totalValueLabel.TextAlign = ContentAlignment.MiddleRight;

        closeButton.BackColor = Color.White;
        closeButton.FlatAppearance.BorderColor = Color.FromArgb(
            203,
            213,
            225);
        closeButton.FlatAppearance.BorderSize = 1;
        closeButton.FlatStyle = FlatStyle.Flat;
        closeButton.Font = new Font(
            "Bahnschrift",
            9F);
        closeButton.ForeColor = Color.FromArgb(
            71,
            85,
            105);
        closeButton.Location = new Point(
            570,
            438);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(
            100,
            34);
        closeButton.TabIndex = 23;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = false;
        closeButton.Click += closeButton_Click;

        AcceptButton = closeButton;
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        CancelButton = closeButton;
        ClientSize = new Size(
            700,
            492);
        Controls.Add(closeButton);
        Controls.Add(totalValueLabel);
        Controls.Add(totalLabel);
        Controls.Add(discountAmountValueLabel);
        Controls.Add(discountAmountLabel);
        Controls.Add(discountValueLabel);
        Controls.Add(discountLabel);
        Controls.Add(subtotalValueLabel);
        Controls.Add(subtotalLabel);
        Controls.Add(paymentLabel);
        Controls.Add(separatorPanel);
        Controls.Add(pickupDateValueLabel);
        Controls.Add(pickupDateLabel);
        Controls.Add(statusValueLabel);
        Controls.Add(statusLabel);
        Controls.Add(itemsValueLabel);
        Controls.Add(itemsLabel);
        Controls.Add(staffValueLabel);
        Controls.Add(staffLabel);
        Controls.Add(customerValueLabel);
        Controls.Add(customerLabel);
        Controls.Add(orderValueLabel);
        Controls.Add(orderLabel);
        Controls.Add(titleLabel);
        Font = new Font(
            "Bahnschrift",
            9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "OrderDetailForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Order Details";

        ResumeLayout(false);
    }
}