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
        stockTextBox.Text = Stock.ToString();

        decreaseButton.Click += DecreaseButton_Click;
        increaseButton.Click += IncreaseButton_Click;
        saveButton.Click += SaveButton_Click;
        stockTextBox.KeyPress += StockTextBox_KeyPress;
    }

    private void DecreaseButton_Click(object? sender, EventArgs e)
    {
        if (int.TryParse(stockTextBox.Text, out int stock))
            stockTextBox.Text = Math.Max(0, stock - 1).ToString();

        stockTextBox.Focus();
        stockTextBox.SelectAll();
    }

    private void IncreaseButton_Click(object? sender, EventArgs e)
    {
        if (int.TryParse(stockTextBox.Text, out int stock))
            stockTextBox.Text = (stock + 1).ToString();

        stockTextBox.Focus();
        stockTextBox.SelectAll();
    }

    private void StockTextBox_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(stockTextBox.Text, out int stock))
        {
            MessageBox.Show(
                @"Please enter a valid stock number.",
                @"Invalid Stock",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            stockTextBox.Focus();
            return;
        }

        Stock = Math.Max(0, stock);
        DialogResult = DialogResult.OK;
        Close();
    }
}