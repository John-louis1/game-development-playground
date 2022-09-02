using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {
    public Rigidbody2D rbBall;
    public Rigidbody2D rbHook;
    public float maxDragDistance = 2f;
    public float releaseTime = .15f;
    private bool isPressed = false;
    public GameObject nextBall;
    void Start() {
        
    }

    void Update() {
        if (isPressed) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, rbHook.position) > maxDragDistance) {
			rbBall.position = rbHook.position + (mousePos - rbHook.position).normalized * maxDragDistance;
            } else {
                rbBall.position = mousePos;
            }
        }
    }

    void OnMouseDown() {
        isPressed = true;
        rbBall.isKinematic = true;
    }

    void OnMouseUp() {
        isPressed = false;
        rbBall.isKinematic = false; 
        StartCoroutine(Release());
    }

    IEnumerator Release() {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2f);
        if (nextBall != null) {
            nextBall.SetActive(true);
        } else {
            Enemy.EnemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
