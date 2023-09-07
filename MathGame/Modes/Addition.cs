using MathGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathGame.Models.IOperation;

namespace MathGame.Modes;

internal class Addition : IOperation
{
    public string DisplayName => "Addition";

    public string DisplayPattern => "{0} + {1}";

    public int Calculate(int a, int b)
    {
        return a + b;
    }

    /// <summary>
    /// Randomly decomposes the required result into two numbers that can be used by the operation to get the result. The numbers must be within the given domains (exclusive end). May throw an <see cref="ArgumentException"/> if the result cannot be decomposed.
    /// </summary>
    public Tuple<int, int> DecomposeResult(Random rnd, int requiredResult, Tuple<int, int> domainA, Tuple<int, int> domainB)
    {
        if (requiredResult < domainA.Item1 + domainB.Item1 || domainA.Item2 + domainB.Item2 < requiredResult)
        {
            throw new ArgumentException("The required result cannot be decomposed into two numbers within the given domains.");
        }

        // Find A within a "subdomain".
        int minA = Math.Max(domainA.Item1, requiredResult - domainB.Item2);
        int maxA = Math.Min(domainA.Item2, requiredResult - domainB.Item1);
        int a = rnd.Next(minA, maxA + 1);

        int b = requiredResult - a;

        return new Tuple<int, int>(a, b);
    }
}
