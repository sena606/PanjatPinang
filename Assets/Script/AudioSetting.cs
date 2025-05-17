using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public enum AudioType { BGM, SFX }
    public AudioType audioType;

    public Image statusImage;        // Gambar wadah yang akan berubah saat audio aktif/nonaktif
    public Sprite onSprite;          // Gambar untuk status aktif
    public Sprite offSprite;         // Gambar untuk status nonaktif

    private bool isOn = true;         // Status aktif/nonaktif audio

    private const string BGM_KEY = "BGM_STATE";   // Kunci untuk status BGM di PlayerPrefs
    private const string SFX_KEY = "SFX_STATE";   // Kunci untuk status SFX di PlayerPrefs

    void Start()
    {
        LoadState();                  // Memuat status dari PlayerPrefs
        UpdateUI();                   // Memperbarui tampilan UI sesuai dengan status
        UpdateAudio();                // Menyesuaikan audio sesuai dengan status
    }

    // Fungsi untuk toggle status audio ketika tombol di-klik
    public void ToggleAudio()
    {
        isOn = !isOn;                 // Membalik status
        SaveState();                  // Menyimpan status terbaru ke PlayerPrefs
        UpdateUI();                   // Memperbarui tampilan UI
        UpdateAudio();                // Memperbarui status audio (aktif/nonaktif)
    }

    // Fungsi untuk memperbarui UI (mengubah gambar wadah berdasarkan status)
    void UpdateUI()
    {
        if (statusImage != null)
        {
            statusImage.sprite = isOn ? onSprite : offSprite;
        }
    }

    // Fungsi untuk memperbarui status audio (BGM/SFX)
    void UpdateAudio()
    {
        if (AudioManager.Instance == null) return;

        if (audioType == AudioType.BGM)
        {
            AudioManager.Instance.bgmSource.mute = !isOn;  // Menonaktifkan BGM jika isOn = false
        }
        else if (audioType == AudioType.SFX)
        {
            AudioManager.Instance.sfxSource.mute = !isOn;  // Menonaktifkan SFX jika isOn = false
        }
    }

    // Fungsi untuk memuat status audio dari PlayerPrefs
    void LoadState()
    {
        string key = audioType == AudioType.BGM ? BGM_KEY : SFX_KEY;
        isOn = PlayerPrefs.GetInt(key, 1) == 1;  // Mengambil nilai 1 (aktif) atau 0 (nonaktif)
    }

    // Fungsi untuk menyimpan status audio ke PlayerPrefs
    void SaveState()
    {
        string key = audioType == AudioType.BGM ? BGM_KEY : SFX_KEY;
        PlayerPrefs.SetInt(key, isOn ? 1 : 0);  // Menyimpan status aktif (1) atau nonaktif (0)
    }
}
