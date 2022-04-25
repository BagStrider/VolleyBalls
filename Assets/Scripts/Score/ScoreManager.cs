using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<Score> Scores { get; private set; }

    public void Awake()
    {
        string json = PlayerPrefs.GetString("scores", "{}");

        Scores = JsonUtility.FromJson<List<Score>>(json);
    }

    public void AddScore(Score score)
    {
        Scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        string json = JsonUtility.ToJson(Scores);
        PlayerPrefs.SetString("scores", json);
    }
}
