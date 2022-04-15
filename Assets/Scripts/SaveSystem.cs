using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static SettingsData settings;
    public static string file = "GameSettings.txt";


    public static void Save()
    {
        string json = JsonUtility.ToJson(settings);
        WriteToFile(file, json);
        
    }

    private static void WriteToFile(string fileName, string json)
    {
        string path = Application.dataPath + "/" + file;
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.Write(json);
        }
    }

    private static string ReadFromFile(string fileName)
    {
        string path = Application.dataPath + "/" + file;
        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not found");
        }
        return null;
    }

    public static void Load()
    {
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, settings);
    }
}
