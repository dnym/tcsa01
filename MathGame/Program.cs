namespace MathGame;

internal static class Program
{
    static void Main()
    {
        var game = new Gameplay();
        while (true)
        {
            game.Play();
        }
    }
}