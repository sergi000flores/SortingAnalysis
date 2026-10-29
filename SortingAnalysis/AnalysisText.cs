using System.Text;

namespace SortingAnalysis;

public static class AnalysisText
{
    private static readonly string NL = Environment.NewLine;

    public static string BuildTheory()
    {
        var sb = new StringBuilder();
        sb.AppendLine("PROBLEMA SELECCIONADO");
        sb.AppendLine("Ordenar ascendentemente un arreglo de n enteros.");
        sb.AppendLine("Se comparan dos algoritmos con enfoques opuestos: Bubble Sort (fuerza bruta, in-place) y Merge Sort (divide y vencerás, usa memoria auxiliar).");
        sb.AppendLine();
        sb.AppendLine("══════════════════════════════════════════");
        sb.AppendLine("ALGORITMO 1: BUBBLE SORT");
        sb.AppendLine("══════════════════════════════════════════");
        sb.AppendLine("Idea: recorrer el arreglo intercambiando vecinos desordenados; en cada pasada el mayor \"burbujea\" a su posición final.");
        sb.AppendLine();
        sb.AppendLine("Complejidad en el tiempo");
        sb.AppendLine("  • Pasadas: n−1; en la pasada i se hacen n−1−i comparaciones.");
        sb.AppendLine("  • Comparaciones (peor/promedio) = Σ(n−1−i) = n(n−1)/2  →  O(n²).");
        sb.AppendLine("  • Mejor caso (ya ordenado, con bandera de intercambio): una sola pasada  →  O(n).");
        sb.AppendLine("  • Intercambios en caso promedio ≈ n(n−1)/4 (cada par está invertido con prob. 1/2).");
        sb.AppendLine();
        sb.AppendLine("Complejidad en el espacio");
        sb.AppendLine("  • Solo usa variables escalares (i, j, bandera, temporal del intercambio)  →  O(1) memoria auxiliar.");
        sb.AppendLine("  • Es in-place y estable.");
        sb.AppendLine();
        sb.AppendLine("══════════════════════════════════════════");
        sb.AppendLine("ALGORITMO 2: MERGE SORT");
        sb.AppendLine("══════════════════════════════════════════");
        sb.AppendLine("Idea: dividir el arreglo a la mitad, ordenar cada mitad recursivamente y mezclar las dos mitades ordenadas.");
        sb.AppendLine();
        sb.AppendLine("Complejidad en el tiempo");
        sb.AppendLine("  • Recurrencia: T(n) = 2·T(n/2) + Θ(n), T(1) = Θ(1).");
        sb.AppendLine("  • Teorema maestro (a=2, b=2, f(n)=Θ(n)=Θ(n^log₂2)) → caso 2  →  T(n) = Θ(n log n).");
        sb.AppendLine("  • Árbol de recursión: log₂n niveles × n trabajo por nivel.");
        sb.AppendLine("  • Mejor, promedio y peor caso son Θ(n log n); comparaciones ≈ n·log₂n − n.");
        sb.AppendLine();
        sb.AppendLine("Complejidad en el espacio");
        sb.AppendLine("  • Buffer auxiliar de n elementos para la mezcla  →  O(n).");
        sb.AppendLine("  • Pila de recursión de profundidad log₂n  →  O(log n).");
        sb.AppendLine("  • Total: O(n) + O(log n) = O(n). Es estable pero no in-place.");
        sb.AppendLine();
        sb.AppendLine("══════════════════════════════════════════");
        sb.AppendLine("COMPARACIÓN ANALÍTICA");
        sb.AppendLine("══════════════════════════════════════════");
        sb.AppendLine("                    Bubble Sort        Merge Sort");
        sb.AppendLine("Tiempo (mejor)      O(n)               O(n log n)");
        sb.AppendLine("Tiempo (promedio)   O(n²)              O(n log n)");
        sb.AppendLine("Tiempo (peor)       O(n²)              O(n log n)");
        sb.AppendLine("Espacio auxiliar    O(1)               O(n)");
        sb.AppendLine();
        sb.AppendLine("Ejemplo con n = 1 000 000 (4 bytes por entero):");
        sb.AppendLine("  • Bubble: ≈ 5·10¹¹ comparaciones, 0 bytes extra.");
        sb.AppendLine("  • Merge:  ≈ 2·10⁷ comparaciones, ≈ 4 MB extra.");
        sb.AppendLine("  • Merge hace unas 25 000 veces menos trabajo a cambio de 4 MB de memoria.");
        sb.AppendLine();
        sb.AppendLine("CONCLUSIÓN");
        sb.AppendLine("Existe un compromiso tiempo–espacio: Bubble Sort ahorra memoria pero su tiempo crece cuadráticamente; Merge Sort sacrifica O(n) memoria para lograr crecimiento casi lineal. Para n grande, Merge Sort es claramente superior; Bubble solo es razonable con n muy pequeño, datos casi ordenados o memoria extremadamente limitada.");
        sb.AppendLine();
        sb.AppendLine("Nota: los tiempos medidos incluyen el costo de los contadores de operaciones (igual para ambos algoritmos). La memoria se mide con GC.GetAllocatedBytesForCurrentThread().");
        return sb.ToString();
    }

