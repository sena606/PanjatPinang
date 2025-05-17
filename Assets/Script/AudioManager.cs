using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip gameBGM;   // BGM Game biasa
    public AudioClip gameOverBGM;  // BGM Game Over

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Fungsi untuk memulai ulang BGM
    public void RestartBGM()
    {
        if (bgmSource != null && bgmSource.clip != null)
        {
            bgmSource.Stop();
            bgmSource.time = 0f;
            bgmSource.Play();
        }
    }

    // Fungsi untuk memainkan BGM Game Over
    public void PlayGameOverBGM()
    {
        if (bgmSource != null && gameOverBGM != null)
        {
            bgmSource.Stop();
            bgmSource.clip = gameOverBGM;  // Ganti ke BGM Game Over
            bgmSource.time = 0f;
            bgmSource.Play();
        }
    }
}
