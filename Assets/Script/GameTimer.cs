using UnityEngine;
using TMPro; // atau UnityEngine.UI

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private float waktuBerjalan;
    private bool gameSelesai = false;
    
    private bool markerTerlihat = false; 

    void Update()
    {
        // BARU: Tambahkan syarat '&& markerTerlihat'
        // Artinya: Timer jalan HANYA JIKA game belum selesai DAN marker sedang terlihat
        if (gameSelesai == false && markerTerlihat == true)
        {
            waktuBerjalan += Time.deltaTime;
            UpdateTampilanWaktu(waktuBerjalan);
        }
    }

    void UpdateTampilanWaktu(float waktu)
    {
        float menit = Mathf.FloorToInt(waktu / 60);
        float detik = Mathf.FloorToInt(waktu % 60);
        timerText.text = string.Format("{0:00}:{1:00}", menit, detik);
    }

    public void StopTimer()
    {
        gameSelesai = true;
        timerText.color = Color.green;
    }

    // --- FUNGSI BARU UNTUK VUFORIA ---

    // Dipanggil saat Marker Ketemu
    public void MulaiHitung()
    {
        markerTerlihat = true;
    }

    // Dipanggil saat Marker Hilang (Kertas diangkat/ketutup)
    public void PauseHitung()
    {
        markerTerlihat = false;
    }

    // Tambahkan fungsi ini di dalam class GameTimer
    public float GetWaktuBerjalan()
    {
        return waktuBerjalan;
    }
}