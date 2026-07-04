using AoC.Common;

namespace AoC.Tests;

/// <summary>Loads puzzle files for a given day. Thin wrapper over Common's file locator.</summary>
public static class Load
{
    public static string Sample(int year, int day) => Inputs.Sample(year, day);

    public static string Input(int year, int day) => Inputs.Real(year, day);
}
