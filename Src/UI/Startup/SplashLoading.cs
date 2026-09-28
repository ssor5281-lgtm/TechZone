using Microsoft.Data.SqlClient;
using TechZone.Data.Database;
using TechZone.Data.Services;
using TechZone.UI.Forms;

namespace TechZone.UI.Startup;

public partial class SplashLoading : Form
{
    private readonly AuthService? _authService;
    private bool _starting;
    private bool _closing;

    public SplashLoading()
    {
        InitializeComponent();

        Icon = new Icon(
            Path.Combine(
                AppContext.BaseDirectory,
                "techzone.ico"));

        if (DesignMode)
            return;

        _authService = new AuthService();

        Load += SplashLoading_Load;
    }

    private async void SplashLoading_Load(
        object? sender,
        EventArgs e)
    {
        await StartApplicationAsync();
    }

    private async Task StartApplicationAsync()
    {
        if (_starting || _closing)
            return;

        _starting = true;

        try
        {
            SetProgress("Starting TechZone...", 5);
            await Task.Delay(300);

            SetProgress(
                "Starting database service...",
                15);

            bool serviceReady =
                await DatabaseService.EnsureRunningAsync();

            if (!serviceReady)
            {
                ShowError(
                    "SQL Server Service",
                    "TechZone could not start the SQL Server service.");

                return;
            }

            SetProgress(
                "Database service ready...",
                25);

            await Task.Delay(300);

            SetProgress(
                "Preparing database...",
                30);

            bool databaseReady;

            try
            {
                databaseReady =
                    await DatabaseInitializer.InitializeAsync();
            }
            catch (Exception ex)
            {
                ShowException(
                    "Database Initialization",
                    ex);

                return;
            }

            if (!databaseReady)
            {
                ShowError(
                    "Database Initialization",
                    "DatabaseInitializer returned false.");

                return;
            }

            SetProgress(
                "Database ready...",
                45);

            await Task.Delay(300);

            SetProgress(
                "Connecting to database...",
                50);

            bool databaseConnected;

            try
            {
                databaseConnected =
                    await ConnectToDatabaseAsync();
            }
            catch (Exception ex)
            {
                ShowException(
                    "Database Connection",
                    ex);

                return;
            }

            if (!databaseConnected)
            {
                ShowError(
                    "Database Connection",
                    "TechZone could not connect to TechZoneDb.");
                
                return;
            }

            SetProgress(
                "Database connected...",
                55);

            await Task.Delay(250);

            bool hasUsers =
                await _authService!.HasUsersAsync();

            SetProgress(
                "Checking users...",
                65);

            await Task.Delay(200);

            bool hasAdmin =
                await _authService.HasAdminAsync();

            SetProgress(
                "Checking administrator...",
                75);

            await Task.Delay(250);

            if (!hasUsers || !hasAdmin)
            {
                SetProgress(
                    "Administrator account required...",
                    85);

                await Task.Delay(500);

                SetProgress(
                    "Opening setup...",
                    100);

                await Task.Delay(400);

                OpenNext(new RegisterForm());

                return;
            }

            SetProgress(
                "Preparing interface...",
                90);

            await Task.Delay(500);

            SetProgress(
                "Ready.",
                100);

            await Task.Delay(400);

            OpenNext(new LoginForm());
        }
        catch (Exception ex)
        {
            ShowException(
                "TechZone Startup",
                ex);
        }
        finally
        {
            _starting = false;
        }
    }

    private async Task<bool> ConnectToDatabaseAsync()
    {
        const int maxAttempts = 10;

        for (int attempt = 1;
             attempt <= maxAttempts;
             attempt++)
        {
            try
            {
                int progress =
                    30 +
                    (int)(
                        attempt /
                        (double)maxAttempts *
                        20);

                SetProgress(
                    $"Connecting to database... {attempt}/{maxAttempts}",
                    progress);

                await using SqlConnection connection =
                    DatabaseConnection.Create();

                await connection.OpenAsync();

                await using SqlCommand command =
                    new(
                        "SELECT 1",
                        connection);

                await command.ExecuteScalarAsync();

                return true;
            }
            catch (SqlException)
            {
                if (attempt == maxAttempts)
                    throw;

                await Task.Delay(700);
            }
        }

        return false;
    }

    private void SetProgress(
        string message,
        int progress)
    {
        if (IsDisposed || _closing)
            return;

        progress =
            Math.Clamp(progress, 0, 100);

        lblStatus.Text = message;

        int availableWidth =
            progressPanel.ClientSize.Width;

        progressBar.Width =
            (int)(
                availableWidth *
                (progress / 100.0));

        lblPercent.Text =
            @$"{progress}%";

        lblStatus.Refresh();
        progressBar.Refresh();
        lblPercent.Refresh();
    }

    private void OpenNext(Form form)
    {
        if (_closing)
        {
            form.Dispose();
            return;
        }

        form.FormClosed += (_, _) =>
        {
            if (!_closing)
                Application.Exit();
        };

        form.Show();
        Hide();
    }

    private void ShowError(
        string title,
        string message)
    {
        if (_closing)
            return;

        MessageBox.Show(
            message,
            @$"TechZone - {title}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        ExitApplication();
    }

    private void ShowException(
        string title,
        Exception ex)
    {
        if (_closing)
            return;

        MessageBox.Show(
            ex.ToString(),
            @$"TechZone - {title}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        ExitApplication();
    }

    private void ExitApplication()
    {
        _closing = true;
        Application.Exit();
    }
}