using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        int limit = SceneManager.sceneCount + 1;
        int scene = SceneManager.GetActiveScene().buildIndex + 1;
        if (limit <= scene) scene = 0;
        StartCoroutine(LoadLevel(scene));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        print("IEnumerator");
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
