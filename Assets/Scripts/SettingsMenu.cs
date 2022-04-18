using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private DecreaseIncreaseField _decreaseIncreaseField;
    [SerializeField] private TextMeshProUGUI _p1Name;
    [SerializeField] private TextMeshProUGUI _p2Name;
    public void LoadMainMenu()
    {
        SettingsData settings = new SettingsData(_decreaseIncreaseField, _p1Name.text, _p2Name.text);
        SaveSystem.settings = settings;
        SaveSystem.Save();
        SceneManager.LoadScene(0);
    }
}
