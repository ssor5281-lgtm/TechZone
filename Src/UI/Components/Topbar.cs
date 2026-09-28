using System.Drawing.Drawing2D;
using TechZone.Core.Helpers;
using TechZone.Core.Models;
using TechZone.Core.Settings;
using TechZone.UI.Forms;
using TechZone.UI.Forms.Edit;

namespace TechZone.UI.Components;

public partial class Topbar : UserControl
{
    
    private ToolStripDropDown? _profileDropdown;
    
    private User? GetCurrentUser()
    {
        return FindForm() is MainForm mainForm
            ? mainForm.CurrentUser
            : null;
    }

    public Topbar()
    {
        InitializeComponent();

        profilePictureBox.Cursor = Cursors.Hand;

        profilePictureBox.Click -= ProfilePictureBox_Click;
        profilePictureBox.Click += ProfilePictureBox_Click;
    }

    public void SetUser(User user)
    {
        string displayName =
            string.IsNullOrWhiteSpace(user.DisplayName)
                ? user.Username
                : user.DisplayName.Trim();

        displayNameLabel.Text = displayName;
        roleLabel.Text = user.Role.ToString();

        string? imagePath =
            ResolveProfileImagePath(user.ProfileImagePath);

        if (imagePath == null)
        {
            ShowDefaultProfile(displayName);
            return;
        }

        ShowProfileImage(
            imagePath,
            displayName);
    }

    private static string? ResolveProfileImagePath(
        string? profileImagePath)
    {
        if (string.IsNullOrWhiteSpace(profileImagePath))
            return null;

        string value = profileImagePath.Trim();

        if (Path.IsPathRooted(value))
            return File.Exists(value) ? value : null;

        string fileName = Path.GetFileName(value);

        if (string.IsNullOrWhiteSpace(fileName))
            return null;

        string fullPath =
            Path.Combine(
                AppPaths.UserImages,
                fileName);

        return File.Exists(fullPath)
            ? fullPath
            : null;
    }

    private void ShowDefaultProfile(string name)
    {
        int size =
            Math.Min(
                profilePictureBox.Width,
                profilePictureBox.Height);

        Bitmap bitmap = new(size, size);

        using Graphics graphics =
            Graphics.FromImage(bitmap);

        ConfigureGraphics(graphics);
        graphics.Clear(Color.Transparent);

        using GraphicsPath circle =
            CreateCirclePath(size);

        using Brush background =
            new SolidBrush(
                Color.FromArgb(
                    219,
                    234,
                    254));

        graphics.FillPath(
            background,
            circle);

        using Font font =
            new(
                "Bahnschrift SemiBold",
                12F,
                FontStyle.Bold);

        using Brush textBrush =
            new SolidBrush(
                Color.FromArgb(
                    37,
                    99,
                    235));

        using StringFormat format =
            new();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        graphics.DrawString(
            GetInitials(name),
            font,
            textBrush,
            new RectangleF(
                0,
                0,
                size,
                size),
            format);

        using Pen border =
            new(
                Color.FromArgb(
                    191,
                    219,
                    254),
                1F);

        graphics.DrawPath(
            border,
            circle);

        SetProfileBitmap(bitmap);
    }

    private void ShowProfileImage(
        string imagePath,
        string displayName)
    {
        try
        {
            using Image source =
                Image.FromFile(imagePath);

            int size =
                Math.Min(
                    profilePictureBox.Width,
                    profilePictureBox.Height);

            Bitmap bitmap =
                new(size, size);

            using Graphics graphics =
                Graphics.FromImage(bitmap);

            ConfigureGraphics(graphics);
            graphics.Clear(Color.Transparent);

            using GraphicsPath circle =
                CreateCirclePath(size);

            graphics.SetClip(
                circle,
                CombineMode.Replace);

            float scale =
                Math.Max(
                    (float)size / source.Width,
                    (float)size / source.Height);

            float imageWidth =
                source.Width * scale;

            float imageHeight =
                source.Height * scale;

            float x =
                (size - imageWidth) / 2F;

            float y =
                (size - imageHeight) / 2F;

            graphics.DrawImage(
                source,
                new RectangleF(
                    x,
                    y,
                    imageWidth,
                    imageHeight));

            graphics.ResetClip();

            using Pen border =
                new(
                    Color.FromArgb(
                        226,
                        232,
                        240),
                    1F);

            graphics.DrawPath(
                border,
                circle);

            SetProfileBitmap(bitmap);
        }
        catch
        {
            ShowDefaultProfile(displayName);
        }
    }

