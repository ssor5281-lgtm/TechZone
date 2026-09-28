using System.ComponentModel;

namespace TechZone.UI.Components;

public partial class DataTable : UserControl
{
    public event EventHandler<DataTableActionEventArgs>? ViewClicked;
    public event EventHandler<DataTableActionEventArgs>? EditClicked;
    public event EventHandler<DataTableActionEventArgs>? DeleteClicked;
    public event EventHandler<DataTableCustomActionEventArgs>? CustomActionClicked;
    
    private readonly HashSet<int> _disabledActionRows = [];
    private readonly List<CustomActionButton> _customActions = [];
    private readonly ToolTip _actionToolTip = new();

    private int _numberStart = 1;
    public float fontSize = 9.5F;

    private bool _showView = true;
    private bool _showEdit = true;
    private bool _showDelete = true;

    private int _hoverRow = -1;
    private string? _hoverAction;

    private string _viewHint = "View";
    private string _editHint = "Edit";
    private string _deleteHint = "Delete";

    private Image? _viewIcon = TechZone.Resources.icon_view;
    private Image? _editIcon = TechZone.Resources.icon_edit;
    private Image? _deleteIcon = TechZone.Resources.icon_delete;

    public DataTable()
    {
        InitializeComponent();

        FontSize = fontSize;

        dataGridView.RowTemplate.Height = 44;
        dataGridView.ColumnHeadersHeight = 44;
        dataGridView.ShowCellToolTips = false;

        _actionToolTip.AutoPopDelay = 3000;
        _actionToolTip.InitialDelay = 0;
        _actionToolTip.ReshowDelay = 0;
        _actionToolTip.ShowAlways = true;
        _actionToolTip.UseAnimation = true;
        _actionToolTip.UseFading = true;

        dataGridView.Paint += DataGridView_Paint;
        dataGridView.RowsAdded += DataGridView_DataChanged;
        dataGridView.RowsRemoved += DataGridView_DataChanged;
        dataGridView.DataSourceChanged += DataGridView_DataSourceChanged;

        dataGridView.CellPainting += Action_CellPainting;
        dataGridView.CellMouseClick += Action_CellMouseClick;

        dataGridView.MouseMove += DataGridView_MouseMove;
        dataGridView.MouseLeave += DataGridView_MouseLeave;
    }

