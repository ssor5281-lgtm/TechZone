using System.Net.Mail;
using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Edit;

public partial class EditCustomerForm : Form
{
    private readonly CustomerRepository _customerRepo = new();

    private readonly Customer _customer;

    public EditCustomerForm(Customer customer)
    {
        InitializeComponent();

        _customer = customer;

        Load += EditCustomerForm_Load;
        saveButton.Click += SaveButton_Click;
        cancelButton.Click += CancelButton_Click;
    }

    // =========================================================
    // LOAD
    // =========================================================

    private void EditCustomerForm_Load(
        object? sender,
        EventArgs e)
    {
        LoadCustomer();
    }

    private void LoadCustomer()
    {
        nameTextBox.Text =
            _customer.Name;

        phoneTextBox.Text =
            _customer.Phone;

        emailTextBox.Text =
            _customer.Email;
    }

    // =========================================================
    // SAVE
    // =========================================================

    private void SaveButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        var customer = new Customer
        {
            Id = _customer.Id,
            Name = nameTextBox.Text.Trim(),
            Phone = phoneTextBox.Text.Trim(),
            Email = emailTextBox.Text.Trim()
        };

        bool updated =
            _customerRepo.Update(customer);

        if (!updated)
        {
            MessageBox.Show(
                @"Failed to update customer.",
                @"Edit Customer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            @"Customer updated successfully.",
            @"Edit Customer",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult =
            DialogResult.OK;

        Close();
    }

    // =========================================================
    // VALIDATION
    // =========================================================

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
                @"Customer name is required.",
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
                @"Phone number is required.",
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

    // =========================================================
    // CANCEL
    // =========================================================

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.Cancel;

        Close();
    }
}