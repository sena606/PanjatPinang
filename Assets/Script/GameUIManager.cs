using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    public GameObject gameOverPanel;  // Panel Game Over
    public TextMeshProUGUI scoreText; // Text untuk menampilkan skor
    public TextMeshProUGUI highScoreText; // Text untuk menampilkan high score
    public GameObject retryButton; // Tombol Retry
    public GameObject homeButton;  // Tombol Home

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

    // Fungsi untuk menampilkan Panel Game Over dan mengupdate skor
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);  // Menampilkan panel Game Over

        int currentScore = ScoreManager.Instance.score;  // Ambil score dari ScoreManager
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);  // Ambil highscore dari PlayerPrefs

        // Menampilkan skor dan high score
        scoreText.text = "Score: " + currentScore.ToString();
        highScoreText.text = "High Score: " + currentHighScore.ToString();

        // Cek jika Score lebih tinggi dari highScore
        if (currentScore > currentHighScore)
        {
            currentHighScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentHighScore);  // Simpan high score ke PlayerPrefs
            PlayerPrefs.Save();  // Simpan perubahan
        }

        retryButton.SetActive(true);   // Menampilkan tombol Retry
        homeButton.SetActive(true);    // Menampilkan tombol Home

        Time.timeScale = 0f;
    }

    // Fungsi untuk tombol Retry
    public void OnRetryButtonClicked()
    {
        Time.timeScale = 1f;  // Restart waktu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi untuk tombol Home
    public void OnHomeButtonClicked()
    {
        Time.timeScale = 1f;
       SceneManager.LoadScene("MainMenu");  // Contoh jika ada scene MainMenu
    }
}
