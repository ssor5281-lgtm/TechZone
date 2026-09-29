using System.Drawing;
using FluentTransitions;
using TechZone.UI.Controls;
using TechZone.UI.Theme;

namespace TechZone.UI.Effects;

public static class TzEffects
{
    private enum NavigationState
    {
        Normal,
        Active
    }

    private sealed class NavigationItem
    {
        public required Control Control { get; init; }
        public required string PropertyName { get; init; }
        public required object DefaultValue { get; init; }
        public required Func<object> ActiveValue { get; init; }
        public required bool Animate { get; init; }
        public required int Duration { get; init; }
        public required string Group { get; init; }

        public NavigationState State { get; set; } =
            NavigationState.Normal;
    }

    private static readonly Dictionary<Control, NavigationItem>
        NavigationItems = new();

    private static readonly Dictionary<string, Control>
        ActiveItems = new();

    public static void TzEffect(
        this Control control,
        string propertyName,
        object defaultValue,
        object hoverValue,
        object activeValue,
        bool animate = true,
        int duration = 200,
        string group = "default")
    {
        SetProperty(
            control,
            propertyName,
            defaultValue);

        var item = new NavigationItem
        {
            Control = control,
            PropertyName = propertyName,
            DefaultValue = defaultValue,
            ActiveValue =
                group == "navigation"
                    ? () => TzColors.PrimaryActive
                    : () => activeValue,
            Animate = animate,
            Duration = duration,
            Group = group
        };

        NavigationItems[control] = item;

        control.Click -= NavigationItemClicked;
        control.Click += NavigationItemClicked;
    }

    private static void NavigationItemClicked(
        object? sender,
        EventArgs e)
    {
        if (sender is not Control control)
            return;

        if (!NavigationItems.TryGetValue(
                control,
                out NavigationItem? item))
        {
            return;
        }

        SetActive(
            control,
            item.Group);
    }

    public static void SetActive(
        this Control control,
        string group = "default")
    {
        if (!NavigationItems.TryGetValue(
                control,
                out NavigationItem? item))
        {
            return;
        }

        if (ActiveItems.TryGetValue(
                group,
                out Control? previous)
            && previous != control)
        {
            if (NavigationItems.TryGetValue(
                    previous,
                    out NavigationItem? previousItem))
            {
                SetNavigationState(
                    previousItem,
                    NavigationState.Normal);
            }
        }

        ActiveItems[group] = control;

        SetNavigationState(
            item,
            NavigationState.Active);
    }

    public static void RefreshActiveTheme()
    {
        foreach (NavigationItem item in NavigationItems.Values)
        {
            if (item.State != NavigationState.Active)
                continue;

            SetProperty(
                item.Control,
                item.PropertyName,
                item.ActiveValue());

            SetNavigationColor(
                item.Control,
                TzColors.SidebarActiveText);
        }
    }

    private static void SetNavigationState(
        NavigationItem item,
        NavigationState state)
    {
        if (item.State == state)
            return;

        item.State = state;

        switch (state)
        {
            case NavigationState.Normal:
                AnimateBackground(
                    item.Control,
                    item.PropertyName,
                    item.DefaultValue,
                    item.Animate,
                    item.Duration);

                SetNavigationColor(
                    item.Control,
                    TzColors.SidebarText);

                break;

            case NavigationState.Active:
                AnimateBackground(
                    item.Control,
                    item.PropertyName,
                    item.ActiveValue(),
                    item.Animate,
                    item.Duration);

                SetNavigationColor(
                    item.Control,
                    TzColors.SidebarActiveText);

                break;
        }
    }

    private static void AnimateBackground(
        Control control,
        string propertyName,
        object value,
        bool animate,
        int duration)
    {
        if (!animate)
        {
            SetProperty(
                control,
                propertyName,
                value);

            return;
        }

        if (value is Color color)
        {
            Transition.With(
                    control,
                    propertyName,
                    color)
                .EaseInEaseOut(
                    TimeSpan.FromMilliseconds(duration));

            return;
        }

        SetProperty(
            control,
            propertyName,
            value);
    }

    private static void SetNavigationColor(
        Control control,
        Color color)
    {
        if (control is TzIcon icon)
            icon.IconColor = color;

        if (control is Label label)
            label.ForeColor = color;

        foreach (Control child in control.Controls)
            SetNavigationColor(
                child,
                color);
    }

    private static void SetProperty(
        Control control,
        string propertyName,
        object value)
    {
        var property =
            control.GetType()
                .GetProperty(propertyName);

        if (property == null ||
            !property.CanWrite)
        {
            return;
        }

        property.SetValue(
            control,
            value);
    }

    public static void TzEffect(
        this Control control,
        string propertyName,
        object defaultValue,
        object hoverValue,
        bool animate = true,
        int duration = 200)
    {
        SetProperty(
            control,
            propertyName,
            defaultValue);
    }
}