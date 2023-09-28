using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that manages the menu system.
/// </summary>
public class Menu : MonoBehaviour
{
    public GameObject _menu;
    public Animator mainCamera;
    public float transitionTime;

    public void Awake()
    {
        if (GameData.menu) LoadMenu();
    }

    /// <summary>
    /// Toggle on/off the menu screen UI.
    /// </summary>
    public void LoadMenu()
    {
        StartCoroutine(AnimateMenu(mainCamera, transitionTime));
        StartCoroutine(AnimateMenu(_menu.GetComponent<Animator>(), transitionTime));
        foreach (Transform child in _menu.transform.Find("Buttons"))
        {
            child.gameObject.GetComponent<Button>().interactable = !child.gameObject.GetComponent<Button>().interactable;
        }
    }

    /// <summary>
    /// Animates the menu based on transition.
    /// </summary>
    static IEnumerator AnimateMenu(Animator transition, float transitionTime)
    {
        transition.SetBool("Start", !transition.GetBool("Start"));

        yield return new WaitForSeconds(transitionTime);

    }

    /// <summary>
    /// NewGame button method.
    /// Will change to main screen and reset data file
    /// </summary>
    public void NewGame() 
    {
        GameData.menu = false;
        GameData.open = false;
        GameData.ResetData();
        LoadMenu();

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// Quit button methd.
    /// Quit application
    /// </summary>
    public void QuitGame()
    {
        //TODO Save File
        Application.Quit();
        Debug.Log("QUIT");
    }

    /// <summary>
    /// Calls menu when esc key is pressed.
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameData.open == false)
        {
            GameData.menu = !GameData.menu;
            LoadMenu();
        }
    }
}
