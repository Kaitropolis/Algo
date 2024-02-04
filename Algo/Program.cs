using Algo;

while (true)
{
    Console.WriteLine("What would you like to do?\n");

    Console.WriteLine((int)ChoiceType.Sort  + " - " + ChoiceType.Sort);
    Console.WriteLine((int)ChoiceType.FindDuplicates + " - " + ChoiceType.FindDuplicates);

    Console.WriteLine();

    Console.WriteLine("Press any other key to exit.\n");

    var choiceTypeString = Console.ReadLine();

    if (!int.TryParse(choiceTypeString, out var choiceTypeNum) || choiceTypeNum > 1) return;

    var choiceType = (ChoiceType)choiceTypeNum;

    var choice = choiceType.AsChoice();

    choice.Run();
}