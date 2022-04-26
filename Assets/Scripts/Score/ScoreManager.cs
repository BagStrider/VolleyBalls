using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static ScoreCollection ScoreCollection;
    public static void Initialize()
    {
        string json = PlayerPrefs.GetString("scoreCollection", "{}");
        ScoreCollection = JsonUtility.FromJson<ScoreCollection>(json);
        if(ScoreCollection== null)
        {
            ScoreCollection = new ScoreCollection();
        }
    }

    public static void AddScore(Score score)
    {
        ScoreCollection.Scores.Add(score);
    }

    public static void SaveScore()
    {
        string json = JsonUtility.ToJson(ScoreCollection);  

        PlayerPrefs.SetString("scoreCollection", json);
    }
}