    [Browsable(true)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public float FontSize
    {
        get => fontSize;
        set
        {
            if (value <= 0)
                return;

            fontSize = value;

            using var font =
                new Font("Bahnschrift", value);

            dataGridView.DefaultCellStyle.Font = font;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = font;

            dataGridView.Invalidate();
        }
    }

    [Browsable(true)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public object? DataSource
    {
        get => dataGridView.DataSource;
        set
        {
            dataGridView.DataSource = value;
            dataGridView.Invalidate();
        }
    }

    [Browsable(false)]
    public DataGridView Table => dataGridView;

    [Browsable(false)]
    public DataGridViewColumnCollection Columns =>
        dataGridView.Columns;

    [Browsable(true)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public int NumberStart
    {
        get => _numberStart;
        set
        {
            _numberStart = Math.Max(1, value);
            dataGridView.Invalidate();
        }
    }

    public DataGridViewTextBoxColumn AddTextColumn(
        string name,
        string headerText,
        string dataPropertyName = "")
    {
        var column = new DataGridViewTextBoxColumn
        {
            Name = name,
            HeaderText = headerText,
            DataPropertyName = dataPropertyName,
            ReadOnly = true
        };

        dataGridView.Columns.Add(column);
        dataGridView.Invalidate();

        return column;
    }

    public void AddNumberColumn(
        string name = "No",
        string headerText = "No.")
    {
        if (dataGridView.Columns.Contains(name))
            return;

        var column = new DataGridViewTextBoxColumn
        {
            Name = name,
            HeaderText = headerText,
            ReadOnly = true
        };

        column.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

        dataGridView.Columns.Insert(0, column);

        dataGridView.CellFormatting -=
            NumberColumn_CellFormatting;

        dataGridView.CellFormatting +=
            NumberColumn_CellFormatting;

        dataGridView.Invalidate();
    }

    private void NumberColumn_CellFormatting(
        object? sender,
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 ||
            !dataGridView.Columns.Contains("No") ||
            e.ColumnIndex != dataGridView.Columns["No"]!.Index)
            return;

        e.Value =
            (_numberStart + e.RowIndex).ToString();

        e.FormattingApplied = true;
    }

    public void AddActionColumn(
        string name = "Action",
        string headerText = "Action",
        bool showView = true,
        bool showEdit = true,
        bool showDelete = true)
    {
        if (dataGridView.Columns.Contains(name))
            return;

        _showView = showView;
        _showEdit = showEdit;
        _showDelete = showDelete;

        int width =
            GetTotalActionWidth(GetActions());

        var column = new DataGridViewTextBoxColumn
        {
            Name = name,
            HeaderText = headerText,
            ReadOnly = true,
            Width = width,
            MinimumWidth = width,
            Resizable = DataGridViewTriState.False
        };

        column.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

        dataGridView.Columns.Add(column);
        dataGridView.Invalidate();
    }

    public void AddCustomActionButton(
        string name,
        string? text = null,
        string? hint = null,
        Image? image = null,
        int position = int.MaxValue,
        int width = 55,
        int height = 28,
        Color? backgroundColor = null,
        Color? hoverColor = null,
        Color? textColor = null,
        Color? borderColor = null,
        bool showBorder = false)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                @"Action name cannot be empty.",
                nameof(name));

        if (_customActions.Any(x =>
                string.Equals(
                    x.Name,
                    name,
                    StringComparison.OrdinalIgnoreCase)))
            return;

        var action = new CustomActionButton
        {
            Name = name,
            Text = text,
            Hint = hint,
            Image = image,
            Position = position < 1 ? 1 : position,
            Width = Math.Max(20, width),
            Height = Math.Max(20, height),
            BackgroundColor =
                backgroundColor ?? Color.RoyalBlue,
            HoverColor =
                hoverColor ?? Color.FromArgb(96, 165, 250),
            TextColor =
                textColor ?? Color.White,
            BorderColor =
                borderColor ?? Color.Transparent,
            ShowBorder = showBorder
        };

        _customActions.Add(action);

        NormalizeCustomActionPositions();
        UpdateActionColumn();

        dataGridView.Invalidate();
    }

    public void RemoveCustomActionButton(string name)
    {
        var action = FindCustomAction(name);

        if (action == null)
            return;

        _customActions.Remove(action);

        NormalizeCustomActionPositions();
        UpdateActionColumn();
        ResetActionHover();

        dataGridView.Invalidate();
    }

    public void ClearCustomActionButtons()
    {
        _customActions.Clear();

        UpdateActionColumn();
        ResetActionHover();

        dataGridView.Invalidate();
    }

    public void SetCustomActionImage(
        string name,
        Image? image)
    {
        var action = FindCustomAction(name);

        if (action == null)
            return;

        action.Image = image;
        dataGridView.Invalidate();
    }

    public void SetCustomActionText(
        string name,
        string? text)
    {
        var action = FindCustomAction(name);

        if (action == null)
            return;

        action.Text = text;
        dataGridView.Invalidate();
    }

    public void SetCustomActionHint(
        string name,
        string? hint)
    {
        var action = FindCustomAction(name);

        if (action == null)
            return;

        action.Hint = hint;

        if (string.Equals(
                _hoverAction,
                name,
                StringComparison.OrdinalIgnoreCase))
        {
            ShowCurrentTooltip();
        }

        dataGridView.Invalidate();
    }

    public void SetViewHint(string hint)
    {
        _viewHint = hint;

        if (string.Equals(
                _hoverAction,
                "View",
                StringComparison.OrdinalIgnoreCase))
        {
            ShowCurrentTooltip();
        }

        dataGridView.Invalidate();
    }

    public void SetEditHint(string hint)
    {
        _editHint = hint;

        if (string.Equals(
                _hoverAction,
                "Edit",
                StringComparison.OrdinalIgnoreCase))
        {
            ShowCurrentTooltip();
        }

        dataGridView.Invalidate();
    }

    public void SetDeleteHint(string hint)
    {
        _deleteHint = hint;

        if (string.Equals(
                _hoverAction,
                "Delete",
                StringComparison.OrdinalIgnoreCase))
        {
            ShowCurrentTooltip();
        }

        dataGridView.Invalidate();
    }

    public void SetViewIcon(Image image)
    {
        _viewIcon = image;
        dataGridView.Invalidate();
    }

