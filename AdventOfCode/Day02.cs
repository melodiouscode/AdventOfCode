namespace AdventOfCode;

internal sealed class Day02 : MyBase
{
    public override ValueTask<string> Solve_1()
    {
        var safeReports = 0;

        foreach (string reportRow in InputFile)
        {
            IEnumerable<int> reports = reportRow.Split(' ').Select(int.Parse);

            var isFirst = true;

            var previous = 0;

            var isIncreasing = false;
            var isDecreasing = false;
            var hasUnsafe = false;

            foreach (int report in reports)
            {
                if (!isFirst)
                {
                    if (report > previous)
                    {
                        isIncreasing = true;
                    }

                    if (report < previous)
                    {
                        isDecreasing = true;
                    }

                    if (previous == report)
                    {
                        hasUnsafe = true;
                    }

                    int dif = Math.Abs(previous - report);
                    if (dif is < 1 or > 3)
                    {
                        hasUnsafe = true;
                        break;
                    }
                }

                previous = report;
                isFirst = false;

                if (!isDecreasing || !isIncreasing)
                {
                    continue;
                }

                hasUnsafe = true;
                break;
            }

            if (!hasUnsafe)
            {
                safeReports++;
            }
        }

        return new ValueTask<string>(safeReports.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int safeCount = InputFile.Select(row => row.Split(' ')
                .Select(int.Parse)
                .ToArray())
            .Count(IsSafeWhenDamperFiredOnce);

        return new ValueTask<string>(safeCount.ToString());
    }

    private static bool IsSafeWhenDamperFiredOnce(int[] values)
    {
        (bool isSafe, int unsafeReading) = CheckIfSafeLevels(values);

        if (isSafe)
        {
            return true;
        }

        int unsafeIndex = Math.Max(0, unsafeReading - 1);
        int endIndex = Math.Min(values.Length - 1, unsafeReading + 1);

        for (int i = unsafeIndex; i <= endIndex; i++)
        {
            int[] newValues = values.Take(i).Concat(values.Skip(i + 1)).ToArray();
            (isSafe, _) = CheckIfSafeLevels(newValues);

            if (isSafe)
            {
                return true;
            }
        }

        return false;
    }

    private static (bool, int) CheckIfSafeLevels(int[] values)
    {
        bool increasing = values[1] > values[0];
        bool isASafeDifference = Math.Abs(values[1] - values[0]) is 1 or 2 or 3;

        if (!isASafeDifference)
        {
            return (false, 0);
        }

        for (var i = 1; i < values.Length - 1; i++)
        {
            int diff = values[i + 1] - values[i];
            bool increase = diff > 0;
            bool safeDifference = Math.Abs(diff) is 1 or 2 or 3;

            if (!safeDifference || increase != increasing)
            {
                return (false, i);
            }
        }

        return (true, -1);
    }
}

