using Algo;

while (true)
{
    Console.WriteLine("What would you like to do?\n");

    Console.WriteLine(0 + " - " + ChoiceType.Sort);
    Console.WriteLine(1 + " - " + ChoiceType.Search);
    Console.WriteLine(2 + " - " + ChoiceType.FindDuplicates);
    Console.WriteLine(3 + " - " + ChoiceType.PathFinding);

    Console.WriteLine();

    Console.WriteLine("Press any other key to exit.\n");

    var choiceTypeString = Console.ReadLine();

    if (!int.TryParse(choiceTypeString, out var choiceTypeNum) || choiceTypeNum > 2) return;

    var choiceType = (ChoiceType)choiceTypeNum;

    var choice = choiceType.AsChoice();

    choice.Run();
}