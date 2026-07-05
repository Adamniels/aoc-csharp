namespace AoC.Common;

/// <summary>
/// Locates and reads sample.txt / input.txt for a given day by walking up from the
/// build output directory to the repo root (the directory containing AoC.sln), then
/// reading straight from the source tree. No csproj copy wiring needed, and pasting
/// into input.txt takes effect without a rebuild.
/// </summary>
public static class Inputs
{
    private static readonly Lazy<string> RepoRoot = new(FindRepoRoot);

    public static string Sample(int year, int day) => Read(year, day, "sample.txt");

    public static string Sample(int year, int day, string name) => Read(year, day, name);

    public static string Real(int year, int day) => Read(year, day, "input.txt");

    public static string PathFor(int year, int day, string fileName) =>
        Path.Combine(RepoRoot.Value, "src", "Solutions", $"Year{year}", $"Day{day:D2}", fileName);

    private static string Read(int year, int day, string fileName)
    {
        var path = PathFor(year, day, fileName);
        if (!File.Exists(path))
            throw new FileNotFoundException(
                $"Missing {fileName} for {year} day {day}. Expected it at: {path}");

        var text = File.ReadAllText(path);
        if (string.IsNullOrWhiteSpace(text))
            throw new InvalidOperationException(
                $"{path} is empty. Paste the puzzle text into it.");

        return text;
    }

    private static string FindRepoRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir is not null)
        {
            if (File.Exists(Path.Combine(dir.FullName, "AoC.sln")))
                return dir.FullName;
            dir = dir.Parent;
        }

        throw new InvalidOperationException(
            $"Could not find AoC.sln in any directory above {AppContext.BaseDirectory}");
    }
}
