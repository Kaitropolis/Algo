using System.Diagnostics;

namespace Algo
{
    public class Sort : IChoice
    {
        const int _size = 50000;

        public void Run()
        {
            Console.WriteLine("Welcome to the sorting experiment\n");

            // Average times are based on an array size of 50000         

            BubbleSort();

            SelectionSort();  
        }

        static int[] GetUnsortedNumbers()
        {
            var numbers = new int[_size];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            var random = new Random();

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
            }

            return numbers;
        }

        // Average Time - 6 seconds
        static void SelectionSort()
        {
            Console.WriteLine($"Running Selection Sort on {_size} items\n");

            var stopwatch = new Stopwatch();

            var numbers = GetUnsortedNumbers();

            int minIndex;

            stopwatch.Start();

            for (int i = 0; i < numbers.Length; i++)
            {
                minIndex = i;

                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                (numbers[minIndex], numbers[i]) = (numbers[i], numbers[minIndex]);

                //LogNumbers(numbers);
            }

            stopwatch.Stop();

            LogTimeTaken(stopwatch);
        }

        // Average Time - 17 seconds
        static void BubbleSort()
        {
            Console.WriteLine($"Running Bubble Sort on {_size} items\n");

            var stopwatch = new Stopwatch();

            var numbers = GetUnsortedNumbers();

            bool hasSwapped;

            stopwatch.Start();

            for (int i = 0; i < numbers.Length; i++)
            {
                hasSwapped = false;

                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j + 1] < numbers[j])
                    {
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);

                        hasSwapped = true;

                        //LogNumbers(numbers);
                    }
                }

                if (!hasSwapped) break;
            }

            stopwatch.Stop();

            LogTimeTaken(stopwatch);
        }

        static void LogNumbers(int[] numbers)
        {
            var numbersString = $"[{string.Join(", ", numbers)}]";

            Console.WriteLine($"{numbersString}\n");
        }

        static void LogTimeTaken(Stopwatch stopwatch)
        {
            var elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine($"Sort Time: {elapsedSeconds} seconds");
        }
    }
}
