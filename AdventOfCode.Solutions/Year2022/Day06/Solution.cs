namespace AdventOfCode.Solutions.Year2022.Day06;

class Solution : SolutionBase
{
    public Solution() : base(06, 2022, "Tuning Trouble") { }

    protected override string SolvePartOne()
        => GetDistinctMarker(4).ToString();

    protected override string SolvePartTwo()
        => GetDistinctMarker(14).ToString();

    private int GetDistinctMarker(int characterCount)
    {
        var inputBuffer = Input;

        int result = 0;
        List<string> inputParser = new();

        for (var x = 0; x < inputBuffer.Length; x++)
        {
            inputParser.Add(inputBuffer.Substring(x, 1));

            if (inputParser.Count < characterCount)
            {
                continue;
            }

            if (inputParser.Distinct().Count() == characterCount)
            {
                result = x + 1;

                break;
            }

            inputParser.RemoveAt(0);
        }

        return result;
    }
}
