namespace Algo
{
    public enum ChoiceType
    {
        Sort = 0,
        FindDuplicates = 1
    }

    public static class ChoiceExtensions 
    {
        public static string AsString(this ChoiceType choiceType)
        {
            return choiceType switch
            {
                ChoiceType.Sort => "Sort",
                ChoiceType.FindDuplicates => "Find Duplicates",
                _ => throw new ArgumentOutOfRangeException(nameof(choiceType)),
            };
        }

        public static IChoice AsChoice(this ChoiceType choiceType)
        {
            return choiceType switch
            {
                ChoiceType.Sort => new Sort(),
                ChoiceType.FindDuplicates => new FindDuplicates(),
                _ => throw new ArgumentOutOfRangeException(nameof(choiceType)),
            };
        }
    }
}
