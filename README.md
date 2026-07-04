# Advent of Code

One C# solution for every year and every day, test driven, one day at a time. Days are independent and discovered by convention, so there is no central registry: any year, any day, any order.

Built on .NET 10 (C# 14) with xUnit. Four projects: `Common` (parsing and grid helpers), `Solutions` (the day code), `Runner` (prints real answers), and `AoC.Tests`.

## Doing a day

Scaffold it:

```
./scripts/new-day.sh 2024 1
```

That creates `src/Solutions/Year2024/Day01/` with an empty `Solution.cs`, `sample.txt`, and `input.txt`, plus the prewired test file `tests/AoC.Tests/Year2024/Day01Tests.cs`. Then:

1. Paste the puzzle's sample into `sample.txt` and your real input into `input.txt`.
2. Put the sample's known answers into the two sample assertions (replace `EXPECTED`).
3. Start the live loop and write code until green:

```
dotnet watch --project tests/AoC.Tests test --filter "Day=2024_01"
```

or run this for normal tests

```
dotnet test --filter "Day=2024_01"
```

4. Once the samples pass, see your real answers:

```
dotnet run --project src/Runner 2024 1
```

5. Submit on adventofcode.com. When confirmed, paste the answer into the `Part1_Real` / `Part2_Real` assertions and remove the `Skip`. All four tests now pass and act as permanent regression guards.

## Test shape

Every day has four tests tagged with a `Day=YYYY_DD` trait. The two sample tests are the red green loop while solving. The two real tests start skipped so a fresh day never blocks the suite; they get locked in only after adventofcode.com confirms the answer.

Run one day: `dotnet test --filter "Day=2024_01"`. Run everything (rare, after refactoring Common): `dotnet test`.

## How tests find puzzle files

`Load.Sample(year, day)` and `Load.Input(year, day)` resolve files by walking up from the build output directory to the repo root (the folder containing `AoC.sln`) and reading straight from `src/Solutions/YearYYYY/DayDD/`. No copy-to-output wiring, and pasting into `input.txt` takes effect immediately, no rebuild needed.

## Inputs and git

`sample.txt` files are committed (they come from the public problem text). `input.txt` files are gitignored, per Advent of Code's request not to republish puzzle inputs. On a fresh clone, real inputs are absent by design: paste them back in from your AoC account, or leave them out and rely on the sample tests (the real tests will fail with a clear "missing input.txt" message).

## Layout

```
AoC.sln
Directory.Build.props        net10.0 + C# 14 for every project
scripts/new-day.sh           day scaffolder
src/Common/                  InputParser, Grid, MathUtils, Inputs (file locator)
src/Solutions/               ISolution + YearYYYY/DayDD/Solution.cs, sample.txt, input.txt
src/Runner/                  loads a day by reflection, prints both parts with timing
tests/AoC.Tests/             TestBase (Load helper) + YearYYYY/DayDDTests.cs
```
