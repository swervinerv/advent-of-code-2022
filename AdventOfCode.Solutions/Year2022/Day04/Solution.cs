namespace AdventOfCode.Solutions.Year2022.Day04;

class Solution : SolutionBase
{
    public Solution() : base(04, 2022, "Camp Cleanup") { }

    protected override string SolvePartOne()
    {
        var inputList = Input.SplitByNewline();

        var result = 0;
        foreach (var input in inputList)
        {
            var rangeOne = input.Split(',')[0].Split('-').Select(_ => int.Parse(_)).ToArray();
            var rangeTwo = input.Split(',')[1].Split('-').Select(_ => int.Parse(_)).ToArray();

            var enumerableRangeOne = Enumerable.Range(rangeOne[0], rangeOne[1] - rangeOne[0] + 1);
            var enumerableRangeTwo = Enumerable.Range(rangeTwo[0], rangeTwo[1] - rangeTwo[0] + 1);

            var intersection = enumerableRangeOne.Intersect(enumerableRangeTwo);
            var intersectionCount = intersection.Count();

            if (intersectionCount == enumerableRangeOne.Count() || intersectionCount == enumerableRangeTwo.Count())
            {
                result++;
            }
        }

        return result.ToString();
    }

    protected override string SolvePartTwo()
    {
        return "";
    }
}
