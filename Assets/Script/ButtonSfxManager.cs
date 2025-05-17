using UnityEngine;

public class ButtonSfxManager : MonoBehaviour
{
    public GameObject ButtonSfx; 

    public void ShowButtonSfx()
    {
        Time.timeScale = 0f;
        ButtonSfx.SetActive(true);
    }

    public void HideButtonSfx()
    {
        Time.timeScale = 1f;
        ButtonSfx.SetActive(false);
    }
}
