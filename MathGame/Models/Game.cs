using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Models;

internal class Game
{
    public Game(DateTime startTime, IOperation operation)
    {
        StartTime = startTime;
        Operation = operation;
    }

    public DateTime StartTime { get; }
    public IOperation Operation { get; }
    public IList<Round> Rounds { get; } = new List<Round>();
}
