using AoC.Solutions;
using Xunit;
using Solution = AoC.Solutions.Year2023.Day09.Solution;

namespace AoC.Tests.Year2023;

[Trait("Day", "2023_09")]
public class Day09Tests
{
    private readonly ISolution _solution = new Solution();

    [Fact]
    public void Part1_Sample() =>
        Assert.Equal("114", _solution.Part1(Load.Sample(2023, 9)).ToString());

    [Fact]
    public void Part2_Sample() =>
        Assert.Equal("EXPECTED", _solution.Part2(Load.Sample(2023, 9)).ToString());

    [Fact(Skip = "Fill in confirmed real answer, then remove Skip")]
    public void Part1_Real() =>
        Assert.Equal("REAL_ANSWER", _solution.Part1(Load.Input(2023, 9)).ToString());

    [Fact(Skip = "Fill in confirmed real answer, then remove Skip")]
    public void Part2_Real() =>
        Assert.Equal("REAL_ANSWER", _solution.Part2(Load.Input(2023, 9)).ToString());
}
