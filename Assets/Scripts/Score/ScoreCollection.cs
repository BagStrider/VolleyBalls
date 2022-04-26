using System;
using System.Collections.Generic;

[Serializable]
public class ScoreCollection
{
    public List<Score> Scores;

    public ScoreCollection()
    {
        Scores = new List<Score>();
    }
}
