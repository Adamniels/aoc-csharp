using AoC.Common;

namespace AoC.Solutions.Year2024.Day01;

// 2024 Day 1: Historian Hysteria
public class Solution : ISolution
{
    public object Part1(string input)
    {
        var (left, right) = Parse(input);
        left.Sort();
        right.Sort();
        return left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
    }

    public object Part2(string input)
    {
        var (left, right) = Parse(input);

        var counts = new Dictionary<long, long>();
        foreach (var r in right)
            counts[r] = counts.GetValueOrDefault(r) + 1;

        return left.Sum(l => l * counts.GetValueOrDefault(l));
    }

    private static (List<long> Left, List<long> Right) Parse(string input)
    {
        var left = new List<long>();
        var right = new List<long>();

        foreach (var line in InputParser.Lines(input))
        {
            var nums = InputParser.Ints(line);
            left.Add(nums[0]);
            right.Add(nums[1]);
        }

        return (left, right);
    }
}
