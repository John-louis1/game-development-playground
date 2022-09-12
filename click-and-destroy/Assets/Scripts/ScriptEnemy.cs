using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour {
    public Color[] shapeColor;              // Color of the object
    public int numberOfClicks = 2;          // How many times to click on object before it is destroyed
    public float respawnWaitTime = 2.0f;    // How long to hide
    public Transform explosion;             // Load particle effect
    public static int enemyPoint = 1;       // Value of the enemy object
    int storeClicks = 0;

    void Start() {
        storeClicks = numberOfClicks;
        Vector3 startPosition = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0f); // New random position for the clicked game object
        transform.position = startPosition;
        RandomColor();
    }

    void Update() {
        if (numberOfClicks <= 0) {
            if (transform.GetComponent<AudioSource>()) {
                transform.GetComponent<AudioSource>().Play();
            }
            Explode();
            Vector3 position = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0f); // New random position for the clicked game object
            StartCoroutine(RespawnWaitTime());
            transform.position = position; // Move the clicked game object to the new location
            numberOfClicks = storeClicks;
        }
    }

    void Explode() {
        if (explosion) {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    void RandomColor() {        // Change the material of the game object
        if (shapeColor.Length > 0) {
            Color newColor = shapeColor[Random.Range(0, shapeColor.Length)];
            transform.GetComponent<Renderer>().material.color = newColor;
        }
    } 

    IEnumerator RespawnWaitTime() {
        transform.GetComponent<Renderer>().enabled = false;
        RandomColor();
        yield return new WaitForSeconds(respawnWaitTime);
        transform.GetComponent<Renderer>().enabled = true;
    }
}
