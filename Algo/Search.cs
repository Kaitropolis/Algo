using Algo.Utils;
using System.Diagnostics;

namespace Algo;

public class Search : IChoice
{
    const int _size = 10;

    public void Run()
    {
        Console.WriteLine("Welcome to the searching experiment\n");

        var numbers = ArrayUtils.GetSortedNumbers(_size);
        var random = new Random();
        var randomIndex = random.Next(numbers.Length - 1);
        var target = numbers[randomIndex];

        BinarySearch(numbers, target);
    }

    private static int[] BinarySearch(int[] sortedNumbers, int target)
    {        
        Console.WriteLine($"Running Selection Sort on {_size} items\n");

        var stopwatch = new Stopwatch();
        var numbers = new int[sortedNumbers.Length];       

        Array.Copy(sortedNumbers, numbers, sortedNumbers.Length);

        stopwatch.Start();

        var left = 0;
        var right = numbers.Length - 1;

        Search(left, right);

        int Search(int left,  int right)
        {
            var middle = (left + right) / 2;

            if (numbers[middle] == target)
            {
                return middle;
            }

            Search(left, middle);
            Search(middle, right);

            return 0;
        }
        
        stopwatch.Stop();

        StopwatchUtils.LogTimeTaken(stopwatch);

        return numbers;
    }
}
