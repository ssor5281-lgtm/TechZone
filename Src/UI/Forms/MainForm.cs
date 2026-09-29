using System.Reflection;
using TechZone.Core.Enums;
using TechZone.Core.Models;
using TechZone.Core.Settings;
using TechZone.Data.Services;
using TechZone.UI.Controls;
using TechZone.UI.Effects;
using TechZone.UI.Theme;
using TechZone.UI.Views;

namespace TechZone.UI.Forms;

public partial class MainForm : Form
{
    public User CurrentUser => _currentUser;

    private readonly User _currentUser;

    private const int ExpandedSidebarWidth = 240;
    private const int CompactSidebarWidth = 72;

    private const int ExpandedNavWidth = 216;
    private const int CompactNavWidth = 48;

    private readonly Dictionary<string, UserControl> _viewCache = new();

    public MainForm(User currentUser)
    {
        InitializeComponent();

        Icon = new Icon(
            Path.Combine(
                AppContext.BaseDirectory,
                "techzone.ico"));

        EnableSmoothRendering();

        _currentUser = currentUser;

        ApplyTheme();
        ConfigureNavigationIcons();
        PrepareNavigationIconColors();

        topbar.SetUser(_currentUser);

        ConfigureRoleAccess();

        ConfigureNavigationEffects();
        ConfigureNavigation();
        ApplySidebarStyle();

        LoadView(
            new PointOfSaleView(),
            navSale,
            "Point of Sale");
    }

    public void OpenSettings()
    {
        LoadView(
            new SettingView(),
            navSetting,
            "Setting");
    }

    private void EnableSmoothRendering()
    {
        SetDoubleBuffered(this);
        SetDoubleBuffered(sidebarPanel);
        SetDoubleBuffered(mainPanel);
        SetDoubleBuffered(contentPanel);
        SetDoubleBuffered(topbarPanel);
    }

    private static void SetDoubleBuffered(Control control)
    {
        typeof(Control)
            .GetProperty(
                "DoubleBuffered",
                BindingFlags.Instance |
                BindingFlags.NonPublic)
            ?.SetValue(
                control,
                true);
    }

    private void ConfigureNavigationIcons()
    {
        navDashboardIcon.SvgPath =
            GetSvgPath("icon_dashboard.svg");

        navProductIcon.SvgPath =
            GetSvgPath("icon_product.svg");

        navCategoryIcon.SvgPath =
            GetSvgPath("icon_category.svg");

        navInventoryIcon.SvgPath =
            GetSvgPath("icon_inventory.svg");

        navSaleIcon.SvgPath =
            GetSvgPath("icon_sale.svg");

        navCustomerIcon.SvgPath =
            GetSvgPath("icon_customer.svg");

        navUserIcon.SvgPath =
            GetSvgPath("icon_user.svg");

        navSettingIcon.SvgPath =
            GetSvgPath("icon_setting.svg");

        SetNavigationIconColor(
            TzColors.SidebarText);
    }

    private void PrepareNavigationIconColors()
    {
        var normal =
            TzColors.SidebarText;

        var active =
            TzColors.SidebarActiveText;

        navDashboardIcon.PrepareColors(
            normal,
            active);

        navProductIcon.PrepareColors(
            normal,
            active);

        navCategoryIcon.PrepareColors(
            normal,
            active);

        navInventoryIcon.PrepareColors(
            normal,
            active);

        navSaleIcon.PrepareColors(
            normal,
            active);

        navCustomerIcon.PrepareColors(
            normal,
            active);

        navUserIcon.PrepareColors(
            normal,
            active);

        navSettingIcon.PrepareColors(
            normal,
            active);
    }