    public static string BuildEmpirical(IReadOnlyList<BenchmarkRow> rows)
    {
        if (rows.Count < 2) return "Se necesitan al menos 2 tamaños para estimar el crecimiento.";

        var xs = rows.Select(r => (double)r.N).ToArray();
        double kBubbleC = Slope(xs, rows.Select(r => (double)r.BubbleComparisons).ToArray());
        double kMergeC = Slope(xs, rows.Select(r => (double)r.MergeComparisons).ToArray());
        double kBubbleT = Slope(xs, rows.Select(r => r.BubbleMs).ToArray());
        double kMergeT = Slope(xs, rows.Select(r => r.MergeMs).ToArray());
        double kMergeM = Slope(xs, rows.Select(r => (double)r.MergeBytes).ToArray());

        var last = rows[^1];
        var sb = new StringBuilder();
        sb.AppendLine("EVALUACIÓN EMPÍRICA (ajuste log-log: valor ∝ n^k)");
        sb.AppendLine($"  Comparaciones → Bubble k = {kBubbleC:0.00} (teoría 2)   |  Merge k = {kMergeC:0.00} (teoría ≈ 1, n·log n)");
        sb.AppendLine($"  Tiempo        → Bubble k = {kBubbleT:0.00}            |  Merge k = {kMergeT:0.00}");
        sb.AppendLine($"  Memoria extra → Bubble = {last.BubbleBytes:N0} B (O(1))  |  Merge k = {kMergeM:0.00} (teoría 1, O(n)); ≈ {(double)last.MergeBytes / last.N:0.0} B por elemento");
        sb.AppendLine($"  Con n = {last.N:N0}: Bubble hizo {(double)last.BubbleComparisons / Math.Max(1, last.MergeComparisons):N1}× más comparaciones que Merge.");
        sb.AppendLine("  Nota: Merge Sort con n·log n muestra k ligeramente > 1 porque log n también crece.");
        return sb.ToString();
    }

    /// <summary>Pendiente de la regresión lineal de ln(y) vs ln(x) (ignora y ≤ 0).</summary>
    private static double Slope(double[] x, double[] y)
    {
        var pts = x.Zip(y, (a, b) => (a, b)).Where(p => p.a > 0 && p.b > 0)
                   .Select(p => (lx: Math.Log(p.a), ly: Math.Log(p.b))).ToList();
        if (pts.Count < 2) return double.NaN;
        double mx = pts.Average(p => p.lx), my = pts.Average(p => p.ly);
        double num = pts.Sum(p => (p.lx - mx) * (p.ly - my));
        double den = pts.Sum(p => (p.lx - mx) * (p.lx - mx));
        return den == 0 ? double.NaN : num / den;
    }
}