    public void SetEditIcon(Image image)
    {
        _editIcon = image;
        dataGridView.Invalidate();
    }

    public void SetDeleteIcon(Image image)
    {
        _deleteIcon = image;
        dataGridView.Invalidate();
    }

    public void SetActionDisabled(
        int rowIndex,
        bool disabled = true)
    {
        if (rowIndex < 0 ||
            rowIndex >= dataGridView.Rows.Count)
            return;

        if (disabled)
            _disabledActionRows.Add(rowIndex);
        else
            _disabledActionRows.Remove(rowIndex);

        if (disabled &&
            _hoverRow == rowIndex)
        {
            ResetActionHover();
            dataGridView.Cursor = Cursors.No;
        }

        dataGridView.InvalidateRow(rowIndex);
    }

    public void ClearDisabledActions()
    {
        _disabledActionRows.Clear();
        dataGridView.Invalidate();
    }

    private int GetActionColumnIndex()
    {
        if (!dataGridView.Columns.Contains("Action"))
            return -1;

        return dataGridView.Columns["Action"]!.Index;
    }

    private void DataGridView_MouseMove(
        object? sender,
        MouseEventArgs e)
    {
        int actionColumnIndex =
            GetActionColumnIndex();

        if (actionColumnIndex < 0)
        {
            ResetActionHover();
            dataGridView.Cursor = Cursors.Default;
            return;
        }

        var hit =
            dataGridView.HitTest(e.X, e.Y);

        if (hit.RowIndex < 0 ||
            hit.ColumnIndex != actionColumnIndex)
        {
            ResetActionHover();
            dataGridView.Cursor = Cursors.Default;
            return;
        }

        if (_disabledActionRows.Contains(hit.RowIndex))
        {
            ResetActionHover();
            dataGridView.Cursor = Cursors.No;
            return;
        }

        Rectangle cellBounds =
            dataGridView.GetCellDisplayRectangle(
                actionColumnIndex,
                hit.RowIndex,
                false);

        if (cellBounds.Width <= 0 ||
            cellBounds.Height <= 0)
        {
            ResetActionHover();
            dataGridView.Cursor = Cursors.Default;
            return;
        }

        int relativeX =
            e.X - cellBounds.X;

        int relativeY =
            e.Y - cellBounds.Y;

        ActionItem? action =
            GetActionAtPosition(relativeX);

        if (action == null)
        {
            ResetActionHover();
            dataGridView.Cursor = Cursors.Default;
            return;
        }

        int actionX =
            GetActionStartX(
                action,
                cellBounds.Width);

        int actionY =
            (cellBounds.Height - action.Height) / 2;

        var actionRect =
            new Rectangle(
                actionX,
                actionY,
                action.Width,
                action.Height);

        if (!actionRect.Contains(
                relativeX,
                relativeY))
        {
            ResetActionHover();
            dataGridView.Cursor = Cursors.Default;
            return;
        }

        bool changed =
            _hoverRow != hit.RowIndex ||
            !string.Equals(
                _hoverAction,
                action.Name,
                StringComparison.OrdinalIgnoreCase);

        _hoverRow = hit.RowIndex;
        _hoverAction = action.Name;

        dataGridView.Cursor = Cursors.Hand;

        if (!changed)
            return;

        dataGridView.InvalidateRow(
            hit.RowIndex);

        ShowActionTooltip(
            hit.RowIndex,
            action,
            cellBounds);
    }

    private void DataGridView_MouseLeave(
        object? sender,
        EventArgs e)
    {
        ResetActionHover();
        dataGridView.Cursor = Cursors.Default;
    }

    private void ShowActionTooltip(
        int rowIndex,
        ActionItem action,
        Rectangle cellBounds)
    {
        string? hint =
            GetActionHint(action);

        if (string.IsNullOrWhiteSpace(hint))
            return;

        int actionX =
            GetActionStartX(
                action,
                cellBounds.Width);

        int tooltipX =
            cellBounds.X +
            actionX +
            action.Width / 2;

        int tooltipY =
            cellBounds.Y +
            cellBounds.Height +
            4;

        _actionToolTip.Show(
            hint,
            dataGridView,
            tooltipX,
            tooltipY,
            3000);
    }

