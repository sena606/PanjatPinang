using UnityEngine;

public class RetryManager : MonoBehaviour
{
    public GameObject Retry; 

    public void ShowRetry()
    {
        Time.timeScale = 0f;
        Retry.SetActive(true);
    }

    public void HideRetry()
    {
        Time.timeScale = 1f;
        Retry.SetActive(false);
    }
}
