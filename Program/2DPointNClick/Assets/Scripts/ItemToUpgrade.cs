using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToUpgrade : MonoBehaviour
{
    public string id;
    private Resources resource;

    void Start()
    {
        if (GameData.unlocks[id] != -1)
        {
            this.transform.GetChild(GameData.unlocks[id]).gameObject.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        for(int index = 0; index < this.transform.childCount; index++)
        {
            Transform child = this.transform.GetChild(index);
            
            if (child.gameObject.activeSelf == true && index + 1 < this.transform.childCount)
            {
                Transform upgrade = this.transform.GetChild(index + 1);
                resource = GameObject.Find("SceneElements/Resources").GetComponent<Resources>();
                int[] cost = upgrade.GetComponent<ItemResource>().cost;
                if (resource.checkResources(cost))
                {
                    resource.Cost(cost);
                    child.gameObject.SetActive(false);
                    upgrade.gameObject.SetActive(true);

                }
                else 
                {

                }
            }
        }
    }

}
