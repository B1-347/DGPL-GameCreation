using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefaultItem : Interactable
{
    public override void Awake()
    {
        type = itemType.DEFAULT;
        Reset();
    }

    public override void Activate()
    {
        if(!_active)
        {
            _active = true;
            _on.Invoke();
        }
        else
        {
            _active = false;
            _off.Invoke();
        }
    }
    public override void Check()
    {
        //Count how long it has been on
        if(_active)_timeTaken++;
    }
    public override void Reset()
    {
        _active = false;
        _timeTaken = 0;
        duration = 0;
    }
}
