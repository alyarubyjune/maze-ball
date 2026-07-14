using UnityEngine;
using System.Collections.Generic;
using System.Linq; // Wajib ada untuk fitur Sort (Urutkan)

public static class LeaderboardSystem 
{
    // Fungsi untuk menambah skor baru
    public static void AddScore(string levelKey, float newTime)
    {
        // 1. Ambil data lama
        List<float> scores = GetScores(levelKey);

        // 2. Masukkan waktu baru
        scores.Add(newTime);

        // 3. Urutkan dari yang Tercepat (Kecil ke Besar)
        scores.Sort();

        // 4. Potong cuma ambil 5 Teratas
        if (scores.Count > 5)
        {
            scores.RemoveRange(5, scores.Count - 5);
        }

        // 5. Simpan balik ke PlayerPrefs
        SaveScores(levelKey, scores);
    }

    // Fungsi mengambil data menjadi tulisan rapi untuk UI
    public static string GetFormattedLeaderboard(string levelKey)
    {
        List<float> scores = GetScores(levelKey);
        
        if (scores.Count == 0) return "No Records";

        string textOutput = "";
        for (int i = 0; i < scores.Count; i++)
        {
            // Format: "1. 00:45"
            textOutput += (i + 1) + ". " + FormatWaktu(scores[i]) + "\n";
        }
        return textOutput;
    }

    // --- BAGIAN TEKNIS (JEROAN) ---

    private static List<float> GetScores(string key)
    {
        string data = PlayerPrefs.GetString(key, "");
        if (string.IsNullOrEmpty(data)) return new List<float>();

        // Pecah string "10,20,30" menjadi List angka
        return data.Split(',').Select(s => float.Parse(s)).ToList();
    }

    private static void SaveScores(string key, List<float> scores)
    {
        // Gabung List angka jadi satu string "10,20,30"
        string data = string.Join(",", scores);
        PlayerPrefs.SetString(key, data);
        PlayerPrefs.Save();
    }

    private static string FormatWaktu(float waktu)
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        return string.Format("{0:00}:{1:00}", menit, detik);
    }
}