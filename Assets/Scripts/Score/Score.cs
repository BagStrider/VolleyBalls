using System;

[Serializable]
public class Score
{
    public string Player1Name;
    public string Player2Name;
    public int Player1Score;
    public int Player2Score;

    public Score(string player1Name, string player2Name, int player1Score, int player2Score)
    {
        Player1Name = player1Name;
        Player2Name = player2Name;
        Player1Score = player1Score;
        Player2Score = player2Score;
    }   

    public override string ToString()
    {
        return $"{Player1Name} {Player2Name} {Player1Score} {Player2Score}";
    }
}