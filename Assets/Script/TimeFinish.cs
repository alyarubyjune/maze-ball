using UnityEngine;
using TMPro;

public class TimeFinish : MonoBehaviour
{
    public TextMeshProUGUI txtTimeNow;
    public TextMeshProUGUI txtLevel1;
    public TextMeshProUGUI txtLevel2;
    public TextMeshProUGUI txtLevel3;

    void Start()
    {
        float lastTime = PlayerPrefs.GetFloat("LastSessionTime", 0f);
        
        // Gunakan nilai default yang sangat besar (9999) untuk rekor
        float bestTimeLv1 = PlayerPrefs.GetFloat("FastestTime_Lvl1", 9999f);
        float bestTimeLv2 = PlayerPrefs.GetFloat("FastestTime_Lvl2", 9999f);
        float bestTimeLv3 = PlayerPrefs.GetFloat("FastestTime_Lvl3", 9999f);

        // Tampilkan Waktu Sekarang dengan kalimat bahasa Inggris yang kamu minta
        txtTimeNow.text = FormatWaktu(lastTime);

        // Cek jika belum ada rekor
        if (txtLevel1 != null) 
        {
            txtLevel1.text = (bestTimeLv1 >= 9999f) ? "No Record" : FormatWaktu(bestTimeLv1);
        }

        // Cek jika belum ada rekor
        if (txtLevel2 != null) 
        {
            txtLevel2.text = (bestTimeLv2 >= 9999f) ? "No Record" : FormatWaktu(bestTimeLv2);
        }

        // Cek jika belum ada rekor
        if (txtLevel3 != null) 
        {
            txtLevel3.text = (bestTimeLv3 >= 9999f) ? "No Record" : FormatWaktu(bestTimeLv3);
        }


        // // Ambil waktu sesi terakhir
        // float lastTime = PlayerPrefs.GetFloat("LastSessionTime", 0f);
        // // Ambil rekor tercepat
        // float bestTimeLv1 = PlayerPrefs.GetFloat("FastestTime_Lvl1", 0f);
        // float bestTimeLv2 = PlayerPrefs.GetFloat("FastestTime_Lvl2", 0f);
        // float bestTimeLv3 = PlayerPrefs.GetFloat("FastestTime_Lvl3", 0f);

        // // Tampilkan Waktu Sekarang
        // txtTimeNow.text = "Your Time: " + FormatWaktu(lastTime);

        // // Tampilkan Rekor Tercepat
        // txtFastestTimeLv1.text = "Fastest Time: " + FormatWaktu(bestTimeLv1);
        // txtFastestTimeLv2.text = "Fastest Time: " + FormatWaktu(bestTimeLv2);
        // txtFastestTimeLv3.text = "Fastest Time: " + FormatWaktu(bestTimeLv3);
    }

    // Fungsi pembantu agar formatnya selalu 00:00
    string FormatWaktu(float waktu)
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        return string.Format("{0:00}:{1:00}", menit, detik);
    }
}