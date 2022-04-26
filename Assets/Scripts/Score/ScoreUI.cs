using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]private RowUI _rowUI;

    public void Awake()
    {
        ScoreManager.Initialize();
        foreach(Score score in ScoreManager.ScoreCollection.Scores)
        {   
            var row = Instantiate(_rowUI, transform).GetComponent<RowUI>();
            row.player1Name.text = score.Player1Name;
            row.player2Name.text = score.Player2Name;
            row.player1Score.text = score.Player1Score.ToString();
            row.player2Score.text = score.Player2Score.ToString();
        }
    }
}
