using System;

[Serializable]
public class SettingsData
{
    public int rounds;
    public string p1Name;
    public string p2Name;
    
    public SettingsData(DecreaseIncreaseField decreaseIncreaseField, string p1Name, string p2Name)
    {
        rounds = decreaseIncreaseField.Value;
        this.p1Name = p1Name;
        this.p2Name = p2Name;
    }
}
