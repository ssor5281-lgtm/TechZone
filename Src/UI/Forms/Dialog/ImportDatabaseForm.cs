using TechZone.Core.Helpers;

namespace TechZone.UI.Forms.Dialog;

public partial class ImportDatabaseForm : Form
{
    public ImportDatabaseForm()
    {
        InitializeComponent();

        Load += ImportDatabaseForm_Load;
        importButton.Click += ImportButton_Click;
        cancelButton.Click += CancelButton_Click;
    }

    private void ImportDatabaseForm_Load(
        object? sender,
        EventArgs e)
    {
        try
        {
            backupComboBox.Items.Clear();

            List<string> backups =
                DatabaseBackupHelper.GetBackups();

            foreach (string backup in backups)
                backupComboBox.Items.Add(backup);

            importButton.Enabled =
                backupComboBox.Items.Count > 0;

            if (backupComboBox.Items.Count > 0)
                backupComboBox.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                @"Load Backups Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            Close();
        }
    }

    private void ImportButton_Click(
        object? sender,
        EventArgs e)
    {
        if (backupComboBox.SelectedItem is not string backup)
            return;

        DialogResult result =
            MessageBox.Show(
                $"""
                Restore database from:

                {backup}

                The current database will be replaced.

                Are you sure you want to continue?
                """,
                @"Import Database",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;
            importButton.Enabled = false;
            cancelButton.Enabled = false;

            DatabaseBackupHelper.Restore(backup);

            MessageBox.Show(
                """
                Database imported successfully.

                TechZone will restart automatically.
                """,
                @"Import Database",
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
                @"Import Database Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
            importButton.Enabled = true;
            cancelButton.Enabled = true;
        }
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}