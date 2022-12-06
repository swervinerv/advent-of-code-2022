using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2022.Day05;

class Solution : SolutionBase
{
    public Solution() : base(05, 2022, "Supply Stacks") { }

    protected override string SolvePartOne()
    {
        var allInputs = Input.SplitByNewline();
        var crates = allInputs.Take(8);

        int crateStackCount = 9;

        Dictionary<int, List<string>> testing = new();
        for (var x = 1; x <= crateStackCount; x++)
        {
            testing[x] = new();
        }

        int previousColumnIndex = 0;
        Dictionary<int, int> columnIndexes = new();
        for (var x = 1; x <= crateStackCount; x++)
        {
            var columnIndex = previousColumnIndex == 0 ? 1 : previousColumnIndex + 4;

            columnIndexes[columnIndex] = x;

            previousColumnIndex = columnIndex;
        }

        foreach (var crate in crates)
        {
            for (var x = 0; x < crate.Length; x++)
            {
                var crateLetter = crate.Substring(x, 1);
                if (char.IsLetter(crateLetter, 0))
                {
                    var column = columnIndexes[x];

                    testing[column].Add(crateLetter);
                }
            }
        }

        for (var x = 1; x <= crateStackCount; x++)
        {
            testing[x].Reverse();
        }

        Dictionary<int, Stack<string>> stackedCrates = new();
        for (var x = 1; x <= crateStackCount; x++)
        {
            stackedCrates[x] = new();

            testing[x].ForEach(_ => stackedCrates[x].Push(_));
        }

        var remainingInputs = allInputs.Skip(9);
        foreach (var instruction in remainingInputs)
        {
            var movement = ((string)instruction).Split(' ');

            var moveCount = int.Parse(movement[1]);
            var moveFrom = int.Parse(movement[3]);
            var moveTo = int.Parse(movement[5]);

            List<string> cratesToMove = new();
            for (var x = 0; x < moveCount; x++)
            {
                cratesToMove.Add(stackedCrates[moveFrom].Pop());
            }

            foreach (var crate in cratesToMove)
            {
                stackedCrates[moveTo].Push(crate);
            }
        }

        StringBuilder result = new();
        foreach (var crate in stackedCrates)
        {
            result.Append(crate.Value.Pop());
        }

        return result.ToString();
    }

    protected override string SolvePartTwo()
    {
        return "";
    }
}
