using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelLoading;

public class MainMenuScript : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelLoader ll = new LevelLoader();
        ll.LoadNextLevel();
    }

    public void Quit() {
        Application.Quit();
    }
}
