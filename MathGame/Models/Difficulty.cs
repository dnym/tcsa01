namespace MathGame.Models;

internal class Difficulty
{
    public readonly int LowerLimitA;
    public readonly int UpperLimitExclusiveA;
    public readonly int LowerLimitB;
    public readonly int UpperLimitExclusiveB;
    public readonly int LowerLimitResult;
    public readonly int UpperLimitExclusiveResult;

    /// <summary>
    /// <para>Creates a new difficulty level for used when generating problems on the form f(A, B) = Result.</para>
    /// <para>Note that the limits are inclusive on the lower end and exclusive on the upper end, i.e.:</para>
    /// <para>A ∈ [lowerLimitA, upperLimitExclusiveA)</para>
    /// <para>B ∈ [lowerLimitB, upperLimitExclusiveB)</para>
    /// <para>Result ∈ [lowerLimitResult, upperLimitExclusiveResult)</para>
    /// </summary>
    public Difficulty(int lowerLimitA, int upperLimitExclusiveA, int lowerLimitB, int upperLimitExclusiveB, int lowerLimitResult, int upperLimitExclusiveResult)
    {
        LowerLimitA = lowerLimitA;
        UpperLimitExclusiveA = upperLimitExclusiveA;
        LowerLimitB = lowerLimitB;
        UpperLimitExclusiveB = upperLimitExclusiveB;
        LowerLimitResult = lowerLimitResult;
        UpperLimitExclusiveResult = upperLimitExclusiveResult;
    }
}
