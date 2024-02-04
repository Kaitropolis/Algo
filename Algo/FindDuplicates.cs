using System.Diagnostics;

namespace Algo
{
    public class FindDuplicates : IChoice
    {
        const int _size = 100000;

        public void Run()
        {
            var numbers = GetNumbers();

            WithNestedLoop(numbers);

            WithSingleLoop(numbers);
        }

        static void WithNestedLoop(int[] numbers)
        {
            Console.WriteLine("Running With Nested Loop\n");

            var duplicates = new HashSet<int>();
            var stopwatch = new Stopwatch();
            int targetIndex;

            stopwatch.Start();

            for (int i = 0; i < numbers.Length; i++)
            {
                targetIndex = i;
                
                for (int j = i; j < numbers.Length || !duplicates.Contains(numbers[targetIndex]); j++)
                {
                    if (numbers[j] == numbers[targetIndex] && !duplicates.Contains(numbers[j]))
                    {
                        duplicates.Add(numbers[j]);
                        break;
                    }
                }
            }

            stopwatch.Stop();

            LogTimeTaken(stopwatch);
        } 

        static void WithSingleLoop(int[] numbers)
        {
            Console.WriteLine("Running With Single Loop\n");

            var duplicates = new HashSet<int>();
            var uniqueNumbers = new HashSet<int>();
            var stopwatch = new Stopwatch();
        
            stopwatch.Start();

            for (int i = 0; i < numbers.Length; i++)
            {
               var isAdded = uniqueNumbers.Add(numbers[i]);

                if (!isAdded)
                {
                    duplicates.Add(numbers[i]);
                }
            }

            stopwatch.Stop();

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

            Console.WriteLine($"Time to find duplicates: {elapsedSeconds} seconds\n");
        }
    }
}
