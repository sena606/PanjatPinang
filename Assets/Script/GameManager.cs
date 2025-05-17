using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI References")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI Score;     // Menampilkan skor
    public TextMeshProUGUI HighScore; // Menampilkan high score

    // Menambahkan referensi untuk tombol Home
    public GameObject homeButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);  // memastikan panel gameover tidak tampil

        // Memastikan tombol Home dimulai dengan status tidak terlihat
        if (homeButton != null)
            homeButton.SetActive(false); 
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);   // Tampilkan panel GameOver
            Time.timeScale = 0f;             // Stop waktu (freeze game)
        }

        // Ambil score dari ScoreManager
        int currentScore = ScoreManager.Instance.score;

        // Ambil high score dari PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Periksa dan simpan high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);  // Simpan high score
            PlayerPrefs.Save();
        }

        // Update teks Score dan HighScore
        if (Score != null)
            Score.text = currentScore.ToString();   // Menampilkan score

        if (HighScore != null)
            HighScore.text = highScore.ToString();  // Menampilkan high score

        // Menampilkan tombol Home
        if (homeButton != null)
            homeButton.SetActive(true);

        // Ganti BGM dengan Game Over BGM
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayGameOverBGM();
        }
    }

    public void Retry()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.RestartBGM();  // Kembalikan BGM ke normal

        Time.timeScale = 1f;  // Restart waktu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.RestartBGM();  // Kembalikan BGM ke normal

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
