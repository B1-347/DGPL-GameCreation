//https://www.youtube.com/watch?v=RuvfOl8HhhM

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
 
    private void OnEnable()
    {
        TimeKeeper.onMinuteChanged += Check;
    }
    private void OnDisable()
    {
        TimeKeeper.onMinuteChanged -= Check;
    }

    public void Awake()
    {
        name = "master";
    }

    public void Check()
    {
        //foreach(Item i in )
        // if(TimeKeeper.time ==)
    }


}
