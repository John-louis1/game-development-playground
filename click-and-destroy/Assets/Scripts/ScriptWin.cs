using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptWin : MonoBehaviour {
    public float buttonSize = 100f;
    void OnGUI() {
        GUI.Label(new Rect(30, 30, 100, 50), "You Win!");
        if (GUI.Button(new Rect(30, 90, buttonSize, 50), "Restart Game")) {
            SceneManager.LoadScene("sceneLevel1");
        }
        if (GUI.Button(new Rect(30, 150, buttonSize, 50), "Exit Game")) {
            Application.Quit();
        }
    }
}
