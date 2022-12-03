namespace AdventOfCode.Solutions.Year2022.Day03;

class Solution : SolutionBase
{
    public Solution() : base(03, 2022, "Rucksack Reorganization") { }

    protected override string SolvePartOne()
    {
        var inputList = Input.SplitByNewline();
        var caseValueMap = GenerateCaseValueMap();

        var result = 0;
        foreach (var input in inputList)
        {
            var itemOne = input[..(input.Length / 2)];
            var itemTwo = input[(input.Length / 2)..];

            for (var x = 0; x < itemOne.Length; x++)
            {
                if (itemTwo.Contains(itemOne[x], StringComparison.CurrentCulture))
                {
                    result += caseValueMap.GetValueOrDefault(itemOne[x].ToString());

                    break;
                }
            }
        }

        return result.ToString();
    }

    protected override string SolvePartTwo()
    {
        var inputList = Input.SplitByNewline();
        var caseValueMap = GenerateCaseValueMap();

        var result = 0;
        for (var x = 0; x < inputList.Count(); x += 3)
        {
            var itemOne = inputList.ElementAt(x);
            var itemTwo = inputList.ElementAt(x + 1);
            var itemThree = inputList.ElementAt(x + 2);

            for (var y = 0; y < itemOne.Length; y++)
            {
                if (itemTwo.Contains(itemOne[y], StringComparison.CurrentCulture) && itemThree.Contains(itemOne[y], StringComparison.CurrentCulture))
                {
                    result += caseValueMap.GetValueOrDefault(itemOne[y].ToString());

                    break;
                }
            }
        }


        return result.ToString();
    }

    private static Dictionary<string, int> GenerateCaseValueMap()
    {
        var lowerCaseValues = Enumerable.Range(1, 26);
        var upperCaseValues = Enumerable.Range(27, 26);

        var caseValueMap = new Dictionary<string, int>();
        foreach (var lowerCase in lowerCaseValues)
        {
            caseValueMap.Add(Number2String(lowerCase, false), lowerCase);
        }

        foreach (var upperCase in upperCaseValues)
        {
            caseValueMap.Add(Number2String(upperCase - 26, true), upperCase);
        }

        return caseValueMap;
    }

    private static string Number2String(int number, bool isCaps)
    {
        Char c = (Char)((isCaps ? 65 : 97) + (number - 1));

        return c.ToString();
    }
}
