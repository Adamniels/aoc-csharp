using AoC.Common;

namespace AoC.Solutions.Year2023.Day08;

public class Solution : ISolution
{
    public object Part1(string input)
    {
        var directions = ParseDirectionPart1(input);
        var nodes = ParseNodesPart1(input);

        return WalkPath(directions, nodes);
    }

    internal static int WalkPath(string directions, SortedList<string, (string, string)> nodes)
    {
        string currentNode = "AAA";
        string nextNode;
        int steps = 0;
        while (!currentNode.Equals("ZZZ"))
        {
            var direction = directions[steps % directions.Length];
            if (direction == 'L')
            {
                nextNode = nodes[currentNode].Item1;
                currentNode = nextNode;
            }
            else
            {
                nextNode = nodes[currentNode].Item2;
                currentNode = nextNode;
            }
            steps++;
        }

        return steps;
    }

    internal static string ParseDirectionPart1(string input)
    {
        return InputParser.Lines(input)[0];
    }

    internal static SortedList<string, (string, string)> ParseNodesPart1(string input)
    {
        var lines = InputParser.Lines(input);

        string directions = lines[0];
        var nodes = new SortedList<string, (string, string)>();
        for (int i = 2; i < lines.Count(); i++)
        {
            var parts = lines[i]
                .Split(new[] { " = (", ", ", ")" }, StringSplitOptions.RemoveEmptyEntries);

            var from = parts[0];
            var left = parts[1];
            var right = parts[2];

            nodes.Add(from, (left, right));
        }

        return nodes;
    }

    public object Part2(string input)
    {
        var directions = ParseDirectionPart1(input);
        var nodes = ParseNodesPart1(input);
        var startNodes = findStartNodes(nodes);
        var steps = 0;
        while (!TakeStep(directions[steps % directions.Length], startNodes, nodes))
        {
            steps++;
        }
        return steps + 1;
    }

    // change all the current, to new current as a side effect
    internal static bool TakeStep(
        char direction,
        List<string> allCurrentNodes,
        SortedList<string, (string, string)> nodes
    )
    {
        string nextNode;
        var atEnd = 0;
        for (int i = 0; i < allCurrentNodes.Count(); i++)
        {
            nextNode = TakeStepOnePath(direction, allCurrentNodes[i], nodes);
            if (nextNode.EndsWith('Z'))
            {
                atEnd++;
            }
            allCurrentNodes[i] = nextNode;
        }
        if (atEnd == allCurrentNodes.Count())
        {
            return true;
        }

        return false;
    }

    internal static string TakeStepOnePath(
        char direction,
        string currentNode,
        SortedList<string, (string, string)> nodes
    )
    {
        string nextNode;
        if (direction == 'L')
        {
            nextNode = nodes[currentNode].Item1;
        }
        else
        {
            nextNode = nodes[currentNode].Item2;
        }
        return nextNode;
    }

    internal static List<string> findStartNodes(SortedList<string, (string, string)> nodes)
    {
        return nodes.Keys.Where(node => node.EndsWith('A')).ToList();
    }
}
