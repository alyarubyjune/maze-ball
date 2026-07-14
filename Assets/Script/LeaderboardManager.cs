using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    // Hubungkan masing-masing objek Text di Inspector
    [Header("UI Text Slots")]
    public TextMeshProUGUI txtLevel1;
    public TextMeshProUGUI txtLevel2;
    public TextMeshProUGUI txtLevel3;

    void Start()
    {
        // Panggil fungsi untuk memuat data saat Scene dibuka
        UpdateLeaderboardUI();
    }

    void UpdateLeaderboardUI()
    {
        // Level 1
        if (txtLevel1 != null) 
        {
            // Minta teks rapi (1-5) dari sistem
            txtLevel1.text = LeaderboardSystem.GetFormattedLeaderboard("FastestTime_Lvl1");
        }

        // Level 2
        if (txtLevel2 != null)
        {
            txtLevel2.text = LeaderboardSystem.GetFormattedLeaderboard("FastestTime_Lvl2");
        }

        // Level 3
        if (txtLevel3 != null)
        {
            txtLevel3.text = LeaderboardSystem.GetFormattedLeaderboard("FastestTime_Lvl3");
        }
    }

    string FormatWaktu(float waktu)
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        return string.Format("{0:00}:{1:00}", menit, detik);
    }
}