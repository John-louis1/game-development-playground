using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    string tagName      = "enemy";      // Tag name of clicked game object
    float rayDistance   = 100f;         // Distance length of the ray for our raycast
    
    void Update() {
        if (Input.GetMouseButtonDown(0)) { // If left button clicked
            RaycastHit hit; // Clicked game object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Get mouse position
            if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.tag == tagName) { // if an object is clicked & is enemy
                Vector3 position = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0f); // New random position for the clicked game object
                hit.transform.position = position; // Move the clicked game object to the new location
                Debug.Log("You hit an enemy!");
            } else if (Physics.Raycast(ray, out hit, rayDistance)) {
                Debug.Log("This is not an enemy!");
            }
        }
    }
}
