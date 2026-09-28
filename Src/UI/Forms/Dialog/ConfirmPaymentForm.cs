namespace TechZone.UI.Forms.Dialog;

public enum PaymentResult
{
    None,
    Cancelled,
    BackToPos,
    ViewInvoice
}

public partial class ConfirmPaymentForm : Form
{
    private bool _paymentConfirmed;

    public PaymentResult Result { get; private set; }

    public int InvoiceNumber { get; private set; }

    public ConfirmPaymentForm()
    {
        InitializeComponent();

        Result = PaymentResult.None;
    }

    public ConfirmPaymentForm(
        string? invoice,
        string? customer,
        string? staff,
        int items,
        decimal subtotal,
        decimal discount,
        decimal total) : this()
    {
        const string defaultValue = "----------";

        invoiceValueLabel.Text =
            FormatValue(invoice, defaultValue);

        customerValueLabel.Text =
            FormatValue(customer, defaultValue);

        staffValueLabel.Text =
            FormatValue(staff, defaultValue);

        itemsValueLabel.Text =
            items.ToString();

        subtotalValueLabel.Text =
            $@"${subtotal:N2}";

        discountValueLabel.Text =
            $@"${discount:N2}";

        totalValueLabel.Text =
            $@"${total:N2}";
    }

    private static string FormatValue(
        string? value,
        string defaultValue)
    {
        return string.IsNullOrWhiteSpace(value)
            ? defaultValue
            : value;
    }

    public void ShowCompleted(int invoiceNumber)
    {
        _paymentConfirmed = true;
        InvoiceNumber = invoiceNumber;

        invoiceValueLabel.Text =
            $@"INV-{invoiceNumber:D5}";

        titleLabel.Text = @"Sale Completed";

        messageLabel.Text =
            @"The sale has been completed successfully.";

        confirmButton.Text =
            @"View Invoice";

        cancelButton.Text =
            @"Back to POS";

        Text = @"Sale Completed";
    }

    private void confirmButton_Click(
        object sender,
        EventArgs e)
    {
        if (_paymentConfirmed)
        {
            Result = PaymentResult.ViewInvoice;

            DialogResult = DialogResult.OK;
            Close();

            return;
        }

        Result = PaymentResult.None;

        DialogResult = DialogResult.OK;
        Close();
    }

    private void cancelButton_Click(
        object sender,
        EventArgs e)
    {
        if (_paymentConfirmed)
        {
            Result = PaymentResult.BackToPos;

            DialogResult = DialogResult.OK;
            Close();

            return;
        }

        Result = PaymentResult.Cancelled;

        DialogResult = DialogResult.Cancel;
        Close();
    }
}