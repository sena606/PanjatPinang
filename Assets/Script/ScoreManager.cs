using UnityEngine;
using TMPro; // Jika pakai TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;
    public float scoreInterval = 2f; // Setiap 2 detik
    private float timer;

    public TextMeshProUGUI scoreText; // Ganti Text kalau pakai TMP

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
        UpdateScoreText();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= scoreInterval)
        {
            timer = 0f;
            IncreaseScore(1);  // Menambah score setiap interval
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
