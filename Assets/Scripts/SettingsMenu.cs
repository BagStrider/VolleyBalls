using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private DecreaseIncreaseField _decreaseIncreaseField;
    public void LoadMainMenu()
    {
        SettingsData settings = new SettingsData(_decreaseIncreaseField);
        SaveSystem.settings = settings;
        SaveSystem.Save();
        SceneManager.LoadScene(0);
    }


}