    private void SetProfileBitmap(Bitmap bitmap)
    {
        Image? oldImage =
            profilePictureBox.Image;

        profilePictureBox.Image =
            bitmap;

        profilePictureBox.BackColor =
            Color.Transparent;

        profilePictureBox.SizeMode =
            PictureBoxSizeMode.Normal;

        profilePictureBox.Region = null;

        oldImage?.Dispose();
    }

    private static void ConfigureGraphics(
        Graphics graphics)
    {
        graphics.SmoothingMode =
            SmoothingMode.AntiAlias;

        graphics.InterpolationMode =
            InterpolationMode.HighQualityBicubic;

        graphics.PixelOffsetMode =
            PixelOffsetMode.HighQuality;

        graphics.CompositingQuality =
            CompositingQuality.HighQuality;

        graphics.CompositingMode =
            CompositingMode.SourceOver;
    }

    private static GraphicsPath CreateCirclePath(
        int size)
    {
        GraphicsPath path = new();

        path.AddEllipse(
            1F,
            1F,
            size - 2F,
            size - 2F);

        return path;
    }

    private static string GetInitials(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "?";

        string[] parts =
            name.Trim()
                .Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 1)
        {
            string value = parts[0];

            return value.Length >= 2
                ? value[..2].ToUpperInvariant()
                : value.ToUpperInvariant();
        }

