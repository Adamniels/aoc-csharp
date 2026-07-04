using AoC.Common;

namespace AoC.Solutions.Year2023.Day07;

public class Solution : ISolution
{
    public object Part1(string input)
    {
        Parse(input);
        throw new NotImplementedException();
    }

    public object Part2(string input)
    {
        throw new NotImplementedException();
    }

    internal static List<Player> Parse(string input)
    {
        var playerList = new List<Player>();
        foreach (var line in InputParser.Lines(input))
        {
            var playerArr = line.Split(' ');
            playerList.Add(new Player(playerArr[0], int.Parse(playerArr[1])));
        }
        return playerList;
    }

    internal record Player(string Hand, int Bid);
}


// 1. Parse the input into the structs i want

// 2. Sort them based on the rules
// how do I do this in a smart way??

// 3. just add them all together
