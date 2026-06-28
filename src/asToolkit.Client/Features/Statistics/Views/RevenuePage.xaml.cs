using asToolkit.Client.Features.Statistics.Models;
using asToolkit.Domain.Dtos.Statistic;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Shapes;
using Windows.Foundation;

namespace asToolkit.Client.Features.Statistics.Views;

public sealed partial class RevenuePage : Page
{
    // Most recently loaded series, kept so the chart can be redrawn on resize
    // without re-fetching from the server.
    private RevenueChartDto? _currentData;

    // Suppresses the DateChanged handler while we set the initial picker values.
    private bool _initializing;

    private CancellationTokenSource? _loadCts;

    // Screen coordinates of each plotted point, for pointer hit-testing.
    private readonly List<(double X, double Y, RevenueChartPointDto Point)> _plotPoints = new();

    // Vertical extent of the plot area, used to size the hover guide line.
    private double _plotTop;
    private double _plotBottom;

    // Hover overlay visuals, recreated on every redraw and toggled on pointer move.
    private Line? _hoverLine;
    private Ellipse? _hoverMarker;
    private Border? _hoverTooltip;
    private TextBlock? _hoverDateText;
    private TextBlock? _hoverValueText;

    public RevenuePage()
    {
        this.InitializeComponent();

        // Default range: the last 30 days (inclusive). Set here so the pickers
        // always hold a valid range regardless of when the DataContext arrives.
        _initializing = true;
        var today = DateTimeOffset.Now.Date;
        EndDatePicker.Date = today;
        StartDatePicker.Date = today.AddDays(-29);
        _initializing = false;

        this.Loaded += OnLoaded;
        this.Unloaded += OnUnloaded;
        // Navigation sets the DataContext (the RevenueModel) asynchronously, often
        // after Loaded — trigger the initial load as soon as the model is available.
        this.DataContextChanged += OnDataContextChanged;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await ReloadAsync();
    }

