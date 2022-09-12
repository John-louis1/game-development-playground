using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMainMenu : MonoBehaviour {
    public float buttonSize = 100f;
    void OnGUI() {
        if (GUI.Button(new Rect(30, 30, buttonSize, 50), "Start Game")) {
            SceneManager.LoadScene("sceneLevel1");
        }
        if (GUI.Button(new Rect(30, 90, buttonSize, 50), "Exit Game")) {
            Application.Quit();
        }
    }
}
