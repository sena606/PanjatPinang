using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void RestartGame()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.RestartBGM();
        }

        SceneManager.LoadScene("GameScene");

        Time.timeScale = 1f;
    }
}
