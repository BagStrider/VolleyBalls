using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryMatchMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        ScoreManager.SaveScore();
        SceneManager.LoadScene(0);
    }
}
