namespace AdventOfCode;

internal sealed class Day01 : MyBase
{
    public override ValueTask<string> Solve_1()
    {
        (IList<int> left, IList<int> right) = Int32Columns(true);

        var total = 0;
        int leftIndex = 0, rightIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            total += Math.Abs(left[leftIndex] - right[rightIndex]);
            leftIndex++;
            rightIndex++;
        }

        return new ValueTask<string>(total.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var leftTwo = new List<int>();
        var rights = new Dictionary<int, int>();

        foreach (string line in InputFile)
        {
            string[] split = line.Split(TabSpaces);

            var leftNumber = split[0].ToInt32();
            var rightNumber = split[1].ToInt32();

            leftTwo.Add(leftNumber);

            if (!rights.TryAdd(rightNumber, 1))
            {
                rights[rightNumber]++;
            }
        }

        var totalTwo = 0;

        foreach (int leftNumber in leftTwo)
        {
            if (rights.TryGetValue(leftNumber, out int right))
            {
                totalTwo += leftNumber * right;
            }
        }

        return new ValueTask<string>(totalTwo.ToString());
    }
}
