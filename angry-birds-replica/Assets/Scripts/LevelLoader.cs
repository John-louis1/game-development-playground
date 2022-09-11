using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelLoading {
    public class LevelLoader : MonoBehaviour
    {
        public Animator transition;
        public float transitionDuration = 1f;
        
        void Update() {
            if ((SceneManager.GetActiveScene().buildIndex != 0 && Enemy.EnemiesAlive <= 0)
            || (SceneManager.GetActiveScene().buildIndex == 0 && MainMenuScript.play)) {
                LoadNextLevel();
            } 
        }

        public void LoadNextLevel() {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        IEnumerator LoadLevel(int levelIndex) {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionDuration);
            SceneManager.LoadScene(levelIndex);
        }
    }
}
