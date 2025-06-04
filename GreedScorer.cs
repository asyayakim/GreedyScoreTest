using BenchmarkDotNet.Attributes;

namespace GreedyScoreTest;

[MemoryDiagnoser]
public static class GreedScorer
{
    public static int CalculateScore(int[] dice)
    { 
        var counts = dice.
            GroupBy(die => die).
            ToDictionary(g => g.Key, g => g.
                Count());
        int score = 0;
        foreach (var (num, count) in counts)
        {
            int triplets = count / 3;
            int leftNumbers = count % 3;
            if (triplets > 0)
            {
                score += triplets * (num == 1 ? 1000 : num * 100);
            }
            if (num == 1)
                score += leftNumbers * 100;
            else if (num == 5)
                score += leftNumbers * 50;
        }
        return score;
    }
    [Benchmark]
    public static void BenchMark() => CalculateScore([1, 1, 1, 3, 1]);
}
