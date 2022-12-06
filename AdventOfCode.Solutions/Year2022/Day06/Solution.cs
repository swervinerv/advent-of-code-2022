namespace AdventOfCode.Solutions.Year2022.Day06;

class Solution : SolutionBase
{
    public Solution() : base(06, 2022, "Tuning Trouble") { }

    protected override string SolvePartOne()
    {
        var inputBuffer = Input;
        List<string> inputParser = new();
        int result = 0;

        for (var x = 0; x < inputBuffer.Length; x++)
        {
            inputParser.Add(inputBuffer.Substring(x, 1));
            
            if (inputParser.Count < 4)
            {
                continue;
            }

            if (inputParser.Distinct().Count() == 4)
            {
                result = x + 1;

                break;
            }

            inputParser.RemoveAt(0);
        }

        return result.ToString();
    }

    protected override string SolvePartTwo()
    {
        return "";
    }
}
