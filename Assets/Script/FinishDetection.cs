using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetection : MonoBehaviour
{
    public GameTimer timerScript;

    [Header("Pengaturan Level (Isi di Inspector)")]
    [Tooltip("Nama Scene finish yang mau dituju, misal: FinishLvl2")]
    public string namaSceneSelanjutnya; 

    [Tooltip("Kunci penyimpanan rekor, misal: FastestTime_Lvl2")]
    public string namaKeySimpan; 

    private void OnTriggerEnter(Collider other)
    {
        // Pastikan nama bolanya benar 'Bola'
        if (other.gameObject.name == "Bola") 
        {
            Debug.Log("Finish Level Selesai!");
            
            // 1. Hentikan waktu
            timerScript.StopTimer(); 
            float timeFinish = timerScript.GetWaktuBerjalan();

            // 2. Simpan Waktu Sesi Ini 
            // (Supaya bisa muncul di layar 'Congratulations' sebagai 'Your Time')
            PlayerPrefs.SetFloat("LastSessionTime", timeFinish);
            
            // 3. Kirim Skor ke Leaderboard System (Top 5)
            // Script ini akan otomatis memasukkan skor baru, mengurutkan, dan membuang juara ke-6
            LeaderboardSystem.AddScore(namaKeySimpan, timeFinish);

            // 4. Pindah Scene sesuai yang Anda ketik di Inspector
            SceneManager.LoadScene(3);
        }
    }
}