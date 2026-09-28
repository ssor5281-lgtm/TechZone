using TechZone.Core.Models;

namespace TechZone.UI.Forms.Dialog;

public partial class InvoiceDetailForm : Form
{
    public InvoiceDetailForm(
        Invoice invoice,
        string customer,
        string staff,
        int itemCount)
    {
        InitializeComponent();

        invoiceValueLabel.Text =
            invoice.InvoiceCode;

        customerValueLabel.Text =
            customer;

        staffValueLabel.Text =
            staff;

        typeValueLabel.Text =
            invoice.DisplaySaleType;

        itemsValueLabel.Text =
            itemCount.ToString();

        dateValueLabel.Text =
            invoice.InvoiceDate.ToString("dd MMM yyyy");

        subtotalValueLabel.Text =
            $"${invoice.SubtotalAmount:N2}";

        discountValueLabel.Text =
            $"${invoice.DiscountAmount:N2}";

        totalValueLabel.Text =
            $"${invoice.TotalAmount:N2}";
    }

    private void closeButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}