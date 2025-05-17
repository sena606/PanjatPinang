using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.RestartBGM();
        }

        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.RestartBGM();
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
