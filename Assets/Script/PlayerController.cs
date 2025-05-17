using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;          
    public float horizontalOffset = 0.5f; 

    private Rigidbody2D rb;
    private Transform tiang;
    public TMP_Text scoreText; // Menampilkan score di UI

    // Tambahan untuk animasi
    private Animator animator;
    public RuntimeAnimatorController playerKiri;
    public RuntimeAnimatorController playerKanan;

    // Tambahan untuk suara
    public AudioSource audioSource;  // Referensi ke AudioSource
    public AudioClip hitSound;       // Suara ketika terkena obstacle

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // ambil Animator

        rb.gravityScale = 0f;

        tiang = GameObject.Find("tiang").transform;
    }

    public void MoveLeft()
    {
        rb.position = new Vector2(tiang.position.x - horizontalOffset, rb.position.y);
        Debug.Log("Move Left: " + rb.position);

        // Ganti animator ke animasi kiri
        if (animator != null && playerKiri != null)
        {
            animator.runtimeAnimatorController = playerKiri;
        }
    }

    public void MoveRight()
    {
        rb.position = new Vector2(tiang.position.x + horizontalOffset, rb.position.y);
        Debug.Log("Move Right: " + rb.position);

        // Ganti animator ke animasi kanan
        if (animator != null && playerKanan != null)
        {
            animator.runtimeAnimatorController = playerKanan;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Panggil Game Over dari GameManager
            GameManager.Instance.GameOver();

            // Mainkan suara ketika terkena obstacle
            if (audioSource != null && hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);  // Mainkan suara satu kali
            }
        }
    }
}
