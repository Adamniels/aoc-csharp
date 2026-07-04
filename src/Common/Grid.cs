namespace AoC.Common;

public readonly record struct Point(int Row, int Col)
{
    public static Point operator +(Point a, Point b) => new(a.Row + b.Row, a.Col + b.Col);
    public static Point operator -(Point a, Point b) => new(a.Row - b.Row, a.Col - b.Col);
}

/// <summary>2D character grid with bounds checking and neighbor iteration.</summary>
public class Grid
{
    private readonly char[][] _cells;

    public int Height { get; }
    public int Width { get; }

    public Grid(string input)
    {
        _cells = InputParser.CharGrid(input);
        Height = _cells.Length;
        Width = Height == 0 ? 0 : _cells[0].Length;
    }

    public char this[Point p] => _cells[p.Row][p.Col];
    public char this[int row, int col] => _cells[row][col];

    public bool InBounds(Point p) =>
        p.Row >= 0 && p.Row < Height && p.Col >= 0 && p.Col < Width;

    public static readonly Point[] Directions4 =
        [new(-1, 0), new(1, 0), new(0, -1), new(0, 1)];

    public static readonly Point[] Directions8 =
        [new(-1, -1), new(-1, 0), new(-1, 1), new(0, -1), new(0, 1), new(1, -1), new(1, 0), new(1, 1)];

    /// <summary>Every point in the grid, row by row.</summary>
    public IEnumerable<Point> Points()
    {
        for (var r = 0; r < Height; r++)
            for (var c = 0; c < Width; c++)
                yield return new Point(r, c);
    }

    public IEnumerable<Point> Neighbors4(Point p) =>
        Directions4.Select(d => p + d).Where(InBounds);

    public IEnumerable<Point> Neighbors8(Point p) =>
        Directions8.Select(d => p + d).Where(InBounds);

    /// <summary>First point containing the given char, or null.</summary>
    public Point? Find(char value)
    {
        foreach (var p in Points())
            if (this[p] == value)
                return p;
        return null;
    }
}
