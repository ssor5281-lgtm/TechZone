using System.ComponentModel;
using static System.String;

namespace TechZone.UI.Components;

public partial class TzDropdownButton : UserControl
{
    private readonly ContextMenuStrip _dropdown = new();
    private string _selectedValue = Empty;

    public event EventHandler? ValueChanged;

    public TzDropdownButton()
    {
        InitializeComponent();

        ConfigureDropdown();

        Click += TzDropdownButton_Click;
        dropdownPanel.Click += TzDropdownButton_Click;
        valueLabel.Click += TzDropdownButton_Click;
        icon.Click += TzDropdownButton_Click;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Value
    {
        get => _selectedValue;
        private set
        {
            if (_selectedValue == value)
                return;

            _selectedValue = value;

            valueLabel.Text = _selectedValue.Length > 15
                ? _selectedValue[..15] + "..."
                : _selectedValue;

            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void SetValues(params string[] values)
    {
        _dropdown.Items.Clear();

        foreach (string value in values)
        {
            ToolStripItem item =
                _dropdown.Items.Add(value);

            item.Font = new Font(
                "Bahnschrift",
                10,
                FontStyle.Regular,
                GraphicsUnit.Point);

            item.BackColor = Color.White;
            item.ForeColor = Color.DimGray;

            item.Click += (_, _) =>
                Value = item.Text ?? Empty;
        }

        if (values.Length > 0)
            Value = values[0];
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void Reset()
    {
        if (_dropdown.Items.Count > 0)
            Value = _dropdown.Items[0].Text ?? Empty;
    }

    private void ConfigureDropdown()
    {
        _dropdown.BackColor = Color.White;
        _dropdown.ForeColor = Color.Black;

        _dropdown.AutoSize = true;
        _dropdown.ShowImageMargin = false;
        _dropdown.ShowCheckMargin = false;
        
    }

    private void TzDropdownButton_Click(
        object? sender,
        EventArgs e)
    {
        _dropdown.Show(
            this,
            new Point(0, Height));
    }
}