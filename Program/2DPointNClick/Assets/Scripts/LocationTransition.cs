using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Class holds transition data and methods.
/// </summary>
public class LocationTransition : MonoBehaviour
{
    
    public string nextlocation;
    public GameObject animatedObject;
    public float transitionTime;

    private void Awake()
    {
        animatedObject.SetActive(true);
    }

    /// <summary>
    /// Checks if object has been clicked and calls animator.
    /// </summary>
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Load(nextlocation, animatedObject.GetComponentInChildren<Animator>(), transitionTime);
    }
    /// <summary>
    /// Calls animator.
    /// </summary>
    public void Load(string scene, Animator transition, float transitionTime)
    {
        StartCoroutine(LoadLevel(scene, transition, transitionTime));
    }

    /// <summary>
    /// Animates the scene to specified scene based on transition.
    /// </summary>
    IEnumerator LoadLevel(string scene, Animator transition, float transitionTime)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
