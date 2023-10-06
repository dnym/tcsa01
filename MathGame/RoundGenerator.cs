using MathGame.Models;

namespace MathGame;

internal class RoundGenerator
{
    private readonly Random _random = new();
    private readonly Difficulty _difficulty;

    public RoundGenerator(Difficulty difficulty)
    {
        _difficulty = difficulty;
    }

    public Tuple<int, int, int> GenerateQuestion(IOperation operation)
    {
        int result = _random.Next(_difficulty.LowerLimitResult, _difficulty.UpperLimitExclusiveResult + 1);
        Tuple<int, int>? decomposedResult = null;
        while (decomposedResult == null)
        {
            // Note: bad numbers may lead to an infinite loop. E.g. addition for A and B in [0, 2) = {0, 1} can never produce a result in [4, 6) = {4, 5}.
            // TODO: Handle this case. Perhaps set a limit on the number of attempts?
            decomposedResult = operation.DecomposeResult(_random, result,
                _difficulty.LowerLimitA, _difficulty.UpperLimitExclusiveA,
                _difficulty.LowerLimitB, _difficulty.UpperLimitExclusiveB);
        }
        return new Tuple<int, int, int>(decomposedResult.Item1, decomposedResult.Item2, result);
    }
}
