using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private DecreaseIncreaseField _decreaseIncreaseField;
    [SerializeField] private TMP_InputField _p1Name;
    [SerializeField] private TMP_InputField _p2Name;

    public void Awake()
    {
        SaveSystem.Load();
        _p1Name.text = SaveSystem.settings.p1Name;
        _p2Name.text = SaveSystem.settings.p2Name;
       
    }
    public void LoadMainMenu()
    {
        SettingsData settings = new SettingsData(_decreaseIncreaseField, _p1Name.text, _p2Name.text);
        SaveSystem.settings = settings;
        SaveSystem.Save();
        SceneManager.LoadScene(0);
    }
}
