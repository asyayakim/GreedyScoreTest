using System.Diagnostics;

namespace GreedyScoreTest;
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] dice = new int[5];
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i] = random.Next(1, 6);
        }
        Console.WriteLine("Dice: " + string.Join(", ", dice));
        Stopwatch stopwatch = Stopwatch.StartNew();
        int score = GreedScorer.CalculateScore(dice);
        stopwatch.Stop();
        Console.WriteLine("Score= " + score);
        Console.WriteLine("Execution Time: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}