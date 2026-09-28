namespace TechZone.UI.Components;

public class NoFocusButton : Button
{
    protected override bool ShowFocusCues => false;

    public override void NotifyDefault(bool value)
    {
        base.NotifyDefault(false);
    }
}