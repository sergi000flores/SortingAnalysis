using System.Diagnostics;
using SortingAnalysis.Algorithms;

namespace SortingAnalysis;

public sealed record BenchmarkRow(
    int N,
    double BubbleMs, long BubbleComparisons, long BubbleMoves, long BubbleBytes,
    double MergeMs, long MergeComparisons, long MergeMoves, long MergeBytes);

public static class Benchmark
{
    /// <summary>Calienta el JIT para que la primera medición no quede distorsionada.</summary>
    public static void WarmUp()
    {
        var rng = new Random(1);
        for (int r = 0; r < 3; r++)
        {
            var d = new int[2000];
            for (int i = 0; i < d.Length; i++) d[i] = rng.Next();
            BubbleSorter.Sort((int[])d.Clone(), new OpCounter());
            MergeSorter.Sort((int[])d.Clone(), new OpCounter());
        }
    }

    /// <summary>Mide ambos algoritmos sobre el mismo arreglo aleatorio de tamaño n.</summary>
    public static BenchmarkRow Measure(int n, int seed)
    {
        var rng = new Random(seed + n);
        var data = new int[n];
        for (int i = 0; i < n; i++) data[i] = rng.Next();

        var (bMs, bBytes, bCnt, bArr) = Run(BubbleSorter.Sort, data);
        var (mMs, mBytes, mCnt, mArr) = Run(MergeSorter.Sort, data);

        if (!IsSorted(bArr) || !IsSorted(mArr) || !bArr.AsSpan().SequenceEqual(mArr))
            throw new InvalidOperationException("Un algoritmo produjo un resultado incorrecto.");

        return new BenchmarkRow(n, bMs, bCnt.Comparisons, bCnt.Moves, bBytes,
                                   mMs, mCnt.Comparisons, mCnt.Moves, mBytes);
    }

    private static (double ms, long bytes, OpCounter cnt, int[] arr) Run(Action<int[], OpCounter> sort, int[] source)
    {
        var arr = (int[])source.Clone();
        var cnt = new OpCounter();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long allocBefore = GC.GetAllocatedBytesForCurrentThread();
        long t0 = Stopwatch.GetTimestamp();
        sort(arr, cnt);
        long t1 = Stopwatch.GetTimestamp();
        long allocAfter = GC.GetAllocatedBytesForCurrentThread();

        return (Stopwatch.GetElapsedTime(t0, t1).TotalMilliseconds, allocAfter - allocBefore, cnt, arr);
    }

    private static bool IsSorted(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
            if (a[i - 1] > a[i]) return false;
        return true;
    }
}
