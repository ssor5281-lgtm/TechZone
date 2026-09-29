using TechZone.Core.Enums;
using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.Data.Services;

namespace TechZone.UI.Forms.Edit;

public partial class EditUserForm : Form
{
    private readonly UserRepository _userRepo = new();
    private readonly User _user;

    private readonly Font _passwordFont =
        new("Bahnschrift", 10F);

    private readonly Font _visiblePasswordFont =
        new("Bahnschrift", 10F);

    private string? _selectedImagePath;
    private string? _originalImagePath;
    private string? _copiedImagePath;
    private bool _removeImage;

    public EditUserForm(User user)
    {
        InitializeComponent();

        _user = user;

        Load += EditUserForm_Load;

        resetPasswordCheckBox.CheckedChanged +=
            ResetPasswordCheckBox_CheckedChanged;

        showPasswordCheckBox.CheckedChanged +=
            ShowPasswordCheckBox_CheckedChanged;

        chooseImageButton.Click +=
            ChooseImageButton_Click;

        removeImageButton.Click +=
            RemoveImageButton_Click;

        saveButton.Click +=
            SaveButton_Click;

        cancelButton.Click +=
            CancelButton_Click;

        ConfigurePasswordBoxes();

        ImageHelper.SetPlaceholder(
            profilePictureBox);

        UpdateImageControls(false);
    }

    private void EditUserForm_Load(
        object? sender,
        EventArgs e)
    {
        usernameTextBox.Text =
            _user.Username;

        roleComboBox.DataSource =
            Enum.GetValues<Role>();

        roleComboBox.SelectedItem =
            _user.Role;

        _originalImagePath =
            _user.ProfileImagePath;

        _selectedImagePath =
            _user.ProfileImagePath;

        _removeImage = false;

        LoadProfileImage();

        SetResetPasswordMode(false);
    }

    private void LoadProfileImage()
    {
        if (string.IsNullOrWhiteSpace(
                _user.ProfileImagePath))
        {
            ImageHelper.SetPlaceholder(
                profilePictureBox);

            UpdateImageControls(false);

            return;
        }

        string? fullPath =
            ImageHelper.GetFullPath(
                _user.ProfileImagePath);

        bool loaded =
            !string.IsNullOrWhiteSpace(fullPath) &&
            ImageHelper.TryLoadPreview(
                profilePictureBox,
                fullPath);

        UpdateImageControls(loaded);
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

            _removeImage = false;

            UpdateImageControls(true);
        }
        catch
        {
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
        _removeImage = true;

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

    private void ConfigurePasswordBoxes()
    {
        PasswordVisibility(false);

        showPasswordCheckBox.Checked = false;
        showPasswordCheckBox.Visible = false;
    }

    private void ResetPasswordCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        SetResetPasswordMode(
            resetPasswordCheckBox.Checked);
    }

    private void SetResetPasswordMode(
        bool enabled)
    {
        newPasswordLabel.Visible =
            enabled;

        newPasswordTextBox.Visible =
            enabled;

        confirmPasswordLabel.Visible =
            enabled;

        confirmPasswordTextBox.Visible =
            enabled;

        showPasswordCheckBox.Visible =
            enabled;

        if (!enabled)
        {
            newPasswordTextBox.Clear();
            confirmPasswordTextBox.Clear();

            showPasswordCheckBox.Checked = false;
        }

        ApplyPasswordVisibility();
    }

