using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Hapus obstacle jika berada di luar layar
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
