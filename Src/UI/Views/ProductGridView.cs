using TechZone.Core.Models;
using TechZone.UI.Components;

namespace TechZone.UI.Views;

public partial class ProductGridView : UserControl
{
    private List<Product> _products = [];
    private readonly List<ProductCard> _cards = [];   // reused cards

    private const int CardWidth = 265;
    private const int CardHeight = 410;

    private const int MinimumColumns = 4;
    private const int FiveColumnWidth = 1350;
    private const int SixColumnWidth = 1550;

    private const int PaddingTop = 0;
    private const int PaddingBottom = 0;

    private const int InitialRows = 2;
    private const int LoadMoreRows = 1;

    private int _visibleRows = InitialRows;

    public ProductGridView()
    {
        InitializeComponent();

        // Double buffering for smoother scrolling
        typeof(Control)
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?
            .SetValue(flowProducts, true);

        flowProducts.AutoScroll = true;
        flowProducts.HorizontalScroll.Enabled = false;
        flowProducts.HorizontalScroll.Visible = false;

        btnLoadMore.Click += BtnLoadMore_Click;
        bottomPanel.Resize += BottomPanel_Resize;

        CenterLoadMoreButton();
    }

    public List<Product> Products
    {
        get => _products;
        set
        {
            _products = value ?? [];
            _visibleRows = InitialRows;
            RefreshProducts();
        }
    }

    public void SetProducts(IEnumerable<Product> products)
    {
        _products = products?.ToList() ?? [];
        _visibleRows = InitialRows;
        RefreshProducts();
    }

    public void ClearProducts()
    {
        _products.Clear();
        _visibleRows = InitialRows;
        RefreshProducts();
    }

    private void BtnLoadMore_Click(
        object? sender,
        EventArgs e)
    {
        _visibleRows += LoadMoreRows;

        RefreshProducts();

        if (flowProducts.Controls.Count == 0)
            return;

        Control lastProduct =
            flowProducts.Controls[
                ^1];

        flowProducts.ScrollControlIntoView(
            lastProduct);
    }

    private void RefreshProducts()
    {
        flowProducts.SuspendLayout();

        try
        {
            int width = flowProducts.ClientSize.Width;
            if (width <= 0) return;

            int columns = GetColumnCount(width);
            int maxProducts = columns * _visibleRows;
            int neededCount = Math.Min(maxProducts, _products.Count);

            // ===== 1. Create more cards if needed =====
            while (_cards.Count < neededCount)
            {
                var card = new ProductCard
                {
                    Size = new Size(CardWidth, CardHeight),
                    Margin = new Padding(0)
                };
                _cards.Add(card);
            }

            // ===== 2. Update existing cards with data =====
            for (int i = 0; i < neededCount; i++)
            {
                _cards[i].Product = _products[i];
                _cards[i].Visible = true;
            }

            // ===== 3. Hide extra cards (don't dispose) =====
            for (int i = neededCount; i < _cards.Count; i++)
            {
                _cards[i].Visible = false;
            }

            // ===== 4. Sync controls in the FlowLayoutPanel =====
            // Remove all first
            flowProducts.Controls.Clear();

            // Add only the visible ones
            for (int i = 0; i < neededCount; i++)
            {
                flowProducts.Controls.Add(_cards[i]);
            }

            UpdateLayout();
            UpdateLoadMore(columns);
        }
        finally
        {
            flowProducts.ResumeLayout(true);
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        CenterLoadMoreButton();

        // Only update layout, don't recreate cards
        if (_products.Count > 0)
        {
            UpdateLayout();
            UpdateLoadMore(GetColumnCount(flowProducts.ClientSize.Width));
        }
    }

    private void UpdateLayout()
    {
        int width = flowProducts.ClientSize.Width;
        if (width <= 0) return;

        int columns = GetColumnCount(width);
        int gapCount = columns - 1;
        if (gapCount <= 0) return;

        flowProducts.Padding = new Padding(0, PaddingTop, 0, PaddingBottom);

        int usableWidth = width - SystemInformation.VerticalScrollBarWidth;
        int totalCardsWidth = columns * CardWidth;
        int remainingWidth = Math.Max(0, usableWidth - totalCardsWidth);

        int baseGap = remainingWidth / gapCount;
        int extraPixels = remainingWidth % gapCount;

        int index = 0;
        foreach (Control control in flowProducts.Controls)
        {
            if (control is ProductCard)
            {
                int colIndex = index % columns;
                bool isLastColumnInRow = (colIndex == gapCount);

                int currentGap = 0;
                if (!isLastColumnInRow)
                {
                    currentGap = baseGap + (colIndex < extraPixels ? 1 : 0);
                }

                control.Margin = new Padding(0, 0, currentGap, baseGap);
                index++;
            }
        }
    }

    private void UpdateLoadMore(int columns)
    {
        int visibleProducts = Math.Min(columns * _visibleRows, _products.Count);
        btnLoadMore.Enabled = visibleProducts < _products.Count;
    }

    private void BottomPanel_Resize(object? sender, EventArgs e)
    {
        CenterLoadMoreButton();
    }

    private void CenterLoadMoreButton()
    {
        btnLoadMore.Left = (bottomPanel.ClientSize.Width - btnLoadMore.Width) / 2;
        btnLoadMore.Top = (bottomPanel.ClientSize.Height - btnLoadMore.Height) / 2;
    }

    private int GetColumnCount(int width)
    {
        if (width >= SixColumnWidth) return 6;
        if (width >= FiveColumnWidth) return 5;
        return MinimumColumns;
    }
}