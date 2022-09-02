using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 4f;
    void OnCollisionEnter2D(Collision2D colInfo) {

        if (colInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }
    void Die() {
        Destroy(gameObject);
    }
}
