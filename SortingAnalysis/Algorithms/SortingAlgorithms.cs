namespace SortingAnalysis.Algorithms;

/// <summary>Contadores de operaciones elementales (análisis empírico de complejidad).</summary>
public sealed class OpCounter
{
    public long Comparisons;
    public long Moves;
}

/// <summary>
/// Bubble Sort con bandera de intercambio.
/// Tiempo: mejor O(n), promedio/peor O(n²). Espacio auxiliar: O(1) (in-place).
/// </summary>
public static class BubbleSorter
{
    public static void Sort(int[] a, OpCounter c)
    {
        int n = a.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                c.Comparisons++;
                if (a[j] > a[j + 1])
                {
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                    c.Moves += 3; // un intercambio = 3 asignaciones
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }
}

/// <summary>
/// Merge Sort top-down con un único buffer auxiliar.
/// Tiempo: Θ(n log n) en todos los casos. Espacio auxiliar: O(n) buffer + O(log n) pila.
/// </summary>
public static class MergeSorter
{
    public static void Sort(int[] a, OpCounter c)
    {
        if (a.Length < 2) return;
        var tmp = new int[a.Length]; // O(n) memoria extra
        SortRange(a, tmp, 0, a.Length - 1, c);
    }

    private static void SortRange(int[] a, int[] tmp, int lo, int hi, OpCounter c)
    {
        if (lo >= hi) return;
        int mid = lo + (hi - lo) / 2;
        SortRange(a, tmp, lo, mid, c);
        SortRange(a, tmp, mid + 1, hi, c);
        Merge(a, tmp, lo, mid, hi, c);
    }

    private static void Merge(int[] a, int[] tmp, int lo, int mid, int hi, OpCounter c)
    {
        int i = lo, j = mid + 1, k = lo;
        while (i <= mid && j <= hi)
        {
            c.Comparisons++;
            tmp[k++] = a[i] <= a[j] ? a[i++] : a[j++];
            c.Moves++;
        }
        while (i <= mid) { tmp[k++] = a[i++]; c.Moves++; }
        while (j <= hi) { tmp[k++] = a[j++]; c.Moves++; }
        for (k = lo; k <= hi; k++) { a[k] = tmp[k]; c.Moves++; }
    }
}
