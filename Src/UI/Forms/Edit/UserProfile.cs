using TechZone.Core;
using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Data.Repositories;

namespace TechZone.UI.Forms.Edit;

public partial class UserProfile : Form
{
    private readonly UserRepository _userRepo = new();
    private readonly User _user;

    private string? _selectedImagePath;
    private string? _originalImagePath;
    private string? _savedImagePath;
    private bool _removeImage;

    public UserProfile(User user)
    {
        InitializeComponent();

        _user = user;

        Load += UserProfile_Load;
        chooseImageButton.Click += ChooseImageButton_Click;
        removeImageButton.Click += RemoveImageButton_Click;
        saveButton.Click += SaveButton_Click;
        cancelButton.Click += CancelButton_Click;

        ImageHelper.SetPlaceholder(
            profilePictureBox);

        UpdateImageControls();
    }

    private void UserProfile_Load(
        object? sender,
        EventArgs e)
    {
        displayNameTextBox.Text =
            _user.DisplayName ?? string.Empty;

        usernameLabel.Text =
            _user.Username;

        roleLabel.Text =
            _user.Role.ToString();

        statusLabel.Text =
            _user.GetUserStatus();

        createdLabel.Text =
            _user.CreatedAt.ToString(
                "MMM dd, yyyy");

        _originalImagePath =
            _user.ProfileImagePath;

        _selectedImagePath =
            _user.ProfileImagePath;

        _removeImage = false;

        LoadProfileImage();
        UpdateImageControls();
    }

    private void LoadProfileImage()
    {
        if (string.IsNullOrWhiteSpace(
                _selectedImagePath))
        {
            ImageHelper.SetPlaceholder(
                profilePictureBox);

            return;
        }

        if (!ImageHelper.TryLoadPreview(
                profilePictureBox,
                _selectedImagePath))
        {
            ImageHelper.SetPlaceholder(
                profilePictureBox);
        }
    }

    private void ChooseImageButton_Click(
        object? sender,
        EventArgs e)
    {
        var imagePath =
            ImageHelper.SelectImage(
                this,
                "Select Profile Image");

        if (string.IsNullOrWhiteSpace(
                imagePath))
        {
            return;
        }

        _selectedImagePath =
            imagePath;

        _removeImage = false;

        ImageHelper.LoadPreview(
            profilePictureBox,
            imagePath);

        UpdateImageControls();
    }

    private void RemoveImageButton_Click(
        object? sender,
        EventArgs e)
    {
        _selectedImagePath = null;
        _removeImage = true;

        ImageHelper.SetPlaceholder(
            profilePictureBox);

        UpdateImageControls();
    }

    private void UpdateImageControls()
    {
        removeImageButton.Visible =
            !string.IsNullOrWhiteSpace(
                _selectedImagePath);
    }

    private void SaveButton_Click(
        object? sender,
        EventArgs e)
    {
        var displayName =
            displayNameTextBox.Text.Trim();

        string? newImagePath =
            _user.ProfileImagePath;

        string? oldImagePath =
            _user.ProfileImagePath;

        _savedImagePath = null;

        if (_removeImage)
        {
            newImagePath = null;
        }
        else if (!string.IsNullOrWhiteSpace(
                     _selectedImagePath) &&
                 !IsSameImage(
                     _selectedImagePath,
                     _originalImagePath))
        {
            string? savedPath =
                ImageHelper.SaveImage(
                    _selectedImagePath,
                    AppPaths.UserImages,
                    $"user_{_user.Id}");

            if (string.IsNullOrWhiteSpace(
                    savedPath))
            {
                MessageBox.Show(
                    this,
                    @"Unable to save the profile image.",
                    @"Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _savedImagePath =
                savedPath;

            newImagePath =
                Path.Combine(
                    "Users",
                    $"user_{_user.Id}.jpg");
        }

        try
        {
            _userRepo.UpdateProfile(
                _user.Id,
                string.IsNullOrWhiteSpace(
                    displayName)
                    ? null
                    : displayName,
                newImagePath);

            _user.DisplayName =
                string.IsNullOrWhiteSpace(
                    displayName)
                    ? null
                    : displayName;

            _user.ProfileImagePath =
                newImagePath;

            if (!string.IsNullOrWhiteSpace(
                    oldImagePath) &&
                !IsSameImage(
                    oldImagePath,
                    newImagePath))
            {
                ImageHelper.DeleteImage(
                    oldImagePath);
            }

            _savedImagePath = null;

            DialogResult =
                DialogResult.OK;

            Close();
        }
        catch (Exception ex)
        {
            if (!string.IsNullOrWhiteSpace(
                    _savedImagePath))
            {
                try
                {
                    File.Delete(
                        _savedImagePath);
                }
                catch
                {
                    //
                }
            }

            MessageBox.Show(
                this,
                @$"Unable to save your profile.\n\n{ex.Message}",
                @"Save Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.Cancel;

        Close();
    }

    private bool IsSameImage(
        string? first,
        string? second)
    {
        if (string.IsNullOrWhiteSpace(first) &&
            string.IsNullOrWhiteSpace(second))
        {
            return true;
        }

        if (string.IsNullOrWhiteSpace(first) ||
            string.IsNullOrWhiteSpace(second))
        {
            return false;
        }

        string? firstPath =
            ImageHelper.GetFullPath(first);

        string? secondPath =
            ImageHelper.GetFullPath(second);

        if (string.IsNullOrWhiteSpace(firstPath) ||
            string.IsNullOrWhiteSpace(secondPath))
        {
            return string.Equals(
                first.Trim(),
                second.Trim(),
                StringComparison.OrdinalIgnoreCase);
        }

        return string.Equals(
            Path.GetFullPath(firstPath),
            Path.GetFullPath(secondPath),
            StringComparison.OrdinalIgnoreCase);
    }

    protected override void OnFormClosed(
        FormClosedEventArgs e)
    {
        ImageHelper.DisposeImage(
            profilePictureBox);

        base.OnFormClosed(e);
    }
}