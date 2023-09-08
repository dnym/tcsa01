using MathGame.Models;
using MathGame.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame;

internal class Gameplay
{
    private readonly RoundGenerator _roundGenerator = new(new Tuple<int, int>(-100, 100), new Tuple<int, int>(-100, 100), new Tuple<int, int>(-100, 100));
    private readonly IOperation _addition = new Addition();

    public void Play()
    {
        Console.Clear();
        var (a, b, result) = _roundGenerator.GenerateQuestion(_addition);
        string? response = null;
        while (response == null)
        {
            Console.Write("What is {0}? ", string.Format(_addition.DisplayPattern, a, b));
            response = Console.ReadLine();
            if (int.TryParse(response, out int responseInt))
            {
                if (responseInt == result)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect! The correct answer is {result}.");
                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey(true);
            }
            else
            {
                Console.Clear();
                response = null;
            }
        }
    }
}
