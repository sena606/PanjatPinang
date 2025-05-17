using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab rintangan
    public float spawnRate = 2f;        // Setiap berapa detik spawn
    public float fallSpeed = 2f;        // Kecepatan jatuh obstacle
    public float offsetX = 0.5f;         // Jarak dari tiang

    private Transform tiang;            // Posisi tiang
    private float timer;

    void Start()
    {
        tiang = GameObject.Find("tiang").transform; // Cari tiang otomatis
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            timer = 0f;
            SpawnObstacle();
        }

        // Sedikit meningkatkan kecepatan jatuh seiring waktu
        fallSpeed += Time.deltaTime * 0.2f;
    }

    void SpawnObstacle()
    {
        // Random pilih kiri (-1) atau kanan (1)
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;

        // Hitung posisi spawn berdasarkan arah
        float spawnX = tiang.position.x + (direction * offsetX);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0f);

        // Spawn rintangan
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Tambahkan Rigidbody2D kalau belum ada
        Rigidbody2D rb = newObstacle.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = newObstacle.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, -fallSpeed);

        // Hapus obstacle setelah 10 detik biar nggak numpuk
        Destroy(newObstacle, 10f);
    }
}
