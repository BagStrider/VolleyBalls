using System;
using UnityEngine;

[Serializable]
public class Score
{
    public string player1Name;
    public string player2Name;
    public int player1Score;
    public int player2Score;

    public Score(string player1Name, string player2Name, int player1Score, int player2Score)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
        this.player1Score = player1Score;
        this.player2Score = player2Score;
    }
}
