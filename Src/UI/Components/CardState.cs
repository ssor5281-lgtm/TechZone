using System.ComponentModel;

namespace TechZone.UI.Components;

public partial class CardState : UserControl
{
    public CardState()
    {
        InitializeComponent();
    }

    [Category("Card")]
    [Description("The title of the card.")]
    [DefaultValue("")]
    public string Title
    {
        get => nameState.Text;
        set => nameState.Text = value;
    }

    [Category("Card")]
    [Description("The value of the card.")]
    [DefaultValue("")]
    public string Value
    {
        get => stateValue.Text;
        set => stateValue.Text = value;
    }

    [Category("Appearance")]
    [Description("Color of the title.")]
    public Color TitleColor
    {
        get => nameState.ForeColor;
        set => nameState.ForeColor = value;
    }

    [Category("Appearance")]
    [Description("Color of the value.")]
    public Color ValueColor
    {
        get => stateValue.ForeColor;
        set => stateValue.ForeColor = value;
    }
}