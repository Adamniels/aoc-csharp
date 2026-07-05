using AoC.Solutions;
using Xunit;
using Day07 = AoC.Solutions.Year2023.Day07;
using Solution = AoC.Solutions.Year2023.Day07.Solution;

namespace AoC.Tests.Year2023;

[Trait("Day", "2023_07")]
public class Day07Tests
{
    private readonly ISolution _solution = new Solution();

    [Fact]
    public void Part1_Sample() =>
        Assert.Equal("6440", _solution.Part1(Load.Sample(2023, 7)).ToString());

    [Fact]
    public void Part2_Sample() =>
        Assert.Equal("5905", _solution.Part2(Load.Sample(2023, 7)).ToString());

    [Fact]
    public void Part1_Real() =>
        Assert.Equal("246409899", _solution.Part1(Load.Input(2023, 7)).ToString());

    [Fact]
    public void Part2_Real() =>
        Assert.Equal("244848487", _solution.Part2(Load.Input(2023, 7)).ToString());

    [Fact]
    public void Parse_Sample_HasFivePlayers()
    {
        var players = Day07.Solution.Parse(Load.Sample(2023, 7));
        Assert.Equal(5, players.Count);
    }

    [Fact]
    public void Parse_Sample_FirstAndLastRowsAreCorrect()
    {
        var players = Day07.Solution.Parse(Load.Sample(2023, 7));

        Assert.Equal(new Day07.Solution.Player("32T3K", 765, 2), players[0]);
        Assert.Equal(new Day07.Solution.Player("QQQJA", 483, 4), players[^1]);
    }
}
