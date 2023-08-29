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
    public string id; //Unique identifier for game object
    public itemType type; //Type of interactable item
    public int duration; //How long it takes to run
    public List<Interactable> container = new List<Interactable>(); //Container for tied items
    protected int _timeTaken; //How long appliance has been runnning
    [SerializeField] protected bool _active;   //If device is on
    [SerializeField] protected UnityEvent _on; //Called if item is on
    [SerializeField] protected UnityEvent _off;//Called if item is off

    public bool isOn() { return _active; }
    public abstract void Awake(); //Auto set variables for each
    public abstract void Activate(); //The function called when user clicks on game object
    public abstract void Reset(); //Object set back to base state
    public abstract void Check(); //Called every minute of the clock
    private void OnEnable()
    {
        TimeKeeper.onMinuteChanged += Check;
    }
    private void OnDisable()
    {
        TimeKeeper.onMinuteChanged -= Check;
    }
    private void OnMouseDown() //Call activate when object is clicked
    {
        if (container.Count == 0)
        {
            Activate();
        }
        else
        {
            foreach (Interactable i in container)
            {
                i.Activate();
            }
        }
    }
    
}
