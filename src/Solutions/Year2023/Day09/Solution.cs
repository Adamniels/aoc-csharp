using AoC.Common;

namespace AoC.Solutions.Year2023.Day09;

public class Solution : ISolution
{
    public object Part1(string input)
    {
        var result = 0;
        var lines = InputParser.Lines(input);
        foreach (var line in lines)
        {
            List<int> parsedLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            result += solveLine(parsedLine);
        }
        return result;
    }

    private static int solveLine(List<int> parsedLine)
    {
        var lastNum = new List<int>();
        lastNum.Add(parsedLine.Last());
        var nextRow = solveRow(parsedLine);
        while (nextRow is not null)
        {
            lastNum.Add(nextRow.Last());
            nextRow = solveRow(nextRow);
        }
        return lastNum.Sum();
    }

    private static List<int>? solveRow(List<int> row)
    {
        var nextRow = new List<int>();
        for (int i = 0; i < row.Count - 1; i++)
        {
            var current = row.ElementAt(i);
            var after = row.ElementAt(i + 1);
            var newNr = after - current;
            nextRow.Add(newNr);
        }

        if (nextRow.All(number => number == 0))
        {
            return null;
        }

        return nextRow;
    }

    public object Part2(string input)
    {
        throw new NotImplementedException();
    }
}
