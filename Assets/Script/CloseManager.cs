using UnityEngine;

public class CloseManager : MonoBehaviour
{
    public GameObject Close; 

    public void ShowClose()
    {
        Time.timeScale = 0f;
        Close.SetActive(true);
    }

    public void HideClose()
    {
        Time.timeScale = 1f;
        Close.SetActive(false);
    }
}
