
using System.Net.Mail;
using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Create;

public partial class AddCustomerForm : Form
{
    private readonly CustomerRepository _customerRepo = new();

    public AddCustomerForm()
    {
        InitializeComponent();

        addButton.Click += AddButton_Click;
        cancelButton.Click += CancelButton_Click;
    }

    private void AddButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        var customer = new Customer
        {
            Name = nameTextBox.Text.Trim(),
            Phone = phoneTextBox.Text.Trim(),
            Email = emailTextBox.Text.Trim()
        };

        bool added =
            _customerRepo.Add(customer);

        if (!added)
        {
            MessageBox.Show(
                @"Failed to add customer.",
                @"Add Customer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            @"Customer added successfully.",
            @"Add Customer",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult = DialogResult.OK;
        Close();
    }

    private bool ValidateInput()
    {
        string name =
            nameTextBox.Text.Trim();

        string phone =
            phoneTextBox.Text.Trim();

        string email =
            emailTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(
                @"Please enter a customer name.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nameTextBox.Focus();
            return false;
        }

        if (name.Length < 2)
        {
            MessageBox.Show(
                @"Customer name must be at least 2 characters.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nameTextBox.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            MessageBox.Show(
                @"Please enter a phone number.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            phoneTextBox.Focus();
            return false;
        }

        if (phone.Length < 7)
        {
            MessageBox.Show(
                @"Phone number must be at least 7 characters.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            phoneTextBox.Focus();
            return false;
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            try
            {
                _ = new MailAddress(email);
            }
            catch
            {
                MessageBox.Show(
                    @"Please enter a valid email address.",
                    @"Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                emailTextBox.Focus();
                return false;
            }
        }

        return true;
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.Cancel;

        Close();
    }
}

