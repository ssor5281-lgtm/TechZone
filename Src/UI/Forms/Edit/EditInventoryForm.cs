using TechZone.Core.Models;

namespace TechZone.UI.Forms.Edit;

public partial class EditInventoryForm : Form
{
    private int Stock { get; set; }

    public int UpdatedStock => Stock;

    public EditInventoryForm(Inventory inventory)
    {
        InitializeComponent();

        productValueLabel.Text = inventory.ProductName;
        Stock = inventory.Stock;
        stockValueLabel.Text = Stock.ToString();

        decreaseButton.Click += DecreaseButton_Click;
        increaseButton.Click += IncreaseButton_Click;
        saveButton.Click += SaveButton_Click;
    }

    private void DecreaseButton_Click(
        object? sender,
        EventArgs e)
    {
        if (int.TryParse(
                stockValueLabel.Text,
                out int stock))
        {
            Stock = Math.Max(0, stock - 1);
            stockValueLabel.Text = Stock.ToString();
        }
    }

    private void IncreaseButton_Click(
        object? sender,
        EventArgs e)
    {
        if (int.TryParse(
                stockValueLabel.Text,
                out int stock))
        {
            Stock = stock + 1;
            stockValueLabel.Text = Stock.ToString();
        }
    }

    private void SaveButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!int.TryParse(
                stockValueLabel.Text,
                out int stock))
        {
            MessageBox.Show(
                @"Invalid stock value.",
                @"Invalid Stock",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        Stock = Math.Max(0, stock);

        DialogResult = DialogResult.OK;
        Close();
    }
}