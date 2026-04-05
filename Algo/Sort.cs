using Algo.Utils;
using System.Diagnostics;

namespace Algo
{
    public class Sort : IChoice
    {
        const int _size = 50000;

        public void Run()
        {
            Console.WriteLine("Welcome to the sorting experiment\n");

            var unsortedNumbers = ArrayUtils.GetUnsortedNumbers(_size);

            //ArrayUtils.LogNumbers(unsortedNumbers);

            BubbleSort(unsortedNumbers);

            SelectionSort(unsortedNumbers);

            MergeSort(unsortedNumbers);
        }        

        // Average times based on 50000 items for Bubble/Selection sort and 10000000 items for merge sort

        // Average Time - 6 seconds
        static void SelectionSort(int[] unsortedNumbers)
        {
            Console.WriteLine($"Running Selection Sort on {_size} items\n");

            var stopwatch = new Stopwatch();
            var numbers = new int[unsortedNumbers.Length];
            int minIndex;

            Array.Copy(unsortedNumbers, numbers, unsortedNumbers.Length);

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

            StopwatchUtils.LogTimeTaken(stopwatch);
        }

        // Average Time - 17 seconds
        static void BubbleSort(int[] unsortedNumbers)
        {
            Console.WriteLine($"Running Bubble Sort on {_size} items\n");

            var stopwatch = new Stopwatch();
            var numbers = new int[unsortedNumbers.Length];
            bool hasSwapped;

            Array.Copy(unsortedNumbers, numbers, unsortedNumbers.Length);

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

            StopwatchUtils.LogTimeTaken(stopwatch);
        }

        static void MergeSort(int[] unsortedNumbers)
        {
            Console.WriteLine($"Running Merge Sort on {_size} items\n");

            var stopwatch = new Stopwatch();
            var numbers = new int[unsortedNumbers.Length];            

            Array.Copy(unsortedNumbers, numbers, unsortedNumbers.Length);

            stopwatch.Start();

            numbers = MergeResursive(numbers);       

            StopwatchUtils.LogTimeTaken(stopwatch);
        }

        // Average Time - 3.648
        static int[] MergeResursive(int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers;

            var mid = numbers.Length / 2;
            var left = MergeResursive(numbers[.. mid]);            
            var right = MergeResursive(numbers[mid ..]);

            var sorted = new int[numbers.Length];
            int l = 0, r = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (l >= left.Length)
                    sorted[i] = right[r++];
                else if (r >= right.Length)
                    sorted[i] = left[l++];
                else
                    sorted[i] = left[l] < right[r] ? left[l++] : right[r++];
            }            

            return sorted;
        }

        // Average Time - 3.968
        static int[] MergeIterative(int[] numbers)
        {            
            int size = 2; // Size of the current subarray
            while (size / 2 < numbers.Length)
            {
                int left = 0;
                while (left < numbers.Length)
                {
                    int right = Math.Min(left + size, numbers.Length);
                    int mid = left + size / 2;
                    int l = left, r = mid;
                    var sorted = new int[size];
                    for (int i = 0; i < right - left; i++)
                    {
                        if (l >= mid && r >= right)
                            continue;
                        if (l >= mid)
                            sorted[i] = numbers[r++];
                        else if (r >= right)
                            sorted[i] = numbers[l++];
                        else
                            sorted[i] = numbers[l] < numbers[r] ? numbers[l++] : numbers[r++];
                    }

                    for (int i = left; i < right; i++)
                    {
                        numbers[i] = sorted[i - left];
                    }

                    left += size;
                }

                size *= 2;
            }

            return numbers;
        }
    }
}
