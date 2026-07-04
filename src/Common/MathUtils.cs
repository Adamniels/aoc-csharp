namespace AoC.Common;

public static class MathUtils
{
    public static long Gcd(long a, long b)
    {
        while (b != 0)
            (a, b) = (b, a % b);
        return Math.Abs(a);
    }

    public static long Lcm(long a, long b) => a / Gcd(a, b) * b;

    public static long Lcm(IEnumerable<long> values) => values.Aggregate(1L, Lcm);
}