    private void ShowCurrentTooltip()
    {
        if (_hoverRow < 0 ||
            string.IsNullOrWhiteSpace(_hoverAction))
            return;

        int actionColumnIndex =
            GetActionColumnIndex();

        if (actionColumnIndex < 0)
            return;

        ActionItem? action =
            GetAction(_hoverAction);

        if (action == null)
            return;

        Rectangle cellBounds =
            dataGridView.GetCellDisplayRectangle(
                actionColumnIndex,
                _hoverRow,
                false);

        if (cellBounds.Width <= 0 ||
            cellBounds.Height <= 0)
            return;

        ShowActionTooltip(
            _hoverRow,
            action,
            cellBounds);
    }

    private string? GetActionHint(
        ActionItem action)
    {
        return action.Type switch
        {
            ActionType.View =>
                string.IsNullOrWhiteSpace(_viewHint)
                    ? "View"
                    : _viewHint,

            ActionType.Edit =>
                string.IsNullOrWhiteSpace(_editHint)
                    ? "Edit"
                    : _editHint,

            ActionType.Delete =>
                string.IsNullOrWhiteSpace(_deleteHint)
                    ? "Delete"
                    : _deleteHint,

            ActionType.Custom =>
                string.IsNullOrWhiteSpace(
                    action.Custom?.Hint)
                    ? action.Custom?.Text ??
                      action.Custom?.Name
                    : action.Custom.Hint,

            _ => null
        };
    }

    private void Action_CellPainting(
        object? sender,
        DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 ||
            !dataGridView.Columns.Contains("Action") ||
            e.ColumnIndex !=
            dataGridView.Columns["Action"]!.Index)
            return;

        e.PaintBackground(
            e.ClipBounds,
            true);

        var actions = GetActions();

        if (actions.Count == 0)
        {
            e.Handled = true;
            return;
        }

        int totalWidth =
            GetTotalActionWidth(actions);

        int x =
            e.CellBounds.X +
            (e.CellBounds.Width - totalWidth) / 2;

        bool disabled =
            _disabledActionRows.Contains(
                e.RowIndex);

        foreach (var action in actions)
        {
            var rect =
                new Rectangle(
                    x,
                    e.CellBounds.Y +
                    (e.CellBounds.Height -
                     action.Height) / 2,
                    action.Width,
                    action.Height);

            bool hover =
                _hoverRow == e.RowIndex &&
                string.Equals(
                    _hoverAction,
                    action.Name,
                    StringComparison.OrdinalIgnoreCase);

            switch (action.Type)
            {
                case ActionType.View:
                    DrawButton(
                        e.Graphics!,
                        rect,
                        _viewIcon,
                        hover,
                        disabled,
                        Color.White,
                        Color.FromArgb(
                            248,
                            250,
                            252),
                        Color.FromArgb(
                            203,
                            213,
                            225));
                    break;

                case ActionType.Edit:
                    DrawButton(
                        e.Graphics!,
                        rect,
                        _editIcon,
                        hover,
                        disabled,
                        Color.FromArgb(
                            59,
                            130,
                            246),
                        Color.FromArgb(
                            96,
                            165,
                            250),
                        Color.Transparent);
                    break;

                case ActionType.Delete:
                    DrawButton(
                        e.Graphics!,
                        rect,
                        _deleteIcon,
                        hover,
                        disabled,
                        Color.FromArgb(
                            239,
                            68,
                            68),
                        Color.FromArgb(
                            248,
                            113,
                            113),
                        Color.Transparent);
                    break;

                case ActionType.Custom
                    when action.Custom != null:
                    DrawCustomButton(
                        e.Graphics!,
                        rect,
                        action.Custom,
                        hover,
                        disabled);
                    break;
            }

            x += action.Width + 6;
        }

