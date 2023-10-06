using MathGame.Models;

namespace MathGame.Modes;

internal class Addition : IOperation
{
    public string DisplayName => "Addition";

    public string DisplayPattern => "{0} + {1}";

    public int Calculate(int a, int b)
    {
        return a + b;
    }

    public Tuple<int, int>? DecomposeResult(Random rnd, int requiredResult, int lowerLimitA, int upperLimitExclusiveA, int lowerLimitB, int upperLimitExclusiveB)
    {
        var (minA, maxA) = (lowerLimitA, upperLimitExclusiveA);
        var (minB, maxB) = (lowerLimitB, upperLimitExclusiveB);
        if (requiredResult < minA + minB || maxA + maxB < requiredResult)
        {
            // The required result cannot be decomposed into two numbers within the given limits.
            return null;
        }

        // Find A within a "subdomain".
        minA = Math.Max(minA, requiredResult - maxB);
        maxA = Math.Min(maxA, requiredResult - minB);
        int a = rnd.Next(minA, maxA + 1);

        int b = requiredResult - a;

        return new Tuple<int, int>(a, b);
    }
}