    private void ShowPasswordCheckBox_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        ApplyPasswordVisibility();
    }

    private void ApplyPasswordVisibility()
    {
        PasswordVisibility(
            showPasswordCheckBox.Checked);
    }

    private void PasswordVisibility(
        bool visible)
    {
        newPasswordTextBox.UseSystemPasswordChar =
            !visible;

        confirmPasswordTextBox.UseSystemPasswordChar =
            !visible;

        newPasswordTextBox.Font =
            visible
                ? _visiblePasswordFont
                : _passwordFont;

        confirmPasswordTextBox.Font =
            visible
                ? _visiblePasswordFont
                : _passwordFont;
    }

    private void SaveButton_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        string? oldImagePath =
            _user.ProfileImagePath;

        string? newImagePath =
            oldImagePath;

        bool imageChanged =
            !IsSameImage(
                _selectedImagePath,
                _originalImagePath);

        try
        {
            if (_removeImage)
            {
                newImagePath = null;
            }
            else if (
                imageChanged &&
                !string.IsNullOrWhiteSpace(
                    _selectedImagePath))
            {
                newImagePath =
                    SaveProfileImage(
                        _user.Id);

                if (string.IsNullOrWhiteSpace(
                        newImagePath))
                {
                    MessageBox.Show(
                        @"The profile image could not be saved.",
                        @"Profile Image",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            _user.Username =
                usernameTextBox.Text.Trim();

            _user.Role =
                (Role)roleComboBox.SelectedItem!;

            _user.ProfileImagePath =
                newImagePath;

            bool updated =
                _userRepo.Update(_user);

            if (!updated)
            {
                DeleteCopiedImage();

                MessageBox.Show(
                    @"Failed to update user.",
                    @"Edit User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (resetPasswordCheckBox.Checked)
            {
                string passwordHash =
                    PasswordHasher.Hash(
                        newPasswordTextBox.Text);

                bool passwordUpdated =
                    _userRepo.UpdatePassword(
                        _user.Id,
                        passwordHash);

                if (!passwordUpdated)
                {
                    MessageBox.Show(
                        @"User was updated, but the password could not be reset.",
                        @"Edit User",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            DeleteOldImage(
                oldImagePath,
                newImagePath);

            _copiedImagePath = null;
        }
        catch (Exception ex)
        {
            DeleteCopiedImage();

            MessageBox.Show(
                $@"Failed to update user.

{ex.Message}",
                @"Edit User",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        MessageBox.Show(
            resetPasswordCheckBox.Checked
                ? "User and password updated successfully."
                : "User updated successfully.",
            @"Edit User",
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

        if (string.IsNullOrWhiteSpace(
                savedPath))
        {
            return null;
        }

        _copiedImagePath =
            savedPath;

        return Path.Combine(
            "Asset",
            "Users",
            $"user_{userId}.jpg");
    }

    private void DeleteOldImage(
        string? oldImagePath,
        string? newImagePath)
    {
        if (string.IsNullOrWhiteSpace(
                oldImagePath))
        {
            return;
        }

        if (IsSameImage(
                oldImagePath,
                newImagePath))
        {
            return;
        }

        ImageHelper.DeleteImage(
            oldImagePath);
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

    private static bool IsSameImage(
        string? first,
        string? second)
    {
        string? firstPath =
            ImageHelper.GetFullPath(first);

        string? secondPath =
            ImageHelper.GetFullPath(second);

        if (string.IsNullOrWhiteSpace(firstPath) ||
            string.IsNullOrWhiteSpace(secondPath))
        {
            return string.Equals(
                first,
                second,
                StringComparison.OrdinalIgnoreCase);
        }

        return string.Equals(
            Path.GetFullPath(firstPath),
            Path.GetFullPath(secondPath),
            StringComparison.OrdinalIgnoreCase);
    }

    private bool ValidateInput()
    {
        string username =
            usernameTextBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(username))
        {
            MessageBox.Show(
                @"Please enter a username.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            usernameTextBox.Focus();

            return false;
        }

        if (username.Length < 3)
        {
            MessageBox.Show(
                @"Username must be at least 3 characters.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            usernameTextBox.Focus();

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

        if (!resetPasswordCheckBox.Checked)
            return true;

        string password =
            newPasswordTextBox.Text;

        string confirmPassword =
            confirmPasswordTextBox.Text;

        if (string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show(
                @"Please enter a new password.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            newPasswordTextBox.Focus();

            return false;
        }

        if (password.Length < 6)
        {
            MessageBox.Show(
                @"Password must be at least 6 characters.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            newPasswordTextBox.Focus();

            return false;
        }

        if (string.IsNullOrWhiteSpace(confirmPassword))
        {
            MessageBox.Show(
                @"Please confirm the new password.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            confirmPasswordTextBox.Focus();

            return false;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show(
                @"Passwords do not match.",
                @"Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            confirmPasswordTextBox.Focus();

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