namespace Algo
{
    public enum ChoiceType
    {
        Sort = 0,
        FindDuplicates = 1,
        PathFinding = 2
    }

    public static class ChoiceExtensions 
    {
        public static string AsString(this ChoiceType choiceType)
        {
            return choiceType switch
            {
                ChoiceType.Sort => "Sort",
                ChoiceType.FindDuplicates => "Find Duplicates",
                ChoiceType.PathFinding => "Path Finding",
                _ => throw new ArgumentOutOfRangeException(nameof(choiceType)),
            };
        }

        public static IChoice AsChoice(this ChoiceType choiceType)
        {
            return choiceType switch
            {
                ChoiceType.Sort => new Sort(),
                ChoiceType.FindDuplicates => new FindDuplicates(),
                ChoiceType.PathFinding => new PathFinding(),
                _ => throw new ArgumentOutOfRangeException(nameof(choiceType)),
            };
        }
    }
}
