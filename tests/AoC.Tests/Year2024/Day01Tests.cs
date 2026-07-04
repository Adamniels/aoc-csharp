using AoC.Solutions;
using Xunit;
using Solution = AoC.Solutions.Year2024.Day01.Solution;

namespace AoC.Tests.Year2024;

[Trait("Day", "2024_01")]
public class Day01Tests
{
    private readonly ISolution _solution = new Solution();

    [Fact]
    public void Part1_Sample() =>
        Assert.Equal("11", _solution.Part1(Load.Sample(2024, 1)).ToString());

    [Fact]
    public void Part2_Sample() =>
        Assert.Equal("31", _solution.Part2(Load.Sample(2024, 1)).ToString());

    [Fact(Skip = "Fill in confirmed real answer, then remove Skip")]
    public void Part1_Real() =>
        Assert.Equal("REAL_ANSWER", _solution.Part1(Load.Input(2024, 1)).ToString());

    [Fact(Skip = "Fill in confirmed real answer, then remove Skip")]
    public void Part2_Real() =>
        Assert.Equal("REAL_ANSWER", _solution.Part2(Load.Input(2024, 1)).ToString());
}
