using System.Diagnostics;
using AoC.Common;
using AoC.Solutions;

if (args.Length != 2 || !int.TryParse(args[0], out var year) || !int.TryParse(args[1], out var day))
{
    Console.Error.WriteLine("Usage: dotnet run --project src/Runner <year> <day>");
    return 1;
}

var typeName = $"AoC.Solutions.Year{year}.Day{day:D2}.Solution";
var type = typeof(ISolution).Assembly.GetType(typeName);
if (type is null)
{
    Console.Error.WriteLine($"No solution found for {year} day {day} (looked for {typeName}).");
    Console.Error.WriteLine($"Scaffold it with: ./scripts/new-day.sh {year} {day}");
    return 1;
}

var solution = (ISolution)Activator.CreateInstance(type)!;

string input;
try
{
    input = Inputs.Real(year, day);
}
catch (Exception e) when (e is FileNotFoundException or InvalidOperationException)
{
    Console.Error.WriteLine(e.Message);
    return 1;
}

Console.WriteLine($"{year} Day {day:D2}");
RunPart("Part 1", () => solution.Part1(input));
RunPart("Part 2", () => solution.Part2(input));
return 0;

static void RunPart(string label, Func<object> part)
{
    var sw = Stopwatch.StartNew();
    object result;
    try
    {
        result = part();
    }
    catch (NotImplementedException)
    {
        Console.WriteLine($"{label}: not implemented yet");
        return;
    }

    sw.Stop();
    Console.WriteLine($"{label}: {result}  ({sw.ElapsedMilliseconds}ms)");
}
