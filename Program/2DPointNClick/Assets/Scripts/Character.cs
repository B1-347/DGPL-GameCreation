using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string character;
    public int satisfaction;
    public Animator animations;
    public GameObject resources;
    public GameObject workstation;
    public GameObject imageBoundary;
    
    //private float _minuteToRealTime = 0.5f;
    private float _timer;

    public enum states { 
        MOVING,
        IDLE,
        WORKING,
        FARMING,
    }
    public void nextAction() 
    {
        
    }
    public void Awake()
    {
        
    }
    public void Update()
    {
        
    }
    public void OnMouseDown()
    {
        
    }
}
