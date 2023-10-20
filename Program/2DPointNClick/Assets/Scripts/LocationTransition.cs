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

    private float _beatToReal = 10f;
    private float _timer;

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
        if (this.GetComponent<AudioSource>() != null) 
        {
            this.GetComponent<AudioSource>().Play();
        }
        
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

    /// <summary>
    /// Resource tick up.
    /// </summary>
    public void Update()
    {
        if (GameData.menu == false)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                for (int index = 0; index < GameData.resources.Length/2; index++)
                {
                    int num = 1 * GameData.satisfaction[index, 1];
                    if (GameData.resources[index, 1] + num <= 999 && GameData.resources[index, 0] == 1)
                    {
                        GameData.resources[index, 1] += num;
                    }
                    else if (GameData.resources[index, 1] + num > 999 && GameData.resources[index, 0] == 1)
                    {
                        GameData.resources[index, 1] = 999;
                    }
                }

                _timer = _beatToReal;
            }
        }
    }
}
