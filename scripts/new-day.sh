#!/usr/bin/env bash
# Scaffolds a new Advent of Code day: solution folder, sample/input files, test file.
# Usage: ./scripts/new-day.sh YEAR DAY     e.g. ./scripts/new-day.sh 2024 7
set -euo pipefail

if [[ $# -ne 2 ]]; then
  echo "Usage: $0 YEAR DAY"
  exit 1
fi

YEAR=$1
DAY_RAW=$2

if ! [[ "$YEAR" =~ ^[0-9]{4}$ ]]; then
  echo "YEAR must be four digits, got: $YEAR"
  exit 1
fi

if ! [[ "$DAY_RAW" =~ ^[0-9]{1,2}$ ]] || (( 10#$DAY_RAW < 1 || 10#$DAY_RAW > 25 )); then
  echo "DAY must be 1 to 25, got: $DAY_RAW"
  exit 1
fi

DAY_NUM=$((10#$DAY_RAW))
DAY=$(printf "%02d" "$DAY_NUM")

ROOT="$(cd "$(dirname "$0")/.." && pwd)"
SOLUTION_DIR="$ROOT/src/Solutions/Year$YEAR/Day$DAY"
TEST_DIR="$ROOT/tests/AoC.Tests/Year$YEAR"
TEST_FILE="$TEST_DIR/Day${DAY}Tests.cs"

if [[ -e "$SOLUTION_DIR" ]]; then
  echo "Refusing to overwrite existing $SOLUTION_DIR"
  exit 1
fi
if [[ -e "$TEST_FILE" ]]; then
  echo "Refusing to overwrite existing $TEST_FILE"
  exit 1
fi

mkdir -p "$SOLUTION_DIR" "$TEST_DIR"

cat > "$SOLUTION_DIR/Solution.cs" <<EOF
using AoC.Common;

namespace AoC.Solutions.Year$YEAR.Day$DAY;

public class Solution : ISolution
{
    public object Part1(string input)
    {
        throw new NotImplementedException();
    }

    public object Part2(string input)
    {
        throw new NotImplementedException();
    }
}
EOF

: > "$SOLUTION_DIR/sample.txt"
: > "$SOLUTION_DIR/input.txt"

cat > "$TEST_FILE" <<EOF
using AoC.Solutions;
using Xunit;
using Solution = AoC.Solutions.Year$YEAR.Day$DAY.Solution;

namespace AoC.Tests.Year$YEAR;

[Trait("Day", "${YEAR}_${DAY}")]
public class Day${DAY}Tests
{
    private readonly ISolution _solution = new Solution();

    [Fact]
    public void Part1_Sample() =>
        Assert.Equal("EXPECTED", _solution.Part1(Load.Sample($YEAR, $DAY_NUM)).ToString());

    [Fact]
    public void Part2_Sample() =>
        Assert.Equal("EXPECTED", _solution.Part2(Load.Sample($YEAR, $DAY_NUM)).ToString());

    [Fact(Skip = "Fill in confirmed real answer, then remove Skip")]
    public void Part1_Real() =>
        Assert.Equal("REAL_ANSWER", _solution.Part1(Load.Input($YEAR, $DAY_NUM)).ToString());

    [Fact(Skip = "Fill in confirmed real answer, then remove Skip")]
    public void Part2_Real() =>
        Assert.Equal("REAL_ANSWER", _solution.Part2(Load.Input($YEAR, $DAY_NUM)).ToString());
}
EOF

echo "Scaffolded $YEAR day $DAY."
echo
echo "  1. Paste the puzzle sample into:  src/Solutions/Year$YEAR/Day$DAY/sample.txt"
echo "  2. Paste your real input into:    src/Solutions/Year$YEAR/Day$DAY/input.txt"
echo "  3. Put the sample answers into:   tests/AoC.Tests/Year$YEAR/Day${DAY}Tests.cs (replace EXPECTED)"
echo
echo "  Live test loop:  dotnet watch --project tests/AoC.Tests test --filter \"Day=${YEAR}_${DAY}\""
echo "  Real answers:    dotnet run --project src/Runner $YEAR $DAY_NUM"
