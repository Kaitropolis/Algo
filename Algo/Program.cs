using System.Diagnostics;

Console.WriteLine("Welcome to the sorting experiment");

const int size = 10000;

var numbers = GetUnsortedNumbers();

SelectionSort(numbers);

Console.ReadLine();

static int[] GetUnsortedNumbers()
{
    var numbers = new int[size];

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

static void SelectionSort(int[] numbers)
{
    var stopwatch = new Stopwatch();
    int minIndex;

    Console.WriteLine("Begin selection sort");

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

        LogNumbers(numbers);
    }

    stopwatch.Stop();

    Console.WriteLine($"Selection Sort Time: {stopwatch.ElapsedMilliseconds / 1000} seconds");
}

static void LogNumbers(int[] numbers)
{
    var numbersString = $"[{string.Join(", ", numbers)}]";
    Console.WriteLine(numbersString);
    Console.WriteLine();
}