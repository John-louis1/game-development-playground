using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int numberOfClicks = 2;

    void Update() {
        if (numberOfClicks <= 0) {
            Vector3 position = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0f); // New random position for the clicked game object
            transform.position = position; // Move the clicked game object to the new location
            numberOfClicks = 2;
        }
    }

    void RespawnWaitTime() {    // Hide the game object for a set amount of time and then unhide it

    }

    void RandomColor() {        // Change the material of the game object

    }

    public void setNumberOfClicks(int number) {
        numberOfClicks = number;
    }
}
