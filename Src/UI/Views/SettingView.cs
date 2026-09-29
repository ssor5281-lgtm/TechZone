using TechZone.Core.Enums;
using TechZone.Core.Helpers;
using TechZone.Core.Settings;
using TechZone.Data.Database;
using TechZone.Data.Services;
using TechZone.UI.Forms;
using TechZone.UI.Forms.Dialog;
using TechZone.UI.Theme;

namespace TechZone.UI.Views;

public partial class SettingView : UserControl
{
    public SettingView()
    {
        InitializeComponent();

        ConfigureRoleAccess();

        Load += SettingView_Load;

        themeComboBox.SelectedIndexChanged +=
            ThemeComboBox_SelectedIndexChanged;

        defaultDiscountNumericUpDown.ValueChanged +=
            DefaultDiscountNumericUpDown_ValueChanged;

        sidebarStyleComboBox.SelectedIndexChanged +=
            SidebarStyleComboBox_SelectedIndexChanged;

        allowSellingWhenStockZeroCheckBox.CheckedChanged +=
            AllowSellingWhenStockZeroCheckBox_CheckedChanged;

        confirmOrderCheckBox.CheckedChanged +=
            ConfirmOrderCheckBox_CheckedChanged;

        rememberUsernameCheckBox.CheckedChanged +=
            RememberUsernameCheckBox_CheckedChanged;

        confirmLogoutCheckBox.CheckedChanged +=
            ConfirmLogoutCheckBox_CheckedChanged;

        confirmQuickSaleCheckBox.CheckedChanged +=
            ConfirmQuickSaleCheckBox_CheckedChanged;

        lowStockThresholdNumericUpDown.ValueChanged +=
            LowStockThresholdNumericUpDown_ValueChanged;

        exportDatabaseButton.Click +=
            ExportDatabaseButton_Click;

        importDatabaseButton.Click +=
            ImportDatabaseButton_Click;

        resetDatabaseButton.Click +=
            ResetDatabaseButton_Click;
    }

    private void ConfigureRoleAccess()
    {
        Role role =
            AuthService.CurrentUser?.Role ??
            Role.Staff;

        bool isAdmin =
            role == Role.Admin;

        bool isManager =
            role == Role.Manager;

        bool isStaff =
            role == Role.Staff;

        if (isStaff)
        {
            HideSaleSection();
            HideInventorySection();
            HideSystemSection();
            HideAboutSection();

            return;
        }

        if (isManager)
        {
            exportDatabaseButton.Visible = true;
            importDatabaseButton.Visible = true;
            resetDatabaseButton.Visible = true;

            return;
        }

        if (isAdmin)
        {
            exportDatabaseButton.Visible = true;
            importDatabaseButton.Visible = true;
            resetDatabaseButton.Visible = true;
        }
    }

    private void HideSaleSection()
    {
        saleIcon.Visible = false;
        saleLabel.Visible = false;
        saleDescription.Visible = false;
        defaultDiscountLabel.Visible = false;
        defaultDiscountNumericUpDown.Visible = false;
        confirmQuickSaleCheckBox.Visible = false;
        confirmOrderCheckBox.Visible = false;
    }

    private void HideInventorySection()
    {
        inventoryIcon.Visible = false;
        inventoryLabel.Visible = false;
        inventoryDescription.Visible = false;
        lowStockThresholdLabel.Visible = false;
        lowStockThresholdNumericUpDown.Visible = false;
        allowSellingWhenStockZeroCheckBox.Visible = false;
    }

    private void HideSystemSection()
    {
        systemIcon.Visible = false;
        systemLabel.Visible = false;
        systemDescription.Visible = false;
        rememberUsernameCheckBox.Visible = false;
        confirmLogoutCheckBox.Visible = false;
        exportDatabaseButton.Visible = false;
        importDatabaseButton.Visible = false;
        resetDatabaseButton.Visible = false;
    }

    private void HideAboutSection()
    {
        aboutIcon.Visible = false;
        aboutLabel.Visible = false;
        aboutDescription.Visible = false;
        applicationNameLabel.Visible = false;
        versionLabel.Visible = false;
        aboutTextLabel.Visible = false;
    }

    private void SettingView_Load(
        object? sender,
        EventArgs e)
    {
        LoadAppearance();
        LoadSaleSettings();
        LoadInventorySettings();

        rememberUsernameCheckBox.Checked =
            AppSettings.RememberUsername;

        confirmLogoutCheckBox.Checked =
            AppSettings.ConfirmLogout;

        confirmOrderCheckBox.Checked =
            AppSettings.ConfirmOrder;
    }

    private void LoadAppearance()
    {
        themeComboBox.Items.Clear();

        themeComboBox.Items.Add("Royal Blue");
        themeComboBox.Items.Add("Light");
        themeComboBox.Items.Add("Dark");

        themeComboBox.SelectedItem =
            AppSettings.Theme switch
            {
                TzTheme.Light => "Light",
                TzTheme.Dark => "Dark",
                _ => "Royal Blue"
            };
        sidebarStyleComboBox.SelectedIndex =
            AppSettings.CompactSidebar
                ? 1
                : 0;
    }

