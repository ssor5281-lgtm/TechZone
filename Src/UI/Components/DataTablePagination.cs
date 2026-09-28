using System.ComponentModel;

namespace TechZone.UI.Components;

public partial class DataTablePagination : UserControl
{
    public event EventHandler<DataTablePageChangedEventArgs>? PageChanged;

    private int _currentPage = 1;
    private int _pageSize = 10;
    private int _totalItems;

    public DataTablePagination()
    {
        InitializeComponent();
        ConfigureButtons();
        UpdatePagination();
    }

    [Browsable(false)]
    public int CurrentPage => _currentPage;

    [DefaultValue(10)]
    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (value <= 0 || value == _pageSize)
                return;

            _pageSize = value;
            _currentPage = 1;

            UpdatePagination();
            RaisePageChanged();
        }
    }

    [DefaultValue(0)]
    public int TotalItems
    {
        get => _totalItems;
        set
        {
            int total = Math.Max(0, value);

            if (_totalItems == total)
                return;

            _totalItems = total;
            _currentPage = Math.Clamp(_currentPage, 1, TotalPages);

            UpdatePagination();
        }
    }

    [Browsable(false)]
    private int TotalPages =>
        Math.Max(1, (int)Math.Ceiling(
            _totalItems / (double)_pageSize));

    public void GoToFirstPage()
    {
        if (_currentPage == 1)
            return;

        _currentPage = 1;

        UpdatePagination();
        RaisePageChanged();
    }

    public void GoToLastPage()
    {
        if (_currentPage == TotalPages)
            return;

        _currentPage = TotalPages;

        UpdatePagination();
        RaisePageChanged();
    }

    private void ConfigureButtons()
    {
        ConfigureButton(previousButton);
        ConfigureButton(nextButton);

        previousButton.MouseEnter += Button_MouseEnter;
        previousButton.MouseLeave += Button_MouseLeave;

        nextButton.MouseEnter += Button_MouseEnter;
        nextButton.MouseLeave += Button_MouseLeave;
    }

    private static void ConfigureButton(Button button)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.BorderColor =
            Color.FromArgb(226, 232, 240);

        button.BackColor = Color.White;
        button.ForeColor =
            Color.FromArgb(30, 41, 59);

        button.Font =
            new Font("Bahnschrift", 9F);

        button.Cursor = Cursors.Hand;
        button.TabStop = false;
        button.UseVisualStyleBackColor = false;
    }

    private static void Button_MouseEnter(
        object? sender,
        EventArgs e)
    {
        if (sender is not Button button)
            return;

        if (button.Tag is not true)
        {
            button.Cursor = Cursors.No;
            return;
        }

        button.BackColor =
            Color.FromArgb(235, 247, 255);

        button.FlatAppearance.BorderColor =
            Color.FromArgb(186, 230, 253);

        button.Cursor = Cursors.Hand;
    }

    private static void Button_MouseLeave(
        object? sender,
        EventArgs e)
    {
        if (sender is Button button)
            SetButtonState(button, button.Tag is true);
    }

    private void previousButton_Click(
        object? sender,
        EventArgs e)
    {
        if (_currentPage <= 1)
            return;

        _currentPage--;

        UpdatePagination();
        RaisePageChanged();
    }

    private void nextButton_Click(
        object? sender,
        EventArgs e)
    {
        if (_currentPage >= TotalPages)
            return;

        _currentPage++;

        UpdatePagination();
        RaisePageChanged();
    }

    private void UpdatePagination()
    {
        pageLabel.Text =
            $@"{_currentPage} of {TotalPages}";

        SetButtonState(
            previousButton,
            _currentPage > 1);

        SetButtonState(
            nextButton,
            _currentPage < TotalPages);
    }

    private static void SetButtonState(
        Button button,
        bool canClick)
    {
        button.Tag = canClick;

        button.BackColor = canClick
            ? Color.White
            : Color.FromArgb(241, 245, 249);

        button.ForeColor = canClick
            ? Color.FromArgb(30, 41, 59)
            : Color.FromArgb(148, 163, 184);

        button.FlatAppearance.BorderColor =
            Color.FromArgb(226, 232, 240);

        button.Cursor =
            canClick ? Cursors.Hand : Cursors.No;
    }

    private void RaisePageChanged()
    {
        PageChanged?.Invoke(
            this,
            new DataTablePageChangedEventArgs(
                _currentPage,
                _pageSize,
                _totalItems,
                TotalPages));
    }
}

public sealed class DataTablePageChangedEventArgs(
    int page,
    int pageSize,
    int totalItems,
    int totalPages)
    : EventArgs
{
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
    public int TotalItems { get; } = totalItems;
    public int TotalPages { get; } = totalPages;
}