using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public GameObject deathEffect, hurtEffect;
    public float health = 4f;
    void Start() {
        EnemiesAlive++;
    }
    void OnCollisionEnter2D(Collision2D colInfo) {
        health -= colInfo.relativeVelocity.magnitude * 0.5f;
        if (health <= 0) {
            Die();
        } else {
            Hurt();
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
    void Hurt() {
        Instantiate(hurtEffect, transform.position, Quaternion.identity);
    }
}
