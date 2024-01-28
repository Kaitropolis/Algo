using Algo;

while (true)
{
    Console.WriteLine("What would you like to do?\n");

    Console.WriteLine(ChoiceType.Sort + " - " + (int)ChoiceType.Sort);
    Console.WriteLine(ChoiceType.FindDuplicates + " - " + (int)ChoiceType.FindDuplicates);

    Console.WriteLine();

    Console.WriteLine("Press any other key to exit.\n");

    var choiceTypeString = Console.ReadLine();

    if (!int.TryParse(choiceTypeString, out var choiceTypeNum) || choiceTypeNum > 1) return;

    var choiceType = (ChoiceType)choiceTypeNum;

    var choice = choiceType.AsChoice();

    choice.Run();

    Console.WriteLine();
}