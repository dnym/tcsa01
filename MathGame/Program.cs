namespace MathGame;

internal static class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        var game = new Gameplay();
        while (true)
        {
            game.Play();
        }
    }
}