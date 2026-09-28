using TechZone.UI.Effects;
using TechZone.UI.Forms;

namespace TechZone.UI.Views;

public partial class PointOfSaleView : UserControl
{
    private readonly string _initialPage;

    public PointOfSaleView(string initialPage = "Sale")
    {
        InitializeComponent();

        _initialPage = initialPage;

        ConfigureNavigationEffects();
        ConfigureNavigation();

        Load += PointOfSaleView_Load;

        switch (_initialPage)
        {
            case "Order":
                orderButton.PerformClick();
                break;

            case "Invoice History":
                invoiceButton.PerformClick();
                break;

            default:
                saleButton.PerformClick();
                break;
        }
    }

    private void PointOfSaleView_Load(
        object? sender,
        EventArgs e)
    {
        if (FindForm() is MainForm mainForm)
        {
            mainForm.SetTopbar(
                "Point of Sale",
                _initialPage);
        }
    }
    
    public void OpenPage(string page)
    {
        switch (page)
        {
            case "Order":
                orderButton.PerformClick();
                break;

            case "Invoice History":
                invoiceButton.PerformClick();
                break;

            default:
                saleButton.PerformClick();
                break;
        }
    }

    private void ConfigureNavigationEffects()
    {
        ConfigureButton(saleButton);
        ConfigureButton(orderButton);
        ConfigureButton(invoiceButton);
    }

    private void ConfigureButton(Button button)
    {
        button.TzEffect(
            nameof(Control.BackColor),
            Color.White,
            Color.FromArgb(248, 250, 252),
            Color.FromArgb(239, 246, 255),
            group: "sale-bg"
        );

        button.ForeColor =
            Color.FromArgb(71, 85, 105);
    }

    private void ConfigureNavigation()
    {
        saleButton.Click += (_, _) =>
            SetActiveTab(
                saleButton,
                new SaleView(),
                "Sale");

        orderButton.Click += (_, _) =>
            SetActiveTab(
                orderButton,
                new OrderView(),
                "Order");

        invoiceButton.Click += (_, _) =>
            SetActiveTab(
                invoiceButton,
                new SaleHistoryView(),
                "Invoice History");
    }

    private void SetActiveTab(
        Button button,
        UserControl content,
        string page)
    {
        ResetTabButtons();

        button.BackColor =
            Color.FromArgb(239, 246, 255);

        button.ForeColor =
            Color.FromArgb(37, 99, 235);

        navIndicator.Left = button.Left;
        navIndicator.BringToFront();

        LoadContent(content);

        if (FindForm() is MainForm mainForm)
        {
            mainForm.SetTopbar(
                "Point of Sale",
                page);
        }
    }

    private void ResetTabButtons()
    {
        foreach (var button in new[]
                 {
                     saleButton,
                     orderButton,
                     invoiceButton
                 })
        {
            button.BackColor = Color.White;
            button.ForeColor =
                Color.FromArgb(71, 85, 105);
        }
    }

    private void LoadContent(UserControl content)
    {
        contentPanel.Controls.Clear();

        content.Dock = DockStyle.Fill;
        contentPanel.Controls.Add(content);
        content.BringToFront();
    }
}