using System.Drawing.Drawing2D;

namespace SortingAnalysis;

/// <summary>Panel que dibuja un gráfico de líneas simple con dos series (sin dependencias externas).</summary>
public sealed class GraphPanel : Panel
{
    public List<double> Xs { get; } = new();
    public List<double> SeriesA { get; } = new();
    public List<double> SeriesB { get; } = new();
    public string Title { get; set; } = "";
    public string NameA { get; set; } = "Bubble Sort";
    public string NameB { get; set; } = "Merge Sort";
    public bool LogScale { get; set; }

    private static readonly Color ColorA = Color.FromArgb(214, 69, 65);
    private static readonly Color ColorB = Color.FromArgb(46, 134, 193);

    public GraphPanel()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BackColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(BackColor);

        using var titleFont = new Font(Font.FontFamily, 11f, FontStyle.Bold);
        g.DrawString(Title, titleFont, Brushes.Black, 10, 8);

        if (Xs.Count < 2)
        {
            g.DrawString("Ejecuta el análisis (mínimo 2 tamaños) para ver la gráfica.", Font, Brushes.Gray, 20, 50);
            return;
        }

        const int left = 90, right = 25, top = 45, bottom = 50;
        var plot = new Rectangle(left, top, Width - left - right, Height - top - bottom);
        if (plot.Width < 50 || plot.Height < 50) return;

        double Tr(double v) => LogScale ? Math.Log10(Math.Max(v, 1)) : v;
        double yMax = Math.Max(SeriesA.Select(Tr).Max(), SeriesB.Select(Tr).Max());
        if (yMax <= 0) yMax = 1;
        double xMin = Xs.Min(), xMax = Xs.Max();
        if (xMax == xMin) xMax = xMin + 1;

        float PX(double x) => plot.Left + (float)((x - xMin) / (xMax - xMin) * plot.Width);
        float PY(double v) => plot.Bottom - (float)(Tr(v) / yMax * plot.Height);

        using var gridPen = new Pen(Color.Gainsboro);
        using var axisPen = new Pen(Color.Black, 1.5f);
        for (int i = 0; i <= 5; i++)
        {
            float y = plot.Bottom - plot.Height * i / 5f;
            g.DrawLine(gridPen, plot.Left, y, plot.Right, y);
            double t = yMax * i / 5.0;
            double label = LogScale ? Math.Pow(10, t) : t;
            var s = Fmt(label);
            var sz = g.MeasureString(s, Font);
            g.DrawString(s, Font, Brushes.Black, plot.Left - sz.Width - 4, y - sz.Height / 2);
        }
        foreach (var x in Xs)
        {
            float px = PX(x);
            g.DrawLine(gridPen, px, plot.Top, px, plot.Bottom);
            var s = x.ToString("N0");
            var sz = g.MeasureString(s, Font);
            g.DrawString(s, Font, Brushes.Black, px - sz.Width / 2, plot.Bottom + 6);
        }
        g.DrawRectangle(axisPen, plot);
        g.DrawString("n (tamaño de la entrada)", Font, Brushes.Black, plot.Left + plot.Width / 2f - 70, plot.Bottom + 28);

        DrawSeries(g, SeriesA, ColorA, PX, PY);
        DrawSeries(g, SeriesB, ColorB, PX, PY);

        // Leyenda
        float lx = plot.Left + 12, ly = plot.Top + 8;
        using var ba = new SolidBrush(ColorA);
        using var bb = new SolidBrush(ColorB);
        g.FillRectangle(ba, lx, ly + 3, 14, 8);
        g.DrawString(NameA, Font, Brushes.Black, lx + 20, ly - 1);
        g.FillRectangle(bb, lx, ly + 23, 14, 8);
        g.DrawString(NameB, Font, Brushes.Black, lx + 20, ly + 19);
    }

    private void DrawSeries(Graphics g, List<double> ys, Color color, Func<double, float> px, Func<double, float> py)
    {
        var pts = new PointF[Xs.Count];
        for (int i = 0; i < Xs.Count; i++) pts[i] = new PointF(px(Xs[i]), py(ys[i]));
        using var pen = new Pen(color, 2.5f);
        using var brush = new SolidBrush(color);
        g.DrawLines(pen, pts);
        foreach (var p in pts) g.FillEllipse(brush, p.X - 4, p.Y - 4, 8, 8);
    }

    private static string Fmt(double v) => v >= 10000 ? v.ToString("0.0e+0") : v >= 100 ? v.ToString("0") : v.ToString("0.##");
}
