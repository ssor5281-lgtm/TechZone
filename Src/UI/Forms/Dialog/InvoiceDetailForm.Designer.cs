using System.ComponentModel;

namespace TechZone.UI.Forms.Dialog;

partial class InvoiceDetailForm
{
    private IContainer components = null!;

    private Label titleLabel;

    private Label invoiceLabel;
    private Label invoiceValueLabel;

    private Label customerLabel;
    private Label customerValueLabel;

    private Label staffLabel;
    private Label staffValueLabel;

    private Label typeLabel;
    private Label typeValueLabel;

    private Label itemsLabel;
    private Label itemsValueLabel;

    private Label dateLabel;
    private Label dateValueLabel;

    private Panel separatorPanel;

    private Label paymentLabel;

    private Label subtotalLabel;
    private Label subtotalValueLabel;

    private Label discountLabel;
    private Label discountValueLabel;

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

        invoiceLabel = new Label();
        invoiceValueLabel = new Label();

        customerLabel = new Label();
        customerValueLabel = new Label();

        staffLabel = new Label();
        staffValueLabel = new Label();

        typeLabel = new Label();
        typeValueLabel = new Label();

        itemsLabel = new Label();
        itemsValueLabel = new Label();

        dateLabel = new Label();
        dateValueLabel = new Label();

        separatorPanel = new Panel();

        paymentLabel = new Label();

        subtotalLabel = new Label();
        subtotalValueLabel = new Label();

        discountLabel = new Label();
        discountValueLabel = new Label();

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
        titleLabel.Text = "Invoice Details";
        titleLabel.TextAlign = ContentAlignment.MiddleLeft;

        invoiceLabel.AutoSize = false;
        invoiceLabel.Font = new Font(
            "Bahnschrift",
            9F);
        invoiceLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        invoiceLabel.Location = new Point(
            30,
            70);
        invoiceLabel.Name = "invoiceLabel";
        invoiceLabel.Size = new Size(
            130,
            24);
        invoiceLabel.TabIndex = 1;
        invoiceLabel.Text = "Invoice";
        invoiceLabel.TextAlign = ContentAlignment.MiddleLeft;

        invoiceValueLabel.AutoEllipsis = true;
        invoiceValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        invoiceValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        invoiceValueLabel.Location = new Point(
            170,
            70);
        invoiceValueLabel.Name = "invoiceValueLabel";
        invoiceValueLabel.Size = new Size(
            190,
            24);
        invoiceValueLabel.TabIndex = 2;
        invoiceValueLabel.TextAlign = ContentAlignment.MiddleLeft;

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

        typeLabel.AutoSize = false;
        typeLabel.Font = new Font(
            "Bahnschrift",
            9F);
        typeLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        typeLabel.Location = new Point(
            400,
            70);
        typeLabel.Name = "typeLabel";
        typeLabel.Size = new Size(
            110,
            24);
        typeLabel.TabIndex = 7;
        typeLabel.Text = "Sale Type";
        typeLabel.TextAlign = ContentAlignment.MiddleLeft;

        typeValueLabel.AutoEllipsis = true;
        typeValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        typeValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        typeValueLabel.Location = new Point(
            520,
            70);
        typeValueLabel.Name = "typeValueLabel";
        typeValueLabel.Size = new Size(
            150,
            24);
        typeValueLabel.TabIndex = 8;
        typeValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        itemsLabel.AutoSize = false;
        itemsLabel.Font = new Font(
            "Bahnschrift",
            9F);
        itemsLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        itemsLabel.Location = new Point(
            400,
            108);
        itemsLabel.Name = "itemsLabel";
        itemsLabel.Size = new Size(
            110,
            24);
        itemsLabel.TabIndex = 9;
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
            520,
            108);
        itemsValueLabel.Name = "itemsValueLabel";
        itemsValueLabel.Size = new Size(
            150,
            24);
        itemsValueLabel.TabIndex = 10;
        itemsValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        dateLabel.AutoSize = false;
        dateLabel.Font = new Font(
            "Bahnschrift",
            9F);
        dateLabel.ForeColor = Color.FromArgb(
            100,
            116,
            139);
        dateLabel.Location = new Point(
            400,
            146);
        dateLabel.Name = "dateLabel";
        dateLabel.Size = new Size(
            110,
            24);
        dateLabel.TabIndex = 11;
        dateLabel.Text = "Sale Date";
        dateLabel.TextAlign = ContentAlignment.MiddleLeft;

        dateValueLabel.AutoEllipsis = true;
        dateValueLabel.Font = new Font(
            "Bahnschrift",
            9.5F,
            FontStyle.Bold);
        dateValueLabel.ForeColor = Color.FromArgb(
            30,
            41,
            59);
        dateValueLabel.Location = new Point(
            520,
            146);
        dateValueLabel.Name = "dateValueLabel";
        dateValueLabel.Size = new Size(
            150,
            24);
        dateValueLabel.TabIndex = 12;
        dateValueLabel.TextAlign = ContentAlignment.MiddleLeft;

        separatorPanel.BackColor = Color.FromArgb(
            226,
            232,
            240);
        separatorPanel.Location = new Point(
            30,
            194);
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
            212);
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
            248);
        subtotalLabel.Name = "subtotalLabel";
        subtotalLabel.Size = new Size(
            180,
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
            248);
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
            284);
        discountLabel.Name = "discountLabel";
        discountLabel.Size = new Size(
            180,
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
            284);
        discountValueLabel.Name = "discountValueLabel";
        discountValueLabel.Size = new Size(
            132,
            24);
        discountValueLabel.TabIndex = 18;
        discountValueLabel.TextAlign = ContentAlignment.MiddleRight;

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
            326);
        totalLabel.Name = "totalLabel";
        totalLabel.Size = new Size(
            200,
            26);
        totalLabel.TabIndex = 19;
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
            322);
        totalValueLabel.Name = "totalValueLabel";
        totalValueLabel.Size = new Size(
            270,
            32);
        totalValueLabel.TabIndex = 20;
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
            374);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(
            100,
            34);
        closeButton.TabIndex = 21;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = false;
        closeButton.Click += closeButton_Click;

        AcceptButton = closeButton;
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        CancelButton = closeButton;
        ClientSize = new Size(
            700,
            428);
        Controls.Add(closeButton);
        Controls.Add(totalValueLabel);
        Controls.Add(totalLabel);
        Controls.Add(discountValueLabel);
        Controls.Add(discountLabel);
        Controls.Add(subtotalValueLabel);
        Controls.Add(subtotalLabel);
        Controls.Add(paymentLabel);
        Controls.Add(separatorPanel);
        Controls.Add(dateValueLabel);
        Controls.Add(dateLabel);
        Controls.Add(itemsValueLabel);
        Controls.Add(itemsLabel);
        Controls.Add(typeValueLabel);
        Controls.Add(typeLabel);
        Controls.Add(staffValueLabel);
        Controls.Add(staffLabel);
        Controls.Add(customerValueLabel);
        Controls.Add(customerLabel);
        Controls.Add(invoiceValueLabel);
        Controls.Add(invoiceLabel);
        Controls.Add(titleLabel);
        Font = new Font(
            "Bahnschrift",
            9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "InvoiceDetailForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Invoice Details";

        ResumeLayout(false);
    }
}