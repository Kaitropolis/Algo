namespace Algo.Utils;
public static class ArrayUtils
{
    public static int[] GetSortedNumbers(int size)
    {
        var numbers = new int[size];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }

        return numbers;
    }

    public static int[] GetUnsortedNumbers(int size)
    {
        var numbers = GetSortedNumbers(size);

        var random = new Random();

        for (int i = numbers.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);

            (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
        }

        return numbers;
    }

    public static void LogNumbers(int[] numbers)
    {
        var numbersString = $"[{string.Join(", ", numbers)}]";

        Console.WriteLine($"{numbersString}\n");
    }
}