        return string.Concat(
                parts[0][0],
                parts[^1][0])
            .ToUpperInvariant();
    }

    private void ProfilePictureBox_Click(
        object? sender,
        EventArgs e)
    {
        if (_profileDropdown != null)
        {
            if (!_profileDropdown.IsDisposed)
                _profileDropdown.Close();

            _profileDropdown = null;
            return;
        }

        ShowProfileDropdown();
    }

    private void ShowProfileDropdown()
    {
        if (_profileDropdown is { IsDisposed: false })
        {
            return;
        }

        ToolStripDropDown dropdown =
            new()
            {
                AutoSize = false,
                Width = 262,
                Height = 222,
                Padding = new Padding(6),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(
                    30,
                    41,
                    59),
                DropShadowEnabled = true
            };

        _profileDropdown = dropdown;

        Panel container =
            new()
            {
                Width = 250,
                Height = 210,
                BackColor = Color.White
            };

        Label nameLabel =
            new()
            {
                AutoSize = false,
                Width = 226,
                Height = 24,
                Location = new Point(12, 10),
                Text = displayNameLabel.Text,
                Font =
                    new Font(
                        "Bahnschrift SemiBold",
                        11F,
                        FontStyle.Bold),
                ForeColor =
                    Color.FromArgb(
                        15,
                        23,
                        42),
                TextAlign =
                    ContentAlignment.MiddleLeft
            };

        Label dropdownRoleLabel =
            new()
            {
                AutoSize = false,
                Width = 226,
                Height = 20,
                Location = new Point(12, 34),
                Text = roleLabel.Text,
                Font =
                    new Font(
                        "Bahnschrift",
                        9F),
                ForeColor =
                    Color.FromArgb(
                        100,
                        116,
                        139),
                TextAlign =
                    ContentAlignment.MiddleLeft
            };

        Label divider =
            new()
            {
                Width = 226,
                Height = 1,
                Location = new Point(12, 62),
                BackColor =
                    Color.FromArgb(
                        226,
                        232,
                        240)
            };

        Panel profileButton =
            CreateDropdownButton(
                "Profile",
                72,
                Resources.icon_user_profile,
                ProfileButton_Click);

        Panel settingsButton =
            CreateDropdownButton(
                "Settings",
                112,
                Resources.icon_setting,
                SettingsButton_Click);

        Panel logoutButton =
            CreateDropdownButton(
                "Logout",
                152,
                Resources.icon_logout_red,
                LogoutButton_Click,
                Color.FromArgb(
                    209,
                    15,
                    15));
        

        container.Controls.Add(nameLabel);
        container.Controls.Add(dropdownRoleLabel);
        container.Controls.Add(divider);
        container.Controls.Add(profileButton);
        container.Controls.Add(settingsButton);
        container.Controls.Add(logoutButton);

        ToolStripControlHost host =
            new(container)
            {
                AutoSize = false,
                Width = 250,
                Height = 210,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

        dropdown.Items.Add(host);

        dropdown.Closed += (_, _) =>
        {
            if (ReferenceEquals(
                    _profileDropdown,
                    dropdown))
            {
                _profileDropdown = null;
            }
        };

        Point location =
            profilePictureBox.PointToScreen(
                new Point(
                    profilePictureBox.Width -
                    dropdown.Width,
                    profilePictureBox.Height + 8));

        dropdown.Show(location);
    }

    private void LogoutButton_Click(object? sender, EventArgs e)
    {
        _profileDropdown?.Close();

        if (FindForm() is not MainForm mainForm)
            return;

        var user = mainForm.CurrentUser;

        if (AppSettings.ConfirmLogout)
        {
            DialogResult result =
                MessageBox.Show(
                    @"Are you sure you want to logout?",
                    @"Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;
        }

        if (AppSettings.RememberUsername)
        {
            AppSettings.RememberedUsername =
                user.Username;
        }
        else
        {
            AppSettings.RememberedUsername =
                string.Empty;
        }

        var loginForm = new LoginForm();

        mainForm.Hide();

        loginForm.FormClosed += (_, _) =>
        {
            Application.Exit();
        };

        loginForm.Show();
    }

    private void SettingsButton_Click(object? sender, EventArgs e)
    {
        _profileDropdown?.Close();

        if (FindForm() is MainForm mainForm)
        {
            mainForm.OpenSettings();
        }
    }

    private void ProfileButton_Click(object? sender, EventArgs e)
    {
        _profileDropdown?.Close();

        var user = GetCurrentUser();

        if (user == null)
            return;

        if (FindForm() is not MainForm mainForm)
            return;

        using var profileForm = new UserProfile(user);

        if (profileForm.ShowDialog(mainForm) == DialogResult.OK)
        {
            SetUser(user);
        }
    }

    private Panel CreateDropdownButton(
        string text,
        int top,
        Image image,
        EventHandler click,
        Color? normalTextColor = null)
    {
        Color defaultTextColor =
            normalTextColor ??
            Color.FromArgb(
                51,
                65,
                85);

        Color hoverTextColor =
            normalTextColor.HasValue
                ? Color.FromArgb(
                    185,
                    28,
                    28)
                : Color.FromArgb(
                    37,
                    99,
                    235);

        Panel button =
            new()
            {
                Width = 226,
                Height = 40,
                Location = new Point(6, top),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

        PictureBox icon =
            new()
            {
                Width = 24,
                Height = 24,
                Location = new Point(10, 8),
                SizeMode =
                    PictureBoxSizeMode.Zoom,
                Image =
                    new Bitmap(
                        image,
                        new Size(24, 24)),
                BackColor =
                    Color.Transparent,
                Cursor =
                    Cursors.Hand
            };

        Label label =
            new()
            {
                AutoSize = false,
                Width = 175,
                Height = 40,
                Location = new Point(46, 0),
                Text = text,
                Font =
                    new Font(
                        "Bahnschrift",
                        10.5F,
                        FontStyle.Regular),
                ForeColor =
                    defaultTextColor,
                TextAlign =
                    ContentAlignment.MiddleLeft,
                BackColor =
                    Color.Transparent,
                Cursor =
                    Cursors.Hand
            };

        button.Controls.Add(icon);
        button.Controls.Add(label);

        void SetHover(bool hover)
        {
            button.BackColor =
                hover
                    ? normalTextColor.HasValue
                        ? Color.FromArgb(
                            254,
                            242,
                            242)
                        : Color.FromArgb(
                            239,
                            246,
                            255)
                    : Color.White;

            label.ForeColor =
                hover
                    ? hoverTextColor
                    : defaultTextColor;
        }

        button.MouseEnter +=
            (_, _) => SetHover(true);

        button.MouseLeave +=
            (_, _) => SetHover(false);

        icon.MouseEnter +=
            (_, _) => SetHover(true);

        icon.MouseLeave +=
            (_, _) => SetHover(false);

        label.MouseEnter +=
            (_, _) => SetHover(true);

        label.MouseLeave +=
            (_, _) => SetHover(false);

        button.Click += click;
        icon.Click += click;
        label.Click += click;

        return button;
    }

    public void SetBreadcrumb(
        string pageHeader)
    {
        parentHeader.Visible = false;
        separatorLabel.Visible = false;

        this.pageHeader.Text = pageHeader;
        this.pageHeader.Left = 24;
    }

    public void SetBreadcrumb(
        string parentHeader,
        string pageHeader)
    {
        this.parentHeader.Text = parentHeader;
        this.pageHeader.Text = pageHeader;

        this.parentHeader.Visible = true;
        separatorLabel.Visible = true;

        this.parentHeader.Left = 24;

        UpdateBreadcrumb();
    }

    private void UpdateBreadcrumb()
    {
        separatorLabel.Left =
            parentHeader.Right + 10;

        pageHeader.Left =
            separatorLabel.Right + 10;
    }
}