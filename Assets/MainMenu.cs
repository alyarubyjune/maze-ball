using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame(int sceneIndex)
    {
        // Pastikan sceneIndex yang dimasukkan valid
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Nomor Indeks Scene tidak valid: " + sceneIndex);
        }
    }

   public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
   }
}