using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static List<Score> Scores { get; private set; }

    public static void Initialize()
    {
        string json = PlayerPrefs.GetString("scores", "{}");
        Scores = JsonUtility.FromJson<List<Score>>(json);
    }

    public static void AddScore(Score score)
    {
        Initialize();
        Scores.Add(score);
        SaveScore();
    }

    public static void SaveScore()
    {
        string json = JsonUtility.ToJson(Scores);
        PlayerPrefs.SetString("scores", json);
    }
}
