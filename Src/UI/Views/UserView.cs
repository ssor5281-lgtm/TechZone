using TechZone.Core.Models;
using TechZone.Data.Repositories;
using TechZone.UI.Components;
using TechZone.UI.Forms.Create;
using TechZone.UI.Forms.Edit;

namespace TechZone.UI.Views;

public partial class UserView : UserControl
{
    private readonly UserRepository _userRepo = new();
    private readonly int _currentUserId;

    private List<User> _users = [];
    private List<User> _filteredUsers = [];

    public UserView(int currentUserId)
    {
        InitializeComponent();

        _currentUserId = currentUserId;

        ConfigureTable();
        ConfigurePagination();
        ConfigureToolbar();

        Load += UserView_Load;
    }

    private void UserView_Load(object? sender, EventArgs e)
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        _users = _userRepo.GetAll(includeInactive: true);
        _filteredUsers = _users.ToList();

        dataTablePagination1.TotalItems =
            _filteredUsers.Count;

        dataTablePagination1.GoToFirstPage();

        LoadCurrentPage();
    }

    private void ConfigureToolbar()
    {
        dataTableToolbar.SearchChanged +=
            DataTableToolbar_SearchChanged;

        dataTableToolbar.RefreshClicked +=
            DataTableToolbar_RefreshClicked;

        dataTableToolbar.AddClicked +=
            DataTableToolbar_AddClicked;

        dataTableToolbar.AddButtonIcon =
            Resources.icon_add_customer;

        dataTableToolbar.AddButtonWidth = 120;
        dataTableToolbar.AddButtonText = "New User";
    }

    private void DataTableToolbar_SearchChanged(
        object? sender,
        EventArgs e)
    {
        SearchUsers(dataTableToolbar.SearchText);
    }

    private void SearchUsers(string searchText)
    {
        searchText = searchText.Trim();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            _filteredUsers = _users.ToList();
        }
        else
        {
            _filteredUsers = _users
                .Where(user =>
                    user.Username.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    user.Role.ToString().Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    (user.IsActive ? "Active" : "Inactive")
                        .Contains(
                            searchText,
                            StringComparison.OrdinalIgnoreCase)
                    ||
                    user.CreatedAt
                        .ToString("yyyy-MM-dd")
                        .Contains(searchText))
                .ToList();
        }

        dataTablePagination1.TotalItems =
            _filteredUsers.Count;

        dataTablePagination1.GoToFirstPage();

        LoadCurrentPage();
    }

    private void DataTableToolbar_RefreshClicked(
        object? sender,
        EventArgs e)
    {
        LoadUsers();
    }

    private void DataTableToolbar_AddClicked(
        object? sender,
        EventArgs e)
    {
        using var form = new AddUserForm();

        if (form.ShowDialog(this) == DialogResult.OK)
            LoadUsers();
    }

    private void ConfigurePagination()
    {
        dataTablePagination1.PageSize = 10;

        dataTablePagination1.PageChanged +=
            DataTablePagination_PageChanged;
    }

    private void DataTablePagination_PageChanged(
        object? sender,
        DataTablePageChangedEventArgs e)
    {
        LoadCurrentPage();
    }

    private void LoadCurrentPage()
    {
        int skip =
            (dataTablePagination1.CurrentPage - 1)
            * dataTablePagination1.PageSize;

        dataTableUser.NumberStart = skip + 1;

        List<User> pageItems = _filteredUsers
            .Skip(skip)
            .Take(dataTablePagination1.PageSize)
            .ToList();

        dataTableUser.ClearDisabledActions();
        dataTableUser.DataSource = pageItems;

        for (int i = 0; i < pageItems.Count; i++)
        {
            if (pageItems[i].Id == _currentUserId)
                dataTableUser.SetActionDisabled(i);
        }
    }

    private void ConfigureTable()
    {
        dataTableUser.ClearColumns();

        dataTableUser.AddNumberColumn();
        dataTableUser.FontSize = 10F;

        dataTableUser.AddTextColumn(
            "Username",
            "Username",
            "Username");

        dataTableUser.AddTextColumn(
            "Role",
            "Role",
            "Role");

        dataTableUser.AddTextColumn(
            "Status",
            "Status",
            "Status");

        dataTableUser.AddTextColumn(
            "CreatedAt",
            "Created At",
            "CreatedAt");

        dataTableUser.AddActionColumn(
            showDelete: true,
            showEdit: true,
            showView: false);

        dataTableUser.EditClicked +=
            DataTableUser_EditClicked;

        dataTableUser.DeleteClicked +=
            DataTableUser_DeleteClicked;

        dataTableUser.SetFixedWidth("No", 70, 70);

        dataTableUser.SetFillColumn(
            "Username",
            180,
            int.MaxValue);

        dataTableUser.SetFixedWidth(
            "Role",
            110,
            110);

        dataTableUser.SetFixedWidth(
            "Status",
            120,
            120);

        dataTableUser.SetFixedWidth(
            "CreatedAt",
            180,
            180);

        dataTableUser.SetFixedWidth(
            "Action",
            150,
            150);

        dataTableUser.SetAlignment(
            "No",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableUser.SetHeaderAlignment(
            "No",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableUser.SetAlignment(
            "Username",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableUser.SetHeaderAlignment(
            "Username",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableUser.SetAlignment(
            "Role",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableUser.SetHeaderAlignment(
            "Role",
            DataGridViewContentAlignment.MiddleLeft);

        dataTableUser.SetAlignment(
            "Status",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableUser.SetHeaderAlignment(
            "Status",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableUser.SetAlignment(
            "CreatedAt",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableUser.SetHeaderAlignment(
            "CreatedAt",
            DataGridViewContentAlignment.MiddleCenter);

        dataTableUser.SetHeaderAlignment(
            "Action",
            DataGridViewContentAlignment.MiddleCenter);
    }

    private void DataTableUser_EditClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not User user)
            return;

        if (user.Id == _currentUserId)
        {
            MessageBox.Show(
                @"You cannot edit your own account.",
                @"Edit User",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!user.IsActive)
        {
            DialogResult result = MessageBox.Show(
                $@"The user ""{user.Username}"" is currently inactive.

Would you like to reactivate this account before editing it?",
                @"Inactive User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            bool reactivated =
                _userRepo.Reactivate(user.Id);

            if (!reactivated)
            {
                MessageBox.Show(
                    @"Failed to reactivate user.",
                    @"Reactivate User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            user.IsActive = true;
        }

        using var form = new EditUserForm(user);

        if (form.ShowDialog(this) == DialogResult.OK)
            LoadUsers();
    }

    private void DataTableUser_DeleteClicked(
        object? sender,
        DataTableActionEventArgs e)
    {
        if (e.DataItem is not User user)
            return;

        if (user.Id == _currentUserId)
        {
            MessageBox.Show(
                @"You cannot delete your own account.",
                @"Delete User",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!user.IsActive)
        {
            MessageBox.Show(
                @"This user is already inactive.",
                @"User Account",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        bool hasSales =
            _userRepo.HasSales(user.Id);

        if (hasSales)
        {
            DialogResult result = MessageBox.Show(
                $@"The user ""{user.Username}"" has existing sales records.

This account cannot be permanently deleted because those sales records must be preserved.

Would you like to deactivate this account instead?",
                @"Deactivate User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            bool deactivated =
                _userRepo.SoftDelete(user.Id);

            if (!deactivated)
            {
                MessageBox.Show(
                    @"Failed to deactivate user.",
                    @"Deactivate User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
        }
        else
        {
            DialogResult result = MessageBox.Show(
                $@"The user ""{user.Username}"" has no sales records.

Are you sure you want to permanently delete this account?",
                @"Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            bool deleted =
                _userRepo.Delete(user.Id);

            if (!deleted)
            {
                MessageBox.Show(
                    @"Failed to delete user.",
                    @"Delete User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
        }

        LoadUsers();
    }
}