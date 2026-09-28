using System.ComponentModel;
using TechZone.UI.Effects;

namespace TechZone.UI.Components;

public partial class DataTableToolbar : UserControl
{
    public DataTableToolbar()
    {
        InitializeComponent();
        SetupEffects();

        refreshButton.Click += (_, e) =>
            RefreshClicked?.Invoke(this, e);

        searchTextBox.TextChanged += (_, e) =>
            SearchChanged?.Invoke(this, e);

        addButton.Click += (_, e) =>
            AddClicked?.Invoke(this, e);
    }

    public event EventHandler? RefreshClicked;
    public event EventHandler? SearchChanged;
    public event EventHandler? AddClicked;

    [Browsable(false)]
    public string SearchText => searchTextBox.Text;

    public void ClearSearch() =>
        searchTextBox.Clear();

    [Category("Layout"), DefaultValue(0)]
    public int RefreshButtonX
    {
        get => refreshButton.Left;
        set => refreshButton.Left = value;
    }

    [Category("Layout"), DefaultValue(60)]
    public int SearchX
    {
        get => searchPanel.Left;
        set => searchPanel.Left = value;
    }

    [Category("Layout"), DefaultValue(375)]
    public int AddButtonX
    {
        get => addButton.Left;
        set => addButton.Left = value;
    }

    [Category("Layout"), DefaultValue(100)]
    public int AddButtonWidth
    {
        get => addButton.Width;
        set => addButton.Width = Math.Max(1, value);
    }

    [Category("Appearance"), DefaultValue("")]
    public string AddButtonText
    {
        get => addButton.Text;
        set => addButton.Text = value;
    }

    [Category("Appearance")]
    [DefaultValue(null)]
    public Image? AddButtonIcon
    {
        get => addButton.Image;
        set => addButton.Image = value;
    }

    [Category("Appearance")]
    [DefaultValue(ContentAlignment.MiddleCenter)]
    public ContentAlignment AddButtonIconAlign
    {
        get => addButton.ImageAlign;
        set => addButton.ImageAlign = value;
    }

    [Category("Appearance")]
    [DefaultValue(ContentAlignment.MiddleCenter)]
    public ContentAlignment AddButtonTextAlign
    {
        get => addButton.TextAlign;
        set => addButton.TextAlign = value;
    }

    [Category("Layout"), DefaultValue(true)]
    public bool ShowRefresh
    {
        get => refreshButton.Visible;
        set => refreshButton.Visible = value;
    }

    [Category("Layout"), DefaultValue(true)]
    public bool ShowSearch
    {
        get => searchPanel.Visible;
        set => searchPanel.Visible = value;
    }

    [Category("Layout"), DefaultValue(true)]
    public bool ShowAdd
    {
        get => addButton.Visible;
        set => addButton.Visible = value;
    }

    private void SetupEffects()
    {
        refreshButton.TzEffect(
            nameof(refreshButton.BackColor),
            Color.White,
            Color.FromArgb(235, 247, 255));

        searchPanel.TzEffect(
            nameof(searchPanel.BackColor),
            Color.White,
            Color.White);

        addButton.TzEffect(
            nameof(addButton.BackColor),
            Color.FromArgb(37, 99, 235),
            Color.FromArgb(59, 130, 246));
    }
}