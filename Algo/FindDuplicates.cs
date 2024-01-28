using System.Diagnostics;

namespace Algo
{
    public class FindDuplicates : IChoice
    {
        public void Run()
        {
            throw new NotImplementedException();
        }

        static void LogNumbers(int[] numbers)
        {
            var numbersString = $"[{string.Join(", ", numbers)}]";

            Console.WriteLine($"{numbersString}\n");
        }

        static void LogTimeTaken(Stopwatch stopwatch)
        {
            var elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine($"Sort Time: {elapsedSeconds} seconds\n");
        }
    }
}
