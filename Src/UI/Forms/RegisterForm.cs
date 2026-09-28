using TechZone.Core.Enums;
using TechZone.Data.Repositories;
using TechZone.Data.Services;
using TechZone.Utilities;

namespace TechZone.UI.Forms;

public partial class RegisterForm : Form
{
    private readonly AuthService _authService;
    private readonly UserRepository _userRepo;

    private bool _passwordVisible;

    private readonly Font _passwordFont = new("Arial", 10.8F);
    private readonly Font _visiblePasswordFont = new("Bahnschrift", 10.8F);

    public RegisterForm()
    {
        InitializeComponent();
        
        Icon = new Icon(
            Path.Combine(
                AppContext.BaseDirectory,
                "techzone.ico"));

        _authService = new AuthService();
        _userRepo = new UserRepository();

        ConfigureButtons();
        ConfigurePasswordBox();

        passwordTextBox.Enter += passwordTextBox_Enter;
        comfirmPasswordTextBox.Enter += comfirmPasswordTextBox_Enter;
    }

    private void ConfigureButtons()
    {
        registerBtn.FlatStyle = FlatStyle.Flat;
        registerBtn.FlatAppearance.BorderSize = 0;
        registerBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
        registerBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        registerBtn.UseVisualStyleBackColor = false;

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

        comfirmPasswordTextBox.UseSystemPasswordChar = true;
        comfirmPasswordTextBox.Font = _passwordFont;

        passwordViewBtn.BackgroundImage = Resources.PasswordShow;
        passwordViewBtn.Location = new Point(750, 295);
    }

    private void RegisterForm_Load(object? sender, EventArgs e)
    {
        usernameTextBox.Focus();
    }

    private void closeBtn_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    private void passwordTextBox_Enter(object? sender, EventArgs e)
    {
        passwordViewBtn.Location = new Point(750, 295);
    }

    private void comfirmPasswordTextBox_Enter(object? sender, EventArgs e)
    {
        passwordViewBtn.Location = new Point(750, 381);
    }

    private void passwordViewBtn_Click(object? sender, EventArgs e)
    {
        _passwordVisible = !_passwordVisible;

        passwordTextBox.UseSystemPasswordChar = !_passwordVisible;
        comfirmPasswordTextBox.UseSystemPasswordChar = !_passwordVisible;

        passwordTextBox.Font = _passwordVisible
            ? _visiblePasswordFont
            : _passwordFont;

        comfirmPasswordTextBox.Font = _passwordVisible
            ? _visiblePasswordFont
            : _passwordFont;

        passwordViewBtn.BackgroundImage = _passwordVisible
            ? Resources.PasswordHide
            : Resources.PasswordShow;
    }

    private void registerBtn_Click(object? sender, EventArgs e)
    {
        var username = usernameTextBox.Text.Trim();
        var password = passwordTextBox.Text;
        var confirmPassword = comfirmPasswordTextBox.Text;

        var validationError = RegisterValidator.Validate(
            username,
            password,
            confirmPassword
        );

        if (validationError != null)
        {
            MessageBox.Show(
                validationError,
                @"Registration Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        try
        {
            _authService.Register(
                username,
                password,
                UserRole.Admin
            );

            var user = _userRepo.GetByUsername(username);

            if (user == null)
            {
                throw new Exception(
                    "User was registered, but the account could not be loaded.");
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
                @"Registration Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }
}