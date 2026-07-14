using UnityEngine;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI langText; 
    private bool isEnglish = true; 

    // Fungsi Start dijalankan otomatis saat objek muncul pertama kali
    void Start()
    {
        // Memastikan tampilan awal sesuai dengan variabel isEnglish
        SetLanguageUI();
    }

    public void ToggleLanguage()
    {
        isEnglish = !isEnglish; 
        SetLanguageUI();
    }

    // Kita pindahkan logika teks ke fungsi terpisah agar bisa dipanggil Start & Toggle
    void SetLanguageUI()
    {
        if (isEnglish)
        {
            langText.text = "ID";
            targetText.text = "1. Get the marker <color=#0000FF><u><link=\"https://bit.ly/Maze-Ball\">here</link></u></color>\n" +
                              "2. Scan the marker to make the maze appears\n" +
                              "3. Tilt the marker to make the maze tilting\n" +
                              "4. Guide the ball to the finish\n";
        }
        else
        {
            langText.text = "EN";
            targetText.text = "1. Dapatkan markernya <color=#0000FF><u><link=\"https://bit.ly/Maze-Ball\">disini</link></u></color>\n" +
                              "2. Pindai markernya agar labirin muncul\n" +
                              "3. Miringkan marker supaya labirin miring\n" +
                              "4. Pandu bola ke garis finish";
        }
    }
}