    private static string GetSvgPath(
        string fileName)
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            "Src",
            "Resources",
            "SVG",
            fileName);
    }

    private void SetNavigationIconColor(
        Color color)
    {
        navDashboardIcon.IconColor = color;
        navProductIcon.IconColor = color;
        navCategoryIcon.IconColor = color;
        navInventoryIcon.IconColor = color;
        navSaleIcon.IconColor = color;
        navCustomerIcon.IconColor = color;
        navUserIcon.IconColor = color;
        navSettingIcon.IconColor = color;
    }

    public void ApplyTheme()
    {
        SuspendLayout();

        try
        {
            logoPictureBox.BackgroundImage =
                TzColors.SidebarLogo;

            logoLabel.ForeColor =
                TzColors.SidebarLogoText;

            ConfigureNavigationIcons();
            PrepareNavigationIconColors();

            BackColor =
                TzColors.Background;

            sidebarPanel.BackColor =
                TzColors.SidebarBackground;

            sidebarHomeLabel.ForeColor =
                TzColors.SidebarTextMuted;

            sidebarManagementLabel.ForeColor =
                TzColors.SidebarTextMuted;

            sidebarAdminLabel.ForeColor =
                TzColors.SidebarTextMuted;

            navDashboardLabel.ForeColor =
                TzColors.SidebarText;

            navProductLabel.ForeColor =
                TzColors.SidebarText;

            navCategoryLabel.ForeColor =
                TzColors.SidebarText;

            navInventoryLabel.ForeColor =
                TzColors.SidebarText;

            navSaleLabel.ForeColor =
                TzColors.SidebarText;

            navCustomerLabel.ForeColor =
                TzColors.SidebarText;

            navUserLabel.ForeColor =
                TzColors.SidebarText;

            navSettingLabel.ForeColor =
                TzColors.SidebarText;

            sidebarBorder.BackColor =
                TzColors.SidebarBorder;

            mainPanel.BackColor =
                TzColors.Background;

            contentPanel.BackColor =
                TzColors.Background;

            topbarPanel.BackColor =
                Color.White;

            topbar.BackColor =
                Color.White;

            topbarBorder.BackColor =
                TzColors.Border;
        }
        finally
        {
            ResumeLayout(true);
        }
    }

    public void ApplySidebarStyle()
    {
        bool compact =
            AppSettings.CompactSidebar;

        SuspendLayout();

        try
        {
            sidebarPanel.Width =
                compact
                    ? CompactSidebarWidth
                    : ExpandedSidebarWidth;

            sidebarBorder.Location =
                new Point(
                    sidebarPanel.Width -
                    sidebarBorder.Width,
                    0);

            sidebarBorder.Height =
                sidebarPanel.Height;

            logoPanel.Width =
                sidebarPanel.Width;

            if (compact)
            {
                logoPictureBox.Size =
                    new Size(40, 40);

                logoPictureBox.Location =
                    new Point(
                        (sidebarPanel.Width -
                         logoPictureBox.Width) / 2,
                        15);

                logoPictureBox.SizeMode =
                    PictureBoxSizeMode.Zoom;

                logoLabel.Visible =
                    false;
            }
            else
            {
                logoPictureBox.Location =
                    new Point(12, 15);

                logoPictureBox.Size =
                    new Size(40, 40);

                logoPictureBox.SizeMode =
                    PictureBoxSizeMode.Zoom;

                logoLabel.Visible =
                    true;
            }

            ApplyNavigationLayout(
                navDashboard,
                navDashboardIcon,
                navDashboardLabel);

            ApplyNavigationLayout(
                navProduct,
                navProductIcon,
                navProductLabel);

            ApplyNavigationLayout(
                navCategory,
                navCategoryIcon,
                navCategoryLabel);

            ApplyNavigationLayout(
                navInventory,
                navInventoryIcon,
                navInventoryLabel);

            ApplyNavigationLayout(
                navSale,
                navSaleIcon,
                navSaleLabel);

            ApplyNavigationLayout(
                navCustomer,
                navCustomerIcon,
                navCustomerLabel);

            ApplyNavigationLayout(
                navUser,
                navUserIcon,
                navUserLabel);

            ApplyNavigationLayout(
                navSetting,
                navSettingIcon,
                navSettingLabel);

            bool canSeeHome =
                _currentUser.Role == Role.Admin ||
                _currentUser.Role == Role.Manager;

            bool canSeeAdmin =
                _currentUser.Role == Role.Admin ||
                _currentUser.Role == Role.Manager;

            sidebarHomeLabel.Visible =
                !compact &&
                canSeeHome;

            sidebarManagementLabel.Visible =
                !compact;

            sidebarAdminLabel.Visible =
                !compact &&
                canSeeAdmin;

            UpdateNavigationGroups();
        }
        finally
        {
            ResumeLayout(true);
        }
    }

    private void ApplyNavigationLayout(
        Panel navItem,
        TzIcon icon,
        Control label)
    {
        bool compact =
            AppSettings.CompactSidebar;

        navItem.Width =
            compact
                ? CompactNavWidth
                : ExpandedNavWidth;

        navItem.Left =
            12;

        icon.Left =
            compact
                ? 12
                : 16;

        icon.Top =
            10;

        label.Visible =
            !compact;

        if (!compact)
        {
            label.Left =
                50;

            label.Top =
                0;

            label.Width =
                155;
        }
    }

    private void UpdateNavigationGroups()
    {
        bool compact =
            AppSettings.CompactSidebar;

        int left = 12;

        int width =
            compact
                ? CompactNavWidth
                : ExpandedNavWidth;

        navDashboard.Left =
            left;

        navProduct.Left =
            left;

        navCategory.Left =
            left;

        navInventory.Left =
            left;

        navSale.Left =
            left;

        navCustomer.Left =
            left;

        navUser.Left =
            left;

        navSetting.Left =
            left;

        navDashboard.Width =
            width;

        navProduct.Width =
            width;

        navCategory.Width =
            width;

        navInventory.Width =
            width;

        navSale.Width =
            width;

        navCustomer.Width =
            width;

        navUser.Width =
            width;

        navSetting.Width =
            width;
    }

    private void LoadView(
        UserControl view,
        Control navItem,
        string page,
        string? parent = null)
    {
        string key =
            GetViewKey(view);

        if (!_viewCache.TryGetValue(
                key,
                out UserControl? cachedView))
        {
            cachedView =
                view;

            cachedView.Dock =
                DockStyle.Fill;

            cachedView.Visible =
                false;

            _viewCache[key] =
                cachedView;

            contentPanel.Controls.Add(
                cachedView);
        }
        else
        {
            view.Dispose();
        }

        SwitchView(
            cachedView,
            navItem);

        if (parent == null)
        {
            SetTopbar(page);
        }
        else
        {
            SetTopbar(
                parent,
                page);
        }
    }

    private static string GetViewKey(
        Control view)
    {
        return view.GetType().FullName
            ?? view.GetType().Name;
    }

    private void SwitchView(
        UserControl view,
        Control navItem)
    {
        if (view.Visible &&
            view.Parent == contentPanel)
        {
            view.BringToFront();

            navItem.SetActive(
                "navigation");

            return;
        }

        contentPanel.SuspendLayout();

        try
        {
            view.Visible =
                true;

            view.BringToFront();

            navItem.SetActive(
                "navigation");
        }
        finally
        {
            contentPanel.ResumeLayout(
                true);
        }
    }

    public void SetTopbar(
        string page)
    {
        topbar.SetBreadcrumb(page);
    }

    public void SetTopbar(
        string parent,
        string page)
    {
        topbar.SetBreadcrumb(
            parent,
            page);
    }

    private void ShowPage(
        string name,
        Control navItem)
    {
        string key =
            $"__PAGE__{name}";

        if (!_viewCache.TryGetValue(
                key,
                out UserControl? page))
        {
            page =
                new UserControl
                {
                    Dock =
                        DockStyle.Fill,

                    BackColor =
                        TzColors.Background
                };

            var label =
                new Label
                {
                    Dock =
                        DockStyle.Fill,

                    Text =
                        name,

                    Font =
                        new Font(
                            "Bahnschrift",
                            24,
                            FontStyle.Bold),

                    ForeColor =
                        TzColors.TextPrimary,

                    BackColor =
                        TzColors.Background,

                    TextAlign =
                        ContentAlignment.MiddleCenter
                };

            page.Controls.Add(label);

            _viewCache[key] =
                page;

            contentPanel.Controls.Add(
                page);
        }

        SwitchView(
            page,
            navItem);

        SetTopbar(name);
    }

    private void ConfigureNavigation()
    {
        navDashboard.Click -= navDashboard_Click;
        navProduct.Click -= navProduct_Click;
        navCategory.Click -= navCategory_Click;
        navInventory.Click -= navInventory_Click;
        navSale.Click -= navSale_Click;
        navCustomer.Click -= navCustomer_Click;
        navUser.Click -= navUser_Click;
        navSetting.Click -= navSetting_Click;

        navDashboard.Click += navDashboard_Click;
        navProduct.Click += navProduct_Click;
        navCategory.Click += navCategory_Click;
        navInventory.Click += navInventory_Click;
        navSale.Click += navSale_Click;
        navCustomer.Click += navCustomer_Click;
        navUser.Click += navUser_Click;
        navSetting.Click += navSetting_Click;
    }

    private void navDashboard_Click(
        object? sender,
        EventArgs e)
    {
        if (!navDashboard.Visible)
            return;

        LoadView(
            new DashboardView(),
            navDashboard,
            "Dashboard");
    }

    private void navProduct_Click(
        object? sender,
        EventArgs e)
    {
        LoadView(
            new ProductView(),
            navProduct,
            "Table",
            "Products");
    }

    private void navCategory_Click(
        object? sender,
        EventArgs e)
    {
        LoadView(
            new CategoryView(),
            navCategory,
            "Category");
    }

    private void navInventory_Click(
        object? sender,
        EventArgs e)
    {
        LoadView(
            new InventoryView(),
            navInventory,
            "Inventory");
    }

    private void navSale_Click(
        object? sender,
        EventArgs e)
    {
        LoadView(
            new PointOfSaleView(),
            navSale,
            "Point of Sale");
    }

    private void navCustomer_Click(
        object? sender,
        EventArgs e)
    {
        LoadView(
            new CustomerView(),
            navCustomer,
            "Customer");
    }

    private void navUser_Click(
        object? sender,
        EventArgs e)
    {
        if (!navUser.Visible)
            return;

        LoadView(
            new UserView(
                currentUserId:
                AuthService.CurrentUser?.Id ??
                _currentUser.Id),
            navUser,
            "User");
    }

    private void navSetting_Click(
        object? sender,
        EventArgs e)
    {
        if (!navSetting.Visible)
            return;

        LoadView(
            new SettingView(),
            navSetting,
            "Setting");
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

        bool canAccessManagement =
            isAdmin ||
            isManager;

        navDashboard.Visible =
            !isStaff;

        navUser.Visible =
            canAccessManagement;

        navSetting.Visible =
            canAccessManagement;

        sidebarAdminLabel.Visible =
            canAccessManagement;

        sidebarManagementLabel.Text =
            isStaff
                ? "TECHZONE"
                : "MANAGEMENT";
    }

    private void ConfigureNavigationEffects()
    {
        ConfigureNavigationEffect(
            navDashboard);

        ConfigureNavigationEffect(
            navProduct);

        ConfigureNavigationEffect(
            navCategory);

        ConfigureNavigationEffect(
            navInventory);

        ConfigureNavigationEffect(
            navSale);

        ConfigureNavigationEffect(
            navCustomer);

        ConfigureNavigationEffect(
            navUser);

        ConfigureNavigationEffect(
            navSetting);
    }

    private void ConfigureNavigationEffect(
        Control navItem)
    {
        navItem.TzEffect(
            nameof(Control.BackColor),
            Color.Transparent,
            TzColors.PrimaryHover,
            TzColors.PrimaryActive,
            group: "navigation");
    }

    public void OpenOrderView()
    {
        if (_viewCache.TryGetValue(
                typeof(PointOfSaleView).FullName!,
                out UserControl? view)
            && view is PointOfSaleView posView)
        {
            SwitchView(
                posView,
                navSale);

            posView.OpenPage("Order");

            SetTopbar(
                "Point of Sale",
                "Order");
        }
    }

    public void OpenInvoiceHistoryView()
    {
        if (_viewCache.TryGetValue(
                typeof(PointOfSaleView).FullName!,
                out UserControl? view)
            && view is PointOfSaleView posView)
        {
            SwitchView(
                posView,
                navSale);

            posView.OpenPage("Invoice History");

            SetTopbar(
                "Point of Sale",
                "Invoice History");
        }
    }

    public void RefreshDashboard()
    {
        if (_viewCache.TryGetValue(
                typeof(DashboardView).FullName!,
                out UserControl? view)
            && view is DashboardView dashboard)
        {
            dashboard.RefreshData();
        }
    }
}