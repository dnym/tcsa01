using MathGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame;

internal static class History
{
    public static IList<Game> Games { get; } = new List<Game>();
}