    private async void OnDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
        if (args.NewValue is RevenueModel)
        {
            await ReloadAsync();
        }
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        _loadCts?.Cancel();
        _loadCts?.Dispose();
        _loadCts = null;
    }

    private async void OnDateChanged(object? sender, DatePickerValueChangedEventArgs e)
    {
        if (_initializing)
        {
            return;
        }

        await ReloadAsync();
    }

    private void OnChartCanvasSizeChanged(object sender, SizeChangedEventArgs e)
    {
        DrawChart();
    }

    private async Task ReloadAsync()
    {
        if (DataContext is not RevenueModel model)
        {
            return;
        }

        var start = StartDatePicker.Date.Date;
        var end = EndDatePicker.Date.Date;

        // Tolerate a reversed range by swapping; the server does the same.
        if (end < start)
        {
            (start, end) = (end, start);
        }

        _loadCts?.Cancel();
        _loadCts?.Dispose();
        _loadCts = new CancellationTokenSource();
        var token = _loadCts.Token;

        ChartProgress.IsActive = true;
        NoDataText.Visibility = Visibility.Collapsed;

        try
        {
            var data = await model.LoadRevenueAsync(start, end, token);
            if (token.IsCancellationRequested)
            {
                return;
            }

            _currentData = data;
            TotalRevenueText.Text = data.TotalRevenue.ToString("C0");
            DrawChart();
        }
        catch (OperationCanceledException)
        {
            // Superseded by a newer request — ignore.
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                ChartProgress.IsActive = false;
            }
        }
    }

    private void DrawChart()
    {
        ChartCanvas.Children.Clear();
        _plotPoints.Clear();
        _hoverLine = null;
        _hoverMarker = null;
        _hoverTooltip = null;

        var width = ChartCanvas.ActualWidth;
        var height = ChartCanvas.ActualHeight;
        var points = _currentData?.Points;

        if (points == null || points.Count == 0 || width <= 0 || height <= 0)
        {
            NoDataText.Visibility = (points == null || points.Count == 0) && !ChartProgress.IsActive
                ? Visibility.Visible
                : Visibility.Collapsed;
            return;
        }

        NoDataText.Visibility = Visibility.Collapsed;

        var axisBrush = GetBrush("OutlineVariantBrush");
        var labelBrush = GetBrush("OnSurfaceVariantBrush");
        var lineBrush = GetBrush("PrimaryBrush");

        // Plot area: leave room for value labels (left) and date labels (bottom).
        const double leftPad = 64;
        const double rightPad = 16;
        const double topPad = 12;
        const double bottomPad = 28;

        var plotWidth = width - leftPad - rightPad;
        var plotHeight = height - topPad - bottomPad;
        if (plotWidth <= 0 || plotHeight <= 0)
        {
            return;
        }

        _plotTop = topPad;
        _plotBottom = topPad + plotHeight;

        var maxRevenue = (double)points.Max(p => p.Revenue);
        if (maxRevenue <= 0)
        {
            maxRevenue = 1; // avoid divide-by-zero; renders a flat baseline
        }

        // Horizontal grid lines + value labels (5 ticks: 0%..100%).
        const int gridLines = 4;
        for (var i = 0; i <= gridLines; i++)
        {
            var ratio = (double)i / gridLines;
            var y = topPad + plotHeight * (1 - ratio);

            ChartCanvas.Children.Add(new Line
            {
                X1 = leftPad,
                Y1 = y,
                X2 = leftPad + plotWidth,
                Y2 = y,
                Stroke = axisBrush,
                StrokeThickness = 1,
                Opacity = 0.6
            });

            var value = (decimal)(maxRevenue * ratio);
            var valueLabel = new TextBlock
            {
                Text = value.ToString("C0"),
                FontSize = 11,
                Foreground = labelBrush
            };
            Canvas.SetLeft(valueLabel, 4);
            Canvas.SetTop(valueLabel, y - 8);
            ChartCanvas.Children.Add(valueLabel);
        }

        // Build the polyline across all points.
        var stepX = points.Count > 1 ? plotWidth / (points.Count - 1) : 0;
        var polyline = new Polyline
        {
            Stroke = lineBrush,
            StrokeThickness = 2,
            StrokeLineJoin = PenLineJoin.Round
        };

        for (var i = 0; i < points.Count; i++)
        {
            var x = leftPad + (points.Count > 1 ? stepX * i : plotWidth / 2);
            var y = topPad + plotHeight * (1 - ((double)points[i].Revenue / maxRevenue));
            polyline.Points.Add(new Point(x, y));
            _plotPoints.Add((x, y, points[i]));
        }

        ChartCanvas.Children.Add(polyline);

        // Emphasise a single point (range of one day) with a dot.
        if (points.Count == 1)
        {
            var (x, y, _) = _plotPoints[0];
            var dot = new Ellipse
            {
                Width = 8,
                Height = 8,
                Fill = lineBrush
            };
            Canvas.SetLeft(dot, x - 4);
            Canvas.SetTop(dot, y - 4);
            ChartCanvas.Children.Add(dot);
        }

        // X-axis date labels: first, middle and last to avoid clutter.
        var labelIndexes = points.Count == 1
            ? new[] { 0 }
            : new[] { 0, points.Count / 2, points.Count - 1 };

        foreach (var idx in labelIndexes.Distinct())
        {
            var x = leftPad + (points.Count > 1 ? stepX * idx : plotWidth / 2);
            var dateLabel = new TextBlock
            {
                Text = points[idx].Date.ToString("dd.MM."),
                FontSize = 11,
                Foreground = labelBrush
            };
            Canvas.SetLeft(dateLabel, Math.Max(0, x - 16));
            Canvas.SetTop(dateLabel, topPad + plotHeight + 6);
            ChartCanvas.Children.Add(dateLabel);
        }

        BuildHoverOverlay(lineBrush);
    }

    /// <summary>
    /// Creates the (initially hidden) hover visuals — vertical guide line, point
    /// marker and tooltip — and adds them on top of the chart.
    /// </summary>
    private void BuildHoverOverlay(Brush lineBrush)
    {
        var surfaceBrush = GetBrush("SurfaceBrush");
        var outlineBrush = GetBrush("OutlineVariantBrush");
        var onSurfaceBrush = GetBrush("OnSurfaceBrush");
        var onSurfaceVariantBrush = GetBrush("OnSurfaceVariantBrush");

        _hoverLine = new Line
        {
            Stroke = lineBrush,
            StrokeThickness = 1,
            Opacity = 0.5,
            Visibility = Visibility.Collapsed,
            IsHitTestVisible = false
        };
        ChartCanvas.Children.Add(_hoverLine);

        _hoverMarker = new Ellipse
        {
            Width = 10,
            Height = 10,
            Fill = lineBrush,
            Stroke = surfaceBrush,
            StrokeThickness = 2,
            Visibility = Visibility.Collapsed,
            IsHitTestVisible = false
        };
        ChartCanvas.Children.Add(_hoverMarker);

        _hoverDateText = new TextBlock
        {
            FontSize = 11,
            Foreground = onSurfaceVariantBrush
        };
        _hoverValueText = new TextBlock
        {
            FontSize = 13,
            FontWeight = Microsoft.UI.Text.FontWeights.SemiBold,
            Foreground = onSurfaceBrush
        };

        _hoverTooltip = new Border
        {
            Background = surfaceBrush,
            BorderBrush = outlineBrush,
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(6),
            Padding = new Thickness(10, 6, 10, 6),
            Visibility = Visibility.Collapsed,
            IsHitTestVisible = false,
            Child = new StackPanel
            {
                Spacing = 2,
                Children = { _hoverDateText, _hoverValueText }
            }
        };
        ChartCanvas.Children.Add(_hoverTooltip);
    }

    private void OnChartPointerMoved(object sender, PointerRoutedEventArgs e)
    {
        if (_plotPoints.Count == 0 || _hoverTooltip == null || _hoverMarker == null || _hoverLine == null)
        {
            return;
        }

        var pos = e.GetCurrentPoint(ChartCanvas).Position;

        // Snap to the data point whose X is closest to the cursor.
        var nearest = _plotPoints[0];
        var bestDist = double.MaxValue;
        foreach (var p in _plotPoints)
        {
            var dist = Math.Abs(p.X - pos.X);
            if (dist < bestDist)
            {
                bestDist = dist;
                nearest = p;
            }
        }

        _hoverLine.X1 = nearest.X;
        _hoverLine.X2 = nearest.X;
        _hoverLine.Y1 = _plotTop;
        _hoverLine.Y2 = _plotBottom;
        _hoverLine.Visibility = Visibility.Visible;

        Canvas.SetLeft(_hoverMarker, nearest.X - _hoverMarker.Width / 2);
        Canvas.SetTop(_hoverMarker, nearest.Y - _hoverMarker.Height / 2);
        _hoverMarker.Visibility = Visibility.Visible;

        if (_hoverDateText != null)
        {
            _hoverDateText.Text = nearest.Point.Date.ToString("ddd, dd.MM.yyyy");
        }
        if (_hoverValueText != null)
        {
            _hoverValueText.Text = nearest.Point.Revenue.ToString("C2");
        }

        // Position the tooltip above the point, clamped to the canvas bounds.
        _hoverTooltip.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        var tw = _hoverTooltip.DesiredSize.Width;
        var th = _hoverTooltip.DesiredSize.Height;

        var tx = Math.Clamp(nearest.X - tw / 2, 0, Math.Max(0, ChartCanvas.ActualWidth - tw));
        var ty = nearest.Y - th - 12;
        if (ty < 0)
        {
            ty = nearest.Y + 12;
        }

        Canvas.SetLeft(_hoverTooltip, tx);
        Canvas.SetTop(_hoverTooltip, ty);
        _hoverTooltip.Visibility = Visibility.Visible;
    }

    private void OnChartPointerExited(object sender, PointerRoutedEventArgs e)
    {
        if (_hoverLine != null) _hoverLine.Visibility = Visibility.Collapsed;
        if (_hoverMarker != null) _hoverMarker.Visibility = Visibility.Collapsed;
        if (_hoverTooltip != null) _hoverTooltip.Visibility = Visibility.Collapsed;
    }

    private static Brush GetBrush(string key)
    {
        if (Application.Current.Resources.TryGetValue(key, out var value) && value is Brush brush)
        {
            return brush;
        }
        return new SolidColorBrush(Microsoft.UI.Colors.Gray);
    }
}