        e.Handled = true;
    }

    private static void DrawButton(
        Graphics graphics,
        Rectangle rect,
        Image? icon,
        bool hover,
        bool disabled,
        Color normalBackground,
        Color hoverBackground,
        Color borderColor)
    {
        Color background =
            disabled
                ? Color.FromArgb(
                    243,
                    244,
                    246)
                : hover
                    ? hoverBackground
                    : normalBackground;

        using var brush =
            new SolidBrush(background);

        graphics.FillRectangle(
            brush,
            rect);

        if (borderColor != Color.Transparent)
        {
            using var pen =
                new Pen(
                    disabled
                        ? Color.FromArgb(
                            203,
                            213,
                            225)
                        : borderColor);

            graphics.DrawRectangle(
                pen,
                rect);
        }

        if (icon == null)
            return;

        const int iconSize = 16;

        var imageRect =
            new Rectangle(
                rect.X +
                (rect.Width - iconSize) / 2,
                rect.Y +
                (rect.Height - iconSize) / 2,
                iconSize,
                iconSize);

        graphics.DrawImage(
            icon,
            imageRect);
    }

    private static void DrawCustomButton(
        Graphics graphics,
        Rectangle rect,
        CustomActionButton action,
        bool hover,
        bool disabled)
    {
        Color background =
            disabled
                ? Color.FromArgb(
                    243,
                    244,
                    246)
                : hover
                    ? action.HoverColor
                    : action.BackgroundColor;

        using var brush =
            new SolidBrush(background);

        graphics.FillRectangle(
            brush,
            rect);

        if (action.ShowBorder)
        {
            using var pen =
                new Pen(
                    disabled
                        ? Color.FromArgb(
                            203,
                            213,
                            225)
                        : action.BorderColor);

            graphics.DrawRectangle(
                pen,
                rect);
        }

        if (action.Image == null)
            return;

        const int iconSize = 16;

        var imageRect =
            new Rectangle(
                rect.X +
                (rect.Width - iconSize) / 2,
                rect.Y +
                (rect.Height - iconSize) / 2,
                iconSize,
                iconSize);

        graphics.DrawImage(
            action.Image,
            imageRect);
    }

    private void Action_CellMouseClick(
        object? sender,
        DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex < 0 ||
            !dataGridView.Columns.Contains("Action") ||
            e.ColumnIndex !=
            dataGridView.Columns["Action"]!.Index ||
            _disabledActionRows.Contains(
                e.RowIndex))
            return;

        ActionItem? action =
            GetActionAtPosition(e.X);

        if (action == null)
            return;

        DataTableActionEventArgs args =
            GetActionArgs(e.RowIndex);

        switch (action.Type)
        {
            case ActionType.View:
                ViewClicked?.Invoke(this, args);
                break;

            case ActionType.Edit:
                EditClicked?.Invoke(this, args);
                break;

            case ActionType.Delete:
                DeleteClicked?.Invoke(this, args);
                break;

            case ActionType.Custom:
                if (action.Custom != null)
                {
                    CustomActionClicked?.Invoke(
                        this,
                        new DataTableCustomActionEventArgs(
                            e.RowIndex,
                            args.DataItem,
                            action.Custom.Name));
                }

                break;
        }
    }

    private ActionItem? GetActionAtPosition(
        int mouseX)
    {
        if (!dataGridView.Columns.Contains("Action"))
            return null;

        var actions = GetActions();

        if (actions.Count == 0)
            return null;

        int totalWidth =
            GetTotalActionWidth(actions);

        int startX =
            (dataGridView.Columns["Action"]!.Width -
             totalWidth) / 2;

        int x = mouseX - startX;

        if (x < 0)
            return null;

        int currentX = 0;

        foreach (var action in actions)
        {
            if (x >= currentX &&
                x < currentX + action.Width)
            {
                return action;
            }

            currentX += action.Width + 6;
        }

        return null;
    }

    private int GetActionStartX(
        ActionItem target,
        int cellWidth)
    {
        var actions = GetActions();

        int totalWidth =
            GetTotalActionWidth(actions);

        int startX =
            (cellWidth - totalWidth) / 2;

        int currentX = 0;

        foreach (var action in actions)
        {
            if (ReferenceEquals(action, target) ||
                string.Equals(
                    action.Name,
                    target.Name,
                    StringComparison.OrdinalIgnoreCase))
            {
                return startX + currentX;
            }

            currentX += action.Width + 6;
        }

        return startX;
    }

    private ActionItem? GetAction(
        string name)
    {
        return GetActions().FirstOrDefault(
            x => string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase));
    }

    private List<ActionItem> GetActions()
    {
        var actions = new List<ActionItem>();

        if (_showView)
        {
            actions.Add(
                ActionItem.BuiltIn(
                    "View",
                    ActionType.View,
                    55,
                    28));
        }

        if (_showEdit)
        {
            actions.Add(
                ActionItem.BuiltIn(
                    "Edit",
                    ActionType.Edit,
                    55,
                    28));
        }

        if (_showDelete)
        {
            actions.Add(
                ActionItem.BuiltIn(
                    "Delete",
                    ActionType.Delete,
                    55,
                    28));
        }

        foreach (var custom in
                 _customActions.OrderBy(
                     x => x.Position))
        {
            int index =
                Math.Clamp(
                    custom.Position - 1,
                    0,
                    actions.Count);

            actions.Insert(
                index,
                ActionItem.CustomAction(custom));
        }

        return actions;
    }

    private void NormalizeCustomActionPositions()
    {
        int max =
            GetBuiltInActionCount() +
            _customActions.Count;

        foreach (var action in _customActions)
        {
            action.Position =
                Math.Clamp(
                    action.Position,
                    1,
                    max);
        }
    }

    private int GetBuiltInActionCount() =>
        (_showView ? 1 : 0) +
        (_showEdit ? 1 : 0) +
        (_showDelete ? 1 : 0);

    private static int GetTotalActionWidth(
        List<ActionItem> actions)
    {
        if (actions.Count == 0)
            return 0;

        return actions.Sum(x => x.Width) +
               (actions.Count - 1) * 6;
    }

    private static int GetTotalActionWidth(
        int count)
    {
        if (count <= 0)
            return 0;

        return count * 55 +
               (count - 1) * 6;
    }

    private void UpdateActionColumn()
    {
        if (!dataGridView.Columns.Contains("Action"))
            return;

        int width =
            GetTotalActionWidth(GetActions());

        var column =
            dataGridView.Columns["Action"]!;

        column.Width = width;
        column.MinimumWidth = width;
    }

    private CustomActionButton? FindCustomAction(
        string name) =>
        _customActions.FirstOrDefault(
            x => string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase));

    private DataTableActionEventArgs GetActionArgs(
        int rowIndex) =>
        new(
            rowIndex,
            dataGridView.Rows[rowIndex].DataBoundItem);

    private void ResetActionHover()
    {
        int row = _hoverRow;

        _hoverRow = -1;
        _hoverAction = null;

        _actionToolTip.Hide(dataGridView);

        if (row >= 0 &&
            row < dataGridView.Rows.Count)
        {
            dataGridView.InvalidateRow(row);
        }
    }

    public void ClearColumns()
    {
        _disabledActionRows.Clear();
        _customActions.Clear();

        _showView = true;
        _showEdit = true;
        _showDelete = true;

        _hoverRow = -1;
        _hoverAction = null;

        _actionToolTip.Hide(dataGridView);

        dataGridView.CellFormatting -=
            NumberColumn_CellFormatting;

        dataGridView.Columns.Clear();
        dataGridView.Invalidate();
    }

    public void HideColumn(string columnName) =>
        SetColumnVisibility(columnName, false);

    public void SetColumnVisibility(
        string columnName,
        bool visible)
    {
        if (dataGridView.Columns.Contains(columnName))
        {
            dataGridView.Columns[columnName]!.Visible =
                visible;
        }
    }

    public void SetHeaderText(
        string columnName,
        string headerText)
    {
        if (dataGridView.Columns.Contains(columnName))
        {
            dataGridView.Columns[columnName]!.HeaderText =
                headerText;
        }
    }

    public void SetHeaderAlignment(
        string columnName,
        DataGridViewContentAlignment alignment)
    {
        if (dataGridView.Columns.Contains(columnName))
        {
            dataGridView.Columns[columnName]!
                .HeaderCell
                .Style
                .Alignment = alignment;
        }
    }

    public void SetAlignment(
        string columnName,
        DataGridViewContentAlignment alignment)
    {
        if (dataGridView.Columns.Contains(columnName))
        {
            dataGridView.Columns[columnName]!
                .DefaultCellStyle
                .Alignment = alignment;
        }
    }

    public void SetFixedWidth(
        string columnName,
        int minWidth,
        int maxWidth) =>
        SetColumnWidth(
            columnName,
            minWidth,
            maxWidth,
            DataGridViewAutoSizeColumnMode.None);

    public void SetFillColumn(
        string columnName,
        int minWidth,
        int maxWidth) =>
        SetColumnWidth(
            columnName,
            minWidth,
            maxWidth,
            DataGridViewAutoSizeColumnMode.Fill);

    private void SetColumnWidth(
        string columnName,
        int minWidth,
        int maxWidth,
        DataGridViewAutoSizeColumnMode mode)
    {
        if (!dataGridView.Columns.Contains(columnName))
            return;

        minWidth = Math.Max(0, minWidth);
        maxWidth = Math.Max(minWidth, maxWidth);

        var column =
            dataGridView.Columns[columnName]!;

        column.AutoSizeMode = mode;
        column.MinimumWidth = minWidth;
        column.Width = minWidth;
        column.Resizable =
            DataGridViewTriState.False;

        column.Tag =
            new ColumnWidthRange(
                minWidth,
                maxWidth);

        UpdateColumnWidths();
    }

    private void UpdateColumnWidths()
    {
        foreach (DataGridViewColumn column
                 in dataGridView.Columns)
        {
            if (column.Tag is not
                ColumnWidthRange range)
                continue;

            if (column.AutoSizeMode ==
                DataGridViewAutoSizeColumnMode.Fill)
            {
                if (column.Width > range.MaxWidth)
                {
                    column.AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.None;

                    column.Width = range.MaxWidth;
                }

                continue;
            }

            column.Width =
                Math.Clamp(
                    column.Width,
                    range.MinWidth,
                    range.MaxWidth);
        }
    }

    private void DataGridView_Paint(
        object? sender,
        PaintEventArgs e)
    {
        if (dataGridView.Rows.Count > 0 ||
            dataGridView.Columns.Count == 0)
            return;

        var bounds =
            dataGridView.ClientRectangle;

        int top =
            dataGridView.ColumnHeadersVisible
                ? dataGridView.ColumnHeadersHeight
                : 0;

        var emptyBounds =
            new Rectangle(
                bounds.Left,
                top,
                bounds.Width,
                Math.Max(
                    0,
                    bounds.Height - top));

        using var font =
            new Font("Bahnschrift", 20F);

        TextRenderer.DrawText(
            e.Graphics,
            "Empty",
            font,
            emptyBounds,
            Color.FromArgb(
                148,
                163,
                184),
            TextFormatFlags.HorizontalCenter |
            TextFormatFlags.VerticalCenter);
    }

    private void DataGridView_DataChanged(
        object? sender,
        EventArgs e) =>
        dataGridView.Invalidate();

    private void DataGridView_DataSourceChanged(
        object? sender,
        EventArgs e) =>
        dataGridView.Invalidate();

    private sealed class ColumnWidthRange(
        int minWidth,
        int maxWidth)
    {
        public int MinWidth { get; } = minWidth;
        public int MaxWidth { get; } = maxWidth;
    }

    private sealed class CustomActionButton
    {
        public string Name { get; init; } = "";
        public string? Text { get; set; }
        public string? Hint { get; set; }
        public Image? Image { get; set; }
        public int Position { get; set; }
        public int Width { get; init; }
        public int Height { get; init; }
        public Color BackgroundColor { get; set; }
        public Color HoverColor { get; set; }
        public Color TextColor { get; set; }
        public Color BorderColor { get; set; }
        public bool ShowBorder { get; init; }
    }

    private sealed class ActionItem
    {
        public string Name { get; }
        public ActionType Type { get; }
        public int Width { get; }
        public int Height { get; }
        public CustomActionButton? Custom { get; }

        private ActionItem(
            string name,
            ActionType type,
            int width,
            int height,
            CustomActionButton? custom = null)
        {
            Name = name;
            Type = type;
            Width = width;
            Height = height;
            Custom = custom;
        }

        public static ActionItem BuiltIn(
            string name,
            ActionType type,
            int width,
            int height) =>
            new(
                name,
                type,
                width,
                height);

        public static ActionItem CustomAction(
            CustomActionButton custom) =>
            new(
                custom.Name,
                ActionType.Custom,
                custom.Width,
                custom.Height,
                custom);
    }

    private enum ActionType
    {
        View,
        Edit,
        Delete,
        Custom
    }
}

public class DataTableActionEventArgs(
    int rowIndex,
    object? dataItem) : EventArgs
{
    public int RowIndex { get; } = rowIndex;
    public object? DataItem { get; } = dataItem;
}

public class DataTableCustomActionEventArgs(
    int rowIndex,
    object? dataItem,
    string actionName) : EventArgs
{
    public int RowIndex { get; } = rowIndex;
    public object? DataItem { get; } = dataItem;
    public string ActionName { get; } = actionName;
}