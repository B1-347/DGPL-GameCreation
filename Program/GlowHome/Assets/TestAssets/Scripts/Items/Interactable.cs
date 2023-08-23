using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum itemType
{
    DEFAULT, //Instantly Switches on
    BAR,     //Will add or decrease too completion percentage
    SEGMENT  //Will automatically switch off after an increment
}

public abstract class Interactable : MonoBehaviour
{
    public itemType type;
    public string id;
    public float duration; //How long it takes to run
    public List<Interactable> container = new List<Interactable>();

    public abstract void Activate();
    

    private void OnMouseDown()
    {
        foreach (Interactable i in container)
        {
            i.Activate();
        }
    }

}
