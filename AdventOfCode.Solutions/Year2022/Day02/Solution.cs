namespace AdventOfCode.Solutions.Year2022.Day02;

class Solution : SolutionBase
{
    public Solution() : base(02, 2022, "Rock Paper Scissors") { }

    protected override string SolvePartOne()
    {
        //a, x = rock = 1
        //b, y = paper = 2
        //c, z = scissors = 3
        //win = 6, draw = 3, lose = 0

        var games = Input.SplitByNewline()
            .Select(_ => _.Split(' '));

        var totalPoints = 0;
        foreach (var game in games)
        {
            var played = game[1].ToLower();
            var opponentPlayed = game[0].ToLower();

            totalPoints += played == "x"
                ? 1 : (played == "y" ? 2 : 3);

            if ((played == "x" && opponentPlayed == "b") || (played == "y" && opponentPlayed == "c") || (played == "z" && opponentPlayed == "a"))
            {
                continue;
            }

            if ((played == "x" && opponentPlayed == "a") || (played == "y" && opponentPlayed == "b") || (played == "z" && opponentPlayed == "c"))
            {
                totalPoints += 3;

                continue;
            }

            totalPoints += 6;
        }

        return totalPoints.ToString();
    }

    protected override string SolvePartTwo()
    {
        //a, x = rock = 1
        //b, y = paper = 2
        //c, z = scissors = 3

        var games = Input.SplitByNewline()
            .Select(_ => _.Split(' '));

        var totalPoints = 0;
        foreach (var game in games)
        {
            var opponentPlayed = game[0].ToLower();
            var outcome = game[1].ToLower();

            if (outcome == "x")
            {
                totalPoints += opponentPlayed == "a"
                    ? 3 : (opponentPlayed == "b" ? 1 : 2);

                continue;
            }

            if (outcome == "y")
            {
                totalPoints += 3;

                totalPoints += opponentPlayed == "a"
                    ? 1 : (opponentPlayed == "b" ? 2 : 3);

                continue;
            }

            totalPoints += 6;

            totalPoints += opponentPlayed == "a"
                ? 2 : (opponentPlayed == "b" ? 3 : 1);
        }

        return totalPoints.ToString();
    }
}
