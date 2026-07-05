using AoC.Common;

namespace AoC.Solutions.Year2023.Day07;

public class Solution : ISolution
{
    public object Part1(string input)
    {
        var players = Parse(input);
        var sortedPlayers = players
            .OrderBy(p => p.Rank)
            .ThenBy(p => p.Hand, Comparer<string>.Create(CompareHands));
        int multi = 1;
        int result = 0;
        foreach (var player in sortedPlayers)
        {
            result += player.Bid * multi;
            multi++;
        }
        return result;
    }

    public object Part2(string input)
    {
        var players = ParsePart2(input);
        var sortedPlayers = players
            .OrderBy(p => p.Rank)
            .ThenBy(p => p.Hand, Comparer<string>.Create(CompareHandsPart2));
        int multi = 1;
        int result = 0;
        foreach (var player in sortedPlayers)
        {
            result += player.Bid * multi;
            multi++;
        }
        return result;
    }

    internal record Player(string Hand, int Bid, int Rank);

    internal static List<Player> Parse(string input)
    {
        var playerList = new List<Player>();
        foreach (var line in InputParser.Lines(input))
        {
            var playerArr = line.Split(' ');
            var hand = playerArr[0];
            var rank = calc_rank(hand);
            playerList.Add(new Player(hand, int.Parse(playerArr[1]), rank));
        }
        return playerList;
    }

    internal static List<Player> ParsePart2(string input)
    {
        var playerList = new List<Player>();
        foreach (var line in InputParser.Lines(input))
        {
            var playerArr = line.Split(' ');
            var hand = playerArr[0];
            var rank = calcRankPart2(hand);
            playerList.Add(new Player(hand, int.Parse(playerArr[1]), rank));
        }
        return playerList;
    }

    private static int calc_rank(string hand)
    {
        var counts = hand.GroupBy(c => c)
            .Select(g => g.Count())
            .OrderByDescending(count => count)
            .ToList();

        return counts switch
        {
            [5] => 7, // Five of a kind
            [4, 1] => 6, // Four of a kind
            [3, 2] => 5, // Full house
            [3, 1, 1] => 4, // Three of a kind
            [2, 2, 1] => 3, // Two pair
            [2, 1, 1, 1] => 2, // One pair
            [1, 1, 1, 1, 1] => 1, // High card
            _ => throw new ArgumentException($"Invalid hand: {hand}"),
        };
    }

    private static int calcRankPart2(string hand)
    {
        var wildcardsCount = hand.Count(c => c == 'J');

        var nonWildcards = hand.Where(c => c != 'J');

        var counts = nonWildcards
            .GroupBy(c => c)
            .Select(g => g.Count())
            .OrderByDescending(count => count)
            .ToList();

        if (counts.Count == 0)
        {
            counts.Add(wildcardsCount);
        }
        else
        {
            counts[0] += wildcardsCount;
        }
        return counts switch
        {
            [5] => 7, // Five of a kind
            [4, 1] => 6, // Four of a kind
            [3, 2] => 5, // Full house
            [3, 1, 1] => 4, // Three of a kind
            [2, 2, 1] => 3, // Two pair
            [2, 1, 1, 1] => 2, // One pair
            [1, 1, 1, 1, 1] => 1, // High card
            _ => throw new ArgumentException($"Invalid hand: {hand}"),
        };
    }

    private static int CompareHands(string a, string b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            int compare = CardValue(a[i]).CompareTo(CardValue(b[i]));

            if (compare != 0)
                return compare;
        }

        return 0;
    }

    private static int CompareHandsPart2(string a, string b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            int compare = CardValuePart2(a[i]).CompareTo(CardValuePart2(b[i]));

            if (compare != 0)
                return compare;
        }

        return 0;
    }

    private static int CardValue(char card) =>
        card switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 11,
            'T' => 10,
            _ => card - '0', // '2'..'9' → 2..9
        };

    private static int CardValuePart2(char card) =>
        card switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 1, // joker is now only worth a 1
            'T' => 10,
            _ => card - '0', // '2'..'9' → 2..9
        };
}


// 1. Parse the input into the structs i want

// 2. Sort them based on the rules
// how do I do this in a smart way??

// 3. just add them all together
