namespace AdventOfCode.Solutions.Year2022.Day08;

class Solution : SolutionBase
{
    public Solution() : base(08, 2022, "Treetop Tree House") { }

    protected override string SolvePartOne()
    {
        var forestInput = Input.SplitByNewline();

        int[][] forest = new int[forestInput[0].Length][];

        for (var x = 0; x < forestInput.Length; x++)
        {
            var treeRow = forestInput[x];
            forest[x] = new int[treeRow.Length];

            for (var y = 0; y < treeRow.Length; y++)
            {
                forest[x][y] = int.Parse(treeRow.Substring(y, 1));
            }
        }

        var visibleCount = 0;
        for (var y = 0; y < forest.Length; y++)
        {
            if (y == 0 || y == (forest.Length - 1))
            {
                visibleCount += forest[y].Length;

                continue;
            }

            for (var x = 0; x < forest[y].Length; x++)
            {
                if (x == 0 || x == (forest[y].Length - 1))
                {
                    visibleCount++;

                    continue;
                }

                var currentHeight = forest[y][x];
                var toTheLeft = forest[y].Take(x);
                if (!toTheLeft.Any(_ => _ >= currentHeight))
                {
                    visibleCount++;

                    continue;
                }

                var toTheRight = forest[y].Skip(x + 1);
                if (!toTheRight.Any(_ => _ >= currentHeight))
                {
                    visibleCount++;

                    continue;
                }

                for (var above = y - 1; above >= 0; above--)
                {
                    if (forest[above][x] >= currentHeight)
                    {
                        break;
                    }

                    if (above == 0)
                    {
                        visibleCount++;

                        continue;
                    }
                }

                for (var below = y + 1; below < forest[y].Length; below++)
                {
                    if (forest[below][x] >= currentHeight)
                    {
                        break;
                    }

                    if (below == forest[y].Length - 1)
                    {
                        visibleCount++;
                    }
                }
            }
        }

        return visibleCount.ToString();
    }

    protected override string SolvePartTwo()
    {
        return "";
    }
}
