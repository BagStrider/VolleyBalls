using System;

[Serializable]
public class SettingsData
{
    public int rounds;
    public string p1Name;
    public string p2Name;
    
    public SettingsData(DecreaseIncreaseField decreaseIncreaseField)
    {
        rounds = decreaseIncreaseField.Value;
    }
}
