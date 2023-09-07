using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Models;

internal class Round
{
    public Round(IOperation operation, int firstNumber, int secondNumber, int givenAnswer)
    {
        Operation = operation;
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
        GivenAnswer = givenAnswer;
    }

    public IOperation Operation { get; }
    public int FirstNumber { get; }
    public int SecondNumber { get; }
    public int GivenAnswer { get; }
}
