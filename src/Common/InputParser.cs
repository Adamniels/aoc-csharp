using System.Text.RegularExpressions;

namespace AoC.Common;

public static class InputParser
{
    /// <summary>All lines, line endings normalized, trailing newline dropped.</summary>
    public static string[] Lines(string input) =>
        input.ReplaceLineEndings("\n").TrimEnd('\n').Split('\n');

    /// <summary>Blocks separated by blank lines. Each block keeps its internal newlines.</summary>
    public static string[] Blocks(string input) =>
        input.ReplaceLineEndings("\n").TrimEnd('\n').Split("\n\n");

    /// <summary>Every integer in the string, including negatives, in order of appearance.</summary>
    public static long[] Ints(string input) =>
        Regex.Matches(input, @"-?\d+").Select(m => long.Parse(m.Value)).ToArray();

    /// <summary>The input as a jagged char grid, one row per line.</summary>
    public static char[][] CharGrid(string input) =>
        Lines(input).Select(line => line.ToCharArray()).ToArray();
}
