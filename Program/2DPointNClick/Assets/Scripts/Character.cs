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
        //Code used to edit character satisfaction
        //switch (character)
        //{
        //    case "Bee":
        //        GameData.satisfaction[1, 1] += 1;
        //        break;
        //    case "Silk":
        //        GameData.satisfaction[2, 1] += 1;
        //        break;
        //}
    }
    public void Update()
    {
        
    }
    public void OnMouseDown()
    {
        
    }
}
