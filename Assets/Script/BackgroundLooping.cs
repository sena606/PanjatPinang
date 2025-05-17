using UnityEngine;

public class BackgroundLooping : MonoBehaviour
{
   public float speed = 1f; // Kecepatan turun
    public float resetPositionY = -10f; // Batas bawah sebelum reset
    public float startPositionY = 10f; // Posisi reset di atas

    void Update()
    {
        // Gerakkan tiang ke bawah
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Reset posisi jika tiang melewati batas bawah
        if (transform.position.y <= resetPositionY)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, startPositionY, transform.position.z);
    }
}
