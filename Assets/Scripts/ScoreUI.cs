using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;


    public void Start()
    {
        foreach(Score score in scoreManager.scores)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.player1Name.text = score.player1Name;
            row.player2Name.text = score.player2Name;
            row.player1Score.text = score.player1Score.ToString();
            row.player2Score.text = score.player2Score.ToString();
        }
    }
}
