using UnityEngine;

public class ButtonBgmManager : MonoBehaviour
{
    public GameObject ButtonBgm; 

    public void ShowButtonBgm()
    {
        Time.timeScale = 0f;
        ButtonBgm.SetActive(true);
    }

    public void HideButtonBgm()
    {
        Time.timeScale = 1f;
        ButtonBgm.SetActive(false);
    }
}
