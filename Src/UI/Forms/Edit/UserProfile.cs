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
private string? _copiedImagePath;
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

    ImageHelper.SetPlaceholder(profilePictureBox);
    UpdateImageControls();
}

private void UserProfile_Load(object? sender, EventArgs e)
{
    displayNameTextBox.Text = _user.DisplayName ?? string.Empty;

    usernameLabel.Text = _user.Username;
    roleLabel.Text = _user.Role.ToString();
    statusLabel.Text = _user.IsActive ? "Active" : "Inactive";
    createdLabel.Text = _user.CreatedAt.ToString("MMM dd, yyyy");

    _originalImagePath = _user.ProfileImagePath;
    _selectedImagePath = _user.ProfileImagePath;
    _removeImage = false;

    LoadProfileImage();
    UpdateImageControls();
}

private void LoadProfileImage()
{
    if (string.IsNullOrWhiteSpace(_selectedImagePath))
    {
        ImageHelper.SetPlaceholder(profilePictureBox);
        return;
    }

    var fullPath = ImageHelper.GetFullPath(_selectedImagePath);

    if (!ImageHelper.TryLoadPreview(profilePictureBox, fullPath))
    {
        ImageHelper.SetPlaceholder(profilePictureBox);
        _selectedImagePath = null;
    }
}

private void ChooseImageButton_Click(object? sender, EventArgs e)
{
    var imagePath = ImageHelper.SelectImage(
        this,
        "Select Profile Image");

    if (string.IsNullOrWhiteSpace(imagePath))
        return;

    _copiedImagePath = imagePath;
    _selectedImagePath = imagePath;
    _removeImage = false;

    ImageHelper.LoadPreview(
        profilePictureBox,
        imagePath);

    UpdateImageControls();
}

private void RemoveImageButton_Click(object? sender, EventArgs e)
{
    _selectedImagePath = null;
    _removeImage = true;

    ImageHelper.SetPlaceholder(profilePictureBox);
    UpdateImageControls();
}

private void UpdateImageControls()
{
    removeImageButton.Visible =
        !string.IsNullOrWhiteSpace(_selectedImagePath);
}

private void SaveButton_Click(object? sender, EventArgs e)
{
    var displayName = displayNameTextBox.Text.Trim();

    string? newImagePath = _user.ProfileImagePath;

    if (_removeImage)
    {
        newImagePath = null;
    }
    else if (!string.IsNullOrWhiteSpace(_selectedImagePath) &&
             !IsSameImage(
                 _selectedImagePath,
                 _originalImagePath))
    {
        newImagePath = ImageHelper.SaveImage(
            _selectedImagePath,
            AppPaths.UserImages,
            $"user_{_user.Id}");

        if (string.IsNullOrWhiteSpace(newImagePath))
        {
            MessageBox.Show(
                this,
                "Unable to save the profile image.",
                "Save Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }
    }

    try
    {
        _userRepo.UpdateProfile(
            _user.Id,
            string.IsNullOrWhiteSpace(displayName)
                ? null
                : displayName,
            newImagePath);

        var oldImagePath = _user.ProfileImagePath;

        _user.DisplayName =
            string.IsNullOrWhiteSpace(displayName)
                ? null
                : displayName;

        _user.ProfileImagePath = newImagePath;

        if (!string.IsNullOrWhiteSpace(oldImagePath) &&
            !IsSameImage(oldImagePath, newImagePath))
        {
            ImageHelper.DeleteImage(oldImagePath);
        }

        _copiedImagePath = null;

        DialogResult = DialogResult.OK;
        Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(
            this,
            $"Unable to save your profile.\n\n{ex.Message}",
            "Save Failed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}

private void CancelButton_Click(object? sender, EventArgs e)
{
    DeleteCopiedImage();

    DialogResult = DialogResult.Cancel;
    Close();
}

private bool IsSameImage(
    string? first,
    string? second)
{
    if (string.IsNullOrWhiteSpace(first) &&
        string.IsNullOrWhiteSpace(second))
        return true;

    if (string.IsNullOrWhiteSpace(first) ||
        string.IsNullOrWhiteSpace(second))
        return false;

    return string.Equals(
        first.Trim(),
        second.Trim(),
        StringComparison.OrdinalIgnoreCase);
}

private void DeleteCopiedImage()
{
    if (string.IsNullOrWhiteSpace(_copiedImagePath))
        return;

    if (IsSameImage(
            _copiedImagePath,
            _originalImagePath))
        return;

    try
    {
        if (File.Exists(_copiedImagePath))
            File.Delete(_copiedImagePath);
    }
    catch
    {
    }

    _copiedImagePath = null;
}

protected override void OnFormClosed(FormClosedEventArgs e)
{
    profilePictureBox.Image?.Dispose();
    base.OnFormClosed(e);
}
}
