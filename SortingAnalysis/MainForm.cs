namespace SortingAnalysis;

public partial class MainForm : Form
{
    private const int MaxN = 30000; // Bubble Sort es O(n²): limitamos para no congelar la demo
    private readonly List<BenchmarkRow> _rows = new();

    public MainForm()
    {
        InitializeComponent();
        cmbMetrica.SelectedIndex = 0;
        txtAnalisis.Text = AnalysisText.BuildTheory();
        txtAnalisis.Select(0, 0);
        RefreshChart();
    }

    private async void btnEjecutar_Click(object? sender, EventArgs e)
    {
        if (!TryParseSizes(out var sizes)) return;

        SetBusy(true);
        _rows.Clear();
        dgvResultados.Rows.Clear();
        txtConclusion.Clear();
        RefreshChart();
        progressBar.Maximum = sizes.Count;
        progressBar.Value = 0;
        int seed = (int)nudSemilla.Value;

        try
        {
            lblEstado.Text = "Calentando JIT...";
            await Task.Run(Benchmark.WarmUp);

            foreach (int n in sizes)
            {
                lblEstado.Text = $"Midiendo n = {n:N0}...";
                var row = await Task.Run(() => Benchmark.Measure(n, seed));
                _rows.Add(row);
                AddGridRow(row);
                progressBar.Value++;
                RefreshChart();
            }

            txtConclusion.Text = AnalysisText.BuildEmpirical(_rows);
            lblEstado.Text = "Listo";
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error";
        }
        finally
        {
            SetBusy(false);
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        _rows.Clear();
        dgvResultados.Rows.Clear();
        txtConclusion.Clear();
        progressBar.Value = 0;
        lblEstado.Text = "Listo";
        RefreshChart();
    }

    private void Grafica_OpcionCambiada(object? sender, EventArgs e) => RefreshChart();

    private void SetBusy(bool busy)
    {
        btnEjecutar.Enabled = !busy;
        btnLimpiar.Enabled = !busy;
        txtTamanos.Enabled = !busy;
        nudSemilla.Enabled = !busy;
        UseWaitCursor = busy;
    }

    private bool TryParseSizes(out List<int> sizes)
    {
        sizes = new List<int>();
        var parts = txtTamanos.Text.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in parts)
        {
            if (!int.TryParse(p, out int n) || n < 2 || n > MaxN)
            {
                MessageBox.Show(this, $"\"{p}\" no es válido. Usa enteros entre 2 y {MaxN:N0}, separados por comas.",
                    "Tamaños inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            sizes.Add(n);
        }
        sizes = sizes.Distinct().OrderBy(x => x).ToList();
        if (sizes.Count < 2)
        {
            MessageBox.Show(this, "Indica al menos 2 tamaños distintos para poder analizar el crecimiento.",
                "Tamaños insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private void AddGridRow(BenchmarkRow r)
    {
        double speedup = r.BubbleMs / Math.Max(r.MergeMs, 0.001);
        dgvResultados.Rows.Add(
            r.N.ToString("N0"),
            r.BubbleMs.ToString("N2"), r.BubbleComparisons.ToString("N0"), r.BubbleMoves.ToString("N0"), r.BubbleBytes.ToString("N0"),
            r.MergeMs.ToString("N2"), r.MergeComparisons.ToString("N0"), r.MergeMoves.ToString("N0"), r.MergeBytes.ToString("N0"),
            speedup.ToString("N1") + "×");
    }

    private void RefreshChart()
    {
        graphPanel.Xs.Clear();
        graphPanel.SeriesA.Clear();
        graphPanel.SeriesB.Clear();

        foreach (var r in _rows)
        {
            graphPanel.Xs.Add(r.N);
            switch (cmbMetrica.SelectedIndex)
            {
                case 1:
                    graphPanel.SeriesA.Add(r.BubbleComparisons);
                    graphPanel.SeriesB.Add(r.MergeComparisons);
                    break;
                case 2:
                    graphPanel.SeriesA.Add(r.BubbleBytes);
                    graphPanel.SeriesB.Add(r.MergeBytes);
                    break;
                default:
                    graphPanel.SeriesA.Add(r.BubbleMs);
                    graphPanel.SeriesB.Add(r.MergeMs);
                    break;
            }
        }

        graphPanel.Title = cmbMetrica.Text + (chkLog.Checked ? " (escala logarítmica)" : "");
        graphPanel.LogScale = chkLog.Checked;
        graphPanel.Invalidate();
    }
}
