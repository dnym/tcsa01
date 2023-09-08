﻿using MathGame.Models;
using MathGame.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame;

internal class Gameplay
{
    private const int _roundsPerGame = 5;
    private readonly RoundGenerator _roundGenerator = new(new Tuple<int, int>(-100, 100), new Tuple<int, int>(-100, 100), new Tuple<int, int>(-100, 100));
    private readonly IOperation _addition = new Addition();

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"Math Game
=========
1. Play [A]ddition
6. [Q]uit

Press a number or letter key to choose.");
            var selection = Console.ReadKey(true);
            switch (selection.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.A:
                    Play(_addition);
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.Q:
                    return;
            }
        }
    }

    private void Play(IOperation operation)
    {
        Game game = new(DateTime.UtcNow, operation);
        for (int i = 0; i < _roundsPerGame; i++)
        {
            string header = operation.DisplayName + "\n" + new string('=', operation.DisplayName.Length);
            Console.Clear();
            var (a, b, result) = _roundGenerator.GenerateQuestion(operation);
            string? response = null;
            while (response == null)
            {
                Console.Write("{0}\n\nRound {1}/{2}: What is {3}? ", header, i+1, _roundsPerGame, string.Format(operation.DisplayPattern, a, b));
                response = Console.ReadLine();
                if (int.TryParse(response, out int responseInt))
                {
                    if (responseInt == result)
                    {
                        Console.WriteLine("\nCorrect!");
                    }
                    else
                    {
                        Console.WriteLine($"\nThe correct answer is {result}.");
                    }
                    game.Rounds.Add(new Round(operation, a, b, responseInt));
                    if (i == _roundsPerGame - 1)
                    {
                        Console.WriteLine("\nGame over! You scored {0} out of {1}.",
                            game.Rounds.Count(r => r.GivenAnswer == r.Operation.Calculate(r.FirstNumber, r.SecondNumber)),
                            game.Rounds.Count);
                    }
                    Console.WriteLine("\nPress any key to continue\nor q to quit to menu.");
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Q)
                    {
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    response = null;
                }
            }
        }
        History.Games.Add(game);
    }
}