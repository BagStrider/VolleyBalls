using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<Score> scores;

    public void Awake()
    {
        scores = new List<Score>();
    }

    public void AddScore(Score score)
    {
        scores.Add(score);
    }
}
