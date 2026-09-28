using TechZone.Core.Enums;
using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.Data.Services;
using TechZone.Utilities;

namespace TechZone.UI.Forms.Create;

public partial class AddUserForm : Form
{
    private readonly UserRepository _userRepo = new();

    private readonly Font _passwordFont =
        new("Bahnschrift", 10.2F);

    private readonly Font _visiblePasswordFont =
        new("Bahnschrift", 10.2F);

    private string? _selectedImagePath;
    private string? _copiedImagePath;

    public AddUserForm()
    {
        InitializeComponent();

        Load += AddUserForm_Load;

        addButton.Click +=
            AddButton_Click;

        cancelButton.Click +=
            CancelButton_Click;

        chooseImageButton.Click +=
            ChooseImageButton_Click;

        removeImageButton.Click +=
            RemoveImageButton_Click;

        showPasswordCheckBox.CheckedChanged +=
            ShowPasswordCheckBox_CheckedChanged;

        ConfigurePasswordBoxes();

        ImageHelper.SetPlaceholder(
            profilePictureBox);

        UpdateImageControls(false);
    }

    private void AddUserForm_Load(
        object? sender,
        EventArgs e)
    {
        LoadRoles();

        usernameTextBox.Focus();
    }

    private void LoadRoles()
    {
        roleComboBox.DataSource =
            Enum.GetValues<UserRole>();

        roleComboBox.SelectedIndex = -1;
    }

    private void ConfigurePasswordBoxes()
    {
        passwordTextBox.UseSystemPasswordChar = true;
        passwordTextBox.Font = _passwordFont;

        confirmPasswordTextBox.UseSystemPasswordChar = true;
        confirmPasswordTextBox.Font = _passwordFont;

        showPasswordCheckBox.Checked = false;
    }

    private void ChooseImageButton_Click(
        object? sender,
        EventArgs e)
    {
        string? imagePath =
            ImageHelper.SelectImage(
                this,
                "Select Profile Image");

        if (string.IsNullOrWhiteSpace(imagePath))
            return;

        try
        {
            ImageHelper.LoadPreview(
                profilePictureBox,
                imagePath);

            _selectedImagePath =
                imagePath;

            UpdateImageControls(true);
        }
        catch
        {
            _selectedImagePath = null;

            ImageHelper.SetPlaceholder(
                profilePictureBox);

            UpdateImageControls(false);

            MessageBox.Show(
                @"The selected image could not be loaded.",
                @"Profile Image",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void RemoveImageButton_Click(
        object? sender,
        EventArgs e)
    {
        _selectedImagePath = null;

        ImageHelper.SetPlaceholder(
            profilePictureBox);

        UpdateImageControls(false);
    }

    private void UpdateImageControls(
        bool hasImage)
    {
        chooseImageButton.Text =
            hasImage
                ? "Change Image"
                : "Choose Image";

        removeImageButton.Visible =
            hasImage;
    }

    private void ShowPasswordCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        bool visible =
            showPasswordCheckBox.Checked;

        passwordTextBox.UseSystemPasswordChar =
            !visible;

        confirmPasswordTextBox.UseSystemPasswordChar =
            !visible;

        passwordTextBox.Font =
            visible
                ? _visiblePasswordFont
                : _passwordFont;

        confirmPasswordTextBox.Font =
            visible
                ? _visiblePasswordFont
                : _passwordFont;
    }

    private void AddButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        string username =
            usernameTextBox.Text.Trim();

        string password =
            passwordTextBox.Text;

        UserRole role =
            (UserRole)roleComboBox.SelectedItem!;

        string passwordHash =
            PasswordHasher.Hash(password);

        var user = new User
        {
            Username = username,
            Role = role
        };

        try
        {
            _userRepo.Create(
                user,
                passwordHash);

            if (!string.IsNullOrWhiteSpace(
                    _selectedImagePath))
            {
                string? imagePath =
                    SaveProfileImage(
                        user.Id);

                if (string.IsNullOrWhiteSpace(
                        imagePath))
                {
                    MessageBox.Show(
                        @"User was created, but the profile image could not be saved.",
                        @"Add User",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    DialogResult =
                        DialogResult.OK;

                    Close();

                    return;
                }

                user.ProfileImagePath =
                    imagePath;

                if (!_userRepo.Update(user))
                {
                    DeleteCopiedImage();

                    MessageBox.Show(
                        @"User was created, but the profile image could not be saved.",
                        @"Add User",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }
        }
        catch (Exception ex)
        {
            DeleteCopiedImage();

            MessageBox.Show(
                $@"Failed to add user.

{ex.Message}",
                @"Add User",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            @"User added successfully.",
            @"Add User",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        DialogResult =
            DialogResult.OK;

        Close();
    }

    private string? SaveProfileImage(
        int userId)
    {
        string? savedPath =
            ImageHelper.SaveImage(
                _selectedImagePath,
                AppPaths.UserImages,
                $"user_{userId}");

        if (string.IsNullOrWhiteSpace(savedPath))
            return null;

        _copiedImagePath =
            savedPath;

        return Path.Combine(
            "Asset",
            "Users",
            $"user_{userId}.jpg");
    }

    private void DeleteCopiedImage()
    {
        if (string.IsNullOrWhiteSpace(
                _copiedImagePath))
        {
            return;
        }

        ImageHelper.DeleteImage(
            _copiedImagePath);

        _copiedImagePath = null;
    }

    private bool ValidateInput()
    {
        string username =
            usernameTextBox.Text.Trim();

        string password =
            passwordTextBox.Text;

        string confirmPassword =
            confirmPasswordTextBox.Text;

        string? validationError =
            RegisterValidator.Validate(
                username,
                password,
                confirmPassword);

        if (validationError != null)
        {
            MessageBox.Show(
                validationError,
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            if (string.IsNullOrWhiteSpace(username))
                usernameTextBox.Focus();
            else if (string.IsNullOrWhiteSpace(password))
                passwordTextBox.Focus();
            else if (password.Length < 6)
                passwordTextBox.Focus();
            else
                confirmPasswordTextBox.Focus();

            return false;
        }

        if (_userRepo.GetByUsername(username) != null)
        {
            MessageBox.Show(
                @"That username is already in use. Please choose another username.",
                @"Username Already Exists",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            usernameTextBox.Focus();
            usernameTextBox.SelectAll();

            return false;
        }

        if (roleComboBox.SelectedIndex < 0)
        {
            MessageBox.Show(
                @"Please select a role.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            roleComboBox.Focus();

            return false;
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

    protected override void OnFormClosed(
        FormClosedEventArgs e)
    {
        ImageHelper.DisposeImage(
            profilePictureBox);

        base.OnFormClosed(e);
    }
}