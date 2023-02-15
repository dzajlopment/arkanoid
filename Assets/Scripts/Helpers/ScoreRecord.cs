public sealed class ScoreRecord
{
    public string Player { get; }
    public int Score { get; }
    
    public ScoreRecord(string player, int score)
    {
        Player = player;
        Score = score;
    }
}
