using System.Diagnostics;

Console.WriteLine("Welcome to the sorting experiment\n");

const int size = 5;

Bubblesort();

SelectionSort();

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

static void SelectionSort()
{
    Console.WriteLine("Running selection sort\n");

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

        LogNumbers(numbers);
    }

    stopwatch.Stop();

    LogTimeTaken(stopwatch);
}

static void Bubblesort()
{
    Console.WriteLine("Running bubble sort\n");

    var stopwatch = new Stopwatch();

    var numbers = GetUnsortedNumbers();

    stopwatch.Start();

    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = 0; j < numbers.Length - 1; j++)
        {
            if(numbers[j + 1] <  numbers[j])
            {
                (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);

                LogNumbers(numbers);
            }
        }
    }

    stopwatch.Stop();

    LogTimeTaken(stopwatch);
}

static void LogNumbers(int[] numbers)
{
    var numbersString = $"[{string.Join(", ", numbers)}]";
    Console.WriteLine(numbersString);
    Console.WriteLine();
}

static void LogTimeTaken(Stopwatch stopwatch)
{
    var elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;

    Console.WriteLine($"Sort Time: {elapsedSeconds} seconds\n");
}