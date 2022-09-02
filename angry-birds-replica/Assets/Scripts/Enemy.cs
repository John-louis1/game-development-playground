using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public GameObject deathEffect;
    public float health = 4f;
    void Start() {
        EnemiesAlive++;
    }
    void OnCollisionEnter2D(Collision2D colInfo) {
        if (colInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }
    
    void Die() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        EnemiesAlive--;
        if (EnemiesAlive <= 0) {
            Debug.Log("Level WON!");
        }
    }
}
