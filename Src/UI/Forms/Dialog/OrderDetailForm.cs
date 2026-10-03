using TechZone.Core.Enums;
using TechZone.Core.Models;

namespace TechZone.UI.Forms.Dialog;

public partial class OrderDetailForm : Form
{
    public OrderDetailForm(
        Sale.Order order,
        string orderCode,
        string customer,
        string staff,
        int itemCount)
    {
        InitializeComponent();

        orderValueLabel.Text = orderCode;
        customerValueLabel.Text = customer;
        staffValueLabel.Text = staff;
        itemsValueLabel.Text = itemCount.ToString();

        statusValueLabel.Text =
            order.Status switch
            {
                SaleStatus.Pending => "Pending",
                SaleStatus.Cancelled => "Canceled",
                SaleStatus.Completed => "Completed",
                _ => "-"
            };

        pickupDateValueLabel.Text =
            order.PickupDate?.ToString("dd MMM yyyy") ?? "-";

        subtotalValueLabel.Text =
            $@"${order.SubtotalAmount:N2}";

        discountValueLabel.Text =
            $@"{order.DiscountPercent:N2}%";

        discountAmountValueLabel.Text =
            $@"${order.DiscountAmount:N2}";

        totalValueLabel.Text =
            $@"${order.TotalAmount:N2}";

        ConfigureStatus();
    }

    private void ConfigureStatus()
    {
        switch (statusValueLabel.Text)
        {
            case "Pending":
                statusValueLabel.ForeColor =
                    Color.FromArgb(217, 119, 6);
                statusValueLabel.BackColor =
                    Color.FromArgb(255, 247, 237);
                break;

            case "Completed":
                statusValueLabel.ForeColor =
                    Color.FromArgb(22, 163, 74);
                statusValueLabel.BackColor =
                    Color.FromArgb(240, 253, 244);
                break;

            case "Canceled":
                statusValueLabel.ForeColor =
                    Color.FromArgb(220, 38, 38);
                statusValueLabel.BackColor =
                    Color.FromArgb(254, 242, 242);
                break;

            default:
                statusValueLabel.ForeColor =
                    Color.FromArgb(71, 85, 105);
                statusValueLabel.BackColor =
                    Color.FromArgb(248, 250, 252);
                break;
        }
    }

    private void closeButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}