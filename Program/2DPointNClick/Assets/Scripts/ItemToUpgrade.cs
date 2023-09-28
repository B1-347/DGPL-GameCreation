using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToUpgrade : MonoBehaviour
{
    public string id;
    public GameObject arrows;

    void Start()
    {
        if (GameData.unlocks[id] != -1)
        {
            this.gameObject.transform.GetChild(GameData.unlocks[id]).gameObject.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        arrows.gameObject.transform.position = this.gameObject.transform.position;
        arrows.gameObject.SetActive(!arrows.activeSelf);
    }

}
