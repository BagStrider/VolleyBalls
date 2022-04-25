using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]private RowUI rowUI;

    public void Awake()
    {
        ScoreManager.Initialize();
        ScoreManager.AddScore(new Score("1", "2", 12, 13));
        foreach(Score score in ScoreManager.Scores)
        {   
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.player1Name.text = score.Player1Name;
            row.player2Name.text = score.Player2Name;
            row.player1Score.text = score.Player1Score.ToString();
            row.player2Score.text = score.Player2Score.ToString();
        }
    }
}
