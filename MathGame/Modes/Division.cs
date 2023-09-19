using MathGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Modes
{
    internal class Division : IOperation
    {
        public string DisplayName => "Division";

        public string DisplayPattern => "{0} / {1}";

        public int Calculate(int a, int b)
        {
            return a / b;
        }

        public Tuple<int, int> DecomposeResult(Random rnd, int requiredResult, Tuple<int, int> domainA, Tuple<int, int> domainB)
        {
            var (minA, maxA) = domainA;
            var (minB, maxB) = domainB;
            // Compensate for exclusive end.
            maxA--;
            maxB--;
            // Remove zero from domain by shrinking.
            if (minB == 0)
            {
                minB++;
            }
            if (maxB == 0)
            {
                maxB--;
            }

            var minQ = 0;
            var maxQ = 0;

            if (requiredResult % 2 == 0)
            {
                // Calculate the possible range of quotients.
                if (minA >= 0 && minB > 0)
                {
                    // A non-negative, B positive.
                    minQ = minA / maxB;
                    maxQ = maxA / minB;
                }
                else if (maxA < 0 && maxB < 0)
                {
                    // Both negative.
                    minQ = maxA / minB;
                    maxQ = minA / maxB;
                }
                else if (minA >= 0 && maxB < 0)
                {
                    // A non-negative, B negative.
                    minQ = maxA / maxB;
                    maxQ = minA / minB;
                }
                else if (maxA < 0 && minB > 0)
                {
                    // A negative, B positive.
                    minQ = minA / minB;
                    maxQ = maxA / maxB;
                }
                else
                {
                    // One or both are mixed.
                    if (minA >= 0)
                    {
                        // If A is non-negative, B must be mixed and contains -1 and 1.
                        minQ = maxA / -1;
                        maxQ = maxA / 1;
                    }
                    else if (maxA < 0)
                    {
                        // If A is negative, B must be mixed and contains -1 and 1.
                        minQ = minA / -1;
                        maxQ = minA / 1;
                    }
                    else if (minB > 0)
                    {
                        minQ = minA / minB;
                        maxQ = maxA / minB;
                    }
                    else if (maxB < 0)
                    {
                        minQ = maxA / maxB;
                        maxQ = minA / maxB;
                    }
                    else
                    {
                        // Both are mixed, and B must contain both -1 and 1.
                        var max = Math.Max(Math.Abs(minA), Math.Abs(maxA));
                        minQ = max / -1;
                        maxQ = max / 1;
                    }
                }
            }

            if (requiredResult % 2 != 0 || requiredResult < minQ || maxQ < requiredResult)
            {
                throw new ArgumentException("The required result cannot be decomposed into two numbers within the given domains.");
            }

            var pairs = new List<Tuple<int, int>>();
            for (int b = minB; b <= maxB; b++)
            {
                if (b == 0)
                {
                    continue;
                }
                var a = requiredResult * b;
                if (a >= minA && a <= maxA)
                {
                    pairs.Add(new Tuple<int, int>(a, b));
                }
            }

            return pairs[rnd.Next(pairs.Count)];
        }
    }
}
