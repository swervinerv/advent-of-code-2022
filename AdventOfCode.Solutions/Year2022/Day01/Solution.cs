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
        var inputList = Input.Split(
            new string[] { "\n" },
            StringSplitOptions.None
        );


        int elfId = 1;
        int totalCaloriesPerElf = 0;

        var caloriesByElf = new Dictionary<int, int>();

        foreach (var entry in inputList)
        {
            if (string.IsNullOrWhiteSpace(entry))
            {
                caloriesByElf.Add(elfId++, totalCaloriesPerElf);

                totalCaloriesPerElf = 0;

                continue;
            }

            totalCaloriesPerElf += int.Parse(entry);
        }

        var totalCalories = caloriesByElf.OrderByDescending(_ => _.Value).Take(3).Sum(_ => _.Value);

        return totalCalories.ToString();
    }
}
