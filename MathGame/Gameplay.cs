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
    private readonly IList<Game> _games = new List<Game>();
    private readonly IOperation _addition = new Addition();
    private readonly IOperation _subtraction = new Subtraction();
    private readonly IOperation _multiplication = new Multiplication();

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"Math Game
=========

1. Play [A]ddition
2. Play [S]ubtraction
3. Play [M]ultiplication
5. Show [H]istory
6. [Q]uit

Press a number or letter key to choose.");
            var selection = Console.ReadKey(true);
            switch (selection.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                case ConsoleKey.A:
                    Play(_addition);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                case ConsoleKey.S:
                    Play(_subtraction);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                case ConsoleKey.M:
                    Play(_multiplication);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                case ConsoleKey.H:
                    ShowHistory();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
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
            var (a, b, result) = _roundGenerator.GenerateQuestion(operation);
            string? response = null;
            string warning = "";
            while (response == null)
            {
                Console.Clear();
                Console.Write("{0}\n\nRound {1}/{2}: What is {3}? ", header, i+1, _roundsPerGame, string.Format(operation.DisplayPattern, a, b));
                if (warning != "")
                {
                    var currentCursorHorizontalPosition = Console.CursorLeft;
                    var currentCursorVerticalPosition = Console.CursorTop;
                    Console.WriteLine(warning);
                    Console.SetCursorPosition(currentCursorHorizontalPosition, currentCursorVerticalPosition);
                }
                response = Console.ReadLine();
                if (int.TryParse(response, out int responseInt))
                {
                    warning = "";
                    {
                        // This is a hack to clear the the warning.
                        var currentCursorHorizontalPosition = Console.CursorLeft;
                        var currentCursorVerticalPosition = Console.CursorTop;
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(currentCursorHorizontalPosition, currentCursorVerticalPosition);
                    }
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
                        Console.WriteLine("\nPress any key to continue.");
                    }
                    else
                    {
                        Console.WriteLine("\nPress any key to continue\nor q to quit to menu.");
                    }
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Q)
                    {
                        return;
                    }
                }
                else
                {
                    if (string.Equals(response?.Trim(), "q", StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                    warning = "\n\nPlease enter a number\nor q to quit to menu.";
                    response = null;
                }
            }
        }
        _games.Add(game);
    }

    private void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("History\n=======\n");
        for (int i = 0; i < _games.Count; i++)
        {
            var game = _games[i];
            var time = game.StartTime.ToString("g");
            int correctRounds = game.Rounds.Count(r => r.GivenAnswer == r.Operation.Calculate(r.FirstNumber, r.SecondNumber));
            int totalRounds = game.Rounds.Count;
            Console.WriteLine("[{0}] {1} ({2}/{3} correct)", time, game.Operation.DisplayName, correctRounds, totalRounds);
            for (int j = 0; j < game.Rounds.Count; j++)
            {
                var round = game.Rounds[j];
                var a = round.FirstNumber;
                var b = round.SecondNumber;
                var expectedAnswer = round.Operation.Calculate(round.FirstNumber, round.SecondNumber);
                var formatted = string.Format(round.Operation.DisplayPattern, a, b);
                if (round.GivenAnswer == expectedAnswer)
                {
                    Console.WriteLine("  {0}) {1}?\tGot {2}.", j+1, formatted, round.GivenAnswer);
                }
                else
                {
                    Console.WriteLine("  {0}) {1}?\tGot {2}, expected {3}.", j+1, formatted, round.GivenAnswer, expectedAnswer);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey(true);
    }
}
