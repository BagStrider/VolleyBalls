using System;
using UnityEngine;

[Serializable]
public class Score
{
    public string Player1Name { get; private set; }
    public string Player2Name { get; private set; }
    public int Player1Score { get; private set; }
    public int Player2Score { get; private set; }

    public Score(string player1Name, string player2Name, int player1Score, int player2Score)
    {
        Player1Name = player1Name;
        Player2Name = player2Name;
        Player1Score = player1Score;
        Player2Score = player2Score;
    }
}
