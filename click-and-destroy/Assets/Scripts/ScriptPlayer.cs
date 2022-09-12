using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptPlayer : MonoBehaviour
{
    public string tagName      = "enemy";       // Tag name of clicked game object
    public float rayDistance   = 100f;          // Distance length of the ray for our raycast
    public int score = 0;                       // Score of the player
    public float gameTime = 20f;                // Duration of the game
    public float loadWaitTime = 3f;
    public int numberOfPointToWin = 5;
    
    void Start() {
        InvokeRepeating("CountDown", 1.0f, 1.0f);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) { // If left button clicked
            RaycastHit hit; // Clicked game object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Get mouse position
            if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.tag == tagName) { // if an object is clicked & is enemy
                    hit.transform.GetComponent<ScriptEnemy>().numberOfClicks--;
                if (hit.transform.GetComponent<ScriptEnemy>().numberOfClicks == 0) {
                    score += ScriptEnemy.enemyPoint;
                    Debug.Log(score);
                }
            } else if (Physics.Raycast(ray, out hit, rayDistance)) {
                Debug.Log("This is not an enemy!");
            }
        }
    }

    void CountDown() {
        if (--gameTime == 0) { // Subtract from game time
            CancelInvoke("CountDown"); // Cancel when game time is zero
            StartCoroutine(SceneChangerWaitTime());
            SceneManager.LoadScene((score >= numberOfPointToWin)?"sceneWin":"sceneLose");
        } 
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 30, 100, 20), "Score: " + score);
        GUI.Label(new Rect(10, 45, 100, 35), "Time: " + gameTime);
    }

     IEnumerator SceneChangerWaitTime() {
        yield return new WaitForSeconds(loadWaitTime);
    }
}
