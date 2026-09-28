using TechZone.Core.Settings;
using TechZone.Data.Services;
using TechZone.Utilities;

namespace TechZone.UI.Forms;

public partial class LoginForm : Form
{
    private readonly AuthService _authService;

    private bool _passwordVisible;

    private readonly Font _passwordFont = new("Arial", 10.8F);
    private readonly Font _visiblePasswordFont = new("Bahnschrift", 10.8F);

    public LoginForm()
    {
        InitializeComponent();

        Icon = new Icon(
            Path.Combine(
                AppContext.BaseDirectory,
                "techzone.ico"));

        _authService = new AuthService();

        ConfigureButtons();
        ConfigurePasswordBox();
    }

    private void ConfigureButtons()
    {
        loginBtn.FlatStyle = FlatStyle.Flat;
        loginBtn.FlatAppearance.BorderSize = 0;
        loginBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
        loginBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        loginBtn.UseVisualStyleBackColor = false;

        passwordViewBtn.FlatStyle = FlatStyle.Flat;
        passwordViewBtn.FlatAppearance.BorderSize = 0;
        passwordViewBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
        passwordViewBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        passwordViewBtn.UseVisualStyleBackColor = false;
        passwordViewBtn.TabStop = false;
    }

    private void ConfigurePasswordBox()
    {
        passwordTextBox.UseSystemPasswordChar = true;
        passwordTextBox.Font = _passwordFont;
        passwordViewBtn.BackgroundImage = Resources.PasswordShow;
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        if (AppSettings.RememberUsername)
        {
            usernameTextBox.Text = AppSettings.RememberedUsername;
            usernameTextBox.SelectionStart = usernameTextBox.Text.Length;
        }

        usernameTextBox.Focus();
    }

    private void closeBtn_Click(object sender, EventArgs e)
        => Application.Exit();

    private void passwordViewBtn_Click(object sender, EventArgs e)
    {
        _passwordVisible = !_passwordVisible;

        passwordTextBox.UseSystemPasswordChar = !_passwordVisible;
        passwordTextBox.Font = _passwordVisible
            ? _visiblePasswordFont
            : _passwordFont;

        passwordViewBtn.BackgroundImage = _passwordVisible
            ? Resources.PasswordHide
            : Resources.PasswordShow;
    }

    private void loginBtn_Click(object sender, EventArgs e)
    {
        var username = usernameTextBox.Text.Trim();
        var password = passwordTextBox.Text;

        var validationError = LoginValidator.Validate(
            username,
            password
        );

        if (validationError != null)
        {
            MessageBox.Show(
                validationError,
                @"Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        try
        {
            var user = _authService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show(
                    @"Invalid username or password.",
                    @"Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (AppSettings.RememberUsername)
            {
                AppSettings.RememberedUsername = username;
            }
            else
            {
                AppSettings.RememberedUsername = string.Empty;
            }

            var mainForm = new MainForm(user);

            mainForm.FormClosed += (_, _) => Application.Exit();

            mainForm.Show();
            Hide();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                @"Login Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}