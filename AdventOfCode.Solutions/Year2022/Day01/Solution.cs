namespace AdventOfCode.Solutions.Year2022.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2022, "Calorie Counting") { }

    protected override string SolvePartOne()
    {
        var inputList = Input.Split(
            new string[] { "\n" },
            StringSplitOptions.None
        );

        int maxCalories = 0;
        int totalCalories = 0;
        foreach (var entry in inputList)
        {
            if (string.IsNullOrWhiteSpace(entry))
            {
                if (totalCalories > maxCalories)
                {
                    maxCalories = totalCalories;
                }

                totalCalories = 0;

                continue;
            }

            totalCalories += int.Parse(entry);
        }

        return maxCalories.ToString();
    }

    protected override string SolvePartTwo()
    {
        return "";
    }
}
