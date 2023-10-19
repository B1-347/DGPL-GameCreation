using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class edits and displays GameData resources.
/// </summary>
public class Resources : MonoBehaviour
{
    void Start()
    {
        UpdateResources();
        Unlocked();
    }

    public void Unlocked()
    {
        foreach (Transform resource in this.gameObject.transform)
        {
            resource.gameObject.SetActive(GameData.resources[resource.GetSiblingIndex(), 0] == 1);
        }
    }

    /// <summary>
    /// Pulls resources based on order and number in array.
    /// </summary>
    public void Cost(int[] resources) 
    {
        if (checkResources(resources) == false) return;

        for (int i = 0; i < resources.Length && GameData.resources[i, 0] == 1; i++)
        {
            GameData.resources[i,1] -= resources[i];
        }

        UpdateResources();
    }

    /// <summary>
    /// Returns resources to 0.
    /// </summary>
    public bool checkResources(int[] resources)
    {
        for (int i = 0; i < resources.Length && GameData.resources[i, 0] == 1; i++)
        {
            if (GameData.resources[i,1] < resources[i])return false;
        }
        
        return true;
    }

    /// <summary>
    /// Returns resources to 0.
    /// </summary>
    public void ResetCount()
    {
        for (int i = 0; i < GameData.resources.Length; i++)
        {
            GameData.resources[i,1] = 0;
        }
    }

    /// <summary>
    /// Writes resource values from GameData into display.
    /// </summary>
    public void UpdateResources()
    {
        foreach (Transform resource in this.gameObject.transform)
        {
            if (GameData.resources[resource.GetSiblingIndex(),0]== 1)
            {
                resource.Find("Count").GetComponent<TMP_Text>().text = GameData.resources[resource.GetSiblingIndex(), 1].ToString();
            }            
        }
    }

    public void Update()
    {
        UpdateResources();
    }
}
