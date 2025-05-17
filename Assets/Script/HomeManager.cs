using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public GameObject Home; 

    public void ShowHome()
    {
        Time.timeScale = 0f;
        Home.SetActive(true);
    }

    public void HideHome()
    {
        Time.timeScale = 1f;
        Home.SetActive(false);
    }
}