    private void ThemeComboBox_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {
        if (themeComboBox.SelectedItem is not string theme)
            return;

        AppSettings.Theme =
            theme switch
            {
                "Light" => TzTheme.Light,
                "Dark" => TzTheme.Dark,
                _ => TzTheme.TzRoyalBlue
            };

        if (FindForm() is MainForm mainForm)
            mainForm.ApplyTheme();
    }

    private void SidebarStyleComboBox_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {
        if (sidebarStyleComboBox.SelectedItem is not string style)
            return;

        AppSettings.CompactSidebar =
            style == "Compact";

        if (FindForm() is MainForm mainForm)
            mainForm.ApplySidebarStyle();
    }

    private void LoadSaleSettings()
    {
        decimal discount =
            Math.Clamp(
                AppSettings.DefaultDiscount,
                defaultDiscountNumericUpDown.Minimum,
                defaultDiscountNumericUpDown.Maximum);

        defaultDiscountNumericUpDown.Value =
            discount;

        confirmQuickSaleCheckBox.Checked =
            AppSettings.ConfirmQuickSale;
    }

    private void LoadInventorySettings()
    {
        lowStockThresholdNumericUpDown.Value =
            Math.Clamp(
                AppSettings.LowStockThreshold,
                (int)lowStockThresholdNumericUpDown.Minimum,
                (int)lowStockThresholdNumericUpDown.Maximum);

        allowSellingWhenStockZeroCheckBox.Checked =
            AppSettings.AllowSellingWhenStockZero;
    }

    private void DefaultDiscountNumericUpDown_ValueChanged(
        object? sender,
        EventArgs e)
    {
        AppSettings.DefaultDiscount =
            defaultDiscountNumericUpDown.Value;
    }

    private void ConfirmQuickSaleCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        AppSettings.ConfirmQuickSale =
            confirmQuickSaleCheckBox.Checked;
    }

    private void LowStockThresholdNumericUpDown_ValueChanged(
        object? sender,
        EventArgs e)
    {
        AppSettings.LowStockThreshold =
            (int)lowStockThresholdNumericUpDown.Value;
    }

    private void AllowSellingWhenStockZeroCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        AppSettings.AllowSellingWhenStockZero =
            allowSellingWhenStockZeroCheckBox.Checked;
    }

    private void ConfirmOrderCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        AppSettings.ConfirmOrder =
            confirmOrderCheckBox.Checked;
    }

    private void RememberUsernameCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        AppSettings.RememberUsername =
            rememberUsernameCheckBox.Checked;

        if (!rememberUsernameCheckBox.Checked)
        {
            AppSettings.RememberedUsername =
                string.Empty;
        }
    }

    private void ConfirmLogoutCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        AppSettings.ConfirmLogout =
            confirmLogoutCheckBox.Checked;
    }

    private void ExportDatabaseButton_Click(
        object? sender,
        EventArgs e)
    {
        Role role =
            AuthService.CurrentUser?.Role ??
            Role.Staff;

        if (role == Role.Manager)
        {
            MessageBox.Show(
                "Only an Administrator can export the database.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (role != Role.Admin)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;
            exportDatabaseButton.Enabled = false;

            string backupPath =
                DatabaseBackupHelper.Backup();

            MessageBox.Show(
                $"""
                Database backup created successfully.

                File:
                {Path.GetFileName(backupPath)}

                Location:
                {backupPath}
                """,
                "Export Database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Export Database Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
            exportDatabaseButton.Enabled = true;
        }
    }

    private void ImportDatabaseButton_Click(
        object? sender,
        EventArgs e)
    {
        Role role =
            AuthService.CurrentUser?.Role ??
            Role.Staff;

        if (role == Role.Manager)
        {
            MessageBox.Show(
                "Only an Administrator can import the database.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (role != Role.Admin)
            return;

        using ImportDatabaseForm form =
            new();

        form.ShowDialog(FindForm());
    }

    private async void ResetDatabaseButton_Click(
        object? sender,
        EventArgs e)
    {
        Role role =
            AuthService.CurrentUser?.Role ??
            Role.Staff;

        if (role == Role.Manager)
        {
            MessageBox.Show(
                "Only an Administrator can reset the database.",
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (role != Role.Admin)
            return;

        DialogResult result =
            MessageBox.Show(
                """
                Reset the TechZone database?

                This will permanently delete:

                • Products
                • Categories
                • Inventory
                • Customers
                • Users
                • Sales
                • Orders
                • Invoices

                The database structure and default roles
                will be recreated.

                This action cannot be undone.

                Are you sure you want to continue?
                """,
                "Reset Database",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;

            resetDatabaseButton.Enabled = false;
            exportDatabaseButton.Enabled = false;
            importDatabaseButton.Enabled = false;

            await DatabaseInitializer.ResetAsync();

            MessageBox.Show(
                """
                Database reset successfully.

                TechZone will restart automatically.
                """,
                "Reset Database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            string applicationPath =
                Application.ExecutablePath;

            System.Diagnostics.Process.Start(
                new System.Diagnostics.ProcessStartInfo
                {
                    FileName = applicationPath,
                    UseShellExecute = true
                });

            Application.Exit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Reset Database Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;

            resetDatabaseButton.Enabled = true;
            exportDatabaseButton.Enabled = true;
            importDatabaseButton.Enabled = true;
        }
    }
}