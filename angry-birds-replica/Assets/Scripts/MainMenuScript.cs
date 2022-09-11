using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelLoading;

public class MainMenuScript : MonoBehaviour
{
    public static bool play = false;
    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        play = true;
    }

    public void Quit() {
        Application.Quit();
    }
    
}
