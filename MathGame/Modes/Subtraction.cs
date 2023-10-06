using MathGame.Models;

namespace MathGame.Modes;

internal class Subtraction : IOperation
{
    public string DisplayName => "Subtraction";

    public string DisplayPattern => "{0} - {1}";

    public int Calculate(int a, int b)
    {
        return a - b;
    }

    public Tuple<int, int>? DecomposeResult(Random rnd, int requiredResult, int lowerLimitA, int upperLimitExclusiveA, int lowerLimitB, int upperLimitExclusiveB)
    {
        var (minA, maxA) = (lowerLimitA, upperLimitExclusiveA);
        var (minB, maxB) = (lowerLimitB, upperLimitExclusiveB);
        if (requiredResult < minA - maxB || maxA - minB < requiredResult)
        {
            // The required result cannot be decomposed into two numbers within the given limits.
            return null;
        }

        // Find A within a "subdomain".
        minA = Math.Max(minA, requiredResult + minB);
        maxA = Math.Min(maxA, requiredResult + maxB);
        int a = rnd.Next(minA, maxA + 1);

        int b = a - requiredResult;

        return new Tuple<int, int>(a, b);
    }
}
