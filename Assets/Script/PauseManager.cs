using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel; 

    public void ShowPause()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void HidePause()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }
}
