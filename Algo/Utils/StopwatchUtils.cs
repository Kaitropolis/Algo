using System.Diagnostics;

namespace Algo.Utils;

public static class StopwatchUtils
{
    public static void LogTimeTaken(Stopwatch stopwatch)
    {
        var elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;

        Console.WriteLine($"Sort Time: {elapsedSeconds} seconds\n");
    }
}
