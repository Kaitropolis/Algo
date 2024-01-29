using System.Diagnostics;

namespace Algo
{
    public class FindDuplicates : IChoice
    {

        const int _size = 100000;

        public void Run()
        {
            var numbers = GetNumbers();
            int targetIndex;
            var duplicates = new HashSet<int>();
            var stopwatch = new Stopwatch();

            LogNumbers(numbers);

            stopwatch.Start();

            for (int i = 0; i < numbers.Length; i++)
            {
                targetIndex = i;

                for (int j = i + 1; j < numbers.Length || !duplicates.Contains(numbers[targetIndex]); j++)
                {
                    if (numbers[j] == numbers[targetIndex] && !duplicates.Contains(numbers[j]))
                    {
                        duplicates.Add(numbers[j]);
                        break;
                    }
                }
            }

            stopwatch.Stop();

            LogNumbers(duplicates.ToArray());

            LogTimeTaken(stopwatch);
        }

        static int[] GetNumbers()
        {
            var numbers = new int[_size];

            var random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10);
            }

            return numbers;
        }

        static void LogNumbers(int[] numbers)
        {
            var numbersString = $"[{string.Join(", ", numbers)}]";

            Console.WriteLine($"{numbersString}\n");
        }

        static void LogTimeTaken(Stopwatch stopwatch)
        {
            var elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine($"Time to find duplicates: {elapsedSeconds} seconds");
        }
    }
}
