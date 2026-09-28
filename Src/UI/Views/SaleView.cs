using TechZone.UI.Forms.Create;

namespace TechZone.UI.Views;

public partial class SaleView : UserControl
{
    public SaleView()
    {
        InitializeComponent();

        Resize += SaleView_Resize;

        CenterContent();
    }

    private void SaleView_Resize(
        object? sender,
        EventArgs e)
    {
        CenterContent();
    }

    private void CenterContent()
    {
        if (contentContainer == null)
            return;

        contentContainer.Left =
            (ClientSize.Width -
             contentContainer.Width) / 2;

        contentContainer.Top =
            (ClientSize.Height -
             contentContainer.Height) / 2;
    }

    private void newSaleButton_Click(
        object sender,
        EventArgs e)
    {
        using var form = new AddSaleForm();

        form.ShowDialog(FindForm());
    }

    private void quickSaleButton_Click(
        object sender,
        EventArgs e)
    {
        using var form = new AddQuickSaleForm();

        form.ShowDialog(FindForm());
    }

    private void newOrderButton_Click(
        object sender,
        EventArgs e)
    {
        using var form = new AddOrderForm();
        form.ShowDialog(FindForm());
    }
}